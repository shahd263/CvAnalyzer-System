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
        public string? PdfUrl { get; set; }
        public string CvText { get; set; } = default!;
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
        public string UserEmail { get; set; } = default!;
    }
}
