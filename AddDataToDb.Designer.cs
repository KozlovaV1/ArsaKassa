namespace ArsaKassa
{
    partial class AddDataToDb
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
            this.textprice = new System.Windows.Forms.TextBox();
            this.textsku = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textnamenomenclature = new System.Windows.Forms.TextBox();
            this.textbarcode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textprice
            // 
            this.textprice.Location = new System.Drawing.Point(40, 165);
            this.textprice.Name = "textprice";
            this.textprice.Size = new System.Drawing.Size(211, 28);
            this.textprice.TabIndex = 0;
            // 
            // textsku
            // 
            this.textsku.Location = new System.Drawing.Point(40, 61);
            this.textsku.Name = "textsku";
            this.textsku.Size = new System.Drawing.Size(211, 28);
            this.textsku.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Добавить запись";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textnamenomenclature
            // 
            this.textnamenomenclature.Location = new System.Drawing.Point(40, 113);
            this.textnamenomenclature.Name = "textnamenomenclature";
            this.textnamenomenclature.Size = new System.Drawing.Size(211, 28);
            this.textnamenomenclature.TabIndex = 3;
            // 
            // textbarcode
            // 
            this.textbarcode.Location = new System.Drawing.Point(40, 212);
            this.textbarcode.Name = "textbarcode";
            this.textbarcode.Size = new System.Drawing.Size(211, 28);
            this.textbarcode.TabIndex = 4;
            // 
            // AddDataToDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 315);
            this.Controls.Add(this.textbarcode);
            this.Controls.Add(this.textnamenomenclature);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textsku);
            this.Controls.Add(this.textprice);
            this.Name = "AddDataToDb";
            this.Text = "AddDataToDb";
            this.Load += new System.EventHandler(this.AddDataToDb_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textprice;
        private System.Windows.Forms.TextBox textsku;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textnamenomenclature;
        private System.Windows.Forms.TextBox textbarcode;
    }
}