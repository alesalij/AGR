using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGR.Classes
{
    public class SubGroup
    {
        public int IDSubgroup;
        public string NameSubGroup;
        public bool Check;
        public SubGroupParameter[] Parameters;

        // Конструктор Подгруппы
        public SubGroup(int IDGroup, int ID, DataTable DTSubgroups, DataTable DTSubgroupsParameters, DataTable DTSaveGroups, DataTable DTSaveGroupParameters)
        {
            IDSubgroup = ID;
            for(int i=0;i<DTSubgroups.Rows.Count;i++)
            {
                if(ID == Convert.ToInt32(DTSubgroups.Rows[i][0])) 
                {
                    NameSubGroup = DTSubgroups.Rows[i][1].ToString();

                    for (int j = 0; j < DTSaveGroups.Rows.Count; j++)
                    {
                        if (IDGroup == Convert.ToInt32(DTSaveGroups.Rows[j][0]))
                        {
                            Check = Convert.ToBoolean(DTSaveGroups.Rows[j][i + 2]);
                            break;
                        }
                        else Check = true;
                    }
                }
            }

            Parameters = new SubGroupParameter[DTSubgroupsParameters.Rows.Count];
            for(int i = 0; i<Parameters.Length;i++)
            {
                Parameters[i] = new SubGroupParameter( IDGroup,IDSubgroup,Convert.ToInt32(DTSubgroupsParameters.Rows[i][0]), DTSubgroupsParameters, DTSaveGroupParameters);
            }
            
        }

        public SubGroup(int IDGroup,int ID, MainDBDataSet DS)
        {
            IDSubgroup = ID;
           
            for (int i = 0; i < DS.Subgroups.Rows.Count; i++)
            {
                if (ID == Convert.ToInt32(DS.Subgroups.Rows[i][0]))
                {
                    NameSubGroup = DS.Subgroups.Rows[i][1].ToString();

                    for (int j = 0; j < DS.SaveGroups.Rows.Count; j++)
                    {
                        if (IDGroup == Convert.ToInt32(DS.SaveGroups.Rows[j][0]))
                        {
                            Check = Convert.ToBoolean(DS.SaveGroups.Rows[j][i + 2]);
                            break;
                        }
                        else Check = true;
                    }
                }
            }

            Parameters = new SubGroupParameter[DS.SubGroupParameters.Rows.Count];
            for (int i = 0; i < Parameters.Length; i++)
            {
                Parameters[i] = new SubGroupParameter(IDGroup,IDSubgroup,Convert.ToInt32(DS.SubGroupParameters.Rows[i][0]), DS);
            }

        }
        public SubGroup() { }
    }
}
