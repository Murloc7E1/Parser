using System;
using System.Collections.Generic;
using System.Text;

namespace parser
{
    interface IParser
    {
        public Dictionary<string, int> chet(List<string> put);
        public string pars();
    }
}
