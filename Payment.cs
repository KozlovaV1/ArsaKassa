using Atol.Drivers10.Fptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArsaKassa
{
    public partial class Payment : Form
    {
        public int choiseMoney; // 1 - наличка, 2 - карта, 3 - отмена оплаты
        public Payment()
        {
            InitializeComponent();

        }


        private void buttonCashMoney_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                main.choiseMoney = 1;
                Close();
            }
        }

        private void buttonVirt_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                main.choiseMoney = 2;
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                main.choiseMoney = 3;
                Close();
                //проверка
            }

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            textBoxGetSum.Text = "0";
            textBoxChange.Text = "0";

            textBoxGetSum.Select();

            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                textBoxSumRMK.Text = main.sumRMKforPay;
                //Close();
            }
        }

        public void countCash()
        {
            if (textBoxGetSum.Text == null)
            {
                textBoxGetSum.Text = "0";
                int Change = Convert.ToInt32(textBoxGetSum.Text) - Convert.ToInt32(textBoxSumRMK.Text);
                textBoxChange.Text = Change.ToString();
            }
            else
            {
                
                int Change = Convert.ToInt32(textBoxGetSum.Text) - Convert.ToInt32(textBoxSumRMK.Text);
                textBoxChange.Text = Change.ToString();
            }
            
        }

        private void buttonNom1_Click(object sender, EventArgs e)
        {
            if (textBoxGetSum.Text == "0")
            {
                textBoxGetSum.Text = "";
            }
            textBoxGetSum.Text = textBoxGetSum.Text + "1";
            countCash();
        }

        private void textBoxGetSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                countCash();
            }
        }

        private void buttonDelOne_Click(object sender, EventArgs e)
        {
            //Устанавливаем 0, после удаления последнего символа
            if (textBoxGetSum.Text.Length > 0)
            {
                textBoxGetSum.Text = textBoxGetSum.Text.Remove(textBoxGetSum.Text.Length - 1);
               
                if (textBoxGetSum.Text == "")
                {
                    textBoxGetSum.Text = "0";
                    countCash();
                }
                countCash();
            }  
            //Устанавливаем 0, после удаления последнего символа
        }

        private void buttonNom2_Click(object sender, EventArgs e)
        {
            if (textBoxGetSum.Text == "0")
            {
                textBoxGetSum.Text = "";
            }
            textBoxGetSum.Text = textBoxGetSum.Text + "2";
            countCash();
        }

        private void buttonNom3_Click(object sender, EventArgs e)
        {
            if (textBoxGetSum.Text == "0")
            {
                textBoxGetSum.Text = "";
            }
            textBoxGetSum.Text = textBoxGetSum.Text + "3";
            countCash();
        }

        private void buttonNom4_Click(object sender, EventArgs e)
        {
            if (textBoxGetSum.Text == "0")
            {
                textBoxGetSum.Text = "";
            }
            textBoxGetSum.Text = textBoxGetSum.Text + "4";
            countCash();
        }

        private void buttonNom5_Click(object sender, EventArgs e)
        {
            if (textBoxGetSum.Text == "0")
            {
                textBoxGetSum.Text = "";
            }
            textBoxGetSum.Text = textBoxGetSum.Text + "5";
            countCash();
        }

        private void buttonNom6_Click(object sender, EventArgs e)
        {
            if (textBoxGetSum.Text == "0")
            {
                textBoxGetSum.Text = "";
            }
            textBoxGetSum.Text = textBoxGetSum.Text + "6";
            countCash();
        }

        private void buttonNom7_Click(object sender, EventArgs e)
        {
            if (textBoxGetSum.Text == "0")
            {
                textBoxGetSum.Text = "";
            }
            textBoxGetSum.Text = textBoxGetSum.Text + "7";
            countCash();
        }

        private void buttonNom8_Click(object sender, EventArgs e)
        {
            if (textBoxGetSum.Text == "0")
            {
                textBoxGetSum.Text = "";
            }
            textBoxGetSum.Text = textBoxGetSum.Text + "8";
            countCash();
        }

        private void buttonNom9_Click(object sender, EventArgs e)
        {
            if (textBoxGetSum.Text == "0")
            {
                textBoxGetSum.Text = "";
            }
            textBoxGetSum.Text = textBoxGetSum.Text + "9";
            countCash();
        }

        private void buttonNom0_Click(object sender, EventArgs e)
        {
            if (textBoxGetSum.Text == "0")
            {
                textBoxGetSum.Text = "";
            }
            textBoxGetSum.Text = textBoxGetSum.Text + "0";
            countCash();
        }

        private void buttonNomPoint_Click(object sender, EventArgs e)
        {
            if (textBoxGetSum.Text == "0")
            {
                textBoxGetSum.Text = "";
            }
            textBoxGetSum.Text = textBoxGetSum.Text + "1";
            countCash();
        }

        private void buttonNum00_Click(object sender, EventArgs e)
        {
            if (textBoxGetSum.Text == "0")
            {
                textBoxGetSum.Text = "";
            }
            textBoxGetSum.Text = textBoxGetSum.Text + "00";
            countCash();
        }
    }
   
}
