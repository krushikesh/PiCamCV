﻿using System;
using System.Threading.Tasks;
using Common.Logging;

namespace PiCamCV.ConsoleApp
{
    public class ConsoleKeyEventArgs : EventArgs
    {
        public ConsoleKeyInfo KeyInfo { get; set; }

        public ConsoleKeyEventArgs(ConsoleKeyInfo keyInfo)
        {
            KeyInfo = keyInfo;
        }
    }

    public class KeyHandler
    {
        protected static ILog Log = LogManager.GetCurrentClassLogger();

        public event EventHandler<ConsoleKeyEventArgs> KeyEvent;
    
        public async Task WaitForExit()
        {
            bool exit = false;
            do
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Q:
                        exit = true;
                        break;
                    case ConsoleKey.T:
                        if (KeyEvent != null)
                        {
                            KeyEvent(this, new ConsoleKeyEventArgs(key));
                        }
                        break;
                }
            }
            while (!exit);

            Log.Info(m => m("Q pressed, exiting"));
        }
    }
}