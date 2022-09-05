using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_P4.DbModels;
using Project_P4.Commands;
using Project_P4.DataAccesLayers;
using System.Windows;
using System.Windows.Input; 
using System.Collections.ObjectModel;

namespace Project_P4.ViewModels
{
    internal class ExpenceViewModel : BaseViewModel
    {
        private Expence _expence = new Expence();
        private ExpenceDataAccessLayer _expenceData;
        public ExpenceViewModel()
        {
            _expenceData = new ExpenceDataAccessLayer();
            RefreshExpences();
            using ( var context  = new Projekt01_HermaContext())
            {
                AllExpences = new ObservableCollection<Expence>(context.Expences.ToList() );
            }
            AddExpenceClick = new RelayCommand(x => DisplayAddMessage());
            UpdateExpenceClick = new RelayCommand(x => DisplayUpdateMessage());
            RemoveExpenceClick = new RelayCommand(x => DisplayRemoveMessage());

        }

        private void DisplayUpdateMessage()
        {
            using (var context = new Projekt01_HermaContext())
            {
                var expenceToUpdate = context.Expences.Where(x => x.ExpenceId == _expence.ExpenceId).FirstOrDefault();
                expenceToUpdate.expe = Budzet;
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
                context.Expences.Add(new Expence{ ExpenceId = ExpenceID, MemberId = MemberID, GroupId = GroupID, ExpenceDate = ExpenceDate, ExpenceCost = ExpenceCost });
                context.SaveChanges();
                RefreshExpences();
                AllExpences = new ObservableCollection<Expence>(context.Expences.ToList());
            }
            MessageBox.Show("Dodano wydatek");
        }

        private ObservableCollection<Expence> _allExpences;
        public ObservableCollection<Expence> AllExpences
        {
            get { return _allExpences; }
            set
            {
                _allExpences = value;
                OnProperyChanged(nameof(AllExpences));
            }
        }

        private void RefreshExpences()
        {
            var obj = new ObservableCollection<Expence>((IEnumerable<Expence>)_expenceData.GetAllExpences());
            AllExpences = obj;
        }

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
        public ICommand AddExpenceClick { get; set; }
        public ICommand UpdateExpenceClick { get; set; }
        public ICommand RemoveExpenceClick { get; set; }
    }
}
