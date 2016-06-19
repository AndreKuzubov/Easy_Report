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
            this.components = new System.ComponentModel.Container();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
          /*  this.dBGaiSignsDataSet = new WFormsAppWordExport.DBGaiSignsDataSet();
            this.знакиПриоритетаBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.знаки_приоритетаTableAdapter = new WFormsAppWordExport.DBGaiSignsDataSetTableAdapters.Знаки_приоритетаTableAdapter();
            this.запрещающие_знакиTableAdapter1 = new WFormsAppWordExport.DBGaiSignsDataSetTableAdapters.Запрещающие_знакиTableAdapter();
            this.предупреждающие_знакиTableAdapter1 = new WFormsAppWordExport.DBGaiSignsDataSetTableAdapters.Предупреждающие_знакиTableAdapter();
            this.dBGaiMarksDataSet = new WFormsAppWordExport.DBGaiMarksDataSet();
            this.дорожнаяРазметкаBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.дорожная_разметкаTableAdapter = new WFormsAppWordExport.DBGaiMarksDataSetTableAdapters.Дорожная_разметкаTableAdapter();
*/            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
         /*   ((System.ComponentModel.ISupportInitialize)(this.dBGaiSignsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.знакиПриоритетаBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBGaiMarksDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.дорожнаяРазметкаBindingSource)).BeginInit();
           */ this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOk.Location = new System.Drawing.Point(12, 486);
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
            this.btCancel.Location = new System.Drawing.Point(688, 486);
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
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 42);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(751, 438);
            this.splitContainer1.SplitterDistance = 245;
            this.splitContainer1.TabIndex = 4;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(4, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(238, 434);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(494, 431);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // dBGaiSignsDataSet
            // 
      /*      this.dBGaiSignsDataSet.DataSetName = "DBGaiSignsDataSet";
            this.dBGaiSignsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // знакиПриоритетаBindingSource
            // 
            this.знакиПриоритетаBindingSource.DataMember = "Знаки приоритета";
            this.знакиПриоритетаBindingSource.DataSource = this.dBGaiSignsDataSet;
            // 
            // знаки_приоритетаTableAdapter
            // 
            this.знаки_приоритетаTableAdapter.ClearBeforeFill = true;
            // 
            // запрещающие_знакиTableAdapter1
            // 
            this.запрещающие_знакиTableAdapter1.ClearBeforeFill = true;
            // 
            // предупреждающие_знакиTableAdapter1
            // 
            this.предупреждающие_знакиTableAdapter1.ClearBeforeFill = true;
            // 
            // dBGaiMarksDataSet
            // 
            this.dBGaiMarksDataSet.DataSetName = "DBGaiMarksDataSet";
            this.dBGaiMarksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // дорожнаяРазметкаBindingSource
            // 
            this.дорожнаяРазметкаBindingSource.DataMember = "Дорожная разметка";
            this.дорожнаяРазметкаBindingSource.DataSource = this.dBGaiMarksDataSet;
            // 
            // дорожная_разметкаTableAdapter
            // 
            this.дорожная_разметкаTableAdapter.ClearBeforeFill = true;
        */    // 
            // FormPictureMultiChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 521);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Name = "FormPictureMultiChoose";
            this.Text = "Выберите несколко";
            this.Load += new System.EventHandler(this.PictureMultiChoose_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
       /*     ((System.ComponentModel.ISupportInitialize)(this.dBGaiSignsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.знакиПриоритетаBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBGaiMarksDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.дорожнаяРазметкаBindingSource)).EndInit();
         */   this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
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