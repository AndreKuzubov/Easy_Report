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
