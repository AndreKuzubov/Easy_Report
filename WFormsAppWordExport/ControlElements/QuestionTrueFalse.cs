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
    public partial class QuestionTrueFalse : Question
    {
        public QuestionTrueFalse(Feature ffQuestion, int iIndex) : base(ffQuestion, iIndex)
        {
            InitializeComponent();
            if ((feature.isAnswered))
            {
                this.labelAnswer.Text = ((int)feature.answer.oAnswer == 0 ? "нет" : "да");
            }
        }

        protected override void reset()
        {
            this.labelAnswer.Text = "";
        }

        private void buttonTrue_Click(object sender, EventArgs e)
        {
            setAnswer(1);
            this.labelAnswer.Text = "да";
        }

        private void buttonFalse_Click(object sender, EventArgs e)
        {
            setAnswer(0);
            this.labelAnswer.Text = "нет";
        }
    }
}
