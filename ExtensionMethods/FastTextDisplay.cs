using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankSystemWpfControlLibrary.ExtensionMethods
{
    public static class FastTextDisplay
    {
        public static void ShowMessage(this string message)
        {
            MessageBox.Show(message);
        }
    }
}
