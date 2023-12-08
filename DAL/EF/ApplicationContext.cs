// Путь: DAL/EF/ApplicationContext.cs

using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeProject>()
                .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany()
                .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany() // Изменено здесь
                .HasForeignKey(ep => ep.ProjectId);

            // Добавим явное указание отношения между Employee и Projects
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Projects)
                .WithOne(p => p.Manager)
                .HasForeignKey(p => p.ManagerId)
                .OnDelete(DeleteBehavior.SetNull); // Если менеджер удаляется, устанавливаем ManagerId в null

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Manager)
                .WithMany(e => e.Projects)
                .HasForeignKey(p => p.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
