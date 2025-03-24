using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Validation.FluentValidation;
using Domain.Aspects.Autofac.Validation;
using Domain.Entities;
using Domain.Utilities.Results.Implementations;
using Domain.Utilities.Results.Interfaces;
using Infrastructure.Repositories.UserRepository;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [ValidationAspect(typeof(UserValidator))]
        public async Task<IResult> AddUserAsync(User user)
        {
            var entity = _userRepository.AddAsync(user);
            if (entity == null)
            {
                return new ErrorResult("Error");
            }
            return new SuccessResult("Success");
        }

        public async Task<IDataResult<IEnumerable<User>>> GetAllUserAsync()
        {
            var entity = await _userRepository.GetAllAsync();
            if (entity == null)
            {
                return new ErrorDataResult<IEnumerable<User>>("Error");
            }
            return new SuccessDataResult<IEnumerable<User>>(entity,"Success");
        }
    }
}