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
        static int Main(string[] args)
        {
            bool success = false;
            try
            {
                var result = Task.Run(() => new Processor().Process(args)).Result;
                success = !result.Exists;
                Console.WriteLine(result.Message);
            }
            catch (ArgException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ArgUsage.GetUsage<ProcessorArgs>());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.Read();
            return Convert.ToInt16(success);
        }



    }
}
