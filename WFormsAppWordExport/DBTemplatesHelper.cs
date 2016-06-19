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
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Data.Linq;
using System.Xml.Linq;
using System.ComponentModel;
using System.Drawing;
using WFormsAppWordExport.DataStructures;

namespace WFormsAppWordExport
{
    class DBTemplatesHelper
    {
        static private DBTemplatesHelper initial;
        static String name = "MyDB60";

        String dir = Directory.GetCurrentDirectory();
        SqlConnection myConn=null;

        public static DBTemplatesHelper get()
        {
            if (initial == null) initial = new DBTemplatesHelper();
            return initial;
        }

        public DBTemplatesHelper ()
        {
            initial = this;
            create_openDB();
        }

        private void create_openDB()
        {
            if (myConn == null)
                if (!File.Exists(dir + "\\" + name + ".dmf"))
                {
                    createDB();
                }
                else
                    openDB();
        }
      
        private void closeDB()
        {
            if (myConn != null&myConn.State == ConnectionState.Open)
            {
                try
                {
                    myConn.Close();
                }
                catch { 
}
                finally
                {

                }
               
            }
        }

        public List<DBObject> getObjects()
        {
            String s = "SELECT * FROM \"Образ Обьекта\"";
            SqlDataReader r=new SqlCommand(s, myConn).ExecuteReader();
            List<DBObject> strs = new List<DBObject>();
            while (r.Read())
            {
                strs.Add(DBObject.read(r));
            }
            r.Close();
            return strs;
        }
  
        public DBObject getDBObjectById(int id)
        {
            String s = "SELECT * FROM \"Образ Обьекта\" WHERE id = " + id + " ";
            SqlDataReader r=null;
            try
            {
                r = new SqlCommand(s, myConn).ExecuteReader();
                r.Read();
                return DBObject.read(r);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка sql", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (r != null)
                    r.Close();
            }
          
            return new DBObject();
        }

        public void bindingFeaturesForObjectById(BindingSource outBindingSource, int idObj)
        {
            String s = "SELECT [Характеристика].* FROM [Образ Обьекта],[Характеристика], [Описание обьекта] WHERE [Образ Обьекта].id = "+idObj
                +" and [Описание обьекта].[id Образа обьекта]=[Образ Обьекта].id and [Описание обьекта].[id характеристики]=Характеристика.id "
                 + "order by isnull([Характеристика].Очередность,2147483647)"; ;
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(s, myConn);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sqlAdapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            sqlAdapter.Fill(table);
            outBindingSource.DataSource = table;

            // Resize the DataGridView columns to fit the newly loaded content.
        //    outDataGridView.AutoResizeColumns(
          //      DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            // SqlDataReader r = null;


        }

        public void fillProjectTree(out List<Essence> outNodes,out List<Essence> outContextNodes)
        {
            outNodes = new List<Essence>();
            outContextNodes = new List<Essence>();
            List<int> outNodesIds = new List<int>();
            List<int[]> contextNodesGroupsIds = new List<int[]>();
            //корневае узлы
            String s1 = "Select * from [Образ Обьекта] where[Образ Обьекта].flags & 1 = 1 order by  isnull([Образ Обьекта].Очередность,2147483647)",

                    //добавляемые узлы 
                    s2 = "Select * from [Образ Обьекта] where not ([Образ Обьекта].flags & 1 = 1 and[Образ Обьекта].flags & 2 <> 2) or[Образ Обьекта].flags is NULL"
                    + "order by  isnull([Образ Обьекта].Очередность,2147483647)";

            SqlDataReader r = null;
            Essence es = null;

            #region Заполнение узлов дерева с данными из базы
            try
            {
                r = new SqlCommand(s1, myConn).ExecuteReader();
                while (r.Read())
                {
                   es=new Essence(r[1].ToString(),
                        (r.IsDBNull(4))?0:(ESSENSE_FLAGS)r[4], (r.IsDBNull(3)) ? null : (String)r[3].ToString(),null, null);
                    outNodes.Add(es);

                    outNodesIds.Add((int)r[0]);
                    contextNodesGroupsIds.Add(r.IsDBNull(5)?null:DBConvertFormat.stringToArray(r[5].ToString()));
                }
               
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка sql", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (r != null)
                    r.Close();
            }

            for (int i=0,l=outNodes.Count;i< l;i++)
            {
                es = outNodes[i];
                fillFeatures(es, (int)outNodesIds[i]);
            }

            for (int i = 0, l = outNodes.Count; i < l; i++)
            {
                es = outNodes[i];
                fillAbstractEssences(es, contextNodesGroupsIds[i]);
            }
            #endregion

        }

        ~DBTemplatesHelper()
        {
            closeDB();
            initial = null;
        }

