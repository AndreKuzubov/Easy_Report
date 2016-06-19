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
