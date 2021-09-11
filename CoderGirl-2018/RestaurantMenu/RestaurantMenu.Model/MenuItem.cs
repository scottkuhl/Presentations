using System;

namespace RestaurantMenu.Model
{
    public class MenuItem
    {
        private string _category = string.Empty;

        public DateTime AddedOn { get; set; }

        public string Category
        {
            get { return _category; }
            set
            {
                if (value.ToLower() == "appetizer") _category = "Appetizer";
                else if (value.ToLower() == "main course") _category = "Main Course";
                else if (value.ToLower() == "dessert") _category = "Dessert";
                else _category = string.Empty;
            }
        }

        public string Description { get; set; }

        public bool IsNew { get { return DateTime.Now <= AddedOn.AddDays(30); } }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            else if (!GetType().Equals(obj.GetType())) return false;
            else
            {
                MenuItem menuItem = (MenuItem)obj;
                return Name == menuItem.Name;
            }
        }

        public override string ToString()
        {
            return $"{Name} {Price:c} {Environment.NewLine}{(IsNew ? "(New) " : string.Empty)}{Description}";
        }
    }
}