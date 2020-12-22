using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc_code
{
	public class Food
	{
		public Food(List<string> ingredients, List<string> allergens)
		{
			Ingredients = ingredients;
			Allergens = allergens;
		}

		public List<string> Ingredients { get; set; }
		public List<string> Allergens { get; set; }
	}

	public class Day21
	{
		public int Run(string input)
		{
			var foods = ParseFoods(input);

			var allAllergens = foods.SelectMany(f => f.Allergens).Distinct().ToList();
			var allIngredients = foods.SelectMany(f => f.Ingredients).Distinct().ToList();

			var dangerousIngredients = FindDangerousIngredients(foods, allAllergens, allIngredients);
			var safeIngredients = allIngredients.Except(dangerousIngredients);

			return safeIngredients.Sum(safeIngredient => foods.Count(f => f.Ingredients.Contains(safeIngredient)));
		}

		public string Run2(string input)
		{
			var foods = ParseFoods(input);

			var allAllergens = foods.SelectMany(f => f.Allergens).Distinct().ToList();
			var allIngredients = foods.SelectMany(f => f.Ingredients).Distinct().ToList();

			var dangerousIngredients = FindDangerousIngredients(foods, allAllergens, allIngredients);
			var safeIngredients = allIngredients.Except(dangerousIngredients).ToList();

			foreach (var food in foods)
			{
				food.Ingredients = food.Ingredients.Except(safeIngredients).ToList();
			}

			var identified = new List<Tuple<string, string>>();

			while (allAllergens.Count > 0)
			{
				foreach (var allergen in allAllergens)
				{
					var foodWithAllergen = foods.Where(f => f.Allergens.Contains(allergen));
					var commonIngredient = new List<string>(allIngredients);
					foreach (var food in foodWithAllergen)
					{
						commonIngredient = commonIngredient.Intersect(food.Ingredients).ToList();
					}

					if (commonIngredient.Count == 1)
					{
						identified.Add(new Tuple<string, string>(allergen, commonIngredient[0]));
						foreach (var food in foods)
						{
							food.Ingredients.Remove(commonIngredient[0]);
						}
					}
				}

				allAllergens = allAllergens.Except(identified.Select(i => i.Item1)).ToList();
			}

			return string.Join(",", identified.OrderBy(t => t.Item1).Select(t => t.Item2).ToList());
		}

		private static List<string> FindDangerousIngredients(List<Food> foods, List<string> allAllergens,
			List<string> allIngredients)
		{
			var dangerousIngredients = new List<string>();

			foreach (var allergen in allAllergens)
			{
				var foodWithAllergen = foods.Where(f => f.Allergens.Contains(allergen));
				var commonIngredient = new List<string>(allIngredients);
				foreach (var food in foodWithAllergen)
				{
					commonIngredient = commonIngredient.Intersect(food.Ingredients).ToList();
				}

				dangerousIngredients = dangerousIngredients.Union(commonIngredient).ToList();
			}

			return dangerousIngredients;
		}

		private static List<Food> ParseFoods(string input)
		{
			var foods = new List<Food>();
			var lines = input.Split("\r\n");
			foreach (var line in lines)
			{
				var parts = line.Split(" (contains ");
				var ingredients = parts[0].Split(" ").ToList();
				var allergens = parts[1].Replace(")", "").Replace(",", "").Split(" ").ToList();

				foods.Add(new Food(ingredients, allergens));
			}

			return foods;
		}
	}
}