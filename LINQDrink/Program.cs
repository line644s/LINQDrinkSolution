using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;

// ReSharper disable UnusedParameter.Local

namespace LINQDrink
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Create drinks
            List<Drink> drinks = new List<Drink>();
            drinks.Add(new Drink("Cuba Libre", "Rum", 3, "Cola", 20));
            drinks.Add(new Drink("Russia Libre", "Vodka", 3, "Cola", 20));
            drinks.Add(new Drink("The Day After", "None", 0, "Water", 20));
            drinks.Add(new Drink("Red Mule", "Vodka", 3, "Fanta", 20));
            drinks.Add(new Drink("Double Straight", "Whiskey", 6, "None", 0));
            drinks.Add(new Drink("Pearly Temple", "None", 0, "Sprite", 20));
            drinks.Add(new Drink("High Spirit", "Vodka", 6, "Sprite", 20));
            drinks.Add(new Drink("Watered Down", "Whiskey", 3, "Water", 3));
            drinks.Add(new Drink("Caribbean Gold", "Rum", 6, "Fanta", 20));
            drinks.Add(new Drink("Siberian Zone", "Vodka", 6, "None", 0));
            #endregion

            //var dnames = from drink in drinks
            //    select drink.Name;

            var dnames = drinks.Select(d => d.Name);
            Console.WriteLine("Drinks");
            foreach (var dname in dnames)
            {
                Console.WriteLine($"{dname}");
            }

            Console.WriteLine();
            Console.WriteLine("Drinks uden alkohol:");

            //var drinksUdenAlkohol = from drink in drinks
            //    where drink.AlcoholicPartAmount == 0
            //    select drink.Name;

            var drinksUdenAlkohol = drinks.Where(d => d.AlcoholicPartAmount == 0).Select(d => d.Name);

            foreach (var drink in drinksUdenAlkohol)
            {
                Console.WriteLine(drink);
            }

            Console.WriteLine();
            Console.WriteLine("Alkoholiske drinks");

            //var drinksMedAlkohol = from drink in drinks
            //    where drink.AlcoholicPartAmount > 0
            //    select new
            //    {
            //        DrinksMedAlkohol = "drink: " + drink.Name + " Alkohol: "+ drink.AlcoholicPart + " " + drink.AlcoholicPart + "Amount: " +
            //                           drink.AlcoholicPartAmount
            //    };
            var drinksMedAlkohol = drinks.Where(d => d.AlcoholicPartAmount > 0).Select(d =>
                "drink: " + d.Name + " Alkohol: " + d.AlcoholicPart + " " + d.AlcoholicPart + "Amount: " +
                d.AlcoholicPartAmount);

            foreach (var drink in drinksMedAlkohol)
            {
                Console.WriteLine(drink);
            }

            Console.WriteLine();
            Console.WriteLine("drinks i alfabetisk orden");

            //var soteretDrinks = from drink in drinks
            //    orderby drink.Name
            //    select drink.Name;

            var soteretDrinks = drinks.OrderBy(d => d.Name).Select(d=> d.Name);
            foreach (var soteretDrink in soteretDrinks)
            {
                Console.WriteLine(soteretDrink);
            }

            Console.WriteLine();
            Console.WriteLine("Den totale mængde alkohol");

            //int mængdeAlkohol = (from drink in drinks
            //    where drink.AlcoholicPartAmount > 0
            //    select drink.AlcoholicPartAmount).Sum();

            double mængdeAlkohol = drinks.Where(d => d.AlcoholicPartAmount > 0).Select(d => d.AlcoholicPartAmount).Sum();

            Console.WriteLine(mængdeAlkohol);

            Console.WriteLine();
            Console.WriteLine("Den gennemsnitlige amount af alkohol");

            //double gennemsnitligMængdeAlkohol = (from drink in drinks
            //    where drink.AlcoholicPartAmount > 0
            //    select drink.AlcoholicPartAmount).Average();
            double gennemsnitligMængdeAlkohol = drinks.Where(d => d.AlcoholicPartAmount > 0)
                .Select(d => d.AlcoholicPartAmount).Average();
            
            Console.WriteLine(gennemsnitligMængdeAlkohol);

            Console.WriteLine();
            Console.WriteLine("Drinks grouperet af alkohol");

            //var drinksGrouped = from drink in drinks
            //                    where drink.AlcoholicPartAmount > 0
            //                    group drink.Name by drink.AlcoholicPart into da
            //                    select new { da.Key, drink = da };

            //foreach (var drink in drinksGrouped)
            //{
            //    Console.WriteLine(drink.Key);
            //    foreach (var VARIABLE in drink.drink)
            //    {
            //        Console.WriteLine(VARIABLE);
            //    }

            //    Console.WriteLine();
            //}

            var drinksGrouped = drinks.Where(d => d.AlcoholicPartAmount > 0).Select(d => new { d.Name, d.AlcoholicPart })
                .GroupBy(d => d.AlcoholicPart, da => da.Name);

            foreach (var drink in drinksGrouped)
            {
                Console.WriteLine(drink.Key);
                foreach (var VARIABLE in drink)
                {
                    Console.WriteLine(VARIABLE);
                }
            }
            KeepConsoleWindowOpen();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
