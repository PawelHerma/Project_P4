using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Project_P4.Commands;
using Project_P4.DataAccesLayers;
using Project_P4.DbModels;

namespace Project_P4.ViewModels
{
    internal class IncomeViewModel : BaseViewModel
    {
        private Income _income = new Income();
        private IncomeDataAccessLayer _incomeData;
        public IncomeViewModel()
        {
            _incomeData = new IncomeDataAccessLayer();
            RefreshIncomes();
            using (var context = new Projekt01_HermaContext())
            {
                AllIncomes = new ObservableCollection<Income>(context.Incomes.ToList());
            }
            AddIncomeClick = new RelayCommand(x => DisplayAddMessage(), x => this.IsValid);
            UpdateIncomeClick = new RelayCommand(x => DisplayUpdateMessage(), x => this.IsValid);
            RemoveIncomeClick = new RelayCommand(x => DisplayRemoveMessage(), x => this.IsValid);

        }

        private void DisplayRemoveMessage()
        {
            using (var context = new Projekt01_HermaContext())
            {
                var incomeToUpdate = context.Incomes.Where(x => x.MemberId == _income.MemberId && x.IncomeDate == _income.IncomeDate && x.IncomeCost == _income.IncomeCost).FirstOrDefault();
                context.Incomes.Remove(incomeToUpdate);
                context.SaveChanges();
                RefreshIncomes();
                AllIncomes = new ObservableCollection<Income>(context.Incomes.ToList());
            }
            MessageBox.Show("Usunieto przychod");
        }

        private void DisplayUpdateMessage()
        {
            using (var context = new Projekt01_HermaContext())
            {
                var incomeToUpdate = context.Incomes.Where(x => x.MemberId == _income.MemberId && x.IncomeDate == _income.IncomeDate).FirstOrDefault();
                incomeToUpdate.IncomeCost = _income.IncomeCost;
                context.Incomes.Update(incomeToUpdate);
                context.SaveChanges();
                RefreshIncomes();
                AllIncomes = new ObservableCollection<Income>(context.Incomes.ToList());
            }
            MessageBox.Show("Zaktualizowano koszt przychodu");
        }

        private void DisplayAddMessage()
        {
            using (var context = new Projekt01_HermaContext())
            {
                context.Incomes.Add(new Income { MemberId = MemberID, IncomeDate = IncomeDate, IncomeCost = IncomeCost  });
                context.SaveChanges();
                RefreshIncomes();
                AllIncomes = new ObservableCollection<Income>(context.Incomes.ToList());
            }
            MessageBox.Show("Dodano przychod");
        }

        public ICommand AddIncomeClick { get; set; }
        public ICommand UpdateIncomeClick { get; set; }
        public ICommand RemoveIncomeClick { get; set; }
        private ObservableCollection<Income> _allIncomes;
        public ObservableCollection<Income> AllIncomes
        {
            get { return _allIncomes; }
            set
            {
                _allIncomes = value;
                OnProperyChanged(nameof(AllIncomes));
            }
        }

        private void RefreshIncomes()
        {
            var obj = new ObservableCollection<Income>((IEnumerable<Income>)_incomeData.GetAllIncomes());
            AllIncomes = obj;
        }

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

        public bool IsValid { get => MemberID > 0; }
    }
}
