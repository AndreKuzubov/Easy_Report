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
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFormsAppWordExport
{
    public partial class FormPictureMultiChoose : Form
    {
        private int[][] _ch;
        public int [][] check{
             set
            {
                updateGrid();
                _ch = value;
            }
            get
            {
                return _ch;
            }
            }

        private DataSet dbSet = null;

        public FormPictureMultiChoose()
        {
            InitializeComponent();

            
           /* switch (source)
            {
                case DB_SOURCE.ROAD_MARKING:
                    dbSet = dBGaiMarksDataSet;
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "dBGaiMarksDataSet.Дорожная_разметка". При необходимости она может быть перемещена или удалена.
                    this.дорожная_разметкаTableAdapter.Fill(this.dBGaiMarksDataSet.Дорожная_разметка);
                    break;
                case DB_SOURCE.ROAD_SIGNS:
                    dbSet = dBGaiSignsDataSet;
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "dBGaiSignsDataSet.Знаки_приоритета". При необходимости она может быть перемещена или удалена.
                    this.предупреждающие_знакиTableAdapter1.Fill(this.dBGaiSignsDataSet.Предупреждающие_знаки);
                    this.знаки_приоритетаTableAdapter.Fill(this.dBGaiSignsDataSet.Знаки_приоритета);
                    this.запрещающие_знакиTableAdapter1.Fill(this.dBGaiSignsDataSet.Запрещающие_знаки);
                    break;
                default:return;
            }*/
          
            int len = dbSet.Tables.Count;
            _ch = new int[len][];
            for (int i = 0; i < len; i++)
            {
                TreeNode node = new TreeNode(dbSet.Tables[i].TableName);
                node.Tag = i;
                treeView1.Nodes.Add(node);
                _ch[i] = new int[dbSet.Tables[i].Rows.Count]; 
            }
                    
        }

        public string getStringAnswer()
        {
            string s = "";
            string separator = "";
            for (int i = 0, len = dbSet.Tables.Count; i < len; i++)
            {
                DataRowCollection rows = dbSet.Tables[i].Rows;
                for (int j = 0, l = rows.Count; j < l; j++)
                {
                    if (_ch[i][j] == 0) continue; 
                    DataRow row = rows[j];
                    s += separator+row.ItemArray[2].ToString();
                    separator = ", ";

                }
            }
            s += ".";
            return s;
        }

        private void updateGrid()
        {
            
            flowLayoutPanel1.Controls.Clear();
            if (treeView1.SelectedNode == null) return;
            int j = (int)treeView1.SelectedNode.Tag;
            DataTable table = dbSet.Tables[(int)treeView1.SelectedNode.Tag];
            DataRowCollection rows = table.Rows;

            for (int i = 0, l = rows.Count; i < l; i++)
            {
                DataRow row = rows[i];
                UseControlChoosePict choosePict = new UseControlChoosePict();
                choosePict.checkBox1.Text = row.ItemArray[0].ToString();//+"  "+ row.ItemArray[2].ToString();
                choosePict.checkBox1.Image = (Image)(new ImageConverter().ConvertFrom((byte[])row.ItemArray[1]));
                choosePict.checkBox1.Tag = (int)treeView1.SelectedNode.Tag * 1000 + i;
                choosePict.checkBox1.CheckedChanged += new EventHandler(checkBox_checked);
                if (_ch[j][i] == 1) choosePict.checkBox1.CheckState = CheckState.Checked;
                flowLayoutPanel1.Controls.Add(choosePict);

            }

        }

        private void PictureMultiChoose_Load(object sender, EventArgs e)
        {
          

        }

        private void btOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            updateGrid();
        }

        private void checkBox_checked(object sender, EventArgs e)
        {
            int a =(int) ((Control)sender).Tag;
            bool value = ((CheckBox)sender).Checked;
            _ch[a / 1000][a % 1000] = (value) ? 1 : 0;
        }

    }
}
