using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Форма для работы с настройками чтения из БД
namespace AGR
{  
    public partial class FormDB : Form
    {
        public FormDB()
        {
            InitializeComponent();

            cB_Profiles.Items.Clear();

            //Program.DBAdapters.Fill();
            Program.GV.MainDB.Fill();
            Program.GV.mainDBDataSet = Program.GV.MainDB.DS as MainDBDataSet;
            /*if (Program.GV.Profile.ProfileName == null) 
            Program.GV.Profile.Load(Program.GV.Profile);*/
            LoadSettings();
            cB_Profiles.Items.Add(Program.GV.Profile.ProfileName);
            cB_Profiles.SelectedItem = cB_Profiles.Items[0];


        }
        public DB Database;
         
        // Функция загрузки данных в текущие поля.
        public void LoadSettings() 
        {
            cB_Profiles.Text = Program.GV.Profile.ProfileName;
            tB_OpenDB.Text = Program.GV.Profile.DataBasePlace;
            tB_Table1.Text = Program.GV.Profile.Table1;
            tB_Table2.Text = Program.GV.Profile.Table2;

            tB_Columns1.Text = Program.GV.Profile.Columns1;
            tB_Columns2.Text = Program.GV.Profile.Columns2;
            tB_FolderDB.Text = Program.GV.Profile.OtherDataBaseFolder;
            tB_MaskKey.Text = Program.GV.Profile.MaskKey;
            tB_MaskDB.Text = Program.GV.Profile.MaskDB;
            tB_MainColumn.Text = Program.GV.Profile.MainColumn;
            chB_DB.Checked = Program.GV.Profile.OtherDB;

        }

        
        // Кнопка ок (подключиться к БД) 
        private void b_LoadDB_Click(object sender, EventArgs e)
        {
//            Database = new DB(tB_OpenDB.Text);
 //           Database.Connect();
            Database.OleConnection.Open();
            Database.OleConnection.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {

            // TODO: данная строка кода позволяет загрузить данные в таблицу "Program.GV.Program.GV.mainDBDataSet.Profiles" из БД
            Program.GV.MainDB.Fill();
            Program.GV.mainDBDataSet = Program.GV.MainDB.DS as MainDBDataSet;
            Program.GV.mainDBDataSet.Profiles.DefaultView.Sort = "ProfileName asc";
            dataGridView1.DataSource = Program.GV.mainDBDataSet.Profiles;
           
        }



        private void button2_Click(object sender, EventArgs e)
        {

            // Сохранение данных в БД
            Program.GV.MainDB.DS = Program.GV.mainDBDataSet;
            Program.GV.MainDB.Update();
            

        }


        //Функция при раскрытии списка выбора профиля
        public void cB_Profiles_DropDown(object sender, EventArgs e)
        {
            
            cB_Profiles.Items.Clear();
            // TODO: данная строка кода позволяет загрузить данные в таблицу "Program.GV.mainDBDataSet.Profiles" из БД
            Program.GV.MainDB.Fill();
            Program.GV.mainDBDataSet = Program.GV.MainDB.DS as MainDBDataSet;
            Program.GV.mainDBDataSet.Profiles.DefaultView.Sort = "ProfileName asc";
             foreach (DataRowView row in Program.GV.mainDBDataSet.Profiles.DefaultView)
             {
                 cB_Profiles.Items.Add(row["ProfileName"]);

             }
           /* DataView dv = new DataView(Program.GV.mainDBDataSet.Profiles);
            dv.Sort = "ProfileName asc";
            foreach (DataRowView drv in dv) 
            {
                cB_Profiles.Items.Add(drv["ProfileName"]);
            }*/
            

        }
        
        //Функция при выборе профиля
        private void cB_Profiles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            b_delete.Enabled = true;
            // TODO: данная строка кода позволяет загрузить данные в таблицу "Program.GV.mainDBDataSet.Profiles" из БД
            Program.GV.MainDB.Fill();
            Program.GV.mainDBDataSet = Program.GV.MainDB.DS as MainDBDataSet;
            int i = 0;
            foreach (DataRow row in Program.GV.mainDBDataSet.Profiles.Rows)
            {

                if (cB_Profiles.SelectedItem.ToString() == row[Program.GV.mainDBDataSet.Profiles.ProfileNameColumn].ToString())
                {
                    Program.GV.Profile.ProfileName = row[Program.GV.mainDBDataSet.Profiles.ProfileNameColumn].ToString();
                    Program.GV.Profile.DataBasePlace = row[Program.GV.mainDBDataSet.Profiles.DataBasePlaceColumn].ToString();
                    Program.GV.Profile.Table1 = row[Program.GV.mainDBDataSet.Profiles.Table1Column].ToString();
                    Program.GV.Profile.Table2 = row[Program.GV.mainDBDataSet.Profiles.Table2Column].ToString();
                    Program.GV.Profile.Columns1 = row[Program.GV.mainDBDataSet.Profiles.Columns1Column].ToString();
                    Program.GV.Profile.Columns2 = row[Program.GV.mainDBDataSet.Profiles.Columns2Column].ToString();

                    Program.GV.Profile.MaskKey = row[Program.GV.mainDBDataSet.Profiles.MaskKeyColumn].ToString();
                    Program.GV.Profile.MaskDB = row[Program.GV.mainDBDataSet.Profiles.MaskDBColumn].ToString();
                    Program.GV.Profile.OtherDB = Convert.ToBoolean(row[Program.GV.mainDBDataSet.Profiles.OtherDBColumn]);
                    Program.GV.Profile.OtherDataBaseFolder = row[Program.GV.mainDBDataSet.Profiles.DataBaseFolderColumn].ToString();
                    Program.GV.Profile.MainColumn = row[Program.GV.mainDBDataSet.Profiles.MainColumnColumn].ToString();
                    Program.GV.mainDBDataSet.Profiles.Rows[i][Program.GV.mainDBDataSet.Profiles.SelectedColumn] = true;
                }
                else
                    Program.GV.mainDBDataSet.Profiles.Rows[i][Program.GV.mainDBDataSet.Profiles.SelectedColumn] = false;
                i++;
            }
            Program.GV.MainDB.DS = Program.GV.mainDBDataSet;
            Program.GV.MainDB.Update();
            

        }


