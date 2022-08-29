using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_P4.Models;

namespace Project_P4.ViewModels
{
    internal class ExpGroupViewModel : BaseViewModel
    {
        private ExpGroup _expGroup;
        public int GroupID
        {
            get { return _expGroup.GroupID; }
            set
            {
                if ( value != _expGroup.GroupID)
                {
                    _expGroup.GroupID = value;
                    OnProperyChanged(nameof(GroupID));
                }
            }
        }
        public string GroupName
        {
            get { return _expGroup.GroupName; }
            set
            {
                if (value != _expGroup.GroupName)
                {
                    _expGroup.GroupName = value;
                    OnProperyChanged(nameof(GroupName));
                }
            }
        }
    }
}
