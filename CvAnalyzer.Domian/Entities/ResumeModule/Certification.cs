namespace CvAnalyzer.Domian.Entities.ResumeModule
{
    public class Certification : ResumeBaseEntity
    {
        public string Name { get; set; } = default!;   // e.g., "AWS Certified Developer"
        public string? Issuer { get; set; }            // e.g., AWS, Microsoft
        public DateTime? IssueDate { get; set; }       // Optional
        public DateTime? ExpirationDate { get; set; }  // Optional
        public string? CredentialUrl { get; set; }
    }
}