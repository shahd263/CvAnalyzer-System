namespace CvAnalyzer.Domian.Entities.ResumeModule
{
    public class Language : ResumeBaseEntity
    {
        public string Name { get; set; } = default!;     
        public string? Proficiency { get; set; }
    }
}