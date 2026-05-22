using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemPractice
{
    public static class CacheCleaner
    {
        public class CleanReport
        {
            public int DeletedFilesCount { get; set; }
            public long TotalSizeDeleted { get; set; }
        }

        public static CleanReport CleanWithRecursion(string cachePath)
        {
            CleanReport report = new CleanReport();
            if (!Directory.Exists(cachePath)) return report;

            RecursiveDelete(new DirectoryInfo(cachePath), report);
            return report;
        }

        private static void RecursiveDelete(DirectoryInfo currentDir, CleanReport report)
        {
            foreach (FileInfo file in currentDir.GetFiles())
            {
                try
                {
                    report.TotalSizeDeleted += file.Length;
                    file.Delete();
                    report.DeletedFilesCount++;
                }
                catch (Exception) { /* Пропускаємо заблоковані системою файли */ }
            }

            foreach (DirectoryInfo subDir in currentDir.GetDirectories())
            {
                RecursiveDelete(subDir, report);
            }
        }

        public static CleanReport CleanWithoutRecursion(string cachePath)
        {
            CleanReport report = new CleanReport();
            if (!Directory.Exists(cachePath)) return report;

            Queue<string> foldersQueue = new Queue<string>();
            foldersQueue.Enqueue(cachePath);

            while (foldersQueue.Count > 0)
            {
                string currentFolder = foldersQueue.Dequeue();

                try
                {
                    string[] files = Directory.GetFiles(currentFolder);
                    foreach (string filePath in files)
                    {
                        FileInfo fileInfo = new FileInfo(filePath);
                        report.TotalSizeDeleted += fileInfo.Length;
                        File.Delete(filePath);
                        report.DeletedFilesCount++;
                    }
                }
                catch (Exception) { }

                try
                {
                    string[] subDirs = Directory.GetDirectories(currentFolder);
                    foreach (string dir in subDirs)
                    {
                        foldersQueue.Enqueue(dir);
                    }
                }
                catch (Exception) { }
            }

            return report;
        }
    }
}