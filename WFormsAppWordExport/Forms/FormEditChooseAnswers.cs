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
using System.Windows.Forms;
using WFormsAppWordExport.DataStructures;
using System.IO;

namespace WFormsAppWordExport.Forms
{
    public partial class FormEditChooseAnswers : Form
    {
        public List<int> ObjIds = new List<int>();
        private List<DBTemplatesHelper.DBAnswer> _chooseAnswers = new List<DBTemplatesHelper.DBAnswer>();
        private bool _swapWork=false;
        private int _selectedItem = 0;
        public List<DBTemplatesHelper.DBAnswer> chooseAnswers
        {
            get
            {
                return _chooseAnswers;
            }
            set
            {
                _chooseAnswers = value;
                updateData();
            }
        }         
        String currentName
        {
            get
            {
                if (_swapWork) return "";
                int i = (selectedItem<listBox1.Items.Count)?selectedItem:listBox1.Items.Count-1;
                return listBox1.Items[i].ToString();
            }
            set
            {
                if (_swapWork) return;
                if (listBox1.Items.Count == 0) return;
                int i = selectedItem;
                listBox1.Items[i] = value;
                chooseAnswers[i].sName = value;
            }
        }
        int selectedItem
        {
            get
            {
                if (_swapWork)return  0;
                return _selectedItem;
            }
            set
            {
                if (_swapWork) return;
                if (value != -1)
                    _selectedItem = value;
                if (_selectedItem >= chooseAnswers.Count)
                    _selectedItem = chooseAnswers.Count - 1;
                updateDataToView();
            }
        }

        public FormEditChooseAnswers()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (cbObj.Enabled)
            {
                foreach (DBTemplatesHelper.DBAnswer a in chooseAnswers)
                {
                    if (a.idObject == -1)
                    {
                        MessageBox.Show("Заполните все ответы, ссылки на все обьекты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            for (int i = 0, l = chooseAnswers.Count; i < l; i++)
            {
                chooseAnswers[i].pos = i;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("answer");
            chooseAnswers.Add(new DBTemplatesHelper.DBAnswer());
            selectedItem = listBox1.Items.Count - 1;
            updateDataToView();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0) return;
            int i = selectedItem;
            chooseAnswers.RemoveAt(i);
            listBox1.Items.RemoveAt(i);
            updateDataToView();
        }

        private void btUp_Click(object sender, EventArgs e)
        {
          
           int i = selectedItem;
            if (i == 0) return;
            _swapWork = true;
            object a = chooseAnswers[i];
            chooseAnswers.RemoveAt(i);
            chooseAnswers.Insert(i - 1,(DBTemplatesHelper.DBAnswer)a);

            a=listBox1.Items[i];
            listBox1.Items.RemoveAt(i);
            listBox1.Items.Insert(i - 1, a);
            _swapWork = false;
            selectedItem = i - 1;
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            int i = selectedItem;
            if (i >= listBox1.Items.Count-1) return;
            _swapWork = true;
            object a = chooseAnswers[i];
            chooseAnswers.RemoveAt(i);
            chooseAnswers.Insert(i + 1, (DBTemplatesHelper.DBAnswer)a);

            a = listBox1.Items[i];
            listBox1.Items.RemoveAt(i);
            listBox1.Items.Insert(i + 1, a);
            _swapWork = false;
            selectedItem = i + 1;
        }

        private void btImportImage_Click(object sender, EventArgs e)
        {
            if (selectedItem == -1 || chooseAnswers.Count==0) return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "файлы bmp (*.bmp)|*.bmp";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {

                string FileName = openFileDialog.FileName;
                int i = selectedItem;
                
                DBTemplatesHelper.DBAnswer a = chooseAnswers[i];
                a.image = Image.FromFile(FileName);
                updateDataToView();
            }
         
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = listBox1.SelectedIndex;
        }

        private void updateDataToView()
        {
            if (chooseAnswers.Count == 0)
            {
                tbQuestionName.Text = "";
                textBoxExportName.Text = "";
                this.pictureBox1.Image = null;
                cbObj.SelectedIndex=-1;
               // this.pictureBox1.Image = ((Image)(new ComponentResourceManager(typeof(FormEditChooseAnswers)).GetObject("pictureBox1.Image")));
                return;
            }

            int i = selectedItem;
            DBTemplatesHelper.DBAnswer a = chooseAnswers[i];
            tbQuestionName.Text = currentName;
            textBoxExportName.Text = a.sExport;
            pictureBox1.Image = a.image;
            cbObj.SelectedIndex = ObjIds.IndexOf(a.idObject);
        }

        private void updateData()
        {
            listBox1.Items.Clear();
            foreach (DBTemplatesHelper.DBAnswer a in chooseAnswers)
            {
                listBox1.Items.Add(a.sName);
            }
            selectedItem = 0;
            updateDataToView();
        }

        private void tbQuestionName_TextChanged(object sender, EventArgs e)
        {
            currentName = tbQuestionName.Text;
        }

        private void textBoxExportName_TextChanged(object sender, EventArgs e)
        {
            int i = selectedItem;
            DBTemplatesHelper.DBAnswer a = chooseAnswers[i];
            a.sExport = textBoxExportName.Text;
        }

        private void сomboBoxObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chooseAnswers.Count > 0)
                if (this.cbObj.SelectedIndex != -1)
                {
                    chooseAnswers[selectedItem].idObject = ObjIds[this.cbObj.SelectedIndex];
                    currentName = cbObj.Items[cbObj.SelectedIndex].ToString();
                }else
                {
                    chooseAnswers[selectedItem].idObject = -1;
                    currentName = "answer";
                }
        }

        #region drop pictures 
        private void FormEditChooseAnswers_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                foreach (string fileLoc in filePaths)
                {
                    int indexFormat = fileLoc.LastIndexOf('.');
                    String format = fileLoc.Substring(indexFormat, fileLoc.Length - indexFormat);
                    int indexDir = fileLoc.LastIndexOf('\\');
                    String fileShortName = fileLoc.Substring(indexDir+1, indexFormat- indexDir-1);
                    if (File.Exists(fileLoc)&&format.Equals(".bmp"))
                    {

                        DBTemplatesHelper.DBAnswer ans = new DBTemplatesHelper.DBAnswer()
                        {
                            image = Image.FromFile(fileLoc),
                            sName = fileShortName
                        };
                        chooseAnswers.Add(ans);
                       
                    }
                }
                updateData();
            }
        }

        private void FormEditChooseAnswers_DragEnter(object sender, DragEventArgs e)
        {
            if (btImport.Enabled)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    #region search any bmp file
                    {
                        Object a = e.Data.GetData(DataFormats.FileDrop);
                        if (!(a is string[])) return;
                    }
                    String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];
                    bool allow = false;
                    for (int i = 0; i < files.Length; i++)
                    {
                        int indexFormat = files[i].LastIndexOf('.');
                        String format = files[i].Substring(indexFormat, files[i].Length-indexFormat);
                        if (format.Equals(".bmp"))
                        {
                            allow = true;
                            break;
                        }
                    }
                    #endregion
                    if (allow)
                        e.Effect = DragDropEffects.Copy;
                }
            }
           
        }
        #endregion 
    }
}
