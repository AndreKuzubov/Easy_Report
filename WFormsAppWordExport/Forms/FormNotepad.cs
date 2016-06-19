using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WFormsAppWordExport
{
    public partial class FormNotepad : Form
    {
        public FormNotepad()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void NotepadForm_Load(object sender, EventArgs e)
        {
            textBox.Focus();
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
       //     if (e.KeyCode == Keys.Enter)
         //       saveButton_Click(sender, e);

        }
    }
}
