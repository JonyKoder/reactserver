using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactserver.Domain.Models
{
    public class BankAccount
    {
        public Guid Id { get; set; }
        public string Bic { get; set; }
        public string BranchName { get; set; }
        public string CheckingAccount { get; set; }
        public string CorrespondentAccount { get; set; }
    }
}
