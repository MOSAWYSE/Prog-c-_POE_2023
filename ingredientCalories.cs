using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

delegate void CalorieAlert(double totalCalories);//declaring the delegate method

namespace RecipeGui
{
    
    public class ingredientCalories
    {
        
       public List<double> storedCalories = new List<double>();
        List<double> storedTotalRecipeCalories = new List<double>();//this list will be storin g the total number of calories calculated of each recipe
         List<string> ingredientFoodGroup = new List<string>();//ingredient food group array list
        double totalCalories = 0.0;

        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;//this will get the main window xaml class

        public void captureCalories() 
        {

            string calorie = Microsoft.VisualBasic.Interaction.InputBox("Enter the number of ingredient calories","Ingredient Calorie");//this will prompt the user to input calories
            double calories = double.Parse(calorie);//the string calorie will be converted into a double data type to make calculations
            storedCalories.Add(calories);//the double calorie will be stored on the calories list
        }


        public void captureFoodGroup()  
        {

            // Console.WriteLine("\nFOOD GROUPS\n1.Grains (more nutrients)\n2.Vegetables (more nutrients)\n3.Fruits (less nutrients)\n4.Proteins (more nutrients)\n5.Dairy (less nutrient)\nEnter the ingredient food group:");
            

            string foodGroup = mainWindow.ingredientFoodGroup.SelectedItem.ToString();//this will retrieve the selected item
            if(foodGroup == null) 
            {
                MessageBox.Show("The food group is empty check it","Food Group Is Empty");

            }
            else 
            {

                ingredientFoodGroup.Add(foodGroup);//the food group will be saved to the ingredient food group
            }

           
            
        }

        //this method will be checking the total number of calories in a recipe
        public string checkCalorieIntake(double calories) 
        {
            string status="";
            if(totalCalories1() >= 1800 && totalCalories1() <= 2000) 
            {
                status= "This is the maximum number of daily calories intake for females.";
            }
            else if(totalCalories1() >= 2000 && totalCalories1() <= 2500)
            {
                status = "This is the maximum number of daily calories intake for males";
            }
            else 
            {
                status = "correct calorie intake";
            }
            return status;

        }

        public string getFoodGroup(int v) 
        {
            return ingredientFoodGroup.ElementAt(v);//this will return the specified element on the ingredientFoodGroup list
        }

        public double getCalories(int v) 
        {
        return storedCalories.ElementAt(v);//This will retrieve the stored calories on the list
        }


      

        public double totalCalories1()
        {
            totalCalories = storedCalories.Sum();//this will assign the variable totalCalories with the total calories stored on the storedCalories list of each ingredient
            storedTotalRecipeCalories.Add(totalCalories);//adding the calculated total calorie on the list
            return totalCalories;
        }

        //this function will be printing the alert if the total number of calories exceeds 300
        public void AlertUser(double totalCalories) 
        {
            MessageBox.Show("\nThe total number of recipe calories exceeds 300 calories." );
             
        }


        public void alertingDelegate(double total) 
        {
            CalorieAlert userAlert = null;
            //this if statement will be checking if the total number of calories in a recipe exceeds 300 and if the delegate has not been used
            if(total > 300 && userAlert == null)
            {
                userAlert = AlertUser;//assigning the delegate to the AlertUser method
                userAlert(total);//this will invoke the  AlertUser method and the method will check the total
            }

        }


    }



}
