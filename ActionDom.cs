using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoParser
{
    public class ActionDom
    {
        public Action<object, XenoParseEventArgs> Method { get; private set; }
        public string Argument { get; private set; }
        public string Help { get; private set; }
        public string Info { get; private set; }
        public bool IsUsed { get; set; }
        public bool RequiredExtraArgument { get; set; }

        public ActionDom(string argument, string help, string info, bool requiredExtraArgument, Action<object, XenoParseEventArgs> methodInvoker)
        {
            this.Argument = argument;
            this.RequiredExtraArgument = requiredExtraArgument;
            this.Help = help;
            this.Info = info;
            this.Method = methodInvoker;
        }
    }
}
