using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCookbook.Models;

namespace MyCookbook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeItem> RecipeItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Recipe>()
                .Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.Entity<RecipeItem>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeItems)
                .HasForeignKey(ri => ri.RecipeId);

            builder.Entity<RecipeItem>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeItems)
                .HasForeignKey(ri => ri.IngredientId);

            builder.Entity<RecipeItem>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            base.OnModelCreating(builder);

            Seed(builder);
        }

        private static void Seed(ModelBuilder builder)
        {
            var cheese = new Ingredient() { Id = 1, Name = "Cheese" };
            var milk = new Ingredient() { Id = 2, Name = "Milk" };
            var pumpkin = new Ingredient() { Id = 3, Name = "Pumpkin" };
            var sugar = new Ingredient() { Id = 4, Name = "Sugar" };
            var beans = new Ingredient() { Id = 5, Name = "Beans" };
            var oliveoil = new Ingredient() { Id = 15, Name = "Olive Oil" };
            var salt = new Ingredient() { Id = 16, Name = "Salt" };

            var pastaCarbonara = new Recipe() { Id = 1, Title = "Pasta Carbonara", Instructions = "Make pasta Carbonara..." };
            var pancakes = new Recipe() { Id = 2, Title = "Pancakes", Instructions = "Make pancakes..." };
            var salad = new Recipe() { Id = 3, Title = "Salad", Instructions = "Make salad..." };
            var pumpkinSoup = new Recipe() { Id = 4, Title = "Pumkinsoup", Instructions = "Make pumkinsoup..." };
            var pizza = new Recipe() { Id = 5, Title = "Pizza", Instructions = "Make pizza..." };

            var carbonaraCheese = new RecipeItem() { RecipeId = pastaCarbonara.Id, IngredientId = cheese.Id, Name = cheese.Name, Unit = "Grams", Quantity = 100 };
            var carbonaraMilk = new RecipeItem() { RecipeId = pastaCarbonara.Id, IngredientId = milk.Id, Name = milk.Name, Unit = "Mililiter", Quantity = 500 };
            var carbonaraOliveOil = new RecipeItem() { RecipeId = pastaCarbonara.Id, IngredientId = oliveoil.Id, Name = oliveoil.Name, Unit = "Tablespoon", Quantity = 500 };
            var carbonaraSalt = new RecipeItem() { RecipeId = pastaCarbonara.Id, IngredientId = salt.Id, Name = salt.Name, Unit = "Teaspoon", Quantity = 500 };

            var pancakesPumpkin = new RecipeItem() { RecipeId = pancakes.Id, IngredientId = pumpkin.Id, Name = pumpkin.Name, Unit = "Piece", Quantity = 1 };
            var pancakesSugar = new RecipeItem() { RecipeId = pancakes.Id, IngredientId = sugar.Id, Name = sugar.Name, Unit = "Grams", Quantity = 20 };
            var pancakesBeans = new RecipeItem() { RecipeId = pancakes.Id, IngredientId = beans.Id, Name = beans.Name, Unit = "Grams", Quantity = 150 };

            builder.Entity<Ingredient>().HasData(cheese, milk, pumpkin, sugar, beans, salt, oliveoil);
            builder.Entity<Recipe>().HasData(pastaCarbonara, pancakes, salad, pumpkinSoup, pizza);
            builder.Entity<RecipeItem>().HasData(carbonaraCheese, carbonaraMilk, carbonaraOliveOil, carbonaraSalt, pancakesPumpkin, pancakesSugar, pancakesBeans);
            
        }

        public DbSet<MyCookbook.Models.RecipeDetailsViewModel> RecipeDetailsViewModel { get; set; }

        public DbSet<MyCookbook.Models.RecipeCreateViewModel> RecipeCreateViewModel { get; set; }

        
    }
}
