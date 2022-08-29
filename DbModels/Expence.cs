using System;
using System.Collections.Generic;

namespace Project_P4.DbModels
{
    public partial class Expence
    {
        public int ExpenceId { get; set; }
        public int MemberId { get; set; }
        public int GroupId { get; set; }
        public DateTime ExpenceDate { get; set; }
        public decimal ExpenceCost { get; set; }

        public virtual ExpGroup Group { get; set; } = null!;
        public virtual Member Member { get; set; } = null!;
    }
}
