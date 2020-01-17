using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace AGR
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }
        public class GV 
        {
            public static OleDbConnection MainConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MainDB.accdb;");
            public static OleDbDataAdapter SaveGroupsDataAdapter = new OleDbDataAdapter("SELECT * FROM SaveGroups", Program.GV.MainConnection);
           // public static 
            public static OleDbCommand s = new OleDbCommand("SELECT * FROM SaveGroups", Program.GV.MainConnection); 
            public static ProfileSettings Profile = new ProfileSettings(); // Профиль с настройками подключения к БД
          /*  public static MainDBDataSetTableAdapters.ProfilesTableAdapter profilesTableAdapter = new AGR.MainDBDataSetTableAdapters.ProfilesTableAdapter(); // Текущие настройки профиля
            public static MainDBDataSetTableAdapters.DefaultGroupsTableAdapter defaultGroupsTableAdapter = new AGR.MainDBDataSetTableAdapters.DefaultGroupsTableAdapter();
            public static MainDBDataSetTableAdapters.SaveGroupParametersTableAdapter saveGroupParametersTableAdapter = new AGR.MainDBDataSetTableAdapters.SaveGroupParametersTableAdapter(); //Сохраненные параметры для групп, выбранных пользователем
           */ public static MainDBDataSetTableAdapters.SaveGroupsTableAdapter saveGroupsTableAdapter = new AGR.MainDBDataSetTableAdapters.SaveGroupsTableAdapter(); // Сохраненные Группы
           /* public static MainDBDataSetTableAdapters.SelectedSpillsTableAdapter selectedSpillsTableAdapter = new AGR.MainDBDataSetTableAdapters.SelectedSpillsTableAdapter(); //Сохраненные проливы, выбранные пользователем
            public static MainDBDataSetTableAdapters.SubGroupParametersTableAdapter subGroupParametersTableAdapter = new AGR.MainDBDataSetTableAdapters.SubGroupParametersTableAdapter(); // Параметры подгрупп
            public static MainDBDataSetTableAdapters.SubgroupsTableAdapter subgroupsTableAdapter = new AGR.MainDBDataSetTableAdapters.SubgroupsTableAdapter(); //Подгруппы
            */
            public static MainDBDataSet mainDBDataSet = new AGR.MainDBDataSet();
            public static Group[] Groups;
            
        }
        public class DBAdapters       
        {
            public static OleDbDataAdapter SaveGroupsDataAdapter = new OleDbDataAdapter("SELECT * FROM SaveGroups", Program.GV.MainConnection);
            public static OleDbDataAdapter ProfilesDataAdapter = new OleDbDataAdapter("SELECT * FROM Profiles", Program.GV.MainConnection);
            public static OleDbDataAdapter SaveGroupParametersDataAdapter = new OleDbDataAdapter("SELECT * FROM SaveGroupParameters", Program.GV.MainConnection);
            public static OleDbDataAdapter SelectedSpillsDataAdapter = new OleDbDataAdapter("SELECT * FROM SelectedSpills", Program.GV.MainConnection);
            public static OleDbDataAdapter SubGroupParametersDataAdapter = new OleDbDataAdapter("SELECT * FROM SubGroupParameters", Program.GV.MainConnection);
            public static OleDbDataAdapter SubgroupsDataAdapter = new OleDbDataAdapter("SELECT * FROM SubGroups", Program.GV.MainConnection);
            public static OleDbCommand save = new OleDbCommand("SELECT * FROM SaveGroups",GV.MainConnection);
           

             public MainDBDataSetTableAdapters.ProfilesTableAdapter profilesTableAdapter = new AGR.MainDBDataSetTableAdapters.ProfilesTableAdapter(); // Текущие настройки профиля
             public MainDBDataSetTableAdapters.DefaultGroupsTableAdapter defaultGroupsTableAdapter = new AGR.MainDBDataSetTableAdapters.DefaultGroupsTableAdapter();
             public static MainDBDataSetTableAdapters.SaveGroupParametersTableAdapter saveGroupParametersTableAdapter = new AGR.MainDBDataSetTableAdapters.SaveGroupParametersTableAdapter(); //Сохраненные параметры для групп, выбранных пользователем
             public static MainDBDataSetTableAdapters.SaveGroupsTableAdapter saveGroupsTableAdapter = new AGR.MainDBDataSetTableAdapters.SaveGroupsTableAdapter(); // Сохраненные Группы
             public static MainDBDataSetTableAdapters.SelectedSpillsTableAdapter selectedSpillsTableAdapter = new AGR.MainDBDataSetTableAdapters.SelectedSpillsTableAdapter(); //Сохраненные проливы, выбранные пользователем
             public static MainDBDataSetTableAdapters.SubGroupParametersTableAdapter subGroupParametersTableAdapter = new AGR.MainDBDataSetTableAdapters.SubGroupParametersTableAdapter(); // Параметры подгрупп
             public static MainDBDataSetTableAdapters.SubgroupsTableAdapter subgroupsTableAdapter = new AGR.MainDBDataSetTableAdapters.SubgroupsTableAdapter(); //Подгруппы


            public static void Fill() 
            {


              /*  SaveGroupsDataAdapter.Fill(GV.mainDBDataSet.SaveGroups);
                ProfilesDataAdapter.Fill(GV.mainDBDataSet.Profiles);
                SaveGroupParametersDataAdapter.Fill(GV.mainDBDataSet, GV.mainDBDataSet.SaveGroupParameters.TableName);
                SelectedSpillsDataAdapter.Fill(GV.mainDBDataSet.SelectedSpills);
                SubGroupParametersDataAdapter.Fill(GV.mainDBDataSet.SubGroupParameters);
                SubgroupsDataAdapter.Fill(GV.mainDBDataSet.Subgroups);
                //saveGroupParametersTableAdapter
                saveGroupsTableAdapter.Adapter.SelectCommand = save;
                //saveGroupsTableAdapter
                saveGroupsTableAdapter.Adapter.Fill(GV.mainDBDataSet.SaveGroups);
                /* SaveGroupsDataAdapter.Fill(GV.mainDBDataSet);
                 ProfilesDataAdapter.Fill(GV.mainDBDataSet);
                 SaveGroupParametersDataAdapter.Fill(GV.mainDBDataSet);
                 SelectedSpillsDataAdapter.Fill(GV.mainDBDataSet);
                 SubGroupParametersDataAdapter.Fill(GV.mainDBDataSet);
                 SubgroupsDataAdapter.Fill(GV.mainDBDataSet);*/
            }

            public static void Update()
            {



              /*  saveGroupsTableAdapter.Adapter.Update(GV.mainDBDataSet.SaveGroups);
                SaveGroupsDataAdapter.Update(GV.mainDBDataSet, GV.mainDBDataSet.SaveGroups.TableName);


                //SaveGroupsDataAdapter.Update(GV.mainDBDataSet);
               /* ProfilesDataAdapter.Update(GV.mainDBDataSet);
                SaveGroupParametersDataAdapter.Update(GV.mainDBDataSet);
                SelectedSpillsDataAdapter.Update(GV.mainDBDataSet);
                SubGroupParametersDataAdapter.Update(GV.mainDBDataSet);
                SubgroupsDataAdapter.Update(GV.mainDBDataSet);*/
            }

            public static void UpdateFill() 
            {
                
                Update();

                Fill();
            }


        }
    }
}
