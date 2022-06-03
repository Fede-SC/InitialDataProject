using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Techpork.Core.Entities;

namespace Techpork.Infrastructure.Persistance.Data
{
    public static class SeedData
    {
        public static void SeedAsync(IServiceProvider serviceProvider)
        {
            using (var context = new TechPorkContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TechPorkContext>>()))
            {
                context.Database.Migrate();

                // User endpoints
                if (!context.Users.Any()) 
                {
                    var user = new User
                    {
                        Email = "gullandrea693@gmail.com",
                        Username = "HandGull",
                        Birthday = new DateTime(1996, 8, 31),
                        Gender = Gender.Male,
                        Height = 166,
                        AvatarUri = "Resources/Images/no_picture.png",
                        Visible = true
                    };
                    context.Users.Attach(user);
                    context.SaveChanges();
                }

                // Check endpoints
                if (!context.Circumferences.Any())
                {
                    var circumferences = new List<Circumference>()
                    {
                        new Circumference
                        {
                            Code = 1,
                            HelpPicUri = "Resources/Images/check1-PNG.png"
                        },
                        new Circumference
                        {
                            Code = 2,
                            HelpPicUri = "Resources/Images/Capture2.png"
                        },
                        new Circumference
                        {
                            Code = 3,
                            HelpPicUri = "Resources/Images/Capture.png"
                        },
                        new Circumference
                        {
                            Code = 4,
                            HelpPicUri = "Resources/Images/Capture5.png"
                        },
                        new Circumference
                        {
                            Code = 5,
                            HelpPicUri = "Resources/Images/Capture8.png"
                        },
                        new Circumference
                        {
                            Code = 6,
                            HelpPicUri = "Resources/Images/Capture15.png"
                        }
                    };
                    context.Circumferences.AddRange(circumferences);
                    context.SaveChanges();
                }

                if (!context.Checks.Any())
                {
                    var check = new Check
                    {
                        UserId = context.Users.FirstOrDefault().Id,
                        Date = DateTime.UtcNow,
                        Weight = 71f
                    };
                    check.ChecksHasCircumferences = new List<ChecksHasCircumference>()
                    {
                        new ChecksHasCircumference
                        {
                            CircumferenceId = context.Circumferences.FirstOrDefault().Id,
                            Measure = 93.3f
                        }
                    };
                    context.Checks.Attach(check);
                    context.SaveChanges();
                }

                if (!context.Pics.Any())
                {
                    var pic = new Pic
                    {
                        CheckId = context.Checks.FirstOrDefault().Id,
                        Uri = "Resources/Images/no_picture.png"
                    };
                    context.Pics.Attach(pic);
                    context.SaveChanges();
                }

                if (!context.UnitMeasures.Any())
                {
                    var um = new UnitMeasure
                    {
                        Name = "mg"
                    };
                    context.UnitMeasures.Attach(um);
                    context.SaveChanges();
                }

                if (!context.FoodSources.Any())
                {
                    var source = new FoodSource
                    {
                        Name = "SourceExample"
                    };
                    context.FoodSources.Attach(source);
                    context.SaveChanges();
                }

                // Food endpoints
                if (!context.Foods.Any())
                {
                    var food = new Food
                    {
                        NameIt = "Esempio",
                        NameEn = "Example",
                        Carb = 24,
                        Pro = 24,
                        Fats = 24,
                        Kcals = 100,
                        Fibers = 200,
                        AuthorId = context.Users.FirstOrDefault().Id,
                        SourceId = context.FoodSources.FirstOrDefault().Id
                    };
                    context.Foods.Attach(food);
                    context.SaveChanges();
                }

                if (!context.Micronutrients.Any())
                {
                    var micro = new Micronutrient
                    {
                        Name = "mic",
                        FoodHasMicronutrients = new List<FoodHasMicronutrient>()
                        {
                            new FoodHasMicronutrient
                            {
                                FoodId = context.Foods.FirstOrDefault().Id,
                                Quantity = 45,
                                UnitMeasureId = context.UnitMeasures.FirstOrDefault().Id
                            }
                        }
                    };
                    context.Micronutrients.Attach(micro);
                    context.SaveChanges();
                }

                if (!context.FoodTags.Any())
                {
                    var foodTags = new FoodTag
                    {
                        Code = 234,
                        FoodHasTags = new List<FoodHasTag>()
                        {
                            new FoodHasTag
                            {
                                FoodId = context.Foods.FirstOrDefault().Id
                            }
                        }
                    };
                    context.FoodTags.Attach(foodTags);
                    context.SaveChanges();
                }

                // Diet endpoints
                if (!context.Diets.Any())
                {
                    var diet = new Diet
                    {
                        FirstDay = DateTime.Now,
                        AuthorId = context.Users.FirstOrDefault().Id,
                        Description = "Descrizione dieta",
                        Name = "Test Dieta",
                        DiffFromNormo = 25,
                        UserId = context.Users.FirstOrDefault().Id
                    };
                    context.Diets.Attach(diet);
                    context.SaveChanges();
                }

                if (!context.DietDays.Any())
                {
                    var dietDay = new DietDay
                    {
                        Name = "Diet day 1",
                        DietIndex = 1,
                        DietId = context.Diets.FirstOrDefault().Id
                    };
                    context.DietDays.Attach(dietDay);
                    context.SaveChanges();
                }

                if (!context.Meals.Any())
                {
                    var meal = new Meal
                    {
                        Name = "Meal Example",
                        DayIndex = 1,
                        DietDayId = context.DietDays.FirstOrDefault().Id
                    };
                    context.Meals.Attach(meal);
                    context.SaveChanges();
                }

                if (!context.Portions.Any())
                {
                    var portion = new Portion
                    {
                        Quantity = 78,
                        MealId = context.Meals.FirstOrDefault().Id,
                        FoodId = context.Foods.FirstOrDefault().Id
                    };
                    context.Portions.Attach(portion);
                    context.SaveChanges();
                }

                // Attachments endpoints
                if (!context.Attachments.Any())
                {
                    var attachments = new List<Attachment>()
                    {
                        new Attachment
                        {
                            AuthorId = context.Users.FirstOrDefault().Id,
                            UserId = context.Users.FirstOrDefault().Id,
                            Name = "DietAttachment1",
                            LastChange = DateTime.Now,
                            Uri = "Resources/Attachments/fede-diet.pdf"
                        },
                         new Attachment
                        {
                            AuthorId = context.Users.FirstOrDefault().Id,
                            UserId = context.Users.FirstOrDefault().Id,
                            Name = "DietAttachment2",
                            LastChange = DateTime.Now,
                            Uri = "Resources/Attachments/gulli-diet.pdf"
                        },
                         new Attachment
                        {
                            AuthorId = context.Users.FirstOrDefault().Id,
                            UserId = context.Users.FirstOrDefault().Id,
                            Name = "WoAttachment1",
                            LastChange = DateTime.Now,
                            Uri = "Resources/Attachments/wo.pdf"
                        },
                         new Attachment
                        {
                            AuthorId = context.Users.FirstOrDefault().Id,
                            UserId = context.Users.FirstOrDefault().Id,
                            Name = "WoAttachment2",
                            LastChange = DateTime.Now,
                            Uri = "Resources/Attachments/wo-pt2.pdf"
                        },
                    };
                    context.Attachments.AddRange(attachments);
                    context.SaveChanges();
                }
            }
        }
    }
}
