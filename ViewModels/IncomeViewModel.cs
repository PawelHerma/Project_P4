using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_P4.DbModels;

namespace Project_P4.ViewModels
{
    internal class IncomeViewModel : BaseViewModel
    {
        private Income _income;
        public int MemberID
        {
            get { return _income.MemberId; }
            set
            {
                if (value != _income.MemberId)
                {
                    _income.MemberId = value;
                    OnProperyChanged(nameof(MemberID));
                }
            }
        }
        public DateTime IncomeDate
        {
            get { return _income.IncomeDate; }
            set
            {
                if (value != _income.IncomeDate)
                {
                    _income.IncomeDate = value;
                    OnProperyChanged(nameof(IncomeDate));
                }
            }
        }
        public decimal IncomeCost
        {
            get { return _income.IncomeCost; }
            set
            {
                if (value != _income.IncomeCost)
                {
                    _income.IncomeCost = value;
                    OnProperyChanged(nameof(IncomeCost));
                }
            }
        }
    }
}
