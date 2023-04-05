﻿using BankSystemLibrary.BankSystem;
using BankSystemLibrary.BankSystem.BankAccounts;
using BankSystemLibrary.BankSystem.BankWorkers;
using BankSystemLibrary.BankWorkers;
using BankSystemWpfControlLibrary.SelectionWindows;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для MenuOfAccountOperations.xaml
    /// </summary>
    public partial class MenuOfAccountOperations : UserControl
    {
        public Worker Employee { get; set; }
        public Client SelectedClient { get; set; }
        public BankAccount SelectedBankAccount { get; set; }
        public MenuOfAccountOperations()
        {
            InitializeComponent();
        }
        public void BankClientSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var client in e.AddedItems)
                if (client is Client selectedClient)
                    SelectedClient = selectedClient;
        }
        public void BankAccountSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var bankAccount in e.AddedItems)
                if (bankAccount is BankAccount selectedBankAccount)
                    SelectedBankAccount = selectedBankAccount;
        }

        private void ButtonOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            if (Employee != null && SelectedClient != null)
            {
                BankAccountSelectionWindow bankAccountSelectionWindow = new BankAccountSelectionWindow();
                if (bankAccountSelectionWindow.ShowDialog() == true)
                {
                    BankAccount bankAccount = bankAccountSelectionWindow.GetBankAccount;
                    Employee.OpenNewBankAccount(SelectedClient, bankAccount);
                }
            }
        }

        private void ButtonCloseAccount_Click(object sender, RoutedEventArgs e)
        {
            if (Employee != null && SelectedBankAccount != null && SelectedClient != null)
            {
                Employee.CloseBankAccount(SelectedClient, SelectedBankAccount);
            }
        }

        private void ButtonReplenishmentAccount_Click(object sender, RoutedEventArgs e)
        {
            if (Employee != null && SelectedClient!= null && SelectedBankAccount != null)
            {
                ReplenishmentWindow replenishmentWindow = new ReplenishmentWindow("Пополнить счет на");
                if (replenishmentWindow.ShowDialog() == true)
                {
                    try
                    {
                        Employee.ReplenishmentByTypeAccount
                            (
                            SelectedClient,
                            SelectedBankAccount.TypeAccount,
                            replenishmentWindow.AmountAddMoney
                            );
                    }
                    catch (AccessRightsException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
