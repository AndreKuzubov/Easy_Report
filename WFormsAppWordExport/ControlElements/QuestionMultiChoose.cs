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
using WFormsAppWordExport.DataStructures;
using System.Windows.Forms;

namespace WFormsAppWordExport
{
    public partial class QuestionMultiChoose : WFormsAppWordExport.Question
    {
        
        public QuestionMultiChoose(Feature feature,int iIndex,Form1 f):base(feature,iIndex,f)
        {
            
            InitializeComponent();
            bool haveImage=false;
            if (feature.sAnswers!=null&&feature.sAnswers.Count > 0)
            {
                foreach(Choose_Answer ans in feature.sAnswers)
                {
                    checkedListBox1.Items.Add(ans.sName);
                    if (ans.image != null) haveImage = true;
                }
            }
            btExpose.Visible = btExpose.Enabled = haveImage;
            updateAnswer();
        }

        protected override void reset()
        {
            checkedListBox1.ClearSelected();
            for (int i = 0,l= checkedListBox1.Items.Count; i <l ; i++)
                checkedListBox1.SetItemChecked(i, false);
        }

        private void checkedListBox1_ItemChecked(object sender, ItemCheckEventArgs e)
        {
            String s = "",divider="";
            int[] a = new int[checkedListBox1.Items.Count];
            for (int i = 0; i < a.Length; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    a[i] = 1;
                    s += divider + feature.sAnswers[i].sExport ;
                    divider = ", ";
                }
                  
                else a[i] = 0;

                
            }
            a[e.Index] = (e.NewValue == CheckState.Checked) ? 1:0;
            setAnswer(a,s);
        }

        private void btExpose_Click(object sender, EventArgs e)
        {
            FormPictureMultiChoose form = new FormPictureMultiChoose(feature.sAnswers);
            if (feature.answer!=null)
            {
                form.check = (int[])feature.answer.oAnswer;
            }
            if (form.ShowDialog() == DialogResult.OK)
            {
                setAnswer(form.check, form.getStringAnswer());
                updateAnswer();
            }
        }

        private void updateAnswer()
        {
            if (base.feature.isAnswered)
            {
                int[] a = (int[])(base.feature.answer.oAnswer);
                for (int i = 0; i < a.Length; i++)
                {
                    checkedListBox1.SetItemChecked(i, (a[i] == 1) ? true : false);
                }
            }
        }
    }
}
