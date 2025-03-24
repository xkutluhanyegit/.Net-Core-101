using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Request.AuthRequest;
using Application.DTOs.Request.UserRoleRequest;
using Application.DTOs.Response.AuthResponse;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.UnitOfWork;
using Domain.Utilities.Results.Implementations;
using Domain.Utilities.Results.Interfaces;
using Infrastructure.Identity.Hasher;
using Infrastructure.Identity.Jwt;
using Infrastructure.Repositories.RoleRepository;
using Infrastructure.Repositories.UserRepository;
using Infrastructure.Repositories.UserRoleRepository;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleService _userRoleService;
        private readonly IUnitOfWork _unitOfWork;
        public AuthService(IUserService userService,IUserRepository userRepository,
        IMapper mapper,IPasswordHasher passwordHasher,
        ITokenService tokenService,IRoleRepository roleRepository,
        IUserRoleService userRoleService,IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _roleRepository = roleRepository;
            _userRoleService = userRoleService;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }
        public async Task<IDataResult<AuthResponse>> CreateUserAsync(RegisterRequest request)
        {
            var userExist = await _userRepository.isExistAsync(x=>x.Email == request.Email);
            if (userExist)
            {
                return new ErrorDataResult<AuthResponse>("User Exist");
            }

            _passwordHasher.CreatePasswordHash(request.Password,out byte [] _passwordHash, out byte [] _passwordSalt);
            var user = _mapper.Map<User>(request);
            user.PasswordHash = _passwordHash;
            user.PasswordSalt = _passwordSalt;

            var result = await _userService.AddUserAsync(user);
            if (result.Success)
            {
                //UserRole Table Added
                var getUserRoleId = await _roleRepository.GetAsync(x=> x.Name == Roles.User.ToString());
                await _userRoleService.AddAsync(new AddUserRoleRequest{roleId = getUserRoleId.Id,userId = user.Id});
                var userRoles = await _userRepository.GetUserRoleNameByUserId(user.Id);
                
                var token = _tokenService.GenerateToken(user.Id,user.Email,userRoles);


                await _unitOfWork.CommitTransactionAsync();
                return new SuccessDataResult<AuthResponse>( new AuthResponse {Token = token});
            }

            return new ErrorDataResult<AuthResponse>();

        }

        public async Task<IDataResult<AuthResponse>> LoginAsync(LoginRequest request)
        {
            //
            var user = await _userRepository.GetAsync(x=>x.Email == request.Email);
            if (user == null)
            {
                return new ErrorDataResult<AuthResponse>("User not found");
            }

            var passwordValid =  _passwordHasher.VerifyPasswordHash(request.Password,user.PasswordHash,user.PasswordSalt);
            if (!passwordValid)
            {
                return new ErrorDataResult<AuthResponse>("Invalid password");
            }

            var userRoles = await _userRepository.GetUserRoleNameByUserId(user.Id);
            var token = _tokenService.GenerateToken(user.Id,user.Email,userRoles);

            return new SuccessDataResult<AuthResponse>(new AuthResponse{Token = token});

        }
    }
}