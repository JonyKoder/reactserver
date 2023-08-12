using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public  async Task<List<Company>> GetCompanyes()
        {
           var companys = await db.Companies.ToListAsync();
           return companys;
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
