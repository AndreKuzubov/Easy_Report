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
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // timePicker
            // 
            this.timePicker.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.timePicker.Checked = false;
            this.timePicker.Cursor = System.Windows.Forms.Cursors.Default;
            this.timePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.timePicker.Location = new System.Drawing.Point(186, 32);
            this.timePicker.Name = "timePicker";
            this.timePicker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timePicker.ShowCheckBox = true;
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(157, 20);
            this.timePicker.TabIndex = 5;
            this.timePicker.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "mm";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(3, 32);
            this.datePicker.Name = "datePicker";
            this.datePicker.ShowCheckBox = true;
            this.datePicker.ShowUpDown = true;
            this.datePicker.Size = new System.Drawing.Size(177, 20);
            this.datePicker.TabIndex = 4;
            this.datePicker.Value = new System.DateTime(2016, 6, 25, 15, 43, 38, 0);
            this.datePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // QuestionDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.datePicker);
            this.Name = "QuestionDate";
            this.Size = new System.Drawing.Size(348, 69);
            this.Controls.SetChildIndex(this.labelAuthor, 0);
            this.Controls.SetChildIndex(this.datePicker, 0);
            this.Controls.SetChildIndex(this.timePicker, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.DateTimePicker timePicker;
    }
}
