using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Request.AuthRequest;
using Application.DTOs.Response.AuthResponse;
using Domain.Utilities.Results.Interfaces;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<IDataResult<AuthResponse>> CreateUserAsync(RegisterRequest request);
        Task<IDataResult<AuthResponse>> LoginAsync(LoginRequest request);
    }
}