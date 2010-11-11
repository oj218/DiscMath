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
        #region Calculations of the extended algorithm of euclides
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

                    lblInvers.Text = "The multiplicative inverse is = " + B2;
                }catch(Exception ex){
                    lblInvers.Text = "The multiplicative inverse doesn't exist";
                }
            }
        #endregion


        #region Input validation
                private void checkInput(Object sender)
                {
                    TextBox txt = sender as TextBox;
                    int num;

                    if (int.TryParse(txt.Text, out num) || txt.Text == "")
                    {
                        txt.BackColor = Color.White;
                        if (txt.Text == "")
                        {
                            btnCalculate.Enabled = false;
                        }
                    }
                    else{
                        txt.BackColor = Color.Salmon;
                        btnCalculate.Enabled = false;
                    }

                    if (txtFirst.Text != "" && txtSecond.Text != "" && int.TryParse(txtFirst.Text, out num) && int.TryParse(txtSecond.Text, out num))
                    {
                        btnCalculate.Enabled = true;
                    }

                }
                private void txtFirst_TextChanged(object sender, EventArgs e)
                {
                    checkInput(sender);
                }

                private void txtSecond_TextChanged_1(object sender, EventArgs e)
                {
                    checkInput(sender);
                }

                private void Form1_Load(object sender, EventArgs e)
                {
                    btnCalculate.Enabled = false;
                }
        #endregion
    }
}
