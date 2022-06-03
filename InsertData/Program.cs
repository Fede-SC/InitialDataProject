using System;
using System.Collections.Generic;
using System.IO;
using Techpork.Core.Entities;
using Techpork.Core.Extensions;
using Techpork.Infrastructure.Persistance.Data;

namespace Techpork.ExecuteInsertBda
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            string basePath = @"C:\techporkCSV";
            try
            {
                using (var context = new TechPorkContext())
                {
                    var db = new InsertDal(context);
                    db.FoodCsv = Path.Combine(basePath, "bda_foods.csv");
                    db.MicronutrientsCsv = Path.Combine(basePath, "bda_micronutrients.csv");
                    db.MicronutrientsWithUmCsv = Path.Combine(basePath, "bda_micronutrients_with_um.csv");
                    db.FoodWithMicronutrientsCsv = Path.Combine(basePath, "food_with_micronutrients.csv");
                    db.UmCsv = Path.Combine(basePath, "um.csv");
                    if (!File.Exists(db.FoodCsv))
                    {
                        Console.WriteLine("Path not fount: bda_foods.csv");
                    }
                    else if (!File.Exists(db.MicronutrientsCsv))
                    {
                        Console.WriteLine("Path not fount: bda_micronutrients.csv");
                    }
                    else if (!File.Exists(db.MicronutrientsWithUmCsv))
                    {
                        Console.WriteLine("Path not fount: bda_micronutrients_with_um.csv");
                    }
                    else if (!File.Exists(db.FoodWithMicronutrientsCsv))
                    {
                        Console.WriteLine("Path not fount: food_with_micronutrients.csv");
                    }
                    else if (!File.Exists(db.UmCsv))
                    {
                        Console.WriteLine("Path not fount: um.csv");
                    }
                    else
                    {
                        db.InsertSource();
                        db.InsertUms();
                        db.InsertFoods();
                        db.InsertMicronutrients();
                        db.InsertFoodsWithMicronutrients();
                        Console.WriteLine("Successful execution");
                    }
                }
                Console.WriteLine("Finish. Press a key to exit");
            }
            catch (Exception ex)
            {
                Console.WriteLine("errore: {0}", ex.Message);
            }
            Console.ReadLine();
        }
    }
}
