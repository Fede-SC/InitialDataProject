﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Techpork.Infrastructure.Persistance.Data;

namespace Techpork.Infrastructure.Migrations
{
    [DbContext(typeof(TechPorkContext))]
    [Migration("20220614195108_AlterFoods")]
    partial class AlterFoods
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Techpork.Core.Entities.Attachment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint")
                        .HasColumnName("author_id");

                    b.Property<DateTime>("LastChange")
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("last_change");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("uri");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_attachments");

                    b.HasIndex("AuthorId");

                    b.HasIndex("UserId");

                    b.ToTable("attachments");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Check", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("date");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("deleted");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<float?>("Weight")
                        .HasColumnType("real")
                        .HasColumnName("weight");

                    b.HasKey("Id")
                        .HasName("pk_checks");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_checks_user_id");

                    b.ToTable("checks");
                });

            modelBuilder.Entity("Techpork.Core.Entities.ChecksHasCircumference", b =>
                {
                    b.Property<long>("CheckId")
                        .HasColumnType("bigint")
                        .HasColumnName("check_id");

                    b.Property<long>("CircumferenceId")
                        .HasColumnType("bigint")
                        .HasColumnName("circumference_id");

                    b.Property<float>("Measure")
                        .HasColumnType("real")
                        .HasColumnName("measure");

                    b.HasKey("CheckId", "CircumferenceId")
                        .HasName("pk_checks_has_circumferences");

                    b.HasIndex("CircumferenceId")
                        .HasDatabaseName("ix_checks_has_circumferences_circumference_id");

                    b.ToTable("checks_has_circumferences");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Circumference", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<int>("Code")
                        .HasColumnType("integer")
                        .HasColumnName("code");

                    b.Property<string>("HelpPicUri")
                        .HasColumnType("text")
                        .HasColumnName("help_pic_uri");

                    b.HasKey("Id")
                        .HasName("pk_circumferences");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("circumferences");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Diet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint")
                        .HasColumnName("author_id");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("deleted");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("DiffFromNormo")
                        .HasColumnType("integer")
                        .HasColumnName("diff_from_normo");

                    b.Property<DateTime>("FirstDay")
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("first_day");

                    b.Property<DateTime?>("LastDay")
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("last_day");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_diets");

                    b.HasIndex("AuthorId");

                    b.HasIndex("UserId");

                    b.ToTable("diets");
                });

            modelBuilder.Entity("Techpork.Core.Entities.DietDay", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<long>("DietId")
                        .HasColumnType("bigint")
                        .HasColumnName("diet_id");

                    b.Property<int>("DietIndex")
                        .HasColumnType("integer")
                        .HasColumnName("diet_index");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_diet_days");

                    b.HasIndex("DietId")
                        .HasDatabaseName("ix_diet_days_diet_id");

                    b.ToTable("diet_days");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Food", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<long?>("AuthorId")
                        .HasColumnType("bigint")
                        .HasColumnName("author_id");

                    b.Property<int>("Calcium")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("calcium");

                    b.Property<double>("Carb")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0)
                        .HasColumnName("carb");

                    b.Property<int>("Dha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("dha");

                    b.Property<int>("Epa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("epa");

                    b.Property<double>("Fats")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0)
                        .HasColumnName("fats");

                    b.Property<double>("Fibers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0)
                        .HasColumnName("fibers");

                    b.Property<int>("Kcals")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("kcals");

                    b.Property<int>("Magnesium")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("magnesium");

                    b.Property<string>("NameEn")
                        .HasColumnType("text")
                        .HasColumnName("name_en");

                    b.Property<string>("NameIt")
                        .HasColumnType("text")
                        .HasColumnName("name_it");

                    b.Property<int>("Potassium")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("potassium");

                    b.Property<double>("Pro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0)
                        .HasColumnName("pro");

                    b.Property<int>("ServingSize")
                        .HasColumnType("integer")
                        .HasColumnName("serving_size");

                    b.Property<string>("ServingUnit")
                        .HasColumnType("text")
                        .HasColumnName("serving_unit");

                    b.Property<int>("Sodium")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("sodium");

                    b.Property<long>("SourceId")
                        .HasColumnType("bigint")
                        .HasColumnName("source_id");

                    b.Property<double>("Sugar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0)
                        .HasColumnName("sugar");

                    b.Property<int>("VitaminA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("vitamin_a");

                    b.Property<int>("VitaminB12")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("vitamin_b12");

                    b.Property<int>("VitaminC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("vitamin_c");

                    b.Property<int>("VitaminD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("vitamin_d");

                    b.Property<int>("VitaminE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("vitamin_e");

                    b.Property<int>("Zinc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("zinc");

                    b.HasKey("Id")
                        .HasName("pk_foods");

                    b.HasIndex("AuthorId")
                        .HasDatabaseName("ix_foods_author_id");

                    b.HasIndex("SourceId")
                        .HasDatabaseName("ix_foods_source_id");

                    b.HasIndex("NameEn", "AuthorId")
                        .IsUnique();

                    b.HasIndex("NameIt", "AuthorId")
                        .IsUnique();

                    b.ToTable("foods");
                });

            modelBuilder.Entity("Techpork.Core.Entities.FoodSource", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_food_sources");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("food_sources");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Meal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<int>("DayIndex")
                        .HasColumnType("integer")
                        .HasColumnName("day_index");

                    b.Property<long>("DietDayId")
                        .HasColumnType("bigint")
                        .HasColumnName("diet_day_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_meals");

                    b.HasIndex("DietDayId")
                        .HasDatabaseName("ix_meals_diet_day_id");

                    b.ToTable("meals");
                });

            modelBuilder.Entity("Techpork.Core.Entities.PendingFollowRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<long>("CoachId")
                        .HasColumnType("bigint")
                        .HasColumnName("coach_id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("date");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_pending_follow_requests");

                    b.HasIndex("CoachId");

                    b.HasIndex("UserId");

                    b.ToTable("pending_follow_requests");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Portion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<long>("FoodId")
                        .HasColumnType("bigint")
                        .HasColumnName("food_id");

                    b.Property<long>("MealId")
                        .HasColumnType("bigint")
                        .HasColumnName("meal_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("pk_portions");

                    b.HasIndex("FoodId")
                        .HasDatabaseName("ix_portions_food_id");

                    b.HasIndex("MealId")
                        .HasDatabaseName("ix_portions_meal_id");

                    b.ToTable("portions");
                });

            modelBuilder.Entity("Techpork.Core.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<int>("Avatar")
                        .HasColumnType("integer")
                        .HasColumnName("avatar");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("date")
                        .HasColumnName("birthday");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Gender")
                        .HasColumnType("text")
                        .HasColumnName("gender");

                    b.Property<int?>("Height")
                        .HasColumnType("integer")
                        .HasColumnName("height");

                    b.Property<long?>("NutritionistId")
                        .HasColumnType("bigint")
                        .HasColumnName("nutritionist_id");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<long?>("TrainerId")
                        .HasColumnType("bigint")
                        .HasColumnName("trainer_id");

                    b.Property<string>("Username")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("username");

                    b.Property<bool>("Visible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("visible");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("NutritionistId");

                    b.HasIndex("TrainerId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("users");

                    b.HasCheckConstraint("CK_users_height_Range", "height >= 0 AND height <= 300");

                    b.HasCheckConstraint("CK_users_username_MinLength", "LENGTH(username) >= 3");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Attachment", b =>
                {
                    b.HasOne("Techpork.Core.Entities.User", "Author")
                        .WithMany("AuthorAttachments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Techpork.Core.Entities.User", "User")
                        .WithMany("UserAttachments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Check", b =>
                {
                    b.HasOne("Techpork.Core.Entities.User", "User")
                        .WithMany("Checks")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_checks_users_user_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Techpork.Core.Entities.ChecksHasCircumference", b =>
                {
                    b.HasOne("Techpork.Core.Entities.Check", "Check")
                        .WithMany("ChecksHasCircumferences")
                        .HasForeignKey("CheckId")
                        .HasConstraintName("fk_checks_has_circumferences_checks_check_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Techpork.Core.Entities.Circumference", "Circumference")
                        .WithMany("ChecksHasCircumferences")
                        .HasForeignKey("CircumferenceId")
                        .HasConstraintName("fk_checks_has_circumferences_circumferences_circumference_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Check");

                    b.Navigation("Circumference");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Diet", b =>
                {
                    b.HasOne("Techpork.Core.Entities.User", "Author")
                        .WithMany("AuthorDiets")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Techpork.Core.Entities.User", "User")
                        .WithMany("UserDiets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Techpork.Core.Entities.DietDay", b =>
                {
                    b.HasOne("Techpork.Core.Entities.Diet", "Diet")
                        .WithMany("DietDays")
                        .HasForeignKey("DietId")
                        .HasConstraintName("fk_diet_days_diets_diet_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Food", b =>
                {
                    b.HasOne("Techpork.Core.Entities.User", "Author")
                        .WithMany("Foods")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("fk_foods_users_author_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Techpork.Core.Entities.FoodSource", "Source")
                        .WithMany("Foods")
                        .HasForeignKey("SourceId")
                        .HasConstraintName("fk_foods_food_sources_source_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Meal", b =>
                {
                    b.HasOne("Techpork.Core.Entities.DietDay", "DietDay")
                        .WithMany("Meals")
                        .HasForeignKey("DietDayId")
                        .HasConstraintName("fk_meals_diet_days_diet_day_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DietDay");
                });

            modelBuilder.Entity("Techpork.Core.Entities.PendingFollowRequest", b =>
                {
                    b.HasOne("Techpork.Core.Entities.User", "Coach")
                        .WithMany("CoachPendingFollowRequests")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Techpork.Core.Entities.User", "User")
                        .WithMany("UserPendingFollowRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Portion", b =>
                {
                    b.HasOne("Techpork.Core.Entities.Food", "Food")
                        .WithMany("Portions")
                        .HasForeignKey("FoodId")
                        .HasConstraintName("fk_portions_foods_food_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Techpork.Core.Entities.Meal", "Meal")
                        .WithMany("Portions")
                        .HasForeignKey("MealId")
                        .HasConstraintName("fk_portions_meals_meal_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("Techpork.Core.Entities.User", b =>
                {
                    b.HasOne("Techpork.Core.Entities.User", "Nutritionist")
                        .WithMany("NutritionistUsers")
                        .HasForeignKey("NutritionistId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Techpork.Core.Entities.User", "Trainer")
                        .WithMany("TrainerUsers")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Nutritionist");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Check", b =>
                {
                    b.Navigation("ChecksHasCircumferences");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Circumference", b =>
                {
                    b.Navigation("ChecksHasCircumferences");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Diet", b =>
                {
                    b.Navigation("DietDays");
                });

            modelBuilder.Entity("Techpork.Core.Entities.DietDay", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Food", b =>
                {
                    b.Navigation("Portions");
                });

            modelBuilder.Entity("Techpork.Core.Entities.FoodSource", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("Techpork.Core.Entities.Meal", b =>
                {
                    b.Navigation("Portions");
                });

            modelBuilder.Entity("Techpork.Core.Entities.User", b =>
                {
                    b.Navigation("AuthorAttachments");

                    b.Navigation("AuthorDiets");

                    b.Navigation("Checks");

                    b.Navigation("CoachPendingFollowRequests");

                    b.Navigation("Foods");

                    b.Navigation("NutritionistUsers");

                    b.Navigation("TrainerUsers");

                    b.Navigation("UserAttachments");

                    b.Navigation("UserDiets");

                    b.Navigation("UserPendingFollowRequests");
                });
#pragma warning restore 612, 618
        }
    }
}