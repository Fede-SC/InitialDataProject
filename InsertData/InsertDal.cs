using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Techpork.Core.Entities;
using Techpork.Core.Extensions;
using Techpork.Infrastructure.Persistance.Data;

namespace Techpork.ExecuteInsertBda
{
    public class InsertDal
    {
        private readonly TechPorkContext _context;
        private FoodSource _foodSource;

        public string FoodCsv { get; set; }
        public string MicronutrientsCsv { get; set; }
        public string MicronutrientsWithUmCsv { get; set; }
        public string FoodWithMicronutrientsCsv { get; set; }
        public string UmCsv { get; set; }
        public InsertDal(TechPorkContext context)
        {
            _context = context;
        }

        public void InsertSource()
        {
            _context.Add(new FoodSource
            {
                Name = "BDA"
            });
            _context.SaveChanges();
        }

        public void InsertFoods()
        {
            List<Food> foods = new List<Food>();
            _foodSource = _context.FoodSources.Where(s => s.Name.Equals("BDA")).FirstOrDefault();
            if (_foodSource == null)
            {
                throw new ArgumentNullException("InsertFoods: food source is null");
            }   
            using (StreamReader sr = new StreamReader(FoodCsv)) // bda_foods
            {
                int count = 0;
                while (!sr.EndOfStream)
                {
                    count++;
                    string line = sr.ReadLine();
                    var length = File.ReadAllLines(FoodCsv).Length;
                    if (count == 1)
                    {
                        Console.WriteLine(count);
                        continue;
                    }
                    string[] split = line.Split(';');
                    Console.WriteLine(count + " " + split[0]);

                    foods.Add(new Food
                    {
                        NameIt = split[0],
                        NameEn = split[1],
                        Kcals = split[2].Trim().ToNumber<int>(),
                        Pro = split[3].Trim().ToNumber<double>(),
                        Fats = split[4].Trim().ToNumber<double>(),
                        Carb = split[5].Trim().ToNumber<double>(),
                        Sugar = split[6].Trim().ToNumber<double>(),
                        Fibers = split[7].Trim().ToNumber<double>(),
                        Sodium = split[8].Trim().ToNumber<int>(),
                        Potassium = split[9].Trim().ToNumber<int>(),
                        VitaminA = split[10].Trim().ToNumber<int>(),
                        VitaminB12 = split[11].Trim().ToNumber<int>(),
                        VitaminC = split[12].Trim().ToNumber<int>(),
                        VitaminD = split[13].Trim().ToNumber<int>(),
                        VitaminE = split[14].Trim().ToNumber<int>(),
                        Calcium = split[15].Trim().ToNumber<int>(),
                        Zinc = split[16].Trim().ToNumber<int>(),
                        Magnesium = split[17].Trim().ToNumber<int>(),
                        Epa = split[18].Trim().ToNumber<int>(),
                        Dha = split[19].Trim().ToNumber<int>(),
                        ServingUnit = "g",
                        ServingSize = 0,
                        SourceId = _foodSource?.Id ?? 0
                    });
                }

                sr.Close();
            }
            _context.AddRange(foods);
            _context.SaveChanges();
        }
    }
}
