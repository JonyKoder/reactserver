using reactserver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactserver.Application.Repositoryes.Interfaces
{
    public interface ICompanyRepository
    {
        Task<bool> CreateAsync(Company iP);
    }
}
