using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory1
{
    [DialogFactory("Hello")]
    class MyClass : IFoo
    {
        public void Fred()
        {
            Console.WriteLine("Fred");
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                int[] a = { 1, 2, 3 };
                var list = a.ToList();
                Type[] at = { typeof(int), typeof(short) };
                var lt = at.ToList();

                Type t0 = typeof(MyClass);
                var t1 = t0.GetInterfaces().ToList();

                var factory = new Factory<IFoo>();
                var x = factory.Create("Hello", 3);
                x.Fred();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
