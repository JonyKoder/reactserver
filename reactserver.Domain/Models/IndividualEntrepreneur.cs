using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace reactserver.Domain.Models
{
    public class IndividualEntrepreneur
    {
        public Guid Id { get; set; }
        public string INN { get; set; }
        public DateTime DateRegistration { get; set; }
        public string OGRNIP { get; set; }
        public string ScanInnImage { get; set; }
        public string OgrnIpImage { get; set; }
        public string EgripImage { get; set; }
        public Guid BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        public void AddBankAccount(string accountNumber, string bankCode, string bankName, string bankAddress, string swiftCode, string iban, string accountHolderName)
        {
            BankAccount = new BankAccount
            {
                Id = Guid.NewGuid(),
                AccountNumber = accountNumber,
                BankCode = bankCode,
                BankName = bankName,
                BankAddress = bankAddress,
                SWIFTCode = swiftCode,
                IBAN = iban,
                AccountHolderName = accountHolderName
            };

            BankAccountId = BankAccount.Id;
        }

        public void SetDateRegistration(string dateRegistrationString)
        {
            if (DateTime.TryParse(dateRegistrationString, out DateTime dateRegistration))
            {
                DateRegistration = dateRegistration.ToUniversalTime();
            }
            else
            {
                throw new ArgumentException("Invalid date format.");
            }
        }

    }
    public class ApplicationFormDto
    {
        public Guid Id { get; set; }
        public string Inn { get; set; }
        public DateTime DateRegistration { get; set; }
        public string Ogrnip { get; set; }
        public IFormFile ScanInnImage { get; set; }
        public IFormFile OgrnIpImage { get; set; }
        public IFormFile EgripImage { get; set; }
    }
    public class BankAccountDto
    {
        public Guid Id { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string Bic { get; set; }
    }
}