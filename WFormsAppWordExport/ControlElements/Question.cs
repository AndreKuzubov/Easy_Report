using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport
{
    public  partial class Question : UserControl
    {
        public Feature feature { get; protected set; }

        protected virtual void reset() { }

        public Question()
        {
            InitializeComponent();
        }

        public Question(Feature fQuestion, int iTabIndex)
        {
            this.feature = fQuestion;
            this.TabIndex = iTabIndex;
            InitializeComponent();
            this.labelQuestion.Text = fQuestion.sQuestion;
            if ((fQuestion.isAnswered))
            {
                this.labelAuthor.Text = fQuestion.sAuthor;
            }
        }

        protected void setAnswer(Object Answer)
        {
            setAnswer(Answer, null);
        }

        protected void setAnswer(Object oAnswer,String strAnswer)
        {
            feature.setAnswer(new Answer(oAnswer,strAnswer), Program.sUser);
            labelAuthor.Text = Program.sUser;
            if (this.Parent != null)
            {
                //((Feature)(this.Parent))();
            }

        }

      

        private void buttonReset_Click(object sender, EventArgs e)
        {
            reset();
            feature.resetAns();
          //  ((Feature)(this.Parent)).update();
            labelAuthor.Text = "";
        }

        private void load(object sender, EventArgs e)
        {
        }
    }
}
