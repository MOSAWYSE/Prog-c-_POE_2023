        /*
using NUnit.Framework;
using System;
namespace IngredientCaloriesTest
{
    [TestFixture]
    public class IngredientCaloriesTests
    {
        [Test]
        public void returnsCorrectTotalCalories()
        {
            //this will arrange the values to be tested
          
            var ingredientCalories = new ingredientCalories();

            ingredientCalories.captureCalories();
            ingredientCalories.captureCalories();
            ingredientCalories.captureCalories();


            double expectedTotalCalories = 0.0;

            foreach (double calories in ingredientCalories.storedCalories)
            {
                expectedTotalCalories += calories;
            }

            //actual calories
            double actualTotalCalories = ingredientCalories.totalCalories1();


            //assert the values
            Assert.AreEqual(expectedTotalCalories, actualTotalCalories);


        }


    }

}
        */