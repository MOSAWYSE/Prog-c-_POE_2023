using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace RecipeGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private recipe Recipe;
        private static List<recipe> newRecipe = new List<recipe>();//this will be the recipe list that will be storing  the recipe data
         displayRecipeInfo obj = new displayRecipeInfo();

        public MainWindow()
        {
            InitializeComponent();
            Recipe = new recipe();
            

        }
        //this function will handle the captureRecipe function

        private void captureButton(object sender, RoutedEventArgs e)
        {

            try
            {
                
                Recipe.captureInfo();//capture recipe data
                newRecipe.Add(Recipe);//ADDING THE RECIPE DATA TO THE LIST
                MessageBox.Show("Recipe data was captured successfully");
                string choice = Microsoft.VisualBasic.Interaction.InputBox("Do you want to add more recipes?(YES/NO)", "Continue Capturing Recipe data");
                obj.recipePrompt(choice);


            }
            catch (Exception ex)
            {
                MessageBox.Show("An exception has occured while capturing recipe data. " + ex.Message);
            }


        }
        //this function will be handling the print recipe data function
        private void printButton(object sender, RoutedEventArgs e)
        {
            Recipe.printRecipe();// this will printout the normal recipe data

            try
            {//this for each loop will iterate through the newRecipe array list to print all the recipe details
                foreach (recipe myRecipe in newRecipe)
                {//this method will display the recipes alphabetically
                    obj.displayRecipeAlphabetically();//print each recipe data
                }

               
            }
            catch (Exception er)
            {
               MessageBox.Show("An exception has occured while printing recipe data. " + er.Message);
            }

        }


        private void scaleButton(object sender, RoutedEventArgs e) //this function will be handling the recipe scaling
        {
           // Recipe.scaleRecipe();
            //this foreach loop will scale the recipes stored in the array list
            foreach (recipe myRecipe in newRecipe)
            {
                myRecipe.scaleRecipe();//scale recipe unit of measurement  
            }


        }

        //this function will be reseting recipe quantities
        private void resetButton(object sender,RoutedEventArgs e) 
        {
           // Recipe.resetQuanity(Recipe.scale);

            try
            {
                foreach (recipe myRecipe in newRecipe)
                {
                    myRecipe.resetQuanity(Recipe.scale);//reset recipe unit of measurement
                }
               

            }
            catch (IOException ex)
            {
                Console.WriteLine("An exception has occured while scaling values. " + ex.Message);
            }


        }

        //this function will clear all the list data stored 
        private void clearButton(object sender, RoutedEventArgs e) 
        {
            Recipe.clearData();

            try
            {
                newRecipe.Clear();//this will clear the recipe data stored in the array list
                MessageBox.Show("The recipe data was successfully cleared.");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception has occured while clearing recipe data. " + ex.Message);
            }

        }
        
       
    }

   

}
