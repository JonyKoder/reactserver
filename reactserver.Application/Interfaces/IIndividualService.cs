using reactserver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactserver.Application.Interfaces
{
    public interface IIndividualService
    {
        Task<bool> CreateAsync(ApplicationFormDto dto);
    }
}
