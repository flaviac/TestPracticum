using TestPraticum.ConsoleApp.Commom;
using TestPraticum.ConsoleApp.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPraticum.ConsoleApp
{
    public class DishesData
    {  
        /// <summary>
        /// Get all dishes types
        /// </summary>
        public List<Dishes> GetAll()
        {
            var Dishes = new List<Dishes>();
            Dishes.Add(new Dishes()
            {
                id = 1,
                dish = "eggs",
                allowMultiple = false,
                mealTime = MealTimeObj.morning.ToString(),
                mealType = new MealTypeObj().entree,
                qtd = 1

            });
            Dishes.Add(new Dishes()
            {
                id = 2,
                dish = "toasts",
                allowMultiple = false,
                mealTime = MealTimeObj.morning.ToString(),
                mealType = new MealTypeObj().side,
                qtd = 1
            });
            Dishes.Add(new Dishes()
            {
                id = 3,
                dish = "coffee",
                allowMultiple = true,
                mealTime = MealTimeObj.morning.ToString(),
                mealType = new MealTypeObj().drink,
                qtd = 1

            });
          
            Dishes.Add(new Dishes()
            {
                id = 4,
                dish = "steak",
                allowMultiple = false,
                mealTime = MealTimeObj.night.ToString(),
                mealType = new MealTypeObj().entree,
                qtd = 1

            });
            Dishes.Add(new Dishes()
            {
                id = 5,
                dish = "potato",
                allowMultiple = true,
                mealTime = MealTimeObj.night.ToString(),
                mealType = new MealTypeObj().side,
                qtd = 1
    
            });
            Dishes.Add(new Dishes()
            {
                id = 6,
                dish = "wine",
                allowMultiple = false,
                mealTime = MealTimeObj.night.ToString(),
                mealType = new MealTypeObj().drink,
                qtd = 1

            });
            Dishes.Add(new Dishes()
            {
                id = 7,
                dish = "cake",
                allowMultiple = false,
                mealTime = MealTimeObj.night.ToString(),
                mealType = new MealTypeObj().dessert,
                qtd = 1

            });

            return Dishes;
        }

        /// <summary>
        /// Get filtered types of dishes
        /// </summary>
        /// <param name="opcs">string options</param>
        /// <param name="time">string mealtime</param>
        /// <returns></returns>
        public List<Dishes> GetByDishType(string opcs, string time)
        {
            List<Dishes> listDishes = GetAll();
            Dishes newDishes;
            List<Dishes> listNewDishes = new List<Dishes>();

            try
            {

                foreach (var item in opcs.Split(new char[] { ',' }))
                {
                    int opc = Convert.ToInt32(item);

                    newDishes = listDishes.FirstOrDefault(x => x.mealTime.ToString().Equals(time) && x.mealType.Equals(opc));

                    if ((newDishes == null) || listNewDishes.Any(x => x.mealType.Equals(newDishes.mealType) && !newDishes.allowMultiple))
                    {
                        newDishes = new Dishes();
                        newDishes.error.hasError = true;
                        newDishes.error.detail = "error";
                        newDishes.mealType = listNewDishes.Count + 1;
                        listNewDishes.Add(newDishes);
                        return listNewDishes;
                    }

                    if (listNewDishes.Any(x => x.mealType.Equals(newDishes.mealType)) && newDishes.allowMultiple)
                    {
                        listNewDishes.Remove(newDishes);
                        newDishes.qtd += listNewDishes.Count(x => x.mealType.Equals(newDishes.mealType)) + 1;
                    }

                    listNewDishes.Add(newDishes);

                }
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return listNewDishes;
        }

    }
}
