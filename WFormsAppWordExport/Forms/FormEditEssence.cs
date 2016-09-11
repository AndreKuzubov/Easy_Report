using System;
using System.Windows.Forms;

namespace WFormsAppWordExport.Forms
{
    public partial class FormEditEssence : Form
    {
        public FormEditEssence()
        {
            InitializeComponent();
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
