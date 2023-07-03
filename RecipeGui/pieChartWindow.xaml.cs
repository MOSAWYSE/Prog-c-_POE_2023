using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace RecipeGui
{
    /// <summary>
    /// Interaction logic for pieChartWindow.xaml
    /// </summary>
    public partial class pieChartWindow : Window
    {
        private recipe Recipe;//instantiaing the recipe class
        private static List<recipe> newRecipe = new List<recipe>();
        displayRecipeInfo obj = new displayRecipeInfo();

        
        public pieChartWindow()
        {
            InitializeComponent();
            Recipe = new recipe();
        }

        //this function will be handling the print chart button action
        private void printChart(object sender, RoutedEventArgs e) 
        {
            Dictionary<string, double> foodGroupsPercent = new Dictionary<string, double>();//this dictionary will be storing the foodGroup percentages
            
            foreach(recipe myRecipe in newRecipe) 
            {//print the recipe details
            
            }

                   
        }

        
        private double getFirstAngle( int totalPie, int position) //this function will be responsible for calculating the angle of the first total calorie
        {
            return (360/totalPie)* position;//expression used to get the first angle
        }

        //this method will be calculating the last angle of the total calorie
        private double getLastAngle(int totalPie,int position)
        {
            return (360 / totalPie) *(position + 1);
            
        }


    }
}
