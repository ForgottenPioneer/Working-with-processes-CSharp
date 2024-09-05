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
        static void KillProcess(int id)
        {
            Process processForKill = Process.GetProcessById(id);

            processForKill.Kill();

            Logger.Logging("Процесс убит.");
        }

        static void StartProgram(string programName)
        {
            Process.Start(programName);

            Logger.Logging("Процесс запущен.");
        }

        static void PrintAllProcesses(Process[] processes)
        {
            foreach (Process process in processes)
            {
                Console.WriteLine($"Name: {process.ProcessName}  ID: {process.Id}  memory footprint: {process.PagedMemorySize64 / 1024 / 1024} MB status: {process.Responding}");

                Logger.Logging("Выведены все запущенные процессы.");
            }
        }
    }

    class Logger
    {
        public static void Logging(string message)
        {
            string logPath = "process_log.txt";

            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine($"{DateTime.Now} {message}");
            }
        }
    }
}

