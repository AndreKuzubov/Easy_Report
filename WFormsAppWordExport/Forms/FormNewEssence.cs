using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WFormsAppWordExport.Forms
{
    public partial class FormNewEssence : Form
    {
        private List<SourceDataImages.ESSENSES_IMEG> _essImages=new List<SourceDataImages.ESSENSES_IMEG>();
        public List<SourceDataImages.ESSENSES_IMEG> essImages {
            get { return _essImages; }
            set {
                _essImages = value;
                updateData();
            }
        }

        public SourceDataImages.ESSENSES_IMEG selectedEssenceImage { get
            {
                if (comboBoxImagesObjects.SelectedIndex == -1) return null;
                return _essImages[comboBoxImagesObjects.SelectedIndex];
            }

        }

        public String sSelectedNameEssence
        {
            get
            {
                if (textBoxNameEssence.Text == null || textBoxNameEssence.Text.Length == 0)
                    return (selectedEssenceImage == null) ? null : selectedEssenceImage.name;
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
            foreach(SourceDataImages.ESSENSES_IMEG db in _essImages)
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
