using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestPraticum.ConsoleApp;
using TestPraticum.ConsoleApp.Commom;

namespace TestPraticum.Tests
{
    [TestClass]
    public class ConsoleAppTests
    {
        public const string morning = "morning";
        public const string night = "night";

        [TestMethod]
        public void Test_MealTime_MORNING()
        {
            Assert.AreEqual(true, Helper.ValidMealTime("MORNING"));

        }

        [TestMethod]
        public void Test_Mealtime_Abc()
        {
            Assert.AreEqual(false, Helper.ValidMealTime("Abc"));

        }

        [TestMethod]
        public void Test_MealTime_NIGHT()
        {
            Assert.AreEqual(true, Helper.ValidMealTime("NIGHT"));

        }

        [TestMethod]
        public void Test_Opc_Abc()
        {
            var r= Helper.ValidOpc("Abc");
            Assert.AreEqual(true, r.hasError);
        }


        [TestMethod]
        public void Test_Opc_Morning_1_2_3()
        {
            string opcs = "1,2,3";
            var dishes = new DishesData().GetByDishType(opcs, morning);
            var dishesFormated = Helper.Format(dishes);

            Assert.AreEqual("eggs,toasts,coffee", dishesFormated);

        }

        [TestMethod]
        public void Test_Opc_Morning_1_2_3_4()
        {
            string opcs = "1,2,3,4";
            var dishes = new DishesData().GetByDishType(opcs, morning);
            var dishesFormated = Helper.Format(dishes);

            Assert.AreEqual("eggs,toasts,coffee,error", dishesFormated);

        }

        [TestMethod]
        public void Test_Opc_Morning_2_1_3()
        {
            string opcs = "2,1,3";
            var dishes = new DishesData().GetByDishType(opcs, morning);
            var dishesFormated = Helper.Format(dishes);

            Assert.AreEqual("eggs,toasts,coffee", dishesFormated);

        }

        [TestMethod]
        public void Test_Opc_Morning_1_2_3_3_3()
        {
            string opcs = "1,2,3,3,3";
            var dishes = new DishesData().GetByDishType(opcs, morning);
            var dishesFormated = Helper.Format(dishes);

            Assert.AreEqual("eggs,toasts,coffee(x3)", dishesFormated);

        }

        [TestMethod]
        public void Test_Opc_Night_1_2_3_4()
        {
            string opcs = "1,2,3,4";
            var dishes = new DishesData().GetByDishType(opcs, night);
            var dishesFormated = Helper.Format(dishes);

            Assert.AreEqual("steak,potato,wine,cake", dishesFormated);

        }

        [TestMethod]
        public void Test_Opc_Night_1_2_2_4()
        {
            string opcs = "1,2,2,4";
            var dishes = new DishesData().GetByDishType(opcs, night);
            var dishesFormated = Helper.Format(dishes);

            Assert.AreEqual("steak,potato(x2),cake", dishesFormated);
        }

        [TestMethod]
        public void Test_Opc_Night_1_2_2_5_4()
        {
            string opcs = "1,2,2,5,4";
            var dishes = new DishesData().GetByDishType(opcs, night);
            var dishesFormated = Helper.Format(dishes);

            Assert.AreEqual("steak,potato(x2),error", dishesFormated);
        }

        #region NUnit

        [NUnit.Framework.Test]
        public void Test_MealTime_MORNING_NUnit()
        {
            var input = "MORNING";
            var output = Helper.ValidMealTime(input);
            NUnit.Framework.Assert.AreEqual(true, output);
            Console.WriteLine(string.Format("Test MealTime: input {0} output {1}", input, output ));
        }

        [NUnit.Framework.Test]
        public void Test_Mealtime_Abc_NUnit()
        {
            var input = "Abc";
            var output = Helper.ValidMealTime(input);
            NUnit.Framework.Assert.AreEqual(false, output);
            Console.WriteLine(string.Format("Test MealTime: input {0} output {1}", input, output));
        }

