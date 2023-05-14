using BankSystemLibrary.BankSystem;
using BankSystemLibrary.BankSystem.BankAccounts;
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
using System.Windows.Shapes;

namespace BankSystemWpfControlLibrary.SelectionWindows
{
    /// <summary>
    /// Логика взаимодействия для RecipientSelectionWindow.xaml
    /// </summary>
    public partial class RecipientSelectionWindow : Window
    {
        public Client SelectedRecipient { get; set; }
        public BankAccount SelectedAccountRecipient { get; set; }
        public RecipientSelectionWindow(Client senderClient,ObservableCollection<Client> clients)
        {
            InitializeComponent();
            ObservableCollection<Client> filterClients = new ObservableCollection<Client>(clients);
            filterClients.Remove(senderClient);
            bankClientList.ListBoxDataClients.ItemsSource = filterClients;
            bankClientList.ListBoxDataClients.SelectionChanged += ListBoxDataClients_SelectionChanged;
            bankAccountsList.ListBoxClientBankAccounts.SelectionChanged += ListBoxClientBankAccounts_SelectionChanged;
        }

        private void ListBoxClientBankAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var bankAccount in e.AddedItems)
                if (bankAccount is BankAccount selectedBankAccount)
                    SelectedAccountRecipient = selectedBankAccount;
        }

        private void ListBoxDataClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var client in e.AddedItems)
                if (client is Client selectedClient)
                {
                    SelectedRecipient = selectedClient;
                    bankAccountsList.ListBoxClientBankAccounts.ItemsSource = SelectedRecipient.BankAccounts;
                }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedRecipient != null && SelectedAccountRecipient != null)
                this.DialogResult = true;
        }
    }
}
