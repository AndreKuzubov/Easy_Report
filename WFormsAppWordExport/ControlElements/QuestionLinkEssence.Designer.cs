namespace WFormsAppWordExport.ControlElements
{
    partial class QuestionLinkEssence
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
            this.comboBoxLinkEssences = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxLinkEssences
            // 
            this.comboBoxLinkEssences.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLinkEssences.FormattingEnabled = true;
            this.comboBoxLinkEssences.Location = new System.Drawing.Point(6, 32);
            this.comboBoxLinkEssences.Name = "comboBoxLinkEssences";
            this.comboBoxLinkEssences.Size = new System.Drawing.Size(339, 21);
            this.comboBoxLinkEssences.TabIndex = 5;
            this.comboBoxLinkEssences.DropDown += new System.EventHandler(this.comboBoxLinkEssences_DropDown);
            this.comboBoxLinkEssences.SelectedIndexChanged += new System.EventHandler(this.comboBoxLinkEssences_SelectedIndexChanged);
            // 
            // QuestionLinkEssence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.comboBoxLinkEssences);
            this.Name = "QuestionLinkEssence";
            this.Size = new System.Drawing.Size(348, 69);
            this.Controls.SetChildIndex(this.labelAuthor, 0);
            this.Controls.SetChildIndex(this.comboBoxLinkEssences, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxLinkEssences;
    }
}
