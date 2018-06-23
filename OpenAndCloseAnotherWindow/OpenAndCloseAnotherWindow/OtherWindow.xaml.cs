using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OpenAndCloseAnotherWindow
{
    /// <summary>
    /// Interaction logic for OrherWindow.xaml
    /// </summary>
    public partial class OtherWindow : Window
    {
        public OtherWindow()
        {
            InitializeComponent();
        }

        // get another window as readonly global variable
        private AnotherWindow _anWin = new AnotherWindow();


        /// <summary>
        /// Open and close window with custom class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleButtonStatic2_OnClick(object sender, RoutedEventArgs e)
        {
            // get this toggle button from sender
            var tgb = (ToggleButton)sender;

            if (tgb == null)
                return;

            // IsChecked can be null
            if (tgb.IsChecked == true)
            {
                // prevent visiblity error
                _anWin = new AnotherWindow();

                // call from MyClass
                _anWin.OpenWindow();
            }
            else
            {
                _anWin.CloseWindow();
                tgb.Content = "Open Another Window With Toggle Button";
            }
        }

    }
}
