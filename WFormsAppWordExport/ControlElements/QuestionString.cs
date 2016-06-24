/**
 Copyright 2016 Andrey Kuzubov

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License. 
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport
{
    public partial class QuestionString : WFormsAppWordExport.Question
    {
        public QuestionString(Feature ffQuestion, int iIndex):base(ffQuestion,iIndex)
        {
            InitializeComponent();
            if ((feature.isAnswered))
            {
                comboBox1.Text = (String)feature.answer.oAnswer;
            }
           // if (fQuestion.sAnswers != null && fQuestion.sAnswers.Length > 0)
             //   comboBox1.Items.AddRange(fQuestion.sAnswers);
           // else
             //   comboBox1.DropDownStyle = ComboBoxStyle.Simple;
        }

        protected override void reset()
        {
            comboBox1.Text = "";
        }

      
        private void expose_Click(object sender, EventArgs e)
        {
            FormNotepad notepad = new FormNotepad();
            notepad.textBox.Text = this.comboBox1.Text;
            notepad.ShowDialog(this);
            if (notepad.DialogResult == DialogResult.OK)
            {
                notepad.Close();
                comboBox1.Text = notepad.textBox.Text;
                setAnswer(notepad.textBox.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setAnswer((Object)comboBox1.Text);
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            setAnswer((Object)comboBox1.Text);
        }
    }
}
