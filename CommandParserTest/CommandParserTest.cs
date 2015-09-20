using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CommandParser;

namespace CommandParserTest
{
    public class CommandParserTest
    {
        [Test]
        public void CommandParserEmptyArgsTest()
        {
            string result = "CommandParser.exe [/?] [/help] [-help] [-k key value] [-ping] [-print <print a value>] \n";
            InterpretClass ic = new InterpretClass();
            String[] arg = new String[] { };
            bool exit = false;
            Assert.AreEqual(ic.interpret(arg, out exit), result);
        }

        [Test]
        public void CommandParserPingArgTest()
        {
            string result = "Pinging ... \n";
            InterpretClass ic = new InterpretClass();
            String[] arg = new String[] { "ping" };
            bool exit = false;
            Assert.AreEqual(ic.interpret(arg, out exit), result);
        }

        [Test]
        public void CommandParserPrintArgTest()
        {
            string result = "Printing message hello world \n";
            InterpretClass ic = new InterpretClass();
            String[] arg = new String[] {"print hello world"};
            bool exit = false;
            Assert.AreEqual(ic.interpret(arg, out exit), result);
        }

        [Test]
        public void CommandParserUnsupportedArgTest()
        {
            string result = "Command <bye> is not supported, use CommandParser.exe /? to see set of allowed commands \n";
            InterpretClass ic = new InterpretClass();
            String[] arg = new String[] { "bye" };
            bool exit = false;
            Assert.AreEqual(ic.interpret(arg, out exit), result);
        }

        [Test]
        public void CommandParserKArgTest()
        {
            string result = "key key1 - value value1 \nkey key2 - value value2 \n";
            InterpretClass ic = new InterpretClass();
            String[] arg = new String[] { "k key1 value1 key2 value2" };
            bool exit = false;
            Assert.AreEqual(ic.interpret(arg, out exit), result);
        }

        [Test]
        public void CommandParserKEmptyValueArgTest()
        {
            string result = "key key1 - value value1 \nkey key2 - value null \n";
            InterpretClass ic = new InterpretClass();
            String[] arg = new String[] { "k key1 value1 key2" };
            bool exit = false;
            Assert.AreEqual(ic.interpret(arg, out exit), result);
        }

        [Test]
        public void CommandParserHelpIsNotFirstArgTest()
        {
            string result = "Pinging ... \n";
            InterpretClass ic = new InterpretClass();
            String[] arg = new String[] { "ping -help" };
            bool exit = false;
            Assert.AreEqual(ic.interpret(arg, out exit), result);
        }

        [Test]
        public void CommandParserHelpArgTest()
        {
            string result = "CommandParser.exe [/?] [/help] [-help] [-k key value] [-ping] [-print <print a value>] \n";
            InterpretClass ic = new InterpretClass();
            String[] arg = new String[] { "help" };
            bool exit = false;
            Assert.AreEqual(ic.interpret(arg, out exit), result);
        }

        [Test]
        public void CommandParserHelpSignArgTest()
        {
            string result = "CommandParser.exe [/?] [/help] [-help] [-k key value] [-ping] [-print <print a value>] \n";
            InterpretClass ic = new InterpretClass();
            String[] arg = new String[] { "?" };
            bool exit = false;
            Assert.AreEqual(ic.interpret(arg, out exit), result);
        }

        [Test]
        public void CommandParserExitSignArgTest()
        {
            InterpretClass ic = new InterpretClass();
            String[] arg = new String[] { "exit" };
            bool exit = true;
            ic.interpret(arg, out exit);
            Assert.AreEqual(exit, true);
        }


      
    }
}
