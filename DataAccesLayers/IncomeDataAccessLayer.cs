using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Project_P4.DbModels;

namespace Project_P4.DataAccesLayers
{
    internal class IncomeDataAccessLayer
    {
        DataTable dt;
        public IncomeDataAccessLayer()
        {
            dt = new DataTable("Income");
            dt.Columns.Add("MemberId", typeof(int));
            dt.Columns.Add("IncomeDate", typeof(DateTime));
            dt.Columns.Add("IncomeCost", typeof(int));
        }
        public List<Income> GetAllIncomes()
        {
            var list = new List<Income>();
            foreach(DataRow dr in dt.Rows)
            {
                var income = new Income
                {
                    MemberId = (int)dr[1],
                    IncomeDate = (DateTime)dr[2],
                    IncomeCost = (int)dr[3],
                };
                list.Add(income);
            }
            return list;
        }
    }
}
