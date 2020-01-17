using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGR
{
    // Класс для работы с настройками профиля
    public class ProfileSettings
    {
        public int ID;
        public string ProfileName;
        public string DataBasePlace;
        public string Table1;
        public string Table2;
        public string Columns1;
        public string Columns2;
        public string MainColumn;


        public bool OtherDB;
        public string MaskKey;
        public string MaskDB;
        public string OtherDataBaseFolder;

        public void Save()
        {
          //  string query = "INSERT INTO Profile (ProfileName, DataBasePlace, Key1, Key2, MaskKey, MaskDB,DataBaseFolder) VALUES (" + ProfileName + ", " +
        //        DataBasePlace + ", " + Key1 + ", " + Key2 + ", " + MaskKey + ", " + MaskDB + ", " + OtherDataBaseFolder + ")";
            
        }


        //Функция загрузки данных в профиль из БД
        public void Load(ProfileSettings profile)
        {

            Program.GV.MainDB.Fill();
            Program.GV.mainDBDataSet = Program.GV.MainDB.DS as MainDBDataSet;

            foreach (DataRow row in Program.GV.mainDBDataSet.Profiles.Rows)
            {

                if (Convert.ToBoolean(row[Program.GV.mainDBDataSet.Profiles.SelectedColumn]) == true)
                {
                    profile.ID = Convert.ToInt32(row[Program.GV.mainDBDataSet.Profiles.IDColumn]);
                    profile.ProfileName = row[Program.GV.mainDBDataSet.Profiles.ProfileNameColumn].ToString();
                    profile.DataBasePlace = row[Program.GV.mainDBDataSet.Profiles.DataBasePlaceColumn].ToString();
                    profile.Table1 = row[Program.GV.mainDBDataSet.Profiles.Table1Column].ToString();
                    profile.Table2 = row[Program.GV.mainDBDataSet.Profiles.Table2Column].ToString();
                    profile.Columns1 = row[Program.GV.mainDBDataSet.Profiles.Columns1Column].ToString();
                    profile.Columns2 = row[Program.GV.mainDBDataSet.Profiles.Columns2Column].ToString();
                    profile.MaskKey = row[Program.GV.mainDBDataSet.Profiles.MaskKeyColumn].ToString();
                    profile.MaskDB = row[Program.GV.mainDBDataSet.Profiles.MaskDBColumn].ToString();
                    profile.OtherDB = Convert.ToBoolean(row[Program.GV.mainDBDataSet.Profiles.OtherDBColumn]);
                    profile.OtherDataBaseFolder = row[Program.GV.mainDBDataSet.Profiles.DataBaseFolderColumn].ToString();
                    profile.MainColumn = row[Program.GV.mainDBDataSet.Profiles.MainColumnColumn].ToString();
                }
            }
            
        }
    }
}
