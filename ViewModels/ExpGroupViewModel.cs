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
    internal class ExpGroupViewModel : BaseViewModel
    {
        private ExpGroup _expGroup = new ExpGroup();
        private ExpGroupDataAccessLayer _expGroupData;
        public ExpGroupViewModel()
        {
            _expGroupData = new ExpGroupDataAccessLayer();
            RefreshExpGroups();
            using (var context = new Projekt01_HermaContext())
            {
                AllExpGroups = new ObservableCollection<ExpGroup>(context.ExpGroups.ToList());
            }
            AddExpGroupClick = new RelayCommand(x => DisplayAddMessage(), x => this.IsValid);
            UpdateExpGroupClick = new RelayCommand(x => DisplayUpdateMessage(), x => this.IsValid);
            RemoveExpGroupClick = new RelayCommand(x => DisplayRemoveMessage(), x => this.IsValid);
        }

        private void DisplayRemoveMessage()
        {
            using (var context = new Projekt01_HermaContext())
            {
                var expGroupToRemove = context.ExpGroups.Where(x => x.GroupId == _expGroup.GroupId).FirstOrDefault();
                context.ExpGroups.Remove(expGroupToRemove);
                context.SaveChanges();
                RefreshExpGroups();
                AllExpGroups = new ObservableCollection<ExpGroup>(context.ExpGroups.ToList());
            }
            MessageBox.Show("Usunięto grupe wydatkow");
        }

        private void DisplayUpdateMessage()
        {
            using (var context = new Projekt01_HermaContext())
            {
                var expGroupToUpdate = context.ExpGroups.Where(x => x.GroupId == _expGroup.GroupId).FirstOrDefault();
                expGroupToUpdate.GroupName = GroupName;
                context.ExpGroups.Update(expGroupToUpdate);
                context.SaveChanges();
                RefreshExpGroups();
                AllExpGroups = new ObservableCollection<ExpGroup>(context.ExpGroups.ToList());
            }
            MessageBox.Show("Zaktualizowano grupe wydatkow");
        }

        private void DisplayAddMessage()
        {
            using (var context = new Projekt01_HermaContext())
            {
                context.ExpGroups.Add(new ExpGroup { GroupId = GroupID, GroupName = GroupName });
                context.SaveChanges();
                RefreshExpGroups();
                AllExpGroups = new ObservableCollection<ExpGroup>(context.ExpGroups.ToList());
            }
            MessageBox.Show("Dodano grupe wydatkow");
        }

        private ObservableCollection<ExpGroup> _allExpGroups;
        public ObservableCollection<ExpGroup> AllExpGroups
        {
            get { return _allExpGroups; }
            set 
            { 
                _allExpGroups = value;
                OnProperyChanged(nameof(AllExpGroups));
            }
        }
        public int GroupID
        {
            get { return _expGroup.GroupId; }
            set
            {
                if ( value != _expGroup.GroupId)
                {
                    _expGroup.GroupId = value;
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

        public void RefreshExpGroups()
        {
            var obj = new ObservableCollection<ExpGroup>((IEnumerable<ExpGroup>)_expGroupData.GetAllExpGroups());
            AllExpGroups = obj;
        }
        public ICommand AddExpGroupClick { get; set; }
        public ICommand UpdateExpGroupClick { get; set; }
        public ICommand RemoveExpGroupClick { get; set; }
        public bool IsValid { get => GroupID > 0 || !string.IsNullOrEmpty(GroupName); }
    }
}
