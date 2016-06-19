using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFormsAppWordExport
{
    public partial class UseControlChoosePict : UserControl
    {
        public UseControlChoosePict()
        {
            InitializeComponent();
        }

        private void UseControlChoosePict_Load(object sender, EventArgs e)
        {

        }

        private void choosePict_MouseClick(object sender, MouseEventArgs e)
        {
           checkBox1.CheckState=(CheckState.Checked== checkBox1.CheckState)?CheckState.Unchecked:CheckState.Checked;
        }
    }
}