        [NUnit.Framework.Test]
        public void Test_MealTime_NIGHT_NUnit()
        {
            var input = "NIGHT";
            var output = Helper.ValidMealTime(input);
            NUnit.Framework.Assert.AreEqual(true, output);
            Console.WriteLine(string.Format("Test MealTime: input {0} output {1}", input, output));
       
        }

        [NUnit.Framework.Test]
        public void Test_Opc_Abc_NUnit()
        {
            var input = "Abc";
            var output = Helper.ValidOpc(input);
            NUnit.Framework.Assert.AreEqual(true, output.hasError);
            Console.WriteLine(string.Format("Test Valid Dish Type: input  {0} output {1}", input, output.detail));

        }


        [NUnit.Framework.Test]
        public void Test_Opc_Morning_1_2_3_NUnit()
        {
            string opcs = "1,2,3";
            var dishes = new DishesData().GetByDishType(opcs, morning);
            var dishesFormated = Helper.Format(dishes);

            NUnit.Framework.Assert.AreEqual("eggs,toasts,coffee", dishesFormated);
            Console.WriteLine(string.Format("Test Morning: input {0} output {1}", opcs, dishesFormated));
       

        }

        [NUnit.Framework.Test]
        public void Test_Opc_Morning_1_2_3_4_NUnit()
        {
            string opcs = "1,2,3,4";
            var dishes = new DishesData().GetByDishType(opcs, morning);
            var dishesFormated = Helper.Format(dishes);

            NUnit.Framework.Assert.AreEqual("eggs,toasts,coffee,error", dishesFormated);
            Console.WriteLine(string.Format("Test Morning: input {0} output {1}", opcs, dishesFormated));
       
        }

        [NUnit.Framework.Test]
        public void Test_Opc_Morning_2_1_3_NUnit()
        {
            string opcs = "2,1,3";
            var dishes = new DishesData().GetByDishType(opcs, morning);
            var dishesFormated = Helper.Format(dishes);

            NUnit.Framework.Assert.AreEqual("eggs,toasts,coffee", dishesFormated);
            Console.WriteLine(string.Format("Test Morning: input {0} output {1}", opcs, dishesFormated));
       

        }

        [NUnit.Framework.Test]
        public void Test_Opc_Morning_1_2_3_3_3_NUnit()
        {
            string opcs = "1,2,3,3,3";
            var dishes = new DishesData().GetByDishType(opcs, morning);
            var dishesFormated = Helper.Format(dishes);

            NUnit.Framework.Assert.AreEqual("eggs,toasts,coffee(x3)", dishesFormated);
            Console.WriteLine(string.Format("Test Morning: input {0} output {1}", opcs, dishesFormated));
       
        }

        [NUnit.Framework.Test]
        public void Test_Opc_Night_1_2_3_4_NUnit()
        {
            string opcs = "1,2,3,4";
            var dishes = new DishesData().GetByDishType(opcs, night);
            var dishesFormated = Helper.Format(dishes);

            NUnit.Framework.Assert.AreEqual("steak,potato,wine,cake", dishesFormated);
            Console.WriteLine(string.Format("Test Night: input {0} output {1}", opcs, dishesFormated));
       
        }

        [NUnit.Framework.Test]
        public void Test_Opc_Night_1_2_2_4_NUnit()
        {
            string opcs = "1,2,2,4";
            var dishes = new DishesData().GetByDishType(opcs, night);
            var dishesFormated = Helper.Format(dishes);

            NUnit.Framework.Assert.AreEqual("steak,potato(x2),cake", dishesFormated);
            Console.WriteLine(string.Format("Test Night: input {0} output {1}", opcs, dishesFormated));
       
        }

        [NUnit.Framework.Test]
        public void Test_Opc_Night_1_2_2_5_4_NUnit()
        {
            string opcs = "1,2,2,5,4";
            var dishes = new DishesData().GetByDishType(opcs, night);
            var dishesFormated = Helper.Format(dishes);

            NUnit.Framework.Assert.AreEqual("steak,potato(x2),error", dishesFormated);
            Console.WriteLine(string.Format("Test Night: input {0} output {1}", opcs, dishesFormated));
       
        }

        #endregion
    }
}
