using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Request.ClaimRequest;
using Domain.Entities;
using Domain.Utilities.Results.Interfaces;

namespace Application.Interfaces
{
    public interface IClaimService
    {
        Task<IDataResult<IEnumerable<Claim>>> GetAllClaimsAsync();
        Task<IResult> AddClaimAsync(AddClaimRequest request);
    }
}