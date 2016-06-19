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
    public partial class QuestionNumeric : WFormsAppWordExport.Question
    {
        public QuestionNumeric(Feature ffQuestion, int iIndex) : base(ffQuestion, iIndex)
        {
            InitializeComponent();
            if (feature.isAnswered)
            {
                numericUpDown1.Value = (int)feature.answer.oAnswer;
            }
        }

        protected override void reset()
        {
            numericUpDown1.Value = 0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            setAnswer((Object) (int)numericUpDown1.Value);
        }
    }
}
