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
