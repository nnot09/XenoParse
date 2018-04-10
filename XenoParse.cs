using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoParser
{
    public class XenoParse
    {
        private List<ActionDom> _actions;

        public XenoParse()
        {
            _actions = new List<ActionDom>();
        }

        /// <summary>
        /// Adds a new argument definition.
        /// </summary>
        /// <param name="argument">The desired argument name to define. You can use multiple definitions with synonymous meanings by using the '|' seperator.</param>
        /// <param name="help">Usage text.</param>
        /// <param name="info">Argument description</param>
        /// <param name="requiredExtraArgument">Determines whether the argument has an extra additional argument or not.</param>
        /// <param name="action">The target function to invoke when the param is used.</param>
        public void AddAction(string argument, string help, string info, bool requiredExtraArgument, Action<object, XenoParseEventArgs> action)
        {
            _actions.Add(new ActionDom(argument, help, info, requiredExtraArgument, action));
        }

        /// <summary>
        /// Returns a help-text.
        /// </summary>
        /// <returns>string</returns>
        public string GetHelp()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ActionDom action in _actions)
            {
                sb.AppendLine("[Argument]");
                sb.AppendFormat("   => Definition: {0}\n", action.Argument);
                sb.AppendFormat("   => Information: {0}\n", action.Info);
                sb.AppendFormat("   => Usage: {0}\n", action.Help);
                sb.AppendLine();
            }

            return sb.ToString();
        }

        /// <summary>
        /// Parses the current commandline arguments given to this process.
        /// </summary>
        /// <param name="args">Commandline args.</param>
        public void Parse(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];

                foreach (ActionDom action in _actions)
                {
                    // Contains only the list of synonmous param definitions.
                    string[] synParams = action.Argument.Split('|');

                    if (synParams.Any(x => x.Equals(arg, StringComparison.OrdinalIgnoreCase)))
                    {
                        action.IsUsed = true;

                        XenoParseEventArgs eventArguments;

                        if (action.RequiredExtraArgument)
                        {
                            if ( i + 1 >= args.Length )
                            {
                                Console.WriteLine("[ERROR] The parameter \"{0}\" requires an additional argument.", arg);
                                return;
                            }

                            string extraArgument = args[i + 1];

                            if ( string.IsNullOrWhiteSpace(extraArgument) )
                            {
                                Console.WriteLine("[ERROR] The parameter \"{0}\" has an invalid argument.", arg);
                                return;
                            }

                            eventArguments = new XenoParseEventArgs(args[i + 1]);
                        }
                        else
                            eventArguments = new XenoParseEventArgs();

                        action.Method?.Invoke(this, eventArguments);
                    }
                }
            }
        }
    }
}