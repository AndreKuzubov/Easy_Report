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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Word = NetOffice.WordApi;
using WordEnums = NetOffice.WordApi.Enums;
using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport
{
    public class ProjectDataHelper
    {
      

        public TreeNodeCollection rootData;
        public String fileName ;

        #region constructions
        public static ProjectDataHelper Initial { get; private set; } = null;
        public static void closeProject()
        {
            Initial = null;
        } 

        public ProjectDataHelper()
        {
            Initial = this;
        }

       ~ProjectDataHelper()
        {
        //    Instate = null;
        }
        #endregion

        public bool saveToFile()
        {
            if (fileName == null) return false;
            saveToFile(fileName);
            return true;
        }

        public void saveToFile(String fileName)
        {
            this.fileName = fileName;
            int len = rootData.Count;
            Essence[] eEssences = new Essence[len];
            for (int i = 0; i < len; i++)
            {
                eEssences[i] = (Essence)rootData[i];
            }
            FileStream fileStream;
            if (File.Exists(fileName))
                fileStream = new FileStream(fileName, FileMode.Truncate);
            else fileStream = new FileStream(fileName, FileMode.CreateNew);

            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fileStream, eEssences);
            fileStream.Close();
        }

        public void exportDoc(String filename)
        {
            Word.Application app = new Word.Application();
            app.Visible = false;
            Word.Document doc;

            Object template = MyFiles.getMyTemplate();
            Object newTemplate = false;
            Object documentType = 0;
            Object visible = false;


            doc = app.Documents.Add(
            template, newTemplate, documentType, visible);
            doc.Activate();

            Exporter.exportAll(app, rootData);


            doc.SaveAs2(filename, 16, false, Type.Missing, false,
               Type.Missing, false, false, false, false, false, 0,
               false, false, true);
            app.Quit(0, 0, false);


        }

        public List<Essence> getEssencesByImage(int idofImageObject)
        {
            List<Essence> essences=new List<Essence>();
            foreach (Essence es in rootData)
            {
                if (es.idDb == idofImageObject)
                {
                    essences.Add(es);
                }
            }
            return essences;
        }

    }
}
