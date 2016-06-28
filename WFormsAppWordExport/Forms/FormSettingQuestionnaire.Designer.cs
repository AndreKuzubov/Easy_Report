namespace WFormsAppWordExport
{
    partial class FormSettingQuestionnaire
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabObjects = new System.Windows.Forms.TabPage();
            this.splitContainerFeatures = new System.Windows.Forms.SplitContainer();
            this.treeViewObjects = new System.Windows.Forms.TreeView();
            this.btDelObject = new System.Windows.Forms.Button();
            this.btAddObject = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabWordExport = new System.Windows.Forms.TabPage();
            this.btNew_SettingScript = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.advancedTextEditor1 = new TextRuler.AdvancedTextEditorControl.AdvancedTextEditor();
            this.ucTemplateObject1 = new WFormsAppWordExport.UCTemplateObject();
            this.statusStrip.SuspendLayout();
            this.tabObjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFeatures)).BeginInit();
            this.splitContainerFeatures.Panel1.SuspendLayout();
            this.splitContainerFeatures.Panel2.SuspendLayout();
            this.splitContainerFeatures.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabWordExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 452);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(839, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel.Text = "Загрузка";
            // 
            // tabObjects
            // 
            this.tabObjects.AutoScroll = true;
            this.tabObjects.Controls.Add(this.splitContainerFeatures);
            this.tabObjects.Location = new System.Drawing.Point(4, 22);
            this.tabObjects.Name = "tabObjects";
            this.tabObjects.Padding = new System.Windows.Forms.Padding(3);
            this.tabObjects.Size = new System.Drawing.Size(807, 411);
            this.tabObjects.TabIndex = 0;
            this.tabObjects.Text = "Образы обьектов";
            this.tabObjects.UseVisualStyleBackColor = true;
            // 
            // splitContainerFeatures
            // 
            this.splitContainerFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFeatures.Location = new System.Drawing.Point(3, 3);
            this.splitContainerFeatures.Name = "splitContainerFeatures";
            // 
            // splitContainerFeatures.Panel1
            // 
            this.splitContainerFeatures.Panel1.Controls.Add(this.treeViewObjects);
            this.splitContainerFeatures.Panel1.Controls.Add(this.btDelObject);
            this.splitContainerFeatures.Panel1.Controls.Add(this.btAddObject);
            // 
            // splitContainerFeatures.Panel2
            // 
            this.splitContainerFeatures.Panel2.AutoScroll = true;
            this.splitContainerFeatures.Panel2.Controls.Add(this.ucTemplateObject1);
            this.splitContainerFeatures.Size = new System.Drawing.Size(801, 405);
            this.splitContainerFeatures.SplitterDistance = 267;
            this.splitContainerFeatures.TabIndex = 0;
            // 
            // treeViewObjects
            // 
            this.treeViewObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewObjects.Location = new System.Drawing.Point(3, 4);
            this.treeViewObjects.Name = "treeViewObjects";
            this.treeViewObjects.Size = new System.Drawing.Size(261, 369);
            this.treeViewObjects.TabIndex = 5;
            this.treeViewObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewObjects_afterSelected);
            // 
            // btDelObject
            // 
            this.btDelObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelObject.Location = new System.Drawing.Point(189, 379);
            this.btDelObject.Name = "btDelObject";
            this.btDelObject.Size = new System.Drawing.Size(75, 23);
            this.btDelObject.TabIndex = 4;
            this.btDelObject.Text = "Удалить";
            this.btDelObject.UseVisualStyleBackColor = true;
            this.btDelObject.Click += new System.EventHandler(this.btDelObject_Click);
            // 
            // btAddObject
            // 
            this.btAddObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAddObject.Location = new System.Drawing.Point(3, 379);
            this.btAddObject.Name = "btAddObject";
            this.btAddObject.Size = new System.Drawing.Size(75, 23);
            this.btAddObject.TabIndex = 3;
            this.btAddObject.Text = "Добавить";
            this.btAddObject.UseVisualStyleBackColor = true;
            this.btAddObject.Click += new System.EventHandler(this.btAddObject_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabObjects);
            this.tabControl1.Controls.Add(this.tabWordExport);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(815, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // tabWordExport
            // 
            this.tabWordExport.Controls.Add(this.btNew_SettingScript);
            this.tabWordExport.Controls.Add(this.btDel);
            this.tabWordExport.Controls.Add(this.advancedTextEditor1);
            this.tabWordExport.Location = new System.Drawing.Point(4, 22);
            this.tabWordExport.Name = "tabWordExport";
            this.tabWordExport.Size = new System.Drawing.Size(807, 411);
            this.tabWordExport.TabIndex = 1;
            this.tabWordExport.Text = "Отчетный лист";
            this.tabWordExport.UseVisualStyleBackColor = true;
            // 
            // btNew_SettingScript
            // 
            this.btNew_SettingScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNew_SettingScript.Location = new System.Drawing.Point(568, 3);
            this.btNew_SettingScript.Name = "btNew_SettingScript";
            this.btNew_SettingScript.Size = new System.Drawing.Size(115, 23);
            this.btNew_SettingScript.TabIndex = 2;
            this.btNew_SettingScript.Text = "Новый скрипт";
            this.btNew_SettingScript.UseVisualStyleBackColor = true;
            this.btNew_SettingScript.Click += new System.EventHandler(this.btNewSettSctript_Click);
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDel.Location = new System.Drawing.Point(689, 3);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(115, 23);
            this.btDel.TabIndex = 1;
            this.btDel.Text = "Удалить скрипт";
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDelScript_Click);
            // 
            // advancedTextEditor1
            // 
            this.advancedTextEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedTextEditor1.Location = new System.Drawing.Point(3, 3);
            this.advancedTextEditor1.Name = "advancedTextEditor1";
            this.advancedTextEditor1.Size = new System.Drawing.Size(801, 405);
            this.advancedTextEditor1.TabIndex = 0;
            this.advancedTextEditor1.Load += new System.EventHandler(this.advancedTextEditor1_Load);
            this.advancedTextEditor1.Leave += new System.EventHandler(this.advancedTextEditor1_Leave);
            this.advancedTextEditor1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.advancedTextEditor1_MouseMove);
            // 
            // ucTemplateObject1
            // 
            this.ucTemplateObject1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucTemplateObject1.AutoSize = true;
            this.ucTemplateObject1.Location = new System.Drawing.Point(4, 4);
            this.ucTemplateObject1.Name = "ucTemplateObject1";
            this.ucTemplateObject1.Size = new System.Drawing.Size(523, 398);
            this.ucTemplateObject1.TabIndex = 0;
            // 
            // FormSettingQuestionnaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 474);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl1);
            this.HelpButton = true;
            this.Name = "FormSettingQuestionnaire";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettingQuestionnaire_FormClosing);
            this.Load += new System.EventHandler(this.FormSettingQuestionnaire_Load);
            this.Shown += new System.EventHandler(this.FormSettingQuestionnaire_Shown);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.FormSettingQuestionnaire_Layout);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabObjects.ResumeLayout(false);
            this.splitContainerFeatures.Panel1.ResumeLayout(false);
            this.splitContainerFeatures.Panel2.ResumeLayout(false);
            this.splitContainerFeatures.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFeatures)).EndInit();
            this.splitContainerFeatures.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabWordExport.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btDelObject;
        private System.Windows.Forms.SplitContainer splitContainerFeatures;
        private System.Windows.Forms.TabPage tabObjects;
        private System.Windows.Forms.TreeView treeViewObjects;
        private System.Windows.Forms.TabPage tabWordExport;
        private TextRuler.AdvancedTextEditorControl.AdvancedTextEditor advancedTextEditor1;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Button btNew_SettingScript;
        private System.Windows.Forms.Button btAddObject;
        private UCTemplateObject ucTemplateObject1;
    }
}

