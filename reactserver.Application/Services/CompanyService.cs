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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> CreateAsync(CompanyDto dto)
        {
            var company = new Company()
            {
                Bic = dto.Bic,
                BranchName = dto.BranchName,
                CheckingAccount = dto.CheckingAccount,
                CorrespondentAccount = dto.CorrespondentAccount,
                DateRegistration = dto.DateRegistration,
                FullName = dto.FullName,
                INN = dto.INN,
                OGRN = dto.OGRN,
                ShortName = dto.ShortName,
                Id = Guid.NewGuid(),

            };
            await AddFilesAsync(dto, company);
            company.AddBankAccount(dto.Bic, dto.BranchName, dto.CheckingAccount, dto.CorrespondentAccount);
            await _companyRepository.CreateAsync(company);
            return true;
        }
        private async Task AddFilesAsync(CompanyDto applicationForm, Company company)
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
                    company.ScanInnImage = filePath;
                }
                else if (file.Image == applicationForm.OgrnIpImage)
                {
                    company.OgrnIpImage = filePath;
                }
                else if (file.Image == applicationForm.EgripImage)
                {
                    company.EgripImage = filePath;
                }
            }
        }
    }
}
