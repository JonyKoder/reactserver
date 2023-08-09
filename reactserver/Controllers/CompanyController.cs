using Microsoft.AspNetCore.Mvc;
using reactserver.Domain.Models;
using System.ComponentModel.Design;

namespace reactserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        [HttpGet]
        [Route("GetCompany")]
        public Company GetCompanyes()
        {
            var company = new Company();

            company.DateRegistration = DateTime.Now;
            company.FullName = "Что попало";
            company.Id = Guid.NewGuid();
            company.INN = "d222233111";
            company.OGRN = "12432213242133213";

           
            return company;
        }
    }
}
