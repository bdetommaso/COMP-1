using System;
using System.Collections.Generic;
using System.Linq;

namespace SprocketOrderApp
{
    public class SprocketOrder
    {
        // Properties
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; private set; }
        public List<Sprocket> Items { get; private set; }

        // Constructors
        public SprocketOrder(string customerName, string address, List<Sprocket> items)
        {
            CustomerName = customerName;
            Address = address;
            Items = items ?? new List<Sprocket>();
            Calculate();
        }

        public SprocketOrder() : this("Unknown", null, null) { }

        // Methods
        public void AddItem(Sprocket sprocket)
        {
            Items.Add(sprocket);
            Calculate();
        }

        public void RemoveItem(Sprocket sprocket)
        {
            Items.Remove(sprocket);
            Calculate();
        }

        private void Calculate()
        {
            TotalPrice = Items.Sum(item => item.Price);
        }

        public override string ToString()
        {
            var addressString = string.IsNullOrEmpty(Address) ? "Local Pickup" : Address;
            return $"{CustomerName}: {Items.Count} items, Total Price: {TotalPrice:C}\nShip to: {addressString}";
        }
    }
}
