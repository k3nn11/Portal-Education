using Data.Models;
using Microsoft.EntityFrameworkCore;



namespace Data.DbInitializer
{
    public class PortalContext : DbContext
    {
        public PortalContext(DbContextOptions options) : base(options)
        {
           
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (optionsBuilder != null && !optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PL_Portal.Data;Trusted_Connection=True;MultipleActiveResultSets=true");
        //    }
        //}
        public DbSet<Article> Articles { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Course> Courses { get; set; }

        public  DbSet<User> Users { get; set; }

        public DbSet<Login> Logins { get; set; }

        public  DbSet<PersonalInformation> PersonalInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            //modelBuilder.Entity<Book>()
            //.Property(b => b.Id)
            //.ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
              .HasOne(e => e.Information)
              .WithOne(i => i.User)
              .HasForeignKey<PersonalInformation>("UserId")
              .IsRequired();

            modelBuilder.Entity<Login>()
                .HasOne(e => e.User)
                .WithOne(i => i.Login)
                .HasForeignKey<User>("LoginId")
                .IsRequired();

            modelBuilder.Entity<PersonalInformation>()
                .HasMany(p => p.Skills)
                .WithOne(p => p.Information)
                .HasForeignKey("PersonalInformationId")
                .IsRequired(false);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Skills)
                .WithMany(c => c.Courses)
                .UsingEntity(j => j.ToTable("CourseSkill"));

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Videos)
                .WithOne(c => c.Course)
                .HasForeignKey("CourseId")
                .IsRequired(false);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Articles)
                .WithOne(c => c.Course)
                .HasForeignKey("CourseId")
                .IsRequired(false);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Books)
                .WithOne(c => c.Course)
                .HasForeignKey("CourseId")
                .IsRequired(false);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Users)
                .WithMany(u => u.Courses)
                .UsingEntity(j => j.ToTable("UserCourse"));

            modelBuilder.Entity<Course>()
                .Property(c => c.State)
                .HasConversion<string>();
        }
    }
}
