using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Request.UserRoleRequest;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Utilities.Results.Implementations;
using Domain.Utilities.Results.Interfaces;
using Infrastructure.Repositories.UserRoleRepository;

namespace Application.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;
        public UserRoleService(IUserRoleRepository userRoleRepository,IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(AddUserRoleRequest request)
        {
            var userRole = _mapper.Map<UserRole>(request);
            var entity = _userRoleRepository.AddAsync(userRole);
            if (entity == null)
            {
                return new ErrorResult("Error");
            }
            return new SuccessResult("Success");

        }
    }
}