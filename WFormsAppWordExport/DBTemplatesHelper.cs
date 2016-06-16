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
using System.Windows.Forms;

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
        }

        public void create_openDB()
        {
            if (myConn == null)
                if (!File.Exists(dir + "\\" + name + ".dmf"))
                {
                    createDB();
                }
                else
                    openDB();
        }
      
        public void closeDB()
        {
            if (myConn != null&myConn.State == ConnectionState.Open)
            {
                myConn.Close();
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
                +" and [Описание обьекта].[id Образа обьекта]=[Образ Обьекта].id and [Описание обьекта].[id характеристики]=Характеристика.id";
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

        ~DBTemplatesHelper()
        {
            initial = null;
   //         closeDB();
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
    }
}
