using System;

namespace StoreOrderApp
{
    public class LogoOrderItem
    {
        // Private backing fields
        private bool hasLogo;
        private string itemType;
        private int numColors;
        private int numItems;
        private string text;

        // Auto-properties
        public int ItemID { get; private set; }
        public decimal TotalPrice { get; private set; } // Read-only property

        // Properties with backing fields
        public bool HasLogo
        {
            get => hasLogo;
            set
            {
                hasLogo = value;
                Calc();
            }
        }

        public string ItemType
        {
            get => itemType;
            set
            {
                itemType = value;
                Calc();
            }
        }

        public int NumColors
        {
            get => numColors;
            set
            {
                numColors = value;
                Calc();
            }
        }

        public int NumItems
        {
            get => numItems;
            set
            {
                numItems = value;
                Calc();
            }
        }

        public string Text
        {
            get => text;
            set
            {
                text = value;
                Calc();
            }
        }

        // Constructors
        public LogoOrderItem(int itemID, string itemType, int numColors, int numItems, bool hasLogo, string text)
        {
            ItemID = itemID;
            ItemType = itemType;
            NumColors = numColors;
            NumItems = numItems;
            HasLogo = hasLogo;
            Text = text;
            Calc();
        }

        public LogoOrderItem(string text, bool hasLogo)
            : this(-1, "mug", 0, 0, hasLogo, text)
        {
        }

        public LogoOrderItem()
            : this(-1, "mug", 0, 0, false, string.Empty)
        {
        }

        // Calculate total price based on requirements
        private void Calc()
        {
            decimal baseCost = itemType switch
            {
                "pen" => 1.00m,
                "mug" => 3.50m,
                "usb" => 4.00m,
                _ => 0.00m
            };

            decimal logoCost = hasLogo ? 0.10m : 0.00m;
            decimal textCost = !string.IsNullOrEmpty(text) ? 0.05m : 0.00m;
            decimal colorCost = hasLogo ? 0.03m * numColors : 0.00m;

            TotalPrice = numItems * (baseCost + logoCost + textCost + colorCost);
        }

        // Generate order summary
        public string GetOrderSummary()
        {
            return $"Order num {ItemID}: {numItems} {itemType}s with {numColors} color logo with the following text: {text}. Price: {TotalPrice:C}";
        }
    }
}
