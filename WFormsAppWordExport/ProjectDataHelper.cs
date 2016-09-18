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
        public static String sUser = "sys";
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
            Exporter.exportAll( filename);

        }

        public List<Essence> getEssencesByImage([MettodVariants(typeof(ProjectDataHelper), "getEssences")]int idofImageObject)
        {
            List<Essence> essences=new List<Essence>();
            foreach (Essence es in rootData)
            {
                if (hasEssangeImage(es,idofImageObject))
                {
                    essences.Add(es);
                }
            }
            return essences;
        }

        private bool hasEssangeImage(Essence root,int idImage)
        {
            if (root.idDb == idImage) return true;
            if (root.abstrEssences != null)
            {
                foreach (Essence es in root.abstrEssences)
                {
                    if (hasEssangeImage(es, idImage)) return true;
                }
            }
            return false;
        }

        #region use in scrips
      
        public  static AutocompleteMenuNS.AutocompleteItem[] getEssences()
        {
            List<AutocompleteMenuNS.MulticolumnAutocompleteItem> items = new List<AutocompleteMenuNS.MulticolumnAutocompleteItem>();
           List<DBTemplatesHelper.DBObject> dbObjs= DBTemplatesHelper.DBObject.getAll();
            
            foreach(DBTemplatesHelper.DBObject dbO in dbObjs)
            {
                items.Add(new AutocompleteMenuNS.MulticolumnAutocompleteItem(new string[] {""+ dbO.id, dbO.name },""+ dbO.id));
            }
            return items.ToArray();
        }

        #endregion
    }
}
