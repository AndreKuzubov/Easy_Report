namespace TextRuler.AdvancedTextEditorControl
{
    partial class AdvancedTextEditor
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

        #region Component Designer generated code

        //this.fontComboBox1 = new TextRuler.AdvancedTextEditorControl.FontComboBoxControl.FontComboBox();

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedTextEditor));
            ExtendedRichTextBox.CharStyle charStyle1 = new ExtendedRichTextBox.CharStyle();
            ExtendedRichTextBox.ParaLineSpacing paraLineSpacing1 = new ExtendedRichTextBox.ParaLineSpacing();
            ExtendedRichTextBox.ParaListStyle paraListStyle1 = new ExtendedRichTextBox.ParaListStyle();
            this.tlpEditorLayout = new System.Windows.Forms.TableLayoutPanel();
            this.Toolbox_Formatting = new System.Windows.Forms.ToolStrip();
            this.cmbFontName = new System.Windows.Forms.ToolStripComboBox();
            this.cmbFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.sepTBFormatting1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBold = new System.Windows.Forms.ToolStripButton();
            this.btnItalic = new System.Windows.Forms.ToolStripButton();
            this.btnUnderline = new System.Windows.Forms.ToolStripButton();
            this.btnStrikeThrough = new System.Windows.Forms.ToolStripButton();
            this.sepTBFormatting2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAlignLeft = new System.Windows.Forms.ToolStripButton();
            this.btnAlignCenter = new System.Windows.Forms.ToolStripButton();
            this.btnAlignRight = new System.Windows.Forms.ToolStripButton();
            this.btnJustify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNumberedList = new System.Windows.Forms.ToolStripButton();
            this.btnBulletedList = new System.Windows.Forms.ToolStripButton();
            this.TextEditor = new ExtendedRichTextBox();
            this.Ruler = new TextRuler.TextRulerControl.TextRuler();
            this.LineNumbers = new System.Windows.Forms.Label();
            this.prtDoc = new System.Drawing.Printing.PrintDocument();
            this.DocPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.PageSettings = new System.Windows.Forms.PageSetupDialog();
            this.PrintWnd = new System.Windows.Forms.PrintDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tlpEditorLayout.SuspendLayout();
            this.Toolbox_Formatting.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpEditorLayout
            // 
            this.tlpEditorLayout.ColumnCount = 2;
            this.tlpEditorLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpEditorLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEditorLayout.Controls.Add(this.Toolbox_Formatting, 0, 0);
            this.tlpEditorLayout.Controls.Add(this.TextEditor, 1, 2);
            this.tlpEditorLayout.Controls.Add(this.Ruler, 1, 1);
            this.tlpEditorLayout.Controls.Add(this.LineNumbers, 0, 2);
            this.tlpEditorLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEditorLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpEditorLayout.Name = "tlpEditorLayout";
            this.tlpEditorLayout.RowCount = 3;
            this.tlpEditorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpEditorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpEditorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEditorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEditorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEditorLayout.Size = new System.Drawing.Size(687, 502);
            this.tlpEditorLayout.TabIndex = 0;
            this.tlpEditorLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpEditorLayout_Paint);
            // 
            // Toolbox_Formatting
            // 
            this.Toolbox_Formatting.BackColor = System.Drawing.Color.Transparent;
            this.tlpEditorLayout.SetColumnSpan(this.Toolbox_Formatting, 2);
            this.Toolbox_Formatting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Toolbox_Formatting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbFontName,
            this.cmbFontSize,
            this.sepTBFormatting1,
            this.btnBold,
            this.btnItalic,
            this.btnUnderline,
            this.btnStrikeThrough,
            this.sepTBFormatting2,
            this.btnAlignLeft,
            this.btnAlignCenter,
            this.btnAlignRight,
            this.btnJustify,
            this.toolStripSeparator2,
            this.btnNumberedList,
            this.btnBulletedList});
            this.Toolbox_Formatting.Location = new System.Drawing.Point(0, 0);
            this.Toolbox_Formatting.Name = "Toolbox_Formatting";
            this.Toolbox_Formatting.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Toolbox_Formatting.Size = new System.Drawing.Size(687, 26);
            this.Toolbox_Formatting.TabIndex = 4;
            this.Toolbox_Formatting.Text = "toolStrip1";
            // 
            // cmbFontName
            // 
            this.cmbFontName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFontName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFontName.DropDownHeight = 300;
            this.cmbFontName.IntegralHeight = false;
            this.cmbFontName.Name = "cmbFontName";
            this.cmbFontName.Size = new System.Drawing.Size(170, 26);
            this.cmbFontName.SelectedIndexChanged += new System.EventHandler(this.cmbFontName_SelectedIndexChanged);
            this.cmbFontName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbFontName_KeyUp);
            // 
            // cmbFontSize
            // 
            this.cmbFontSize.AutoSize = false;
            this.cmbFontSize.DropDownHeight = 200;
            this.cmbFontSize.IntegralHeight = false;
            this.cmbFontSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "30",
            "36",
            "48",
            "60",
            "72",
            "85",
            "100"});
            this.cmbFontSize.MaxDropDownItems = 20;
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(50, 23);
            this.cmbFontSize.Text = "8";
            this.cmbFontSize.SelectedIndexChanged += new System.EventHandler(this.cmbFontSize_SelectedIndexChanged);
            this.cmbFontSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbFontSize_KeyDown);
            this.cmbFontSize.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbFontSize_KeyUp);
            // 
            // sepTBFormatting1
            // 
            this.sepTBFormatting1.Name = "sepTBFormatting1";
            this.sepTBFormatting1.Size = new System.Drawing.Size(6, 26);
            // 
            // btnBold
            // 
            this.btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBold.Image = ((System.Drawing.Image)(resources.GetObject("btnBold.Image")));
            this.btnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(23, 23);
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItalic.Image = ((System.Drawing.Image)(resources.GetObject("btnItalic.Image")));
            this.btnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(23, 23);
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnUnderline
            // 
            this.btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnderline.Image = ((System.Drawing.Image)(resources.GetObject("btnUnderline.Image")));
            this.btnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(23, 23);
            this.btnUnderline.Click += new System.EventHandler(this.btnUnderline_Click);
            // 
            // btnStrikeThrough
            // 
            this.btnStrikeThrough.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStrikeThrough.Image = ((System.Drawing.Image)(resources.GetObject("btnStrikeThrough.Image")));
            this.btnStrikeThrough.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStrikeThrough.Name = "btnStrikeThrough";
            this.btnStrikeThrough.Size = new System.Drawing.Size(23, 23);
            this.btnStrikeThrough.Click += new System.EventHandler(this.btnStrikeThrough_Click);
            // 
            // sepTBFormatting2
            // 
            this.sepTBFormatting2.Name = "sepTBFormatting2";
            this.sepTBFormatting2.Size = new System.Drawing.Size(6, 26);
            // 
            // btnAlignLeft
            // 
            this.btnAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignLeft.Image")));
            this.btnAlignLeft.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnAlignLeft.Name = "btnAlignLeft";
            this.btnAlignLeft.Size = new System.Drawing.Size(23, 23);
            this.btnAlignLeft.Click += new System.EventHandler(this.btnAlignLeft_Click);
            // 
            // btnAlignCenter
            // 
            this.btnAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignCenter.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignCenter.Image")));
            this.btnAlignCenter.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnAlignCenter.Name = "btnAlignCenter";
            this.btnAlignCenter.Size = new System.Drawing.Size(23, 23);
            this.btnAlignCenter.Click += new System.EventHandler(this.btnAlignCenter_Click);
            // 
            // btnAlignRight
            // 
            this.btnAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignRight.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignRight.Image")));
            this.btnAlignRight.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnAlignRight.Name = "btnAlignRight";
            this.btnAlignRight.Size = new System.Drawing.Size(23, 23);
            this.btnAlignRight.Click += new System.EventHandler(this.btnAlignRight_Click);
            // 
            // btnJustify
            // 
            this.btnJustify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnJustify.Image = ((System.Drawing.Image)(resources.GetObject("btnJustify.Image")));
            this.btnJustify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnJustify.Name = "btnJustify";
            this.btnJustify.Size = new System.Drawing.Size(23, 23);
            this.btnJustify.Click += new System.EventHandler(this.btnJustify_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // btnNumberedList
            // 
            this.btnNumberedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNumberedList.Image = ((System.Drawing.Image)(resources.GetObject("btnNumberedList.Image")));
            this.btnNumberedList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNumberedList.Name = "btnNumberedList";
            this.btnNumberedList.Size = new System.Drawing.Size(23, 23);
            this.btnNumberedList.Text = "toolStripButton1";
            this.btnNumberedList.Click += new System.EventHandler(this.btnNumberedList_Click);
            // 
            // btnBulletedList
            // 
            this.btnBulletedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBulletedList.Image = ((System.Drawing.Image)(resources.GetObject("btnBulletedList.Image")));
            this.btnBulletedList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBulletedList.Name = "btnBulletedList";
            this.btnBulletedList.Size = new System.Drawing.Size(23, 23);
            this.btnBulletedList.Text = "toolStripButton2";
            this.btnBulletedList.Click += new System.EventHandler(this.btnBulletedList_Click);
            // 
            // TextEditor
            // 
            this.TextEditor.AcceptsTab = true;
            this.TextEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextEditor.EnableAutoDragDrop = true;
            this.TextEditor.HideSelection = false;
            this.TextEditor.Location = new System.Drawing.Point(30, 53);
            this.TextEditor.Name = "TextEditor";
            charStyle1.Bold = false;
            charStyle1.Italic = false;
            charStyle1.Link = false;
            charStyle1.Strikeout = false;
            charStyle1.Underline = false;
            this.TextEditor.SelectionCharStyle = charStyle1;
            this.TextEditor.SelectionFont2 = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Inch);
            paraLineSpacing1.ExactSpacing = 0;
            paraLineSpacing1.SpacingStyle = ExtendedRichTextBox.ParaLineSpacing.LineSpacingStyle.Unknown;
            this.TextEditor.SelectionLineSpacing = paraLineSpacing1;
            paraListStyle1.BulletCharCode = ((short)(0));
            paraListStyle1.NumberingStart = ((short)(0));
            paraListStyle1.Style = ExtendedRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis;
            paraListStyle1.Type = ExtendedRichTextBox.ParaListStyle.ListType.None;
            this.TextEditor.SelectionListType = paraListStyle1;
            this.TextEditor.SelectionOffsetType = ExtendedRichTextBox.OffsetType.None;
            this.TextEditor.SelectionSpaceAfter = 0;
            this.TextEditor.SelectionSpaceBefore = 0;
            this.TextEditor.Size = new System.Drawing.Size(654, 446);
            this.TextEditor.TabIndex = 5;
            this.TextEditor.Text = "";
            this.TextEditor.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.TextEditor_LinkClicked);
            this.TextEditor.SelectionChanged += new System.EventHandler(this.TextEditor_SelectionChanged);
            this.TextEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextEditor_MouseUp);
            // 
            // Ruler
            // 
            this.Ruler.BackColor = System.Drawing.Color.Transparent;
            this.Ruler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Ruler.Font = new System.Drawing.Font("Arial", 7.25F);
            this.Ruler.LeftHangingIndent = 19;
            this.Ruler.LeftIndent = 19;
            this.Ruler.LeftMargin = 1;
            this.Ruler.Location = new System.Drawing.Point(30, 29);
            this.Ruler.Name = "Ruler";
            this.Ruler.NoMargins = true;
            this.Ruler.RightIndent = 14;
            this.Ruler.RightMargin = 1;
            this.Ruler.Size = new System.Drawing.Size(654, 20);
            this.Ruler.TabIndex = 8;
            this.Ruler.TabsEnabled = true;
            this.Ruler.LeftHangingIndentChanging += new TextRuler.TextRulerControl.TextRuler.IndentChangedEventHandler(this.Ruler_LeftHangingIndentChanging);
            this.Ruler.LeftIndentChanging += new TextRuler.TextRulerControl.TextRuler.IndentChangedEventHandler(this.Ruler_LeftIndentChanging);
            this.Ruler.RightIndentChanging += new TextRuler.TextRulerControl.TextRuler.IndentChangedEventHandler(this.Ruler_RightIndentChanging);
            this.Ruler.BothLeftIndentsChanged += new TextRuler.TextRulerControl.TextRuler.MultiIndentChangedEventHandler(this.Ruler_BothLeftIndentsChanged);
            this.Ruler.TabAdded += new TextRuler.TextRulerControl.TextRuler.TabChangedEventHandler(this.Ruler_TabAdded);
            this.Ruler.TabRemoved += new TextRuler.TextRulerControl.TextRuler.TabChangedEventHandler(this.Ruler_TabRemoved);
            this.Ruler.TabChanged += new TextRuler.TextRulerControl.TextRuler.TabChangedEventHandler(this.Ruler_TabChanged);
            // 
            // LineNumbers
            // 
            this.LineNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineNumbers.Location = new System.Drawing.Point(3, 50);
            this.LineNumbers.Name = "LineNumbers";
            this.LineNumbers.Size = new System.Drawing.Size(21, 452);
            this.LineNumbers.TabIndex = 9;
            // 
            // prtDoc
            // 
            this.prtDoc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.prtDoc_BeginPrint);
            this.prtDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prtDoc_PrintPage);
            // 
            // DocPreview
            // 
            this.DocPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.DocPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.DocPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.DocPreview.Document = this.prtDoc;
            this.DocPreview.Enabled = true;
            this.DocPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("DocPreview.Icon")));
            this.DocPreview.Name = "DocPreview";
            this.DocPreview.Visible = false;
            // 
            // PageSettings
            // 
            this.PageSettings.Document = this.prtDoc;
            // 
            // PrintWnd
            // 
            this.PrintWnd.Document = this.prtDoc;
            this.PrintWnd.UseEXDialog = true;
            // 
            // AdvancedTextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpEditorLayout);
            this.Name = "AdvancedTextEditor";
            this.Size = new System.Drawing.Size(687, 502);
            this.Load += new System.EventHandler(this.AdvancedTextEditor_Load);
            this.tlpEditorLayout.ResumeLayout(false);
            this.tlpEditorLayout.PerformLayout();
            this.Toolbox_Formatting.ResumeLayout(false);
            this.Toolbox_Formatting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpEditorLayout;
        private System.Windows.Forms.ToolStrip Toolbox_Formatting;
        private System.Windows.Forms.ToolStripComboBox cmbFontName;
        private System.Windows.Forms.ToolStripComboBox cmbFontSize;
        private System.Windows.Forms.ToolStripSeparator sepTBFormatting1;
        private System.Windows.Forms.ToolStripButton btnBold;
        private System.Windows.Forms.ToolStripButton btnItalic;
        private System.Windows.Forms.ToolStripButton btnStrikeThrough;
        private System.Windows.Forms.ToolStripSeparator sepTBFormatting2;
        private System.Windows.Forms.ToolStripButton btnAlignLeft;
        private System.Windows.Forms.ToolStripButton btnAlignCenter;
        private System.Windows.Forms.ToolStripButton btnAlignRight;
        private System.Drawing.Printing.PrintDocument prtDoc;
        private System.Windows.Forms.PrintPreviewDialog DocPreview;
        private System.Windows.Forms.PageSetupDialog PageSettings;
        private System.Windows.Forms.PrintDialog PrintWnd;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton btnJustify;
        private System.Windows.Forms.ToolStripButton btnUnderline;
        private TextRuler.TextRulerControl.TextRuler Ruler;
        private System.Windows.Forms.Label LineNumbers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnBulletedList;
        private System.Windows.Forms.ToolStripButton btnNumberedList;
        public ExtendedRichTextBox TextEditor;
    }
}
