using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using LLKeyboardMouseListener;

namespace LowLevelKeyboardAndMouseListener
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // keyboard listener
            _keyboardListener = new KeyboardListener();
            // add event handler
            _keyboardListener.KeyDown += KeyboardListener_KeyDown;
            // install hook
            _keyboardListener.InstallHook();
        }

        /// <summary>
        /// Define Keyboard Listener
        /// </summary>
        private readonly KeyboardListener _keyboardListener;

        /// <summary>
        /// Keyboard key down event
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">listener custom keydown event args</param>
        private void KeyboardListener_KeyDown(object sender, KeyDownEventArgs e)
        {
            PressedKeys.Items.Add($"Key: {e.Key.ToString()}");

            if (e.Key == Key.Enter)
            {
                PressedKeys.Items.Add($"You Pressed Enter");
            }
        }

        /// <summary>
        /// Open key list included window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeeKeyList_onClick(object sender, RoutedEventArgs e)
        {
            var keyList = new KeyList();
            keyList.Show();
        }

        /// <summary>
        /// Uninstall on closing window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            _keyboardListener.UninstallHook();
        }
    }
}
