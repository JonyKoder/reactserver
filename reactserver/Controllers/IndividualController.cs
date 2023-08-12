using Humanizer;
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

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddApplicationForm([FromForm] ApplicationFormDto applicationForm)
        {
            var iP = new IndividualEntrepreneur();
            
                await AddFilesAsync(applicationForm, iP);
                iP.AddBankAccount("dsa","dsa","dsa","dsa","dsad", "dsadsa", "dsad");
                iP.INN = applicationForm.Inn;
                iP.OGRNIP = applicationForm.Ogrnip;
                iP.SetDateRegistration(applicationForm.DateRegistration.ToString("dd.MM.yyyy"));
                await _appDbContext.IndividualEntrepreneurs.AddAsync(iP);
            
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(AddApplicationForm), applicationForm);
        }

        private async Task AddFilesAsync(ApplicationFormDto applicationForm, IndividualEntrepreneur iP)
        {
            var fileInn = applicationForm.ScanInnImage.FileName;
            var fileOgrnip = applicationForm.OgrnIpImage.FileName;
            var fileEgrip = applicationForm.EgripImage.FileName;
            var files = new[]
            {
                   new { FileName = fileInn, Image = applicationForm.ScanInnImage },
                   new { FileName = fileOgrnip, Image = applicationForm.OgrnIpImage },
                   new { FileName = fileEgrip, Image = applicationForm.EgripImage },
                };

            foreach (var file in files)
            {
                string uploadsFolder = Path.Combine(Path.GetTempPath(), "uploads");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.Image.CopyToAsync(stream);
                }

                if (file.Image == applicationForm.ScanInnImage)
                {
                    iP.ScanInnImage = filePath;
                }
                else if (file.Image == applicationForm.OgrnIpImage)
                {
                    iP.OgrnIpImage = filePath;
                }
                else if (file.Image == applicationForm.EgripImage)
                {
                    iP.EgripImage = filePath;
                }
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
