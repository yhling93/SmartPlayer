using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RealSense;
using System.Diagnostics;
using System.Threading;

namespace ProcessHandle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter main");
            Console.WriteLine(args.Length);
            if(args.Length<2)
            {
                //throw new Exception("ProcessHandle: args number error");
            }
            foreach(string s in args)
            {
                Console.WriteLine(s);
            }
            

           
            ProcessHandle ph = new ProcessHandle();

#if false
            string dir = @"H:\2017.3.19\3\data\1aaa1907-8584-4aad-88bd-2a465d1cadf1";
            string fname = dir + "\\record.rssdk";
            ph.Go(dir, fname);
#else
            ph.Go(args[0], args[1]);
#endif




            // Process current = Process.GetCurrentProcess();
            // current.Kill();

        }
    }
}
