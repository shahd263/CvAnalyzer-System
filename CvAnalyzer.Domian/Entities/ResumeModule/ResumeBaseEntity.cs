using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAnalyzer.Domian.Entities.ResumeModule
{
    public class ResumeBaseEntity : BaseEntity<int>
    {
        public Resume Resume { get; set; } = default!;
        public string ResumeId { get; set; } = default!;
    }
}
