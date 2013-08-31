using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PowerArgs;
using hst.ActionArgs;

namespace hst
{
    public class Processor
    {
        private static readonly string ipaddrRegex = @"^[^#\d]*((([01]?\d?\d|2[0-4]\d|25[0-5])\.){3}([01]?\d?\d|2[0-4]\d|25[0-5]))\s+([^\s]+)";
        private static readonly RegexOptions regexOptions = RegexOptions.Multiline | RegexOptions.Compiled | RegexOptions.IgnoreCase;
        private readonly string hostFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\etc\\Hosts");
        public static IDictionary<string, string> Hosts;

        internal async Task<HostResult> Process(string[] args)
        {
            string hostContent;
            using (var reader = File.OpenText(hostFilePath))
            {
                hostContent = await reader.ReadToEndAsync();
            }

            var hostContentMatches = Regex.Matches(hostContent, ipaddrRegex, regexOptions).OfType<Match>();

            var hostGroups = from match in hostContentMatches
                             group match by match.Groups[5].Value into matches
                             select matches;

            Hosts = hostGroups.ToDictionary(
                m => m.Key, 
                m => m.FirstOrDefault().Groups[1].Value);

            return await doAction(args);
        }
        
        private async Task<HostResult> doAction(string[] args)
        {
            var options = Args.InvokeAction<ProcessorArgs>(args);

            using (var hostFileStream = new FileStream(hostFilePath, FileMode.Truncate))
            {
                using (var writer = new StreamWriter(hostFileStream))
                {
                    Hosts.ToList().ForEach(async (pair) => await writer
                        .WriteLineAsync(string.Format("{0} {1}", pair.Value, pair.Key)));
                }
            }

            var baseArgs = (options.ActionArgs as BaseActionArgs);
            return baseArgs.Result;
        }
    }
}
