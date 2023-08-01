using Core.Dtos;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Core.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}