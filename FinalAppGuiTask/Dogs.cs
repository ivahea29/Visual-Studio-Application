using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FinalAppGuiTask
{
    class Dogs : livestock
    {
        public Dogs(int id, double amtWater, double dailyCost, double weight, int age, string colour) : base(id, amtWater, dailyCost, weight, age, colour)
        {

        }
        override public string getInfo()
        {
            string infoDogs = "Dogs" + ", " + id.ToString() + ", " + amtWater.ToString() + ", " + dailyCost.ToString() + ", " + weight.ToString() + ", " + age.ToString() + ", " + colour.ToString();
            return (infoDogs);
        }
        override public double getProf()
        {
            double dogprof = 0 - (amtWater * Prices.WaterPrice) - dailyCost;
            return (dogprof);
        }
        override public double getCost()
        {
            double dogcost = (amtWater * Prices.WaterPrice) + dailyCost;
            return (dogcost);
        }
        override public string getColour()
        {
            return (colour);
        }
    }
}


