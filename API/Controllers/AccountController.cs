using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FloofyWoof.Controllers;

public class AccountController : BaseApiController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;

    public AccountController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IMapper mapper,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AppUser>> RegisterAsync(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.UserName)) 
            return BadRequest("Username is already taken");

        var user = _mapper.Map<AppUser>(registerDto);
        user.UserName = user.UserName?.ToLower();

        var createUser = await _userManager.CreateAsync(user, registerDto.Password);
        if (!createUser.Succeeded)
            return BadRequest("Error creating new user");
        
        return Ok(new UserDto
        {
            UserName = user.UserName,
            Token = await _tokenService.CreateToken(user),
        });
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> LoginAsync(LoginDto loginDto)
    {
        var user = await _userManager.Users
            .SingleOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());
        if (user == null)
            return Unauthorized();

        var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (!checkPassword.Succeeded)
            return Unauthorized();

        return Ok(new UserDto()
        {
            UserName = user.UserName,
            Token = await _tokenService.CreateToken(user)
        });
    }

    private async Task<bool> UserExists(string username)
    {
        return await _userManager.Users.AnyAsync(x => x.UserName == username);
    }
}