namespace Inheritance_Polymorphism
{
    class Animal
    {
        //creating private fields 
        protected int id;
        protected double milkQty;
        protected string animalType;

        //creating their respective constructors
        public Animal(int id, double milkQty, string animalType)
        {
            this.id = id;
            this.milkQty = milkQty;
            this.animalType = animalType;

        }

        public virtual double getProfit() //virtual is used to allow this method to be used by child classes
        {
            return 0.0;
        }


    }
}
