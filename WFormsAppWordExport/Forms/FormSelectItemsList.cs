using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WFormsAppWordExport.Forms
{
    public partial class FormSelectItemsList : Form
    {

        public FormSelectItemsList()
        {
            InitializeComponent();
        }

        public void set(List<Para> selected, List<Para> unselected)
        {
            listBoxUnSelected.Items.Clear();
            listBoxSelected.Items.Clear();
            listBoxUnSelected.Items.AddRange(unselected.ToArray());
            listBoxSelected.Items.AddRange(selected.ToArray());
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            int i = listBoxUnSelected.SelectedIndex;
            if (i != -1)
            {
                listBoxSelected.Items.Add(listBoxUnSelected.Items[i]);
                listBoxUnSelected.Items.RemoveAt(i);
            }
          
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            int i = listBoxSelected.SelectedIndex;
            if (i != -1)
            {
                listBoxUnSelected.Items.Add(listBoxSelected.Items[i]);
                listBoxSelected.Items.RemoveAt(i);
            }

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public class Para
        {
           public int id;
           public String text;
           public override String ToString()
            {
                
                return text;
            }
        }
    }
}
