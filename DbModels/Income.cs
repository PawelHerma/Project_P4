using System;
using System.Collections.Generic;

namespace Project_P4.DbModels
{
    public partial class Income
    {
        public int MemberId { get; set; }
        public DateTime IncomeDate { get; set; }
        public decimal IncomeCost { get; set; }

        public virtual Member Member { get; set; } = null!;
    }
}
