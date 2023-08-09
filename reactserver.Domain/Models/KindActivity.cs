namespace reactserver.Domain.Models
{
    public class KindActivity
    {
        public Guid Id { get; set; }
        
        public Guid IndividualEntrepreneurId { get; set; }
        public IndividualEntrepreneur IndividualEntrepreneur { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }


    }
}
