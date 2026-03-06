namespace CvAnalyzer.Domian.Entities.ResumeModule
{
    public class Education : ResumeBaseEntity
    {
        public string Degree { get; set; } = default!;
        public string University { get; set; } = default!;
        public string FieldOfStudy { get; set; } = default!;
        public int StartYear { get; set; }
        public int EndYear { get; set; }
    }
}