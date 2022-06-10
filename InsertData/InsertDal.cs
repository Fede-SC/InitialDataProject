using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void InsertMicronutrients()
        {
            List<Micronutrient> micro = new List<Micronutrient>();
            using (StreamReader sr = new StreamReader(MicronutrientsCsv)) // bda_micronutrients
            {
                int count = 0;
                while (!sr.EndOfStream)
                {
                    count++;
                    string line = sr.ReadLine();
                    if (count == 1)
                    {
                        continue;
                    }

                    string[] split = line.Split(';');

                    micro.Add(new Micronutrient
                    {
                        Name = split[0]
                    });
                }

                sr.Close();
            }
            _context.AddRange(micro);
            _context.SaveChanges();
        }

        public void InsertUms()
        {
            List<UnitMeasure> ums = new List<UnitMeasure>();
            using (StreamReader sr = new StreamReader(UmCsv)) // um
            {
                int count = 0;
                while (!sr.EndOfStream)
                {
                    count++;
                    string line = sr.ReadLine();
                    if (count == 1)
                    {
                        continue;
                    }

                    string[] split = line.Split(';');

                    ums.Add(new UnitMeasure
                    {
                        Name = split[0]
                    });
                }

                sr.Close();
            }
            _context.AddRange(ums);
            _context.SaveChanges();
        }

        public void InsertFoodsWithMicronutrients()
        {
            List<FoodHasMicronutrient> fhm = new List<FoodHasMicronutrient>();
            var umsDictionary = new Dictionary<long, long>();
            using (StreamReader sr = new StreamReader(FoodWithMicronutrientsCsv)) // food_whth_micronutrients
            {
                int count = 0;
                using (StreamReader sr2 = new StreamReader(MicronutrientsWithUmCsv)) // bda_micronutrients_with_um
                {
                    while (!sr2.EndOfStream)
                    {
                        count++;
                        string line = sr2.ReadLine();
                        if (count == 1)
                        {
                            continue;
                        }
                        string[] split = line.Split(';');
                        var findMicro = _context.Micronutrients.Where(s => s.Name.Equals(split[0])).AsNoTracking().FirstOrDefault();
                        var findUm = _context.UnitMeasures.Where(s => s.Name.Equals(split[1])).AsNoTracking().FirstOrDefault();
                        if (findUm == null || findMicro == null)
                            continue;
                        umsDictionary.Add(findMicro.Id, findUm.Id);
                    }
                } 
                count = 0;
                while (!sr.EndOfStream)
                {
                    count++;
                    if (count == 1)
                    {
                        continue;
                    }
                    string line = sr.ReadLine();
                    string[] split = line.Split(';');
                    var findFood = _context.Foods.Where(f => f.NameEn.ToLower().Equals(split[0].ToLower())).AsNoTracking().FirstOrDefault();
                    if (findFood == null)
                        continue;
                    foreach (var m in _context.Micronutrients.AsNoTracking().ToList())
                    {
                        fhm.Add(new FoodHasMicronutrient
                        {
                            FoodId = findFood.Id,
                            MicronutrientId = m.Id,
                            Quantity = split[m.Id].ToNumber<int>(),
                            UnitMeasureId = umsDictionary[m.Id]
                        });
                    }
                }

                sr.Close();
            }
            _context.AddRange(fhm);
            _context.SaveChanges();
        }
    }
}
