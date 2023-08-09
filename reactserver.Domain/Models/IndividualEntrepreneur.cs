namespace reactserver.Domain.Models
{
    public class IndividualEntrepreneur
    {
        public Guid Id { get; set; }
        public string INN { get; set; }
        public DateTime DateRegistration { get; set; }
        public string OGRNIP { get; set; }

    }
}