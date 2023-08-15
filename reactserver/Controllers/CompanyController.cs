using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reactserver.Application.Interfaces;
using reactserver.database;
using reactserver.Domain.Models;
using System.ComponentModel.Design;

namespace reactserver.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [Route("CreateCompany")]
        public async Task<IActionResult> CreateCompany([FromForm] CompanyDto request)
        {
            await _companyService.CreateAsync(request);

            return Ok();
        }
    }
}
