namespace WFormsAppWordExport
{
    partial class QuestionMultiChoose
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btExpose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAuthor
            // 
            this.labelAuthor.Location = new System.Drawing.Point(345, 198);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(3, 24);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(236, 169);
            this.checkedListBox1.TabIndex = 5;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemChecked);
            // 
            // btExpose
            // 
            this.btExpose.Location = new System.Drawing.Point(274, 170);
            this.btExpose.Name = "btExpose";
            this.btExpose.Size = new System.Drawing.Size(75, 23);
            this.btExpose.TabIndex = 6;
            this.btExpose.Text = "Раскрыть";
            this.btExpose.UseVisualStyleBackColor = true;
            this.btExpose.Click += new System.EventHandler(this.btExpose_Click);
            // 
            // QuestionMultiChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btExpose);
            this.Controls.Add(this.checkedListBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "QuestionMultiChoose";
            this.Size = new System.Drawing.Size(352, 211);
            this.Controls.SetChildIndex(this.labelAuthor, 0);
            this.Controls.SetChildIndex(this.checkedListBox1, 0);
            this.Controls.SetChildIndex(this.btExpose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btExpose;
    }
}
