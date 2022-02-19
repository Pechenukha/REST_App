using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_App.Models
{
    public class CollegeContext : DbContext
    {
        public DbSet<Student> student { get; set; }
        public DbSet<Faculty> faculty { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<StudentPassport> student_passport { get; set; }
        public DbSet<StudentInGroup> student_in_group { get; set; }

        public CollegeContext(DbContextOptions<CollegeContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentInGroup>()
                .HasOne(s => s.student)
                .WithMany(sig => sig.student_in_group)
                .HasForeignKey(si => si.id_student);

            modelBuilder.Entity<StudentInGroup>()
               .HasOne(s => s.groups)
               .WithMany(sig => sig.student_in_group)
               .HasForeignKey(si => si.id_group);


        }

    }
}
