using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using AGR.Classes;

namespace AGR
{
    class Group
    {
        /*
         * Таблица вида: 
         * Код * Группа * Подгруппа * Скорость потока;По времени * Скорость потока;По ресурсу
         

             */
        public string[] Spills; // Массив имен проливов. +
        public int[] IDSpills; // Массив ID проливов. +
        public string NameGroup; // Имя группы +
        public int IDGroup; // ID Группы в БД +
        public SubGroup[] SubGroups; // Подгруппы.

        /*  public bool[] SubGroupsCheck; //Массив значений подгрупп
        public string[] SubGroups;//  Массив имен подгрупп (Скорость потока).
        public string[] SubGroupParameters; // Массив имен параметров подгрупп (По времени, по ресурсу).
        public string[] SubGroupParametersType; // Типы данных параметров подгрупп.
        public object[,] SubGroupParametersCheck; // Значение параметров. Подгруппа\Параметр
        public DataTable MainDT;*/

        // Функция занесения данных в таблицу.
        public void MakeSave()
        {
            /*  if (MainDT.Columns.Count > 3)

                  for (int i = 2; i < MainDT.Columns.Count; i++)
                  {
                      for (int j = 0; j < MainDT.Rows.Count; j++)
                      {
                          MainDT.Rows[j][i] = SubGroupParametersCheck[i - 2, j];
                      }
                  }*/
        }
        /* public void Save() 
         {

         }*/
        /* public Group(DataTable DTSelecteSpills, DataTable DTSubgroups, DataTable DTSubgroupsParameters, DataTable DTSaveGroups, DataTable DTSaveGroupParameters)
         {
             NameGroup = "Группа";
         } */
        public Group(int ID, MainDBDataSet DS)
        {
            IDGroup = ID;
            Spills = new string[1];
            IDSpills = new int[1];
            SubGroups = new SubGroup[DS.Subgroups.Rows.Count];
            // Имя группы по ID
            for (int i = 0; i < DS.SaveGroups.Rows.Count; i++)
            {
                if (Convert.ToInt32(Program.GV.mainDBDataSet.SaveGroups.Rows[i][0]) == ID)
                {
                    NameGroup = Program.GV.mainDBDataSet.SaveGroups.Rows[i][1].ToString();
                    break;
                }
            }

            // заполнение Массива Проливов
            for (int i = 0; i < DS.SelectedSpills.Rows.Count; i++)
            {
                if (Convert.ToInt32(Program.GV.mainDBDataSet.SelectedSpills.Rows[i][1]) == ID)
                {
                    Spills[Spills.Length - 1] = Program.GV.mainDBDataSet.SelectedSpills.Rows[i][2].ToString();
                    IDSpills[IDSpills.Length - 1] = Convert.ToInt32(Program.GV.mainDBDataSet.SelectedSpills.Rows[i][0]);
                    Array.Resize(ref Spills, Spills.Length + 1);
                    Array.Resize(ref IDSpills, IDSpills.Length + 1);
                }
            }
            Array.Resize(ref Spills, Spills.Length - 1);
            Array.Resize(ref IDSpills, IDSpills.Length - 1);

            //Заполнение массива подгрупп.
            for (int i = 0; i < SubGroups.Length; i++)
            {
                SubGroups[i] = new SubGroup(Convert.ToInt32(DS.Subgroups.Rows[i][0]), DS);
            }

        }// Конструктор группы по
        public Group(int ID, DataTable DTSelecteSpills, DataTable DTSubgroups, DataTable DTSubgroupsParameters, DataTable DTSaveGroups, DataTable DTSaveGroupParameters) 
        {
            IDGroup = ID;
            Spills = new string[1];
            IDSpills = new int[1];
            SubGroups = new SubGroup[DTSubgroups.Rows.Count];
            // Имя группы по ID
            for (int i = 0; i < DTSaveGroups.Rows.Count; i++)
            {
                if (Convert.ToInt32(Program.GV.mainDBDataSet.SaveGroups.Rows[i][0]) == ID)
                {
                    NameGroup = Program.GV.mainDBDataSet.SaveGroups.Rows[i][1].ToString();
                    break;
                }
            }

            // заполнение Массива Проливов
            for (int i = 0; i < DTSelecteSpills.Rows.Count; i++)
            {
                if (Convert.ToInt32(Program.GV.mainDBDataSet.SelectedSpills.Rows[i][1]) == ID)
                {
                    Spills[Spills.Length - 1] = Program.GV.mainDBDataSet.SelectedSpills.Rows[i][2].ToString();
                    IDSpills[IDSpills.Length - 1] = Convert.ToInt32(Program.GV.mainDBDataSet.SelectedSpills.Rows[i][0]);
                    Array.Resize(ref Spills, Spills.Length + 1);
                    Array.Resize(ref IDSpills, IDSpills.Length + 1);
                }
            }
            Array.Resize(ref Spills, Spills.Length - 1);
            Array.Resize(ref IDSpills, IDSpills.Length - 1);

            //Заполнение массива подгрупп.
            for(int i = 0;i<SubGroups.Length;i++)
            {      
                SubGroups[i] = new SubGroup(Convert.ToInt32(DTSubgroups.Rows[i][0]), DTSubgroups, DTSubgroupsParameters, DTSaveGroups, DTSaveGroupParameters);
            }

        }
        // Конструктор Класса по ID Группы
        public Group(int ID) 
        {
            //IDGroup = ID;

  /*          
            Program.GV.saveGroupsTableAdapter.Fill(Program.GV.mainDBDataSet.SaveGroups);
            Program.GV.selectedSpillsTableAdapter.Fill(Program.GV.mainDBDataSet.SelectedSpills);
            Program.GV.subgroupsTableAdapter.Fill(Program.GV.mainDBDataSet.Subgroups);
            Program.GV.subGroupParametersTableAdapter.Fill(Program.GV.mainDBDataSet.SubGroupParameters);
            Spills = new string[1];
            IDSpills = new int[1];
            SubGroups = new string[Program.GV.mainDBDataSet.Subgroups.Rows.Count* Program.GV.mainDBDataSet.SubGroupParameters.Rows.Count];
          //  SubGroupParametersCheck = new string[SubGroups.Length];
            //SubGroupParametersCheck = new string[SubGroups.Length];
            SubGroupsCheck = new bool[SubGroups.Length];
            if (Program.GV.mainDBDataSet.SaveGroups.Rows.Count > 0)
            {
                // Заполнение имен параметров и типов

                // Заполнение Имен подгрупп
                for(int i = 0;i< Program.GV.mainDBDataSet.Subgroups.Rows.Count;i++)
                {
                    SubGroups[i] = Program.GV.mainDBDataSet.Subgroups.Rows[1].ToString();

                }

                // Заполнение Имя группы по ID
                for(int i = 0;i< Program.GV.mainDBDataSet.SaveGroups.Rows.Count;i++)
                {
                    if (Convert.ToInt32(Program.GV.mainDBDataSet.SaveGroups.Rows[i][0]) == ID) 
                    {
                        for(int j = 0;j<SubGroups.Length;j++)
                        {
                            SubGroups[j] = Program.GV.mainDBDataSet.SaveGroups.Columns[j + 2].Caption;
                            SubGroupsCheck[j] = Convert.ToBoolean(Program.GV.mainDBDataSet.SaveGroups.Rows[i][j + 2]);
                        }
                        Group = Program.GV.mainDBDataSet.SaveGroups.Rows[i][1].ToString();
                    }
                } 
                // заполнение Массива Проливов
               for(int i = 0; i < Program.GV.mainDBDataSet.SelectedSpills.Rows.Count;i++)
                {
                    if(Convert.ToInt32(Program.GV.mainDBDataSet.SelectedSpills.Rows[i][1]) == ID)
                    {
                        Spills[Spills.Length - 1] = Program.GV.mainDBDataSet.SelectedSpills.Rows[i][2].ToString();
                        IDSpills[IDSpills.Length - 1] = Convert.ToInt32(Program.GV.mainDBDataSet.SelectedSpills.Rows[i][0]);
                        Array.Resize(ref Spills, Spills.Length + 1);
                        Array.Resize(ref IDSpills, IDSpills.Length + 1);
                    }
                }
                Array.Resize(ref Spills, Spills.Length - 1);
                Array.Resize(ref IDSpills, IDSpills.Length - 1);


                //Заполнение массива подгрупп

            }


                /*  // Заполнение массива групп.
                  Program.GV.saveGroupsTableAdapter.Fill(Program.GV.mainDBDataSet.SaveGroups);
                  Program.GV.selectedSpillsTableAdapter.Fill(Program.GV.mainDBDataSet.SelectedSpills);
                  if (Program.GV.mainDBDataSet.SaveGroups.Rows.Count > 0)
                  {
                      IDGroup = new int[Program.GV.mainDBDataSet.SaveGroups.Rows.Count];

                      for (int i=0;i< IDGroup.Length;i++)
                      {
                          IDGroup[i] = Convert.ToInt32(Program.GV.mainDBDataSet.SaveGroups.Rows[i][0]);
                          Group.Nodes.Add(Program.GV.mainDBDataSet.SaveGroups.Rows[i][1].ToString());
                      }
                      for (int i = 0; i < Program.GV.mainDBDataSet.SelectedSpills.Count; i++) 
                      {
                          for (int j = 0; j < IDGroup.Length; j++)
                          {
                              if (IDGroup[j] == Convert.ToInt32(Program.GV.mainDBDataSet.SelectedSpills.Rows[i][1]))
                              {
                                  Group.Nodes[j].Nodes.Add(Program.GV.mainDBDataSet.SelectedSpills.Rows[i][2].ToString());
                              }
                          }

                      }

                      // Заполнение массива значений подгрупп и параметров
                      */


                /*  Group = new List<string>[Program.GV.mainDBDataSet.SaveGroups.Rows.Count];
                  IDGroup = new int[Group.Length];
                  for (int i = 0; i < Group.Length; i++)
                  {
                      IDGroup[i] = Convert.ToInt32(Program.GV.mainDBDataSet.SaveGroups.Rows[i][0]);
                      Group[i].Add(Program.GV.mainDBDataSet.SaveGroups.Rows[i][1].ToString());
                  }
                  for (int i = 0;i< Program.GV.mainDBDataSet.SelectedSpills.Count;i++)
                  {
                      for (int j = 0; j < IDGroup.Length; j++)
                          if (IDGroup[j] == Convert.ToInt32(Program.GV.mainDBDataSet.SelectedSpills.Rows[i][1]))
                          {
                              Group[j].Add(Program.GV.mainDBDataSet.SelectedSpills.Rows[i][2].ToString());
                          }
                  }
              }*/





            }
        public Group() { }
        // Конструктор класса по таблице.;
        public Group(DataTable DT)
        {
           /* MainDT = DT;
            Groups = new string[MainDT.Rows.Count];
            SubGroups = new string[MainDT.Columns.Count - 3];
            SubGroupParameters = new string[SubGroups.Length];
            SubGroupParametersType = new string[SubGroups.Length];
            SubGroupParametersCheck = new object[SubGroups.Length + 1, MainDT.Rows.Count];
            if (MainDT.Columns.Count > 3)

                for (int i = 3; i < MainDT.Columns.Count; i++)
                {

                    SubGroups[i - 3] = MainDT.Columns[i].Caption.Substring(0, MainDT.Columns[i].Caption.IndexOf(";"));
                    SubGroupParameters[i - 3] = MainDT.Columns[i].Caption.Substring(MainDT.Columns[i].Caption.IndexOf(";") + 1);
                    SubGroupParametersType[i - 3] = MainDT.Rows[0][i].GetType().ToString();

                    for (int j = 0; j < MainDT.Rows.Count; j++)
                    {
                        SubGroupParametersCheck[0, j] = MainDT.Rows[j][2];
                        SubGroupParametersCheck[i - 2, j] = MainDT.Rows[j][i];
                        //          Groups[j] = MainDT.Rows[2][j].ToString();
                    }

                }

            bool f = false;
            for (int i = 0; i < SubGroupParametersType.Length; i++)
            {
                if (SubGroupParametersType[i] == "System.DBNull")
                {
                    SubGroupParametersCheck[i + 1, 0] = "0";
                    f = true;
                }
                
            }

            if (f)
            {
                MakeSave();
                for (int i = 3; i < MainDT.Columns.Count; i++)
                {
                    SubGroupParametersType[i - 3] = MainDT.Rows[0][i].GetType().ToString();
                }
            }*/
        }
        
   
       



    }
}
