using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guti.FileCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileServices.CompressFile();
                Console.WriteLine("Archivo comprimido exitosamente");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                Console.ReadLine();
            }
        }
    }
}
