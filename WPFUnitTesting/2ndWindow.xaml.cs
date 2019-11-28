using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFUnitTesting
{
    /// <summary>
    /// Interaction logic for _2ndWindow.xaml
    /// </summary>
    public partial class _2ndWindow : UserControl
    {
        public _2ndWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Content = new _3rdWindow()
            };

            window.ShowDialog();
        }
    }
}
