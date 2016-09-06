namespace WFormsAppWordExport
{
    partial class FormPictureMultiChoose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPictureMultiChoose));
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOk.Location = new System.Drawing.Point(12, 459);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "сохранить";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.Location = new System.Drawing.Point(547, 459);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(12, 12);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(132, 23);
            this.btReset.TabIndex = 3;
            this.btReset.Text = "Сбросить выделенное";
            this.btReset.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 45);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(610, 404);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // FormPictureMultiChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 494);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPictureMultiChoose";
            this.Text = "Выберите несколько";
            this.Load += new System.EventHandler(this.PictureMultiChoose_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        /*  private DBGaiSignsDataSet dBGaiSignsDataSet;
private System.Windows.Forms.BindingSource знакиПриоритетаBindingSource;
private DBGaiSignsDataSetTableAdapters.Знаки_приоритетаTableAdapter знаки_приоритетаTableAdapter;
private DBGaiSignsDataSetTableAdapters.Запрещающие_знакиTableAdapter запрещающие_знакиTableAdapter1;
private DBGaiSignsDataSetTableAdapters.Предупреждающие_знакиTableAdapter предупреждающие_знакиTableAdapter1;
private DBGaiMarksDataSet dBGaiMarksDataSet;
private System.Windows.Forms.BindingSource дорожнаяРазметкаBindingSource;
private DBGaiMarksDataSetTableAdapters.Дорожная_разметкаTableAdapter дорожная_разметкаTableAdapter;*/
    }
}