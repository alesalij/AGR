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

namespace AGR
{
    public partial class MainForm : Form
    {
        //public static string connectString; // строка подключения 
        DB DataBase1, DataBase2;
        private OleDbConnection myConnection;
        public MainForm()
        {
            InitializeComponent();

            //Подключение к БД с настройками
            
            // Получение ДБ Настроек
            Program.GV.Profile.Load(Program.GV.Profile);
            Program.GV.Groups = new Group[Program.GV.mainDBDataSet.SaveGroupParameters.Rows.Count];
            
            // Зачем это здесь??
            for (int i = 0; i < Program.GV.Groups.Length;i++)
            {
                Program.GV.Groups[i] = new Group(Convert.ToInt32(Program.GV.mainDBDataSet.SaveGroupParameters.Rows[i][0]), Program.GV.mainDBDataSet);
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {

            /*Program.GV.SaveGroupsDataAdapter.Fill(Program.GV.mainDBDataSet.SaveGroups);    
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(Program.GV.SaveGroupsDataAdapter);
            Program.GV.SaveGroupsDataAdapter.UpdateCommand = cmd.GetUpdateCommand();*/

            Program.GV.MainDB.Fill();
            Program.GV.mainDBDataSet = Program.GV.MainDB.DS as MainDBDataSet;


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
            dataGridView1.DataSource = Program.GV.mainDBDataSet.SaveGroups;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Test f = new Test();
            f.MakeDT(Program.GV.mainDBDataSet.SaveGroups);
          


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
                        Program.GV.Groups[tV_Groups.SelectedNode.Index].Spills[Program.GV.Groups[Convert.ToInt32(tV_Groups.SelectedNode.Tag)].Spills.Length - 1] = dGV_DB1.SelectedCells[i].Value.ToString();
                        tV_Groups.SelectedNode.Nodes.Add(dGV_DB1.SelectedCells[i].Value.ToString());
                        f = false;
                    }
                }

                if (f) MessageBox.Show("Проверьте параметр /Выбранный столбец/");
                          
            }
        }

        private void b_AddGroup_Click(object sender, EventArgs e)
        {


            tV_Groups.Nodes.Add("Группа " + tV_Groups.Nodes.Count);
            Program.GV.MainDB.Fill();
            Program.GV.mainDBDataSet = Program.GV.MainDB.DS as MainDBDataSet;
            Program.GV.mainDBDataSet.SaveGroups.Rows.Add();
            Program.GV.mainDBDataSet.SaveGroups.Rows[Program.GV.mainDBDataSet.SaveGroups.Rows.Count - 1][1] = tV_Groups.Nodes[tV_Groups.Nodes.Count - 1].Text;       
            for(int i=2;i< Program.GV.mainDBDataSet.SaveGroups.Columns.Count;i++)
                Program.GV.mainDBDataSet.SaveGroups.Rows[Program.GV.mainDBDataSet.SaveGroups.Rows.Count - 1][i] = true;

            
            Program.GV.MainDB.DS = Program.GV.mainDBDataSet;
            Program.GV.MainDB.Update();
            Program.GV.MainDB.Fill();
            Program.GV.mainDBDataSet = Program.GV.MainDB.DS as MainDBDataSet;


            Array.Resize(ref Program.GV.Groups, Program.GV.Groups.Length + 1);
            Program.GV.Groups[Program.GV.Groups.Length - 1] = new Group(Convert.ToInt32(
                   Program.GV.mainDBDataSet.SaveGroups.Rows[Program.GV.mainDBDataSet.SaveGroups.Rows.Count-1][0]), 
                   Program.GV.mainDBDataSet);

           
            tV_Groups.Nodes[tV_Groups.Nodes.Count-1].Tag = Program.GV.Groups.Length - 1;
            //tB_OpenDB.Text = tV_Groups.Nodes[tV_Groups.Nodes.Count-1].Tag.ToString();

        
         
        dataGridView1.DataSource = Program.GV.mainDBDataSet.SaveGroups;

            dataGridView1.Update();
        }

        private void b_DeleteGroup_Click(object sender, EventArgs e)
        {

            tV_Groups.Nodes.Remove(tV_Groups.SelectedNode);
            
        }
     
