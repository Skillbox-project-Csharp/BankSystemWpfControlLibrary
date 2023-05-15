using BankSystemLibrary.BankSystem;
using BankSystemLibrary.BankSystem.Documents.AccountTransaction;
using BankSystemLibrary.BankWorkers;
using BankSystemWpfControlLibrary.SelectionWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    /// Логика взаимодействия для CustomerAccountManagementWindow.xaml
    /// </summary>
    public partial class CustomerAccountManagementMenu : UserControl
    {
        private Worker _employee;
        private ObservableCollection<Client> _bankClients;
        public Worker Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                menuOfAccountOperations.Employee = _employee;
                if (_employee != null)
                {
                    _employee.MoneyTransferEvent += HistoryOperations.MoneyTransferTransactionDo;
                    _employee.OpenCloseBankAccountEvent += HistoryOperations.OpenCloseBankAccountTransactionDo;
                    _employee.ReplenishmentAccountEvent += HistoryOperations.ReplenishmentAccountTransactionDo;
                }
            }
        }
        public static AccountTransactionHistory HistoryOperations { get; set; } = new AccountTransactionHistory();
        public ObservableCollection<Client> BankClients
        {
            get
            {
                return _bankClients;
            }
            set
            {
                _bankClients = value;
                bankClientList.ListBoxDataClients.ItemsSource = _bankClients;
                menuOfAccountOperations.Clients = _bankClients;
            }
        }

        public CustomerAccountManagementMenu()
        {
            InitializeComponent();
            bankClientList.ListBoxDataClients.SelectionChanged += ListBoxDataClients_SelectionChanged;
            bankClientList.ListBoxDataClients.SelectionChanged += menuOfAccountOperations.BankClientSelectionChanged;
            bankAccountsList.ListBoxClientBankAccounts.SelectionChanged += menuOfAccountOperations.BankAccountSelectionChanged;
            HistoryOperations.TransactionCompleted += OpenTransactionDispalay;
        }
        private void ListBoxDataClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var obj in e.AddedItems)
                if (obj is Client client)
                    bankAccountsList.ListBoxClientBankAccounts.ItemsSource = client.BankAccounts;
        }
        private void OpenTransactionDispalay(AccountTransaction accountTransaction)
        {
            TransactionDisplayWindows historyOperationWindows = new TransactionDisplayWindows(accountTransaction);
            historyOperationWindows.Show();
        }
    }
}
