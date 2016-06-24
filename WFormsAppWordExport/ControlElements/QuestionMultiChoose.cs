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
        public QuestionMultiChoose(Feature ffQuestion,int iIndex):base(ffQuestion,iIndex)
        {
            InitializeComponent();
            //checkedListBox1.Items.AddRange(fQuestion.sAnswers);
            if (feature.isAnswered)
            {
                int []a = (int [])(feature.answer.oAnswer);
                for (int i = 0; i < a.Length; i++)
                {
                    checkedListBox1.SetItemChecked(i, (a[i]==1)?true:false);
                }
            }
        }

        protected override void reset()
        {
            checkedListBox1.SelectedItems.Clear();
        }

        private void checkedListBox1_ItemChecked(object sender, ItemCheckEventArgs e)
        {
            int[] a = new int[checkedListBox1.Items.Count];
            for (int i = 0; i < a.Length; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                    a[i] = 1;
                else a[i] = 0;
            }
            a[e.Index] = (e.NewValue == CheckState.Checked) ? 1:0;
            setAnswer(a);
        }
    }
}
