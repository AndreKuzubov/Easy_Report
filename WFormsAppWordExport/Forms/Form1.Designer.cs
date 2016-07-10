namespace WFormsAppWordExport
{
    partial class Form1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btEditEssence = new System.Windows.Forms.Button();
            this.btEssenceDown = new System.Windows.Forms.Button();
            this.btEssenceUp = new System.Windows.Forms.Button();
            this.btDelEssence = new System.Windows.Forms.Button();
            this.btAddEssence = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.btEditEssence);
            this.splitContainer1.Panel1.Controls.Add(this.btEssenceDown);
            this.splitContainer1.Panel1.Controls.Add(this.btEssenceUp);
            this.splitContainer1.Panel1.Controls.Add(this.btDelEssence);
            this.splitContainer1.Panel1.Controls.Add(this.btAddEssence);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(660, 470);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 1;
            // 
            // btEditEssence
            // 
            this.btEditEssence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEditEssence.Location = new System.Drawing.Point(94, 435);
            this.btEditEssence.Name = "btEditEssence";
            this.btEditEssence.Size = new System.Drawing.Size(75, 23);
            this.btEditEssence.TabIndex = 5;
            this.btEditEssence.Text = "Редактировать";
            this.btEditEssence.UseVisualStyleBackColor = true;
            this.btEditEssence.Click += new System.EventHandler(this.btEditEssence_Click);
            // 
            // btEssenceDown
            // 
            this.btEssenceDown.Location = new System.Drawing.Point(3, 52);
            this.btEssenceDown.Name = "btEssenceDown";
            this.btEssenceDown.Size = new System.Drawing.Size(30, 43);
            this.btEssenceDown.TabIndex = 4;
            this.btEssenceDown.Text = "down";
            this.btEssenceDown.UseVisualStyleBackColor = true;
            this.btEssenceDown.Click += new System.EventHandler(this.btEssenceDown_Click);
            // 
            // btEssenceUp
            // 
            this.btEssenceUp.Location = new System.Drawing.Point(3, 3);
            this.btEssenceUp.Name = "btEssenceUp";
            this.btEssenceUp.Size = new System.Drawing.Size(30, 43);
            this.btEssenceUp.TabIndex = 3;
            this.btEssenceUp.Text = "up";
            this.btEssenceUp.UseVisualStyleBackColor = true;
            this.btEssenceUp.Click += new System.EventHandler(this.btEssenceUp_Click);
            // 
            // btDelEssence
            // 
            this.btDelEssence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelEssence.Location = new System.Drawing.Point(172, 435);
            this.btDelEssence.Name = "btDelEssence";
            this.btDelEssence.Size = new System.Drawing.Size(75, 23);
            this.btDelEssence.TabIndex = 2;
            this.btDelEssence.Text = "Удалить";
            this.btDelEssence.UseVisualStyleBackColor = true;
            this.btDelEssence.Click += new System.EventHandler(this.btDelEssence_Click);
            // 
            // btAddEssence
            // 
            this.btAddEssence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAddEssence.Location = new System.Drawing.Point(13, 435);
            this.btAddEssence.Name = "btAddEssence";
            this.btAddEssence.Size = new System.Drawing.Size(75, 23);
            this.btAddEssence.TabIndex = 1;
            this.btAddEssence.Text = "Добавить";
            this.btAddEssence.UseVisualStyleBackColor = true;
            this.btAddEssence.Click += new System.EventHandler(this.btAddEssence_Click);
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView1.Location = new System.Drawing.Point(39, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(211, 429);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(400, 464);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(660, 470);
            this.Controls.Add(this.splitContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btDelEssence;
        private System.Windows.Forms.Button btAddEssence;
        private System.Windows.Forms.Button btEssenceDown;
        private System.Windows.Forms.Button btEssenceUp;
        private System.Windows.Forms.Button btEditEssence;
    }
}

