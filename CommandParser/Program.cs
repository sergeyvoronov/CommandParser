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
            string[] commands = prepareArraysCommands(args);
            string output = interpret(commands);
            Console.WriteLine(output);
            Console.ReadKey();
        }

        private static string interpret(string[] commands)
        {
            string result = "";
            if (commands.Length == 0) result += String.Format("CommandParser.exe [/?] [/help] [-help] [-k key value] [-ping] [-print <print a value>] \n");
            foreach (string command in commands)
            {
                string[] c = command.Split(' ');
                if (c[0] != "")
                {
                    switch (c[0])
                    {
                        case "help":
                            result += String.Format("CommandParser.exe [/?] [/help] [-help] [-k key value] [-ping] [-print <print a value>] \n");
                            break;
                        case "ping":
                            result += String.Format("Pinging ... \n");
                            break;
                        case "print":
                            if (c[1] != null)
                                result += String.Format("Printing message {0} \n", c[1]);
                            else
                                result += String.Format("Message can't be empty \n");
                            break;
                        case "k":
                                for (int i = 1; i < c.Length; i+=2)
                                {
                                    string key = c[i];
                                    string value = (i+1<c.Length)?c[i+1]:"null";
                                        result += String.Format("key {0} - value {1} \n", key, value);
                                 }
                            break;
                        case "?":
                            result += String.Format("CommandParser.exe [/?] [/help] [-help] [-k key value] [-ping] [-print <print a value>] \n");  
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

        private static string[] prepareArraysCommands(string[] args)
        {
            string result = string.Join(" ", args);
            result = result.Replace("-", "/");
            return result.Split(new Char[] {'/'});
        }
    }   
}
