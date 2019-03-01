using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace AppStarter
{
	class Program
	{
		// Write a Console application that starts another application, optionally passing arguments to it.

		// Your Console application will require that at least one argument is passed to it - the path to the executable that it will start.
		// If additional arguments are passed to your console application, those will be passed as a group to the executable that is being started.

		// Running your program like this:
		// AppStarter "c:\windows\system32\notepad.exe" "c:\Users\Joseph\Documents\Jabberwocky.txt" /A
		// Would cause notepad to run with Jabberwocky.txt opened as ANSI.
	
		static int Main(string[] args)
		{

            if (args.Length > 1)
            {
                String builder = "";
                int length = args.Length;

                for (int i = 1; i < args.Length; i++)
                {
                    builder = String.Join(" ", args, 1, args.Length - 1);
                }

                Process.Start(args[0], builder);
                //Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "www.google.com");
                return -1;
            }
            try
            {
                Process.Start(args[0]);
                return 0;
            }
            catch(Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            return -1;
		}
	}
}