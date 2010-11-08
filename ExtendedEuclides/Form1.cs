using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExtendedEuclides
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            calculateExtendedEuclides(int.Parse(txtFirst.Text), int.Parse(txtSecond.Text));

        }

        private void calculateExtendedEuclides(int b, int n)
        {
            int A1 = 1;
            int A2 = 0;
            int B1 = 0;
            int B2 = 1;
            int q =0 ;
            int r =0 ;
            int tempB1 = 0;
            int tempB2 =0;

            while ((n * A1 + b * A2)!=1)
            {
                q = n / b;
                r = n % b;

                B1 = (A1 - q * B1);
                B2 = (A2 - q * B2);
                
                A1 = B1;
                A2 = B2;

                Console.WriteLine((n * A1 + b * A2));
            }

        }
    }
}
