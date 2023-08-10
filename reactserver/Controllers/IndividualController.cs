using Microsoft.AspNetCore.Mvc;
using reactserver.database;
using reactserver.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace reactserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualController : ControllerBase
    {
        private AppDbContext _appDbContext;

        public IndividualController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: api/<IndividualController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<IndividualController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IndividualController>
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] IndividualRequest request)
        {
            var iP = new IndividualEntrepreneur();
            iP.OgrnIpImage = request.OgrnIpImage.FileName;
            iP.EgripImage = request.EgripImage.FileName;
            iP.ScanInnImage = request.ScanInnImage.FileName;
            iP.SetDateRegistration(request.DateRegistration);
            iP.Id = Guid.NewGuid();
            iP.INN = request.INN;
            iP.OGRNIP = request.OGRNIP;

            _appDbContext.IndividualEntrepreneurs.Add(iP);
            int affectedRows = _appDbContext.SaveChanges();

            if (affectedRows > 0)
            {
                return Ok(new { message = "Компания успешно создана", iP });
            }
            else
            {
                return BadRequest(new { message = "Ошибка создания компании" });
            }
        }

        // PUT api/<IndividualController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<IndividualController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
