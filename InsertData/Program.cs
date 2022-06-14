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
            string basePath = @"C:\Users\federica.scivales\Documents\tachporkCSV";
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
                    else
                    {
                        var length = File.ReadAllLines(db.FoodCsv).Length;
                        Console.WriteLine(length);
                        db.InsertSource();
                        db.InsertFoods();
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
