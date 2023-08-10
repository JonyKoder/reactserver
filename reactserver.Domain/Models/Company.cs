using Newtonsoft.Json;

namespace reactserver.Domain.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string INN { get; set; }
        public string OGRN { get; set; }
        public DateTime DateRegistration { get; set; }
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
   public class CompanyRequest
    {
        public string FullName { get; set; }
        public string INN { get; set; }
        public string OGRN { get; set; }
        [JsonProperty("dateRegistration")]
        public string DateRegistration { get; set; }
    }
}