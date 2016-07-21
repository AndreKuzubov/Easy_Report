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

namespace WFormsAppWordExport.Forms
{
    public partial class FormTestEditText : Form
    {
        public FormTestEditText()
        {
            InitializeComponent();
         
        }

        private void advancedTextEditor1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            advancedTextEditor1.TextEditor.insertMyScript(243);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            advancedTextEditor1.TextEditor.Rtf = DBTemplatesHelper.get().getTextParagraph();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (advancedTextEditor1.TextEditor.Text.Length > 0)
            {
                RichTextBox re = new RichTextBox();
                re.Rtf = advancedTextEditor1.TextEditor.Rtf;
                re.Select(advancedTextEditor1.TextEditor.SelectionStart,1);
                
                richTextBox1.Clear();

               // richTextBox1.Text = "" + advancedTextEditor1.TextEditor.SelectionStart;
                
                richTextBox1.Clear();
                richTextBox1.Text = advancedTextEditor1.TextEditor.Text;
                //richTextBox1.Select(advancedTextEditor1.TextEditor,1);
                richTextBox1.Select(advancedTextEditor1.TextEditor.SelectionStart, 1);
                richTextBox1.SelectionBackColor = Color.Blue;

                richTextBox2.Clear();
                
                int index = advancedTextEditor1.TextEditor.getRtfIndexByTextIndex(advancedTextEditor1.TextEditor.SelectionStart);
                richTextBox2.Text = advancedTextEditor1.TextEditor.Rtf + "  index = " + advancedTextEditor1.TextEditor.SelectionStart
                    +" char ="+((advancedTextEditor1.TextEditor.SelectionStart>0&& advancedTextEditor1.TextEditor.SelectionStart< advancedTextEditor1.TextEditor.TextLength)?advancedTextEditor1.TextEditor.Text[advancedTextEditor1.TextEditor.SelectionStart]:' ')
                    + " rtf index = "+ index
                    + " rtf char = "+(index>0?advancedTextEditor1.TextEditor.Rtf[index]:' ')
                    +"  id Script = " +advancedTextEditor1.TextEditor.getIdSript(advancedTextEditor1.TextEditor.SelectionStart);
                richTextBox2.Select(index, 1);
                richTextBox2.SelectionBackColor = Color.Blue;
            }
        }

        private void advancedTextEditor1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
