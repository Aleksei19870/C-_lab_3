using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    public class Logic // класс где будем хранить логику
    {
        public static string Compare(int с_1, string tc_1, int c_2, string tc_2)
        {
            
            return "a";
        }

        public static int GetAverage(int ivanovSum, int petrovSum)
        {
            var averageSum = (petrovSum + ivanovSum) / 2;
            return averageSum;
        }
    }

    
        public class Temperature
        {
            private double celsius;

            public Temperature(double value, string scale)
            {
                switch (scale.ToLower())
                {
                    case "c":
                        this.celsius = value;
                        break;
                    case "f":
                        this.celsius = (value - 32) * 5 / 9;
                        break;
                    case "r":
                        this.celsius = (value - 491.67) * 5 / 9;
                        break;
                    case "k":
                        this.celsius = value - 273.15;
                        break;
                    default:
                        throw new ArgumentException("Invalid temperature scale.");
                }
            }

            public static Temperature operator +(Temperature t1, Temperature t2)
            {
                return new Temperature(t1.celsius + t2.celsius, "c");
            }

            public static Temperature operator -(Temperature t1, Temperature t2)
            {
                return new Temperature(t1.celsius - t2.celsius, "c");
            }

            public static Temperature operator *(Temperature t1, Temperature t2)
            {
                return new Temperature(t1.celsius * t2.celsius, "c");
            }

            public static Temperature operator /(Temperature t1, Temperature t2)
            {
                if (t2.celsius == 0)
                {
                    throw new DivideByZeroException("Error: Division by zero!");
                }
                return new Temperature(t1.celsius / t2.celsius, "c");
            }

            public override string ToString()
            {
                return celsius + "°C";
            }
        }
    
}
