namespace CvAnalyzer.Domian.Entities.ResumeModule
{
    public class ContactInfo :ResumeBaseEntity
    {
        public string? Phone { get; set; }       // Optional
        public string? Email { get; set; }       // Optional
        public string? LinkedIn { get; set; }    // Optional
        public string? GitHub { get; set; }      // Optional
        public string? PortfolioUrl { get; set; } // Optional
        public string? Address { get; set; }
    }
}