using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAppGuiTask
{
    class Sheep : livestock
    {
        public double amtWool;
        public Sheep(int id, double amtWater, double dailyCost, double weight, int age, string colour, double amtWool) : base(id, amtWater, dailyCost, weight, age, colour)
        {
            this.amtWool = amtWool;
        }
        override public string typeAnimal()
        {
            return ("Sheep");
        }
        override public string getInfo()
        {
            string infoSheep = "Sheep" + ", " + id.ToString() + ", " + amtWater.ToString() + ", " + dailyCost.ToString() + ", " + weight.ToString() + ", " + age.ToString() + ", " + colour.ToString() + ", " + amtWool.ToString();
            return (infoSheep);
        }
        override public double getProf()
        {
            double sheepProf = (amtWool * Prices.SheepWoolPrice) - (amtWater * Prices.WaterPrice) - dailyCost - (weight * Prices.Tax);
            return (sheepProf);
        }
        override public double findTaxPaid()
        {
            double sheepTax = (weight * Prices.Tax);
            return (sheepTax);
        }
        public override double getAge()
        {
            return age;
        }
        override public string getColour()
        {
            return (colour);
        }
    }
}
