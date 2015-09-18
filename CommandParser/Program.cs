using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commands = prepareArraysCommandsFromArgs(args);
            bool exit = false;
            string output = interpret(commands, out exit);
            Console.WriteLine(output);
            
            while (!exit)
            {
                string line = Console.ReadLine();
                commands = line.Split(new Char[] { '/', '-' }, StringSplitOptions.RemoveEmptyEntries);
                output = interpret(commands, out exit);
                Console.WriteLine(output);
            }

            Console.WriteLine("Press any  key to exit ...");
            Console.ReadKey();
        }

        private static string interpret(string[] commands, out bool exit)
        {
            exit = false;
            string result = "";
            if (commands.Length == 0) result += "CommandParser.exe [/?] [/help] [-help] [-k key value] [-ping] [-print <print a value>] \n";
            for (int i = 0; i < commands.Length; i++)
            {
                string[] c = commands[i].Split(' ');
                if (c[0] != "")
                {
                    switch (c[0])
                    {
                        case "?":
                        case "help":
                            if (i==0)
                            result += "CommandParser.exe [/?] [/help] [-help] [-k key value] [-ping] [-print <print a value>] \n";
                            break;
                        case "ping":
                            result += "Pinging ... \n";
                            break;
                        case "exit":
                             exit = true;
                            break;
                        case "print":
                            if (c.Length > 1)
                            {
                                string message = String.Empty ;
                                for (int k = 1; k < c.Length; k++)
                                {
                                    message += String.Format("{0} ", c[k]); 
                                }
                                result += String.Format("Printing message {0} \n", message);
                            }
                            else
                                result += "Message can't be empty \n";
                            break;
                        case "k":
                                for (int l = 1; l < c.Length; l+=2)
                                {
                                    string key = c[l];
                                    string value = (l+1<c.Length)?c[l+1]:"null";
                                        result += String.Format("key {0} - value {1} \n", key, value);
                                 }
                            break;
                            default:
                              result += String.Format("Command <{0}> is not supported, use CommandParser.exe /? to see set of allowed commands \n", c[0]);
                            break;
                    }
                }
            }
          return result;
        }

        //приводим массив задданых аргументов в массив, в котором каждый элемент содержит одну комманду.

        private static string[] prepareArraysCommandsFromArgs(string[] args)
        {
            string result = string.Join(" ", args);
            return result.Split(new Char[] { '/', '-' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
