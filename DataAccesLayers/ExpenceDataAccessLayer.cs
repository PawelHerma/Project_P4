using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Project_P4.DbModels;


namespace Project_P4.DataAccesLayers
{
    internal class ExpenceDataAccessLayer
    {
        DataTable dt;
        public ExpenceDataAccessLayer()
        {
            dt = new DataTable("Expence");
            dt.Columns.Add("ExpenceId", typeof(int));
            dt.Columns.Add("MemberId", typeof(int));
            dt.Columns.Add("GroupId", typeof(int));
            dt.Columns.Add("ExpenceDate", typeof(DateTime));
            dt.Columns.Add("ExpenceCost", typeof(int));
        }
        public List<Expence> GetAllExpences()
        {
            var list = new List<Expence>();
            foreach(DataRow dr in dt.Rows)
            {
                var expence = new Expence
                {
                    ExpenceId = (int)dr[1],
                    MemberId = (int)dr[2],
                    GroupId = (int)dr[3],
                    ExpenceDate = (DateTime)dr[4],
                    ExpenceCost = (int)dr[5],
                };
                list.Add(expence);
            }
            return list;
        }
    }
}
