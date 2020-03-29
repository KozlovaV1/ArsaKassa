using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArsaKassa
{
    public partial class  AddDataToDb : Form
    {
        public String Sku { get; set; }
        public String Namenomenclature { get; set; }
        public String Price { get; set; }
        public String Barcode { get; set; }
        public AddDataToDb()
        {
            InitializeComponent();
        }

        private void AddDataToDb_Load(object sender, EventArgs e)
        {
            Sku = "Sku";
            Namenomenclature = "Namenomenclature";
            Price = "Price";
            Barcode = "Barcode";

            textprice.Text = Sku;
            textsku.Text = Price;
            textnamenomenclature.Text = Namenomenclature;
            textbarcode.Text = Barcode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            //Создание объекта для генерации чисел
            Random rnd = new Random();

            //Получить очередное (в данном случае - первое) случайное число
            int value = rnd.Next(0,1000);

            Sku = textprice.Text + value;
            Price = textsku.Text + value;
            Namenomenclature = textnamenomenclature.Text + value;
            Barcode = textbarcode.Text + 4607031149539;


            DialogResult = DialogResult.OK;
        }
    }
}