        //Изменение профиля из списка 
        private void cB_Profiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSettings();
        }


        //Видимость полей при нажатии Checkbox
        private void chB_DB_CheckedChanged(object sender, EventArgs e)
        {
            tB_FolderDB.Visible = chB_DB.Checked;
            tB_MaskDB.Visible = chB_DB.Checked;
            tB_MaskKey.Visible = chB_DB.Checked;
        }


        // Если поля изменились
        private void cB_Profiles_KeyPress(object sender, KeyPressEventArgs e)
        {
            b_AddChanges.Enabled = true;
            b_SaveChanges.Enabled = true;
            b_delete.Enabled = false;
        }


        // Кнопка применить. Присваивает значения текущих полей в Profile и деактивируется. 
        public void b_AddChanges_Click(object sender, EventArgs e)
        {
             Program.GV.Profile.ProfileName = cB_Profiles.Text;
             Program.GV.Profile.DataBasePlace = tB_OpenDB.Text;
             Program.GV.Profile.Table1 = tB_Table1.Text;
             Program.GV.Profile.Table2 = tB_Table2.Text;
            Program.GV.Profile.Columns1 = tB_Columns1.Text;
            Program.GV.Profile.Columns2 = tB_Columns2.Text;

            Program.GV.Profile.OtherDataBaseFolder = tB_FolderDB.Text;
             Program.GV.Profile.MaskKey = tB_MaskKey.Text;
             Program.GV.Profile.MaskDB = tB_MaskDB.Text;
             Program.GV.Profile.OtherDB = chB_DB.Checked;
             b_AddChanges.Enabled = false;
        }


