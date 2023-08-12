using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reactserver.database;
using reactserver.Domain.Models;

namespace reactserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private AppDbContext _appDbContext;

        public BankAccountController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] BankAccountRequest request)
        {
            var bank = new BankAccount();

            bank.BankAddress = request.BankAddress;
            bank.BankName = request.BankName;
            bank.AccountNumber = request.AccountNumber;
            bank.BankCode = request.BankCode;
            bank.Id = Guid.NewGuid();
            _appDbContext.BankAccounts.Add(bank);
            int affectedRows = _appDbContext.SaveChanges();
            if (affectedRows > 0)
            {
                return Ok(new { message = "Компания успешно создана", bank });
            }
            else
            {
                return BadRequest(new { message = "Ошибка создания компании" });
            }
        }
    }
}
