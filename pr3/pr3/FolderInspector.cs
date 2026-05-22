using System;
using System.IO;

namespace FileSystemPractice
{
    public static class FolderInspector
    {
        public static void Inspect(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"Папка за шляхом {folderPath} не існує.");
                return;
            }

            Console.WriteLine($"\n--- ІНСПЕКТОР ПАПКИ: {folderPath} ---");

            Console.WriteLine("\n[Підпапки]:");
            string[] subDirectories = Directory.GetDirectories(folderPath);
            foreach (var dir in subDirectories)
            {
                Console.WriteLine($"  📁 {Path.GetFileName(dir)}");
            }

            Console.WriteLine("\n[Файли]:");
            string[] files = Directory.GetFiles(folderPath);
            foreach (var filePath in files)
            {
                FileInfo fileInfo = new FileInfo(filePath);

                string name = fileInfo.Name;
                double sizeInKb = fileInfo.Length / 1024.0;
                DateTime creationTime = fileInfo.CreationTime;

                Console.WriteLine($"  📄 {name} | Розмір: {sizeInKb:F2} KB | Створено: {creationTime}");
            }
        }
    }
}