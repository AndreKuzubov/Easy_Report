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
    public partial class QuestionChoose : WFormsAppWordExport.Question
    {

        public QuestionChoose(Feature ffQuestion, int iIndex) : base(ffQuestion, iIndex)
        {
            InitializeComponent();
            //comboBox1.Items.AddRange(fQuestion.sAnswers);
            this.SetStyle(ControlStyles.Selectable, false);
            if (feature.isAnswered)
            {
               // comboBox1.SelectedIndex = (int)(fQuestion.Answer);
            }
            comboBox1.MouseWheel += new MouseEventHandler(this.ComboBox1_MouseWheel);
                               
        }

        private void ComboBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        protected override void reset()
        {
            comboBox1.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setAnswer((Object)(comboBox1.SelectedIndex));
        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

    }
}
