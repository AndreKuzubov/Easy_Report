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
        public static TreeNodeCollection rootData;
        String fileName=null;
      
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
            rootData = treeView1.Nodes;
            if (File.Exists(fileName))
            {
                this.fileName = fileName;
                FileStream fileStream = new FileStream(fileName, FileMode.Open);
                BinaryFormatter serializer = new BinaryFormatter();
                Essence[] a = (Essence[])serializer.Deserialize(fileStream);
                for (int i = 0; i < a.Length; i++)
                {
               //     a[i].OnDeserial();
                }

                treeView1.Nodes.AddRange(a);
                fileStream.Close();
                //Auto = (Essence)a[1];


            } else
            {
                loadNewTree();
            }

            
        }

        public void saveToFile(String fileName)
        {
            this.fileName = fileName;
            int len = treeView1.Nodes.Count;
            Essence[] eEssences = new Essence[len];
            for (int i=0;i< len; i++)
            {
                eEssences[i] = (Essence)treeView1.Nodes[i];
            }
            FileStream fileStream;
            if (File.Exists(fileName))
                fileStream = new FileStream(fileName, FileMode.Truncate);
            else fileStream = new FileStream(fileName, FileMode.CreateNew);

            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fileStream, eEssences);
            fileStream.Close();
        }

        public bool saveToFile()
        {
            if (fileName == null ) return false;
            saveToFile(fileName);
            return true;
        }

        public void exportDoc(String filename)
        {
            Word.Application app = new Word.Application();
            app.Visible = false;
            Word.Document doc;

            Object template = MyFiles.getMyTemplate();
            Object newTemplate = false;
            Object documentType = 0;
            Object visible = false;

         
            doc = app.Documents.Add(
            template,  newTemplate,  documentType,  visible);
           doc.Activate();

            Exporter.exportAll(app, treeView1.Nodes);
           
             
            doc.SaveAs2(filename, 16, false, Type.Missing, false,
               Type.Missing, false, false, false, false, false, 0,
               false, false, true);
            app.Quit(0, 0, false);


        }

        private void loadNewTree()
        {
            List<Essence> ess;
            List<Essence> contextEssens;
            DBTemplatesHelper.get().fillProjectTree(out ess,out contextEssens);
            rootData.AddRange(ess.ToArray());
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
