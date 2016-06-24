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
