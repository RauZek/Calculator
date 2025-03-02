using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApplication
{
    public partial class Form1 : Form
    {
        // Global Variables
        private string currentCalculation = "";
        private double baseNumber = 0;
        private bool isExponent = false;

        public Form1()
        {
            InitializeComponent();
        }

        // General Functions (/, *, +, -, .)
        private void button1_Click(object sender, EventArgs e)
        {
            currentCalculation += (sender as Button).Text;
            txtOutput.Text = currentCalculation;
        }

        // CE
        private void button14_Click(object sender, EventArgs e)
        {
            if (currentCalculation.Length > 0)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }
            txtOutput.Text = currentCalculation;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // =
        private void button20_Click(object sender, EventArgs e)
        {
            if (isExponent)
            {
                if (double.TryParse(currentCalculation, out double exponent))
                {
                    txtOutput.Text = Math.Pow(baseNumber, exponent).ToString();
                    currentCalculation = txtOutput.Text;
                    isExponent = false;
                }
                else
                {
                    txtOutput.Text = "Error";
                    currentCalculation = "";
                    isExponent = false;
                }
            }
            else
            {
                string formattedCalculation = currentCalculation.ToString();

                try
                {
                    txtOutput.Text = new DataTable().Compute(formattedCalculation, null).ToString();
                    currentCalculation = txtOutput.Text;
                }
                catch (Exception ex)
                {
                    txtOutput.Text = "Error";
                    currentCalculation = "";
                }
            }
        }

        // C
        private void button15_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "0";
            currentCalculation = "";
        }

        // x!
        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                int num = int.Parse(currentCalculation);

                // Factorial is undefined for negative numbers
                if (num < 0)
                {
                    txtOutput.Text = "Error";
                    return;
                }

                long factorial = 1;
                for (int i = 1; i <= num; i++)
                {
                    factorial *= i;
                }
                txtOutput.Text = factorial.ToString();
                currentCalculation = txtOutput.Text;
            }
            catch (Exception ex)
            {
                txtOutput.Text = "Error";
            }

        }

        // sin
        private void button26_Click(object sender, EventArgs e)
        {
            if (double.TryParse(currentCalculation, out double number))
            {
                txtOutput.Text = Math.Sin(number).ToString();
                currentCalculation = txtOutput.Text;
            }
            else
            {
                txtOutput.Text = "Error";
                currentCalculation = "";
            }
        }

        // π 
        private void button2_Click(object sender, EventArgs e)
        {
            txtOutput.Text = Math.PI.ToString();
            currentCalculation = txtOutput.Text;
        }

        // e 
        private void button21_Click(object sender, EventArgs e)
        {
            txtOutput.Text = Math.E.ToString();
            currentCalculation = txtOutput.Text;
        }

        // √x
        private void button23_Click(object sender, EventArgs e)
        {
            if (double.TryParse(currentCalculation, out double number))
            {
                // Square root is undefined for negative numbers
                if (number < 0)
                {
                    txtOutput.Text = "Error";  
                }
                else
                {
                    txtOutput.Text = Math.Sqrt(number).ToString();
                    currentCalculation = txtOutput.Text;
                }
            }
            else
            {
                txtOutput.Text = "Error";
                currentCalculation = "";
            }
        }

        // xʸ
        private void button24_Click(object sender, EventArgs e)
        {
            if (double.TryParse(currentCalculation, out baseNumber))
            {
                isExponent = true;
                currentCalculation = "";
                txtOutput.Text = "";
            }
            else
            {
                txtOutput.Text = "Error";
                currentCalculation = "";
            }
        }

        // ln
        private void button25_Click(object sender, EventArgs e)
        {
            if (double.TryParse(currentCalculation, out double number))
            {
                // Logarithm is undefined for non-positive numbers
                if (number <= 0)
                {
                    txtOutput.Text = "Error";
                }
                else
                {
                    txtOutput.Text = Math.Log(number).ToString();
                    currentCalculation = txtOutput.Text;
                }
            }
            else
            {
                txtOutput.Text = "Error";
                currentCalculation = "";
            }
        }

        // cos
        private void button27_Click(object sender, EventArgs e)
        {
            if (double.TryParse(currentCalculation, out double number))
            {
                txtOutput.Text = Math.Cos(number).ToString();
                currentCalculation = txtOutput.Text;
            }
            else
            {
                txtOutput.Text = "Error";
                currentCalculation = "";
            }
        }

        // tan
        private void button28_Click(object sender, EventArgs e)
        {
            if (double.TryParse(currentCalculation, out double number))
            {
                txtOutput.Text = Math.Tan(number).ToString();
                currentCalculation = txtOutput.Text;
            }
            else
            {
                txtOutput.Text = "Error";
                currentCalculation = "";
            }
        }

        // +/-
        private void button29_Click(object sender, EventArgs e)
        {
            if (double.TryParse(currentCalculation, out double number))
            {
                number = -number;
                txtOutput.Text = number.ToString();
                currentCalculation = txtOutput.Text;
            }
            else
            {
                txtOutput.Text = "Error";
                currentCalculation = "";
            }
        }
    }
}
