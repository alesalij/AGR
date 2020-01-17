using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace AGR.Classes
{
    class Test
    {

        
        public void MakeDT(DataTable DT)
        {
            for(int i = 0;i<DT.Rows.Count;i++)
                for(int j = 1;j<DT.Columns.Count;j++)
                {
                    DT.Rows[i][j] = true;
                }
        }
    }
}
