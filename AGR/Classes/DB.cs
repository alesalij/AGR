using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
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
            List<int> Exception = new List<int>();

            for (int i = 0; i < OleDBAdapters.Length; i++)
            {
                OleDBAdapters[i].Update(DS.Tables[i]);
         //       Exception.Add(i);
            }
/*
            int j = -1;
            while(Exception.Count > 0)
            try
            {
                    j++;
                    if (j >= Exception.Count) j = 0;
                    OleDBAdapters[Exception[j]].Update(DS.Tables[Exception[j]]);
                    Exception.RemoveAt(j);
                   
            }
            catch 
                {}*/

            OleConnection.Close();
        }
        public void Fill() // Функция для обновления DataSet в исходной БД
        {
            OleConnection.Open();
            for (int i = 0; i < OleDBAdapters.Length; i++)
            {
                DS.Tables[i].Rows.Clear();
                OleDBAdapters[i].Fill(DS.Tables[i]);
            }
            OleConnection.Close();
        }



        /*
         ***********************************Только для БД с настройками (MainDB)*********************************************
             */
        public void SaveGroups(Group[] G)
        {
            MainDBDataSet MainDS = DS as MainDBDataSet;
            for (int i = 0; i < G.Length; i++)
            {
                if (G[i].IDGroup == 0)
                {
                    MainDS.SaveGroups.Rows.Add();
                    MainDS.SaveGroups.Rows[MainDS.SaveGroups.Rows.Count - 1][1] = G[i].NameGroup;
                    for (int j = 0; j < G[i].SubGroups.Length; j++)
                    {
                        MainDS.SaveGroups.Rows[MainDS.SaveGroups.Rows.Count - 1][j+2] = G[i].SubGroups[j].Check;
                    }
                }

                else 
                {
                    for (int j = 0; j < MainDS.SaveGroups.Rows.Count; j++) 
                    {
                        if (G[i].IDGroup == Convert.ToInt32(MainDS.SaveGroups.Rows[j][0])) 
                        {
                            MainDS.SaveGroups.Rows[j][1] = G[i].NameGroup;
                            for (int l = 0; l < G[i].SubGroups.Length; l++)
                            {
                                MainDS.SaveGroups.Rows[j][l + 2] = G[i].SubGroups[l].Check;
                            }
                        }
                    }


                }
            }

            DS = MainDS;
            Update();
            Fill();
            MainDS = DS as MainDBDataSet;

            for (int i = 0; i < G.Length; i++)
            {
                G[i].IDGroup = Convert.ToInt32(MainDS.SaveGroups.Rows[i][0]);
            }

            DS = MainDS;
            SaveGroupParameters(G);
        }

        // Функция сохранения Параметров в DataSet в таблицу SaveSubGroupsparameters; 
        public void SaveGroupParameters(Group[] G)
        {
            MainDBDataSet MainDS = DS as MainDBDataSet;
            for (int l = 0; l < G.Length; l++)
            {
                for (int i = 0; i < G[l].SubGroups.Length; i++)
                {
                    for (int j = 0; j < G[l].SubGroups[i].Parameters.Length; j++)
                    {
                        if (G[l].SubGroups[i].Parameters[j].IDSave == 0)
                        {
                            MainDS.SaveGroupParameters.Rows.Add();
                            MainDS.SaveGroupParameters.Rows[MainDS.SaveGroupParameters.Rows.Count - 1][1] = G[l].IDGroup;
                            MainDS.SaveGroupParameters.Rows[MainDS.SaveGroupParameters.Rows.Count - 1][2] = G[l].SubGroups[i].IDSubgroup;
                            MainDS.SaveGroupParameters.Rows[MainDS.SaveGroupParameters.Rows.Count - 1][3] = G[l].SubGroups[i].Parameters[j].IDParameter;
                            MainDS.SaveGroupParameters.Rows[MainDS.SaveGroupParameters.Rows.Count - 1][4] = G[l].SubGroups[i].Parameters[j].Value.ToString();
                        }
                        else
                            for (int k = 0; k < MainDS.SaveGroupParameters.Rows.Count; k++)
                            {
                                if (Convert.ToInt32(MainDS.SaveGroupParameters.Rows[k][0]) == G[l].SubGroups[i].Parameters[j].IDSave)
                                {
                                    MainDS.SaveGroupParameters.Rows[k][1] = G[l].IDGroup;
                                    MainDS.SaveGroupParameters.Rows[k][2] = G[l].SubGroups[i].IDSubgroup;
                                    MainDS.SaveGroupParameters.Rows[k][3] = G[l].SubGroups[i].Parameters[j].IDParameter;
                                    MainDS.SaveGroupParameters.Rows[k][4] = G[l].SubGroups[i].Parameters[j].Value.ToString();
                                }
                            }
                    }
                }
            }
            DS = MainDS;

        }

        // Функция чистки Параметров, Групп, Проливов в DataSet в таблицах SaveSubGroupsparameters, SaveGroups, Spills ; 
        public void AutoremoveGroupParameters(Group[] G)
        {
            MainDBDataSet MainDS = DS as MainDBDataSet;
             for (int i = 0; i < MainDS.SaveGroupParameters.Rows.Count; i++)
             {
                 bool f = true;
                 for (int j = 0; j < G.Length; j++)
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
                 if (f)
                {
                    if (Convert.ToInt32(MainDS.SaveGroupParameters.Rows.Count) > 1)
                        MainDS.SaveGroupParameters.Rows[i].Delete();
                    else MainDS.SaveGroupParameters.Rows.Clear();
                }
                             
             }


            //MainDS.SelectedSpills.Rows.Clear();
            for (int i = 0; i < MainDS.SelectedSpills.Rows.Count; i++)
             {
                 bool f = true;
                 for (int j = 0; j < G.Length; j++)
                 {
                     for (int k = 0; k < G[j].IDSpills.Length; k++) 
                         if (G[j].IDSpills[k] == Convert.ToInt32(MainDS.SelectedSpills.Rows[i][0]))
                             f = false;
                 }
                if (f)
                {
                    if (Convert.ToInt32(MainDS.SelectedSpills.Rows.Count) > 1)
                        MainDS.SelectedSpills.Rows[i].Delete();
                    else MainDS.SelectedSpills.Rows.Clear();
                }
             }



             for (int i = 0; i < MainDS.SaveGroups.Rows.Count; i++)
             {
                 bool f = true;
                 for (int j = 0; j < G.Length; j++)
                 {
                     if (G[j].IDGroup == Convert.ToInt32(MainDS.SaveGroups.Rows[i][0]))
                         f = false;
                 }
                 if (f)
                {
                    if (Convert.ToInt32(MainDS.SaveGroups.Rows.Count) > 1)
                        MainDS.SaveGroups.Rows[i].Delete();
                    else MainDS.SaveGroups.Rows.Clear();
                }
            }
            DS = MainDS;
        }
    }
}
