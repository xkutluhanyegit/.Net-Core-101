using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Request.ClaimRequest;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Utilities.Results.Implementations;
using Domain.Utilities.Results.Interfaces;
using Infrastructure.Repositories.ClaimRepository;

namespace Application.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IMapper _mapper;
        public ClaimService(IClaimRepository claimRepository,IMapper mapper)
        {
            _claimRepository = claimRepository;
            _mapper = mapper;
        }

        public async Task<IResult> AddClaimAsync(AddClaimRequest request)
        {
            var claim = _mapper.Map<Claim>(request);
            var entity = _claimRepository.AddAsync(claim);
            if (entity == null)
            {
                return new ErrorResult("Error");
            }
            await _claimRepository.SaveChangeAsync();
            return new SuccessResult("Success");
        }

        public async Task<IDataResult<IEnumerable<Claim>>> GetAllClaimsAsync()
        {
            var entity = await _claimRepository.GetAllAsync();
            if (entity == null)
            {
                return new ErrorDataResult<IEnumerable<Claim>>("Error");
            }
            return new SuccessDataResult<IEnumerable<Claim>>(entity,"Success");
        }
    }
}