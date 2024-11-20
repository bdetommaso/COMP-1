using System;

namespace SprocketOrderApp
{
    public abstract class Sprocket
    {
        // Properties
        public int ItemID { get; private set; }
        public int NumItems { get; set; }
        public int NumTeeth { get; set; }
        public decimal Price { get; private set; }

        // Constructor
        protected Sprocket(int itemID, int numItems, int numTeeth)
        {
            ItemID = itemID;
            NumItems = numItems;
            NumTeeth = numTeeth;
            Calculate();
        }

        // Parameterless constructor
        protected Sprocket() : this(-1, 0, 0) { }

        // Protected abstract Calculate method
        protected abstract void Calculate();

        // ToString method
        public override string ToString()
        {
            return $"Order num: {ItemID} Number: {NumItems} Teeth: {NumTeeth} Price: {Price:C}";
        }

        // Set the price from derived classes
        protected void SetPrice(decimal price)
        {
            Price = price;
        }
    }

    public class SteelSprocket : Sprocket
    {
        public SteelSprocket(int itemID, int numItems, int numTeeth) : base(itemID, numItems, numTeeth) { }
        public SteelSprocket() : base() { }

        protected override void Calculate()
        {
            SetPrice(NumItems * NumTeeth * 0.05m);
        }

        public override string ToString()
        {
            return base.ToString() + " Material: steel.";
        }
    }

    public class AluminumSprocket : Sprocket
    {
        public AluminumSprocket(int itemID, int numItems, int numTeeth) : base(itemID, numItems, numTeeth) { }
        public AluminumSprocket() : base() { }

        protected override void Calculate()
        {
            SetPrice(NumItems * NumTeeth * 0.04m);
        }

        public override string ToString()
        {
            return base.ToString() + " Material: aluminum.";
        }
    }

    public class PlasticSprocket : Sprocket
    {
        public PlasticSprocket(int itemID, int numItems, int numTeeth) : base(itemID, numItems, numTeeth) { }
        public PlasticSprocket() : base() { }

        protected override void Calculate()
        {
            SetPrice(NumItems * NumTeeth * 0.02m);
        }

        public override string ToString()
        {
            return base.ToString() + " Material: plastic.";
        }
    }
}
