using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPraticum.ConsoleApp.Objects;

namespace TestPraticum.ConsoleApp.Commom
{
    public static class Helper
    {
        /// <summary>
        /// format the list of dishes in string
        /// </summary>
        /// <param name="listDishes"></param>
        /// <returns></returns>
        public static string Format(List<Dishes> listDishes)
        {
            var newlistOrdered = new List<string>();


            foreach (var item in listDishes.OrderBy(x => x.mealType))
            {
                if (item.error.hasError)
                {
                    newlistOrdered.Add(item.error.detail);
                }
                else if (item.qtd > 1)
                {
                    newlistOrdered.Add(string.Format("{0}(x{1})", item.dish, item.qtd));
                }
                else
                {
                    newlistOrdered.Add(item.dish);
                }
            }

            return string.Join(",", newlistOrdered);
        }

        /// <summary>
        /// checks if it is a valid mealTime
        /// </summary>
        /// <param name="mealTime"></param>
        /// <returns></returns>
        public static bool ValidMealTime(string mealTime)
        {
            return mealTime.ToLower() == MealTimeObj.morning.ToString() || mealTime.ToLower() == MealTimeObj.night.ToString();
        }

        /// <summary>
        /// check if it is a valid option of dish types
        /// </summary>
        /// <param name="opc"></param>
        /// <returns></returns>
        public static Error ValidOpc(string opc)
        {
            Error error = new Error();
            foreach (var item in opc.Split(new char[] { ',' }))
            {
                int r;
                int.TryParse(item.Trim(), out r);

                if (r == 0)
                {
                    error.hasError = true;
                    error.detail = "Only integer numbers are allowed";
                    return error;
                }
            }
            return error;
        }
    }
}
