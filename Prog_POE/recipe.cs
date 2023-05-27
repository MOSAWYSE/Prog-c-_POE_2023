using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prog_POE
{
    class recipe
    {//AUTHOR: Mosa Tshikane (ST10036192)


        int noOfIngredients = 0, Quanity, noSteps = 0;
        double scale;
        string name = "", quantity = "", unitNo = "", recipeName="";

        List<string> recipeNames = new List<string>();//this list will be storing the recipe names
        List<string> ingredientName = new List<string>();//this list will be storing the ingredients names
        List<string> stepDescription = new List<string>();//this list will be storing the steps descriptions
        List<string> ingredientUnit = new List<string>();//this list will be storing the name of the ingredient unit of measurement
        List<int> ingredientQuantity = new List<int>();//this list will be storing the ingredient quantity
        List<double> noOfMeasurement = new List<double>();//this list will be storing the number of the unit of measurement

        ingredientCalories caloriesClass = new ingredientCalories();

        public void captureInfo()
        {
            try
            {

                Console.WriteLine("************CAPTURE NEW RECIPE DATA************");
                Console.WriteLine("Enter your recipe name:");
                 recipeName = Console.ReadLine();
                    recipeNames.Add(recipeName);//recipe name will be stored on the list

                Console.WriteLine("Enter the number of ingredients to be captured:");

                string noIngredients = Console.ReadLine();
                noOfIngredients = int.Parse(noIngredients);//string data type will be converted into an integer for the number of the ingredients

                //THIS FOR LOOP WILL STORE THE DATA OF EACH INGREDIENT
                for (int v = 0; v < noOfIngredients; ++v)
                {

                    Console.WriteLine($"Enter the name of the ({v + 1}) ingredient:");//this will prompt the user to input the ingredient name
                    name = Console.ReadLine();
                    ingredientName.Add(name);//this will store the ingredient name on the first position of the array

                    Console.WriteLine($"Enter the quantity of {name} :");//this will prompt the user to input the quanity of the ingredient
                    quantity = Console.ReadLine();
                    Quanity = int.Parse(quantity);//string data type will be converted into an integer for the quanity
                    ingredientQuantity.Add(Quanity);//the quanity will be stored on the ingredient quantity list


                    Console.WriteLine($"Enter the number of the unit of measurement for eg (4) instead of (4 spoons) :");
                    unitNo = Console.ReadLine();
                    double unitNoDouble = double.Parse(unitNo);//string data type is being converted to a double
                    noOfMeasurement.Add(unitNoDouble);//this will be the number stored of the unit of measurement


                    Console.WriteLine($"Enter the unit of measurement to be used eg(spoons, Cups, ml and etc.");//this will prompt the user to input unit of measurement that will be used
                    string unit = Console.ReadLine();
                    ingredientUnit.Add(unit);//this will be the unit of measurement used eg spoons, ml and etc.

                   
                    //capture the ingredient calories here
                    caloriesClass.captureCalories();

                    //capture the ingredient food group here
                    caloriesClass.captureFoodGroup();

                }

                //steps data
                Console.WriteLine("Enter the number of steps of the recipe:");
                string steps = Console.ReadLine();
                noSteps = int.Parse(steps);//this will be the number of steps of the recipe

                //this for loop will iterate the number of steps until there are no steps available
                for (int b = 0; b < noSteps; b++)
                {
                    Console.WriteLine($"Enter the description of step {b + 1} :");//this will be printing out the number of step description to be entered
                    string stepInfo = Console.ReadLine();
                    stepDescription.Add(stepInfo);//stepInfo data is store into the step description list

                }


            }
            catch (Exception e)
            {
                Console.WriteLine("An exception has occured while capturing data. " + e.Message);
            }



        }

        public void printRecipe()
        {

        

            Console.WriteLine($"\n*********RECIPE RESULTS*************");
            Console.WriteLine($"\nRecipe Name >> {recipeName} \nNumber of ingredients : {noOfIngredients}");

            for (int i = 0; i < noOfIngredients; i++)
            {
                Console.WriteLine($"\nIngredient name: {ingredientName.ElementAt(i)} \nIngredient quantity : {ingredientQuantity.ElementAt(i)}\nIngredient unit of measurement : {noOfMeasurement.ElementAt(i)} {ingredientUnit.ElementAt(i)}\nIngredient calories:{caloriesClass.getCalories(i)}\nIngredient food group:{caloriesClass.getFoodGroup(i)}");
            }

            //use the number of steps to display the steps and a for loop
            //this for loop will iterate through the array
            Console.WriteLine($"\nNumber of steps : {noSteps}");
            for (int i = 0; i < noSteps; i++)
            {
                Console.WriteLine($"\nStep {i + 1} description :{stepDescription.ElementAt(i)}. ");//this will display the step description
            }


        }

        //this method will be used to scale the recipe of the captured ingredient
        public void scaleRecipe(double scale)
        {
            double scaledQuantity;//this variable will be storing the scaled quanity temporary
            int newQuantity;
            for (int i = 0; i < noOfIngredients; ++i)
            {
                scaledQuantity = noOfMeasurement[i] * scale;//this is the formula used to calculate the new scaled quantity with the scale in the argument
                newQuantity = (int)(ingredientQuantity[i] * scale);
                noOfMeasurement[i] = scaledQuantity;//the calculated scaled quantity will be stored in a array
                ingredientQuantity[i] = newQuantity;

            }
            Console.WriteLine("The recipe data was scaled successfully.");

        }

        //THIS METHOD WILL BE RESETING THE QUANITIES OF THE INGREDIENT
        public void resetQuanity(double scale)
        {
            double resetQuantity;//this variable will be storing the reseted quantities
            double oldQuantity;

            for (int i = 0; i < noOfIngredients; ++i)
            {
                resetQuantity = noOfMeasurement[i] / scale;//this will devide the stored unit of measurement with the provided value on the method parameter
                oldQuantity = ingredientQuantity[i] / scale;
                noOfMeasurement[i] = resetQuantity;//the devided quantity will be stored in the unit of measurement array
                ingredientQuantity[i] = (int)oldQuantity;//implicit data type casting
            }

            Console.WriteLine("Quantity reset completed successfully.");
        }

        //This method will be clearing the stored information on the arrays/tempData
        public void clearData()
        {
            //this for loop will set all the array data to default values to clear all the arrays
            string clear = "";
            for (int i = 0; i < noOfIngredients; ++i)
            {
                noOfIngredients = 0;
                noSteps = 0;
                ingredientName[i] = clear;
                stepDescription[i] = clear;
                ingredientQuantity[i] = 0;
                noOfMeasurement[i] = 0;
                ingredientUnit[i] = clear;
            }
            Console.WriteLine("The recipe data was successfully cleared.");

        }

        //this method will get the first recipe name
        public string getName()
        {
            return recipeNames[0];
        }

    }

}
