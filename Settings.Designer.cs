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
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(689, 585);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(240, 43);
            this.button2.TabIndex = 11;
            this.button2.Text = "Диагностика ОФД";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonInfoKKM
            // 
            this.buttonInfoKKM.Location = new System.Drawing.Point(689, 516);
            this.buttonInfoKKM.Name = "buttonInfoKKM";
            this.buttonInfoKKM.Size = new System.Drawing.Size(240, 45);
            this.buttonInfoKKM.TabIndex = 10;
            this.buttonInfoKKM.Text = "Информация о ККМ";
            this.buttonInfoKKM.UseVisualStyleBackColor = true;
            this.buttonInfoKKM.Click += new System.EventHandler(this.buttonInfoKKM_Click);
            // 
            // buttonXreport
            // 
            this.buttonXreport.Location = new System.Drawing.Point(689, 454);
            this.buttonXreport.Name = "buttonXreport";
            this.buttonXreport.Size = new System.Drawing.Size(240, 39);
            this.buttonXreport.TabIndex = 9;
            this.buttonXreport.Text = "X-отчет";
            this.buttonXreport.UseVisualStyleBackColor = true;
            this.buttonXreport.Click += new System.EventHandler(this.buttonXreport_Click);
            // 
            // buttonSale
            // 
            this.buttonSale.Location = new System.Drawing.Point(685, 313);
            this.buttonSale.Name = "buttonSale";
            this.buttonSale.Size = new System.Drawing.Size(244, 46);
            this.buttonSale.TabIndex = 8;
            this.buttonSale.Text = "Продажа";
            this.buttonSale.UseVisualStyleBackColor = true;
            this.buttonSale.Click += new System.EventHandler(this.buttonSale_Click);
            // 
            // buttonCloseKKM
            // 
            this.buttonCloseKKM.Location = new System.Drawing.Point(689, 383);
            this.buttonCloseKKM.Name = "buttonCloseKKM";
            this.buttonCloseKKM.Size = new System.Drawing.Size(240, 39);
            this.buttonCloseKKM.TabIndex = 7;
            this.buttonCloseKKM.Text = "Закрыть смену";
            this.buttonCloseKKM.UseVisualStyleBackColor = true;
            this.buttonCloseKKM.Click += new System.EventHandler(this.buttonCloseKKM_Click);
            // 
            // buttonAddFptr
            // 
            this.buttonAddFptr.Location = new System.Drawing.Point(685, 250);
            this.buttonAddFptr.Name = "buttonAddFptr";
            this.buttonAddFptr.Size = new System.Drawing.Size(244, 41);
            this.buttonAddFptr.TabIndex = 6;
            this.buttonAddFptr.Text = "Подключить драйвер";
            this.buttonAddFptr.UseVisualStyleBackColor = true;
            this.buttonAddFptr.Click += new System.EventHandler(this.buttonAddFptr_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1614, 879);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonInfoKKM);
            this.Controls.Add(this.buttonXreport);
            this.Controls.Add(this.buttonSale);
            this.Controls.Add(this.buttonCloseKKM);
            this.Controls.Add(this.buttonAddFptr);
            this.Name = "Settings";
            this.Text = "Настройки программы";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonInfoKKM;
        private System.Windows.Forms.Button buttonXreport;
        private System.Windows.Forms.Button buttonSale;
        private System.Windows.Forms.Button buttonCloseKKM;
        private System.Windows.Forms.Button buttonAddFptr;
    }
}