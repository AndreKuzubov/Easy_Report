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
using System.Text;
using System.Windows.Forms;
using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport.ControlElements
{
    public partial class QuestionLinkEssence : WFormsAppWordExport.Question
    {
        Essence selectedEssence=null;
        List<Essence> essences=new List<Essence>();
        public QuestionLinkEssence() :base()
        {
            InitializeComponent();
        }

        public QuestionLinkEssence(Feature feature,int iTableIndex,Form1 f):base(feature, iTableIndex,f)
        {
            InitializeComponent();
            updateChoose();
            if ((base.feature.isAnswered))
            {
                selectedEssence = (Essence)base.feature.answer.oAnswer;
                comboBoxLinkEssences.SelectedIndex =essences.IndexOf(selectedEssence);
            }
          
        }

        protected override void reset()
        {
            comboBoxLinkEssences.SelectedIndex = -1;
        }

        private void comboBoxLinkEssences_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLinkEssences.SelectedIndex != -1)
            {
                selectedEssence = essences[comboBoxLinkEssences.SelectedIndex];
            }
            if (selectedEssence!=null)
                setAnswer(selectedEssence,selectedEssence.sName);
        }

        private void comboBoxLinkEssences_DropDown(object sender, EventArgs e)
        {
            updateChoose();
           
        }

        private void updateChoose()
        {
            List<Essence> ess = new List<Essence>();
            if (feature.sAnswers!=null&&feature.sAnswers.Count > 0)
            {
                foreach (Choose_Answer ans in feature.sAnswers)
                {
                    ess.AddRange(ProjectDataHelper.Initial.getEssencesByImage(ans.idObject));
                }
                essences.Clear();
                essences.AddRange(ess);
                comboBoxLinkEssences.Items.Clear();
                foreach (Essence es in essences)
                {
                    comboBoxLinkEssences.Items.Add(es.Name);
                }
            }else
            {
                essences.Clear();
                comboBoxLinkEssences.Items.Clear();
                foreach (Essence es in ProjectDataHelper.Initial.rootData)
                {
                    essences.Add(es);
                    comboBoxLinkEssences.Items.Add(es.Name);
                }
             
            }
            
           
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            Forms.FormNewEssence dial = new Forms.FormNewEssence();
            #region adding images of dbObjects for chose
            List<DBTemplatesHelper.DBObject> dbObjects;
            if (feature.sAnswers != null && feature.sAnswers.Count > 0)
            {
                dbObjects = new List<DBTemplatesHelper.DBObject>();
                foreach (Choose_Answer ans in feature.sAnswers)
                {
                    dbObjects.Add(DBTemplatesHelper.DBObject.get(ans.idObject));
                }
            }
            else
            {
                dbObjects = DBTemplatesHelper.DBObject.getAll();
            }
            dial.dbObjects = dbObjects;
            #endregion

            if (dial.ShowDialog() == DialogResult.OK)
            {
                Essence es = new Essence(dial.dbSelectedObject);
                if (dial.sSelectedNameEssence != null && dial.sSelectedNameEssence.Length != 0)
                {
                    es.sName = dial.sSelectedNameEssence;
                }
                ProjectDataHelper.Initial.rootData.Add(es);
                updateChoose();
                
            }
        }
    }
}
