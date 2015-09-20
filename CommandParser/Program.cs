using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser
{
    public class Program
    {
        static void Main(string[] args)
        {

            InterpretClass ic = new InterpretClass();
            string[] commands = ic.prepareArraysCommandsFromArgs(args);
            bool exit = false;
            
            string output = ic.interpret(commands, out exit);
            Console.WriteLine(output);
            
            while (!exit)
            {
                string line = Console.ReadLine();
                commands = line.Split(new Char[] { '/', '-' }, StringSplitOptions.RemoveEmptyEntries);
                output = ic.interpret(commands, out exit);
                Console.WriteLine(output);
            }

            Console.WriteLine("Press any  key to exit ...");
            Console.ReadKey();
        }

    
    }
}
