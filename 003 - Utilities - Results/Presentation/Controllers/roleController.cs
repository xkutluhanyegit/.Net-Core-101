using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Request.RoleRequest;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class roleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public roleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("getall-roles")]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var result = await _roleService.GetAllRolesAsync();
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleRequest request)
        {
            var result = await _roleService.AddRoleAsync(request);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}