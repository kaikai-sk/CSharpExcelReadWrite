using ExcelRead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtPlug
{
    public class PlugToLower : IPlug
    {
        public string ProcessText(string txt)
        {
            return txt.ToLower();
        }
    }
}
