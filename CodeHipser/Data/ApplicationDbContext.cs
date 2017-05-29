using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CodeHipser.Models;

namespace CodeHipser.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionType> SectionTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<StudentProgress> StudentProgress { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            
            //Customizing composite primary key and foreign keys
            builder.Entity<StudentProgress>()
                .HasKey(t => new { t.ApplicationUserId, t.SectionId });

            builder.Entity<StudentProgress>()
                .HasOne(s => s.ApplicationUser)
                .WithMany(a => a.StudentProgress)
                .HasForeignKey(s => s.ApplicationUserId)
                .HasPrincipalKey(a => a.Id);

            builder.Entity<StudentProgress>()
                .HasOne(s => s.Section)
                .WithMany(sec => sec.StudentProgress)
                .HasForeignKey(s => s.SectionId)
                .HasPrincipalKey(sec => sec.Id);

            //Answer entity required fields
            builder.Entity<Answer>()
                .Property(a => a.AnswerText)
                .IsRequired();

            //Course entity required fields
            builder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired();

            //Question entity required fields
            builder.Entity<Question>()
                .Property(q => q.QuestionText)
                .IsRequired();

            //Section entity required fields
            builder.Entity<Section>()
                .Property(s => s.Name)
                .IsRequired();

            //SectionType entity required fields
            builder.Entity<SectionType>()
                .Property(s => s.Name)
                .IsRequired();
        }
    }
}
