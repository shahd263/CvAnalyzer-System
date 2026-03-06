using CvAnalyzer.Domian.Entities.IdentityModule;
using CvAnalyzer.Domian.Entities.ResumeModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CvAnalyzer.Persistence.Data.Configurations
{
    public class ResumeConfiguration : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.HasOne(c => c.ApplicationUser)
               .WithMany(u => u.Resumes)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
