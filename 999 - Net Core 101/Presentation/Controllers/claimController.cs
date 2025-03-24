using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Request.ClaimRequest;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class claimController : ControllerBase
    {
        private readonly IClaimService _claimService;
        public claimController(IClaimService claimService)
        {
            _claimService = claimService;
        }
        [HttpGet("getall-claims")]
        public async Task<IActionResult> GetAllClaimsAsync()
        {
            var result = await _claimService.GetAllClaimsAsync();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("add-claim")]
        public async Task<IActionResult> AddClaimAsync([FromBody] AddClaimRequest request)
        {
            var result = await _claimService.AddClaimAsync(request);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}