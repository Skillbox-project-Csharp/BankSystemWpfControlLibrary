using BankSystemLibrary.BankSystem.Documents.AccountTransaction;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BankSystemWpfControlLibrary.SelectionWindows
{
    /// <summary>
    /// Логика взаимодействия для TransactionDisplayWindows.xaml
    /// </summary>
    public partial class TransactionDisplayWindows : Window
    {
        public TransactionDisplayWindows(AccountTransaction accountTransaction)
        {
            InitializeComponent();
            var primaryMonitorArea = SystemParameters.WorkArea;
            Left = primaryMonitorArea.Right - Width - 10;
            Top = primaryMonitorArea.Bottom - Height - 10;
            TexBlockTransactionInfo.Text = accountTransaction.AccountTransactionInfo;
            TexBlockStatusTransaction.Text = accountTransaction.IsCompleted.ToString();
            StartCloseTimer();
        }

        private void StartCloseTimer()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(10d)
            };
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            Close();
        }
    }
}
