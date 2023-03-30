using BankSystemLibrary.BankSystem.Documents.AccountTransaction;
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

namespace BankSystemWpfControlLibrary
{
    /// <summary>
    /// Логика взаимодействия для HistoryOperationWindows.xaml
    /// </summary>
    public partial class HistoryOperationWindows : Window
    {
        AccountTransactionHistory History { get; set; }
        public HistoryOperationWindows(AccountTransactionHistory history)
        {
            InitializeComponent();
            History = history;
            
            ListBoxDataHistory.ItemsSource = History.History;
        }
    }
}
