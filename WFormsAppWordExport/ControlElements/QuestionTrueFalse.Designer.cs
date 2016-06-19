namespace WFormsAppWordExport
{
    partial class QuestionTrueFalse
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
            this.labelAnswer = new System.Windows.Forms.Label();
            this.buttonTrue = new System.Windows.Forms.Button();
            this.buttonFalse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAnswer
            // 
            this.labelAnswer.AutoSize = true;
            this.labelAnswer.Location = new System.Drawing.Point(91, 2);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(0, 13);
            this.labelAnswer.TabIndex = 4;
            // 
            // buttonTrue
            // 
            this.buttonTrue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTrue.Location = new System.Drawing.Point(3, 32);
            this.buttonTrue.Name = "buttonTrue";
            this.buttonTrue.Size = new System.Drawing.Size(75, 23);
            this.buttonTrue.TabIndex = 5;
            this.buttonTrue.Text = "Да";
            this.buttonTrue.UseVisualStyleBackColor = true;
            this.buttonTrue.Click += new System.EventHandler(this.buttonTrue_Click);
            // 
            // buttonFalse
            // 
            this.buttonFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFalse.Location = new System.Drawing.Point(103, 32);
            this.buttonFalse.Name = "buttonFalse";
            this.buttonFalse.Size = new System.Drawing.Size(75, 23);
            this.buttonFalse.TabIndex = 6;
            this.buttonFalse.Text = "нет";
            this.buttonFalse.UseVisualStyleBackColor = true;
            this.buttonFalse.Click += new System.EventHandler(this.buttonFalse_Click);
            // 
            // TrueFalseQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.buttonFalse);
            this.Controls.Add(this.buttonTrue);
            this.Controls.Add(this.labelAnswer);
            this.Name = "TrueFalseQuestion";
            this.Controls.SetChildIndex(this.labelAuthor, 0);
            this.Controls.SetChildIndex(this.labelAnswer, 0);
            this.Controls.SetChildIndex(this.buttonTrue, 0);
            this.Controls.SetChildIndex(this.buttonFalse, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAnswer;
        private System.Windows.Forms.Button buttonTrue;
        private System.Windows.Forms.Button buttonFalse;
    }
}
