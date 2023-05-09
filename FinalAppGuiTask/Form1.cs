using System.Windows.Forms;
using System;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalAppGuiTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Dictionary<int, FinalAppGuiTask.livestock> getDict() // creating dictionary and objects for each table in the database
        {
            Dictionary<int, livestock> myFarm = new Dictionary<int, livestock>();
            // Source of database
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; 
                                                        Data Source=C:\Users\GGPC\Desktop\FInalAppGui\FinalAppGui\farmdatabase.accdb");

            // Cow objects
            String query = $"select * from Cows"; // query for Gui to collect data
            OleDbDataAdapter myCmd = new OleDbDataAdapter(query, conn);
            conn.Open(); // opening connection
            DataSet dtSet = new DataSet();
            myCmd.Fill(dtSet, "Cows");
            DataTable dt = dtSet.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = Convert.ToInt32(dt.Rows[i][0]);
                double amtWater = Convert.ToDouble(dt.Rows[i][1]);
                double dailyCost = Convert.ToDouble(dt.Rows[i][2]);
                double weight = Convert.ToDouble(dt.Rows[i][3]);
                int age = Convert.ToInt32(dt.Rows[i][4]);
                string? colour = Convert.ToString(dt.Rows[i][5]);
                double amtMilk = Convert.ToDouble(dt.Rows[i][6]);
                bool yesNo = Convert.ToBoolean(dt.Rows[i][7]);
                if (yesNo == true)
                { // Creating if/else statement for jerseycow since it shares keys, values with cow
                    livestock q = new JerseyCow(id, amtWater, dailyCost, weight, age, colour, amtMilk, yesNo);
                    myFarm.Add(id, q);
                    continue;
                }
                else
                {
                    livestock q = new Cows(id, amtWater, dailyCost, weight, age, colour, amtMilk, yesNo);
                    myFarm.Add(id, q);
                }
            }
            conn.Close(); // closing connection
            
            // Dog objects
            query = $"select * from Dogs";
            myCmd = new OleDbDataAdapter(query, conn);
            conn.Open();
            dtSet = new DataSet();
            myCmd.Fill(dtSet, "Dogs");
            dt = dtSet.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = Convert.ToInt32(dt.Rows[i][0]);
                double amtWater = Convert.ToDouble(dt.Rows[i][1]);
                double dailyCost = Convert.ToDouble(dt.Rows[i][2]);
                double weight = Convert.ToDouble(dt.Rows[i][3]);
                int age = Convert.ToInt32(dt.Rows[i][4]);
                string? colour = Convert.ToString(dt.Rows[i][5]);
                livestock q = new Dogs(id, amtWater, dailyCost, weight, age, colour);
                myFarm.Add(id, q);
            }
            conn.Close();
            
            // Sheep objects
            query = $"select * from Sheep";
            myCmd = new OleDbDataAdapter(query, conn);
            conn.Open();
            dtSet = new DataSet();
            myCmd.Fill(dtSet, "Sheep");
            dt = dtSet.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = Convert.ToInt32(dt.Rows[i][0]);
                double amtWater = Convert.ToDouble(dt.Rows[i][1]);
                double dailyCost = Convert.ToDouble(dt.Rows[i][2]);
                double weight = Convert.ToDouble(dt.Rows[i][3]);
                int age = Convert.ToInt32(dt.Rows[i][4]);
                string? colour = Convert.ToString(dt.Rows[i][5]);
                double amtWool = Convert.ToDouble(dt.Rows[i][6]);
                livestock q = new Sheep(id, amtWater, dailyCost, weight, age, colour, amtWool);
                myFarm.Add(id, q);
            }
            conn.Close();
            
            // Prices objects
            query = $"select * from Prices";
            myCmd = new OleDbDataAdapter(query, conn);
            conn.Open();
            dtSet = new DataSet();
            myCmd.Fill(dtSet, "Prices");
            dt = dtSet.Tables[0];
            Prices.CowsMilkPrice = Convert.ToDouble(dt.Rows[1][1]);
            Prices.GoatsMilkPrice = Convert.ToDouble(dt.Rows[0][1]);
            Prices.SheepWoolPrice = Convert.ToDouble(dt.Rows[1][1]);
            Prices.WaterPrice = Convert.ToDouble(dt.Rows[1][1]);
            Prices.Tax = Convert.ToDouble(dt.Rows[1][1]);
            Prices.JerseyTax = Convert.ToDouble(dt.Rows[1][1]);
            conn.Close();
            return myFarm;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Report one: Enter Id, Show Info
            var myFarm = getDict(); // referencing dictionary myFarm
            int inputId = int.Parse(textBox1.Text); // grabbing input from textBox
            if (myFarm.ContainsKey(inputId)) // if textbox input is inputId
            {
                var lines = myFarm[inputId].getInfo();
                textBox2.Text = String.Join(Environment.NewLine, lines); // print input user Id
            }

            // Report two: Total Profibility
            double totalProf = 0.0;
            foreach (KeyValuePair<int, livestock> elem in myFarm)
            {
                totalProf += elem.Value.getProf();
            }
            string getTotalProf = totalProf.ToString();
            textBox3.Text = Convert.ToString(getTotalProf);

            // Report three: tax per month
            double totaltax = 0.0;
            foreach (KeyValuePair<int, livestock> elem in myFarm)
            {
                if (elem.Value.typeAnimal() != "Dog")
                    totaltax += elem.Value.findTaxPaid();
            }
            double totaltaxpermonth = totaltax * 28;
            string findTaxPaid = totaltaxpermonth.ToString();
            textBox4.Text = Convert.ToString(findTaxPaid);

            // Report four: total milk per day
            double totalMilkDay = 0.0;
            foreach (KeyValuePair<int, livestock> elem in myFarm)
            {
                totalMilkDay += elem.Value.milkPerDay();
            }
            string milkPerDay = totalMilkDay.ToString();
            textBox5.Text = Convert.ToString(milkPerDay);

            // Report five: display the average age of all farm animals(Excluding dogs)
            double avgAge = 0.0;
            double totalAge = 0.0;
            foreach (KeyValuePair<int, livestock> elem in myFarm)
            {
                if (elem.Value.typeAnimal() != "Dog")
                {
                    totalAge++;
                    avgAge += elem.Value.getAge();
                }
            }
            avgAge = avgAge / totalAge;
            string formataverageage = avgAge.ToString();
            textBox6.Text = Convert.ToString(formataverageage);

            // Report 6: Display the average profitability of “Goats and Cow” Vs. Sheep
            double goatCowCount = 0.0;
            double sheepCount = 0.0;
            double goatCowTotalProf = 0.0;
            double sheepTotalProf = 0.0;
            foreach (KeyValuePair<int, livestock> elem in myFarm)
            {
                if (elem.Value.typeAnimal() == "Sheep")
                {
                    sheepCount++;
                    sheepTotalProf += elem.Value.getProf();
                }
                else if (elem.Value.typeAnimal() == "Cow" || elem.Value.typeAnimal() == "Goat" || elem.Value.typeAnimal() == "JerseyCow")
                {
                    goatCowCount++;
                    goatCowTotalProf += elem.Value.getProf();
                }
            }
            double goatCowAvgProf = goatCowTotalProf / goatCowCount;
            double sheepAvgProf = sheepTotalProf / sheepCount;
            string formatgoatCowAvg = goatCowAvgProf.ToString();
            string formatsheepAvg = sheepAvgProf.ToString();
            textBox7.Text = "$" + Convert.ToString(formatgoatCowAvg);
            textBox8.Text = "$" + Convert.ToString(formatsheepAvg);

            // Report 7: Display the ratio of Dogs’ cost compared to the total cost
            double totalcost = 0.0;
            double dogcost = 0.0;
            foreach (KeyValuePair<int, livestock> elem in myFarm)
            {
                totalcost += elem.Value.getCost();
                if (elem.Value.typeAnimal() == "Dog")
                {
                    dogcost += elem.Value.getCost();
                }
            }
            string formattotalcost = totalcost.ToString("");
            string formatdogcost = dogcost.ToString("");
            textBox9.Text = "$" + Convert.ToString(formattotalcost);
            textBox10.Text = "$" + Convert.ToString(formatdogcost);

            // Report 8:Generate a file that contains the ID of all animal ordered by their profitability(You are not allowed to use built -in sorting algorithm – Your code must do the sorting). Dogs are excluded.
            Dictionary<int, double> profDict = new Dictionary<int, double>();
            //create list to hold profitability values
            List<double> profList = new List<double>();
            foreach (KeyValuePair<int, livestock> elem in myFarm)
            {
                if (elem.Value.typeAnimal() != "Dog")
                {
                    profDict.Add(elem.Key, elem.Value.getProf());
                    profList.Add(elem.Value.getProf());
                }
            }
            //convert list to array to sort using iterative algorithm
            double[] arr = profList.ToArray();
            double temp;
            //traverse 0 to array length
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    //compare array element with all next elements
                    if (arr[i] < arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            using StreamWriter file = new("C:\\Users\\GGPC\\Desktop\\FInalAppGui\\FinalAppGuiTask\\ReportFileTxt");
            foreach (double line in arr)
            {
                foreach (KeyValuePair<int, double> elem in profDict)
                {
                    if (elem.Value == line)
                    {
                        file.WriteLine(elem.Key);
                    }
                }
            }
            // Report 9: Display the ratio of livestock with the color red
            int redcount = 0;
            int count = 0;
            foreach (KeyValuePair<int, livestock> elem in myFarm)
            {
                if (elem.Value.getColour() == "red")
                {
                    count++;
                    redcount++;
                }
                else
                {
                    count++;
                }
            }
            textBox12.Text = Convert.ToString(redcount);
            textBox11.Text = Convert.ToString(count);

            // Report 10: Display the total tax paid for Jersey Cows
            double jerseytax = 0.0;
            foreach (KeyValuePair<int, livestock> elem in myFarm)
            {
                if (elem.Value.typeAnimal() == "JerseyCow")
                {
                    jerseytax += elem.Value.findTaxPaid();
                }
            }
            string fjerseytax = jerseytax.ToString("");
            textBox13.Text = "$" + Convert.ToString(fjerseytax);

            // Report 12: Display the total profitability of all Jersey Cows.
            double totaljerseyprof = 0.0;
            foreach (KeyValuePair<int, livestock> elem in myFarm)
            {
                if (elem.Value.typeAnimal() == "JerseyCow")
                {
                    totaljerseyprof += elem.Value.getProf();
                }
            }
            string fjerseyprof = totaljerseyprof.ToString("F");
            textBox14.Text = "$" + Convert.ToString(fjerseyprof);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // report 11: The user enter a threshold (number of years), and the program displays the ratio of the number of animal farm where the age is above this threshold.
            var myFarm = getDict();
            int inputage = int.Parse(textBox15.Text);
            int livestockcount = 0;
            foreach (KeyValuePair<int, livestock> elem in myFarm)
            {
                if (inputage < elem.Value.getAge())
                {
                    livestockcount++;
                }
            }
            textBox16.Text = Convert.ToString(livestockcount);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}


