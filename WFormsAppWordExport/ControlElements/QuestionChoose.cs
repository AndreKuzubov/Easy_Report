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
