using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Documents;

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
        public class GV // Глобальные переменные
        {
            public static ProfileSettings Profile = new ProfileSettings(); // Профиль с настройками подключения к БД
            public static MainDBDataSet mainDBDataSet = new AGR.MainDBDataSet();
            public static DB MainDB = new DB(mainDBDataSet, "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MainDB.accdb;"); // База данных для настроек, для полноценного обновления Данных нужно взаимодействовать между DS и mainDBDataset
            public static Group[] Groups; 


            
        }

    }
}
