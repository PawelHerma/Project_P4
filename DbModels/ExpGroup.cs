using System;
using System.Collections.Generic;

namespace Project_P4.DbModels
{
    public partial class ExpGroup
    {
        public ExpGroup()
        {
            Expences = new HashSet<Expence>();
        }

        public int GroupId { get; set; }
        public string? GroupName { get; set; }

        public virtual ICollection<Expence> Expences { get; set; }
    }
}
