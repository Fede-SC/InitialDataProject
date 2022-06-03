using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techpork.Core.ConfigConstants
{
    public class DietConstants
    {
        public static readonly string[] INCLUDES = new string[]
            {
                "DietDays",
                "DietDays.Meals",
                "DietDays.Meals.Portions",
                "DietDays.Meals.Portions.Food",
                "DietDays.Meals.Portions.Food.Author",
                "DietDays.Meals.Portions.Food.Source",
                "DietDays.Meals.Portions.Food.FoodHasTags",
                "DietDays.Meals.Portions.Food.FoodHasTags.FoodTag",
                "DietDays.Meals.Portions.Food.FoodHasMicronutrients",
                "DietDays.Meals.Portions.Food.FoodHasMicronutrients.UnitMeasure",
                "DietDays.Meals.Portions.Food.FoodHasMicronutrients.Micronutrient"
            };
        public const string DELETED_PROPERTY = "Deleted";
        public const string USER_ID = "UserId";
    }
}
