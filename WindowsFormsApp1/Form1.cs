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

        private MeasureType GetMeasureType(ComboBox comboBox)
        {
            MeasureType measureType;
            switch (comboBox.Text)
            {
                case "C":
                    measureType = MeasureType.C;
                    break;
                case "F":
                    measureType = MeasureType.F;
                    break;
                case "R":
                    measureType = MeasureType.R;
                    break;
                case "K":
                    measureType = MeasureType.K;
                    break;
                default:
                    measureType = MeasureType.C;
                    break;
            }
            return measureType;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double value1 = double.Parse(this.textBox1.Text);
            MeasureType scale1 = GetMeasureType(comboBox1);
            MeasureType scale2 = GetMeasureType(comboBox2);
            MeasureType scale3 = GetMeasureType(comboBox3);
            double value2 = double.Parse(this.textBox3.Text);

            Temperature temp1 = new Temperature(value1, scale1);
            Temperature temp2 = new Temperature(value2, scale2);
            Temperature resultSum = temp1 + temp2;
            resultSum = resultSum.To(scale3);
            string v = resultSum.Verbose();
            MessageBox.Show("Сумма температур: " + v);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double value1 = double.Parse(this.textBox1.Text);
            MeasureType scale1 = GetMeasureType(comboBox1);
            MeasureType scale2 = GetMeasureType(comboBox2);
            MeasureType scale3 = GetMeasureType(comboBox3);
            double value2 = double.Parse(this.textBox3.Text);

            Temperature temp1 = new Temperature(value1, scale1);
            Temperature temp2 = new Temperature(value2, scale2);       
            Temperature resultSub = temp1 - temp2;
            resultSub = resultSub.To(scale3);
            string v = resultSub.Verbose();
            MessageBox.Show("Разница температур: " + v);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double value1 = double.Parse(this.textBox1.Text);
            MeasureType scale1 = GetMeasureType(comboBox1);
            MeasureType scale2 = GetMeasureType(comboBox2);
            MeasureType scale3 = GetMeasureType(comboBox3);
            double value2 = double.Parse(this.textBox3.Text);

            Temperature temp1 = new Temperature(value1, scale1);
            Temperature temp2 = new Temperature(value2, scale2);
            Temperature resultMul = temp1 * temp2;
            resultMul = resultMul.To(scale3);
            string v = resultMul.Verbose();
            MessageBox.Show("Результат умножения температур: " + v );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double value1 = double.Parse(this.textBox1.Text);
            MeasureType scale1 = GetMeasureType(comboBox1);
            MeasureType scale2 = GetMeasureType(comboBox2);
            MeasureType scale3 = GetMeasureType(comboBox3);
            double value2 = double.Parse(this.textBox3.Text);

            Temperature temp1 = new Temperature(value1, scale1);
            Temperature temp2 = new Temperature(value2, scale2);

            Temperature resultDiv = temp1 / temp2;
            resultDiv = resultDiv.To(scale3);
            string v = resultDiv.Verbose();
            MessageBox.Show("Результат деления температур: " + v);

        }
    }   
}