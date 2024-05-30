using Xunit;
using CookBook;

namespace CookBookTests
{
    public class RecipeAppTests
    {
        [Fact]
        public void TestTotalCaloriesCalculation()
        {
            // Arrange
            Recipe recipe = new Recipe();
            recipe.Ingredients.Add(new Ingredient { Name = "Chicken", Quantity = 200, Unit = "g", Calories = 220 });
            recipe.Ingredients.Add(new Ingredient { Name = "Rice", Quantity = 100, Unit = "g", Calories = 130 });
            recipe.Ingredients.Add(new Ingredient { Name = "Broccoli", Quantity = 50, Unit = "g", Calories = 30 });

            RecipeApp recipeApp = new RecipeApp();

            // Act
            float totalCalories = recipeApp.GetTotalCalories(recipe);

            // Assert
            Assert.Equal(380, totalCalories);
        }
    }
}
