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
        private OleDbDataAdapter OleDBAdapter;       
        string ConnectString; // Строка подключения

        public string SQLString; // Строка - SQL запрос к бд при подключении
        public string DBTable;
        public string DBColumns;
        // Строка - название таблицы в Базе данных
        public OleDbConnection OleConnection; // Подключение базы данных
        public DataSet DS; // Таблица данных
        

        //Создание строки подключения 
        public void MakeConnectString()
        {
            if (ConnectString.EndsWith(".accdb"))
            {
                ConnectString = Connect_accdb + ConnectString + ";";
            }

           
        }
        
        
        //Создание подключения к базе данных
        public void Connect()
        {
            OleConnection = new OleDbConnection(ConnectString);           
        }
        
        //Заполнение таблицы данными.
        public void DSMake() 
        {
            OleConnection.Open();
            OleDBAdapter = new OleDbDataAdapter(SQLString, OleConnection);
            DS = new DataSet();
            OleDBAdapter.Fill(DS, DBTable);
            OleConnection.Close();
            
        }
       public string SQLMake() 
        {
            return "SELECT " + DBColumns+ " FROM " + DBTable +"";
        }
        
        
        // Конструктор, str - путь к БД
        public DB(string str)
        {
            ConnectString = str;
            MakeConnectString();
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
