using System.Windows;
using System.Windows.Controls;
using BankSystemLibrary.BankWorkers;
using BankSystemLibrary;

namespace BankSystemWpfControlLibrary.SelectionWindows
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class EmployeeSelectionWindow : Window
    {
        public EmployeeSelectionWindow()
        {
            InitializeComponent();
        }

        public Worker GetWorker
        {
            get
            {
                switch (TypesWorker.SelectedIndex)
                {
                    case 0: return new Manager(InputName.Text, InputSurName.Text, InputPatronymic.Text);
                    case 1: return new Consultant(InputName.Text, InputSurName.Text, InputPatronymic.Text);
                    default: return null;
                }

            }
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
