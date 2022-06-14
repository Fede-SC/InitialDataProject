using Microsoft.EntityFrameworkCore;
using System;
using Techpork.Core.Entities;
using Techpork.Core.Extensions;

namespace Techpork.Infrastructure.Persistance.Data
{
    public class TechPorkContext : DbContext
    {
        private static string tutRgx = @"\b(?:[0-9]{1,2}\.){3}[0-9]{1,2}\b".Replace("\\", "");
        public TechPorkContext() { }
        public TechPorkContext(DbContextOptions<TechPorkContext> options) : base(options)
        {
        }

        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<ChecksHasCircumference> ChecksHasCircumferences { get; set; }
        public DbSet<Circumference> Circumferences { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<DietDay> DietDays { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodSource> FoodSources { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<PendingFollowRequest> PendingFollowRequests { get; set; }
        public DbSet<Portion> Portions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseNpgsql("Host=127.168.1.1;Database=techpork_db;Username=postgres;Password=techpork420")
                    .UseValidationCheckConstraints()
                    .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ToSnakeCase();

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.Property(e => e.LastChange)
                    .HasColumnType("TIMESTAMP");
                entity.HasOne(e => e.Author)
                    .WithMany(e => e.AuthorAttachments)
                    .HasForeignKey(e => e.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.User)
                    .WithMany(e => e.UserAttachments)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                //entity.Property(e => e.Topic)
                //    .HasConversion(
                //        v => v.ToString(),
                //        v => (Topic)Enum.Parse(typeof(Topic), v));
            });

            modelBuilder.Entity<Check>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.Property(e => e.Date)
                    .HasColumnType("TIMESTAMP");
                entity.HasOne(e => e.User)
                    .WithMany(e => e.Checks)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.Deleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<ChecksHasCircumference>(entity =>
            {
                entity.HasKey(e => new { e.CheckId, e.CircumferenceId });
                entity.HasOne(e => e.Check) // cascade
                    .WithMany(e => e.ChecksHasCircumferences)
                    .HasForeignKey(e => e.CheckId)
                    .OnDelete(DeleteBehavior.Cascade); 
                entity.HasOne(e => e.Circumference) // cascade
                    .WithMany(e => e.ChecksHasCircumferences)
                    .HasForeignKey(e => e.CircumferenceId)
                    .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<Circumference>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.HasIndex(e => e.Code)
                    .IsUnique();
            });

            modelBuilder.Entity<Diet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.Property(e => e.FirstDay)
                    .HasColumnType("TIMESTAMP");
                entity.Property(e => e.LastDay)
                    .HasColumnType("TIMESTAMP");
                entity.HasOne(e => e.Author)
                    .WithMany(e => e.AuthorDiets)
                    .HasForeignKey(e => e.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.User)
                    .WithMany(e => e.UserDiets)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.Deleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<DietDay>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.HasOne(e => e.Diet) // cascade
                    .WithMany(e => e.DietDays)
                    .HasForeignKey(e => e.DietId)
                    .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.HasOne(e => e.Author)
                    .WithMany(e => e.Foods)
                    .HasForeignKey(e => e.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(e => new { e.NameIt, e.AuthorId })
                    .IsUnique();
                entity.HasIndex(e => new { e.NameEn, e.AuthorId })
                    .IsUnique();
                entity.Property(e => e.Carb)
                   .HasDefaultValue(0);
                entity.Property(e => e.Pro)
                   .HasDefaultValue(0);
                entity.Property(e => e.Fats)
                   .HasDefaultValue(0);
                entity.Property(e => e.Kcals)
                   .HasDefaultValue(0);
                entity.Property(e => e.Sugar)
                   .HasDefaultValue(0);
                entity.Property(e => e.Fibers)
                   .HasDefaultValue(0);
                entity.Property(e => e.Sodium)
                   .HasDefaultValue(0);
                entity.Property(e => e.Potassium)
                   .HasDefaultValue(0);
                entity.Property(e => e.VitaminA)
                   .HasDefaultValue(0);
                entity.Property(e => e.VitaminB12)
                   .HasDefaultValue(0);
                entity.Property(e => e.VitaminC)
                   .HasDefaultValue(0);
                entity.Property(e => e.VitaminD)
                   .HasDefaultValue(0);
                entity.Property(e => e.VitaminE)
                   .HasDefaultValue(0);
                entity.Property(e => e.Calcium)
                   .HasDefaultValue(0);
                entity.Property(e => e.Zinc)
                   .HasDefaultValue(0);
                entity.Property(e => e.Magnesium)
                   .HasDefaultValue(0);
                entity.Property(e => e.Epa)
                   .HasDefaultValue(0);
                entity.Property(e => e.Dha)
                   .HasDefaultValue(0);
                entity.HasOne(e => e.Source)
                    .WithMany(e => e.Foods)
                    .HasForeignKey(e => e.SourceId);
            });

            modelBuilder.Entity<FoodSource>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.HasOne(e => e.DietDay) // cascade
                    .WithMany(e => e.Meals)
                    .HasForeignKey(e => e.DietDayId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PendingFollowRequest>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.HasOne(e => e.Coach)
                    .WithMany(e => e.CoachPendingFollowRequests)
                    .HasForeignKey(e => e.CoachId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.User)
                    .WithMany(e => e.UserPendingFollowRequests)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.Date)
                    .HasColumnType("TIMESTAMP");
                //entity.Property(e => e.Topic)
                //    .HasConversion(
                //        v => v.ToString(),
                //        v => (Topic)Enum.Parse(typeof(Topic), v));
            });

            modelBuilder.Entity<Portion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.HasOne(e => e.Meal) // cascade
                    .WithMany(e => e.Portions)
                    .HasForeignKey(e => e.MealId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Food) // cascade
                    .WithMany(e => e.Portions)
                    .HasForeignKey(e => e.FoodId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
                entity.HasIndex(e => e.Email)
                    .IsUnique();
                entity.HasIndex(e => e.Username)
                    .IsUnique();
                entity.Property(e => e.Birthday)
                    .HasColumnType("date");
                entity.HasOne(e => e.Nutritionist)
                    .WithMany(e => e.NutritionistUsers)
                    .HasForeignKey(e => e.NutritionistId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Trainer)
                    .WithMany(e => e.TrainerUsers)
                    .HasForeignKey(e => e.TrainerId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.Gender)
                    .HasConversion(
                        v => v.ToString(),
                        v => (Gender)Enum.Parse(typeof(Gender), v));
                entity.Property(e => e.Visible)
                    .HasDefaultValue(false);
            });
        }
    }
}
