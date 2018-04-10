using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoParser
{
    public class XenoParseEventArgs
    {
        public string Value { get; set; }

        public XenoParseEventArgs(string passedValue)
        {
            this.Value = passedValue;
        }

        public XenoParseEventArgs()
        {
            this.Value = string.Empty;
        }
    }
}
