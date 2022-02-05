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

namespace Vector_Calculator
{
    /// <summary>
    /// Interaction logic for PopUp.xaml
    /// </summary>
    /// 
    public partial class PopUp : Window
    {
        public string username = "";
        public PopUp()
        {
            InitializeComponent();
            ButtonEnter.Click += ButtonEnter_Click;
            KeyDown += new KeyEventHandler(ManageWindow_KeyDown);
            txtBox.Focus();
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            Enter();
        }

        private void ManageWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Enter();
            }
        }

        private void Enter()
        {
            username = txtBox.Text;
            Close();
        }
    }

}
