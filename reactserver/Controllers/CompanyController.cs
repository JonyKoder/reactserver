using Microsoft.AspNetCore.Mvc;
using reactserver.database;
using reactserver.Domain.Models;
using System.ComponentModel.Design;

namespace reactserver.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private AppDbContext db;

        public CompanyController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("GetCompany")]
        public Company GetCompanyes()
        {
            var company = new Company();

            company.FullName = "Что попало";
            company.Id = Guid.NewGuid();
            company.INN = "d222233111";
            company.OGRN = "12432213242133213";

           
            return company;
        }
        [HttpPost]
        [Route("CreateCompany")]
        public IActionResult CreateCompany([FromBody] CompanyRequest request)
        {
            var company = new Company();

            company.SetDateRegistration(request.DateRegistration);
            company.FullName = request.FullName;
            company.Id = Guid.NewGuid();
            company.INN = request.INN;
            company.OGRN = request.OGRN;
            db.Companies.Add(company);
            int affectedRows = db.SaveChanges();

            if (affectedRows > 0)
            {
                return Ok(new { message = "Компания успешно создана", company });
            }
            else
            {
                return BadRequest(new { message = "Ошибка создания компании" });
            }
        }
    }
}
