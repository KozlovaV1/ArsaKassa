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
    }
}
