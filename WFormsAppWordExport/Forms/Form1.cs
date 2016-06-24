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
      
      
    //   Questions questions;
        //  List<TreeNode> roots;
        // Event ev=new Event();

       // Essence Auto;
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
                projectData.fileName = fileName;
                FileStream fileStream = new FileStream(fileName, FileMode.Open);
                BinaryFormatter serializer = new BinaryFormatter();
                Essence[] a = (Essence[])serializer.Deserialize(fileStream);
                treeView1.Nodes.AddRange(a);
                fileStream.Close();
            } else
            {
                loadNewTree();
            }

            
        }


        private void loadNewTree()
        {
            List<Essence> ess;
            List<Essence> contextEssens;
            DBTemplatesHelper.get().fillProjectTree(out ess,out contextEssens);
            projectData.rootData.AddRange(ess.ToArray());
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            setEssence((Essence)(treeView1.SelectedNode));
        }

        public void updateEssences()
        {
            Essence es = (Essence)treeView1.SelectedNode;
            updateEssences(es.features);
            foreach (Essence abstrEssence in es.abstrEssences)
            {
                updateEssences(abstrEssence.features);
            }
        }

        private void updateEssences(List<Feature> features)
        {
            for (int i=0, l=flowLayoutPanel1.Controls.Count; i<l ; i++)
            {
                flowLayoutPanel1.Controls[i].Visible = (((Question)flowLayoutPanel1.Controls[i]).feature.isUsable());
            }
        }

        private void setEssence(Essence eEssence)
        {
            if (eEssence == null) return;
            eEssence.afterWishUpdateQuestions = delegate
            {
                flowLayoutPanel1.Controls.Clear();
                initEssences();
                updateEssences();
            };
            eEssence.afterWishUpdateQuestions();
        }

        private void initEssences()
        {
            Essence es = (Essence)treeView1.SelectedNode;
            initEssences(es.features);
            foreach (Essence abstrEssence in es.abstrEssences)
            {
                initEssences(abstrEssence.features);
            }
        }

        private void initEssences(List<Feature> features)
        {
            UserControl uc = null;
            Feature feature;
            for (int l = features.Count, i = 0; i < l; i++)
            {
                feature = features[i];
              
                switch (feature.typeAnswer)
                {
                    case TYPE_ANSWER.TRUE_FALSE:
                        uc = new QuestionTrueFalse(feature, i);
                        break;
                    case TYPE_ANSWER.STRING:
                        uc = new QuestionString(feature, i);
                        break;
                    case TYPE_ANSWER.NUMBER:
                        uc = new QuestionNumeric(feature, i);
                        break;
                    case TYPE_ANSWER.DATE:
                        uc = new QuestionDate(feature, i);
                        break;
                    case TYPE_ANSWER.CHOOSE:
                        uc = new QuestionChoose(feature, i);
                        break;
                    case TYPE_ANSWER.MULTI_CHOSE:
                        uc = new QuestionMultiChoose(feature, i);
                        break;
                        //    us = new QuestionPictMultiChose(fQuestion, i);
                        //    break;              
                }
                flowLayoutPanel1.Controls.Add(uc);
                
            }
        }
    }
}
