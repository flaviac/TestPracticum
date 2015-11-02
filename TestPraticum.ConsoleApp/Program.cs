using TestPraticum.ConsoleApp.Commom;
using TestPraticum.ConsoleApp.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPraticum.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Dishes> listMeals = new List<Dishes>();

            string mealtime = string.Empty;
            string opc = string.Empty;

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the time of day : morning or night (press CTRL+Z to exit):");
                    mealtime = Console.ReadLine();


                    if (Helper.ValidMealTime(mealtime))
                    {
                        Console.WriteLine("Enter with the meal type list numbers: (press CTRL+Z to exit):");
                        opc = Console.ReadLine();

                        var r = Helper.ValidOpc(opc);

                        if (!r.hasError)
                        {
                            var listDishes = new DishesData().GetByDishType(opc, mealtime);
                            string dishes = Helper.Format(listDishes);

                            Console.WriteLine(dishes);
                        }
                        else
                        {
                            Console.WriteLine(r.detail);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Unexpected error, try again !");                    
                }
                
            }
        }
    }
}