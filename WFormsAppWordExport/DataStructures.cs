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
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace WFormsAppWordExport
{
    public static class MyFiles
    {
        //все внутренние файлы 
        /// <summary>
        /// получить файл логов - паролей
        /// </summary>
        /// <returns></returns>
        public static String getMyLogs()
        {
            return Application.UserAppDataPath + "\\lgs";
        }
        /// <summary>
        /// получить адрес файла шаблона тля текущего пользователя
        /// </summary>
        /// <returns></returns>
        public static String getMyTemplate()
        {
            return Application.UserAppDataPath + "/" + Program.sUser + ".dot";
        }

        public static void log(String log)
        {
            StreamWriter fileStream = new StreamWriter(Directory.GetCurrentDirectory() + "/log.txt", true);
            fileStream.WriteLine("l:" + log);
            fileStream.Close();
        }

    }
    [Serializable()]
    public struct WordStyle
    {
        public int font;
        public int size;
    }
   
   // [Serializable()]
   // public enum DB_SOURCE { ROAD_SIGNS, ROAD_MARKING, NONE = -1 };

    //[Serializable()]
    //public enum QUESTION_GROUP { AUTO, SCENE, INSPECTOR, SCHOOL, MAN, VICTIM, DRIVER, PASSENGER, PEDENSTRIAN, TOTAL, TELEPHONEMESSAGE }

   
   /* [Serializable()]
    public delegate bool IsUseFunc();
    [Serializable()]
    public delegate void AfterAnswer();
    */
    
}
