using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport.Forms
{
    public partial class FormEditFeature : Form
    {
        private int _idAssociatedObject=0;
        private DBTemplatesHelper.DBFeature _feature=new DBTemplatesHelper.DBFeature();
        public DBTemplatesHelper.DBFeature feature { get { return _feature; } set { _feature = value; updateView(); } }
        public int idAssociatedObject { get { return _idAssociatedObject; } set { _idAssociatedObject = value; updateView(); } }

        public FormEditFeature()
        {
            InitializeComponent();
        }

        public FormEditFeature(DBTemplatesHelper.DBFeature feature,int idAssociatedObject) : this()
        {
            this.feature = feature;
            this.idAssociatedObject = idAssociatedObject;
        }

        private void updateView()
        {
            textBoxQuestion.Text = feature.sQuestion;
            comboBoxType.SelectedIndex = feature.type;
            comboBoxAfterQuestion.Items.Clear();
            List<DBTemplatesHelper.DBFeature> dbFeatures=DBTemplatesHelper.DBFeature.getFeatures(idAssociatedObject);
            for (int i=0,l=dbFeatures.Count;i< l; i++)
            {
                comboBoxAfterQuestion.Items.Add(dbFeatures[i].sQuestion);
            }
            comboBoxAfterQuestion.SelectedIndex = dbFeatures.Count - 1;
            textBoxScriptCondition.Text = feature.scriptCondition;
            textBoxScriptAfterAnswer.Text = feature.scriptAfter;

        }

        private void btOk_Click(object sender, EventArgs e)
        {
            feature.sQuestion = textBoxQuestion.Text;
            feature.type=comboBoxType.SelectedIndex;
            feature.pos=comboBoxAfterQuestion.SelectedIndex;
            feature.scriptCondition=textBoxScriptCondition.Text;
            feature.scriptAfter=textBoxScriptAfterAnswer.Text;

            DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btAnswers_Click(object sender, EventArgs e)
        {

        }
    }
}
