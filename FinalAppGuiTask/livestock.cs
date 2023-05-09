using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAppGuiTask
{
    public class livestock
    {
        public int id;
        public double amtWater;
        public double dailyCost;
        public double weight;
        public int age;
        public string colour;
        public livestock(int id, double amtWater, double dailyCost, double weight, int age, string colour) 
        {
            this.id = id;
            this.amtWater = amtWater;
            this.dailyCost = dailyCost;
            this.weight = weight;
            this.age = age;
            this.colour = colour;
        }
        virtual public string typeAnimal()
        {
            return null;
        }
        virtual public string getInfo()
        {
            return null;
        }
        virtual public double getProf()
        {
            return 0;
        }
        virtual public double findTaxPaid()
        {
            return 0;
        }
        virtual public double milkPerDay()
        {
            return 0;
        }
        virtual public double getAge()
        {
            return age;
        }
        virtual public double getCost()
        {
            return 0;
        }
        virtual public string getColour()
        {
            return null;
        }
    }
}