        // Происходит при каждом переключении на текущую форму
        private void MainForm_Activated(object sender, EventArgs e)
        {
            tV_Groups.Nodes.Clear();
            try
            {
                DataBase1 = new DB(Program.GV.Profile.Table1, Program.GV.Profile.Columns1, Program.GV.Profile.DataBasePlace);   // Создание подключения к БД     
            // Заполнение dataGridView
          
            

            //DataBase1.MakeConnectString(); // Создание строки подключения OLEDB\

                DataBase1.Fill();
                dGV_DB1.DataSource = DataBase1.DS.Tables[0];
                dGV_DB1.Update();

            }
            catch { }

            // Заполнение treeViewGroups

            for (int i = 0; i < Program.GV.Groups.Length; i++)
            {
                tV_Groups.Nodes.Add(Program.GV.Groups[i].NameGroup);
                tV_Groups.Nodes[tV_Groups.Nodes.Count - 1].Tag = i;
                if (Program.GV.Groups[i].Spills !=null)
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
               // Program.DBAdapters.Fill();
               tVWTB_Parameters.Tree.Items.Clear();

                

            }
           /* tV_Groups.SelectedNode.Tag = "Bugaga";

            tB_OpenDB.Text = Program.GV.Groups[2].NameGroup;
                */


            /* 
                 Program.GV.defaultGroupsTableAdapter.Fill(Program.GV.mainDBDataSet.DefaultGroups);

                 if (tV_Groups.SelectedNode.Parent == null)
                 {
                     tVWTB_Parameters.Tree.Items.Clear();
                     Program.GV.defaultGroupsTableAdapter.Fill(Program.GV.mainDBDataSet.DefaultGroups);
                     // Класс для работы с настройками группы
                     Group g = new Group(Program.GV.mainDBDataSet.DefaultGroups);
                     // tVWTB_Parameters.AddChild();

                     for (int i = 0; i < g.SubGroupParameters.Length; i++)
                     {
                         //tVWTB_Parameters.AddSItem(tVWTB_Parameters.Tree.Items[tVWTB_Parameters.Tree.Items.Count - 1].ToString(),null);

                         if (tVWTB_Parameters.Tree.Items.Count != 0)
                         {
                             if (g.SubGroups[i] != g.SubGroups[i - 1])
                                 tVWTB_Parameters.AddItem(null, g.SubGroupParametersType[i], g.SubGroups[i], null);
                         }
                         else
                             tVWTB_Parameters.AddItem(null, g.SubGroupParametersType[i], g.SubGroups[i], null);
                         tVWTB_Parameters.AddItem(tVWTB_Parameters.Tree.Items[tVWTB_Parameters.Tree.Items.Count - 1] as TreeViewItem, g.SubGroupParametersType[i], g.SubGroupParameters[i], null);
                         //tVWTB_Parameters.Tree.Items[tVWTB_Parameters.Tree.Items.Count - 1].Add(g.SubGroupParameters[i]);
                     }

                 }
             */
        }

           private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tB_OpenDB.Text = checkBox1.Checked.ToString();
        }

        private void eH_Parameters_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            tB_OpenDB.Text = e.ToString();
        }

        private void tV_Groups_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (tV_Groups.SelectedNode.Parent == null)
                Program.GV.Groups[Convert.ToInt32(tV_Groups.SelectedNode.Tag)].NameGroup = e.Label;
            else
                tV_Groups.SelectedNode.Text = Program.GV.Groups[Convert.ToInt32(tV_Groups.SelectedNode.Parent.Tag)].Spills[Convert.ToInt32(tV_Groups.SelectedNode.Tag)];
        }

        private void MainForm_Enter(object sender, EventArgs e)
        {
            //tB_OpenDB.Text += "1"; 
           // DataBase1.ConnectString = Program.GV.Profile.DataBasePlace;
          //  DataBase1.MakeConnectString();
           // DataBase1.Connect();
            //connectStringDB1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Program.GV.Profile.DataBasePlace + ";";
            //connectStringDB2 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Program.GV.Profile.DataBasePlace + ";";

        }
    }
}
