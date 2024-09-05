using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Process[] processes = Process.GetProcesses();

        foreach (Process process in processes)
        {
            Console.Write("Имя: " + process.ProcessName + ", ID: " + process.Id + ", RAM: " + process.PagedMemorySize64 / 8 / 1024 / 1024 + "MB ");
            if (process.ProcessName.Length == 0)
                Console.WriteLine("Status: Stopped");
            else
                Console.WriteLine("Status: Running");

        }
        int ProcessIDin = Convert.ToInt32(Console.ReadLine());
        Process ProcessId = Process.GetProcessById(ProcessIDin);
            ProcessId.Kill();

    }
}

