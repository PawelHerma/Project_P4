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
    internal class MemberDataAccesLayer
    {
        DataTable dt;
        public MemberDataAccesLayer()
        {
            dt = new DataTable("Member");
            dt.Columns.Add("MemberId", typeof(int));
            dt.Columns.Add("MemberName", typeof(string));
            dt.Columns.Add("MemberBudget", typeof(int));
        }
        public bool AddMemberClick(Member member)
        {
            try
            {
                dt.Rows.Add(null, member.MemberId, member.MemberName, member.MemberBudget);
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
                    MemberId = (int)dr[1],
                    MemberName = dr[2].ToString(),
                    MemberBudget = (int)dr[3],
                };
                list.Add(member);
            }
            return list;
        }
    }
}
