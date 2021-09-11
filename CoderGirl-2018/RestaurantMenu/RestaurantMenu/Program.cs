using RestaurantMenu.Model;
using System;

namespace RestaurantMenu
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.AddMenuItem(new MenuItem { AddedOn = new DateTime(2017, 08, 30), Category = "Dessert", Description = "Made fresh daily.", Name = "Apple Pie", Price = 2.99m });
            menu.AddMenuItem(new MenuItem { AddedOn = new DateTime(2018, 08, 29), Category = "Dessert", Description = "Straight from the cow.", Name = "Ice Cream", Price = 1.99m });

            menu.AddMenuItem(new MenuItem { AddedOn = new DateTime(2016, 08, 30), Category = "Appetizer", Description = "A St. Louis tradition.", Name = "Toasted Ravioli", Price = 4.99m });
            menu.AddMenuItem(new MenuItem { AddedOn = new DateTime(2015, 08, 20), Category = "Appetizer", Description = "Spears, not chips.", Name = "Fried Pickles", Price = 4.99m });

            menu.AddMenuItem(new MenuItem { AddedOn = new DateTime(2017, 08, 30), Category = "Main Course", Description = "Testing.", Name = "Bag of Garbage", Price = 16.99m });
            menu.RemoveMenuItem(new MenuItem { AddedOn = new DateTime(2017, 08, 30), Category = "Main Course", Description = "", Name = "Bag of Garbage", Price = 2.99m });

            menu.AddMenuItem(new MenuItem { AddedOn = new DateTime(2017, 08, 30), Category = "Main Course", Description = "Served medium well.", Name = "Burger", Price = 6.99m });
            menu.AddMenuItem(new MenuItem { AddedOn = new DateTime(2017, 08, 26), Category = "Main Course", Description = "Served raw.", Name = "Chicken Tartar", Price = 12.99m });

            Console.WriteLine(menu);

            Console.ReadLine();
        }
    }
}