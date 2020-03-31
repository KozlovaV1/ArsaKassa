using Atol.Drivers10.Fptr;
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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void buttonAddFptr_Click(object sender, EventArgs e)
        {
            //Инициализация  драйвера
            IFptr fptr = new Fptr();
            String version = fptr.version();
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

            //Открытие смены обязательно вносим кассира
            fptr.setParam(1021, "Кассир Иванов И.");
            fptr.setParam(1203, "123456789047");
            fptr.operatorLogin();
            fptr.openShift(); //открытие смены
            fptr.checkDocumentClosed(); // проверка на успешность действия
            //Открытие смены обязательно вносим кассира
            fptr.close();

            ////Закрываем смену
            //fptr.setParam(1021, "Кассир Иванов И.");
            //fptr.setParam(1203, "123456789047");
            //fptr.operatorLogin();
            //fptr.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_CLOSE_SHIFT);
            //fptr.report();
            //fptr.checkDocumentClosed();
            ////Закрываем смену
        }

        private void buttonInfoKKM_Click(object sender, EventArgs e)
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

            fptr.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_KKT_INFO);
            fptr.report();
            fptr.close();
        }

        private void buttonXreport_Click(object sender, EventArgs e)
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

            //X-отчет
            fptr.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_X);
            fptr.report();
            //X-отчет
            fptr.close();
        }

        private void button2_Click(object sender, EventArgs e)
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
            fptr.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_OFD_TEST);
            fptr.report();
            fptr.close();
        }

        private void buttonCloseKKM_Click(object sender, EventArgs e)
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

            //Закрываем смену
            fptr.setParam(1021, "Кассир Иванов И.");
            fptr.setParam(1203, "123456789047");
            fptr.operatorLogin();
            fptr.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_CLOSE_SHIFT);
            fptr.report();
            fptr.checkDocumentClosed();
            //Закрываем смену
            fptr.close();
        }

        private void buttonSale_Click(object sender, EventArgs e)
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

            //открывает чек и кассира
            fptr.setParam(1021, "Кассир Иванов И.");
            fptr.setParam(1203, "123456789047");
            fptr.operatorLogin();

            fptr.setParam(Constants.LIBFPTR_PARAM_RECEIPT_TYPE, Constants.LIBFPTR_RT_SELL);
            fptr.openReceipt();
            //открывает чек и кассира

            //Тело чека
            fptr.setParam(Constants.LIBFPTR_PARAM_COMMODITY_NAME, "Товар");
            fptr.setParam(Constants.LIBFPTR_PARAM_PRICE, 100);
            fptr.setParam(Constants.LIBFPTR_PARAM_QUANTITY, 5.15);
            fptr.setParam(Constants.LIBFPTR_PARAM_TAX_TYPE, Constants.LIBFPTR_TAX_NO);
            fptr.registration();
            fptr.setParam(Constants.LIBFPTR_PARAM_COMMODITY_NAME, "ПИВО очень вкусное");
            fptr.setParam(Constants.LIBFPTR_PARAM_PRICE, 50);
            fptr.setParam(Constants.LIBFPTR_PARAM_QUANTITY, 1);
            fptr.setParam(Constants.LIBFPTR_PARAM_TAX_TYPE, Constants.LIBFPTR_TAX_NO);
            fptr.registration();
            fptr.setParam(Constants.LIBFPTR_PARAM_COMMODITY_NAME, "Товар2");
            fptr.setParam(Constants.LIBFPTR_PARAM_PRICE, 1000);
            fptr.setParam(Constants.LIBFPTR_PARAM_QUANTITY, 1);
            fptr.setParam(Constants.LIBFPTR_PARAM_TAX_TYPE, Constants.LIBFPTR_TAX_NO);
            fptr.registration();
            //Тело чека

            //Оплата чека
            fptr.setParam(Constants.LIBFPTR_PARAM_PAYMENT_TYPE, Constants.LIBFPTR_PT_CASH);
            fptr.setParam(Constants.LIBFPTR_PARAM_PAYMENT_SUM, 100.00);
            fptr.payment();
            //Оплата чека   

            //Полная оплата чека
            fptr.closeReceipt();
            //Полная оплата чека

            fptr.close();
            fptr.continuePrint(); // допечатать документ
        }
    }
}
