using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guti.FileCompression
{
    class Program
    {
        private static readonly string pathTemporal = @"c:\Guti.FileCompression\Compress";
        private static readonly string compressionBase = @"c:\Guti.FileCompression\";
        //private static readonly string archivoDePeueba = @"C:\Users\rgutierrez\Desktop\Imágenes\home-slide-02.jpg";
        private static readonly string archivoDePrueba = @"C:\Guti.FileCompression\Prueba.pdf";


        static void Main(string[] args)
        {
            try
            {
                FileServices.CompressFile(archivoDePrueba, compressionBase, pathTemporal, true);
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
