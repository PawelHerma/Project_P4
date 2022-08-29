using Project_P4;
using Project_P4.DataAccesLayers;
using Project_P4.DbModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace Project_P4.ViewModels
{
    internal class MemberViewModel : BaseViewModel
    {
        private Member _member = new Member();
        private MemberDataAccesLayer _memberData;
        public MemberViewModel()
        {
            _memberData = new MemberDataAccesLayer();
            RefreshMembers();
            using (var context = new Project_P4.DbModels.Projekt01_HermaContext())
            {
                AllMembers = new ObservableCollection<Member>(context.Members.ToList());
            }
            
        }
        private ObservableCollection<Member> _allMembers;
        
        public ObservableCollection<Member> AllMembers
        {
            get { return _allMembers; }
            set
            {
                _allMembers = value;
                OnProperyChanged(nameof(AllMembers));
            }
        }
        public ICommand AddMemberClick
        {
            get;
            private set;
        }
        public void RefreshMembers()
        {
            var obj = new ObservableCollection<Member>((IEnumerable<Member>)_memberData.GetAllMembers());
            AllMembers = obj;
        }
        public int IdCzlonka
        {
            get { return _member.MemberId; }
            set
            {
                if (_member.MemberId != value)
                {
                    _member.MemberId = value;
                    OnProperyChanged(nameof(IdCzlonka));
                }
            }
        }
        public string Imie
        {
            get { return _member.MemberName; }
            set
            {
                if (value != _member.MemberName)
                {
                    _member.MemberName = value;
                    OnProperyChanged(nameof(Imie));
                }
            }
        }
        public decimal Budzet
        {
            get { return (decimal)_member.MemberBudget; }
            set
            {
                if (value != _member.MemberBudget)
                {
                    _member.MemberBudget = value;
                    OnProperyChanged(nameof(Budzet));
                }
            }
        }
    }
}
