using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

/*
 *	Use the Windows API functions EnumWindows and GetWindowThreadProcessId to list all of the Window processes on your desktop.

		Hint:  To get the address of a method (the first argument to EnumWindows), you’ll need to define a delegate with the appropriate signature.  
		If you are writing in Visual Basic, you will also need to use the Address Of operator.

		Hint:  Once you have the process id, use Process.GetProcessById to retrieve the needed process information.

		As for the ListProcesses exercise, write the application to output each unique window/process name and the number of instances running.  
		Order the output by the # running processes, descending.
*/

namespace ListDesktopWindowProcesses
{
    /*class Program
	{
		static void Main(string[] args)
		{
            Process[] processes = Process.GetProcessById();
            Array.Sort(processes, delegate (Process p1, Process p2)
            {
                return string.Compare(p1.ProcessName, p2.ProcessName, StringComparison.Ordinal);
            }
            foreach (Process process in processes)
            {
                Console.WriteLine(process.ProcessName);
            }
            Console.ReadLine();

        }
	}*/

    class Program
    {
        static List<int> handles = new List<int>();
        public delegate bool CallBackPtr(int hwnd, int lParam);

        [DllImport("user32.dll")]
        public static extern int EnumWindows(CallBackPtr callPtr, int lPar);
        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int ProcessId);

        private static bool ProcIntId(int hwnd, int lParam)
        {
            handles.Add(hwnd);
            return true;
        }

        private static void Main(string[] args)
        {
            CallBackPtr point = new CallBackPtr(ProcIntId);
            EnumWindows(point, 0);
            //GetWindowThreadProcessId(point, 0);
            //Console.WriteLine(handles.Count);
            WindowsIds();
        }

        private static void WindowsIds()
        {
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();

            foreach (int i in handles)
            {
                IntPtr p = new IntPtr(i);
                GetWindowThreadProcessId(p, out int processId);
                string proc = Process.GetProcessById(processId).ProcessName;
                int track = 1;

                if (!myDictionary.ContainsKey(proc))
                {
                    myDictionary.Add(proc, track);
                }
                else
                {
                    myDictionary[proc]++;
                }
            }

            foreach (KeyValuePair<string, int> kvp in myDictionary.OrderByDescending(k => k.Value))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}