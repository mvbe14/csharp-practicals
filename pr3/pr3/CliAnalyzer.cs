using System;
using System.IO;

namespace FileSystemPractice
{
    public static class CliAnalyzer
    {
        public static void Analyze(string targetPath)
        {
            if (!Directory.Exists(targetPath))
            {
                Console.WriteLine($"Помилка: Шлях '{targetPath}' не знайдено.");
                return;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(targetPath);

            int folderCount = 0;
            int fileCount = 0;
            long totalSize = 0;
            FileInfo largestFile = null;

            try
            {
                folderCount = dirInfo.GetDirectories("*.*", SearchOption.AllDirectories).Length;

                FileInfo[] files = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);
                fileCount = files.Length;

                foreach (FileInfo file in files)
                {
                    totalSize += file.Length;

                    if (largestFile == null || file.Length > largestFile.Length)
                    {
                        largestFile = file;
                    }
                }

                double sizeInMb = totalSize / (1024.0 * 1024.0);

                Console.WriteLine($"\n=== АНАЛІЗ ДЛЯ: {targetPath} ===");
                Console.WriteLine($"Folders: {folderCount}");
                Console.WriteLine($"Files: {fileCount}");
                Console.WriteLine($"Total size: {sizeInMb:F2} MB");
                Console.WriteLine($"Largest file: {(largestFile != null ? largestFile.Name : "Немає")} ({(largestFile != null ? (largestFile.Length / (1024.0 * 1024.0)) : 0):F2} MB)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка під час аналізу файлової системи: {ex.Message}");
            }
        }
    }
}