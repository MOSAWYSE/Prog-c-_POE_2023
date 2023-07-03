using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecipeGui
{
    class recipe
    {//AUTHOR: Mosa Tshikane (ST10036192)


        int noOfIngredients = 0, Quanity, noSteps = 0;
        public double scale = 0;
        string name = "", quantity = "", unitNo = "", recipeName = "";

       public List<string> recipeNames = new List<string>();//this list will be storing the recipe names
        List<string> ingredientName = new List<string>();//this list will be storing the ingredients names
        List<string> stepDescription = new List<string>();//this list will be storing the steps descriptions
        List<string> ingredientUnit = new List<string>();//this list will be storing the name of the ingredient unit of measurement
        List<int> ingredientQuantity = new List<int>();//this list will be storing the ingredient quantity
        List<double> noOfMeasurement = new List<double>();//this list will be storing the number of the unit of measurement

        ingredientCalories caloriesClass = new ingredientCalories();

        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;//this will get the main window xaml class

        public void captureInfo()
        {
            try
            {


                mainWindow.Show();

                recipeName = Microsoft.VisualBasic.Interaction.InputBox("Enter the recipe Name", "New recipe name");
                recipeNames.Add(recipeName);//recipe name will be stored on the list
                                            //  MessageBox.Show("Enter your the number of ingredients to be captured");


                string noIngredients = Microsoft.VisualBasic.Interaction.InputBox("Enter the number of ingredients to be captured","Recipe Ingredients");

                //string noIngredients = mainWindow.numberOfIngredientsTextbox.Text;//this is the number of ingredients on the textbox on the xml
                noOfIngredients = int.Parse(noIngredients);//string data type will be converted into an integer for the number of the ingredients




                //this foor loop will iterate through the number of ingredients to allow the user input of each ingredient 
                for (int v = 0; v < noOfIngredients; ++v)
                {
                    name = Microsoft.VisualBasic.Interaction.InputBox($"Enter the name of the ({v + 1}) ingredient:", "Ingredient " + (v + 1) + " name");
                    ingredientName.Add(name);

                    string quantityInput = Microsoft.VisualBasic.Interaction.InputBox($"Enter the quantity of {name}:", "Ingredient " + (v + 1) + " quantity");
                    Quanity = int.Parse(quantityInput);
                    ingredientQuantity.Add(Quanity);

                    string unitNoInput = Microsoft.VisualBasic.Interaction.InputBox("Enter the number of the unit of measurement:", "Ingredient " + (v + 1) + " number of unit of Measurement ");
                    double unitNoDouble = double.Parse(unitNoInput);
                    noOfMeasurement.Add(unitNoDouble);

                    string unit = Microsoft.VisualBasic.Interaction.InputBox("Enter the unit of measurement to be used:", "Unit of Measurement");
                    ingredientUnit.Add(unit);

                    caloriesClass.captureCalories(); // Modify this method to capture calories using input dialog or prompts

                    caloriesClass.captureFoodGroup();



                }


                //end of testing




                /*old code starts here


                //THIS FOR LOOP WILL STORE THE DATA OF EACH INGREDIENT
                for (int v = 0; v < noOfIngredients; ++v)
                {

                   // mainWindow.ingredientName.BringIntoView();

                    name = mainWindow.ingredientName.Text;//this line will retrieve the text from the text box
                    ingredientName.Add(name);//this will store the ingredient name on the first position of the array

                    //Console.WriteLine($"Enter the quantity of {name} :");//this will prompt the user to input the quanity of the ingredient

                    quantity = mainWindow.ingredientQuantity.Text;//this line will retrieve the text from the text box
                    Quanity = int.Parse(quantity);//string data type will be converted into an integer for the quanity
                    ingredientQuantity.Add(Quanity);//the quanity will be stored on the ingredient quantity list


                    // Console.WriteLine($"Enter the number of the unit of measurement for eg (4) instead of (4 spoons) :");

                    unitNo = mainWindow.ingredientUnitOfMeasurement.Text;//this will get the unit number from the textbox
                    double unitNoDouble = double.Parse(unitNo);//string data type is being converted to a double
                    noOfMeasurement.Add(unitNoDouble);//this will be the number stored of the unit of measurement


                    //Console.WriteLine($"Enter the unit of measurement to be used eg(spoons, Cups, ml and etc.");//this will prompt the user to input unit of measurement that will be used
                    string unit = mainWindow.UnitOfMeasurement.Text;//this line will retrieve the unitof measurement on the textbox
                    ingredientUnit.Add(unit);//this will be the unit of measurement used eg spoons, ml and etc.




                    //capture the ingredient calories here

                    caloriesClass.captureCalories();//i need to modify the method of the calories

                    //capture the ingredient food group here
                    caloriesClass.captureFoodGroup();

                }


                old code ends here */

                string steps = mainWindow.recipeNoSteps.Text;//this is the number of recipe steps on the textbox on the xml

                //steps data
                //Console.WriteLine("Enter the number of steps of the recipe:");

                noSteps = int.Parse(steps);//this will be the number of steps of the recipe

                //this for loop will iterate the number of steps until there are no steps available
                for (int b = 0; b < noSteps; b++)
                {
                    //  Console.WriteLine($"Enter the description of step {b + 1} :");//this will be printing out the number of step description to be entered
                    string stepInfo = Microsoft.VisualBasic.Interaction.InputBox($"Enter the description of step {b + 1} ", "Recipe Step description");
                    stepDescription.Add(stepInfo);//stepInfo data is store into the step description list

                }


            }
            catch (Exception e)
            {
                MessageBox.Show("An exception has occured while capturing data. " + e.Message, "Exception");
            }



        }

        public void printRecipe()
        {

            //  Console.WriteLine($"\n*********RECIPE RESULTS*************");
            // Console.WriteLine($"\nRecipe Name >> {recipeName} \nNumber of ingredients : {noOfIngredients}");

            //for (int i = 0; i < noOfIngredients; i++)
            //{
            //Console.WriteLine($"\nIngredient name: {ingredientName.ElementAt(i)} \nIngredient quantity : {ingredientQuantity.ElementAt(i)}\nIngredient unit of measurement : {noOfMeasurement.ElementAt(i)} {ingredientUnit.ElementAt(i)}\nIngredient calories:{caloriesClass.getCalories(i)}\nIngredient food group:{caloriesClass.getFoodGroup(i)}");
            // }

            //print total recipe calories
            //Console.WriteLine($"\nTotal recipe calories: {caloriesClass.totalCalories1()}   (this is the total units of energy that the the recipe provides.)");
            //this method will be invoking the total recipe calories delegate 
            //caloriesClass.alertingDelegate(caloriesClass.totalCalories1());//this will be my delegate

            //use the number of steps to display the steps and a for loop
            //this for loop will iterate through the array
            // Console.WriteLine($"\nNumber of steps : {noSteps}");
            //for (int i = 0; i < noSteps; i++)
            //{
            //  Console.WriteLine($"\nStep {i + 1} description :{stepDescription.ElementAt(i)}. ");//this will display the step description
            //}
            try
            {

                MessageBox.Show($"Recipe results\nRecipe Name >> {recipeName} \nNumber of ingredients: {noOfIngredients}", "*********RECIPE RESULTS*************");//this statement will display the number of ingredients
                for (int i = 0; i < noOfIngredients; i++)
                {
                    MessageBox.Show($"Ingredient name: {ingredientName.ElementAt(i)} \nIngredient quantity : {ingredientQuantity.ElementAt(i)}\nIngredient unit of measurement : {noOfMeasurement.ElementAt(i)} {ingredientUnit.ElementAt(i)}\nIngredient calories:{caloriesClass.getCalories(i)}\nIngredient food group:{caloriesClass.getFoodGroup(i)}", "******Ingredient " + (1 + i) + " Result******");
                }


                //print total recipe calories
                MessageBox.Show($"Total recipe calories: {caloriesClass.totalCalories1()}   (this is the total units of energy that the the recipe provides.)", "Total recipe calorie");
                caloriesClass.alertingDelegate(caloriesClass.totalCalories1());//this will invoke the calorie notification if it exceeds 300


                MessageBox.Show($"Number of steps:{noSteps}", "Total recipe steps");

                for (int i = 0; i < noSteps; i++)
                {
                    MessageBox.Show($"Step {i + 1} description :{stepDescription.ElementAt(i)}. ", $"{recipeName} step {i + 1} description");//this line will printout each step description using a messagebox

                }
                //notify the user about the calories limit
                MessageBox.Show(caloriesClass.checkCalorieIntake(caloriesClass.totalCalories1()), "Human Calorie Intake");

            }
            catch (IndexOutOfRangeException range)
            {
                MessageBox.Show("An index out of range exception has occured " + range.Message, "Exception");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An exception occured while printing recipe data." + ex.Message, "Exception");
            }


        }

        //this method will be used to scale the recipe of the captured ingredient
        public void scaleRecipe()
        {
            try
            {
                scale = double.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter the scale ratio number to scale the recipe data"));//THIS will prompt the user to input the recipe scale to scale the recipe

                double scaledQuantity;//this variable will be storing the scaled quanity temporary
                double newQuantity;
                double scaledCalorie;
                for (int i = 0; i < noOfIngredients; ++i)
                {
                    scaledQuantity = noOfMeasurement.ElementAt(i) * scale;//this is the formula used to calculate the new scaled quantity with the scale in the argument
                    newQuantity = ingredientQuantity.ElementAt(i) * scale;
                    scaledCalorie = caloriesClass.getCalories(i) * scale;
                    noOfMeasurement.RemoveAt(i);//this will remove the old stored unit of measurement of a recipe that is stored on the list
                    ingredientQuantity.RemoveAt(i);//this will remove the ingredient quantity that is stored on the list
                    caloriesClass.storedCalories.RemoveAt(i);//this will remove the stored calorie number of a ingredient in a list 


                    noOfMeasurement.Add(scaledQuantity);//the calculated scaled quantity will be stored in a number of measurement list
                    ingredientQuantity.Add((int)newQuantity);//calculated ingredient quantity will be stored in the ingredient quantity list
                    caloriesClass.storedCalories.Add(scaledCalorie);//the calculated sclaed calorie will be stored on the list


                }

                MessageBox.Show("The recipe data was scaled successfully.");

            }
            catch (IOException io)
            {
                MessageBox.Show("An IO exception has occured while capturing recipe data "+io.Message, "Exception");
            }

        }

        //THIS METHOD WILL BE RESETING THE QUANITIES OF THE INGREDIENT
        public void resetQuanity(double scale)
        {
            try { 
            double resetQuantity;//this variable will be storing the reseted quantities
            double oldQuantity;
            double oldCalorie;



            for (int i = 0; i < noOfIngredients; ++i)
            {
                resetQuantity = noOfMeasurement.ElementAt(i) / scale;//this will divide the stored unit of measurement with the provided value on the method parameter
                oldQuantity = ingredientQuantity.ElementAt(i) / scale;
                oldCalorie = caloriesClass.getCalories(i) / scale;
                noOfMeasurement.RemoveAt(i);//this will remove the old stored unit of measurement of a recipe that is stored on the list
                ingredientQuantity.RemoveAt(i);//this will remove the ingredient quantity that is stored on the list
                caloriesClass.storedCalories.RemoveAt(i);


                noOfMeasurement.Add(resetQuantity);//the divided quantity will be stored in the unit of measurement list
                ingredientQuantity.Add((int)oldQuantity);//implicit data type casting
                caloriesClass.storedCalories.Add(oldCalorie);
            }


            MessageBox.Show("Quantity reset completed successfully.");

        }
        catch(IOException ex)
            {
                MessageBox.Show("An IO exception has occurred "+ex.Message,"Exception");
            }

        }

        //This method will be clearing the stored information on the arrays/tempData
        public void clearData()
        {
            try 
            {
                //this for loop will be removing the elements that are stored on the lists
                for (int i = 0; i < noOfIngredients; ++i)
                {
                    noOfIngredients = 0;
                    noSteps = 0;
                    ingredientName.RemoveAt(i);
                    stepDescription.RemoveAt(i);
                    ingredientQuantity.RemoveAt(i);
                    noOfMeasurement.RemoveAt(i);
                    ingredientUnit.RemoveAt(i);
                    stepDescription.RemoveAt(i);
                }
                MessageBox.Show("The recipe data was successfully cleared.");

            }
            catch(Exception e) 
            {
                MessageBox.Show("An exception has occured while capturing recipe data "+e.Message);
            }
            //this for loop will set all the array data to default values to clear all the arrays

           

        }

        //this method will get the first recipe name
        public string getName()
        {
            return recipeNames.First();//this will retriev the first element at the recipe names list
        }

    } //end of recipe class
}
