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
        private Form1 parentControl;

        protected virtual void reset() { }

        public Question()
        {
            InitializeComponent();
        }

        public Question(Feature fQuestion, int iTabIndex,Form1 parentControl)
        {
            this.feature = fQuestion;
            this.TabIndex = iTabIndex;
            this.parentControl = parentControl;
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
            if (parentControl != null)
            {
                parentControl.updateShowingEssences();
            }

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            reset();
            feature.resetAns();
            labelAuthor.Text = "";
            parentControl.updateShowingEssences();
        }

        private void load(object sender, EventArgs e)
        {
        }
    }
}
