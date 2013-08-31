using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace hst
{
    public class Processor
    {
        private static readonly string ipaddrRegex = @"^((([01]?\d?\d|2[0-4]\d|25[0-5])\.){3}([01]?\d?\d|2[0-4]\d|25[0-5]))\w+([a-Z.]+)$";
        internal async Task Process(Options options = null)
        {
            var hostContent = File.ReadAllText(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\etc\\hosts"));
            foreach (Match m in Regex.Matches(hostContent, ipaddrRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase))
            {
                Console.WriteLine(m.Value);
            }
            
        }
    }
}
