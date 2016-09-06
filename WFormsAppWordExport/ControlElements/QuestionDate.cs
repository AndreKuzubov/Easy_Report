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
        DateSaver date= new DateSaver();
        public QuestionDate(Feature ffQuestion, int iIndex,Form1 f) : base(ffQuestion, iIndex,f)
        {
            InitializeComponent();
                  
            if (feature.isAnswered)
            {
                DateSaver saver = (feature.answer.dateAnswer);
                datePicker.Value = saver.date;
                comboBoxFromat.SelectedIndex = (int)saver.format;                
            }else
            {
                datePicker.Value = DateTime.Today;
                comboBoxFromat.SelectedIndex = 0;
            }
            
        }

        

        protected override void reset()
        {
            datePicker.Value = DateTime.Today;
            comboBoxFromat.SelectedIndex = 0;
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void saveChanges()
        {
            date.date = datePicker.Value;
            date.format = (DateSaver.DATE_FORMAT)comboBoxFromat.SelectedIndex;
        }

        private void comboBoxFromat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxFromat.SelectedIndex)
            {
                case 0:
                    datePicker.CustomFormat = "yyyy";
                    break;
                case 1:
                    datePicker.CustomFormat = "MM.yyyy";
                    break;
                case 2:
                    datePicker.CustomFormat = "d.MM.yyyy";

                    break;
                case 3:
                    datePicker.CustomFormat = "d.MM.yyyy h:mm";
                    break;
                case 4:
                    datePicker.CustomFormat = "d.MM h:mm";
                    break;
                case 5:
                    datePicker.CustomFormat = "h:mm";
                    break;
                default:comboBoxFromat.SelectedIndex = 0;
                    break;
            }
        }

        private void datePicker_Enter(object sender, EventArgs e)
        {
            saveChanges();
            setAnswer(date, date.getStringDate());
        }
    }
}
