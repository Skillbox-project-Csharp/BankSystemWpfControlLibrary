using BankSystemWpfControlLibrary.SelectionWindows;
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

namespace BankSystemWpfControlLibrary.SelectionWindows
{
    /// <summary>
    /// Логика взаимодействия для ReplenishmentAccount.xaml
    /// </summary>
    public partial class ReplenishmentAccount : Window
    {
        private double _amount = 0;
        public double AmountAddMoney
        {
            get
            {
                return _amount;
            }
            private set { _amount = value; }
        }

        public ReplenishmentAccount(string labelText)
        {
            InitializeComponent();
            AmountAddMoney = 0;
            TopInfoText.Text = labelText;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(InputAmountMoney.Text, out double amount))
            {
                AmountAddMoney = amount;
                this.DialogResult = true;
            }
        }
    }
}
