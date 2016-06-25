namespace WFormsAppWordExport
{
    partial class QuestionChoose
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btExpose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.comboBox1.Location = new System.Drawing.Point(4, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(260, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.MouseHover += new System.EventHandler(this.comboBox1_MouseHover);
            this.comboBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseMove);
            // 
            // btExpose
            // 
            this.btExpose.Enabled = false;
            this.btExpose.Location = new System.Drawing.Point(270, 30);
            this.btExpose.Name = "btExpose";
            this.btExpose.Size = new System.Drawing.Size(75, 23);
            this.btExpose.TabIndex = 5;
            this.btExpose.Text = "Раскрыть";
            this.btExpose.UseVisualStyleBackColor = true;
            this.btExpose.Click += new System.EventHandler(this.btExpose_Click);
            // 
            // QuestionChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CausesValidation = false;
            this.Controls.Add(this.btExpose);
            this.Controls.Add(this.comboBox1);
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Name = "QuestionChoose";
            this.Size = new System.Drawing.Size(348, 69);
            this.Controls.SetChildIndex(this.labelAuthor, 0);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.btExpose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btExpose;
    }
}
