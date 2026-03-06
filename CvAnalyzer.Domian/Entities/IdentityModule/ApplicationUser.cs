using CvAnalyzer.Domian.Entities.ResumeModule;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAnalyzer.Domian.Entities.IdentityModule
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; } = default!;
        public ICollection<Resume> Resumes { get; set; } = default!;

    }
}
