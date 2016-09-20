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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Word=NetOffice.WordApi;
using WordEnums = NetOffice.WordApi.Enums;
using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport
{
    public partial class Form1 : Form
    {
        static string newFileSys
        {
            get
            {
                return MyFiles.dir + "//sys.dtp";
            }
        }
       
        ProjectDataHelper projectData;

        #region constructions
        public Form1():this(null)
        {
          
        }

        public Form1(String fileName) : base()
        {
            InitializeComponent();
            SourceDataImages.init();

            projectData = new ProjectDataHelper();
            projectData.rootData = treeView1.Nodes;

            Essence[] a = projectData.loadFromFile(fileName);
            if (a != null)
            {
                treeView1.Nodes.AddRange(a);
            }
            else
            {

                a = projectData.loadFromFile(newFileSys);
                if (a != null)
                {
                    treeView1.Nodes.AddRange(a);
                }
                else
                {
                    if (Program.isDebugMode)
                        loadNewTree();
                }
            }
        }
        #endregion

        public void updateShowingEssences()
        {
            ((MDIParent1)MdiParent).setState("Подготовка списков вопросов");
            Essence cEssence=null;
            bool use = false;
            for (int i = 0, l = flowLayoutPanel1.Controls.Count; i < l; i++)
            {
                Feature f = ((Question)flowLayoutPanel1.Controls[i]).feature;
                if (f.parentEssence != cEssence)
                {
                    cEssence = f.parentEssence;
                    use = f.parentEssence.isShow();
                }
                if (!use)
                {
                    flowLayoutPanel1.Controls[i].Visible = false;
                    continue;
                }

                flowLayoutPanel1.Controls[i].Visible = (f.isUsable());
            }
             ((MDIParent1)MdiParent).stateNorm();
        }

        #region events
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            setSelectedEssence((Essence)(treeView1.SelectedNode));
        }
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ProjectDataHelper.deleteTemp();
            }
            else
            {
                ProjectDataHelper.Initial.saveTemp();
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProjectDataHelper.closeProject();
        }
        #endregion

        #region private methods   
        private void setSelectedEssence(Essence eEssence)
        {
            ((MDIParent1)MdiParent).setState("Открытие обьекта");
            if (eEssence == null) return;
            eEssence.afterWishUpdateQuestions = delegate
            {
                flowLayoutPanel1.Controls.Clear();
                initShowingEssences();
                updateShowingEssences();
            };
            eEssence.afterWishUpdateQuestions();
            ((MDIParent1)MdiParent).stateNorm();
        }

        private void initShowingEssences()
        {
          //  List<Feature> allFeatures = new List<Feature>();
            Essence es = (Essence)treeView1.SelectedNode;
            //     if (es.isShowScript == null || es.isShowScript.runBool(true))
            //     allFeatures.AddRange(es.features);
            //   foreach (Essence abstrEssence in es.abstrEssences)
            //   {

            // if (abstrEssence.isShowScript != null && !abstrEssence.isShowScript.runBool(true)) continue;

            //    #region paste abstract to spec place
            //     int index = -1;
            //    foreach (Feature f in allFeatures)
            //        if (abstrEssence.idFeatureAfterShow == f.idDB) index = es.features.IndexOf(f);
            //     #endregion
            //      if (index != -1)
            //          allFeatures.InsertRange(index, abstrEssence.features);
            //      else
            //           allFeatures.AddRange(abstrEssence.features);
            //   }

            // initShowingFeatures(allFeatures);
            initShowingFeatures(getFeatures(es));
        }
        private List<Feature> getFeatures(Essence es)
        {
            List<Feature> features = new List<Feature>();
            features.AddRange(es.features);
            if (es.abstrEssences!=null)
            foreach (Essence e in es.abstrEssences)
                {
                    features.AddRange(getFeatures(e));
                }
            return features;
        }
        
        private void initShowingFeatures(List<Feature> features)
        {
            UserControl uc = null;
            Feature feature;
            for (int l = features.Count, i = 0; i < l; i++)
            {
                feature = features[i];
              
                switch (feature.typeAnswer)
                {
                    case TYPE_ANSWER.TRUE_FALSE:
                        uc = new QuestionTrueFalse(feature, i,this);
                        break;
                    case TYPE_ANSWER.STRING:
                        uc = new QuestionString(feature, i, this);
                        break;
                    case TYPE_ANSWER.NUMBER:
                        uc = new QuestionNumeric(feature, i, this);
                        break;
                    case TYPE_ANSWER.DATE:
                        uc = new QuestionDate(feature, i, this);
                        break;
                    case TYPE_ANSWER.DATE_YEAR:
                        uc = new QuestionDate(feature, i,0, this);
                        break;
                    case TYPE_ANSWER.DATE_YEAR_MOUTH:
                        uc = new QuestionDate(feature, i, 1, this);
                        break;
                    case TYPE_ANSWER.DATE_YEAR_MOUTH_DAY:
                        uc = new QuestionDate(feature, i, 2, this);
                        break;
                    case TYPE_ANSWER.DATE_YEAR_MOUTH_DAY_TIME:
                        uc = new QuestionDate(feature, i, 3, this);
                        break;
                    case TYPE_ANSWER.DATE_MOUTH_DAY_TIME:
                        uc = new QuestionDate(feature, i, 4, this);
                        break;
                    case TYPE_ANSWER.DATE_TIME:
                        uc = new QuestionDate(feature, i, 5, this);
                        break;

                    case TYPE_ANSWER.CHOOSE:
                        uc = new QuestionChoose(feature, i, this);
                        break;
                    case TYPE_ANSWER.MULTI_CHOSE:
                        uc = new QuestionMultiChoose(feature, i, this);
                        break;
                    case TYPE_ANSWER.LIST_IDS_OF_ESSENCE:
                       uc = new ControlElements.QuestionLinkEssence(feature, i,this);
                            break;              
                }
                uc.Visible = false;
                flowLayoutPanel1.Controls.Add(uc);


            }
        }

        private void loadNewTree()
        {
            List<Essence> ess;
            DBTemplatesHelper.get().fillNewProjectTree(out ess);
            projectData.rootData.AddRange(ess.ToArray());
        }
        #endregion

        private void btAddEssence_Click(object sender, EventArgs e)
        {
            ((MDIParent1)MdiParent).setState("Добавление данных");
            Forms.FormNewEssence dial = new Forms.FormNewEssence();
            dial.essImages = SourceDataImages.getEssenceImageByFlag(ESSENSE_FLAGS.MULTIPLE);

            if (dial.ShowDialog() == DialogResult.OK)
            {
                Essence es = SourceDataImages.createByImage(dial.selectedEssenceImage);
                if (dial.sSelectedNameEssence != null && dial.sSelectedNameEssence.Length != 0)
                {
                    es.sName = dial.sSelectedNameEssence;
                }
                projectData.rootData.Add(es);
            }
            ((MDIParent1)MdiParent).stateNorm();
        }

        private void btDelEssence_Click(object sender, EventArgs e)
        {

            ((MDIParent1)MdiParent).setState("Удаление данных");
            if (treeView1.SelectedNode != null)

                if (MessageBox.Show("Удалить " + treeView1.SelectedNode.Name, "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    treeView1.SelectedNode.Remove();

                }

            ((MDIParent1)MdiParent).stateNorm();
        }
        private void btEditEssence_Click(object sender, EventArgs e)
        {

            ((MDIParent1)MdiParent).setState("Редактирование данных");
            if (treeView1.SelectedNode == null)
            {
                return;
            }
            Essence es = (Essence)treeView1.SelectedNode;
            Forms.FormEditEssence dial = new Forms.FormEditEssence();
            dial.comboBoxImagesObjects.Text =SourceDataImages.getEssenceImageByID(es.idDb).name;
            dial.textBoxNameEssence.Text = es.Text;
            if (dial.ShowDialog()==DialogResult.OK)
            {
                es.Text = dial.textBoxNameEssence.Text;
            }

            ((MDIParent1)MdiParent).stateNorm();
        }


        private void btEssenceUp_Click(object sender, EventArgs e)
        {
            ((MDIParent1)MdiParent).setState("Смещение вверх");
            if (treeView1.SelectedNode != null)
            {
                int index = treeView1.SelectedNode.Index;
                if (index > 0)
                {
                    TreeNode n1 = treeView1.Nodes[index-1];
                    TreeNode sel = treeView1.SelectedNode;
                    treeView1.Nodes.Remove(n1);
                    treeView1.Nodes.Remove(sel);
                    treeView1.Nodes.Insert( index - 1,sel);
                    treeView1.Nodes.Insert( index,n1);
                    treeView1.SelectedNode = sel;
                }
            }

            ((MDIParent1)MdiParent).stateNorm();
        }

        private void btEssenceDown_Click(object sender, EventArgs e)
        {

            ((MDIParent1)MdiParent).setState("Смещение вниз");
            if (treeView1.SelectedNode != null)
            {
                int index = treeView1.SelectedNode.Index,l=treeView1.Nodes.Count;
                if (index <l-1 )
                {
                    TreeNode n1 = treeView1.Nodes[index + 1],
                        sel=treeView1.SelectedNode;
                    treeView1.Nodes.Remove(n1);
                    treeView1.Nodes.Remove(sel);
                    treeView1.Nodes.Insert(index, n1);
                    treeView1.Nodes.Insert(index+1, sel);
                    treeView1.SelectedNode = sel;
                }
                
            }
            ((MDIParent1)MdiParent).stateNorm();
        }

      
    }

}
