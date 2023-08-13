using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reactserver.Application.Interfaces;
using reactserver.database;
using reactserver.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace reactserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualController : ControllerBase
    {
        private IIndividualService _individualService;

        public IndividualController(IIndividualService individualService)
        {
            _individualService = individualService;
        }

        private string GenerateImageUrl(string imageName)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host.Value}";
            var imagePath = $"{imageName}";
            return $"{baseUrl}/{imagePath}";
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddApplicationForm([FromForm] ApplicationFormDto applicationForm)
        {
            await _individualService.CreateAsync(applicationForm);

            return CreatedAtAction(nameof(AddApplicationForm), applicationForm);
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
