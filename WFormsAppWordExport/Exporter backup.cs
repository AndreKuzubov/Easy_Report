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
using System.Text;
using System.IO;
using Word = NetOffice.WordApi;
using WordEnums = NetOffice.WordApi.Enums;
using System.Windows.Forms;
using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport
{
    public static class Exporter
    {


        public static void exportAll(String filename)
        {
            List<DBTemplatesHelper.DBParagraph> paragraphs = DBTemplatesHelper.DBParagraph.getAllParagraphs();
            //List<DBTemplatesHelper.DBParagraph> paragraphs = new ;


            RTFHelpener rtfHelper = new RTFHelpener(findText(paragraphs));
            foreach(DBTemplatesHelper.DBParagraph p in paragraphs)
            {
                SoftwareSctipt scrip;
                if (p.flag == 0)
                {
                    scrip = new SoftwareSctipt(p.text,SoftwareSctipt.SCRIPT_TYPE.STRING);
                    rtfHelper.replaceScriptToText(p.id, scrip.runString("no script"));
                }
            }
           

            Word.Application app = new Word.Application();
            app.Visible = false;
            Word.Document doc;
            Object template = null;
            Object newTemplate = false;
            Object documentType = 0;
            Object visible = false;
            
            
            doc = app.Documents.Add(template, newTemplate, documentType, visible);
            doc.Activate();
            Clipboard.SetText(rtfHelper.Rtf, TextDataFormat.Rtf);
            app.Selection.Paste();

            doc.SaveAs2(filename, 16, false, Type.Missing, false,
             Type.Missing, false, false, false, false, false, 0,
             false, false, true);
            app.Quit(0, 0, false);

        }

        private static String findText(List<DBTemplatesHelper.DBParagraph> paragraphs)
        {
            foreach (DBTemplatesHelper.DBParagraph p in paragraphs)
            {
                if (p.flag == 1){
                    return p.text;
                }
            }
            return "";
        }

    }
}
