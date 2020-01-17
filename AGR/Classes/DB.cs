using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace AGR
{
    // Класс для работы с БД.
    /*
     

         
         */
   public class DB
    {
        const string Connect_accdb = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
        private OleDbDataAdapter[] OleDBAdapters;
        private OleDbCommandBuilder[] OleCB;
        private string ConnectString; // Строка подключения

       // public string[] SQLString; // Строка - SQL запрос к бд при подключении
        public string[] DBTables;
        public string[] DBColumns; // Колонки в таблицах через  ","  (длины массивов равны) 
        // Строка - название таблицы в Базе данных
        public OleDbConnection OleConnection; // Подключение базы данных
        public DataSet DS; // Таблица данных
            
        // Конструктор таблиц по 1й
        public DB(string Table,string column, string str) 
        {
            DBColumns = new string[1];
            DBColumns[0] = column;
            DS = new DataSet();
            DBTables = new string[1];
            DBTables[0] = Table;
            DataTable DT = new DataTable(DBTables[0]);
            DS.Tables.Add(DT);
            ConstructorWithDS(str);
        }

        //Конструктор по списку таблиц и  пути к БД 
        public DB(string[] Tables, string[] columns, string str) // str - Путь к БД
        {
            DBColumns = columns;
            DBTables = Tables;     
            DS = new DataSet();       
            for(int i = 0;i<DBTables.Length;i++)
            {
                DataTable DT = new DataTable(DBTables[i]);
                DS.Tables.Add(DT);
            }
            ConstructorWithDS(str);
        }
       
        
        // Конструктор по DataSet и  пути к БД
        public DB(DataSet Data, string column,string str) // str - Путь к БД
        {
            DBColumns = new string[1];
            DBColumns[0] = column;
           DS = Data;
            ConstructorWithDS(str);
        }
        public DB(DataSet Data, string[] columns, string str) // str - Путь к БД
        {
            DS = Data;
            DBColumns = columns;
            ConstructorWithDS(str);
        }
        public DB(DataSet Data,  string str) // str - Путь к БД
        {
            DS = Data;
            DBColumns = new string[DS.Tables.Count];
            for (int i = 0; i < DBColumns.Length; i++)
                DBColumns[i] = "*";
            ConstructorWithDS(str);
        }

        // Функция для конструктора
        private  void ConstructorWithDS(string str) // Неизвесен массив таблиц
        {
            ConnectString = str;
            MakeConnectString();
            OleConnection = new OleDbConnection(ConnectString);        
            DBTables = new string[DS.Tables.Count];
            OleConnection.Open();
            
            OleDBAdapters = new OleDbDataAdapter[DBTables.Length];
            OleCB = new OleDbCommandBuilder[DBTables.Length];


            for (int i = 0; i < DS.Tables.Count; i++)
            {
                DBTables[i] = DS.Tables[i].TableName;
                OleDBAdapters[i] = new OleDbDataAdapter(SelectSQLCommand(DBColumns[i], DBTables[i]), OleConnection);
                OleCB[i] = new OleDbCommandBuilder(OleDBAdapters[i]);
                OleDBAdapters[i].Fill(DS.Tables[i]);
                OleCB[i].QuotePrefix = "[";
                OleCB[i].QuoteSuffix = "]";
                OleDBAdapters[i].UpdateCommand = OleCB[i].GetUpdateCommand();
            }


            OleConnection.Close();
        }
        
        
        public string SelectSQLCommand(string Columns,string DT) 
        {
            return "SELECT " + Columns+ " FROM " + DT +"";
        }


        public void Update() 
        {
            OleConnection.Open();
            for (int i = 0; i < OleDBAdapters.Length; i++)
            {
                OleDBAdapters[i].Update(DS.Tables[i]);
            }
            OleConnection.Close();
        }

        public void Fill()
        {
            OleConnection.Open();
            for (int i = 0; i < OleDBAdapters.Length; i++)
            {
                OleDBAdapters[i].Fill(DS.Tables[i]);
            }
            OleConnection.Close();
        }

        // Конструктор, str - путь к БД

        //Создание подключения к базе данных
        public void Connects()
        {

        }

        //Создание строки подключения 
        public void MakeConnectString()
        {
            if (ConnectString.EndsWith(".accdb"))
            {
                ConnectString = Connect_accdb + ConnectString + ";";
            }


        }

        // Поиск базы в папке.
        /*public void FindDB() 
        {
            if (Directory.Exists(ConnectString))
            {

            }
            else 
            {
                System.FormDB();
            }
        }*/

    }
}
