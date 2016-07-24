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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WFormsAppWordExport
{
    public partial class FormAuthorization : Form
    {
        private Dictionary<String, String> logins = new Dictionary<String, String>();

        public FormAuthorization()
        {
            InitializeComponent();
            loadkeys();
          
        }

        public void addUser(String login , String password)
        {
            
            logins.Add(login, password);
            savekeys();
        }

        public void removeUser(String login)
        {
            logins.Remove(login);
            savekeys();
        }

        public void setPassword(String login,String password)
        {
            logins.Remove(login);
            logins.Add(login, password);
            savekeys();
        }

        public bool checkLogin(String login)
        {
            return logins.ContainsKey(login);
        }

        public bool checkUser(String login,String password)
        {
            if (!checkLogin(login)) return false;
            String p;
            logins.TryGetValue(login, out p);
            return p.Equals(password);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Program.context.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String password;
            if (logins.ContainsKey(textBox1.Text))
            {
                logins.TryGetValue(textBox1.Text, out password);
                if (password.Equals(textBox2.Text))
                {
                    ProjectDataHelper.sUser = textBox1.Text;
                    MDIParent1 p = new MDIParent1();
                    p.Show();
                    p.Activate();
                    Program.context.MainForm = p;
                    this.Hide();
                    ErrorLabel.Text = "";

                }
                else errLogin();
            }
            else errLogin();




     
        }

        private void button2_Click(object sender, EventArgs e)
        {

            FormCreateUser createUser = new FormCreateUser(this);
            createUser.ShowDialog();
        
        }

        private void loadkeys()
        {
            FileStream file;
            try
            {
                file = new FileStream(MyFiles.getMyLogs(), FileMode.Open);
            }
            catch(FileNotFoundException e)
            {
                return;
            }
            BinaryFormatter serializer = new BinaryFormatter();
            logins=(Dictionary<String,String>)serializer.Deserialize(file);
            file.Close();
        }


        private void savekeys()
        {
            FileStream file;
            file = new FileStream(MyFiles.getMyLogs(), FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(file, logins);
            file.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void errLogin()
        {
            ErrorLabel.Text = "логин или пароль неверный";
        }

        private void password_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void login_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
