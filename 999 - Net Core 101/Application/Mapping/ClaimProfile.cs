using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Request.ClaimRequest;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class ClaimProfile:Profile
    {
        public ClaimProfile()
        {
            CreateMap<Claim,AddClaimRequest>();
            CreateMap<AddClaimRequest,Claim>();
        }
    }
}