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
using System.Windows.Forms;

using Word = NetOffice.WordApi;
using WordEnums = NetOffice.WordApi.Enums;

namespace WFormsAppWordExport
{
    public partial class FormSettingQuestionnaire : Form
    {

        DBTemplatesHelper myDb;
      
        public FormSettingQuestionnaire()
        {
            InitializeComponent();
            this.advancedTextEditor1.TextEditor.SelectionChanged += TextEditor_SelectionChanged;
        }


        #region events 

        private void TextEditor_SelectionChanged(object sender, EventArgs e)
        {
            int indexSelected = this.advancedTextEditor1.TextEditor.SelectionStart;
            int i = this.advancedTextEditor1.TextEditor.getIdSript(indexSelected);
            if (i != -1)
            {
                btNew_SettingScript.Text = "Редактировать";
                btNew_SettingScript.Tag = i;
                btDel.Enabled = true;
            }
            else {
                btNew_SettingScript.Text = "Новый скрипт";
                btDel.Enabled = false;
                btNew_SettingScript.Tag = i;
            }
        }

        private void btAddObject_Click(object sender, EventArgs e)
        {

        }

        private void btDelObject_Click(object sender, EventArgs e)
        {

        }

        private void FormSettingQuestionnaire_Load(object sender, EventArgs e)
        {
           myDb  = DBTemplatesHelper.get();
           loadText();
        }

        private void FormSettingQuestionnaire_Shown(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Состояние: Открытие настроек";
            toolStripStatusLabel.Text = "Состояние";
            treeViewObjects.Nodes.Clear();
             List <DBTemplatesHelper.DBObject> obj = myDb.getObjects();
            for (int i = 0; i < obj.Count; i++)
            {
                TreeNode node = new TreeNode(obj[i].name);
                node.Tag = obj[i].id;
                treeViewObjects.Nodes.Add(node);
            }
            treeViewObjects.SelectedNode = treeViewObjects.Nodes[0];
        }

        private void FormSettingQuestionnaire_Layout(object sender, LayoutEventArgs e)
        {
           
         
        }

        private void treeViewObjects_afterSelected(object sender, TreeViewEventArgs e)
        {
            ucTemplateObject1.setFollowObj((int)treeViewObjects.SelectedNode.Tag);
        }
        #endregion

        #region private methods
        private void advancedTextEditor1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btNewSettSctript_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "редактирование скрипта";
            //advancedTextEditor1.TextEditor.insertMyScript()
            if ((int)btNew_SettingScript.Tag == -1)
            {
                Forms.FormDevCode formDevCode = new Forms.FormDevCode();
                if (formDevCode.ShowDialog() == DialogResult.OK)
                {
                    String s = formDevCode.richTextBoxCode.Text;
                    int id = DBTemplatesHelper.get().insertCodeToDB(s,0);
                    advancedTextEditor1.TextEditor.insertMyScript(id);
                }
            }
            else
            {
                Forms.FormDevCode formDevCode = new Forms.FormDevCode();
                int idCode = (int)btNew_SettingScript.Tag;
                if (idCode == -1) return;
                String code = DBTemplatesHelper.get().getCodeById(idCode);
                formDevCode.richTextBoxCode.Text = code; 
                if (formDevCode.ShowDialog() == DialogResult.OK)
                {
                    String s = formDevCode.richTextBoxCode.Text;
                    DBTemplatesHelper.get().updateCodeById(idCode,s);
                }
            }
            toolStripStatusLabel.Text = "состояние";
        }

        private void btDelScript_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "удаление скрипта";
            int id = (int)btNew_SettingScript.Tag;
            DBTemplatesHelper.get().delCodeById(id);
            advancedTextEditor1.TextEditor.delScript(id);
            toolStripStatusLabel.Text = "состояние";
        }

        private void advancedTextEditor1_Leave(object sender, EventArgs e)
        {
            safeText();
        }

        private void advancedTextEditor1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "загрузка текста из базы";
            advancedTextEditor1.TextEditor.Rtf = DBTemplatesHelper.get().getTextParagraph();
            toolStripStatusLabel.Text = "состояние";
        }

        private void FormSettingQuestionnaire_FormClosing(object sender, FormClosingEventArgs e)
        {
            safeText();
        }

        private void safeText()
        {
            toolStripStatusLabel.Text = "загрузка текста в базу";
            DBTemplatesHelper.get().updateTextParagraph(advancedTextEditor1.TextEditor.Rtf);
            toolStripStatusLabel.Text = "состояние";
        }

        private void loadText()
        {
            DBTemplatesHelper.DBParagraph p = DBTemplatesHelper.DBParagraph.getText();
            if (p == null) return;
            advancedTextEditor1.TextEditor.Rtf = p.text;
        }

        #endregion
    }
}
