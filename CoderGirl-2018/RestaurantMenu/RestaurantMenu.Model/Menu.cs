using System;

namespace RestaurantMenu.Model
{
    public class Menu
    {
        public Menu()
        {
            MenuItems = new MenuItem[0];
        }

        public DateTime? LastUpdated
        {
            get
            {
                DateTime? lastUpdated = null;

                foreach (MenuItem menuItem in MenuItems)
                {
                    if (lastUpdated == null) lastUpdated = menuItem.AddedOn;
                    else if (lastUpdated < menuItem.AddedOn) lastUpdated = menuItem.AddedOn;
                }

                return lastUpdated;
            }
        }

        public MenuItem[] MenuItems { get; private set; }

        public void AddMenuItem(MenuItem menuItem)
        {
            MenuItem[] currentMenuItems = new MenuItem[MenuItems.Length + 1];
            for (int i = 0; i < MenuItems.Length; i++) currentMenuItems[i] = MenuItems[i];
            currentMenuItems[currentMenuItems.Length - 1] = menuItem;
            MenuItems = currentMenuItems;
        }

        public void RemoveMenuItem(MenuItem menuItem)
        {
            int newSize = 0;

            for (int i = 0; i < MenuItems.Length; i++)
            {
                if (MenuItems[i].Equals(menuItem)) MenuItems[i] = null;
                else newSize++;
            }

            int element = 0;

            MenuItem[] currentMenuItems = new MenuItem[newSize];
            foreach (MenuItem item in MenuItems)
            {
                if (item != null)
                {
                    currentMenuItems[element] = item;
                    element++;
                }
            }

            MenuItems = currentMenuItems;
        }

        public override string ToString()
        {
            string value = string.Empty;

            string[] categories = new string[] { "Appetizer", "Main Course", "Dessert" };

            foreach (string category in categories)
            {
                value += $"{category}s{Environment.NewLine}{Environment.NewLine}";

                foreach (MenuItem item in MenuItems)
                    if (item.Category == category)
                        value += $"{item} {Environment.NewLine}";

                value += Environment.NewLine;
            }

            value += $"Last updated {LastUpdated.Value.ToShortDateString()}";

            return value;
        }
    }
}