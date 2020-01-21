using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using AGR.Classes;

namespace AGR
{

    public class DB
    {
        const string Connect_accdb = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
        private OleDbDataAdapter[] OleDBAdapters;
        private OleDbCommandBuilder[] OleCB;
        private string ConnectString; // Строка подключения

        public string[] DBTables; //Массив названий таблиц
        public string[] DBColumns; // Колонки в таблицах через  ","  (длины массивов равны) 

        public OleDbConnection OleConnection; // Подключение базы данных
        public DataSet DS; // Таблица данных

        private string SelectSQLCommand(string Columns, string DT) // Создание строки типа SELECT 
        {
            return "SELECT " + Columns + " FROM " + DT + "";
        }

        private void ConstructorWithDS(string PathToBD) // Функция для конструктора 
        {
            ConnectString = PathToBD;
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

        private void MakeConnectString()   //Создание строки подключения из пути к БД
        {
            if (ConnectString.EndsWith(".accdb"))
            {
                ConnectString = Connect_accdb + ConnectString + ";";
            }
        }

        /* 
 ******************************************Конструкторы***************************************************
        */

        public DB(string Table, string column, string PathToBD)
        {
            DBColumns = new string[1];
            DBColumns[0] = column;
            DS = new DataSet();
            DBTables = new string[1];
            DBTables[0] = Table;
            DataTable DT = new DataTable(DBTables[0]);
            DS.Tables.Add(DT);
            ConstructorWithDS(PathToBD);
        }
        public DB(string[] Tables, string[] columns, string PathToBD)
        {
            DBColumns = columns;
            DBTables = Tables;
            DS = new DataSet();
            for (int i = 0; i < DBTables.Length; i++)
            {
                DataTable DT = new DataTable(DBTables[i]);
                DS.Tables.Add(DT);
            }
            ConstructorWithDS(PathToBD);
        }
        public DB(DataSet Data, string column, string PathToBD)
        {
            DBColumns = new string[1];
            DBColumns[0] = column;
            DS = Data;
            ConstructorWithDS(PathToBD);
        }
        public DB(DataSet Data, string[] columns, string PathToBD)
        {
            DS = Data;
            DBColumns = columns;
            ConstructorWithDS(PathToBD);
        }
        public DB(DataSet Data, string PathToBD)
        {
            DS = Data;
            DBColumns = new string[DS.Tables.Count];
            for (int i = 0; i < DBColumns.Length; i++)
                DBColumns[i] = "*";
            ConstructorWithDS(PathToBD);
        }
        /* 
**********************************************************************************************************
  */
        public void Update() // Функция для сохранения DataSet в исходной БД
        {
            OleConnection.Open();
            for (int i = 0; i < OleDBAdapters.Length; i++)
            {
                OleDBAdapters[i].Update(DS.Tables[i]);

            }
            OleConnection.Close();
        }
        public void Fill() // Функция для обновления DataSet в исходной БД
        {
            OleConnection.Open();
            for (int i = 0; i < OleDBAdapters.Length; i++)
            {
                OleDBAdapters[i].Fill(DS.Tables[i]);
            }
            OleConnection.Close();
        }
        // Функция сохранения Groups в DataSet в таблицу SaveSubGroupsparameters; 
        public void SaveGroupParameters(Group[] G, MainDBDataSet MainDS)
        {for (int i = 0; i < G.Length; i++)
                SaveGroupParameters(G[i], MainDS);
        }
        public void SaveGroupParameters(Group G, MainDBDataSet MainDS)
        {


            for (int i = 0; i < G.SubGroups.Length; i++)
            {
                for (int j = 0; j < G.SubGroups[i].Parameters.Length; j++)
                {
                    if (G.SubGroups[i].Parameters[j].IDSave == 0)
                    {
                        MainDS.SaveGroupParameters.Rows.Add();
                        MainDS.SaveGroupParameters.Rows[MainDS.SaveGroupParameters.Rows.Count - 1][1] = G.IDGroup;
                        MainDS.SaveGroupParameters.Rows[MainDS.SaveGroupParameters.Rows.Count - 1][2] = G.SubGroups[i].IDSubgroup;
                        MainDS.SaveGroupParameters.Rows[MainDS.SaveGroupParameters.Rows.Count - 1][3] = G.SubGroups[i].Parameters[j].IDParameter;
                        MainDS.SaveGroupParameters.Rows[MainDS.SaveGroupParameters.Rows.Count - 1][4] = G.SubGroups[i].Parameters[j].Value.ToString();
                    }
                    else
                        for (int k = 0; k < MainDS.SaveGroupParameters.Rows.Count; k++)
                        {
                            if (Convert.ToInt32(MainDS.SaveGroupParameters.Rows[k][0]) == G.SubGroups[i].Parameters[j].IDSave)
                            {
                                MainDS.SaveGroupParameters.Rows[k][1] = G.IDGroup;
                                MainDS.SaveGroupParameters.Rows[k][2] = G.SubGroups[i].IDSubgroup;
                                MainDS.SaveGroupParameters.Rows[k][3] = G.SubGroups[i].Parameters[j].IDParameter;
                                MainDS.SaveGroupParameters.Rows[k][4] = G.SubGroups[i].Parameters[j].Value.ToString();
                            }
                        }
                }
            }
            
        }

        public void Autoremove(Group[] G, MainDBDataSet MainDS) 
        {
            int i = 0;
            while (i<MainDS.SaveGroupParameters.Rows.Count)
            {
                
                bool f = true;
                for (int j = 0; j < G.Length; i++) 
                {
                    for (int k = 0; k < G[j].SubGroups.Length; k++)
                    {
                        for (int l = 0; l < G[j].SubGroups[k].Parameters.Length; l++)
                        {
                            if (G[j].SubGroups[k].Parameters[l].IDSave == Convert.ToInt32(MainDS.SaveGroupParameters.Rows[i][0])) 
                                f = false;                            
                        }
                    }
                } 
                if(f) 
                {
                    MainDS.SaveGroupParameters.Rows[i].Delete();
                }
                i++;
            }
        }

    }
}
