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
    public partial class FormCreateUser : Form
    {
        private int err = 2;
        private FormAuthorization authorizationForm;

        public FormCreateUser(FormAuthorization authorizationForm)
        {
            InitializeComponent();
            this.authorizationForm = authorizationForm;
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (authorizationForm.checkLogin(textBox1.Text))
            {
                errRepeatlabel.Text = "такой логин уже есть";
                err |= 1;
            }
            else
            {
                errRepeatlabel.Text = "";
                err &= ~1;

            }

            if (err == 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals(textBox2.Text))
            {
                err &= ~2;
            }
            else
            {             
                err |= 2;
            }

            if (err == 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals(textBox2.Text))
            {
                errDifPasswordlabel.Text = "";
                err &= ~2;
            }
            else
            {
                errDifPasswordlabel.Text = "пароли не равны";
                err |= 2;
            }


            if (err==0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            authorizationForm.addUser(textBox1.Text, textBox2.Text);
            this.Close();
        }

        private void keyDown1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }

        private void keyDown2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox3.Focus();
        }

        private void keyDown3(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }
    }
}
