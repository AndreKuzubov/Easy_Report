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
            DBTemplatesHelper.DBObject obj= db.getDBObjectById(objId);

            textBoxName.Text = obj.name;
            textBoxObjFlags.Text = obj.flags.ToString();
            textBoxObjScript.Text = obj.script;
            textBoxObjIds.Text = obj.sObjects;
            numericObjectPos.Value = obj.pos;
            db.bindingFeaturesForObjectById(bindingSource, objId);
        }
    }
}
