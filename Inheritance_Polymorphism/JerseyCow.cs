namespace Inheritance_Polymorphism
{
    class JerseyCow : Cow
    {
        //constructor are used to make new objects i.e new jerseycow
        public JerseyCow(int id, double milkQty, string animalType) : base(id, milkQty, animalType) //super
        {
        }

        public override double getProfit() //We need to override because we have a same name with parent class and the parent class method will be replaced with this
        {
            double getProfit = ((Costs.cowMilkPriceUserInput * milkQty) * 365) - (Costs.userInputJerseyVax);
            return getProfit;
        }
    }
}
