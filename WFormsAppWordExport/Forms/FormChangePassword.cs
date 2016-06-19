using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WFormsAppWordExport
{
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
            this.loginTextBox.Text = Program.sUser;
        }
        public FormChangePassword(String login)
        {
            InitializeComponent();
            this.loginTextBox.Text = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (passwordTextBox2.Text.Equals(passwordTextBox.Text))
            {
                Program.authorizationForm.setPassword(loginTextBox.Text, passwordTextBox.Text);
                Close();
            }else
            {
                errLabel.Text = "пароли не совпадают";
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                passwordTextBox2.Focus();
        }

        private void keyDown2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);

        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            passwordTextBox.Focus();
        }
    }
}
