﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_Education.Classes.Extensions
{
    public class AutoClosingMessageBox
    {
        System.Threading.Timer _timeoutTimer;
        string _caption;
        const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        public AutoClosingMessageBox(string caption, string title, int timeout,MessageBoxIcon icon)
        {
            _caption = caption;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
            using (_timeoutTimer)
                MessageBox.Show(caption, title, MessageBoxButtons.OK, icon);
        }
        public static void Show(string caption, string title, int timeout, MessageBoxIcon icon)
        {
            new AutoClosingMessageBox(caption, title, timeout, icon);
        }
        void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
            if (mbWnd != IntPtr.Zero)
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            _timeoutTimer.Dispose();
        }
      
    }
}
