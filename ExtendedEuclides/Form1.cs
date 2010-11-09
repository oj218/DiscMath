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
            int r = n%b ;

            try{
                int q = (n - r) / b;
                int tempA1 = A1;
                int tempA2 = A2;

                A1 = B1;
                A2 = B2;

                B1 = (tempA1 - q * B1);
                B2 = (tempA2 - q * B2);

                int A = b;
                int B = r;

                while ((n * B1) + (b * B2) != 1)
                {
                    r = A % B;
                    q = (A - r) / B;

                    tempA1 = A1;
                    tempA2 = A2;

                    A1 = B1;
                    A2 = B2;

                    B1 = (tempA1 - q * B1);
                    B2 = (tempA2 - q * B2);

                    A = n * A1 + b * A2;
                    B = n * B1 + b * B2;
                    
                }

                if (B2 < 0)
                    B2 += n;

                Console.WriteLine("inverse = " + B2);
                Console.WriteLine("rest = " + (n * B1 + b * B2));
            }catch(Exception ex){
                Console.WriteLine("Er is geen multiplicatief inverse");
            }
        }
    }
}
