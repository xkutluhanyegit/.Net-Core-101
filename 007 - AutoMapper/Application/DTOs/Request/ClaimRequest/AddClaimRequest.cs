using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Request.ClaimRequest
{
    public class AddClaimRequest
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string Description { get; set; }
    }
}