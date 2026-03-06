namespace CvAnalyzer.Domian.Entities.ResumeModule
{
    public class Skill : ResumeBaseEntity
    {
        public string Name { get; set; } = default!;
        public SkillType SkillType { get; set; }
        

    }
}