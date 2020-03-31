using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Atol.Drivers10.Fptr;
using JR.Utils.GUI.Forms;

namespace ArsaKassa
{
    public partial class Form1 : Form
    {
        private string dbFileName;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;

        public int choiseMoney;
        public string sumRMKforPay;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDBNomenclature_Click(object sender, EventArgs e)
        {
            if (!File.Exists(dbFileName))
                SQLiteConnection.CreateFile(dbFileName);

            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + "; Version =3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;

                m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Nomenclature (id INTEGER PRIMARY KEY AUTOINCREMENT, sku INT, namenomenclature TEXT, price DOUBLE, barcode BIGINT)";
                m_sqlCmd.ExecuteNonQuery();

                toolStripStatusLabelDB.Text = "Подключено к БД";
            }
            catch (SQLiteException ex)
            {
                toolStripStatusLabelDB.Text = "Нет подключения к БД";
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //textBoxScaner.Focus();
            textBoxScaner.Select();
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();

            dbFileName = "DBAraKassa.sqlite";
            toolStripStatusLabelDB.Text = "Нет подключения к БД";

            connectDB();

            //Устанавливаем путь до базы обмена
            String path = @"C:\base.txt";
            //textBoxPathBaseTxt.Text = path;
            // textBoxScaner.SelectionStart;

        }

        public void connectDB()
        {
            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;

                toolStripStatusLabelDB.Text = "Подключено к БД";
            }
            catch (SQLiteException ex)
            {
                toolStripStatusLabelDB.Text = "Нет подключения к БД";
                MessageBox.Show("Ошибка " + ex.Message);
            }
        }

