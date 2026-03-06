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
    public class AnalyzerDbcontext : IdentityDbContext<ApplicationUser>
    {
        public AnalyzerDbcontext(DbContextOptions<AnalyzerDbcontext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Resume> Resumes { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<VolunteerWork> VolunteerWorks { get; set; }







    }
}
