using System;
using System.IO;

namespace FileSystemPractice
{
    public static class LargestFileFinder
    {
        public static void Find(string folderPath)
        {
            if (!Directory.Exists(folderPath)) return;

            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
            FileInfo largestFile = null;

            try
            {
                FileInfo[] files = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);

                foreach (FileInfo file in files)
                {
                    if (largestFile == null || file.Length > largestFile.Length)
                    {
                        largestFile = file;
                    }
                }

                if (largestFile != null)
                {
                    Console.WriteLine("\n--- НАЙБІЛЬШИЙ ФАЙЛ ---");
                    Console.WriteLine($"Name: {largestFile.Name}");
                    Console.WriteLine($"Size: {largestFile.Length / (1024.0 * 1024.0):F2} MB ({largestFile.Length} bytes)");
                    Console.WriteLine($"Path: {largestFile.FullName}");
                }
                else
                {
                    Console.WriteLine("Файлів не знайдено.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при пошуку: {ex.Message}");
            }
        }
    }
}