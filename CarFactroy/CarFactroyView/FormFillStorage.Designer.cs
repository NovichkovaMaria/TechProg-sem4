namespace CarFactoryView
{
    partial class FormFillStorage
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelAutoPart = new System.Windows.Forms.Label();
            this.labelStorage = new System.Windows.Forms.Label();
            this.comboBoxAutoPart = new System.Windows.Forms.ComboBox();
            this.comboBoxStorage = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(171, 121);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(102, 25);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(45, 121);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(102, 25);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(11, 80);
            this.labelCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(66, 13);
            this.labelCount.TabIndex = 10;
            this.labelCount.Text = "Количество";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(132, 73);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(141, 20);
            this.textBoxCount.TabIndex = 9;
            // 
            // labelAutoPart
            // 
            this.labelAutoPart.AutoSize = true;
            this.labelAutoPart.Location = new System.Drawing.Point(11, 40);
            this.labelAutoPart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAutoPart.Name = "labelAutoPart";
            this.labelAutoPart.Size = new System.Drawing.Size(49, 13);
            this.labelAutoPart.TabIndex = 7;
            this.labelAutoPart.Text = "Часть";
            // 
            // labelStorage
            // 
            this.labelStorage.AutoSize = true;
            this.labelStorage.Location = new System.Drawing.Point(11, 6);
            this.labelStorage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStorage.Name = "labelStorage";
            this.labelStorage.Size = new System.Drawing.Size(38, 13);
            this.labelStorage.TabIndex = 8;
            this.labelStorage.Text = "Склад";
            // 
            // comboBoxAutoPart
            // 
            this.comboBoxAutoPart.FormattingEnabled = true;
            this.comboBoxAutoPart.Location = new System.Drawing.Point(132, 40);
            this.comboBoxAutoPart.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxAutoPart.Name = "comboBoxAutoPart";
            this.comboBoxAutoPart.Size = new System.Drawing.Size(141, 21);
            this.comboBoxAutoPart.TabIndex = 5;
            // 
            // comboBoxStorage
            // 
            this.comboBoxStorage.FormattingEnabled = true;
            this.comboBoxStorage.Location = new System.Drawing.Point(132, 6);
            this.comboBoxStorage.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxStorage.Name = "comboBoxStorage";
            this.comboBoxStorage.Size = new System.Drawing.Size(141, 21);
            this.comboBoxStorage.TabIndex = 6;
            // 
            // FormFillStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 193);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelAutoPart);
            this.Controls.Add(this.labelStorage);
            this.Controls.Add(this.comboBoxAutoPart);
            this.Controls.Add(this.comboBoxStorage);
            this.Name = "FormFillStorage";
            this.Text = "Заполнение склада";
            this.Load += new System.EventHandler(this.FormFillStorage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelAutoPart;
        private System.Windows.Forms.Label labelStorage;
        private System.Windows.Forms.ComboBox comboBoxAutoPart;
        private System.Windows.Forms.ComboBox comboBoxStorage;
    }
}