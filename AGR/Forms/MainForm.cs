using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using System.Data.OleDb;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Access = Microsoft.Office.Interop.Access;
using AGR.Classes;
using System.Windows.Documents;

namespace AGR
{
    public partial class MainForm : Form
    {
        //public static string connectString; // строка подключения 
        DB DataBase1, DataBase2;
        
        public MainForm()
        {
            InitializeComponent();

            // Чтение БД.
            Program.GV.MainDB.Fill();
            Program.GV.mainDBDataSet = Program.GV.MainDB.DS as MainDBDataSet;

            // Получение ДБ Настроек
            Program.GV.Profile.Load(Program.GV.Profile);

            //Создание Groups
            Program.GV.Groups = new Group[Program.GV.mainDBDataSet.SaveGroups.Rows.Count];
            for (int i = 0; i < Program.GV.Groups.Length; i++)
            {
                Program.GV.Groups[i] = new Group(Convert.ToInt32(Program.GV.mainDBDataSet.SaveGroups.Rows[i][0]), Program.GV.mainDBDataSet);
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            Program.GV.MainDB.Fill();
            Program.GV.mainDBDataSet = Program.GV.MainDB.DS as MainDBDataSet;

            dataGridView1.DataSource = null;
           
            dataGridView1.DataSource = Program.GV.mainDBDataSet.SaveGroupParameters;

            // Создаем пустую книгу. Используйте использование statment, поэтому пакет будет утилизирован, когда мы закончим. 
            /* using (var p = new ExcelPackage(new FileInfo(@"c:\workbooks\myworkbook.xlsx")))
             {
                 var ws = p.Workbook.Worksheets.Add("MySheet");
                 // Рабочая книга должна содержать хотя бы одну ячейку, поэтому давайте добавим одну ...
                 ws.Cells["A1"].Value = "This is cell A1";
                 //Создание директории.
                 Directory.CreateDirectory("c:/workbooks");
                 p.Save();
                 p.Save();
                 p.Save();
                 p.Save();
         }*/

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Program.GV.mainDBDataSet.SaveGroupParameters.Rows[0].Delete();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Program.GV.MainDB.SaveGroupParameters(Program.GV.Groups);
        }
        private void button4_Click(object sender, EventArgs e)
        {

            //!!!!!!!!!!!!!!!!!!!!!!!
            /*  OleDbCommandBuilder cmd = new OleDbCommandBuilder(Program.GV.SaveGroupsDataAdapter);                     
              cmd.QuotePrefix = "[";
              cmd.QuoteSuffix = "]";
              Program.GV.SaveGroupsDataAdapter.UpdateCommand = cmd.GetUpdateCommand();
              tB_OpenDB.Text = Program.GV.SaveGroupsDataAdapter.UpdateCommand.CommandText;
              Program.GV.SaveGroupsDataAdapter.Update(Program.GV.mainDBDataSet, "SaveGroups");*/
            
            Program.GV.MainDB.DS = Program.GV.mainDBDataSet;
            Program.GV.MainDB.Update();
        }



        private void b_LoadDB_Click(object sender, EventArgs e)
        {
            //Подключение к БД
            
            //Строка подключения тестовая
           //connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Program.GV.Profile.DataBasePlace +";";
            // Новый экземпляр класса OleDbConnection
            /*myConnection = new OleDbConnection(connectString);
            

            myConnection.Open();
            myConnection.Close();
            */



        }

        private void b_BD_Click(object sender, EventArgs e)
        {
            FormDB nF = new FormDB();
            
            nF.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Program.GV.profilesTableAdapter.Connection.Close();
           
        }

        private void b_Add_Click(object sender, EventArgs e)
        {
            bool f = true;
            if (tV_Groups.SelectedNode.Parent == null)
            {
                for (int i = 0; i < dGV_DB1.Columns.Count; i++)
                {
                    if (dGV_DB1.Columns[i].Name == Program.GV.Profile.MainColumn)
                    {
                        Array.Resize(ref Program.GV.Groups[Convert.ToInt32(tV_Groups.SelectedNode.Tag)].Spills, Program.GV.Groups[Convert.ToInt32(tV_Groups.SelectedNode.Tag)].Spills.Length + 1);

                        Program.GV.Groups[Convert.ToInt32(tV_Groups.SelectedNode.Tag)].Spills[Program.GV.Groups[Convert.ToInt32(tV_Groups.SelectedNode.Tag)].Spills.Length - 1] = dGV_DB1.SelectedCells[i].Value.ToString();
                        tV_Groups.SelectedNode.Nodes.Add(dGV_DB1.SelectedCells[i].Value.ToString());
                        f = false;
                    }
                }

                if (f) MessageBox.Show("Проверьте параметр /Выбранный столбец/");
                          
            }
        }

        // Добавление группы
        private void b_AddGroup_Click(object sender, EventArgs e)
        {
            tV_Groups.Nodes.Add("Группа " + tV_Groups.Nodes.Count);

            Array.Resize(ref Program.GV.Groups, Program.GV.Groups.Length + 1);
            Program.GV.Groups[Program.GV.Groups.Length - 1] = new Group(0, Program.GV.mainDBDataSet);
            Program.GV.Groups[Program.GV.Groups.Length - 1].NameGroup = tV_Groups.Nodes[tV_Groups.Nodes.Count - 1].Text;

            tV_Groups.Nodes[tV_Groups.Nodes.Count-1].Tag = Program.GV.Groups.Length - 1;
 
        }

        //Удаление группы
        private void b_DeleteGroup_Click(object sender, EventArgs e)
        {
            /* Program.GV.MainDB.Fill();
             Program.GV.mainDBDataSet = Program.GV.MainDB.DS as MainDBDataSet;
             */
            if (tV_Groups.SelectedNode != null)
            {
                Group[] G = new Group[Program.GV.Groups.Length - 1];
                for (int i = 0; i < G.Length; i++)
                {
                    if (i >= Convert.ToInt32(tV_Groups.SelectedNode.Tag))
                        G[i] = Program.GV.Groups[i + 1];
                    else
                        G[i] = Program.GV.Groups[i];
                }
                Program.GV.Groups = G;

                /* Program.GV.MainDB.Autoremove(Program.GV.Groups, Program.GV.mainDBDataSet);
                 Program.GV.MainDB.DS = Program.GV.mainDBDataSet;
                 Program.GV.MainDB.Update();
                 */
                for (int i = tV_Groups.SelectedNode.Index; i < tV_Groups.Nodes.Count; i++)
                {
                    tV_Groups.Nodes[i].Tag = Convert.ToInt32(tV_Groups.Nodes[i].Tag) - 1;
                }

                /* if (tV_Groups.SelectedNode.Index == 0) 

                     tV_Groups.Nodes.*/
                tV_Groups.Nodes.Remove(tV_Groups.SelectedNode);

            }


        }
     
        // Происходит при каждом переключении на текущую форму
        private void MainForm_Activated(object sender, EventArgs e)
        {
           
            try
            {
                DataBase1 = new DB(Program.GV.Profile.Table1, Program.GV.Profile.Columns1, Program.GV.Profile.DataBasePlace);   // Подключение к БД Пользователя     
                DataBase1.Fill();
                dGV_DB1.DataSource = DataBase1.DS.Tables[0];
                dGV_DB1.Update();

            }
            catch { }

            tV_Groups.Nodes.Clear();
            for (int i = 0; i < Program.GV.Groups.Length; i++)
            {
                tV_Groups.Nodes.Add(Program.GV.Groups[i].NameGroup);
                tV_Groups.Nodes[tV_Groups.Nodes.Count - 1].Tag = i;
                if (Program.GV.Groups[i].Spills != null)
                {
                    for (int j = 0; j < Program.GV.Groups[i].Spills.Length; j++)
                    {
                        tV_Groups.Nodes[tV_Groups.Nodes.Count - 1].Nodes.Add(Program.GV.Groups[i].Spills[j]);
                        tV_Groups.Nodes[tV_Groups.Nodes.Count - 1].Nodes[tV_Groups.Nodes[tV_Groups.Nodes.Count - 1].Nodes.Count - 1].Tag = j;
                    }
                }
            }
        }
        
        //Функция при выборе элемента в Дереве для групп. 
        private void tV_Groups_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
                if (tV_Groups.SelectedNode.Parent == null)
                {
                    tVWTB_Parameters.Tree.Items.Clear();
                   /* Program.GV.MainDB.Fill();
                    Program.GV.mainDBDataSet = Program.GV.MainDB.DS as MainDBDataSet;
                    tB_OpenDB.Text = tV_Groups.SelectedNode.Tag.ToString();*/
                    
                    Program.GV.Groups[Convert.ToInt32(tV_Groups.SelectedNode.Tag)].MakeTreeView(tVWTB_Parameters);
                    tVWTB_Parameters.ExpandAll(true);
                }
             
        }

