namespace WFormsAppWordExport.Forms
{
    partial class FormNewEssence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewEssence));
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.Название = new System.Windows.Forms.Label();
            this.textBoxNameEssence = new System.Windows.Forms.TextBox();
            this.comboBoxImagesObjects = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOk.Location = new System.Drawing.Point(12, 106);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 0;
            this.btOk.Text = "Сохранить";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.Location = new System.Drawing.Point(247, 106);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // Название
            // 
            this.Название.AutoSize = true;
            this.Название.Location = new System.Drawing.Point(12, 15);
            this.Название.Name = "Название";
            this.Название.Size = new System.Drawing.Size(57, 13);
            this.Название.TabIndex = 2;
            this.Название.Text = "Название";
            // 
            // textBoxNameEssence
            // 
            this.textBoxNameEssence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNameEssence.Location = new System.Drawing.Point(106, 12);
            this.textBoxNameEssence.Name = "textBoxNameEssence";
            this.textBoxNameEssence.Size = new System.Drawing.Size(216, 20);
            this.textBoxNameEssence.TabIndex = 3;
            // 
            // comboBoxImagesObjects
            // 
            this.comboBoxImagesObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxImagesObjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxImagesObjects.FormattingEnabled = true;
            this.comboBoxImagesObjects.Location = new System.Drawing.Point(106, 38);
            this.comboBoxImagesObjects.Name = "comboBoxImagesObjects";
            this.comboBoxImagesObjects.Size = new System.Drawing.Size(216, 21);
            this.comboBoxImagesObjects.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Прообраз";
            // 
            // FormNewEssence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 141);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxImagesObjects);
            this.Controls.Add(this.textBoxNameEssence);
            this.Controls.Add(this.Название);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 180);
            this.Name = "FormNewEssence";
            this.Text = "Новый Элемент";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label Название;
        private System.Windows.Forms.TextBox textBoxNameEssence;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBoxImagesObjects;
    }
}