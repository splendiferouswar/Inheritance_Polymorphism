namespace Inheritance_Polymorphism
{
    class Goat : Animal
    {
        public Goat(int id, double milkQty, string animalType) : base(id, milkQty, animalType)
        {
        }

        public override double getProfit() //We need to override because we have a same name with parent class and the parent class method will be replaced with this
        {
            double getProfit = ((Costs.goatMilkPriceUserInput * milkQty) * 365) - (Costs.userInputGoatVax);
            return getProfit;
        }
    }
}
