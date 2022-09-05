using Project_P4;
using Project_P4.Commands;
using Project_P4.DataAccesLayers;
using Project_P4.DbModels;
using Project_P4.Views;
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
            AddMemberClick = new RelayCommand(x => DisplayAddMessage(), x => this.IsValid);
            UpdateMemberClick = new RelayCommand(x => DisplayUpdateMessage(), x => this.IsValid);
            RemoveMemberClick = new RelayCommand(x => DisplayRemoveMessage(), x => this.IsValid);
        }
        
        private void DisplayRemoveMessage()
        {
            using (var context = new Projekt01_HermaContext())
            {
                var memberToRemove = context.Members.Where(x => x.MemberName == _member.MemberName).FirstOrDefault();
                context.Members.Remove(memberToRemove);
                context.SaveChanges();
                RefreshMembers();
                AllMembers = new ObservableCollection<Member>(context.Members.ToList());
            }
            MessageBox.Show("Usunięto Czlonka rodziny");
        }

        private void DisplayUpdateMessage()
        {
            using (var context = new Projekt01_HermaContext())
            {
                var memberToUpdate = context.Members.Where(x => x.MemberName == _member.MemberName).FirstOrDefault();
                memberToUpdate.MemberBudget = Budzet;
                context.Members.Update(memberToUpdate);
                context.SaveChanges();
                RefreshMembers();
                AllMembers = new ObservableCollection<Member>(context.Members.ToList());
            }
            MessageBox.Show("Zaktualizowano Czlonka rodziny");
        }

        private void DisplayAddMessage()
        {
            using (var context = new Projekt01_HermaContext())
            {
                context.Members.Add(new Member { MemberName = Imie, MemberBudget = Budzet });
                context.SaveChanges();
                RefreshMembers();
                AllMembers = new ObservableCollection<Member>(context.Members.ToList());
            }
            MessageBox.Show("Dodano Czlonka rodziny");
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
        public ICommand AddMemberClick { get; set; }
        public ICommand UpdateMemberClick { get; set; }
        public ICommand RemoveMemberClick { get; set; }
        public bool IsValid { get => !string.IsNullOrEmpty(Imie); }
    }
}
