using CvAnalyzer.Domian.Entities.IdentityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAnalyzer.Domian.Entities.ResumeModule
{
    public class Resume : BaseEntity<string>
    {
        public string FullName { get; set; } = default!;
        public string? Title { get; set; }
        public string PdfUrl { get; set; } = default!;
        public ContactInfo ContactInfo { get; set; } = default!;
        public string Summary { get; set; } = default!;
        public ICollection<Experience> Experiences { get; set; } = [];
        public ICollection<Skill> Skills { get; set; } = [];
        public ICollection<Education> Educations { get; set; } = [];
        public ICollection<Project>? Projects { get; set; }
        public ICollection<Language>? Languages { get; set; }
        public ICollection<Certification>? Certifications { get; set; }
        public ICollection<VolunteerWork>? VolunteerWorks { get; set; }

        public ApplicationUser ApplicationUser { get; set; } = default!;
        public string UserId { get; set; } = default!;

    }
}
