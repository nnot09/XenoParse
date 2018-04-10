using System;

namespace XenoParser
{
    class Program
    {
        static void Main(string[] args)
        {
            // Commandline: -action1 printme -a2 works! -action2 worksaswell! -a3 "C:\Configuration\Anything.xml" /connect 127.0.0.1 -c 127.0.0.1:3333 --stunnel /help -anythingthatdoesntexist

            // Instantiate an object
            XenoParse parser = new XenoParse();

            // Add argument definitions
            parser.AddAction("-action1|-a1", "-action1 <text> or -a1 <text>", "Prints some text.", true, action1);
            parser.AddAction("-action2|-a2", "-action2 <text> or -a2 <text>", "Prints some text aswell.", true, action2);
            parser.AddAction("--action3|-a3", "--action3 <path> or -a3 <path>", "Reads a config file.", true, action3);
            parser.AddAction("--stunnel|-s|/stunnel", "--stunnel, -s or /stunnel", "Enables stunnel.", false, stunnel);
            parser.AddAction("-connect|-c|/connect", "-connect <host> or -c <host> or /connect <host> ", "Connect to a host.", true, connect);
            parser.AddAction("/help|/h", "Just type '/help' and see what happens lol", "Prints a help text.", false, help);

            // note that "-anythingthatdoesntexist" will be ignored.

            // Parse commandline.
            parser.Parse(args);

            Console.Read();
        }

        private static void stunnel(object sender, XenoParseEventArgs e)
        {
            Console.WriteLine("STunnel has been activated!");
        }

        private static void connect(object sender, XenoParseEventArgs e)
        {
            Console.WriteLine("Connecting to {0}", e.Value);
        }

        private static void help(object sender, XenoParseEventArgs e)
        {
            // we can cast the 'sender' object and use the "GetHelp" function directly since the caller of this function passes a 'this'-reference of it's own object to the 'sender'. The cast is totally safe.
            Console.WriteLine(((XenoParse)sender).GetHelp());
        }

        private static void action3(object sender, XenoParseEventArgs e)
        {
            Console.WriteLine("Reading config from {0}", e.Value);
        }

        private static void action2(object sender, XenoParseEventArgs e)
        {
            Console.WriteLine("2nd Message {0}", e.Value);
        }

        private static void action1(object sender, XenoParseEventArgs e)
        {
            Console.WriteLine("1st Message {0}", e.Value);
        }
    }
}

