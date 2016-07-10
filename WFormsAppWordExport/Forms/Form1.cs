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
       
        ProjectDataHelper projectData;

        #region constructions
        public Form1():this(null)
        {
          
        }

        public Form1(String fileName) : base()
        {
            InitializeComponent();
            projectData = new ProjectDataHelper();
            projectData.rootData = treeView1.Nodes;
            if (File.Exists(fileName))
            {
                FileStream fileStream = null; ;
                try
                {
                    projectData.fileName = fileName;
                    fileStream = new FileStream(fileName, FileMode.Open);
                    BinaryFormatter serializer = new BinaryFormatter();
                    Essence[] a = (Essence[])serializer.Deserialize(fileStream);
                    treeView1.Nodes.AddRange(a);
                   
                }catch (System.Runtime.Serialization.SerializationException ex)
                {
                    throw ex;
                }
                finally
                {
                    if (fileStream!=null)
                        fileStream.Close();
                }
               
            } else
            {
                loadNewTree();
            }

            
        }
        #endregion

        public void updateShowingEssences()
        {
            Essence es = (Essence)treeView1.SelectedNode;
            updateShowingFeatures(es.features);
            foreach (Essence abstrEssence in es.abstrEssences)
            {
                updateShowingFeatures(abstrEssence.features);
            }
        }

        #region events
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            setSelectedEssence((Essence)(treeView1.SelectedNode));
        }
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            ProjectDataHelper.closeProject();
        }
        #endregion

        #region private methods
        private void updateShowingFeatures(List<Feature> features)
        {
            for (int i = 0, l = flowLayoutPanel1.Controls.Count; i < l; i++)
            {
                flowLayoutPanel1.Controls[i].Visible = (((Question)flowLayoutPanel1.Controls[i]).feature.isUsable());
            }
        }
    
        private void setSelectedEssence(Essence eEssence)
        {
            if (eEssence == null) return;
            eEssence.afterWishUpdateQuestions = delegate
            {
                flowLayoutPanel1.Controls.Clear();
                initShowingEssences();
                updateShowingEssences();
            };
            eEssence.afterWishUpdateQuestions();
        }

        private void initShowingEssences()
        {
            List<Feature> allFeatures = new List<Feature>();
            Essence es = (Essence)treeView1.SelectedNode;
            allFeatures.AddRange(es.features);
            foreach (Essence abstrEssence in es.abstrEssences)
            {
                #region paste abstract to spec place
                int index = -1;
                foreach (Feature f in allFeatures)
                    if (abstrEssence.idFeatureAfterShow == f.idDB) index = es.features.IndexOf(f);
                #endregion
                if (index!=-1)
                    allFeatures.InsertRange(index, abstrEssence.features);          
                else
                    allFeatures.AddRange(abstrEssence.features);
            }
            initShowingFeatures(allFeatures);
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
            Forms.FormNewEssence dial = new Forms.FormNewEssence();
            dial.dbObjects = DBTemplatesHelper.DBObject.getByFlag((int)ESSENSE_FLAGS.MULTIPLE);
            if (dial.ShowDialog() == DialogResult.OK)
            {
                Essence es = new Essence(dial.dbSelectedObject);
                if (dial.sSelectedNameEssence != null && dial.sSelectedNameEssence.Length != 0)
                {
                    es.sName = dial.sSelectedNameEssence;
                }
                projectData.rootData.Add(es);
            }
        }

        private void btDelEssence_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)

                if (MessageBox.Show("Удалить " + treeView1.SelectedNode.Name, "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    treeView1.SelectedNode.Remove();

                }
        }
        private void btEditEssence_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                return;
            }
            Essence es = (Essence)treeView1.SelectedNode;
            Forms.FormEditEssence dial = new Forms.FormEditEssence();
            dial.comboBoxImagesObjects.Text = DBTemplatesHelper.DBObject.get(es.idDb).name;
            dial.textBoxNameEssence.Text = es.Text;
            if (dial.ShowDialog()==DialogResult.OK)
            {
                es.Text = dial.textBoxNameEssence.Text;
            }
        }


        private void btEssenceUp_Click(object sender, EventArgs e)
        {
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
        }

        private void btEssenceDown_Click(object sender, EventArgs e)
        {
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
        }

       
    }

}
