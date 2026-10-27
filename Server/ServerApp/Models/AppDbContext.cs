using Microsoft.EntityFrameworkCore;

namespace ServerApp.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Proposal> Proposals => Set<Proposal>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Початкові тестові дані (Seeding)
        modelBuilder.Entity<Teacher>().HasData(
            new Teacher { ID = 1, Name = "Олександр Шевченко", Email = "shevchenko@univ.edu.ua", PasswordHash = "e10adc3949ba59abbe56e057f20f883e" },
            new Teacher { ID = 2, Name = "Олена Бондаренко", Email = "bondarenko@univ.edu.ua", PasswordHash = "c33367701511b4f6020ec61ded352059" }
        );

        modelBuilder.Entity<Course>().HasData(
            new Course { ID = 1, Name = "Об'єктно-орієнтоване програмування", Description = "Базовий курс C# та .NET", Semester = "Осінь 2024", TeacherID = 1 },
            new Course { ID = 2, Name = "Бази даних та SQL", Description = "Проєктування реляційних баз даних", Semester = "Осінь 2024", TeacherID = 2 }
        );
    }
}