using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WFormsAppWordExport.Forms
{
    public partial class FormNewEssence : Form
    {
        private List<DBTemplatesHelper.DBObject> _dbObjects=new List<DBTemplatesHelper.DBObject>();
        public List<DBTemplatesHelper.DBObject> dbObjects {
            get { return _dbObjects; }
            set {
                _dbObjects = value;
                updateData();
            }
        }

        public DBTemplatesHelper.DBObject dbSelectedObject { get
            {
                if (comboBoxImagesObjects.SelectedIndex == -1) return null;
                return _dbObjects[comboBoxImagesObjects.SelectedIndex];
            }

        }

        public String sSelectedNameEssence
        {
            get
            {
                if (textBoxNameEssence.Text == null || textBoxNameEssence.Text.Length == 0)
                    return (dbSelectedObject == null) ? null : dbSelectedObject.name;
                return textBoxNameEssence.Text;
            }
        }

        public FormNewEssence()
        {
            InitializeComponent();
        }

        private void updateData()
        {
            comboBoxImagesObjects.Items.Clear();
            foreach(DBTemplatesHelper.DBObject db in _dbObjects)
            {
                comboBoxImagesObjects.Items.Add(db.name);
            }
        }


        private void btOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
