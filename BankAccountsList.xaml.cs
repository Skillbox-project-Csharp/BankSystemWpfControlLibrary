using System;
using System.Collections.Generic;
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

namespace BankSystemWpfControlLibrary
{
    /// <summary>
    /// Логика взаимодействия для BankAccountsList.xaml
    /// </summary>
    public partial class BankAccountsList : UserControl
    {
        public ListBox ListBoxClientBankAccounts { get; set; }
        public BankAccountsList()
        {
            InitializeComponent();
            ListBoxClientBankAccounts = listBoxClientBankAccounts;
        }
    }
}
