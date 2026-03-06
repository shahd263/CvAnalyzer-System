namespace CvAnalyzer.Domian.Entities.ResumeModule
{
    public class Project : ResumeBaseEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }        
        public string? Technologies { get; set; }
        public string? Url { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}