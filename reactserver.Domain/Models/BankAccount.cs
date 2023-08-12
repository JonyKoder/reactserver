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
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string SWIFTCode { get; set; }
        public string IBAN { get; set; }
        public string AccountHolderName { get; set; }
    }
    public class BankAccountRequest
    {
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string AccountHolderName { get; set; }
    }
}
