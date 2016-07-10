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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WFormsAppWordExport.Forms;

namespace WFormsAppWordExport
{
    public partial class UCTemplateObject : UserControl
    {
        DBTemplatesHelper db = DBTemplatesHelper.get();
        SqlDataAdapter sqlAdapter = new SqlDataAdapter();
        BindingSource bindingSource = new BindingSource();
        DBTemplatesHelper.DBObject obj;
        public FormSettingQuestionnaire parent;

        private int objId;
        public UCTemplateObject()
        {
            InitializeComponent();
            bindingNavigator1.BindingSource = bindingSource;
            dataGridView1.DataSource = bindingSource;
        }

        public void setFollowObj(int id)
        {
            this.objId = id;
            updateViewData();
        }

        private void updateViewData()
        {
            if (this.objId == -1)
            {
                obj = null;
                textBoxName.Text = "";
                comboBoxFlags.SelectedIndex = -1;
                textBoxObjScript.Text ="";
                textBoxObjIds.Text ="";
                bindingSource.DataSource=null;
            }
            else {
                obj = DBTemplatesHelper.DBObject.get(objId);
                textBoxName.Text = obj.name;
                comboBoxFlags.SelectedIndex = obj.flags;
                textBoxObjScript.Text = obj.script;
                textBoxObjIds.Text = obj.sObjects;
                db.bindingFeaturesForObjectById(bindingSource, objId);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DBTemplatesHelper.DBFeature f=new DBTemplatesHelper.DBFeature(objId);
            FormEditFeature dialog = new FormEditFeature(f, objId);
          
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                f.insertToDB(objId);
                foreach (DBTemplatesHelper.DBAnswer ans in dialog.answers)
                {
                    ans.insertAnswer(f.id);
                }
            }
            dialog.Close();
            updateViewData();
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Создайте Элемент.","База данных пуста", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = dataGridView1.CurrentCell.RowIndex;
            DBTemplatesHelper.DBFeature f=DBTemplatesHelper.DBFeature.get((int)dataGridView1.Rows[index].Cells[0].Value);
            FormEditFeature dialog =new FormEditFeature(f, objId);
            List<DBTemplatesHelper.DBAnswer> oldAnswers = DBTemplatesHelper.DBAnswer.getAnswers(f.id);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                f.updateToDB();
                foreach (DBTemplatesHelper.DBAnswer ans in oldAnswers)
                {
                    ans.deleleteFromDB();
                }
                foreach (DBTemplatesHelper.DBAnswer ans in dialog.answers)
                {
                    ans.insertAnswer(f.id);
                }
                updateViewData();
            }
            dialog.Close();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Создайте Элемент.", "База данных пуста", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = dataGridView1.CurrentCell.RowIndex;
            DBTemplatesHelper.DBFeature f = DBTemplatesHelper.DBFeature.get((int)dataGridView1.Rows[index].Cells[0].Value);
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                f.deleteFromDB();
            }
            updateViewData();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (obj!=null)
                obj.name = textBoxName.Text;
        }

        private void textBoxObjScript_TextChanged(object sender, EventArgs e)
        {
            if (obj != null)
                obj.script = textBoxObjScript.Text;
        }

        private void textBoxObjIds_TextChanged(object sender, EventArgs e)
        {
            if (obj != null)
                obj.sObjects = textBoxObjIds.Text;
         
        }

        private void btScript_Click(object sender, EventArgs e)
        {
            Forms.FormDevCode formDev = new FormDevCode(textBoxObjScript.Text, DataStructures.SoftwareSctipt.SCRIPT_TYPE.STRING);
            if (formDev.ShowDialog() == DialogResult.OK)
            {
                textBoxObjScript.Text = formDev.richTextBoxCode.Text;
                if (obj != null)
                    obj.script = formDev.richTextBoxCode.Text;
                formDev.Close();
            }
        }

        private void comboBoxFlags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (obj != null)
                obj.flags = comboBoxFlags.SelectedIndex;
        }

        private void tabControl2_Leave(object sender, EventArgs e)
        {
            saveToDB();
        }

        public void saveToDB()
        {
            if ( obj != null)
            {
                obj.updateToDB();
                if (parent!= null)
                    parent.updateData();
            }
        }

        private void btAbstObjects_Click(object sender, EventArgs e)
        {
            #region prepere params before call dialog
            Forms.FormSelectItemsList fDialog = new FormSelectItemsList();
            List<Forms.FormSelectItemsList.Para> selected = new List<FormSelectItemsList.Para>();
            List<Forms.FormSelectItemsList.Para> unSelected = new List<FormSelectItemsList.Para>();
            {
                int[] ids = ConvertFormat.stringToArray(textBoxObjIds.Text);
                if (ids != null && ids.Length > 0)
                {
                    foreach (int idObj in ids)
                    {
                        DBTemplatesHelper.DBObject dbObj = DBTemplatesHelper.DBObject.get(idObj);
                        FormSelectItemsList.Para p = new FormSelectItemsList.Para();
                        p.text = dbObj.name;
                        p.id = dbObj.id;
                        selected.Add(p);
                    }
                }
            }
            List<DBTemplatesHelper.DBObject> dbObjs = DBTemplatesHelper.get().getObjects();
            foreach (DBTemplatesHelper.DBObject dbObj in dbObjs)
            {
                FormSelectItemsList.Para p = new FormSelectItemsList.Para();
                p.text = dbObj.name;
                p.id = dbObj.id;
                if (!selected.Contains(p))
                    unSelected.Add(p);
            }
            #endregion

            fDialog.set(selected, unSelected);
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                List<int> idsO=new List<int>();
                foreach (FormSelectItemsList.Para p in fDialog.listBoxSelected.Items)
                {
                    idsO.Add(p.id);
                }

                obj.sObjects = ConvertFormat.arrayToString(idsO.ToArray());
                textBoxObjIds.Text = obj.sObjects;
            }


        }
    }
}