        private void createDB()
        {

            myConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;");

            String str = "CREATE DATABASE " + name + " ON PRIMARY " +
                "(NAME = MyDatabase_Data, " +
                "FILENAME = '" + dir + "\\" + name + ".dmf', " +
                 " SIZE = 5MB," +
                  " MAXSIZE = 30MB," +
                 " FILEGROWTH = 10%)" +

                "LOG ON (NAME = MyDatabase_Log, " +
                "FILENAME = '" + dir + "\\" + name + ".ldf" + "', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)";
            try
            {

                SqlCommand myCommand = new SqlCommand(str, myConn);
                myConn.Open();
                myCommand.ExecuteNonQuery();
                myConn.Close();


            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка открытия БД", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }

            openDB();
            buildDB();
            fILLDB();

        }

        private void openDB()
        {
            myConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + dir + "\\" + name + ".dmf;Integrated Security=True;Connect Timeout=30");
            myConn.Open();
        }

        private void buildDB()
        {
            String s1, s2, s3, s4, s5, s6;
            s1 = "CREATE TABLE \"Параграфы\"  (id INTEGER PRIMARY KEY IDENTITY, Стиль ntext NOT NULL,Скрипт ntext)";
            s2 = "CREATE TABLE \"Образ Обьекта\"  (id INTEGER PRIMARY KEY IDENTITY, Название ntext NOT NULL, Очередность int,Скрипт ntext, flags int, \"ids абстрактных обьектов\" ntext )";
            s3 = "CREATE TABLE \"Характеристика\"  (id INTEGER PRIMARY KEY IDENTITY,Тип int, Вопрос ntext NOT NULL, Очередность int, \"Условие вопроса\" ntext, \"Скрипт после ответа\" ntext)";
            s4 = "CREATE TABLE \"Вариант ответа\"  (id INTEGER PRIMARY KEY IDENTITY, Очередность int, \"Звучание по вопросу\" ntext NOT NULL, \"Звучание по ответу\" ntext, Картинка image)";
            s5 = "CREATE TABLE \"Выборка\"  (id INTEGER PRIMARY KEY IDENTITY, \"id характеристики\" INTEGER FOREIGN KEY REFERENCES Характеристика (id),"
                + " \"id варианта\" INTEGER FOREIGN KEY REFERENCES \"Вариант ответа\" (id))";
            s6 = "CREATE TABLE \"Описание обьекта\"  (id INTEGER PRIMARY KEY IDENTITY, \"id Образа обьекта\" INTEGER FOREIGN KEY REFERENCES \"Образ Обьекта\"  (id),"
                + " \"id характеристики\" INTEGER FOREIGN KEY REFERENCES \"Характеристика\" (id))";

            new SqlCommand(s1, myConn).ExecuteNonQuery();
            new SqlCommand(s2, myConn).ExecuteNonQuery();
            new SqlCommand(s3, myConn).ExecuteNonQuery();
            new SqlCommand(s4, myConn).ExecuteNonQuery();
            new SqlCommand(s5, myConn).ExecuteNonQuery();
            new SqlCommand(s6, myConn).ExecuteNonQuery();
        }

        private void fILLDB()
        {
            String s;
            s = "INSERT INTO \"Образ Обьекта\" (Название) VALUES (N'Пешеход'),(N'Водитель'),(N'Пострадавший')";
            new SqlCommand(s, myConn).ExecuteNonQuery();
            s = "INSERT INTO \"Характеристика\" (Вопрос) VALUES (N'Имя'),(N'Возраст'),(N'стаж'),(N'степень повреждений'),(N'место в машине')";
             new SqlCommand(s, myConn).ExecuteNonQuery();
             s = "INSERT INTO \"Описание Обьекта\" (\"id характеристики\",\"id образа обьекта\") VALUES (1,1),(1,2),(1,3),(2,1),(2,2),(2,3),(3,2),(4,3),(5,1)";
            new SqlCommand(s, myConn).ExecuteNonQuery();
        }

