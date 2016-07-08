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
using Word = NetOffice.WordApi;
using WordEnums = NetOffice.WordApi.Enums;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using WFormsAppWordExport.DataStructures;
using System.Collections;
using System.Reflection;


namespace WFormsAppWordExport.Forms
{
    public partial class FormDevCode : Form
    {
        public SoftwareSctipt.SCRIPT_TYPE typeMethod = SoftwareSctipt.SCRIPT_TYPE.STRING;
        public String textCode
        {
            get { if (richTextBoxCode != null) return richTextBoxCode.Text; else return null; }
            set { if (richTextBoxCode != null) richTextBoxCode.Text = value; }
        }



        public FormDevCode(String script, SoftwareSctipt.SCRIPT_TYPE typeMethod) : this()
        {
            this.richTextBoxCode.Text = script;
            this.typeMethod = typeMethod;
        }

        public FormDevCode()
        {
            InitializeComponent();
            loadDataWordsToProject();
            autocompleteMenuCode.MaximumSize = new System.Drawing.Size(600, 200);
        }

        /*    private void button4_Click(object sender, EventArgs e)
            {
                String s= richTextBoxCode.Rtf;
              //  richTextBox1.
       //        richTextBox1
            }

            private void button2_Click(object sender, EventArgs e)
            {
                Word.Application app = new Word.Application();
                app.Visible = true;
                Word.Document doc;
                Object template = MyFiles.getMyTemplate();
                Object newTemplate = false;
                Object documentType = 0;
                Object visible = true;


                doc = app.Documents.Add(
                template, newTemplate, documentType, visible);
                doc.Activate();
                Clipboard.SetText(richTextBoxCode.Text, TextDataFormat.Rtf);
                app.Selection.Paste();

            }*/

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            CompilerResults result = DataStructures.SoftwareSctipt.compile(richTextBoxCode.Text, typeMethod);
            if (result == null || result.Errors.Count == 0)
                this.DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show("Исправте код, либо нажмите отмена", "Ошибка в коде", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btErase_Click(object sender, EventArgs e)
        {
            richTextBoxCode.Clear();
        }

        private void btCompile_Click(object sender, EventArgs e)
        {
            CompilerResults result = DataStructures.SoftwareSctipt.compile(richTextBoxCode.Text, typeMethod);
            extendedTextBoxResult.Clear();


            if (result != null)
                if (result.Errors != null && result.Errors.Count > 0)
                    foreach (CompilerError s in result.Errors)
                        extendedTextBoxResult.Text += (s.Line - 18) + " : " + s.ErrorText + " " + s.FileName + "\n";
                else
                {
                    extendedTextBoxResult.Text += "success";
                }
        }

        #region autocompletemenu 
        private MyMultiDictionary myMultiDictionary = new MyMultiDictionary();

        private void autocompleteMenuCode_MenuShowing(object sender, EventArgs e)
        {
            autocompleteMenuCode.Items = null;
            String suggestion = getSuggestion();

            int flag = getFlag(suggestion);
            if (flag == 0)
            {
                #region  get fields 
                FieldInfo[] fields;
                MethodInfo[] methods;
                getFieldsMethods(suggestion, out fields, out methods);
                addToMenu(fields, methods);

                #endregion
            }
            else if (flag == -1)
            {
                #region get all available  data 
                FieldInfo[] fields;
                MethodInfo[] methods;
                getFieldsMethods(null, out fields, out methods);

                addToMenu(fields, methods);
                #endregion
            }
            else
            {
                #region get expected data
                int[] address = getAddress(suggestion);
                if (address == null || address.Length == 0)
                {
                    //show all
                    List<CompleteItem> lis = myMultiDictionary.getValues();
                    foreach (CompleteItem c in lis)
                    {
                        autocompleteMenuCode.AddItem(new AutocompleteMenuNS.MulticolumnAutocompleteItem(new String[] { c.toExport, c.description }, c.toExport));
                    }
                }
                else
                {
                    List<CompleteItem> lis = myMultiDictionary.getValues(address);
                    foreach (CompleteItem c in lis)
                    {
                        autocompleteMenuCode.AddItem(new AutocompleteMenuNS.MulticolumnAutocompleteItem(new String[] { c.toExport, c.description }, c.toExport));
                    }
                }
                #endregion

            }
        }

        private void addToMenu(FieldInfo [] fields,MethodInfo[] methods)
        {
            foreach (FieldInfo field in fields)
            {
                autocompleteMenuCode.AddItem(new AutocompleteMenuNS.MulticolumnAutocompleteItem(new string[] { field.Name, field.FieldType.Name }, field.Name));
            }
            foreach (MethodInfo method in methods)
            {
                String description =/* "(" + method.DeclaringType.Name + ")" +*/ method.ReturnType.Name + "(",sParams="";
                ParameterInfo[] parametrs = method.GetParameters();
                String d = "";

                foreach (ParameterInfo p in parametrs)
                {
                    description += d + p.ParameterType + " " + p.Name;
                    sParams += d + p.Name;
                    d = ",";
                }
                description += ")";
                autocompleteMenuCode.AddItem(new AutocompleteMenuNS.MulticolumnAutocompleteItem(
                    new string[] { method.Name, description }, method.Name + "("+sParams+")"));
            }
        }

        private int[] getAddress(String suggention)
        {
            return DBTemplatesHelper.DBWord.getAddress(suggention);
        }

        private String getSuggestion()
        {
            if (richTextBoxCode.TextLength <= 1) return null;

            String text = richTextBoxCode.Text;
            int startIndex = richTextBoxCode.SelectionStart - 1;
            int i;
            for (i = startIndex; i > 0 && text[i] != ' '; --i) ;
            if (text[i] == ' ') ++i;

            return text.Substring(i, startIndex - i + 1);
        }

        private int getFlag(String sug)
        {
            int k = 0;
            if (sug == null || sug.Length < 2) return -1;
            for (int i = sug.Length - 1; i > 0; i--)
            {
                if (sug[i] == '.') return 0;
                if (sug[i] == ',') ++k;
                if (sug[i] == '(') return k + 1;
            }
            return -1;
        }

        private DBTemplatesHelper.DBWord getWord(String suggestion)
        {
            return DBTemplatesHelper.DBWord.getFromSuggestion(suggestion);
        }
      
        private void getFieldsMethods(String sep,out FieldInfo[]  Fields,out MethodInfo[] Methods)
        {
            Type currentType = typeof(ScriptSandBox);
            if (sep == null)
            {

                Fields = currentType.GetFields();
                Methods = currentType.GetMethods();
                return;
            }
            else
            {
                Fields = null;
                Methods = null;
                String[] w = sep.Split('.');
                int i = 0, l = w.Length;
                if (w[l - 1].Length == 0) --l;
                for (; i < l; i++)
                {
                    if (w[i].IndexOf('(') != -1)
                    {
                        int iSt = w[i].IndexOf('('), iEnd = w[i].IndexOf(')');
                        if (iEnd < iSt) return;
                        MethodInfo method = currentType.GetMethod(w[i].Substring(0, iSt - 1));
                        if (method == null) return;
                        currentType = method.ReturnType;

                    }
                    else
                    {
                        currentType = currentType.GetField(w[i]).FieldType;
                        if (currentType == null) return;
                    }
                }

                Fields = currentType.GetFields();
                Methods = currentType.GetMethods();
                return ;
            }
        }


        #region complate data from project 

        private void loadDataWordsToProject()
        {
            List<DBTemplatesHelper.DBObject> dbOs = DBTemplatesHelper.DBObject.getAll();
            foreach (DBTemplatesHelper.DBObject dbO in dbOs)
            {
                CompleteItem item = new CompleteItem()
                {
                    description = dbO.name,
                    toExport = "DataProject.getEssencesByIdDB(" + dbO.id + ")"
                };
                myMultiDictionary.Add(new int[] {dbO.id}, item);
                loadFeatures(dbO.id);
            }


        }
        
        private void loadFeatures(int address)
        {
              List<DBTemplatesHelper.DBFeature> dbFs= DBTemplatesHelper.DBFeature.getFeatures(address);
            foreach (DBTemplatesHelper.DBFeature dbF in dbFs)
            {
                CompleteItem item = new CompleteItem()
                {
                    description = dbF.sQuestion,
                    toExport = "DataProject.getFeaturesByAddress(new int[] {" + address + "," + dbF.id + "})"
                };
                myMultiDictionary.Add(new int[] { address, dbF.id },item);
                loadAnswers( new int[] { address, dbF.id });
            } 
        }

        private void loadAnswers(int[] address)
        {
            List<DBTemplatesHelper.DBAnswer> dbAs = DBTemplatesHelper.DBAnswer.getAnswers(address[address.Length-1]);
            foreach (DBTemplatesHelper.DBAnswer dbA in dbAs)
            {
                CompleteItem item = new CompleteItem()
                {
                    description = dbA.sName,
                    toExport = "DataProject.getAnswersByAddress(new int[] { " + address[0] + "," + address[1] + "," + dbA.id + " } )"
                };
                myMultiDictionary.Add(new int[] { address[0], address[1], dbA.id },item);
            }
        }
        #endregion

        #region myTypes


        struct CompleteItem
        {


            public String description;
            public String toExport;


        }

        class MyMultiDictionary : Dictionary<int, List<CompleteItem>>
        {
            //int[] key;

            public void Add(int[] address, CompleteItem e)
            {
                int key = f(address);
                if (base.ContainsKey(key))
                {
                    base[key].Add(e);
                }
                else
                {
                    List<CompleteItem> list = new List<CompleteItem>();
                    list.Add(e);
                    base.Add(key, list);
                }
            }
            public List<CompleteItem> getValues(int[] address)
            {
                int key = f(address);
                return base[key];
            }

            public List<CompleteItem> getValues()
            {
                List<CompleteItem> list = new List<CompleteItem>();
                foreach (List<CompleteItem> lists in Values)
                {
                    list.AddRange(lists);
                }
                return list;
            }

            private int f(int[] key)
            {
                int a = 0;
                for (int i = 0; i < key.Length; i++)
                {
                    a = key[i] + (10000 * i);
                }
                return a;
            }



            /*public override int GetHashCode()
            {
                int a = 0;
                for (int i = 0; i < key.Length; i++)
                {
                    a = key[i] + (10000 * i);
                }
                return a;
            }*/
        }

        class ScriptSandBox
        {
            public ProjectDataHelper DataProject;
        }



        #endregion

        #endregion

       
    }


}

