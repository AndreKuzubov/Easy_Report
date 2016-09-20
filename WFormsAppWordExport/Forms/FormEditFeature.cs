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
using System.Windows.Forms;
using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport.Forms
{
    public partial class FormEditFeature : Form
    {
        private int _idAssociatedObject=0;
        private DBTemplatesHelper.DBFeature _feature=new DBTemplatesHelper.DBFeature(-1);
        private List<DBTemplatesHelper.DBFeature> dbFeatures;
        private int _holeIndex=-1;

        public DBTemplatesHelper.DBFeature feature
        {
            get { return _feature; }
            set
            {
                _feature = value; answers = DBTemplatesHelper.DBAnswer.getAnswers(feature.id); updateView();
            }
        }
        public List<DBTemplatesHelper.DBAnswer> answers = new List<DBTemplatesHelper.DBAnswer>();
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
            #region set work mode of type feature condition  
            comboBoxType.SelectedIndex = (int)feature.type;
            if (feature.type == TYPE_ANSWER.CHOOSE || feature.type == TYPE_ANSWER.MULTI_CHOSE
                || feature.type == TYPE_ANSWER.STRING || feature.type == TYPE_ANSWER.LIST_IDS_OF_ESSENCE)
            {
                btAnswers.Enabled = true;
            }
            else btAnswers.Enabled = false;
            #endregion

            #region set combobox position of feature 
            comboBoxAfterQuestion.Items.Clear();
            dbFeatures = DBTemplatesHelper.DBFeature.getFeatures(idAssociatedObject);
            comboBoxAfterQuestion.Items.Add("вставить вначале");
            int selectIndex = 0;
            if (dbFeatures != null && dbFeatures.Count > 0)
            {
               
                for (int i = 0, l = dbFeatures.Count; i < l; i++)
                {
                    if (dbFeatures[i].pos == feature.pos)
                    {
                        _holeIndex = i;
                        continue;
                    }
                    comboBoxAfterQuestion.Items.Add(dbFeatures[i].sQuestion);
                    if (dbFeatures[i].pos < feature.pos) selectIndex = i + 1;
                }
                
            }
            comboBoxAfterQuestion.SelectedIndex = selectIndex;
            #endregion

            textBoxScriptCondition.Text = feature.scriptCondition;
            textBoxScriptAfterAnswer.Text = feature.scriptAfter;
            
        }

        private void btOk_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btAnswers_Click(object sender, EventArgs e)
        {
            FormEditChooseAnswers formChooseAnswers = new FormEditChooseAnswers();

            #region prepare Form
            formChooseAnswers.chooseAnswers = answers;
            if (feature.type == TYPE_ANSWER.STRING)
            {
                formChooseAnswers.btImport.Enabled = false;
                formChooseAnswers.cbObj.Enabled = false;
            }
            if (feature.type == TYPE_ANSWER.CHOOSE || feature.type == TYPE_ANSWER.MULTI_CHOSE)
            {
                formChooseAnswers.btImport.Enabled = true;
                formChooseAnswers.cbObj.Enabled = false;
            }
            if (feature.type == TYPE_ANSWER.LIST_IDS_OF_ESSENCE)
            {
                formChooseAnswers.btImport.Enabled = false;
                formChooseAnswers.cbObj.Enabled = true;
                formChooseAnswers.textBoxExportName.Enabled = false;
                formChooseAnswers.tbQuestionName.Enabled = false;
                List <DBTemplatesHelper.DBObject> objects = DBTemplatesHelper.get().getObjects();
                foreach (DBTemplatesHelper.DBObject obj in objects)
                {
                    formChooseAnswers.cbObj.Items.Add(obj.name);
                    formChooseAnswers.ObjIds.Add(obj.id);
                }
                
            }
            #endregion

           
            if (formChooseAnswers.ShowDialog() == DialogResult.OK)
            {
                answers = formChooseAnswers.chooseAnswers;
            }
           

        }

        private void btConditionScript_Click(object sender, EventArgs e)
        {
            FormDevCode formDevCode = new FormDevCode(textBoxScriptCondition.Text,SoftwareSctipt.SCRIPT_TYPE.FUNC_BOOL);
            if (formDevCode.ShowDialog() == DialogResult.OK)
            {
                textBoxScriptCondition.Text = formDevCode.textCode;
                formDevCode.Close();
                feature.scriptCondition = textBoxScriptCondition.Text;
            }
        }

        private void btAfterScript_Click(object sender, EventArgs e)
        {
            FormDevCode formDevCode = new FormDevCode(textBoxScriptAfterAnswer.Text, SoftwareSctipt.SCRIPT_TYPE.VOID);
            if (formDevCode.ShowDialog() == DialogResult.OK)
            {
                textBoxScriptAfterAnswer.Text = formDevCode.textCode;
                formDevCode.Close();
                feature.scriptAfter = textBoxScriptAfterAnswer.Text;
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            feature.type = (TYPE_ANSWER)comboBoxType.SelectedIndex;
            updateView();
        }

        private void comboBoxAfterQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int iSelect = comboBoxAfterQuestion.SelectedIndex;
            if (iSelect > 0)
            {
                if (iSelect <_holeIndex)
                    feature.pos = dbFeatures[iSelect - 1].pos + 1;
                else
                      if (iSelect < dbFeatures.Count)
                    feature.pos = dbFeatures[iSelect].pos + 1;
            }
            else {
                if (dbFeatures.Count>0)
                feature.pos = dbFeatures[0].pos - 1;
                else
                {
                    feature.pos=0;
                }
            }


        }

        private void textBoxQuestion_TextChanged(object sender, EventArgs e)
        {
            feature.sQuestion = textBoxQuestion.Text;
        }
    }
}
