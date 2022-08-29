using System;

namespace Project_P4.Models
{
    public class Expence
    {
        public int ExpenceID { get; set; }
        public int MemberID { get; set; }
        public int GroupID { get; set; }
        public DateTime ExpenceDate { get; set; }
        public decimal ExpenceCost { get; set; }

    }
}