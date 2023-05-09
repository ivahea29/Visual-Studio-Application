using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAppGuiTask
{
    class JerseyCow : Cows
    {
        public JerseyCow(int id, double amtWater, double dailyCost, double weight, int age, string colour, double amtMilk, bool yesNo) : base(id, amtWater, dailyCost, weight, age, colour, amtMilk, yesNo)
        {
            this.amtMilk = amtMilk;
        }
        override public string typeAnimal()
        {
            return ("Jersey Cow");
        }
        override public string getInfo()
        {
            string infoJerseyCow = "Jersey Cow" + ", " + id.ToString() + ", " + amtWater.ToString() + ", " + dailyCost.ToString() + ", " + weight.ToString() + ", " + age.ToString() + ", " + colour.ToString() + ", " + amtMilk.ToString();
            return (infoJerseyCow);
        }
        override public double getProf()
        {
            double jerseyCowProf = 0 - (amtWater * Prices.WaterPrice) - dailyCost - (weight * Prices.Tax);
            return (jerseyCowProf);
        }
        override public double findTaxPaid()
        {
            double JerseyCowTax = (weight * Prices.Tax);
            return (JerseyCowTax);
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
        override public double getCost()
        {
            return 0;
        }

    }
}
