using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ListProcesses
{
	class Program
	{
		/*
		 * Write a Console application that lists the names of all active processes.
		 * 
		 * You may notice that many processes occur numerous times.
		 * 
		 * Modify the application to output each unique process name and the number of instances running.  Order the output by the # running processes, descending.
		*/

		static void Main(string[] args)
		{
            Process[] processList = Process.GetProcesses();
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            foreach (Process a in processList)
            {
                string holder = a.ProcessName;
                if (!myDictionary.ContainsKey(holder))
                {
                    myDictionary.Add(holder, 1);
                }
                else
                {
                    myDictionary[holder]++;
                }
            }

            foreach (string key in myDictionary.Keys)
            {
                Console.WriteLine($"{key}: {myDictionary[key]}");
            }
        }
	}
}
