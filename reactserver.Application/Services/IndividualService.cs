using reactserver.Application.Interfaces;
using reactserver.Application.Repositoryes.Interfaces;
using reactserver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactserver.Application.Services
{
    public class IndividualService : IIndividualService
    {
        private readonly IIndividualRepository _individualRepository;

        public IndividualService(IIndividualRepository individualRepository)
        {
            _individualRepository = individualRepository;
        }

        public async Task<bool> CreateAsync(ApplicationFormDto dto)
        {
            var iP = new IndividualEntrepreneur();

            await AddFilesAsync(dto, iP);
            iP.AddBankAccount("dsa", "dsa", "dsa", "dsa", "dsad", "dsadsa", "dsad");
            iP.INN = dto.Inn;
            iP.OGRNIP = dto.Ogrnip;
            iP.SetDateRegistration(dto.DateRegistration.ToString("dd.MM.yyyy"));
            await _individualRepository.CreateAsync(iP);
            return true;

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
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
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
    }
}
