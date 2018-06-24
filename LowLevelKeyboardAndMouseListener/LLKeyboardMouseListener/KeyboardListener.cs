using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace LLKeyboardMouseListener
{
    public class KeyboardListener
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public KeyboardListener()
        {
            _proc = CallBackHooking;
        }

        /// <summary>
        /// Keydown event
        /// </summary>
        public event EventHandler<KeyDownEventArgs> KeyDown;

        #region WinAPI Implements

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;

        private LowLevelKeyboardProc _proc;
        private IntPtr hookId = IntPtr.Zero;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int hookId, LowLevelKeyboardProc hookProc, IntPtr parmIntPtr, uint procId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hook, int code, IntPtr paramIntPtr, IntPtr paramIntPtr2);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string moduleName);

        public delegate IntPtr LowLevelKeyboardProc(int code, IntPtr paramIntPtr, IntPtr paramIntPtr2);

        private IntPtr Hooking(LowLevelKeyboardProc proc)
        {
            using (var currentProcess = Process.GetCurrentProcess())
            using (var currentModule = currentProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(currentModule.ModuleName), 0);
            }
        }

        private IntPtr CallBackHooking(int code, IntPtr paramIntPtr, IntPtr paramIntPtr2)
        {
            if ((code < 0 || paramIntPtr != (IntPtr)WM_KEYDOWN) && paramIntPtr != (IntPtr)WM_SYSKEYDOWN)
                return CallNextHookEx(hookId, code, paramIntPtr, paramIntPtr2);
            var virtualKeyCode = Marshal.ReadInt32(paramIntPtr2);

            KeyDown?.Invoke(this, new KeyDownEventArgs(KeyInterop.KeyFromVirtualKey(virtualKeyCode)));

            return CallNextHookEx(hookId, code, paramIntPtr, paramIntPtr2);
        }

        #endregion


        #region Pulic Methods

        public void InstallHook()
        {
            hookId = Hooking(_proc);
        }

        public void UninstallHook()
        {
            UnhookWindowsHookEx(hookId);
        }

        #endregion
    }
}
