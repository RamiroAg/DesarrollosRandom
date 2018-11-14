using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Guti.FileCompression
{
    public class FileServices
    {
        private static readonly string pathTemporal = @"c:\Guti.FileCompression\Compress";
        private static readonly string compressionBase = @"c:\Guti.FileCompression\";
        //private static readonly string archivoDePeueba = @"C:\Users\rgutierrez\Desktop\Imágenes\home-slide-02.jpg";
        private static readonly string archivoDePeueba = @"C:\Guti.FileCompression\Prueba.html";

        private static void CreatePaths()
        {
            Directory.CreateDirectory(pathTemporal);
            Directory.CreateDirectory(compressionBase);
        }

        public static string GenerarRandomName(int numChars)
        {
            string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random r = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < numChars; i++)
            {
                int idx = r.Next(0, 35);
                sb.Append(s.Substring(idx, 1));
            }

            return sb.ToString();
        }

        public static void CompressFile()
        {
            CreatePaths();
            //Copiar archivo a la carpeta temporal
            File.Copy(archivoDePeueba, Path.Combine(pathTemporal, Path.GetFileName(archivoDePeueba)));
            //Comprimir
            string zipPath = Path.Combine(compressionBase, $"{GenerarRandomName(10)}.zip");
            ZipFile.CreateFromDirectory(pathTemporal, zipPath, CompressionLevel.Optimal, false);

            //Borrar archivo de la carpeta temporal
            File.Delete(Path.Combine(pathTemporal, Path.GetFileName(archivoDePeueba)));

            //string extractPath = @"c:\example\extract";

            //ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
