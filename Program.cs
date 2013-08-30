using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using PowerArgs;

namespace hst
{
    class Program
    {
        static void Main(string[] args)
        {
            // var options = Args.Parse<Options>(args);
            Func<string, ProcessStartInfo> ps =
                (i) =>
                    new ProcessStartInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        string.Format("exp{0}.xlsx", i)));

            var p = new Process() { StartInfo = ps(string.Empty) };
            var p2 = new Process() { StartInfo = ps("2") };


            p.Exited += p_Exited;
            p2.Exited += p_Exited;

            Task.WaitAll(
                Task.Run(() =>
                {
                    p.EnableRaisingEvents = true;
                    p.Start();

                    foreach (var process in pp)
                    {
                        Console.Write(process.Id);
                    }
                }),
                Task.Run(
                    () =>
                    {
                        p2.Start();
                    })
            );

            //Marshal.get




            Console.Read();


        }

        static void p_Exited(object sender, EventArgs e)
        {
            Console.Write(e);
        }

        private static void Process(Options options)
        {
            Console.Read();

        }
    }
}
