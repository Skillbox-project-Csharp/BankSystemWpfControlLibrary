using BankSystemLibrary.BankSystem.BankAccounts;
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
using System.Windows.Shapes;

namespace BankSystemWpfControlLibrary.SelectionWindows
{

    /// <summary>
    /// Логика взаимодействия для OpenAccountWindow.xaml
    /// </summary>
    public partial class BankAccountSelectionWindow : Window
    {
        public BankAccount GetBankAccount
        {
            get
            {
                switch (TypesBankAccounts.SelectedIndex)
                {
                    case 0: return new BankAccount();
                    case 1: return new NoDepositAccount();
                    case 2: return new DepositAccount();
                    default: return null;
                }

            }
        }
        public BankAccountSelectionWindow()
        {
            InitializeComponent();
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
