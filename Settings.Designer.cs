namespace ArsaKassa
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.buttonInfoKKM = new System.Windows.Forms.Button();
            this.buttonXreport = new System.Windows.Forms.Button();
            this.buttonSale = new System.Windows.Forms.Button();
            this.buttonCloseKKM = new System.Windows.Forms.Button();
            this.buttonAddFptr = new System.Windows.Forms.Button();
            this.panelAtolKKM = new System.Windows.Forms.Panel();
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelAtolKKM.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(46, 358);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(240, 43);
            this.button2.TabIndex = 11;
            this.button2.Text = "Диагностика ОФД";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonInfoKKM
            // 
            this.buttonInfoKKM.Location = new System.Drawing.Point(46, 289);
            this.buttonInfoKKM.Name = "buttonInfoKKM";
            this.buttonInfoKKM.Size = new System.Drawing.Size(240, 45);
            this.buttonInfoKKM.TabIndex = 10;
            this.buttonInfoKKM.Text = "Информация о ККМ";
            this.buttonInfoKKM.UseVisualStyleBackColor = true;
            this.buttonInfoKKM.Click += new System.EventHandler(this.buttonInfoKKM_Click);
            // 
            // buttonXreport
            // 
            this.buttonXreport.Location = new System.Drawing.Point(46, 227);
            this.buttonXreport.Name = "buttonXreport";
            this.buttonXreport.Size = new System.Drawing.Size(240, 39);
            this.buttonXreport.TabIndex = 9;
            this.buttonXreport.Text = "X-отчет";
            this.buttonXreport.UseVisualStyleBackColor = true;
            this.buttonXreport.Click += new System.EventHandler(this.buttonXreport_Click);
            // 
            // buttonSale
            // 
            this.buttonSale.Location = new System.Drawing.Point(42, 86);
            this.buttonSale.Name = "buttonSale";
            this.buttonSale.Size = new System.Drawing.Size(244, 46);
            this.buttonSale.TabIndex = 8;
            this.buttonSale.Text = "Продажа";
            this.buttonSale.UseVisualStyleBackColor = true;
            this.buttonSale.Click += new System.EventHandler(this.buttonSale_Click);
            // 
            // buttonCloseKKM
            // 
            this.buttonCloseKKM.Location = new System.Drawing.Point(46, 156);
            this.buttonCloseKKM.Name = "buttonCloseKKM";
            this.buttonCloseKKM.Size = new System.Drawing.Size(240, 39);
            this.buttonCloseKKM.TabIndex = 7;
            this.buttonCloseKKM.Text = "Закрыть смену";
            this.buttonCloseKKM.UseVisualStyleBackColor = true;
            this.buttonCloseKKM.Click += new System.EventHandler(this.buttonCloseKKM_Click);
            // 
            // buttonAddFptr
            // 
            this.buttonAddFptr.Location = new System.Drawing.Point(42, 23);
            this.buttonAddFptr.Name = "buttonAddFptr";
            this.buttonAddFptr.Size = new System.Drawing.Size(244, 41);
            this.buttonAddFptr.TabIndex = 6;
            this.buttonAddFptr.Text = "Подключить драйвер";
            this.buttonAddFptr.UseVisualStyleBackColor = true;
            this.buttonAddFptr.Click += new System.EventHandler(this.buttonAddFptr_Click);
            // 
            // panelAtolKKM
            // 
            this.panelAtolKKM.Controls.Add(this.buttonAddFptr);
            this.panelAtolKKM.Controls.Add(this.button2);
            this.panelAtolKKM.Controls.Add(this.buttonCloseKKM);
            this.panelAtolKKM.Controls.Add(this.buttonInfoKKM);
            this.panelAtolKKM.Controls.Add(this.buttonSale);
            this.panelAtolKKM.Controls.Add(this.buttonXreport);
            this.panelAtolKKM.Location = new System.Drawing.Point(24, 15);
            this.panelAtolKKM.Name = "panelAtolKKM";
            this.panelAtolKKM.Size = new System.Drawing.Size(332, 413);
            this.panelAtolKKM.TabIndex = 12;
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.tabPage1);
            this.tabControlSettings.Controls.Add(this.tabPage2);
            this.tabControlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSettings.Location = new System.Drawing.Point(0, 0);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(1321, 858);
            this.tabControlSettings.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1313, 823);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Основные";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelAtolKKM);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1313, 823);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Настройка Атол ККМ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 858);
            this.Controls.Add(this.tabControlSettings);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки программы";
            this.panelAtolKKM.ResumeLayout(false);
            this.tabControlSettings.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonInfoKKM;
        private System.Windows.Forms.Button buttonXreport;
        private System.Windows.Forms.Button buttonSale;
        private System.Windows.Forms.Button buttonCloseKKM;
        private System.Windows.Forms.Button buttonAddFptr;
        private System.Windows.Forms.Panel panelAtolKKM;
        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}