namespace reactserver.Domain.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string INN { get; set; }
        public string OGRN { get; set; }
        public DateTime DateRegistration { get; set; }

    }
}