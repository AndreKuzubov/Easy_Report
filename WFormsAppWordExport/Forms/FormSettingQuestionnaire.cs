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

namespace WFormsAppWordExport
{
    public partial class FormSettingQuestionnaire : Form
    {

        DBTemplatesHelper myDb = DBTemplatesHelper.get();
        public FormSettingQuestionnaire()
        {
            InitializeComponent();
        }
        
        private void btAddObject_Click(object sender, EventArgs e)
        {

        }

        private void btDelObject_Click(object sender, EventArgs e)
        {

        }

        private void FormSettingQuestionnaire_Load(object sender, EventArgs e)
        {
           
        }

        private void FormSettingQuestionnaire_Shown(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Состояние: Открытие настроек";
          //  myDb.create_openDB();
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
    }
}
