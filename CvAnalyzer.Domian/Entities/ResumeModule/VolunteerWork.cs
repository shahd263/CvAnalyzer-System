namespace CvAnalyzer.Domian.Entities.ResumeModule
{
    public class VolunteerWork : ResumeBaseEntity
    {
        public string Role { get; set; } = default!;
        public string Organization { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }        
        public string? Description { get; set; }
    }
}