namespace WFormsAppWordExport.Forms
{
    partial class FormDevCode
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
            ExtendedRichTextBox.CharStyle charStyle1 = new ExtendedRichTextBox.CharStyle();
            ExtendedRichTextBox.ParaLineSpacing paraLineSpacing1 = new ExtendedRichTextBox.ParaLineSpacing();
            ExtendedRichTextBox.ParaListStyle paraListStyle1 = new ExtendedRichTextBox.ParaListStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDevCode));
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.btErase = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.extendedTextBoxResult = new ExtendedRichTextBox();
            this.richTextBoxCode = new System.Windows.Forms.RichTextBox();
            this.btHelp = new System.Windows.Forms.Button();
            this.btFunctions = new System.Windows.Forms.Button();
            this.btCompile = new System.Windows.Forms.Button();
            this.autocompleteMenuCode = new AutocompleteMenuNS.AutocompleteMenu();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.Location = new System.Drawing.Point(532, 426);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 0;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(451, 426);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "Сохранить";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btErase
            // 
            this.btErase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btErase.Location = new System.Drawing.Point(12, 426);
            this.btErase.Name = "btErase";
            this.btErase.Size = new System.Drawing.Size(105, 23);
            this.btErase.TabIndex = 2;
            this.btErase.Text = "Очистить";
            this.btErase.UseVisualStyleBackColor = true;
            this.btErase.Click += new System.EventHandler(this.btErase_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(636, 318);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(8, 8);
            this.progressBar1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.587156F));
            this.tableLayoutPanel1.Controls.Add(this.extendedTextBoxResult, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.richTextBoxCode, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.44968F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.55032F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(514, 408);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // extendedTextBoxResult
            // 
            this.extendedTextBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.autocompleteMenuCode.SetAutocompleteMenu(this.extendedTextBoxResult, null);
            this.extendedTextBoxResult.Location = new System.Drawing.Point(3, 290);
            this.extendedTextBoxResult.Name = "extendedTextBoxResult";
            this.extendedTextBoxResult.ReadOnly = true;
            charStyle1.Bold = false;
            charStyle1.Italic = false;
            charStyle1.Link = false;
            charStyle1.Strikeout = false;
            charStyle1.Underline = false;
            this.extendedTextBoxResult.SelectionCharStyle = charStyle1;
            this.extendedTextBoxResult.SelectionFont2 = new System.Drawing.Font("Microsoft Sans Serif", 2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Inch);
            paraLineSpacing1.ExactSpacing = 0;
            paraLineSpacing1.SpacingStyle = ExtendedRichTextBox.ParaLineSpacing.LineSpacingStyle.Unknown;
            this.extendedTextBoxResult.SelectionLineSpacing = paraLineSpacing1;
            paraListStyle1.BulletCharCode = ((short)(0));
            paraListStyle1.NumberingStart = ((short)(0));
            paraListStyle1.Style = ExtendedRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis;
            paraListStyle1.Type = ExtendedRichTextBox.ParaListStyle.ListType.None;
            this.extendedTextBoxResult.SelectionListType = paraListStyle1;
            this.extendedTextBoxResult.SelectionOffsetType = ExtendedRichTextBox.OffsetType.None;
            this.extendedTextBoxResult.SelectionSpaceAfter = 0;
            this.extendedTextBoxResult.SelectionSpaceBefore = 0;
            this.extendedTextBoxResult.Size = new System.Drawing.Size(508, 115);
            this.extendedTextBoxResult.TabIndex = 1;
            this.extendedTextBoxResult.Text = "";
            // 
            // richTextBoxCode
            // 
            this.richTextBoxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.autocompleteMenuCode.SetAutocompleteMenu(this.richTextBoxCode, this.autocompleteMenuCode);
            this.richTextBoxCode.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxCode.Name = "richTextBoxCode";
            this.richTextBoxCode.Size = new System.Drawing.Size(508, 281);
            this.richTextBoxCode.TabIndex = 8;
            this.richTextBoxCode.Text = "";
            // 
            // btHelp
            // 
            this.btHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btHelp.Location = new System.Drawing.Point(532, 15);
            this.btHelp.Name = "btHelp";
            this.btHelp.Size = new System.Drawing.Size(75, 23);
            this.btHelp.TabIndex = 5;
            this.btHelp.Text = "Че о чем";
            this.btHelp.UseVisualStyleBackColor = true;
            // 
            // btFunctions
            // 
            this.btFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFunctions.Location = new System.Drawing.Point(529, 44);
            this.btFunctions.Name = "btFunctions";
            this.btFunctions.Size = new System.Drawing.Size(75, 23);
            this.btFunctions.TabIndex = 6;
            this.btFunctions.Text = "Функции";
            this.btFunctions.UseVisualStyleBackColor = true;
            // 
            // btCompile
            // 
            this.btCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCompile.Location = new System.Drawing.Point(337, 426);
            this.btCompile.Name = "btCompile";
            this.btCompile.Size = new System.Drawing.Size(105, 23);
            this.btCompile.TabIndex = 7;
            this.btCompile.Text = "Компилировать ";
            this.btCompile.UseVisualStyleBackColor = true;
            this.btCompile.Click += new System.EventHandler(this.btCompile_Click);
            // 
            // autocompleteMenuCode
            // 
            this.autocompleteMenuCode.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("autocompleteMenuCode.Colors")));
            this.autocompleteMenuCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.autocompleteMenuCode.ImageList = null;
            this.autocompleteMenuCode.Items = new string[0];
            this.autocompleteMenuCode.TargetControlWrapper = null;
            this.autocompleteMenuCode.MenuShowing += new System.EventHandler<System.EventArgs>(this.autocompleteMenuCode_MenuShowing);
            // 
            // FormDevCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 461);
            this.Controls.Add(this.btCompile);
            this.Controls.Add(this.btFunctions);
            this.Controls.Add(this.btHelp);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btErase);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.btCancel);
            this.Name = "FormDevCode";
            this.Text = "FormDevCode";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btErase;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ExtendedRichTextBox extendedTextBoxResult;
        private System.Windows.Forms.Button btHelp;
        private System.Windows.Forms.Button btFunctions;
        private System.Windows.Forms.Button btCompile;
        public System.Windows.Forms.RichTextBox richTextBoxCode;
        private AutocompleteMenuNS.AutocompleteMenu autocompleteMenuCode;
    }
}