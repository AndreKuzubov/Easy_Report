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
using System.Data.Linq;
using System.Xml.Linq;
using System.ComponentModel;
using System.Drawing;
using WFormsAppWordExport.DataStructures;

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

    public static class ConvertFormat
    {
        public static String arrayToString(int[] a)
        {
            if (a != null & a.Length > 0) return null;
            String s = "";

            for (int i = 0, l = a.Length - 1; i < l; i++)
            {
                s += a[i] + ", ";
            }
            s += a[a.Length - 1];
            return s;
        }

        public static int[] stringToArray(String s)
        {
            if (s == null || s.Length == 0) return null;
            int[] a = null;
            try
            {
                String[] sArr = s.Split(',');
                a = new int[sArr.Length];
                for (int i = 0; i < sArr.Length; i++)
                {
                    a[i] = Int32.Parse(sArr[i]);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка данных в sql", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return a;
        }

        public static Image toImageFromBMP(Object v)
        {
            if (v == null) return null;
           
            try
            {
                return (Image)(new ImageConverter().ConvertFrom((byte[])v));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка конвертации картинки", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return null;
        }

        public static byte[] toByteArray(Image image)
        {
            if (image == null) return null;
            try
            {
                return (byte [])(new ImageConverter().ConvertTo(image, typeof(byte[])));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка конвертации картинки", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return null;
        }

    }




}
