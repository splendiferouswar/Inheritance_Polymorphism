using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Inheritance_Polymorphism
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();
        private void button2_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var list = new List<string>(); //creating empty list for storing all the lines

            string[] splitLines; //we are creating an array for storing all the split words

            double profitForFarm = 0.0; //variable that will be used to calculate profit later on

            Animal[] farmAnimals = new Animal[10]; //creating an empty array of size 10

            var fileStream = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read); //reading the txt file
            using (var streamReader = new StreamReader(fileStream))
            {
                string line;

                int counter = 0;

                /*storing user inputted data*/
                Costs.userInputCowVax = Convert.ToDouble(vaxCostCow.Text);
                Costs.userInputJerseyVax = Convert.ToDouble(vaxCostJersey.Text);
                Costs.userInputGoatVax = Convert.ToDouble(vaxCostGoat.Text);
                Costs.cowMilkPriceUserInput = Convert.ToDouble(cowMilkPrice.Text);
                Costs.goatMilkPriceUserInput = Convert.ToDouble(goatMilkPrice.Text);

                //while reading the lines
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line); //add the lines to the list

                    splitLines = line.Split(','); //also take the line and split it up and add it to an array

                    //take the first and second element and put them inside their respective variables
                    int animalId = Convert.ToInt32(splitLines[0]);
                    double animalMilkQty = Convert.ToDouble(splitLines[1]);
                    string animalType = splitLines[2];

                    if (splitLines[2] == "Cow") //if the 3rd element in the array is == cow
                    {
                        //initiating a new instance and passing all the user input variables and elements of the list as parameters for the constructor
                        Animal animal = new Cow(animalId, animalMilkQty, animalType);
                        farmAnimals[counter] = animal; //adding to an array called farmAnimals
                        counter++; //increasing the counter so that every new animal created does not overwrite previously existing animals in the farm animals array
                    }
                    else if (splitLines[2] == "JerseyCow")
                    {
                        Animal animal = new JerseyCow(animalId, animalMilkQty, animalType);
                        farmAnimals[counter] = animal;
                        counter++;
                    }
                    else if (splitLines[2] == "Goat")
                    {
                        Animal animal = new Goat(animalId, animalMilkQty, animalType);
                        farmAnimals[counter] = animal;
                        counter++;
                    }

                }
                //for each animal in farmAnimal array
                foreach (Animal i in farmAnimals)
                {   //run them throught the getprofit method, the get profit method returns a double, add it ti profitForFarm variable
                    profitForFarm += i.getProfit();
                }
            }
            //append the final profit to the text boxs
            profit.Text = Convert.ToString(profitForFarm);
        }
    }
}