using Enigma.View;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Enigma.Launcher
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Write something technic inside the console");
            ConsoleManager.Close();
            Application app = new Application();
            //app.ShutdownMode = ShutdownMode.OnLastWindowClose;
            app.Run(new MainWindow());
        }
    }
}
