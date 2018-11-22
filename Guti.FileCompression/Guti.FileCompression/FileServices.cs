using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Guti.FileCompression
{
    public class FileServices
    {
        private static void CreatePaths(string pathTemporal, string compressionBase)
        {
            Directory.CreateDirectory(pathTemporal);
            Directory.CreateDirectory(compressionBase);
        }

        public static void DeleteFiles(DirectoryInfo directory)
        {
            //delete files:
            foreach (System.IO.FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            //delete directories in this directory:
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories())
            {
                directory.Delete(true);
            }
        }

        public static string GenerarRandomCode(int numChars)
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

        public static string GetUniqueName()
        {
            return DateTime.Now.Ticks.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">Ruta al archivo a comprimir</param>
        /// <param name="compressedFileDestination">Ruta de destino para el archivo comprimido</param>
        /// <param name="temporalPath">Carpeta temporal en donde se comprimirá el archivo</param>
        /// <param name="deleteOriginal">Si true borra el archivo original</param>
        public static void CompressFile(string filePath, string compressedFileDestination, string temporalPath, bool deleteOriginal)
        {
            Directory.CreateDirectory(temporalPath);
            Directory.CreateDirectory(compressedFileDestination);

            //Vaciar la carpeta temporal
            DeleteFiles(new DirectoryInfo(temporalPath));

            //Copiar archivo a la carpeta temporal
            File.Copy(filePath, Path.Combine(temporalPath, Path.GetFileName(filePath)));

            //Comprimir
            string zipPath = Path.Combine(compressedFileDestination, $"{GetUniqueName()}.zip");
            ZipFile.CreateFromDirectory(temporalPath, zipPath, CompressionLevel.Optimal, false);

            //Borrar archivo de la carpeta temporal
            File.Delete(Path.Combine(temporalPath, Path.GetFileName(filePath)));

            if (deleteOriginal)
            {
                File.Delete(filePath);
            }
        }

        public static string CompressFileGzip(string filePath, string compressedFileDestination, bool deleteOriginal)
        {
            FileInfo fileToBeGZipped = new FileInfo(filePath);
            FileInfo gzipFileName = new FileInfo(string.Concat(fileToBeGZipped.FullName, ".gz"));

            using (FileStream fileToBeZippedAsStream = fileToBeGZipped.OpenRead())
            {
                using (FileStream gzipTargetAsStream = gzipFileName.Create())
                {
                    using (GZipStream gzipStream = new GZipStream(gzipTargetAsStream, CompressionMode.Compress))
                    {
                        try
                        {
                            fileToBeZippedAsStream.CopyTo(gzipStream);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }

            if (deleteOriginal)
            {
                File.Delete(filePath);
            }

            string fileUniqueName = Path.Combine(compressedFileDestination, $"{GetUniqueName()}.gz");
            File.Move(gzipFileName.FullName, fileUniqueName);
            return fileUniqueName;
        }

        public static void CompressFileDeflate(string filePath)
        {
            FileInfo fileToBeDeflateZipped = new FileInfo(filePath);
            FileInfo deflateZipFileName = new FileInfo(string.Concat(fileToBeDeflateZipped.FullName, ".cmp"));

            using (FileStream fileToBeZippedAsStream = fileToBeDeflateZipped.OpenRead())
            {
                using (FileStream deflateZipTargetAsStream = deflateZipFileName.Create())
                {
                    using (DeflateStream deflateZipStream = new DeflateStream(deflateZipTargetAsStream, CompressionMode.Compress))
                    {
                        try
                        {
                            fileToBeZippedAsStream.CopyTo(deflateZipStream);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
    }
}