        private void fillAbstractEssences(Essence outNode,int[] idsEs)
        {
            if (idsEs == null || idsEs.Length == 0) return;

            String s = "SELECT * FROM [Образ Обьекта] WHERE id = " + idsEs[0] 
                + "order by  isnull([Образ Обьекта].Очередность,2147483647)";
            for (int i = 1; i < idsEs.Length; i++)
            {
                s += " or id=" + idsEs[i]+" ";
            }

            List<int> outNodesIds = new List<int>();
            List<int[]> contextNodesGroupsIds = new List<int[]>();
            SqlDataReader r = null;
            Essence es = null;

            #region Заполнение узла абстрактными узлами
            try
            {
                r = new SqlCommand(s, myConn).ExecuteReader();
                while (r.Read())
                {
                    es = new Essence(r[1].ToString(),
                         (r.IsDBNull(4)) ? 0 : (ESSENSE_FLAGS)r[4], (r.IsDBNull(3)) ? null : (String)r[3].ToString(), null, null);
                    outNode.abstrEssences.Add(es);

                    outNodesIds.Add((int)r[0]);
                    contextNodesGroupsIds.Add(r.IsDBNull(5) ? null : DBConvertFormat.stringToArray(r[5].ToString()));
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка sql", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (r != null)
                    r.Close();
            }
            for (int i = 0, l = outNodesIds.Count; i < l; i++)
            {
                es = outNode.abstrEssences[i];
                fillFeatures(es, (int)outNodesIds[i]);
            }

            for (int i = 0, l = outNodesIds.Count; i < l; i++)
            {
                es = outNode.abstrEssences[i];
                fillAbstractEssences(es, contextNodesGroupsIds[i]);
            }
            #endregion
        }

        private void fillFeatures(Essence outEs,int idEss)
        {
            String s = "SELECT [Характеристика].* FROM [Образ Обьекта],[Характеристика], [Описание обьекта] WHERE [Образ Обьекта].id = " + idEss
               + " and [Описание обьекта].[id Образа обьекта]=[Образ Обьекта].id and [Описание обьекта].[id характеристики]=Характеристика.id "
               + "order by  isnull([Характеристика].Очередность,2147483647)";

            SqlDataReader r = null;
            List<int> idsFeatures=new List<int>();
            try
            {
                r = new SqlCommand(s, myConn).ExecuteReader();
                while (r.Read())
                {
                    Feature f=new Feature(r[2].ToString(),null, r.IsDBNull(1)?0:(TYPE_ANSWER)(int)r[1], r.IsDBNull(3)?null:r[3].ToString(), 
                        r.IsDBNull(4)?null:r[4].ToString());
                    idsFeatures.Add((int)r[0]);
                    outEs.features.Add(f);
                 
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка sql загрузка Характеристик", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (r != null)
                    r.Close();
            }
            for (int i=0,l=outEs.features.Count;i< l; i++)
            {
                fillAnswersToFeature(outEs.features[i], idsFeatures[i]);
            }

        }

        private void fillAnswersToFeature(Feature outFeature,int idFeature)
        {
            String s = "SELECT [Вариант ответа].* FROM [Вариант ответа],[Характеристика], [Выборка] WHERE [Характеристика].id = " + idFeature
            + " and [Выборка].[id характеристики]=[Характеристика].id and [Выборка].[id варианта]=[Вариант ответа].id "
             + "order by  isnull([Вариант ответа].Очередность,2147483647)"; ;

            SqlDataReader r = null;
            try
            {
                r = new SqlCommand(s, myConn).ExecuteReader();
                while (r.Read())
                {
                    Chooce_Answer ans = new Chooce_Answer();
                    ans.sName = r[2].ToString();
                    if (!r.IsDBNull(3))
                         ans.sExport = r[3].ToString();
                    if (!r.IsDBNull(4))
                        ans.image = DBConvertFormat.toImage(r[4]);
                    outFeature.sAnswers.Add(ans);
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка sql загрузка Характеристик", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (r != null)
                    r.Close();
            }
        }

        public class DBObject
        {
            public int id=0;
            public String name="безымянный";
            public int pos=-1;
            public String script="";
            public int flags=0;
            public String sObjects="";

            public static DBObject read(SqlDataReader r)
            {
                DBObject obj = new DBObject();
                obj.id = (int)r[0];
                obj.name = r[1].ToString();
                if (!r.IsDBNull(2))
                    obj.pos = (int)r[2];
                if (!r.IsDBNull(3))
                    obj.script = r[3].ToString();
                if (!r.IsDBNull(4))
                    obj.flags = (int)r[4];
                if (!r.IsDBNull(5))
                    obj.sObjects = r[5].ToString();
                return obj;
            }
        }

        private static class DBConvertFormat
        {
            public static String arrayToString(int [] a)
            {
                if (a != null & a.Length > 0) return null;
                String s ="";

                for (int i = 0,l = a.Length - 1; i <l; i++)
                {
                    s += a[i] + ", ";
                }
                s += a[a.Length - 1];
                return s;
            }

            public static int [] stringToArray (String s)
            {
                if (s == null || s.Length == 0) return null;
                int[] a=null;
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

            public static Image toImage(Object v)
            {
                if (v == null) return null;
                try
                {
                    return (Image)(new ImageConverter().ConvertFrom((byte[])v));
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка sql Картинки", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return null;
            }
        } 

    }
}
