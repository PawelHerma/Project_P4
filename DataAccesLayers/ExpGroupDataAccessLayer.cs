using Project_P4.DbModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P4.DataAccesLayers
{
    internal class ExpGroupDataAccessLayer
    {
        DataTable dt;
        public ExpGroupDataAccessLayer()
        {
            dt = new DataTable("ExpGroup");
            dt.Columns.Add("GroupId", typeof(int));
            dt.Columns.Add("GroupName", typeof(string));
        }
        public List<ExpGroup> GetAllExpGroups()
        {
            var list = new List<ExpGroup>();
            foreach(DataRow dr in dt.Rows)
            {
                var expGroup = new ExpGroup
                {
                    GroupId = (int)dr[1],
                    GroupName = (string)dr[2],
                };
                list.Add(expGroup);
            }
            return list;
        }
    }
}
