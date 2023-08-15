using reactserver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactserver.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<bool> CreateAsync(CompanyDto dto);
    }
}
