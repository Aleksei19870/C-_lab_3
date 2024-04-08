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
            double value1 = double.Parse(this.textBox1.Text);
            string scale1 = this.textBox2.Text;
            string scale2 = this.textBox2.Text;
            double value2 = double.Parse(this.textBox3.Text);

            Temperature temp1 = new Temperature(value1, scale1);
            Temperature temp2 = new Temperature(value2, scale2);

            Temperature resultSum = temp1 + temp2;
            MessageBox.Show("Сумма температур: " + resultSum);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double value1 = double.Parse(this.textBox1.Text);
            string scale1 = this.textBox2.Text;
            string scale2 = this.textBox2.Text;
            double value2 = double.Parse(this.textBox3.Text);

            Temperature temp1 = new Temperature(value1, scale1);
            Temperature temp2 = new Temperature(value2, scale2);

            Temperature resultSub = temp1 - temp2;
            MessageBox.Show("Разница температур: " + resultSub);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double value1 = double.Parse(this.textBox1.Text);
            string scale1 = this.textBox2.Text;
            string scale2 = this.textBox2.Text;
            double value2 = double.Parse(this.textBox3.Text);

            Temperature temp1 = new Temperature(value1, scale1);
            Temperature temp2 = new Temperature(value2, scale2);

            Temperature resultMul = temp1 * temp2;
            MessageBox.Show("Результат умножения температур: " + resultMul);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double value1 = double.Parse(this.textBox1.Text);
            string scale1 = this.textBox2.Text;
            string scale2 = this.textBox2.Text;
            double value2 = double.Parse(this.textBox3.Text);

            Temperature temp1 = new Temperature(value1, scale1);
            Temperature temp2 = new Temperature(value2, scale2);

            Temperature resultDiv = temp1 / temp2;
            MessageBox.Show("Результат деления температур: " + resultDiv);
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
