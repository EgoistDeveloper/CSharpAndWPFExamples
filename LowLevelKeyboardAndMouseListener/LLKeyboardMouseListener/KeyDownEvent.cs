using System;
using System.Windows.Input;

namespace LLKeyboardMouseListener
{
    public class KeyDownEventArgs : EventArgs
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="key"></param>
        public KeyDownEventArgs(Key key)
        {
            Key = key;
        }

        /// <summary>
        /// Pressed key
        /// </summary>
        public Key Key { get; }
    }
}
