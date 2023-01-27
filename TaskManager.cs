using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace App8
{
    class Program
    {

        public static Process[] tasks = Process.GetProcesses();

        static void Help()
        {
            Console.WriteLine("\n\nexit --- закончить выполнение программы ");
            Console.WriteLine("PrintList --- вывести список все процессов ");
            Console.WriteLine("FindElemId --- определить Id процесса по его названию ");
            Console.WriteLine("KillById --- прекрарить процесс по Id");
            Console.WriteLine("KillByName --- прекратить процесс по имени\n\n");
        }

        static void KillById()
        {
            Console.WriteLine("Введите айди процесса, который хотите прекратить: ");
            
            int idd = int.Parse(Console.ReadLine());

            for (int i = 0; i < tasks.Length; i++){
                if (tasks[i].Id == idd) tasks[i].Kill();
            }
        }

        static void KillByName()
        {
            Console.WriteLine("Введите название процесса, который хотите прекратить: ");           
            
            string name = Console.ReadLine();

            name = name.ToLower();

            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i].ProcessName.ToLower() == name) tasks[i].Kill();
            }
        }
        
        static void PrintList()
        {
            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine($"{tasks[i].ProcessName,-40} {tasks[i].Id}");
            }
        }

        

        static void FindElemId()
        {
            Console.WriteLine("Введите название процесса, айди которого хотите прекратить: ");
            
            string name = Console.ReadLine();
            int idd;

            name = name.ToLower();

            if (name == "") return;

            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i].ProcessName.ToLower().Contains(name) == true)
                {
                    idd = tasks[i].Id;
                    Console.WriteLine("Айди " + tasks[i].ProcessName + " --- " + idd);
                }
            }

        }

        static void Main(string[] args)
        {
            /*var tasks = Process.GetProcesses();
            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine($"{tasks[i].ProcessName, -40} {tasks[i].Id}");
                if (tasks[i].ProcessName == "notepad") tasks[i].Kill();
            }
            string s = "KOLOKOL";
            s = s.ToLower();
            s = s.ToUpper();
            var t = s.Split("O");
            s.StartsWith("K");
            int v = s.IndexOf("ko");
            Console.WriteLine("Какую операцию хотите выполнить?");
            Console.WriteLine("**help --- просмотреть список доступных команд**");*/

            Boolean begin = true;
            string moveTo;


            while (begin)
            {
                Console.Write("Какую операцию вы хотите выполнить?\nВведите help для просмотра всех доступных операций --- ");

                moveTo = Console.ReadLine();

                moveTo = moveTo.ToLower();

                switch (moveTo)
                {
                    case "exit":
                        begin = false;
                        break;

                    case "help":
                        Help();
                        break;

                    case "printlist":
                        PrintList();
                        break;
                    
                    case "killbyid":
                        KillById();
                        break;
                    
                    case "killbyname":
                        KillByName();
                        break;
                    
                    case "findelemid":
                        FindElemId();
                        break;

                    default:
                        begin = false;
                        break;
                }
            }

        }

       
    }
}