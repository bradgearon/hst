using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using PowerArgs;
using System.Security.Principal;

namespace hst
{
    class Program
    {
        static void Main(string[] args)
        {
            Processor p = new Processor();
            Task.WaitAll(Task.Run(() => p.Process(
                //Args.Parse<Options>(args)
                )));

        }



    }
}
