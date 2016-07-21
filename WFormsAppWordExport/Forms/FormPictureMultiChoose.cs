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
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport
{
    public partial class FormPictureMultiChoose : Form
    {
        private int[] _ch;
        private List<Choose_Answer> answers=null;
        public int [] check{
             set
            {
                 _ch = value;
                updateView();
            }
            get
            {
                return _ch;
            }
            }
        

        public FormPictureMultiChoose(List<Choose_Answer> answers)
        {
            InitializeComponent();
            this.answers = answers;
            if (answers == null) return;
            int len = answers.Count;
            check = new int[len];        
        }

        public string getStringAnswer()
        {
            if (answers == null) return null;
            string s = "";
            string separator = "";
            for (int i = 0, l = answers.Count; i < l; i++)
            {
                s += separator + answers[i].sExport;
                separator = ", ";
            }
            return s;
        }

        private void updateView()
        {
           
            flowLayoutPanel1.Controls.Clear();
            if (answers == null) return;
            for (int i = 0, l = answers.Count; i < l; i++)
            {
                UCChoosePict choosePict = new UCChoosePict();
                choosePict.checkBox1.Text = answers[i].sName;
                choosePict.checkBox1.Image = answers[i].image;
                choosePict.checkBox1.Tag = i;
                choosePict.checkBox1.CheckedChanged += new EventHandler(checkBox_checked);
                if (_ch[i] == 1) choosePict.checkBox1.CheckState = CheckState.Checked;
                flowLayoutPanel1.Controls.Add(choosePict);
            }

        }

        private void PictureMultiChoose_Load(object sender, EventArgs e)
        {
          

        }

        private void btOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void checkBox_checked(object sender, EventArgs e)
        {
            if (answers == null) return;
            int a =(int) ((Control)sender).Tag;
            bool value = ((CheckBox)sender).Checked;
            _ch[a]= (value) ? 1 : 0;
        }

    }
}
