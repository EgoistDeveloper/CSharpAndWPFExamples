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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenAndCloseAnotherWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*/// <summary>
        /// Basic open, hide, close window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonX_OnClick(object sender, RoutedEventArgs e)
        {
            var anWin = new AnotherWindow();

            anWin.Show();
            anWin.Hide();
            anWin.Close();
        }*/


        // get another window as readonly global variable
        private AnotherWindow _anWin = new AnotherWindow();

        /// <summary>
        /// Open and close window with toggle button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleButtonStatic_OnClick(object sender, RoutedEventArgs e)
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

                _anWin.Show();
                tgb.Content = "Close Another Window With Toggle Button";
            }
            else
            {
                _anWin.Close();
                tgb.Content = "Open Another Window With Toggle Button";
            }
        }

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

        /// <summary>
        /// Open other window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            var otWin = new OtherWindow();
            otWin.Show();
        }

        private void ToggleButtonDynamic_OnClick(object sender, RoutedEventArgs e)
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
                _anWin.Title.CloseWindow();
                tgb.Content = "Open Another Window With Toggle Button";
            }
        }

        /// <summary>
        /// Close all another windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            _anWin.Title.CloseWindow();
        }
    }
}
