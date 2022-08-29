using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Project_P4.Models;
using Project_P4.ViewModels;

namespace Project_P4.Views
{
    /// <summary>
    /// Logika interakcji dla klasy MemberView.xaml
    /// </summary>
    public partial class MemberView : UserControl
    {
        public MemberView()
        {
            InitializeComponent();
            DataContext = new MemberViewModel();
        }
    }
}
