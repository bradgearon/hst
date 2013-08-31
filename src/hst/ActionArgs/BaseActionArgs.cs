using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerArgs;

namespace hst.ActionArgs
{
    public class BaseActionArgs
    {
        public BaseActionArgs()
        {
            Result = new HostResult();
        }

        [ArgIgnore]
        public HostResult Result { get; set; }

        [ArgPosition(1)]
        [ArgRequired(PromptIfMissing = true)]
        [ArgDescription("Host name to perform action on")]
        public string Name { get; set; }

        [ArgPosition(2)]
        [DefaultValue("127.0.0.1")]
        [ArgDescription("Network address (v4 | v6)")]
        public string Address { get; set; }

    }
}
