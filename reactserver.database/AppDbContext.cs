using Microsoft.EntityFrameworkCore;
using reactserver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactserver.database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<IndividualEntrepreneur> IndividualEntrepreneurs { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
