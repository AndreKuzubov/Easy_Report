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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = NetOffice.WordApi;
using WordEnums = NetOffice.WordApi.Enums;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using WFormsAppWordExport.DataStructures;


namespace WFormsAppWordExport.Forms
{
    public partial class FormDevCode : Form
    {
        public SoftwareSctipt.SCRIPT_TYPE typeMethod= SoftwareSctipt.SCRIPT_TYPE.STRING;
        public  FormDevCode()
        {
            InitializeComponent();
        }

    /*    private void button4_Click(object sender, EventArgs e)
        {
            String s= richTextBoxCode.Rtf;
          //  richTextBox1.
   //        richTextBox1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Word.Application app = new Word.Application();
            app.Visible = true;
            Word.Document doc;
            Object template = MyFiles.getMyTemplate();
            Object newTemplate = false;
            Object documentType = 0;
            Object visible = true;


            doc = app.Documents.Add(
            template, newTemplate, documentType, visible);
            doc.Activate();
            Clipboard.SetText(richTextBoxCode.Text, TextDataFormat.Rtf);
            app.Selection.Paste();
          
        }*/

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            CompilerResults result = DataStructures.SoftwareSctipt.compile(richTextBoxCode.Text, typeMethod);
            if (result==null||result.Errors.Count==0)
                this.DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show("Исправте код, либо нажмите отмена", "Ошибка в коде", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btErase_Click(object sender, EventArgs e)
        {
            richTextBoxCode.Clear();
        }

        private void btCompile_Click(object sender, EventArgs e)
        {
            CompilerResults result=DataStructures.SoftwareSctipt.compile(richTextBoxCode.Text, typeMethod);
            extendedTextBoxResult.Clear();

            
            if (result!=null)
                if (result.Errors!=null&&result.Errors.Count>0)
                foreach (CompilerError s in result.Errors)
                    extendedTextBoxResult.Text += (s.Line-18)+" : "+s.ErrorText+" "+s.FileName+"\n";
            else
                {
                    extendedTextBoxResult.Text += "success";
                }
        }
    }
}
