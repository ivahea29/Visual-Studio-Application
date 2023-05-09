using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAppGuiTask
{
        class Cows : livestock
     {
        public double amtMilk;
        public bool yesNo;
        public Cows(int id, double amtWater, double dailyCost, double weight, int age, string colour, double amtMilk, bool yesNo) : base(id, amtWater, dailyCost, weight, age, colour)
        {
            this.amtMilk = amtMilk;
            this.yesNo = yesNo;
        }
        override public string typeAnimal()
        {
            return ("cow");
        }
        override public string getInfo()
        {
            string infoCow = "Cow" + ", " + id.ToString() + ", " + amtWater.ToString() + ", " + dailyCost.ToString() + ", " + weight.ToString() + ", " + age.ToString() + ", " + colour.ToString() + ", " + amtMilk.ToString();
            return (infoCow);
        }
        override public double getProf()
        {
            double cowProf = (amtMilk * Prices.CowsMilkPrice) - (amtWater * Prices.WaterPrice) - (weight * Prices.Tax) - dailyCost;
            return (cowProf);
        }
        override public double findTaxPaid()
        {
            double cowTax = (weight * Prices.Tax);
            return (cowTax);
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
