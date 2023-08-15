using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace reactserver.Domain.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string INN { get; set; }
        public string OGRN { get; set; }
        public string ScanInnImage { get; set; }
        public string OgrnIpImage { get; set; }
        public string EgripImage { get; set; }
        public DateTime DateRegistration { get; set; }
        public string Bic { get; set; }
        public string BranchName { get; set; }
        public string CheckingAccount { get; set; }
        public string CorrespondentAccount { get; set; }
        public BankAccount BankAccount { get; set; }
        public Guid BankAccountId { get; set; }
        public void AddBankAccount(string bic, string branch, string checkingAccount, string correspondetAccount)
        {
            BankAccount = new BankAccount
            {
                Id = Guid.NewGuid(),
                Bic = bic,
                BranchName = branch,
                CheckingAccount = checkingAccount,
                CorrespondentAccount = correspondetAccount
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
    public class CompanyDto
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string INN { get; set; }
        public string OGRN { get; set; }
        public DateTime DateRegistration { get; set; }
        public string Bic { get; set; }
        public string BranchName { get; set; }
        public string CheckingAccount { get; set; }
        public string CorrespondentAccount { get; set; }
        public IFormFile ScanInnImage { get; set; }
        public IFormFile OgrnIpImage { get; set; }
        public IFormFile EgripImage { get; set; }

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
}