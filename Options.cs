using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerArgs;

namespace hst
{
    [TabCompletion]
    [ArgExample("hst action name [networkAddress]", "does action ([a]dd, [d]elete, [c]heck, [r]eplace) on name in machine host file")]
    class Options
    {
        [ArgPosition(0), ArgRequired(PromptIfMissing = true)]
        [ArgDescription("Action to perform ([a]dd, [d]elete, [c]heck, [r]eplace)")]
        public string Action { get; set; }

        [ArgPosition(1), ArgRequired(PromptIfMissing = true)]
        [ArgDescription("Host name to perform action on")]
        public string Name { get; set; }

        [ArgPosition(2)]
        [ArgDescription("Network address (v4 | v6)")]
        public string Address { get; set; }
    }
}


