using System;

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
                //FileServices.CompressFile(archivoDePrueba, compressionBase, pathTemporal, true);
                string message = FileServices.CompressFileGzip(archivoDePrueba, compressionBase, false);
                Console.WriteLine("Archivo comprimido en: {0}", message);
                //FileServices.CompressFileDeflate(archivoDePrueba);

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
