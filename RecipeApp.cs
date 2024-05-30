using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook
{
    public class RecipeApp
    {
        private List<Recipe> recipes = new List<Recipe>();
        private Dictionary<string, Recipe> recipeDict = new Dictionary<string, Recipe>();

        // Delegate for notifying when calories exceed 300
        public delegate void CalorieNotification(string message);
        public event CalorieNotification OnCalorieExceeded;

        public Recipe CreateRecipe()
        {
            Recipe recipe = new Recipe();
            Console.WriteLine("Enter the recipe name:");
            string name = Console.ReadLine();
            recipeDict[name] = recipe;

            // Add ingredients
            Console.WriteLine("Enter the number of ingredients:");
            int numIngredients = int.Parse(Console.ReadLine());
            for (int i = 0; i < numIngredients; i++)
            {
                Ingredient ingredient = new Ingredient();
                Console.WriteLine($"Enter name of ingredient {i + 1}:");
                ingredient.Name = Console.ReadLine();
                Console.WriteLine($"Enter quantity of {ingredient.Name}:");
                ingredient.Quantity = float.Parse(Console.ReadLine());
                Console.WriteLine($"Enter unit of {ingredient.Name}:");
                ingredient.Unit = Console.ReadLine();
                Console.WriteLine($"Enter calories of {ingredient.Name}:");
                ingredient.Calories = float.Parse(Console.ReadLine());
                Console.WriteLine($"Enter food group of {ingredient.Name}:");
                ingredient.FoodGroup = Console.ReadLine();

                recipe.Ingredients.Add(ingredient);
            }

            // Add steps
            Console.WriteLine("Enter the number of steps:");
            int numSteps = int.Parse(Console.ReadLine());
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                recipe.Steps.Add(Console.ReadLine());
            }

            recipes.Add(recipe);
            return recipe;
        }

        public void DisplayRecipe(Recipe recipe)
        {
            Console.WriteLine("Recipe:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }
            foreach (var step in recipe.Steps)
            {
                Console.WriteLine(step);
            }
            Console.WriteLine($"Total calories: {GetTotalCalories(recipe)}");
        }

        public void ScaleRecipe(Recipe recipe, float factor)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities(Recipe recipe)
        {
            // Assuming initial quantities were stored, for simplicity not implemented
        }

        public void ClearRecipe(Recipe recipe)
        {
            recipe.Ingredients.Clear();
            recipe.Steps.Clear();
        }

        public float GetTotalCalories(Recipe recipe)
        {
            float totalCalories = recipe.Ingredients.Sum(ingredient => ingredient.Calories);
            if (totalCalories > 300)
            {
                OnCalorieExceeded?.Invoke("Total calories exceed 300!");
            }
            return totalCalories;
        }

        public void DisplayAllRecipes()
        {
            foreach (var recipeName in recipeDict.Keys.OrderBy(name => name))
            {
                Console.WriteLine(recipeName);
            }
        }

        public void DisplayRecipeByName(string name)
        {
            if (recipeDict.TryGetValue(name, out Recipe recipe))
            {
                DisplayRecipe(recipe);
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
    }
}
