using System.Xml.Linq;
using System.Text;
using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Windows;
using System.IO;
using System;

namespace RecipeGui
{
   
     class displayRecipeInfo
    {//author: Mosa Tshikane(ST10036192)


          List<recipe> newRecipe = new List<recipe>();//this will be the recipe list that will be storing  the recipe data
        static double scale;


        //this  method will be sorting the recipes 
        public void displayRecipeAlphabetically()
        {
            try
            {
                MessageBox.Show("********RECIPES IN ALPHABETICAL ORDER^^^^^^");
                 List<recipe> sortedRecipes = newRecipe.OrderBy(recipe => recipe.getName()).ToList();

                string recipeList = "";
                //this for loop will print out the sorted recipe names
                for (int i = 0; i < sortedRecipes.Count; i++)
                {
                    recipeList += sortedRecipes[i].getName()+"\n";//this will retrieve the recipe data and create a new line 
                    
                }

                MessageBox.Show(recipeList, "List of available Recipes");



                string selection = Microsoft.VisualBasic.Interaction.InputBox("Enter the number of the recipe to display \nOnly the recipe number is required");

                int recipeNumber = int.Parse(selection);
                if (recipeNumber != 0)
                {
                    if (recipeNumber >= 1 && recipeNumber <= sortedRecipes.Count)
                    {
                        recipe selectedRecipe = sortedRecipes[recipeNumber - 1];
                        selectedRecipe.printRecipe();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid recipe number.","Incorrect recipe number");
                    }

                }
                else
                {
                    MessageBox.Show("Please enter a valid number.", "Incorrect user input");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("An exception has occured while printing recipe data "+e.Message,"Exception");
            }

        }



        public void recipePrompt(string prompt)
        {



            switch (prompt.ToLower())
            {
                case "yes":
                    {
                        //this will allow users to capture another recipe data
                        try
                        {
                            recipe obj = new recipe();//instantiating a the recipe class
                             
                            obj.captureInfo();  
                            newRecipe.Add(obj);//Add the recipe data to the array list
                            MessageBox.Show("Recipe data was captured successfully");
                            string choice = Microsoft.VisualBasic.Interaction.InputBox("Do you want to add more recipes? YES/NO");
                            recipePrompt(choice);

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("An exception has occured. " + e.Message, "Exception");
                        }
                        break;
                    }

                case "no":
                    {
                        //display start up menu

                        break;
                    }

                default:
                    {
                        MessageBox.Show("Please enter a yes or no answer.", "User prompt");
                        break;
                    }

            }



        }
    }
}