using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_P4.DbModels;

namespace Project_P4.ViewModels
{
    internal class ExpenceViewModel : BaseViewModel
    {
        private Expence _expence;
        public int ExpenceID
        {
            get { return _expence.ExpenceId; }
            set
            {
                if (value != _expence.ExpenceId)
                {
                    _expence.ExpenceId = value;
                    OnProperyChanged(nameof(ExpenceID));
                }
            }
        }
        public int MemberID
        {
            get { return _expence.MemberId; }
            set
            {
                if (value != _expence.MemberId)
                {
                    _expence.MemberId = value;
                    OnProperyChanged(nameof(MemberID));
                }
            }
        }
        public int GroupID
        {
            get { return _expence.GroupId; }
            set
            {
                if (value != _expence.GroupId)
                {
                    _expence.GroupId = value;
                    OnProperyChanged(nameof(GroupID));
                }
            }
        }
        public DateTime ExpenceDate
        {
            get { return _expence.ExpenceDate; }
            set
            {
                if (value != _expence.ExpenceDate)
                {
                    _expence.ExpenceDate = value;
                    OnProperyChanged(nameof(ExpenceDate));
                }
            }
        }
        public decimal ExpenceCost
        {
            get { return _expence.ExpenceCost; }
            set
            {
                if (value != _expence.ExpenceCost)
                {
                    _expence.ExpenceCost = value;
                    OnProperyChanged(nameof(ExpenceCost));
                }
            }
        }
    }
}
