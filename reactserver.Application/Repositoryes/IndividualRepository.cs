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
    public class IndividualRepository : IIndividualRepository
    {
        private readonly AppDbContext _context;

        public IndividualRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(IndividualEntrepreneur iP)
        {
           await _context.IndividualEntrepreneurs.AddAsync(iP);
           var res = await _context.SaveChangesAsync();
            return res > 0;
        }
    }
}
