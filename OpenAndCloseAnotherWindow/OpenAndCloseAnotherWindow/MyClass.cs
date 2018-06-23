using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OpenAndCloseAnotherWindow
{
    public static class MyClass
    {
        /// <summary>
        /// Open window method (Extension Method)
        /// </summary>
        /// <param name="window">subject window</param>
        public static void OpenWindow(this Window window)
        {
            window.Show();
        }


        /// <summary>
        /// Close window method (Extension Method)
        /// </summary>
        /// <param name="window">subject window</param>
        /// <param name="sender">sender window (default value is null, can call as class)</param>
        public static void CloseWindow(this Window window)
        {
            foreach (Window win in Application.Current.Windows)
            {
                if (!Equals(win, window))
                {
                    win.Close();
                }
            }
        }

        /// <summary>
        /// Close window as title method (Extension Method)
        /// </summary>
        /// <param name="windowTitle">subject window title</param>
        public static void CloseWindow(this string windowTitle)
        {
            foreach (Window win in Application.Current.Windows)
            {
                if (Equals(win.Title, windowTitle))
                {
                    win.Close();
                }
            }
        }
    }
}
