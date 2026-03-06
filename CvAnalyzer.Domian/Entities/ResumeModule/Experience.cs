namespace CvAnalyzer.Domian.Entities.ResumeModule
{
    public class Experience : ResumeBaseEntity
    {
        public string JobTitle { get; set; } = default!;
        public string Company { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }

    }
}