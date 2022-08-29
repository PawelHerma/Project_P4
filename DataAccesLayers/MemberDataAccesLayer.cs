using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Project_P4.Models;

namespace Project_P4.DataAccesLayers
{
    internal class MemberDataAccesLayer
    {
        DataTable dt;
        public MemberDataAccesLayer()
        {
            dt = new DataTable("Member");
            dt.Columns.Add("MemberID", typeof(int));
            dt.Columns.Add("MemberName", typeof(string));
            dt.Columns.Add("MemberBudget", typeof(int));
        }
        public bool AddMemberClick(Member member)
        {
            try
            {
                dt.Rows.Add(null, member.MemberID, member.MemberName, member.MemberBudget);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        public List<Member> GetAllMembers()
        {
            var list = new List<Member>();
            foreach(DataRow dr in dt.Rows)
            {
                var member = new Member
                {
                    MemberID = (int)dr[1],
                    MemberName = dr[2].ToString(),
                    MemberBudget = (int)dr[3],
                };
                list.Add(member);
            }
            return list;
        }
    }
}
