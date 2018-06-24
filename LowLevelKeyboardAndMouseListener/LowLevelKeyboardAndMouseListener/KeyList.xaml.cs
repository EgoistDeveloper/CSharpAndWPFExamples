using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace LowLevelKeyboardAndMouseListener
{
    /// <summary>
    /// Interaction logic for KeyList.xaml
    /// </summary>
    public partial class KeyList : Window
    {
        public KeyList()
        {
            InitializeComponent();

            KeyListListView.ItemsSource = Enum.GetValues(typeof(Key))
                .Cast<Key>()
                .Select(v => v.ToString())
                .ToList();
        }
    }
}
