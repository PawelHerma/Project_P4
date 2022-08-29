using Microsoft.EntityFrameworkCore;
using System;

namespace Project_P4.Models
{
    public class Income
    {
        public int MemberID { get; set; }
        public DateTime IncomeDate { get; set; }
        public decimal IncomeCost { get; set; }
    }
}