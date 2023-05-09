using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAppGuiTask
{
    class Goats : livestock
    {
        public double amtMilk;
        public Goats(int id, double amtWater, double dailyCost, double weight, int age, string colour, double amtMilk) : base(id, amtWater, dailyCost, weight, age, colour)
        {
            this.amtMilk = amtMilk;
        }
        override public string typeAnimal()
        {
            return ("Goat");
        }
        override public string getInfo()
        {
            string infoGoats = "Goats" + ", " + id.ToString() + ", " + amtWater.ToString() + ", " + dailyCost.ToString() + ", " + weight.ToString() + ", " + age.ToString() + ", " + colour.ToString() + ", " + amtMilk.ToString();
            return (infoGoats);
        }
        override public double getProf()
        {
            double goatProf = (amtMilk * Prices.CowsMilkPrice) - (amtWater * Prices.WaterPrice) - dailyCost - (weight * Prices.Tax);
            return (goatProf);
        }
        override public double findTaxPaid()
        {
            double GoatTax = (weight * Prices.Tax);
            return (GoatTax);
        }
        override public double milkPerDay()
        {
            return amtMilk;
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

