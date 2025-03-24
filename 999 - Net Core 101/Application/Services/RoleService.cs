using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Request.RoleRequest;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Utilities.Results.Implementations;
using Domain.Utilities.Results.Interfaces;
using Infrastructure.Repositories.RoleRepository;

namespace Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository,IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IResult> AddRoleAsync(AddRoleRequest request)
        {

            var roleExist = await _roleRepository.isExistAsync(x=> x.Name == request.Name);
            if (roleExist)
            {
                return new ErrorResult("Role Exist");
            }

            var role = _mapper.Map<Role>(request);

            var entity =  _roleRepository.AddAsync(role);
            if (entity == null)
            {
                return new ErrorResult("Error");
            }
            await _roleRepository.SaveChangeAsync();
            
            return new SuccessResult("Added successfully.");
        }

        public async Task<IDataResult<IEnumerable<Role>>> GetAllRolesAsync()
        {
            var entity = await _roleRepository.GetAllAsync();
            if (entity == null)
            {
                return new ErrorDataResult<IEnumerable<Role>>();
            }
            return new SuccessDataResult<IEnumerable<Role>>(entity);
        }

    }
}