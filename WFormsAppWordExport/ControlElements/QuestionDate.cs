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
   
    public partial class QuestionDate : WFormsAppWordExport.Question
    {
        public QuestionDate(Feature ffQuestion, int iIndex) : base(ffQuestion, iIndex)
        {
            InitializeComponent();
            if (feature.isAnswered)
            {
                DateSaver saver = (DateSaver)(feature.answer.oAnswer);
                datePicker.Value = saver.date;
                datePicker.Checked = saver.isDate;
                timePicker.Value = saver.time;
                timePicker.Checked = saver.isTime;
                
            }
            
        }

        

        protected override void reset()
        {
            datePicker.Checked = false;
            timePicker.Checked = false;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            setAnswer(save());
         }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            setAnswer(save());
        }

        private Object save()
        {
            DateSaver s;
            s.date = datePicker.Value;
            s.isDate = datePicker.Checked;
            s.time = timePicker.Value;
            s.isTime = timePicker.Checked;
            return (Object)s;
        }
    }
}
