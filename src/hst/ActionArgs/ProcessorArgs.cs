using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using hst.ActionArgs;
using PowerArgs;

namespace hst
{
    [TabCompletion]
    [ArgExample("hst action name [networkAddress]", "does action ([a]dd, [d]elete, [c]heck, [r]eplace) on name in machine host file")]
    public class ProcessorArgs
    {
        [ArgPosition(0)]
        [ArgRequired]
        public string Action { get; set; }

        [ArgActionMethod]
        public void Add(AddArgs opt)
        {
            if (!Processor.Hosts.ContainsKey(opt.Name))
            {
                Processor.Hosts.Add(opt.Name, opt.Address);
            }
            else
            {
                Processor.Hosts[opt.Name] = opt.Address;
            }

            opt.Result.Message = string.Format("host entry added for {0} @ {1}", opt.Name, opt.Address);
        }

        [ArgActionMethod]
        public void Delete(DeleteArgs opt)
        {
            if (Processor.Hosts.ContainsKey(opt.Name))
            {
                Processor.Hosts.Remove(opt.Name);
            }

            opt.Result.Message = string.Format("host entry removed for {0} @ {1}", opt.Name, opt.Address);
        }

        [ArgActionMethod]
        public void Check(CheckArgs opt)
        {
            var exists = Processor.Hosts.ContainsKey(opt.Name);

            var existsMessage = exists ? "exists " : "does not exist ";
            opt.Result.Message = string.Format("host entry {0} for {1} @ {2}", existsMessage, opt.Name, opt.Address);
        }

        [ArgActionMethod]
        public void Replace(ReplaceArgs opt)
        {
            var existing = Processor.Hosts[opt.Name];
            Processor.Hosts[opt.Name] = opt.Address;

            opt.Result.Message = string.Format("host entry changed for {0} from {1} to {2}", opt.Name, opt.Address, existing);
        }


    }
}


