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
using Word = NetOffice.WordApi;
using WordEnums = NetOffice.WordApi.Enums;
using System.IO;
namespace WFormsAppWordExport
{
    public partial class MDIParent1 : Form
    {
#if DEBUG
        Boolean isDebugMode = true;
#else
        Boolean isDebugMode = false;
#endif

        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Состояние: создание нового проекта";
            OpenProject(null);
            stateNorm();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Состояние: Открытие файла";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (isDebugMode)
                openFileDialog.InitialDirectory = "D:\\work\\Visual Studio\\projects\\WinForms(Gai)\\WinForms(Gai)\\bin\\x86\\Debug";
            openFileDialog.Filter = "файлы дтп (*.dtp)|*.dtp|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                closeProject();
                string FileName = openFileDialog.FileName;

                OpenProject(openFileDialog.FileName);
              
            }
            stateNorm();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Состояние: Сохранение файла";
            if (ProjectDataHelper.Initial==null)
            {
                errFormNoOpen();
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (isDebugMode)
                saveFileDialog.InitialDirectory = "D:\\work\\Visual Studio\\projects\\WinForms(Gai)\\WinForms(Gai)\\bin\\x86\\Debug";
            saveFileDialog.Filter = "Файлы ДТП (*.dtp)|*.dtp|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                ProjectDataHelper.Initial.saveToFile(fileName);
            }
            stateNorm();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Состояние: Сохранение файла";
            if (ProjectDataHelper.Initial==null)
            {
                errFormNoOpen();
                return;
            }
            if (!ProjectDataHelper.Initial.saveToFile())
                SaveAsToolStripMenuItem_Click(sender, e);
            stateNorm();
        }

        private void closeProject()
        {
            if (MdiChildren == null||MdiChildren.Length==0) return;
            ((Form1)MdiChildren[0]).Close();
        }
        private void OpenProject(String file)
        {
            closeProject();
            try
            {
                Form childForm = (file == null) ? new Form1() : new Form1(file);
                childForm.MdiParent = this;
                childForm.Focus();
                
                childForm.Text = "Окно " + childFormNumber++;
                childForm.Show();
            }catch (System.Runtime.Serialization.SerializationException ex)
            {
                MessageBox.Show("Попробуйте еще раз. Либо откройте другой файл", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }

        private void errFormNoOpen()
        {
            MessageBox.Show("Создайте или откройте проект");
        }

        private void exportDocToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (ProjectDataHelper.Initial == null)
            {
                errFormNoOpen();
                return;
            }
            toolStripStatusLabel.Text = "Состояние: экспорт документа";


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (isDebugMode)
                saveFileDialog.InitialDirectory = "D:\\work\\Visual Studio\\projects\\WinForms(Gai)\\WinForms(Gai)\\bin\\x86\\Debug";
            saveFileDialog.Filter = "Файлы word (*.doc)|*.doc|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {

                string fileName = saveFileDialog.FileName;
                ProjectDataHelper.Initial.exportDoc(fileName);

            }

            stateNorm();
        }

        private void exitLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeProject();
            Program.authorizationForm.Show();
            Program.context.MainForm = Program.authorizationForm;
            this.Close();
        }

        private void setTemlateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Состояние: Загрузка конфигурации";
            FormSettingQuestionnaire setting = new FormSettingQuestionnaire();
            stateNorm();
            setting.ShowDialog();
        }

        private void setPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangePassword chPasw = new FormChangePassword(ProjectDataHelper.sUser);
            chPasw.ShowDialog();
        }

        private void delUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Уверены?", "Удалить пользователя", MessageBoxButtons.YesNoCancel);
            if (dialogResult== DialogResult.Cancel || dialogResult==DialogResult.No)
            {
                return;
            }
            if (dialogResult == DialogResult.Yes)
            {
                closeProject();
               // File.Delete(MyFiles.getMyTemplate());
                Program.authorizationForm.Show();
                Program.context.MainForm = Program.authorizationForm;
                Program.authorizationForm.removeUser(ProjectDataHelper.sUser);
                this.Close();
            }
        }

        private bool hasText(String st)
        {
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] != ' ' && st[i] != '\n'&& st[i]!='\r'&&st[i]!='\t') return true;
            }
            return false;
        }

        private void stateNorm()
        {
            toolStripStatusLabel.Text = "Состояние";
        }

        private void mdi_show(object sender, EventArgs e)
        {
            if (Program.OpenFile != null)
            {
                OpenProject(Program.OpenFile);
                Program.OpenFile = null;
            }
        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.FormAbout().ShowDialog();
        }

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {
            toolStripStatusLabel.Text = "Состояние: Закрытие конфигурации";
            DBTemplatesHelper.get().closeDB();
            stateNorm();
        }
     

        #region drop file
        private void MDIParent1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                foreach (string fileLoc in filePaths)
                {
                    int indexFormat = fileLoc.LastIndexOf('.');
                    String format = fileLoc.Substring(indexFormat, fileLoc.Length - indexFormat);
                    int indexDir = fileLoc.LastIndexOf('\\');
                    String fileShortName = fileLoc.Substring(indexDir + 1, indexFormat - indexDir - 1);
                    if (File.Exists(fileLoc) && format.Equals(".dtp"))
                    {
                        OpenProject(fileLoc);
                    }
                }
            }
        }

        private void MDIParent1_DragEnter(object sender, DragEventArgs e)
        {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    #region search any dtp file
                    {
                        Object a = e.Data.GetData(DataFormats.FileDrop);
                        if (!(a is string[])) return;
                    }
                    String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];
                    bool allow = false;
                    for (int i = 0; i < files.Length; i++)
                    {
                        int indexFormat = files[i].LastIndexOf('.');
                        String format = files[i].Substring(indexFormat, files[i].Length - indexFormat);
                        if (format.Equals(".dtp"))
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
        #endregion 
    }
}
