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
    public class IndividualRequest
    {
        public string INN { get; set; }
        [JsonProperty("dateRegistration")]
        public string DateRegistration { get; set; }
        public string OGRNIP { get; set; }
        public IFormFile ScanInnImage { get; set; }

        public IFormFile OgrnIpImage { get; set; }
        public IFormFile EgripImage { get; set; }
    }
}