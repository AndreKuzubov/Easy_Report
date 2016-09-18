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
using System.Data.SqlClient;
using WFormsAppWordExport.Forms;
using System.Drawing;
using System.IO;
using WFormsAppWordExport.DataStructures;
using System.Drawing.Imaging;

namespace WFormsAppWordExport
{
    public partial class UCTemplateObject : UserControl
    {
        DBTemplatesHelper db = DBTemplatesHelper.get();
        SqlDataAdapter sqlAdapter = new SqlDataAdapter();
        BindingSource bindingSource = new BindingSource();
        DBTemplatesHelper.DBObject obj;
        public FormSettingQuestionnaire parent;

        private int objId;
        public UCTemplateObject()
        {
            InitializeComponent();
            bindingNavigator1.BindingSource = bindingSource;
            dataGridView1.DataSource = bindingSource;
        }

        public void setFollowObj(int id)
        {
            this.objId = id;
            updateViewData();
        }

        private void updateViewData()
        {
            if (this.objId == -1)
            {
                obj = null;
                textBoxName.Text = "";
                comboBoxFlags.SelectedIndex = -1;
                textBoxObjScript.Text ="";
                textBoxObjIds.Text ="";
                bindingSource.DataSource=null;
            }
            else {
                obj = DBTemplatesHelper.DBObject.get(objId);
                textBoxName.Text = obj.name;
                comboBoxFlags.SelectedIndex = obj.flags;
                textBoxObjScript.Text = obj.script;
                textBoxObjIds.Text = obj.sObjects;
                db.bindingFeaturesForObjectById(bindingSource, objId);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DBTemplatesHelper.DBFeature f=new DBTemplatesHelper.DBFeature(objId);
            FormEditFeature dialog = new FormEditFeature(f, objId);
          
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                f.insertToDB(objId);
                foreach (DBTemplatesHelper.DBAnswer ans in dialog.answers)
                {
                    ans.insertAnswer(f.id);
                }
            }
            dialog.Close();
            updateViewData();
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Создайте Элемент.","База данных пуста", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = dataGridView1.CurrentCell.RowIndex;
            DBTemplatesHelper.DBFeature f=DBTemplatesHelper.DBFeature.get((int)dataGridView1.Rows[index].Cells[0].Value);
            FormEditFeature dialog =new FormEditFeature(f, objId);
            List<DBTemplatesHelper.DBAnswer> oldAnswers = DBTemplatesHelper.DBAnswer.getAnswers(f.id);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                f.updateToDB();
                foreach (DBTemplatesHelper.DBAnswer ans in oldAnswers)
                {
                    ans.deleleteFromDB();
                }
                foreach (DBTemplatesHelper.DBAnswer ans in dialog.answers)
                {
                    ans.insertAnswer(f.id);
                }
                updateViewData();
            }
            dialog.Close();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Создайте Элемент.", "База данных пуста", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int index = dataGridView1.CurrentCell.RowIndex;
            DBTemplatesHelper.DBFeature f = DBTemplatesHelper.DBFeature.get((int)dataGridView1.Rows[index].Cells[0].Value);
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                f.deleteFromDB();
            }
            updateViewData();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (obj!=null)
                obj.name = textBoxName.Text;
        }

        private void textBoxObjScript_TextChanged(object sender, EventArgs e)
        {
            if (obj != null)
                obj.script = textBoxObjScript.Text;
        }

        private void textBoxObjIds_TextChanged(object sender, EventArgs e)
        {
            if (obj != null)
                obj.sObjects = textBoxObjIds.Text;
         
        }

        private void btScript_Click(object sender, EventArgs e)
        {
            Forms.FormDevCode formDev = new FormDevCode(textBoxObjScript.Text, DataStructures.SoftwareSctipt.SCRIPT_TYPE.FUNC_BOOL);
            formDev.richTextBoxCode.Text = textBoxObjScript.Text;
            if (formDev.ShowDialog() == DialogResult.OK)
            {
                textBoxObjScript.Text = formDev.richTextBoxCode.Text;
                if (obj != null)
                    obj.script = formDev.richTextBoxCode.Text;
                formDev.Close();
            }
        }

        private void comboBoxFlags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (obj != null)
                obj.flags = comboBoxFlags.SelectedIndex;
        }

        private void tabControl2_Leave(object sender, EventArgs e)
        {
            saveToDB();
        }

        public void saveToDB()
        {
            if ( obj != null)
            {
                obj.updateToDB();
                if (parent!= null)
                    parent.updateData();
            }
        }

        private void btAbstObjects_Click(object sender, EventArgs e)
        {
            #region prepere params before call dialog
            Forms.FormSelectItemsList fDialog = new FormSelectItemsList();
            List<Forms.FormSelectItemsList.Para> selected = new List<FormSelectItemsList.Para>();
            List<Forms.FormSelectItemsList.Para> unSelected = new List<FormSelectItemsList.Para>();
            {
                int[] ids = ConvertFormat.stringToArray(textBoxObjIds.Text);
                if (ids != null && ids.Length > 0)
                {
                    foreach (int idObj in ids)
                    {
                        DBTemplatesHelper.DBObject dbObj = DBTemplatesHelper.DBObject.get(idObj);
                        FormSelectItemsList.Para p = new FormSelectItemsList.Para();
                        p.text = dbObj.name;
                        p.id = dbObj.id;
                        selected.Add(p);
                    }
                }
            }
            List<DBTemplatesHelper.DBObject> dbObjs = DBTemplatesHelper.get().getObjects();
            foreach (DBTemplatesHelper.DBObject dbObj in dbObjs)
            {
                FormSelectItemsList.Para p = new FormSelectItemsList.Para();
                p.text = dbObj.name;
                p.id = dbObj.id;
                if (!selected.Contains(p))
                    unSelected.Add(p);
            }
            #endregion

            fDialog.set(selected, unSelected);
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                List<int> idsO=new List<int>();
                foreach (FormSelectItemsList.Para p in fDialog.listBoxSelected.Items)
                {
                    idsO.Add(p.id);
                }

                obj.sObjects = ConvertFormat.arrayToString(idsO.ToArray());
                textBoxObjIds.Text = obj.sObjects;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region SourceDataImage.cs
            {
                String createAllImages = "";
                String createAllFeatureImages = "";
                String addFeaturesToEssence = "";
                String createAllChooseAnswers = "";

                String methods = "";


                #region allImages     
                {
                    List<DBTemplatesHelper.DBObject> allDBObjects = DBTemplatesHelper.DBObject.getAll();
                    createAllImages = "new ESSENSES_IMEG[]{";
                    string d = "";
                    foreach (DBTemplatesHelper.DBObject obj in allDBObjects)
                    {
                        createAllImages += d + "new  ESSENSES_IMEG(" + obj.id + ",\"" + obj.name + "\", " + obj.flags + "," +
                            ((obj.script == null || obj.script.Length==0 || obj.script.Equals("null")) ? "null" :"@\"" +obj.script.Replace("\"", "\"+\"\\\"\"+@\"") + "\"")
                            + "," + ((obj.sObjects == null) ? "null" : "new int []{ " + obj.sObjects+"}")+")";
                        d = ",";
                    }
                    createAllImages += "};";
                }
                #endregion

                #region allDBAnswer     
                {
                    List<DBTemplatesHelper.DBAnswer> allDBAnswer = DBTemplatesHelper.DBAnswer.getAnswers();
                    foreach (DBTemplatesHelper.DBAnswer chAns in allDBAnswer)
                    {
                        string im = "null";
                        String fileName = "null";
                        if (chAns.image != null)
                        {
                            fileName = MyFiles.dir + "\\images\\" + chAns.sName + ".bmp";


                            chAns.image.Save(fileName, ImageFormat.Bmp);

                            im = "getImageFromFile(\"" + chAns.sName + ".bmp" + "\")";
                        }

                          createAllChooseAnswers += " allChooceAnswer.Add(" + chAns.id + ",new Choose_Answer(" + chAns.id + ",\"" + chAns.sName + "\"," + chAns.pos + ","+im+"," +
                          chAns.idObject + "));\n";

                    }
                }
                #endregion

                #region allFeatures
                {
                    List<DBTemplatesHelper.DBFeature> allFeatures = DBTemplatesHelper.DBFeature.getFeatures();
                    createAllFeatureImages = "";
                    foreach (DBTemplatesHelper.DBFeature f in allFeatures)
                    {
                        List<DBTemplatesHelper.DBAnswer> chAnswers = DBTemplatesHelper.DBAnswer.getAnswers(f.id);
                        String idAnswers = "null";
                        if (chAnswers != null)
                        {
                            idAnswers = "new int[]{";
                            string div = "";
                            for (int i = 0; i < chAnswers.Count; i++)
                            {
                                idAnswers += div + chAnswers[i].id;
                                div = ",";
                            }
                            idAnswers += "}";
                        }

                        //FEATURE_IMAGE(int idDB,String sQuestion,int typeAnswer,int [] idAnswers,string isUse, string after)
                        createAllFeatureImages += "allFeatureImages.Add("+f.id+",new  FEATURE_IMAGE(" + f.id + ",\""+ f.sQuestion + "\", " 
                            + (int)f.type + "," + idAnswers 
                            + ","+ ((f.scriptCondition!=null && f.scriptCondition.Length>0)? " @\"" + f.scriptCondition.Replace("\"", "\"+\"\\\"\"+@\"")+"\"" : "null")
                            + "," + ((f.scriptAfter!=null && f.scriptAfter.Length > 0 ) ? " @\"" + f.scriptAfter.Replace("\"", "\"+\"\\\"\"+@\"")+"\"" :"null") + ") );\n";

                    }
                }
                #endregion

                #region addFeaturesToEssence 
                {
                    //List<Feature> features = new List<Feature>();
                    List<DBTemplatesHelper.DBObject> dbObjects = DBTemplatesHelper.DBObject.getAll();
                    string caseCall = "";
                    foreach (DBTemplatesHelper.DBObject dbObject in dbObjects)
                    {
                        caseCall += "case " + dbObject.id + ":" + " obj" + dbObject.id + "(es,features);" + "\n break;\n";
                        methods += " private static void obj" + dbObject.id + "(Essence es,List<Feature> features){";
                        List<DBTemplatesHelper.DBFeature> features = DBTemplatesHelper.DBFeature.getFeatures(dbObject.id);

                        foreach (DBTemplatesHelper.DBFeature f in features)
                        {
                            methods += "\u000A  features.Add(allFeatureImages[" + f.id + "].getFeature(es));";
                        }
                        methods += "}\n";

                    }




                    addFeaturesToEssence += @"
            switch ( image.dbId)
            {" +
                caseCall
                + @"} 
";

                }
                #endregion

                String code = @"
/**
AutoGenereted code by UCTemplateObject.cs

 Copyright 2016 Andrey Kuzubov

Licensed under the Apache License, Version 2.0 (the License);
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an AS IS BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport
{
    public static class SourceDataImages
    {


        public class ESSENSES_IMEG
        {
            public String name { get; }
            public int dbId { get; }
            public int[] abstEssences { get; }
            public int flag { get; }
            public String script { get; }
            public ESSENSES_IMEG(int dbID, String name, int flag,String script, int[] abstEssencesIDS)
            {
                this.dbId = dbID;
                this.name = name;
                this.flag = flag;
                this.script = script;
                this.abstEssences = abstEssencesIDS;

            }

        }

        public class FEATURE_IMAGE
        {
            public int[] idAnswers;
            public int idDB = -1;
            public String sQuestion;
            public int typeAnswer;
          
          
            private String isUse = null;
            private String after = null;

            public FEATURE_IMAGE(int idDB,String sQuestion,int typeAnswer,int [] idAnswers,string isUse, string after)
            {
                this.idDB = idDB;
                this.sQuestion = sQuestion;
                this.typeAnswer = typeAnswer;
                this.idAnswers = idAnswers;
                this.isUse = isUse;
                this.after = after;
            }

            public Feature getFeature (Essence es)
            {
                List<Choose_Answer> sAnswers = null;
                if (idAnswers != null)
                {
                    sAnswers= new List<Choose_Answer>();
                    foreach (int idAn in idAnswers)
                    {
                        sAnswers.Add(allChooceAnswer[idAn]);
                    }
                }
                return new Feature(es, idDB, sQuestion, sAnswers,(TYPE_ANSWER) typeAnswer, isUse, after);
            }
        }



        public static ESSENSES_IMEG[] allImageEssences { get; } = " + createAllImages + @"

         public static Dictionary<int, FEATURE_IMAGE> allFeatureImages = new Dictionary<int, FEATURE_IMAGE>();

        public static Dictionary<int, Choose_Answer> allChooceAnswer = new Dictionary<int, Choose_Answer>();

        public static void init()
        {" +
     createAllChooseAnswers +
     createAllFeatureImages
    + @"}


        public static Essence createByImage(ESSENSES_IMEG image)
        {
           
         
            Essence es = new Essence(image.dbId, image.name, (ESSENSE_FLAGS)image.flag, image.script, null, null);

            if (image.abstEssences != null)
            {
                foreach (int abstrImID in image.abstEssences)
                {
                    Essence child=createByImage(getEssenceById(abstrImID));
                    es.abstrEssences.Add(child);
                    child.parentEssence = es;
                }
            }

            List<Feature> features = new List<Feature>();
 
" +
    addFeaturesToEssence
    +
    @"
        
           
            es.features = features;
            return es;

        }

        public static List<ESSENSES_IMEG> getEssenceImageByFlag(ESSENSE_FLAGS flag)
        {
            List<ESSENSES_IMEG> result = new List<ESSENSES_IMEG>();
            foreach (ESSENSES_IMEG esIm in allImageEssences)
            {
                if ((esIm.flag & (int)flag) == (int)flag) result.Add(esIm);
            }
            return result;
        }
        
        public static ESSENSES_IMEG getEssenceImageByID (int id)
        {
         
            foreach (ESSENSES_IMEG esIm in allImageEssences)
            {
                if (esIm.dbId ==id)  return esIm;
            }
            return null;
        }



        private static ESSENSES_IMEG getEssenceById(int id)
        {
            foreach (ESSENSES_IMEG im in allImageEssences)
                if (im.dbId == id) return im;
            return null;
        }

        private static Image getImageFromFile(String idNameIfImage)
        {
            String fileName =  MyFiles.dir+" + "\"\\\\images\\\\\" " + @"+ idNameIfImage;
            return Image.FromFile(fileName);
        }

        " + methods + @"

    }


}
";
                StreamWriter outStriam = File.CreateText(MyFiles.dir+"\\"+"SourceDataImages.cs");
                outStriam.Write(code);
                outStriam.Close();
            }
            #endregion

            #region Exporter.cs
            {
                String addParagraphs = "";

                List<DBTemplatesHelper.DBParagraph> paragraphs = DBTemplatesHelper.DBParagraph.getAllParagraphs();
                foreach (DBTemplatesHelper.DBParagraph paragraph in paragraphs)
                {
                   
                    addParagraphs += "paragraphs.Add(new DBTemplatesHelper.DBParagraph("+paragraph.id+","+ paragraph.flag+","
                        +((paragraph.text!=null && paragraph.text.Length>0)?"@\""+paragraph.text.Replace("\"", "\"+\"\\\"\"+@\"") +"\"": "null")+"));\n ";
                }
              




                String code = @"
/**
AutoGenereted code by UCTemplateObject.cs

 Copyright 2016 Andrey Kuzubov

Licensed under the Apache License, Version 2.0 (the License);
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an AS IS BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using System;
                using System.Collections.Generic;
                using System.Text;
                using System.IO;
                using Word = NetOffice.WordApi;
                using WordEnums = NetOffice.WordApi.Enums;
                using System.Windows.Forms;
                using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport
    {
        public static class Exporter
        {




            public static void exportAll(String filename)
            {
                 List<DBTemplatesHelper.DBParagraph> paragraphs = new List<DBTemplatesHelper.DBParagraph>();

"+
addParagraphs
+@"

                RTFHelpener rtfHelper = new RTFHelpener(findText(paragraphs));
                foreach (DBTemplatesHelper.DBParagraph p in paragraphs)
                {
                    SoftwareSctipt scrip;
                    if (p.flag == 0)
                    {
                        scrip = new SoftwareSctipt(p.text, SoftwareSctipt.SCRIPT_TYPE.STRING);
                        rtfHelper.replaceScriptToText(p.id, scrip.runString(" + "\"no script\""+@"));
                    }
                }


                Word.Application app = new Word.Application();
                app.Visible = false;
                Word.Document doc;
                Object template = null;
                Object newTemplate = false;
                Object documentType = 0;
                Object visible = false;


                doc = app.Documents.Add(template, newTemplate, documentType, visible);
                doc.Activate();
                Clipboard.SetText(rtfHelper.Rtf, TextDataFormat.Rtf);
                app.Selection.Paste();

                doc.SaveAs2(filename, 16, false, Type.Missing, false,
                 Type.Missing, false, false, false, false, false, 0,
                 false, false, true);
                app.Quit(0, 0, false);

            }

            private static String findText(List<DBTemplatesHelper.DBParagraph> paragraphs)
            {
                foreach (DBTemplatesHelper.DBParagraph p in paragraphs)
                {
                    if (p.flag == 1)
                    {
                        return p.text;
                    }
                }
                return "+"\"\""+@";
            }

        }
    }
";

                StreamWriter outStriam = File.CreateText(MyFiles.dir + "\\" + "Exporter.cs");
                outStriam.Write(code);
                outStriam.Close();
            }
            #endregion

        }
    }
}
