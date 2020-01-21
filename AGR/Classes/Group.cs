using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using AGR.Classes;
using System.Windows.Controls;
using AGR;

namespace AGR
{
    public class Group
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

        // Функция занесения данных в TreeView.    
        public void MakeTreeView(TreeViewWTBox tV)
        {
            //TreeViewWTBox tV = new TreeViewWTBox();

            for (int i = 0; i < SubGroups.Length; i++)
            {
                tV.AddItem(null, true.GetType().ToString(), SubGroups[i].NameSubGroup, SubGroups[i].Check);

                for (int j = 0; j < SubGroups[i].Parameters.Length; j++) 
                {
                    tV.AddItem(tV.Tree.Items[tV.Tree.Items.Count - 1] as TreeViewItem, SubGroups[i].Parameters[j].Type, SubGroups[i].Parameters[j].NameParameter, SubGroups[i].Parameters[j].Value);
                }
            }
            
        }
        // Запись данных группы в DataSet;
        /*public void SaveGroupParameters(MainDBDataSet DS)
        {
            for (int i = 0; i < SubGroups.Length; i++) 
            {
                for (int j = 0; j < SubGroups[i].Parameters.Length; j++)
                {
                    if (SubGroups[i].Parameters[j].IDSave == 0)
                    {
                        DS.SaveGroupParameters.Rows.Add();
                        DS.SaveGroupParameters.Rows[DS.SaveGroupParameters.Rows.Count - 1][1] = SubGroups[i].Parameters[j].IDGroup;
                        DS.SaveGroupParameters.Rows[DS.SaveGroupParameters.Rows.Count - 1][2] = SubGroups[i].Parameters[j].IDSubgroup;
                        DS.SaveGroupParameters.Rows[DS.SaveGroupParameters.Rows.Count - 1][3] = SubGroups[i].Parameters[j].IDParameter;
                        DS.SaveGroupParameters.Rows[DS.SaveGroupParameters.Rows.Count - 1][4] = SubGroups[i].Parameters[j].Value.ToString();
                    }
                    else
                        for (int k = 0; k < DS.SaveGroupParameters.Rows.Count; k++)
                        {
                            if (Convert.ToInt32(DS.SaveGroupParameters.Rows[k][0]) == SubGroups[i].Parameters[j].IDSave) 
                            { 
                                DS.SaveGroupParameters.Rows[k][1] = SubGroups[i].Parameters[j].IDGroup;
                                DS.SaveGroupParameters.Rows[k][2] = SubGroups[i].Parameters[j].IDSubgroup;
                                DS.SaveGroupParameters.Rows[k][3] = SubGroups[i].Parameters[j].IDParameter;
                                DS.SaveGroupParameters.Rows[k][4] = SubGroups[i].Parameters[j].Value.ToString();
                            }
                        }
                }
            }

        }*/


        /*
         ******************************Конструкторы*************************************
             */
        public Group(int ID, MainDBDataSet DS) // Конструктор группы по DataSet
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
                
                SubGroups[i] = new SubGroup(IDGroup, Convert.ToInt32(DS.Subgroups.Rows[i][0]), DS);
                
            }

        }
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
                SubGroups[i] = new SubGroup(IDGroup, Convert.ToInt32(DTSubgroups.Rows[i][0]), DTSubgroups, DTSubgroupsParameters, DTSaveGroups, DTSaveGroupParameters);
            }

        }
        public Group() { }

        /*
         *******************************************************************************
             */



    }
}
