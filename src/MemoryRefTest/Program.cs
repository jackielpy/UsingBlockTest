using System;
using System.IO;

namespace MemoryRefTest
{
    class Program
    {
        /// <summary>
        /// To test the object instance scoping in the using block
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Dummy d1 = new Dummy();
            Dummy d2 = new Dummy();

            string path1 = @"TextFile1.txt";
            string path2 = @"TextFile2.txt";

            using (var s1 = new FileStream(path1, FileMode.Append))
            {
                d1.stream = s1;

                var s2 = new FileStream(path2, FileMode.Append);
                d2.stream = s2;
            }

            try
            {
                Console.WriteLine("d1 length:");
                Console.WriteLine(d1.stream.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("d2 length:");
                Console.WriteLine(d2.stream.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        class Dummy
        {
            public FileStream stream { get; set; }
        }
    }
}
