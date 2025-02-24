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
    public partial class Form1: Form
    {
        private string currentCalculation = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentCalculation += (sender as Button).Text;
            txtOutput.Text = currentCalculation;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if(currentCalculation.Length > 0) currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            txtOutput.Text = currentCalculation;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            string formattedCalculation = currentCalculation.ToString();

            // Error Handling
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

        private void button15_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "0";
            currentCalculation = "";    
        }
    }
}
