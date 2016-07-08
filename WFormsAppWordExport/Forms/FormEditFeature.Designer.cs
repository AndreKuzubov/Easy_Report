namespace WFormsAppWordExport.Forms
{
    partial class FormEditFeature
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btAnswers = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxAfterQuestion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxScriptCondition = new System.Windows.Forms.TextBox();
            this.textBoxScriptAfterAnswer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btConditionScript = new System.Windows.Forms.Button();
            this.btAfterScript = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вопрос характеристики";
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuestion.Location = new System.Drawing.Point(140, 16);
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.Size = new System.Drawing.Size(524, 20);
            this.textBoxQuestion.TabIndex = 1;
            this.textBoxQuestion.TextChanged += new System.EventHandler(this.textBoxQuestion_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип ответа на вопрос";
            // 
            // comboBoxType
            // 
            this.comboBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Строка",
            "Число",
            "Выбор",
            "Да\\Нет",
            "Множественный выбор",
            "Дата",
            "Ссылка на обьект"});
            this.comboBoxType.Location = new System.Drawing.Point(140, 42);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(524, 21);
            this.comboBoxType.TabIndex = 3;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Возможные ответы";
            // 
            // btAnswers
            // 
            this.btAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btAnswers.Location = new System.Drawing.Point(140, 67);
            this.btAnswers.Name = "btAnswers";
            this.btAnswers.Size = new System.Drawing.Size(524, 23);
            this.btAnswers.TabIndex = 5;
            this.btAnswers.Text = "Коллекция";
            this.btAnswers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAnswers.UseVisualStyleBackColor = true;
            this.btAnswers.Click += new System.EventHandler(this.btAnswers_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Спрашивать после";
            // 
            // comboBoxAfterQuestion
            // 
            this.comboBoxAfterQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAfterQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAfterQuestion.FormattingEnabled = true;
            this.comboBoxAfterQuestion.Items.AddRange(new object[] {
            "Строка",
            "Число",
            "Выбор",
            "Множественный выбор",
            "Дата",
            "Ссылка на обьект"});
            this.comboBoxAfterQuestion.Location = new System.Drawing.Point(140, 96);
            this.comboBoxAfterQuestion.Name = "comboBoxAfterQuestion";
            this.comboBoxAfterQuestion.Size = new System.Drawing.Size(524, 21);
            this.comboBoxAfterQuestion.TabIndex = 7;
            this.comboBoxAfterQuestion.SelectedIndexChanged += new System.EventHandler(this.comboBoxAfterQuestion_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Условие вопроса";
            // 
            // textBoxScriptCondition
            // 
            this.textBoxScriptCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxScriptCondition.Location = new System.Drawing.Point(140, 129);
            this.textBoxScriptCondition.Multiline = true;
            this.textBoxScriptCondition.Name = "textBoxScriptCondition";
            this.textBoxScriptCondition.ReadOnly = true;
            this.textBoxScriptCondition.Size = new System.Drawing.Size(524, 164);
            this.textBoxScriptCondition.TabIndex = 9;
            // 
            // textBoxScriptAfterAnswer
            // 
            this.textBoxScriptAfterAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxScriptAfterAnswer.Location = new System.Drawing.Point(140, 299);
            this.textBoxScriptAfterAnswer.Multiline = true;
            this.textBoxScriptAfterAnswer.Name = "textBoxScriptAfterAnswer";
            this.textBoxScriptAfterAnswer.ReadOnly = true;
            this.textBoxScriptAfterAnswer.Size = new System.Drawing.Size(524, 194);
            this.textBoxScriptAfterAnswer.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Делать после";
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOk.Location = new System.Drawing.Point(12, 499);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 12;
            this.btOk.Text = "Сохранить";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.Location = new System.Drawing.Point(589, 499);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 13;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btConditionScript
            // 
            this.btConditionScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btConditionScript.Location = new System.Drawing.Point(564, 270);
            this.btConditionScript.Name = "btConditionScript";
            this.btConditionScript.Size = new System.Drawing.Size(100, 23);
            this.btConditionScript.TabIndex = 14;
            this.btConditionScript.Text = "Редактировать";
            this.btConditionScript.UseVisualStyleBackColor = true;
            this.btConditionScript.Click += new System.EventHandler(this.btConditionScript_Click);
            // 
            // btAfterScript
            // 
            this.btAfterScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAfterScript.Location = new System.Drawing.Point(564, 470);
            this.btAfterScript.Name = "btAfterScript";
            this.btAfterScript.Size = new System.Drawing.Size(100, 23);
            this.btAfterScript.TabIndex = 15;
            this.btAfterScript.Text = "Редактировать";
            this.btAfterScript.UseVisualStyleBackColor = true;
            this.btAfterScript.Click += new System.EventHandler(this.btAfterScript_Click);
            // 
            // FormEditFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 534);
            this.Controls.Add(this.btAfterScript);
            this.Controls.Add(this.btConditionScript);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxScriptAfterAnswer);
            this.Controls.Add(this.textBoxScriptCondition);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxAfterQuestion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btAnswers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxQuestion);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(650, 550);
            this.Name = "FormEditFeature";
            this.Text = "Редактирование характеристики";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btAnswers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxAfterQuestion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxScriptCondition;
        private System.Windows.Forms.TextBox textBoxScriptAfterAnswer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btConditionScript;
        private System.Windows.Forms.Button btAfterScript;
    }
}