namespace WFormsAppWordExport
{
    partial class QuestionDate
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.comboBoxFromat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "h:mm";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(3, 32);
            this.datePicker.Name = "datePicker";
            this.datePicker.ShowUpDown = true;
            this.datePicker.Size = new System.Drawing.Size(177, 20);
            this.datePicker.TabIndex = 4;
            this.datePicker.Value = new System.DateTime(2016, 6, 25, 15, 43, 38, 0);
            this.datePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.datePicker.Enter += new System.EventHandler(this.datePicker_Enter);
            // 
            // comboBoxFromat
            // 
            this.comboBoxFromat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFromat.FormattingEnabled = true;
            this.comboBoxFromat.Items.AddRange(new object[] {
            "год",
            "месяц/год",
            "месяц/год/день ",
            "год/месяц/день/время",
            "месяц/день/время",
            "время "});
            this.comboBoxFromat.Location = new System.Drawing.Point(186, 32);
            this.comboBoxFromat.Name = "comboBoxFromat";
            this.comboBoxFromat.Size = new System.Drawing.Size(159, 21);
            this.comboBoxFromat.TabIndex = 5;
            this.comboBoxFromat.SelectedIndexChanged += new System.EventHandler(this.comboBoxFromat_SelectedIndexChanged);
            // 
            // QuestionDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.comboBoxFromat);
            this.Controls.Add(this.datePicker);
            this.Name = "QuestionDate";
            this.Size = new System.Drawing.Size(348, 69);
            this.Controls.SetChildIndex(this.labelQuestion, 0);
            this.Controls.SetChildIndex(this.labelAuthor, 0);
            this.Controls.SetChildIndex(this.datePicker, 0);
            this.Controls.SetChildIndex(this.comboBoxFromat, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ComboBox comboBoxFromat;
    }
}