        private void buttonConnectedDB_Click(object sender, EventArgs e)
        {
            if (!File.Exists(dbFileName))
            {
                MessageBox.Show("Создайте базу.");
                return;
            }

            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;

                toolStripStatusLabelDB.Text = "Подключено к БД";
            }
            catch (SQLiteException ex)
            {
                toolStripStatusLabelDB.Text = "Нет подключения к БД";
                MessageBox.Show("Ошибка " + ex.Message);
            }
        }

        private void buttonReadAll_Click(object sender, EventArgs e)
        {
            DataTable dTable = new DataTable();
            String sqlQuery;

            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Установите соединение с базой");
                return;
            }
            try
            {
                sqlQuery = "SELECT * FROM Nomenclature";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dTable.Rows.Count; i++)
                        dataGridView1.Rows.Add(dTable.Rows[i].ItemArray);
                }
                else
                    MessageBox.Show("База пустая");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Подключитесь к БД");
            }

            AddDataToDb addData = new AddDataToDb();
            if (addData.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    m_sqlCmd.CommandText = "INSERT INTO Nomenclature ('sku', 'namenomenclature', 'price', 'barcode') values ('" +
                            addData.Sku + "' , '" + addData.Namenomenclature + "' , '" + addData.Price + "', '" + addData.Barcode + "')";

                    m_sqlCmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }

        }

        private void buttonDell_Click(object sender, EventArgs e)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Подключитесь к БД");
                return;

            }

            try
            {
                m_sqlCmd.CommandText = "DELETE FROM Nomenclature";
                m_sqlCmd.ExecuteNonQuery();
                dataGridView1.Rows.Clear();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Подключитесь к БД");
            }

            try
            {
                //Удаляем по индексу
                int indexDel = dataGridView1.CurrentRow.Index;
                DataGridViewRow row = dataGridView1.Rows[indexDel];
                int IndexCell = Convert.ToInt32(row.Cells[0].Value);
           
                //m_sqlCmd.CommandText = "DELETE FROM Catalog WHERE id = " + CellAuthor + " and book = " + CellBook;
                m_sqlCmd.CommandText = "DELETE FROM Nomenclature WHERE id = " + IndexCell;
                m_sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }

        }


        private void buttonAddRandom_Click(object sender, EventArgs e)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Подключитесь к БД");
            }

            //Создание объекта для генерации чисел
            Random rnd = new Random();
            //Получить очередное (в данном случае - первое) случайное число
            int value = rnd.Next(100, 100);
            toolStripProgressBarLOAD.Maximum = value;
            toolStripProgressBarLOAD.Value = 0;
            //Создаем еще поток и отображаем в прогрессбаре и добавляем много записей
            Thread t = new Thread(new ThreadStart(delegate
            {
                for (int i = 0; i < value; i++)
                {
                    this.Invoke(new ThreadStart(delegate
                    {
                        m_sqlCmd.CommandText = "INSERT INTO Nomenclature ('sku', 'namenomenclature', 'price', 'barcode') values " +
                                        "('" + value + "' , '" + value + "',  '" + value + "',  '" + 3760053114402 + "' )";
                        m_sqlCmd.ExecuteNonQuery();
                        toolStripProgressBarLOAD.Value++;

                    }));
                }
            }));
            t.Start();
            //MessageBox.Show("Загружено " + value);

        }

        private void buttonAddBarcode_Click(object sender, EventArgs e)
        {   //добавляем номеклатуру в рмк - типо через сканер поиском по штрихкоду
            DataTable dTable = new DataTable();
            String sqlQuery;

            List<long> bar = new List<long> { 4602193010734, 6933412700036 };
            int countrow = 0;
            foreach (long i in bar)
            {
                try
                {
                    //sqlQuery = "SELECT * FROM Nomenclature WHERE barcode = '4602193010734'";
                    sqlQuery = "SELECT * FROM Nomenclature WHERE barcode = " + i;
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                    adapter.Fill(dTable);
                    //Поиск вхождения SKU в РМК, если есть то добавляем позицию
                    foreach (DataGridViewRow row in dataGridViewRMK.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            int indexSKU = 1;
                            if (cell.Value?.ToString() == dTable.Rows[countrow].ItemArray.GetValue(indexSKU).ToString())
                            {
                                int indexPriceFOR = 3;
                                object pricedTableFOR = dTable.Rows[countrow].ItemArray.GetValue(indexPriceFOR);// Цена номенклатуры
                                int indexPriceIntFOR = Convert.ToInt32(pricedTableFOR);
                                int scoredTableFOR = Convert.ToInt32(row.Cells[5].Value);
                                int indexRowFOR = dataGridViewRMK.Rows.Count - 1; //Получаем индекс строки // тут ошибка при сложении
                                dataGridViewRMK[5, indexRowFOR].Value = scoredTableFOR + 1;    //куда нужно вставить количество и сумма 
                                dataGridViewRMK[6, indexRowFOR].Value = indexPriceIntFOR * Convert.ToInt32(dataGridViewRMK[5, indexRowFOR].Value);    // 6 - сумма, 5 количество 
                                sumALL(false);
                                //return;
                            }
                        }
                    }
                    //тут он не находит по ску и переходит сюда и дублирует строки
                    //Первая продажа, еще не нашли СКУ и поэтому добавляем 1шт
                    dataGridViewRMK.Rows.Add(dTable.Rows[countrow].ItemArray);
                    int indexPrice = 3;
                    object pricedTable = dTable.Rows[0].ItemArray.GetValue(indexPrice);// Цена номенклатуры
                    int indexPriceInt = Convert.ToInt32(pricedTable);
                    int scoredTable = 1;
                    int indexRow = dataGridViewRMK.Rows.Count - 1; //Получаем индекс строки
                    dataGridViewRMK[5, indexRow].Value = scoredTable;    //куда нужно вставить количество и сумма
                    dataGridViewRMK[6, indexRow].Value = indexPriceInt * scoredTable;    // 6 - сумма, 5 количество 
                                                                                         // sumALL(false);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: Штрихкод не найден! " + ex.Message);
                }
                countrow = countrow + 1;
            }


        }

        public void sumALL(bool clearSumAll) //Пересчитываем общию сумму внизу РМК
        {
            if (clearSumAll == true)
            {
                textBoxSumRMK.Text = "0";
            }
            else
            {
                int sumall = 0;
                foreach (DataGridViewRow row in dataGridViewRMK.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        sumall += Convert.ToInt32(row.Cells[6]?.Value);
                        break;
                    }
                }
                textBoxSumRMK.Text = sumall.ToString();
                textBoxScaner.Text = "";
            }

        }

        private void dataGridViewRMK_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {   //Выделяем ячейку и правой кнопкой
            if (e.ColumnIndex < dataGridViewRMK.ColumnCount && e.RowIndex < dataGridViewRMK.RowCount && e.Button == MouseButtons.Right)
            {
                try
                {
                    dataGridViewRMK.CurrentCell = dataGridViewRMK.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dataGridViewRMK.Columns[dataGridViewRMK.Columns.Count - 1].HeaderCell.ContextMenuStrip = contextMenuStripDelPositionRMK;
                }
                catch
                {
                    MessageBox.Show("Выберите ячейку, перед удалением");
                }

            }
        }

        private void ToolStripMenuItemDelPosition_Click(object sender, EventArgs e)//удаляем выделеную строку ячейку в рмк
        {
            try
            {
                foreach (DataGridViewCell cell in dataGridViewRMK.SelectedCells)
                {
                    dataGridViewRMK.Rows.RemoveAt(cell.RowIndex);
                }
            }
            catch
            {
                MessageBox.Show("Вы не выбрали строку для удаления", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void buttonSales_Click(object sender, EventArgs e) //Делаем продажу и записываем в базу ее
        {
            sumRMKforPay = textBoxSumRMK.Text;
            //Проверка, если рмк пуст то не вызываем окно оплаты и оплата № 3 - т.е отмена
            if (dataGridViewRMK.Rows.Count == 0) 
            {
                return;
            }
           
            //Проверка, если рмк пуст то не вызываем окно оплаты

            //Вызываем окно оплаты
            Payment f = new Payment();
            f.Owner = this;
            f.ShowDialog();
            //Вызываем окно оплаты

            if (choiseMoney == 3)
            {
                return;
            }

            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Подключитесь к БД");
            }
            try
            {
                //Продажа по ККМ АТОЛ
                //Инициализация  драйвера
                IFptr fptr = new Fptr();
                //Инициализация  драйвера

                //Настройки для кассы подключение
                fptr.setSingleSetting(Constants.LIBFPTR_SETTING_MODEL, Constants.LIBFPTR_MODEL_ATOL_AUTO.ToString());
                fptr.setSingleSetting(Constants.LIBFPTR_SETTING_PORT, Constants.LIBFPTR_PORT_COM.ToString());
                fptr.setSingleSetting(Constants.LIBFPTR_SETTING_COM_FILE, "COM7");
                fptr.setSingleSetting(Constants.LIBFPTR_SETTING_BAUDRATE, Constants.LIBFPTR_PORT_BR_115200.ToString());
                fptr.applySingleSettings();
                //Настройки для кассы подключение

                //Проверка на подключение кассы
                fptr.setParam(Constants.LIBFPTR_PARAM_DATA_TYPE, Constants.LIBFPTR_DT_STATUS);
                fptr.queryData();
                fptr.open();
                bool isOpened = fptr.isOpened();
                //Проверка на подключение кассы

                //открывает чек и кассира
                fptr.setParam(1021, "Кассир Иванов И.");
                fptr.setParam(1203, "123456789047");
                fptr.operatorLogin();

                fptr.setParam(Constants.LIBFPTR_PARAM_RECEIPT_TYPE, Constants.LIBFPTR_RT_SELL);
                fptr.openReceipt();
                //открывает чек и кассира

                double sumRMKforKKM = 0;
                foreach (DataGridViewRow item in dataGridViewRMK.Rows)
                { //получаем данные из строчки и записываем в таблицу продажи sales

                    int SKU = Convert.ToInt32(item.Cells[1].Value);
                    
                    int shiftnumber = 1; //номер смены
                    DateTime shiftdate = new DateTime(); // время продажи
                    shiftdate = DateTime.Now;
                    String nomenclature = item.Cells[2].Value?.ToString();
                    int price = Convert.ToInt32(item.Cells[3].Value);
                    double barcode = Convert.ToDouble(item.Cells[4].Value);
                    int count = Convert.ToInt32(item.Cells[5].Value);
                    int sum = Convert.ToInt32(item.Cells[6].Value);

                    sumRMKforKKM += sum;

                    m_sqlCmd.CommandText = "INSERT INTO sales ('sku', 'shiftnumber', 'shiftdate', 'nomenclature','price', 'barcode', 'count', 'sum') " +
                         "values ('" + SKU + "' , '" + shiftnumber + "' , '" + shiftdate + "', '" + nomenclature + "', '" + price + "', '" + barcode + "', '" + count + "', '" + sum + "')";
                    m_sqlCmd.ExecuteNonQuery();

                    //Тело чека
                    fptr.setParam(Constants.LIBFPTR_PARAM_COMMODITY_NAME, nomenclature);
                    fptr.setParam(Constants.LIBFPTR_PARAM_PRICE, price);
                    fptr.setParam(Constants.LIBFPTR_PARAM_QUANTITY, count);
                    fptr.setParam(Constants.LIBFPTR_PARAM_TAX_TYPE, Constants.LIBFPTR_TAX_NO);
                    fptr.registration();
                    //Тело чека

                }
                //Выбираем нал или безнал
                if (choiseMoney == 1)
                {
                    //MessageBox.Show("Наличка");
                    fptr.setParam(Constants.LIBFPTR_PARAM_PAYMENT_TYPE, Constants.LIBFPTR_PT_CASH);
                }
                else
                {
                    //MessageBox.Show("Безнал");
                    fptr.setParam(Constants.LIBFPTR_PARAM_PAYMENT_TYPE, Constants.LIBFPTR_PT_ELECTRONICALLY);
                }
                //Выбираем нал или безнал

                //Оплата чека
                //fptr.setParam(Constants.LIBFPTR_PARAM_PAYMENT_TYPE, Constants.LIBFPTR_PT_CASH);
                fptr.setParam(Constants.LIBFPTR_PARAM_PAYMENT_SUM, sumRMKforKKM);
                fptr.payment();
                //Оплата чека   

                //Полная оплата чека
                fptr.closeReceipt();
                //Полная оплата чека

                //Нефискальный чек - реклама
                fptr.beginNonfiscalDocument();
                fptr.setParam(Constants.LIBFPTR_PARAM_TEXT, "МОЯ РЕКЛАМА ШАПКА");
                fptr.setParam(Constants.LIBFPTR_PARAM_ALIGNMENT, Constants.LIBFPTR_ALIGNMENT_RIGHT);
                fptr.setParam(Constants.LIBFPTR_PARAM_FONT, 2);
                fptr.setParam(Constants.LIBFPTR_PARAM_FONT_DOUBLE_WIDTH, true);
                fptr.setParam(Constants.LIBFPTR_PARAM_FONT_DOUBLE_HEIGHT, true);
                fptr.printText();
                fptr.setParam(Constants.LIBFPTR_PARAM_PRINT_FOOTER, false);
                fptr.endNonfiscalDocument();
                //Нефискальный чек - реклама

                fptr.close();
                // fptr.continuePrint(); // допечатать документ
                dataGridViewRMK.Rows.Clear();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            textBoxScaner.Select();
            textBoxScaner.Text = "";
        }

        private void buttonAddFromTxt_Click(object sender, EventArgs e)
        {
            //string path1 = textBoxPathBaseTxt.Text;
            //int countMy = 0;
            //using (StreamReader sr = new StreamReader(path1, System.Text.Encoding.Default))
            //{
            //    string line;

            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        countMy += 1;
            //        string[] mass = line.Split(';');
            //        try
            //        {
            //            m_sqlCmd.CommandText = "INSERT INTO Nomenclature ('sku', 'namenomenclature', 'price', 'barcode') values ('" +
            //                    mass[0] + "' , '" + mass[1] + "' , '" + mass[2] + "', '" + mass[3] + "')";
            //            m_sqlCmd.ExecuteNonQuery();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Ошибка: Разбора файла " + ex.Message);
            //        }
            //    }
            //}
            //MessageBox.Show(countMy + " ШТ Записали в базу из " + path1);
        }

        private void textBoxScaner_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //добавляем номеклатуру в рмк - типо через сканер поиском по штрихкоду
                DataTable dTable = new DataTable();
                String sqlQuery;
                try
                {
                    string barcode = textBoxScaner.Text.ToString(); ;
                    sqlQuery = "SELECT * FROM Nomenclature WHERE barcode =  '" + barcode + "'";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                    adapter.Fill(dTable);
                    //Поиск вхождения SKU в РМК, если есть то добавляем позицию
                    foreach (DataGridViewRow row in dataGridViewRMK.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            int indexSKU = 1;
                            string sku = dTable.Rows[0].ItemArray.GetValue(indexSKU).ToString();
                            if (cell.Value?.ToString() == sku)
                            {
                                int indexPriceFOR = 3;
                                object pricedTableFOR = dTable.Rows[0].ItemArray.GetValue(indexPriceFOR);// Цена номенклатуры
                                int indexPriceIntFOR = Convert.ToInt32(pricedTableFOR);
                                int scoredTableFOR = Convert.ToInt32(row.Cells[5].Value);
                                //int indexRowFOR = dataGridViewRMK.Rows.Count - 1; //Получаем индекс строки
                                int indexRowFOR = dataGridViewRMK.Rows.IndexOf(row);
                                dataGridViewRMK[5, indexRowFOR].Value = scoredTableFOR + 1;    //куда нужно вставить количество и сумма
                                dataGridViewRMK[6, indexRowFOR].Value = indexPriceIntFOR * Convert.ToInt32(dataGridViewRMK[5, indexRowFOR].Value);    // 6 - сумма, 5 количество 
                                sumALL(false);
                                return; //Вовзращаем чтобы не было дубля
                            }
                        }

                    }
                    //Первая продажа, еще не нашли СКУ и поэтому добавляем 1шт
                    dataGridViewRMK.Rows.Add(dTable.Rows[0].ItemArray);
                    int indexPrice = 3;
                    object pricedTable = dTable.Rows[0].ItemArray.GetValue(indexPrice);// Цена номенклатуры
                    int indexPriceInt = Convert.ToInt32(pricedTable);
                    int scoredTable = 1;
                    int indexRow = dataGridViewRMK.Rows.Count - 1; //Получаем индекс строки
                    dataGridViewRMK[5, indexRow].Value = scoredTable;    //куда нужно вставить количество и сумма
                    dataGridViewRMK[6, indexRow].Value = indexPriceInt * scoredTable;    // 6 - сумма, 5 количество 
                    sumALL(false);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: Штрихкод не найден! " + ex.Message);
                    textBoxScaner.Text = "";
                }
            }
            textBoxScaner.Focus();
        }



        private void dataGridViewRMK_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //При изменени количества меняется сумма в строчке

            int priceRMK = Convert.ToInt32(dataGridViewRMK[3, e.RowIndex].Value);
            int countRMK = Convert.ToInt32(dataGridViewRMK[5, e.RowIndex].Value);
            dataGridViewRMK[6, e.RowIndex].Value = priceRMK * countRMK;
        }

        private void textBoxScaner_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            Settings formSetting = new Settings();
            formSetting.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

        }
        public static object atolConnect()
        {
            //Инициализация  драйвера
            IFptr fptr = new Fptr();
            //Инициализация  драйвера

            //Настройки для кассы подключение
            fptr.setSingleSetting(Constants.LIBFPTR_SETTING_MODEL, Constants.LIBFPTR_MODEL_ATOL_AUTO.ToString());
            fptr.setSingleSetting(Constants.LIBFPTR_SETTING_PORT, Constants.LIBFPTR_PORT_COM.ToString());
            fptr.setSingleSetting(Constants.LIBFPTR_SETTING_COM_FILE, "COM7");
            fptr.setSingleSetting(Constants.LIBFPTR_SETTING_BAUDRATE, Constants.LIBFPTR_PORT_BR_115200.ToString());
            fptr.applySingleSettings();
            //Настройки для кассы подключение

            //Проверка на подключение кассы
            fptr.setParam(Constants.LIBFPTR_PARAM_DATA_TYPE, Constants.LIBFPTR_DT_STATUS);
            fptr.queryData();
            fptr.open();
            bool isOpened = fptr.isOpened();
            //Проверка на подключение кассы
            return fptr;
        }

       

        private void button1_Click_2(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            // payment.DGVRMK = this.dataGridViewRMK;
            payment.ShowDialog();
        }

        private void buttonNom1_Click(object sender, EventArgs e)
        {
            textBoxScaner.Text = textBoxScaner.Text + "1";
        }

        private void buttonDelSku1_Click(object sender, EventArgs e)
        {
            textBoxScaner.Text = "";
        }

        private void buttonNom2_Click(object sender, EventArgs e)
        {
            textBoxScaner.Text = textBoxScaner.Text + "2";
        }

        private void buttonNom3_Click(object sender, EventArgs e)
        {
            textBoxScaner.Text = textBoxScaner.Text + "3";
        }

        private void buttonNom4_Click(object sender, EventArgs e)
        {
            textBoxScaner.Text = textBoxScaner.Text + "4";
        }

        private void buttonNom5_Click(object sender, EventArgs e)
        {
            textBoxScaner.Text = textBoxScaner.Text + "5";
        }

        private void buttonNom6_Click(object sender, EventArgs e)
        {
            textBoxScaner.Text = textBoxScaner.Text + "6";
        }

        private void buttonNom7_Click(object sender, EventArgs e)
        {
            textBoxScaner.Text = textBoxScaner.Text + "7";
        }

        private void buttonNom8_Click(object sender, EventArgs e)
        {
            textBoxScaner.Text = textBoxScaner.Text + "8";
        }

        private void buttonNom9_Click(object sender, EventArgs e)
        {
            textBoxScaner.Text = textBoxScaner.Text + "9";
        }

        private void buttonNom0_Click(object sender, EventArgs e)
        {
            textBoxScaner.Text = textBoxScaner.Text + "0";
        }

        private void buttonNomPoint_Click(object sender, EventArgs e)
        {
            textBoxScaner.Text = textBoxScaner.Text + ".";
        }

        private void buttonNomZero2_Click(object sender, EventArgs e)
        {
            textBoxScaner.Text = textBoxScaner.Text + "00";
        }

        private void buttonCancelRMK_Click(object sender, EventArgs e)
        {
            if (dataGridViewRMK.Rows.Count == 0)
            {
                return;
            }

            FlexibleMessageBox.FONT = new Font("Impact", 25, FontStyle.Regular);
            DialogResult result = FlexibleMessageBox.Show("Отменить чек?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dataGridViewRMK.Rows.Clear();
            }
            else
            {

            }


        }

        
    }
}
