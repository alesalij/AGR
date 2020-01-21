using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGR.Classes
{
    public class SubGroupParameter
    {
        public int IDParameter;
        public int IDSave;
        public string NameParameter; // Название параметра.
        public object Value; // Значение параметра.
        public string Type; // Тип параметра.

        // Функция расшифровки типа
        public string TypeMake(string s) 
        {
            string T="";
            int i=0;
            switch (s) 
            {
                case "Текстовый":        
                    T = Convert.ToString("String".GetType());
                    break;
                case "Числовой":
                    T = Convert.ToString(i.GetType());
                    break;
                case "Логический":
                    T = Convert.ToString(true.GetType());
                    break;
            }
                
            return T;
        }



        public SubGroupParameter() { }

        public SubGroupParameter(int IDGroup, int IDSubgroup, int ID, DataTable DTSubgroupsParameters, DataTable DTSaveGroupParameters) 
        {
            IDParameter = ID;
            for (int i = 0; i < DTSubgroupsParameters.Rows.Count; i++)
            {
                if (IDParameter == Convert.ToInt32(DTSubgroupsParameters.Rows[i][0])) 
                {
                    NameParameter = DTSubgroupsParameters.Rows[i][1].ToString();
                    Type = TypeMake(DTSubgroupsParameters.Rows[i][2].ToString());
                    Value = DTSubgroupsParameters.Rows[i][3]; // Присваивание Default
                    break;
                }
            }

            for(int i = 0; i< DTSaveGroupParameters.Rows.Count;i++)
            {
                if((Convert.ToInt32(DTSaveGroupParameters.Rows[i][1]) == IDGroup) &&
                    (Convert.ToInt32(DTSaveGroupParameters.Rows[i][2]) == IDSubgroup) &&
                    (Convert.ToInt32(DTSaveGroupParameters.Rows[i][3]) == IDParameter)) 
                {
                    IDSave = Convert.ToInt32(DTSaveGroupParameters.Rows[i][0]);
                    Value = DTSaveGroupParameters.Rows[i][4];
                    break;
                }
            }
        }

        public SubGroupParameter(int IDGroup,int IDSubgroup,int ID, MainDBDataSet DS)
        {
            IDParameter = ID;
            
            
            for (int i = 0; i < DS.SubGroupParameters.Rows.Count; i++)
            {
                if (IDParameter == Convert.ToInt32(DS.SubGroupParameters.Rows[i][0]))
                {
                    NameParameter = DS.SubGroupParameters.Rows[i][1].ToString();
                    Type = TypeMake(DS.SubGroupParameters.Rows[i][2].ToString());
                    Value = DS.SubGroupParameters.Rows[i][3]; // Присваивание Default
                    break;
                }
            }

            for (int i = 0; i < DS.SaveGroupParameters.Rows.Count; i++)
            {
                
                if ((Convert.ToInt32(DS.SaveGroupParameters.Rows[i][1]) == IDGroup) &&
                    (Convert.ToInt32(DS.SaveGroupParameters.Rows[i][2]) == IDSubgroup) &&
                    (Convert.ToInt32(DS.SaveGroupParameters.Rows[i][3]) == IDParameter))
                {
                    IDSave = Convert.ToInt32(DS.SaveGroupParameters.Rows[i][0]);
                    Value = DS.SaveGroupParameters.Rows[i][4];
                    break;
                }
            }
        }

    }
}
