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

namespace WFormsAppWordExport
{
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
            this.loginTextBox.Text = ProjectDataHelper.sUser;
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
