using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPraticum.ConsoleApp.Objects
{
    public class MealTypeObj
    {
        public int entree {get;set;}
        public int side  {get;set;}
        public int drink {get;set;}
        public int dessert { get; set;}

        public MealTypeObj()
        {
            entree = 1;
            side = 2;
            drink = 3;
            dessert = 4;
        }
    }          
}
