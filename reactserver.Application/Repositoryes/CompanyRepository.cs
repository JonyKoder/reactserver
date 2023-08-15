using reactserver.Application.Repositoryes.Interfaces;
using reactserver.database;
using reactserver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactserver.Application.Repositoryes
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            var res = await _context.SaveChangesAsync();
            return  res > 0;
        }
    }
}
