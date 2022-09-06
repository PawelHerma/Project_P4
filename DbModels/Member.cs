using System;
using System.Collections.Generic;

namespace Project_P4.DbModels
{
    public partial class Member
    {
        public Member()
        {
            Expences = new HashSet<Expence>();
        }

        public int MemberId { get; set; }
        public string? MemberName { get; set; }
        public decimal MemberBudget { get; set; }

        public virtual ICollection<Expence> Expences { get; set; }
    }
}
