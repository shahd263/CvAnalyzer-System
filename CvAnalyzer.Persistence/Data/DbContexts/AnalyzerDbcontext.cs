using CvAnalyzer.Domian.Entities.IdentityModule;
using CvAnalyzer.Domian.Entities.ResumeModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CvAnalyzer.Persistence.Data.DbContexts
{
    public class AnalyzerDbcontext : DbContext
    {
        public AnalyzerDbcontext(DbContextOptions<AnalyzerDbcontext> options) : base(options)
        {
            
        }

        

        public DbSet<Resume> Resumes { get; set; }
       






    }
}