        private void eH_Parameters_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            tB_OpenDB.Text = e.ToString();
        }

        private void tV_Groups_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (tV_Groups.SelectedNode.Parent == null)                        
                Program.GV.Groups[Convert.ToInt32(tV_Groups.SelectedNode.Tag)].NameGroup = e.Label;            

    }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }


        // Кнопка - сохранение групп по умолчанию
        private void b_SaveDefaultGroups_Click(object sender, EventArgs e)
        {
            Program.GV.MainDB.Fill();

            Program.GV.MainDB.AutoremoveGroupParameters(Program.GV.Groups);

            Program.GV.MainDB.SaveGroups(Program.GV.Groups);
           
            Program.GV.MainDB.Update();

            Program.GV.MainDB.Fill();
            Program.GV.mainDBDataSet = Program.GV.MainDB.DS as MainDBDataSet;
            Program.GV.Groups = new Group[Program.GV.mainDBDataSet.SaveGroups.Rows.Count];
            for (int i = 0; i < Program.GV.Groups.Length; i++)
            {
                Program.GV.Groups[i] = new Group(Convert.ToInt32(Program.GV.mainDBDataSet.SaveGroups.Rows[i][0]), Program.GV.mainDBDataSet);
            }
            
            

            






        }

        private void MainForm_Enter(object sender, EventArgs e)
        {
           

        }
    }
}
