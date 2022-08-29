using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_P4.Models;

namespace Project_P4.ViewModels
{
    internal class ExpenceViewModel : BaseViewModel
    {
        private Expence _expence;
        public int ExpenceID
        {
            get { return _expence.ExpenceID; }
            set
            {
                if (value != _expence.ExpenceID)
                {
                    _expence.ExpenceID = value;
                    OnProperyChanged();
                    OnProperyChanged(nameof(ExpenceID));
                }
            }
        }
        public int MemberID
        {
            get { return _expence.MemberID; }
            set
            {
                if (value != _expence.MemberID)
                {
                    _expence.MemberID = value;
                    OnProperyChanged();
                    OnProperyChanged(nameof(MemberID));
                }
            }
        }
        public int GroupID
        {
            get { return _expence.GroupID; }
            set
            {
                if (value != _expence.GroupID)
                {
                    _expence.GroupID = value;
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