        // Кнопка сохранить. Сохраняет текущие значения в БД. + Кнопка применить.
        public void b_SaveChanges_Click(object sender, EventArgs e)
        {
            b_AddChanges_Click(sender, e); // Нажатие на кнопку применить.

            // TODO: данная строка кода позволяет загрузить данные в таблицу "Program.GV.mainDBDataSet.Profiles" из БД
          //  Program.GV.profilesTableAdapter.Fill(Program.GV.mainDBDataSet.Profiles);
            
           for(int i=0;i< Program.GV.mainDBDataSet.Profiles.Rows.Count;i++)
            {
                if (Convert.ToInt32(Program.GV.mainDBDataSet.Profiles.Rows[i][Program.GV.mainDBDataSet.Profiles.IDColumn]) == Program.GV.Profile.ID) 
                {
                    Program.GV.mainDBDataSet.Profiles[i][Program.GV.mainDBDataSet.Profiles.ProfileNameColumn] = Program.GV.Profile.ProfileName;
                    Program.GV.mainDBDataSet.Profiles[i][Program.GV.mainDBDataSet.Profiles.DataBasePlaceColumn] = Program.GV.Profile.DataBasePlace;
                    Program.GV.mainDBDataSet.Profiles[i][Program.GV.mainDBDataSet.Profiles.Table1Column] = Program.GV.Profile.Table1;
                    Program.GV.mainDBDataSet.Profiles[i][Program.GV.mainDBDataSet.Profiles.Table2Column] = Program.GV.Profile.Table2;
                    Program.GV.mainDBDataSet.Profiles[i][Program.GV.mainDBDataSet.Profiles.Columns1Column] = Program.GV.Profile.Columns1;
                    Program.GV.mainDBDataSet.Profiles[i][Program.GV.mainDBDataSet.Profiles.Columns2Column] = Program.GV.Profile.Columns2;

                    Program.GV.mainDBDataSet.Profiles[i][Program.GV.mainDBDataSet.Profiles.OtherDBColumn] = Program.GV.Profile.OtherDB;
                    Program.GV.mainDBDataSet.Profiles[i][Program.GV.mainDBDataSet.Profiles.MaskKeyColumn] = Program.GV.Profile.MaskKey;
                    Program.GV.mainDBDataSet.Profiles[i][Program.GV.mainDBDataSet.Profiles.MaskDBColumn] = Program.GV.Profile.MaskDB;
                    Program.GV.mainDBDataSet.Profiles[i][Program.GV.mainDBDataSet.Profiles.DataBaseFolderColumn] = Program.GV.Profile.OtherDataBaseFolder;
                    Program.GV.mainDBDataSet.Profiles[i][Program.GV.mainDBDataSet.Profiles.MainColumnColumn] = Program.GV.Profile.MainColumn;
                    Program.GV.mainDBDataSet.Profiles[i][Program.GV.mainDBDataSet.Profiles.SelectedColumn] = true;           
                } else Program.GV.mainDBDataSet.Profiles[i][Program.GV.mainDBDataSet.Profiles.SelectedColumn] = false;
            }
            Program.GV.MainDB.DS = Program.GV.mainDBDataSet;
            Program.GV.MainDB.Update();
            

        }
        
        // Кнопка создать. Добавляет новую запись в БД
        private void b_make_Click(object sender, EventArgs e)
        {
            Program.GV.mainDBDataSet.Profiles.Rows.Add();
            
            Program.GV.MainDB.DS = Program.GV.mainDBDataSet;
            Program.GV.MainDB.Update();
            Program.GV.MainDB.Fill();
            Program.GV.mainDBDataSet = Program.GV.MainDB.DS as MainDBDataSet;

            Program.GV.mainDBDataSet.Profiles.DefaultView.Sort = "ID desc" ;
            DataRowView drv = Program.GV.mainDBDataSet.Profiles.DefaultView[0];
            Program.GV.Profile.ID = Convert.ToInt32(drv["ID"]);
            //Program.GV.Profile.ID =Convert.ToInt32(Program.GV.mainDBDataSet.Profiles[Program.GV.mainDBDataSet.Profiles.Rows.Count - 1][Program.GV.mainDBDataSet.Profiles.IDColumn]);
            tB_Columns1.Text = Program.GV.Profile.ID.ToString();
            b_SaveChanges_Click(sender, e);
        }
        // Кнопка удалить. Удаляет текущую запись из БД
        private void b_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите удалить профиль из базы данных?", "Удаление профиля", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < Program.GV.mainDBDataSet.Profiles.Rows.Count; i++)
                {
                    if (Program.GV.mainDBDataSet.Profiles.Rows[i][Program.GV.mainDBDataSet.Profiles.IDColumn].ToString() == Program.GV.Profile.ID.ToString())
                    {
                        Program.GV.mainDBDataSet.Profiles.Rows[i].Delete();
                        break;
                    }

                }
                Program.GV.MainDB.DS = Program.GV.mainDBDataSet;
                Program.GV.MainDB.Update();
                

            }
           
            

        }

        // Кнопка обзор (выбор базы данных). 
        private void b_OpenDB_Click(object sender, EventArgs e)
        {
            if (oFD_BD.ShowDialog() == DialogResult.OK)
                tB_OpenDB.Text = oFD_BD.FileName;
        }
        // Кнопка обзор (выбор папки с БД). 
        private void b_OpenFolderDB_Click(object sender, EventArgs e)
        {
            if (fBD_DB_Folder.ShowDialog() == DialogResult.OK)
                tB_FolderDB.Text = fBD_DB_Folder.SelectedPath;
        }

        private void b_testDB_Click(object sender, EventArgs e)
        {

        }

        private void FormDB_Load(object sender, EventArgs e)
        {

        }
    }
}
