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
using System.Linq;
using System.Windows.Forms;
using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport
{
    static class Program
    {
     
        public static ApplicationContext context;
        public static FormAuthorization authorizationForm;
        public static String OpenFile=null;// = "‪C:\\Users\\Andre\\Desktop\\a.dtp";

      
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(String[] arg)
        {
            MyFiles.log("StartProgramm");
            if (arg != null){
                foreach (String s in arg)
                {
                    MyFiles.log(s);
                }
            }
            if (arg != null && arg.Length > 0 && arg[0] != null)
            {
                OpenFile = arg[0];
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            switch (6)
            {
                case 1:
                    Application.Run(new WFormsAppWordExport.Forms.FormDevCode());
                    break;
              case 2:
                    Application.Run(new MDIParent1());
                    break;
                case 3:
                    Application.Run(new FormSettingQuestionnaire());
                    break;
                case 4:
                    Application.Run(new WFormsAppWordExport.Forms.FormTestEditText());
                    break;
                case 5:
                    Application.Run(new WFormsAppWordExport.Forms.FormDevCode());
                    break;
                case 6:
                    Application.Run(context = new ApplicationContext(authorizationForm = new FormAuthorization()));
                    break;
            }

           
         //   
        }
    }
}
