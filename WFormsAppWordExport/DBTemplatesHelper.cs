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
   public class DBTemplatesHelper
    {
        static private DBTemplatesHelper initial;
        static String sysName = "sys";
        static String name { get
            {
                return ProjectDataHelper.sUser;
            }
        }
        String dir = Directory.GetCurrentDirectory();
        SqlConnection myConn = null;
        String fileParamsName { get
            {
                return dir + "\\" + name + ".prms";
            }
        }

        String fileParamsSysName
        {
            get
            {
                return dir + "\\" + sysName + ".prms";
            }
        }

        #region contructions DB- methodes
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
                if (!File.Exists(fileParamsName))
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

        private void createDB()
        {
            if (name.Equals("sys"))
            {
                #region create sys db 
                myConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;");
                
               
                String str = "CREATE DATABASE " + name + " ON PRIMARY " +
                    "(NAME = MyDatabase_Data, " +
                    "FILENAME = '" + fileParamsName  //+ dir + "\\" + name + ".dmf'
                    + "', " +
                     " SIZE = 5MB," +
                      " MAXSIZE = 30MB," +
                     " FILEGROWTH = 10%)";/* +

                    "LOG ON (NAME = MyDatabase_Log, " +
                    "FILENAME = '" + dir + "\\" + name + ".ldf" + "', " +
                    "SIZE = 1MB, " +
                    "MAXSIZE = 5MB, " +
                    "FILEGROWTH = 10%)";*/
                
                try
                {

                    SqlCommand myCommand = new SqlCommand(str, myConn);
                    myConn.Open();
                    myCommand.ExecuteNonQuery();
                    myConn.Close();


                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка создания БД", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (myConn.State == ConnectionState.Open)
                    {
                        myConn.Close();
                    }
                }
                #endregion*/
                    
              //  new DataContext(fileParamsName)
                //    .CreateDatabase();

                openDB();
                buildSysDB();
                fILLDB();
            }
            else
            {
                File.Copy(fileParamsSysName, fileParamsName);
                openDB();
            } 
           

        }

        private void openDB()
        {
            //     myConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + dir + "\\" + name + ".dmf;Integrated Security=True;Connect Timeout=30");
            myConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='" +fileParamsName+"';Integrated Security=True;Connect Timeout=30");
            myConn.Open();
        }

        private void buildSysDB()
        {
            String s1, s2, s3, s4, s5, s6,s7;
            s1 = "CREATE TABLE \"Параграфы\"  (id INTEGER PRIMARY KEY IDENTITY, flag int NOT NULL,Script ntext)";
            s2 = "CREATE TABLE \"Образ Обьекта\"  (id INTEGER PRIMARY KEY IDENTITY, Название ntext NOT NULL, Очередность int,Скрипт ntext, flags int, \"ids абстрактных обьектов\" ntext )";
            s3 = "CREATE TABLE \"Характеристика\"  (id INTEGER PRIMARY KEY IDENTITY,Тип int, Вопрос ntext NOT NULL, Очередность int, \"Условие вопроса\" ntext, \"Скрипт после ответа\" ntext)";
            s4 = "CREATE TABLE \"Вариант ответа\"  (id INTEGER PRIMARY KEY IDENTITY, Очередность int, \"Звучание по вопросу\" ntext NOT NULL, \"Звучание по ответу\" ntext, Картинка image, Обьект int)";
            s5 = "CREATE TABLE \"Выборка\"  (id INTEGER PRIMARY KEY IDENTITY, \"id характеристики\" INTEGER FOREIGN KEY REFERENCES Характеристика (id),"
                + " \"id варианта\" INTEGER FOREIGN KEY REFERENCES \"Вариант ответа\" (id)  ON DELETE CASCADE )";
            s6 = "CREATE TABLE \"Описание обьекта\"  (id INTEGER PRIMARY KEY IDENTITY, \"id Образа обьекта\" INTEGER FOREIGN KEY REFERENCES \"Образ Обьекта\"  (id),"
                + " \"id характеристики\" INTEGER FOREIGN KEY REFERENCES \"Характеристика\" (id)  ON DELETE CASCADE ON UPDATE CASCADE)";
            s7 = "CREATE TABLE [Word]  (id INTEGER PRIMARY KEY IDENTITY, word ntext,"
                + " flag int, class ntext,classesIn ntext,fields ntext, description ntext, rootWord int)";

            new SqlCommand(s1, myConn).ExecuteNonQuery();
            new SqlCommand(s2, myConn).ExecuteNonQuery();
            new SqlCommand(s3, myConn).ExecuteNonQuery();
            new SqlCommand(s4, myConn).ExecuteNonQuery();
            new SqlCommand(s5, myConn).ExecuteNonQuery();
            new SqlCommand(s6, myConn).ExecuteNonQuery();
            new SqlCommand(s7, myConn).ExecuteNonQuery();
        }

        private void fILLDB()
        {
            String s;
            s = "INSERT INTO \"Образ Обьекта\" (Название,flags) VALUES (N'Пешеход',1),(N'Водитель',1),(N'Пострадавший',1)";
            new SqlCommand(s, myConn).ExecuteNonQuery();
            s = "INSERT INTO \"Характеристика\" (Вопрос) VALUES (N'Имя'),(N'Возраст'),(N'стаж'),(N'степень повреждений'),(N'место в машине')";
            new SqlCommand(s, myConn).ExecuteNonQuery();
            s = "INSERT INTO \"Описание Обьекта\" (\"id характеристики\",\"id образа обьекта\") VALUES (1,1),(1,2),(1,3),(2,1),(2,2),(2,3),(3,2),(4,3),(5,1)";
            new SqlCommand(s, myConn).ExecuteNonQuery();
        }

        private void copyDBFromSys()
        {

        }

        ~DBTemplatesHelper()
        {
            closeDB();
            initial = null;
        }


        #endregion

        #region public methods

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

        public void fillNewProjectTree(out List<Essence> outNodes)
        {
            outNodes = new List<Essence>();
     //       outContextNodes = new List<Essence>();
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
                   es=new Essence((int)r[0],r[1].ToString(),
                        (r.IsDBNull(4))?0:(ESSENSE_FLAGS)r[4], (r.IsDBNull(3)) ? null : (String)r[3].ToString(),null, null);
                    outNodes.Add(es);

                    outNodesIds.Add((int)r[0]);
                    contextNodesGroupsIds.Add(r.IsDBNull(5)?null:ConvertFormat.stringToArray(r[5].ToString()));
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
                getFeatures(es, (int)outNodesIds[i]);
            }

            for (int i = 0, l = outNodes.Count; i < l; i++)
            {
                es = outNodes[i];
                getAbstractEssences(es, contextNodesGroupsIds[i]);
            }
            #endregion
        }

        public void getFeatures(Essence outEs, int idEss)
        {
            String s = "SELECT [Характеристика].* FROM [Образ Обьекта],[Характеристика], [Описание обьекта] WHERE [Образ Обьекта].id = " + idEss
               + " and [Описание обьекта].[id Образа обьекта]=[Образ Обьекта].id and [Описание обьекта].[id характеристики]=Характеристика.id "
               + "order by  isnull([Характеристика].Очередность,2147483647)";

            SqlDataReader r = null;
            List<int> idsFeatures = new List<int>();
            try
            {
                r = new SqlCommand(s, myConn).ExecuteReader();
                while (r.Read())
                {
                    Feature f = new Feature((int)r[0], r[2].ToString(), null, r.IsDBNull(1) ? 0 : (TYPE_ANSWER)(int)r[1], r.IsDBNull(4) ? null : r[4].ToString(),
                        r.IsDBNull(5) ? null : r[5].ToString());
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
            for (int i = 0, l = outEs.features.Count; i < l; i++)
            {
                getChooseAnswersToFeature(outEs.features[i], idsFeatures[i]);
            }

        }


        #region table [Параграфы]
        public String getTextParagraph()
        {
            String rtfText=null;
            String s = "SELECT * FROM [Параграфы] WHERE flag = 1";
            SqlDataReader r = null;
            try
            {
                r = new SqlCommand(s, myConn).ExecuteReader();
                if (r.Read())
                {
                    rtfText = r[2].ToString();
                }
               
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка sql поиска текста ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (r != null)
                    r.Close();
            }
            if (rtfText==null)
            {
                s = @"insert into [Параграфы] (flag,Script) Values (1,N'')";
                new SqlCommand(s, myConn).ExecuteNonQuery();
                return "";   
            }

            return rtfText;
        }

        public void updateTextParagraph(String rtfText)
        {
            String s = "Update [Параграфы] SET Script= @T WHERE flag = 1";
            SqlCommand cmd = new SqlCommand(s,myConn);
            cmd.Parameters.Add("@T", SqlDbType.NText).Value=rtfText;
            cmd.ExecuteNonQuery();
        }


        public int insertCodeToDB(String script,int flag)
        {
            String s = @"insert into [Параграфы] (flag,script) Values ("+flag+",N'" + script + "')";
            new SqlCommand(s, myConn).ExecuteNonQuery();

            s = "SELECT @@IDENTITY";
            SqlDataReader r = null;
            try
            {
                r = new SqlCommand(s, myConn).ExecuteReader();
                r.Read();
                int id = (int)Decimal.ToInt32((Decimal)r[0]);
                return id;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка sql id вставленного кода в базу", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (r != null)
                    r.Close();
            }
            return -1;
        }

        public String getCodeById(int id)
        {
            String code = null;
            String s = "SELECT * FROM [Параграфы] WHERE id = " + id;
            SqlDataReader r=null;
            try
            {
                r = new SqlCommand(s, myConn).ExecuteReader();
                r.Read();
                code = r[2].ToString();
                return code;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка sql загрузки кода из базы по id ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (r != null)
                    r.Close();
            }
            return null;
        }

        public void updateCodeById(int id,String script)
        {
            String s = "Update [Параграфы] SET script=N'"+script+"' WHERE id = " + id;
            new SqlCommand(s, myConn).ExecuteNonQuery();
        }

        public void delCodeById(int id)
        {
            String s = "DELETE FROM [Параграфы] WHERE id = "+id;
            new SqlCommand(s, myConn).ExecuteNonQuery();
        }

     
        #endregion

        #endregion

        #region private methods 
        private void getAbstractEssences(Essence outNode,int[] idsEs)
        {
            if (idsEs == null || idsEs.Length == 0) return;

            String s = "SELECT * FROM [Образ Обьекта] WHERE id = " + idsEs[0];
                
            for (int i = 1; i < idsEs.Length; i++)
            {
                s += " or id=" + idsEs[i]+" ";
            }
            s+= "order by  isnull([Образ Обьекта].Очередность,2147483647)";
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
                    es = new Essence((int)r[0],r[1].ToString(),
                         (r.IsDBNull(4)) ? 0 : (ESSENSE_FLAGS)r[4], (r.IsDBNull(3)) ? null : (String)r[3].ToString(), null, null);
                    outNode.abstrEssences.Add(es);

                    outNodesIds.Add((int)r[0]);
                    contextNodesGroupsIds.Add(r.IsDBNull(5) ? null : ConvertFormat.stringToArray(r[5].ToString()));
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
                getFeatures(es, (int)outNodesIds[i]);
            }

            for (int i = 0, l = outNodesIds.Count; i < l; i++)
            {
                es = outNode.abstrEssences[i];
                getAbstractEssences(es, contextNodesGroupsIds[i]);
            }
            #endregion
        }

      

        private void getChooseAnswersToFeature(Feature outFeature,int idFeature)
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
                    outFeature.sAnswers.Add(new Choose_Answer(DBAnswer.read(r)));
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

        private int getLastID()
        {
            String s = "SELECT @@IDENTITY";
            SqlDataReader r = null;
            try
            {
                r = new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
                r.Read();
                return (int)Decimal.ToInt32((Decimal)r[0]);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка sql чтение последнего id", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (r != null)
                    r.Close();
            }
            return -1;

        }
        #endregion

        #region myTypes
        public class DBObject
        {
            public int id=0;
            public String name="безымянный";
            public int pos=-1;
            public String script="";
            public int flags=0;
            public String sObjects="";

            public static DBObject get(int id)
            {
                String s = "SELECT * FROM \"Образ Обьекта\" WHERE id = " + id + " ";
                SqlDataReader r = null;
                try
                {
                    r = new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
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

            public static List<DBObject> getAll()
            {
                List<DBObject> dbObjs = new List<DBObject>();
                String s = "SELECT * FROM [Образ Обьекта] ";
                SqlDataReader r = null;
                try
                {
                    r = new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
                    while (r.Read())
                    {
                        dbObjs.Add(DBObject.read(r));
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


                return dbObjs;
            }

            public static List<DBObject> getByFlag(int flag)
            {
                List<DBObject> dbObjs = getAll();
                for (int i=0;i<dbObjs.Count();++i)
                {
                    DBObject obj = dbObjs[i];
                    if ((obj.flags & flag) != flag)
                    {
                        dbObjs.Remove(obj);
                        --i;
                    }
                }
                return dbObjs;
            }

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

            public static void deleteFromDB(int id)
            {
                String s;
                s = "Delete from [Образ обьекта]  WHERE [id] =" + id;
                new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteNonQuery();
            }

            public int insertToDB()
            {
                #region insert to db
                SqlCommand cmd = new SqlCommand();
                String s = "INSERT INTO [Образ обьекта] ([Название]", p = " VALUES(N'" + name + "' ";
                if (pos != -1)
                {
                    s += ", Очередность ";
                    p += "," + pos + " ";
                }
                if (script != null)
                {
                    s += ",[Скрипт]";
                    p += ",N'" + script + "' ";
                }
                s += ",flags ";
                p += ","+flags+" ";
                if (sObjects != null)
                {
                    s += ", [ids абстрактных обьектов] ";
                    p += ",N'" + sObjects+"' ";
                }
                s += ")"; p += ")";
                cmd.CommandText = s + p;
                cmd.Connection = DBTemplatesHelper.get().myConn;
                cmd.ExecuteNonQuery();
                #endregion

                return DBTemplatesHelper.initial.getLastID();

            }

            public void updateToDB()
            {
                String s = "UPDATE [Образ обьекта] SET [Название]=N'" + name + "' ";
                if (pos != -1)
                {
                    s += " ,[Очередность] = " + pos;
                }
                if (script != null && script.Length > 0)
                {
                    s += " ,[Скрипт]= N'" + script + "' ";
                }
                s += " ,[flags]= " + flags + " ";
                if (sObjects != null && sObjects.Length > 0)
                {
                    s += " ,[ids абстрактных обьектов]= N'" + sObjects + "' ";
                }
                s += " WHERE[id] =" + id;
                new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteNonQuery();
            }
        }

        public class DBFeature
        {
            public int id = 0;
            public TYPE_ANSWER type =0;
            public String sQuestion = null;
            public int pos = -1;
            public String scriptCondition = null;
            public String scriptAfter = null;

            public static DBFeature get(int id)
            {
                String s = "SELECT * FROM [Характеристика] WHERE id = " + id + " ";
                SqlDataReader r = null;
                try
                {
                    r = new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
                    r.Read();
                    return DBFeature.read(r);
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

                return new DBFeature();
            }

            public static DBFeature read(SqlDataReader r)
            {
                DBFeature f = new DBFeature();
                f.id = (int)r[0];
                if (!r.IsDBNull(1))
                    f.type = (TYPE_ANSWER)(int)r[1];
                f.sQuestion = r[2].ToString();
                if (!r.IsDBNull(3))
                    f.pos = (int)r[3];
                if (!r.IsDBNull(4))
                    f.scriptCondition = r[4].ToString();
                if (!r.IsDBNull(5))
                    f.scriptAfter = r[5].ToString();
                return f;
            }

            public static List<DBFeature> getFeatures()
            {
                return getFeatures(-1);
            }

            public static List<DBFeature> getFeatures (int idObj)
            {
                List<DBFeature> features=new List<DBFeature>();
                String s= "SELECT [Характеристика].* FROM [Образ Обьекта],[Характеристика], [Описание обьекта] WHERE [Образ Обьекта].id = " + idObj
             + " and [Описание обьекта].[id Образа обьекта]=[Образ Обьекта].id and [Описание обьекта].[id характеристики]=Характеристика.id "
             + "order by  isnull([Характеристика].Очередность,2147483647)";
                if (idObj == -1)
                {
                    s = "SELECT [Характеристика].* FROM [Характеристика] "
              + "order by  isnull([Характеристика].Очередность,2147483647)";
                }
                

                SqlDataReader r = null;
                try
                {
                    r = new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
                    while (r.Read())
                    {
                        features.Add(read(r));
                    }

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка sql загрузка Характеристик", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }finally
                {
                    r.Close();
                }
                return features;
            }

            public void updateToDB()
            {
                String s="UPDATE [Характеристика] SET [Вопрос]=N'"+sQuestion+"' "
                    +", [Тип] ="+(int)type;
                if (pos != -1)
                {
                    s += " ,[Очередность] = " + pos;
                }
                if (scriptCondition != null && scriptCondition.Length > 0)
                {
                    s += " ,[Условие вопроса]= N'" + scriptCondition + "' ";
                }
                if (scriptAfter != null && scriptAfter.Length > 0)
                {
                    s += " ,[Скрипт после ответа]= N'" + scriptAfter + "' ";
                }
                s += " WHERE[id] =" + id;
                new SqlCommand(s , DBTemplatesHelper.get().myConn).ExecuteNonQuery();
            }

            private void insertToDB()
            {
                //TODO доделать выравнивание очередности
                String s = "INSERT INTO [Характеристика] ( Тип,Вопрос ", p = " Values ("+(int)type+",N'"+sQuestion+"'";
                if (pos != -1)
                {
                    s += ", Очередность ";
                    p += "," + pos;
                }
                if (scriptCondition != null && scriptCondition.Length > 0)
                {
                    s += ", [Условие вопроса] ";
                    p += ",N'"+scriptCondition+"'";
                }
                if (scriptAfter != null && scriptAfter.Length > 0)
                {
                    s += ", [Скрипт после ответа] ";
                    p += ",N'" + scriptAfter+"'";
                }
                s += ")";
                p += ")";
                new SqlCommand(s + p, DBTemplatesHelper.get().myConn).ExecuteNonQuery();
            }

            public void insertToDB(int idObject)
            {
                insertToDB();
                String s = "SELECT @@IDENTITY";
                SqlDataReader r = null;
                
                try
                {
                    r = new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
                    r.Read();
                    id = (int)Decimal.ToInt32( (Decimal)r[0]);
                    s = "INSERT INTO \"Описание Обьекта\" (\"id характеристики\",\"id образа обьекта\") VALUES ("+ id + ","+ idObject + ")";
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка sql связка Характеристики с обьектом", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (r != null)
                        r.Close();
                }
                new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteNonQuery();
            }

            public void deleteFromDB()
            {
                String s = "Delete from [Характеристика]  WHERE[id] =" + id;
                new SqlCommand(s , DBTemplatesHelper.get().myConn).ExecuteNonQuery();
            }

        }

        public class DBAnswer
        {
            public int id = -1;
            public int pos = 0;
            public String sName = null;
            public String sExport = null;
            public Image image = null;
            public int idObject = -1;

            public static DBAnswer read(SqlDataReader r)
            {
                DBAnswer a = new DBAnswer();
                a.id = (int)r[0];
                if (!r.IsDBNull(1))
                    a.pos = (int)r[1];
                a.sName = r[2].ToString();
                if (!r.IsDBNull(3))
                    a.sExport = r[3].ToString();
                if (!r.IsDBNull(4))
                    a.image = ConvertFormat.toImageFromBMP((byte[])r[4]);
                if (!r.IsDBNull(5))
                    a.idObject = (int)r[5];
                return a;
            }

            public static List<DBAnswer> getAnswers(int idFeature)
            {
                List<DBAnswer> answers = new List<DBAnswer>();
                String s = "SELECT [Вариант ответа].* FROM [Вариант ответа],[Выборка],[Характеристика] "
                    + " WHERE [Характеристика].id= " + idFeature + " and [Характеристика].id=[Выборка].[id Характеристики] and [Вариант ответа].id=[Выборка].[id Варианта] "
                    + "order by  isnull([Вариант ответа].Очередность,2147483647)";

                SqlDataReader r = null;
                try
                {
                    r = new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
                    while (r.Read())
                    {
                        answers.Add(DBAnswer.read(r));
                    }

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка sql загрузка ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    r.Close();
                }

                return answers;
            }

            public void deleleteFromDB()
            {
                String s;
                s = "Delete from [Вариант ответа]  WHERE [id] =" + id;
                new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteNonQuery();
            }

            public void insertAnswer(int idFeature)
            {
                #region insert to [вариант ответа]
                SqlCommand cmd = new SqlCommand();
                String s = "INSERT INTO [Вариант ответа] ([Звучание по вопросу]", p = " VALUES(N'" + sName + "' ";
                if (pos != -1)
                {
                    s += ", Очередность ";
                    p += "," + pos + " ";
                }
                if (sExport != null)
                {
                    s += ",[Звучание по ответу]";
                    p += ",N'" + sExport + "' ";
                }
                if (image != null)
                {
                    s += ",Картинка ";
                    p += ",@PIC";
                    cmd.Parameters.Add("@PIC", SqlDbType.Image).Value=ConvertFormat.toByteArray(image);
                }
                if (idObject != -1)
                {
                    s += ", Обьект ";
                    p += "," + idObject;
                }
                s += ")"; p += ")";
                cmd.CommandText = s + p;
                cmd.Connection=DBTemplatesHelper.get().myConn;
                cmd.ExecuteNonQuery();
                #endregion

                s = "SELECT @@IDENTITY";
                SqlDataReader r = null;
                try
                {
                    r = new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
                    r.Read();
                    int id = (int)Decimal.ToInt32((Decimal)r[0]);
                    s = "INSERT INTO [Выборка] ([id варианта],[id характеристики]) VALUES (" + id + "," + idFeature + ")";
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка sql связка Характеристики с обьектом", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (r != null)
                        r.Close();
                }
                new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteNonQuery();
            


        }

        }

        public class DBParagraph
        {
            public int id;
            public int flag=0;
            public String text;

            public static DBParagraph read(SqlDataReader r)
            {
                DBParagraph p = new DBParagraph();
                p.id = (int)r[0];
                if (!r.IsDBNull(1))
                   p.flag = (int)r[1];
                if (!r.IsDBNull(2))
                    p.text = r[2].ToString();
                return p;
            }

            public static List<DBParagraph> getAllParagraphs()
            {
                List<DBParagraph> paragraphs = new List<DBParagraph>();
                String s = "SELECT * FROM [Параграфы]";

                SqlDataReader r = null;
                try
                {
                    r = new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
                    while (r.Read())
                    {
                        paragraphs.Add(DBParagraph.read(r));
                    }

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка sql загрузка параграфов", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    r.Close();
                }

                return paragraphs;
            }

            public static DBParagraph getText()
            {
                List<DBParagraph> paragraphs = new List<DBParagraph>();
                String s = "SELECT * FROM [Параграфы] WHERE flag = 1";

                SqlDataReader r = null;
                try
                {
                    r = new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
                    if (r.Read())
                        return DBParagraph.read(r);
                    else return null;

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка sql загрузка текста параграфа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    r.Close();
                }

                return null;
            }
        }

        public class DBWord
        {
            public int id=-1;
            public String word;
            public int flag;
            public String sClass;
            public List<String> sClassesIn = new List<String>();
            public List<int> fields = new List<int>();
            public String description;
            public bool rootWord;

            public static DBWord read(SqlDataReader r)
            {
                DBWord w = new DBWord();
                w.id = (int)r[0];
                w.word = r[1].ToString();
                w.flag = (int)r[2];
                w.sClass = r[3].ToString();
                w.sClassesIn.AddRange(r[4].ToString().Replace(" ","").Split(','));
                w.fields.AddRange(ConvertFormat.stringToArray(r[5].ToString()));
                w.description=r[6].ToString();
                w.rootWord = (bool)r[7];
                return w;
            }

            public static DBWord get(int id)
            {
                String s = "SELECT * FROM [Words] WHERE id = " + id + " ";
                if (id == -1) return null;
                SqlDataReader r = null;
                r = new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
                if (r.Read())
                    return DBWord.read(r);
                return new DBWord();
            }

            public static List<DBWord> getRoot()
            {
                List<DBWord> dWords = new List<DBWord>();
                String s = "SELECT * FROM [Words] WHERE rootWord = 1  ";
                SqlDataReader r = null;
                try
                {
                    r = new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
                    while (r.Read())
                    {
                        dWords.Add(DBWord.read(r));
                    }
                    return dWords;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка sql read words", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (r != null)
                        r.Close();
                }

                return dWords;
            }
           
            public static int [] getAddress(String suggestion)
            {
                List<int> address = new List<int>();
                String s = suggestion;
                int parentId = -1;
                while (s.Length != 0)
                {
                    String w = getNextWord(s);
                    s = s.Remove(0, w.Length);
                    DBWord parent = get(parentId);
                    if (parent != null && parent.fields != null && parent.fields.Count > 0)
                    {
                        DBWord dbWord = findWordInVariants(w, get(parentId).fields.ToArray());
                        if (dbWord == null || dbWord.id == -1) break;
                        parentId = dbWord.id;
                        address.Add(parentId);
                    }
                    else break;
                  
                }
               
                return address.ToArray();
            } 

            public static DBWord getFromSuggestion(String suggestion)
            {
                int [] address= getAddress(suggestion);
                if (address == null || address.Length == 0) return null;
                return get(address[address.Length - 1]);
            }

            private static DBWord findWordInVariants (String w, int[] ids)
            {
                String s = "SELECT * FROM [Words] WHERE [word]="+w+" ";
                if (ids != null && ids.Length > 0)
                {
                    s += "and (";
                    String d = "";
                    for (int i= 0; i < ids.Length; i++)
                    {
                        s+=d+ " id = "+ids[i]+" ";
                        d = " or ";
                    }
                    s += " )";

                }
                SqlDataReader r = null;
                r = new SqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
                if (r.Read())
                    return DBWord.read(r);
                return new DBWord();
            }

            private static String getNextWord(string s)
            {
                return s.Substring(0, s.IndexOf('.'));
            }
        }

        #endregion
    }
}
