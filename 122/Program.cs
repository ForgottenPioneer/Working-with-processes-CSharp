using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Process[] processes = Process.GetProcesses();
        bool forwhile = true;
        while (forwhile)
        {
            Console.WriteLine("Какое действие вы хотите выполнить?\n1. Завершить процесс.\n2. Запустить процесс\n3. Вывести все процессы.\n4. Выйти из программы.");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    {
                        PrintAllProcesses(processes);
                        Console.WriteLine("Какой из процессов вы хотите завершить(Ввести ID программы)?");
                        int a = Convert.ToInt32(Console.ReadLine());
                        KillProcess(a);
                    }
                    continue;
                case "2":
                    {
                        Console.WriteLine("Введите название программы для запуска.");
                        string b = Console.ReadLine();
                        StartProgram(b);
                    }
                    continue;
                case "3":
                    {
                        PrintAllProcesses(processes);
                    }
                    continue;
                    case "4":
                    {
                        Console.WriteLine("ББ");
                        forwhile = false;
                        break;
                    }
                default:
                    Console.WriteLine("Invalid choice. Choose num of case.");
                    break;
            }
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

