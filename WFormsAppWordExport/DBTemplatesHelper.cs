﻿/**
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
//using System.Data.SqlClient;
using Npgsql;
using System.Windows.Forms;
using System.Data;
using System.IO;
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
        static String name {
            get
            {
                return ProjectDataHelper.sUser;
            }
        }
        static String fullName
        {
            get
            {
                return "\"" + dir + ProjectDataHelper.sUser + "\"";
            }
        }
        static String dir {
            get
            {
                //  return Application.CommonAppDataPath;
                return Application.UserAppDataPath;
            }
           
        }

        NpgsqlConnection myConn = null;
        String fileParamsName { get
            {
                return dir + "\\" + name + ".prms";
            }
        }
        String fileLogsName
        {
            get{
                return dir + "\\" + name + "_log.ldf";
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

        private DBTemplatesHelper ()
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
                {
                    bindDB();
                    openDB();
                }
                   
        }
      
        private void bindDB()
        {
            //myConn = new NpgsqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;");
            myConn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;");
            String str = "CREATE DATABASE " + name + " ON  "
                + "(NAME = MyDatabase_Data, " +
                "FILENAME = '" + fileParamsName + "') FOR ATTACH; ";
            myConn.Open();
            try
            {
                new NpgsqlCommand(str, myConn).ExecuteNonQuery();
            }catch(System.SystemException es)
            {

            }
            finally
            {
                if (myConn!=null)
                    myConn.Close();
            }
         

        }

        public static void closeDB()
        {
            if (initial == null) return;
            if (initial.myConn != null && initial.myConn.State == ConnectionState.Open)
            {
                initial.myConn.Close();
            }
            try
            {
                //initial.myConn = new NpgsqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;User Instance=False");
                initial.myConn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;");
                initial.myConn.Open();
                new NpgsqlCommand(@"ALTER DATABASE " + name + @" SET offline  WITH ROLLBACK IMMEDIATE;" +
                            "DROP DATABASE [" + name + "]", initial.myConn).ExecuteNonQuery();
                initial.myConn.Close();//SINGLE_USER WITH ROLLBACK IMMEDIATE; SINGLE_USER
            }
            catch (System.Exception)
            {

            }
            finally
            {
                initial = null;
            }
           
        }

        private void createDB()
        {
            if (name.Equals(sysName))
            {
                #region create sys db 
                //myConn = new NpgsqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;");
                myConn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;");

                String str = "CREATE DATABASE " + name + " ON PRIMARY " 
                    +"(NAME = MyDatabase_Data, " +
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

                    NpgsqlCommand myCommand = new NpgsqlCommand(str, myConn);
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
                    if (myConn!=null&&myConn.State == ConnectionState.Open)
                    {
                        myConn.Close();
                    }
                }
                #endregion
                    

                openDB();
                buildSysDB();
                fILLDB();
            }
            else
            {
                File.Copy(fileParamsSysName, fileParamsName);
                bindDB();
                openDB();
            } 
           

        }

        private void openDB()
        {
            try
            {
                //myConn = new NpgsqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='" + fileParamsName + "';"
             //+ "Integrated Security=True;Connect Timeout=30;");
                myConn = new NpgsqlConnection("Server=127.0.0.1;Port=5432; AttachDbFilename='" + fileParamsName + "';");
                myConn.Open();
            }
            catch (SystemException es)
            {
                recoveryBugOpen();
            }
               

        }

        private void recoveryBugOpen()
        {
            DialogResult res = MessageBox.Show("Удалить файлы конфигураций " + fileParamsName +"\n"+ fileLogsName + "? ", "Файлы конфигураций повреждены.", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (res == DialogResult.Yes)
            {
                try
                {
                    myConn = null;
                    closeDB();
                  
                }
                catch
                {
                    MessageBox.Show("Приложение сейчас закроется.\nУдалите файлы конфигураций " + fileParamsName + "\n" + fileLogsName + ". Попробуйте перезапустить программу",
                        "Не удалось корректно закончить работу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                try {
                    if (File.Exists(fileParamsName))
                        File.Delete(fileParamsName);
                    if (File.Exists(fileLogsName))
                        File.Delete(fileLogsName);
                }
                catch
                {
                    MessageBox.Show("Приложение сейчас закроется.\nУдалите файлы конфигураций " + fileParamsName + "\n" + fileLogsName, "Не удалось удалить файлы конфигураций", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try {
                    myConn = null;
                    create_openDB();
                } catch
                {
                    MessageBox.Show("Приложение сейчас закроется.\nУдалите файлы конфигураций " + fileParamsName + "\n" + fileLogsName + ". Попробуйте перезапустить программу",
                        "Не удалось корректно закончить работу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

            }
            else
            {
                Application.Exit();
            }
        }

        private void buildSysDB()
        {
            String s1, s2, s3, s4, s5, s6,s7;
            s1 = "CREATE TABLE \"Параграфы\"  (id INTEGER PRIMARY KEY IDENTITY, flag int NOT NULL,Script ntext)";
            s2 = "CREATE TABLE \"Образ Обьекта\"  (id INTEGER PRIMARY KEY IDENTITY, Название ntext NOT NULL, Очередность int default 0,Скрипт ntext, flags int, \"ids абстрактных обьектов\" ntext )";
            s3 = "CREATE TABLE \"Характеристика\"  (id INTEGER PRIMARY KEY IDENTITY,Тип int, Вопрос ntext NOT NULL, Очередность int, \"Условие вопроса\" ntext, \"Скрипт после ответа\" ntext)";
            s4 = "CREATE TABLE \"Вариант ответа\"  (id INTEGER PRIMARY KEY IDENTITY, Очередность int, \"Звучание по вопросу\" ntext NOT NULL, \"Звучание по ответу\" ntext, Картинка image, Обьект int)";
            s5 = "CREATE TABLE \"Выборка\"  (id INTEGER PRIMARY KEY IDENTITY, \"id характеристики\" INTEGER FOREIGN KEY REFERENCES Характеристика (id)  ON DELETE CASCADE,"
                + " \"id варианта\" INTEGER FOREIGN KEY REFERENCES \"Вариант ответа\" (id)  ON DELETE CASCADE )";
            s6 = "CREATE TABLE \"Описание обьекта\"  (id INTEGER PRIMARY KEY IDENTITY, \"id Образа обьекта\" INTEGER FOREIGN KEY REFERENCES \"Образ Обьекта\"  (id)  ON DELETE CASCADE,"
                + " \"id характеристики\" INTEGER FOREIGN KEY REFERENCES \"Характеристика\" (id)  ON DELETE CASCADE)";

            try
            {
                new NpgsqlCommand(s1, myConn).ExecuteNonQuery();
                new NpgsqlCommand(s2, myConn).ExecuteNonQuery();
                new NpgsqlCommand(s3, myConn).ExecuteNonQuery();
                new NpgsqlCommand(s4, myConn).ExecuteNonQuery();
                new NpgsqlCommand(s5, myConn).ExecuteNonQuery();
                new NpgsqlCommand(s6, myConn).ExecuteNonQuery();
            }
            catch
            {

            }
         
        }

        private void fILLDB()
        {
            String s;
            s = "INSERT INTO \"Образ Обьекта\" (Название,flags,Очередность) VALUES (N'Пешеход',1,0),(N'Водитель',1,1),(N'Пострадавший',1,2)";
            new NpgsqlCommand(s, myConn).ExecuteNonQuery();
            s = "INSERT INTO \"Характеристика\" (Вопрос) VALUES (N'Имя'),(N'Возраст'),(N'стаж'),(N'степень повреждений'),(N'место в машине')";
            new NpgsqlCommand(s, myConn).ExecuteNonQuery();
            s = "INSERT INTO \"Описание Обьекта\" (\"id характеристики\",\"id образа обьекта\") VALUES (1,1),(1,2),(1,3),(2,1),(2,2),(2,3),(3,2),(4,3),(5,1)";
            new NpgsqlCommand(s, myConn).ExecuteNonQuery();
        }

        ~DBTemplatesHelper()
        {
          //closeDB();
            initial = null;
        }


        #endregion

        #region public methods

        public List<DBObject> getObjects()
        {
            return DBObject.getAll();
        }
       
        public void bindingFeaturesForObjectById(BindingSource outBindingSource, int idObj)
        {
            String s = "SELECT [Характеристика].* FROM [Образ Обьекта],[Характеристика], [Описание обьекта] WHERE [Образ Обьекта].id = "+idObj
                +" and [Описание обьекта].[id Образа обьекта]=[Образ Обьекта].id and [Описание обьекта].[id характеристики]=Характеристика.id "
                 + "order by isnull([Характеристика].Очередность,2147483647)";
            
            NpgsqlDataAdapter sqlAdapter = new NpgsqlDataAdapter(s, myConn);
            NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(sqlAdapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            sqlAdapter.Fill(table);
            outBindingSource.DataSource = table;
        }

        public void fillNewProjectTree(out List<Essence> outNodes)
        {
            outNodes = new List<Essence>();
            List<int> outNodesIds = new List<int>();
            List<int[]> contextNodesGroupsIds = new List<int[]>();
            //корневае узлы
            String s1 = "Select * from [Образ Обьекта] where[Образ Обьекта].flags & 1 = 1 order by  isnull([Образ Обьекта].Очередность,2147483647)";

            NpgsqlDataReader r = null;
            Essence es = null;

            #region Заполнение узлов дерева с данными из базы
            try
            {
                r = new NpgsqlCommand(s1, myConn).ExecuteReader();
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

            NpgsqlDataReader r = null;
            List<int> idsFeatures = new List<int>();
            try
            {
                r = new NpgsqlCommand(s, myConn).ExecuteReader();
                while (r.Read())
                {
                    Feature f = new Feature(outEs,(int)r[0], r[2].ToString(), null, r.IsDBNull(1) ? 0 : (TYPE_ANSWER)(int)r[1], r.IsDBNull(4) ? null : r[4].ToString(),
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
            NpgsqlDataReader r = null;
            try
            {
                r = new NpgsqlCommand(s, myConn).ExecuteReader();
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
                new NpgsqlCommand(s, myConn).ExecuteNonQuery();
                return "";   
            }

            return rtfText;
        }

        public void updateTextParagraph(String rtfText)
        {
            try {
                String s = "Update [Параграфы] SET Script= @T WHERE flag = 1";
                NpgsqlCommand cmd = new NpgsqlCommand(s, myConn);
                //cmd.Parameters.Add("@T", NpgsqlTypes.NpgsqlDbType.Text).Value = rtfText;
                cmd.ExecuteNonQuery();
            }catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка обновления базы", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public int insertCodeToDB(String script,int flag)
        {
            String s = @"insert into [Параграфы] (flag,script) Values ("+flag+",N'" + script + "')";
            new NpgsqlCommand(s, myConn).ExecuteNonQuery();

            s = "SELECT @@IDENTITY";
            NpgsqlDataReader r = null;
            try
            {
                r = new NpgsqlCommand(s, myConn).ExecuteReader();
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
            NpgsqlDataReader r =null;
            try
            {
                r = new NpgsqlCommand(s, myConn).ExecuteReader();
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
            try {
                String s = "Update [Параграфы] SET script=N'" + script + "' WHERE id = " + id;
                new NpgsqlCommand(s, myConn).ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка обновления базы", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void delCodeById(int id)
        {
            try
            {
                String s = "DELETE FROM [Параграфы] WHERE id = " + id;
                new NpgsqlCommand(s, myConn).ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка обновления базы", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            NpgsqlDataReader r = null;
            Essence es = null;

            #region Заполнение узла абстрактными узлами
            try
            {
                r = new NpgsqlCommand(s, myConn).ExecuteReader();
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

            NpgsqlDataReader r = null;
            try
            {
                r = new NpgsqlCommand(s, myConn).ExecuteReader();
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
            NpgsqlDataReader r = null;
            try
            {
                r = new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
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
            public int id = 0;
            public String name = "безымянный";
            public int pos = -1;
            public String script = "";
            public int flags = 0;
            public String sObjects = "";


            public static DBObject get(int id)
            {
                String s = "SELECT * FROM \"Образ Обьекта\" WHERE id = " + id + " ";
                NpgsqlDataReader r = null;
                try
                {
                    r = new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
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
                String s = "SELECT * FROM [Образ Обьекта] "
                      + "order by  isnull(Очередность,2147483647)";
                NpgsqlDataReader r = null;
                try
                {
                    r = new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
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
                for (int i = 0; i < dbObjs.Count(); ++i)
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

            public static DBObject read(NpgsqlDataReader r)
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

            public static void updateUp(int id)
            {
                String s = new StringBuilder().AppendFormat("SELECT [id],[Очередность] FROM [Образ Обьекта] WHERE [Очередность] <= ANY "
                    + "(SELECT [Очередность] FROM [Образ Обьекта] WHERE [id]= {0})"
                      + "order by Очередность DESC", "" + id).ToString();

                NpgsqlDataReader r = null;
                int pos = -1;//pos of selected node
                int id1 = -1, pos1 = -1;//the node above
                #region read r to prms 
                try
                {
                    r = new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
                    if (r.Read())
                    {
                        pos = (int)r[1];
                    }

                    if (r.Read())
                    {
                        id1 = (int)r[0];
                        pos1 = (int)r[1];
                    }


                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка sql загрузка update UP DBObject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (r != null)
                        r.Close();
                }
                #endregion 

                if (id1 == -1) return;
                updateSwapPositions(id, pos, id1, pos1);

            }

            public static void updateDown(int id)
            {
                String s = new StringBuilder().AppendFormat("SELECT [id],[Очередность] FROM [Образ Обьекта] WHERE [Очередность] >= ANY "
                   + "(SELECT [Очередность] FROM [Образ Обьекта] WHERE [id]= {0})"
                     + " order by isnull(Очередность, 2147483647)", "" + id).ToString();

                NpgsqlDataReader r = null;
                int pos = -1;//pos of selected node
                int id1 = -1, pos1 = -1;//the node above
                #region read r to prms 
                try
                {
                    r = new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
                    if (r.Read())
                    {
                        pos = (int)r[1];
                    }

                    if (r.Read())
                    {
                        id1 = (int)r[0];
                        pos1 = (int)r[1];
                    }


                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка sql загрузка update UP DBObject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (r != null)
                        r.Close();
                }
                #endregion 

                if (id1 == -1) return;

                updateSwapPositions(id, pos, id1, pos1);
            }

            public static void deleteFromDB(int id)
            {
                try
                {
                    String s;
                    s = "Delete from [Образ обьекта]  WHERE [id] =" + id;
                    new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка обновления базы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            private static void updateSwapPositions(int id, int pos, int id1, int pos1)
            {
                try
                {
                    String s = new StringBuilder().AppendFormat("UPDATE [Образ Обьекта] SET [Очередность]= {0} WHERE [id]={1}", "" + pos1, "" + id).ToString();
                    new NpgsqlCommand(s, DBTemplatesHelper.initial.myConn).ExecuteNonQuery();
                    s = new StringBuilder().AppendFormat("UPDATE [Образ Обьекта] SET [Очередность]= {0} WHERE [id]={1}", "" + pos, "" + id1).ToString();
                    new NpgsqlCommand(s, DBTemplatesHelper.initial.myConn).ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка обновления базы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            public static int getLastPos()
            {
                String s = "SELECT TOP 1 [Очередность] FROM [Образ Обьекта]  "
                     + "order by Очередность DESC";
                NpgsqlDataReader r = null;
                try
                {
                    r = new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
                    if (r.Read())
                    {
                        return (int)r[0];
                    }

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка sql получение последнего обьекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (r != null)
                        r.Close();
                }
                return -1;
            }

            public int insertToDB()
            {
                #region insert to db
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    String s = "INSERT INTO [Образ обьекта] ([Название]", p = " VALUES(N'" + name + "' ";
                    if (pos == -1)
                    {
                        pos = getLastPos() + 1;
                    }

                    s += ", Очередность ";
                    p += "," + pos + " ";

                    if (script != null)
                    {
                        s += ",[Скрипт]";
                        p += ",N'" + script + "' ";
                    }
                    s += ",flags ";
                    p += "," + flags + " ";
                    if (sObjects != null)
                    {
                        s += ", [ids абстрактных обьектов] ";
                        p += ",N'" + sObjects + "' ";
                    }
                    s += ")"; p += ")";
                    cmd.CommandText = s + p;
                    cmd.Connection = DBTemplatesHelper.get().myConn;
                    cmd.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка обновления базы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteNonQuery();
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

            public DBFeature(int dbObjParent)
            {
                #region set position after last added
                List<DBFeature> fs = getFeatures(dbObjParent);
                if (fs == null || fs.Count == 0)
                {
                    pos = 0;
                }else
                {
                    pos = fs[fs.Count - 1].pos + 1;
                }
                #endregion
            }
            private DBFeature()
            {

            }

            public static DBFeature get(int id)
            {
                String s = "SELECT * FROM [Характеристика] WHERE id = " + id + " ";
                NpgsqlDataReader r = null;
                try
                {
                    r = new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
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

            public static DBFeature read(NpgsqlDataReader r)
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


                NpgsqlDataReader r = null;
                try
                {
                    r = new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
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
                    if (r!=null)
                    r.Close();
                }
                return features;
            }

            public void updateToDB()
            {
                try
                {
                    String s = "UPDATE [Характеристика] SET [Вопрос]=N'" + sQuestion + "' "
                        + ", [Тип] =" + (int)type;
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
                    new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка обновления базы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            private void insertToDB()
            {
                String s;
                #region paste to queue
                if (pos != -1)
                {
                    s = "UPDATE [Характеристика] SET [Очередность]=[Очередность]+1 WHERE [Очередность]>=" + pos;
                    new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteNonQuery();
                }
                #endregion

                try
                {
                    s = "INSERT INTO [Характеристика] ( Тип,Вопрос ";
                    String p = " Values (" + (int)type + ",N'" + sQuestion + "'";
                    if (pos != -1)
                    {
                        s += ", Очередность ";
                        p += "," + pos;
                    }
                    if (scriptCondition != null && scriptCondition.Length > 0)
                    {
                        s += ", [Условие вопроса] ";
                        p += ",N'" + scriptCondition + "'";
                    }
                    if (scriptAfter != null && scriptAfter.Length > 0)
                    {
                        s += ", [Скрипт после ответа] ";
                        p += ",N'" + scriptAfter + "'";
                    }
                    s += ")";
                    p += ")";
                    new NpgsqlCommand(s + p, DBTemplatesHelper.get().myConn).ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка обновления базы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            public void insertToDB(int idObject)
            {
                insertToDB();
                String s = "SELECT @@IDENTITY";
                NpgsqlDataReader r = null;
                
                try
                {
                    r = new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
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
                new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteNonQuery();
            }

            public void deleteFromDB()
            {
                try
                {
                    String s = "Delete from [Характеристика]  WHERE[id] =" + id;
                    new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка обновления базы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

            public static DBAnswer read(NpgsqlDataReader r)
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

            public static List<DBAnswer> getAnswers()
            {
                List<DBAnswer> answers = new List<DBAnswer>();
                String s = "SELECT [Вариант ответа].* FROM [Вариант ответа]"
                    + "order by  isnull([Вариант ответа].Очередность,2147483647)";

                NpgsqlDataReader r = null;
                try
                {
                    r = new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
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
                    if (r!=null)
                    r.Close();
                }

                return answers;
            }

            public static List<DBAnswer> getAnswers(int idFeature)
            {
                List<DBAnswer> answers = new List<DBAnswer>();
                String s = "SELECT [Вариант ответа].* FROM [Вариант ответа],[Выборка],[Характеристика] "
                    + " WHERE [Характеристика].id= " + idFeature + " and [Характеристика].id=[Выборка].[id Характеристики] and [Вариант ответа].id=[Выборка].[id Варианта] "
                    + "order by  isnull([Вариант ответа].Очередность,2147483647)";

                NpgsqlDataReader r = null;
                try
                {
                    r = new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
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
                    if (r!=null)
                    r.Close();
                }

                return answers;
            }

            public void deleleteFromDB()
            {
                try
                {
                    String s;
                    s = "Delete from [Вариант ответа]  WHERE [id] =" + id;
                    new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка обновления базы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            public void insertAnswer(int idFeature)
            {
                try
                {
                    #region insert to [вариант ответа]
                    NpgsqlCommand cmd = new NpgsqlCommand();
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
                        cmd.Parameters.Add("@PIC", SqlDbType.Image).Value = ConvertFormat.toByteArray(image);
                    }
                    if (idObject != -1)
                    {
                        s += ", Обьект ";
                        p += "," + idObject;
                    }
                    s += ")"; p += ")";
                    cmd.CommandText = s + p;
                    cmd.Connection = DBTemplatesHelper.get().myConn;
                    cmd.ExecuteNonQuery();
                    #endregion

                    s = "SELECT @@IDENTITY";
                    NpgsqlDataReader r = null;
                    try
                    {
                        r = new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
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
                    new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка обновления базы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }

        }

        public class DBParagraph
        {
            public int id;
            public int flag=0;
            public String text;

            public static DBParagraph read(NpgsqlDataReader r)
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

                NpgsqlDataReader r = null;
                try
                {
                    r = new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
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
                    if (r!=null)
                    r.Close();
                }

                return paragraphs;
            }

            public static DBParagraph getText()
            {
                List<DBParagraph> paragraphs = new List<DBParagraph>();
                String s = "SELECT * FROM [Параграфы] WHERE flag = 1";

                NpgsqlDataReader r = null;
                try
                {
                    r = new NpgsqlCommand(s, DBTemplatesHelper.get().myConn).ExecuteReader();
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
                    if (r!=null)
                    r.Close();
                }

                return null;
            }
        }

   
        #endregion
    }
}
