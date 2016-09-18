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
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport
{
    static class Program
    {
#if DEBUG
        public static Boolean isDebugMode = true;
#else
         public static Boolean isDebugMode = false;
#endif


        public static ApplicationContext context=new ApplicationContext();
        public static FormAuthorization authorizationForm;
        public static String OpenFile=null;// = "‪C:\\Users\\Andre\\Desktop\\a.dtp";

      
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(String[] arg)
        {
          
            MyFiles.log("StartProgramm  debugMode:"+isDebugMode);
            if (arg != null)
            {
                for (int i = 0; i < arg.Length; i++)
                    MyFiles.log("arg "+i+" - "+arg[i]);

            }
            if (arg != null && arg.Length > 0 && arg[0] != null)
            {
                if (isValidPath(arg[0]))
                    OpenFile = arg[0];
                MyFiles.log("arg is  valid ");
            }
            MyFiles.log("arg no  valid ");


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
                    context = new ApplicationContext((authorizationForm = new FormAuthorization()));
                    Application.Run(context);
                   
                    break;
            }
            DBTemplatesHelper.closeDB();
            //   
        }

        static private bool isValidPath(string path)
        {
            Regex driveCheck = new Regex(@"^[a-zA-Z]:\\$");
            if (!driveCheck.IsMatch(path.Substring(0, 3))) return false;
            string strTheseAreInvalidFileNameChars = new string(Path.GetInvalidPathChars());
            strTheseAreInvalidFileNameChars += @":/?*" + "\"";
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(strTheseAreInvalidFileNameChars) + "]");
            if (containsABadCharacter.IsMatch(path.Substring(3, path.Length - 3)))
                return false;
            return true;
        }

    }

   

}
