using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_POE
{
    public class ingredientCalories
    {
        List<double> storedCalories = new List<double>();
         List<string> ingredientFoodGroup = new List<string>();//ingredient food group array list
        double totalCalories = 0.0;
        
        public void captureCalories() 
        {
            Console.WriteLine("Enter the number of the ingredient calories.");
            double calories = double.Parse(Console.ReadLine());
            storedCalories.Add(calories);
        }


        public void captureFoodGroup() 
        {
            Console.WriteLine("Enter the ingredient food group:");
            string foodGroup = Console.ReadLine();
            ingredientFoodGroup.Add(foodGroup);

            
        }

        public string getFoodGroup() 
        {
            return ingredientFoodGroup.First();//this will return the first element on the ingredientFoodGroup list
        }


      

        public double totalCalories1()
        {
            return storedCalories.Sum();
        }


       


    }
}
