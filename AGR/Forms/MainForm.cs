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
            //tV_Groups.CheckBoxes = true;
            Program.GV.MainConnection.Open();

            //DataSet DS = new DataSet();

           // Program.DBAdapters.Fill();
            // Program.GV.MainDBDataAdapter.Fill(Program.GV.mainDBDataSet, Program.GV.mainDBDataSet.SaveGroupParameters.TableName);


            //MainDBDataSet m = new MainDBDataSet;
            //m.SaveGroups.
            // Program.GV.saveGroupsTableAdapter.Adapter.Fill(Program.GV.mainDBDataSet.SaveGroups);

            /*Program.GV.saveGroupsTableAdapter.Update(Program.GV.mainDBDataSet.SaveGroups);
            Program.GV.saveGroupsTableAdapter.Fill(Program.GV.mainDBDataSet.SaveGroups);
            Program.GV.saveGroupParametersTableAdapter.Fill(Program.GV.mainDBDataSet.SaveGroupParameters);
            Program.GV.selectedSpillsTableAdapter.Fill(Program.GV.mainDBDataSet.SelectedSpills);
            Program.GV.subgroupsTableAdapter.Fill(Program.GV.mainDBDataSet.Subgroups);
            Program.GV.subGroupParametersTableAdapter.Fill(Program.GV.mainDBDataSet.SubGroupParameters);*/
            Program.GV.Groups = new Group[Program.GV.mainDBDataSet.SaveGroupParameters.Rows.Count];
            
            // Зачем это здесь??
            for (int i = 0; i < Program.GV.Groups.Length;i++)
            {
                Program.GV.Groups[i] = new Group(Convert.ToInt32(Program.GV.mainDBDataSet.SaveGroupParameters.Rows[i][0]), Program.GV.mainDBDataSet);
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            //Program.GV.saveGroupsTableAdapter.Adapter.SelectCommand = Program.GV.s;
            // Program.GV.mainDBDataSet.SaveGroupParameters 
            Program.GV.SaveGroupsDataAdapter.Fill(Program.GV.mainDBDataSet.SaveGroups);
            // Program.GV.saveGroupsTableAdapter.Fill(Program.GV.mainDBDataSet.SaveGroups);
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(Program.GV.SaveGroupsDataAdapter);
            Program.GV.SaveGroupsDataAdapter.UpdateCommand = cmd.GetUpdateCommand();

           // tB_OpenDB.Text = Program.GV.SaveGroupsDataAdapter.UpdateCommand.CommandText;

            //Program.DBAdapters.Fill();


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
           // tB_OpenDB.Text = Program.GV.SaveGroupsDataAdapter.UpdateCommand.CommandText;
            // Program.GV.saveGroupsTableAdapter.Update(Program.GV.mainDBDataSet.SaveGroups);
            //Program.GV.saveGroupsTableAdapter.Fill(Program.GV.mainDBDataSet.SaveGroups);
            //Program.GV.saveGroupsTableAdapter.GetData();

            //tB_OpenDB.Text = Program.GV.SaveGroupsDataAdapter.UpdateCommand.CommandText;



        }
        private void button4_Click(object sender, EventArgs e)
        {

            //!!!!!!!!!!!!!!!!!!!!!!!
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(Program.GV.SaveGroupsDataAdapter);                     
            cmd.QuotePrefix = "[";
            cmd.QuoteSuffix = "]";
            Program.GV.SaveGroupsDataAdapter.UpdateCommand = cmd.GetUpdateCommand();
            tB_OpenDB.Text = Program.GV.SaveGroupsDataAdapter.UpdateCommand.CommandText;
            Program.GV.SaveGroupsDataAdapter.Update(Program.GV.mainDBDataSet, "SaveGroups");
        

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
            Program.GV.MainConnection.Close();
        }

        private void b_Add_Click(object sender, EventArgs e)
        {
            if (tV_Groups.SelectedNode.Parent == null)
            {

                tV_Groups.SelectedNode.Nodes.Add(dGV_DB1.SelectedCells[0].Value.ToString());
                            
            }
        }

        private void b_AddGroup_Click(object sender, EventArgs e)
        {


            tV_Groups.Nodes.Add("Группа " + tV_Groups.Nodes.Count);
            Program.DBAdapters.Fill();
            Program.GV.mainDBDataSet.SaveGroups.Rows.Add();
            Program.GV.mainDBDataSet.SaveGroups.Rows[Program.GV.mainDBDataSet.SaveGroups.Rows.Count - 1][1] = tV_Groups.Nodes[tV_Groups.Nodes.Count - 1].Text;       
            for(int i=2;i< Program.GV.mainDBDataSet.SaveGroups.Columns.Count;i++)
                Program.GV.mainDBDataSet.SaveGroups.Rows[Program.GV.mainDBDataSet.SaveGroups.Rows.Count - 1][i] = true;

            Program.DBAdapters.UpdateFill();


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
            // Заполнение dataGridView
            try
            {
                DataBase1 = new DB(Program.GV.Profile.DataBasePlace);   // Создание подключения к БД        
                DataBase1.DBTable = Program.GV.Profile.Table1; // Параметр чтения - нужная таблица в БД
                DataBase1.DBColumns = Program.GV.Profile.Columns1; // Параметр - нужные колонки
                DataBase1.SQLString = DataBase1.SQLMake(); // Создание строки SQL запроса 
                DataBase1.MakeConnectString(); // Создание строки подключения OLEDB\
                DataBase1.Connect(); // Подключение к БД
                DataBase1.DSMake(); // Создание и запись данных в Dataset
                dGV_DB1.DataSource = DataBase1.DS.Tables[0];
                dGV_DB1.Update();
            }
            catch { }

            // Заполнение treeViewGroups
            /* Program.GV.saveGroupsTableAdapter.Fill(Program.GV.mainDBDataSet.SaveGroups);
             Program.GV.saveGroupParametersTableAdapter.Fill(Program.GV.mainDBDataSet.SaveGroupParameters);
             Program.GV.selectedSpillsTableAdapter.Fill(Program.GV.mainDBDataSet.SelectedSpills);
             Program.GV.subgroupsTableAdapter.Fill(Program.GV.mainDBDataSet.Subgroups);
             Program.GV.subGroupParametersTableAdapter.Fill(Program.GV.mainDBDataSet.SubGroupParameters);*/
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
                Program.DBAdapters.Fill();
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
