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
            DBTemplatesHelper.DBObject obj= DBTemplatesHelper.DBObject.get(objId);
            textBoxName.Text = obj.name;
            textBoxObjFlags.Text = obj.flags.ToString();
            textBoxObjScript.Text = obj.script;
            textBoxObjIds.Text = obj.sObjects;
            numericObjectPos.Value = obj.pos;
            db.bindingFeaturesForObjectById(bindingSource, objId);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DBTemplatesHelper.DBFeature f=new DBTemplatesHelper.DBFeature();
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
            int index = dataGridView1.CurrentCell.RowIndex;
            DBTemplatesHelper.DBFeature f=DBTemplatesHelper.DBFeature.get((int)dataGridView1.Rows[index].Cells[0].Value);
            FormEditFeature dialog =new FormEditFeature(f, objId);
            List<DBTemplatesHelper.DBAnswer> oldAnswers = DBTemplatesHelper.DBAnswer.getAnswers(f.id);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                f.updateToDB();
                foreach (DBTemplatesHelper.DBAnswer ans in oldAnswers)
                {
                    ans.deleleteAnswer();
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
            int index = dataGridView1.CurrentCell.RowIndex;
            DBTemplatesHelper.DBFeature f = DBTemplatesHelper.DBFeature.get((int)dataGridView1.Rows[index].Cells[0].Value);
            FormEditFeature dialog = new FormEditFeature(f,objId);
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                f.deleteFromDB();
            }
            dialog.Close();
            updateViewData();
        }
    }
}
