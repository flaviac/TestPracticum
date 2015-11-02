using TestPraticum.ConsoleApp.Commom;
using TestPraticum.ConsoleApp.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPraticum.ConsoleApp
{
    public class Dishes
    {
        public int id { get; set; }
        public string dish { get; set; }
        public bool allowMultiple { get; set; }
        public int mealType { get; set; }
        public string mealTime { get; set; }
        public int qtd { get; set; }
        public Error error { get; set; }

        public Dishes()
        {
            error = new Error();
        }
        
    }
}
