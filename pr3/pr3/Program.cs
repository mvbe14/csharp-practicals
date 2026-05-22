using System;
using System.IO;

namespace FileSystemPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string testFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFolder");
            string cacheFolder = Path.Combine(testFolder, "Cache");

            Directory.CreateDirectory(testFolder);
            Directory.CreateDirectory(cacheFolder);
            Directory.CreateDirectory(Path.Combine(cacheFolder, "SubCache1"));
            File.WriteAllText(Path.Combine(cacheFolder, "SubCache1", "temp1.dat"), "Хлам 1");
            File.WriteAllText(Path.Combine(testFolder, "big_video.mp4"), "Уявімо що це дуже велике відео на багато гігабайт");

            string storyPath = Path.Combine(testFolder, "story.txt");
            string reportPath = Path.Combine(testFolder, "report.txt");
            TextAnalyzer.Run(storyPath, reportPath);

 
            FolderInspector.Inspect(testFolder);

    
            LargestFileFinder.Find(testFolder);

            Console.WriteLine("\n--- ЗАВДАННЯ 4: ОЧИЩЕННЯ КЕШУ ---");

            var recReport = CacheCleaner.CleanWithRecursion(cacheFolder);
            Console.WriteLine($"[Рекурсія] Видалено файлів: {recReport.DeletedFilesCount}, Сумарний розмір: {recReport.TotalSizeDeleted} байт");

            if (args.Length > 0)
            {
                CliAnalyzer.Analyze(args[0]);
            }
            else
            {
                CliAnalyzer.Analyze(testFolder);
            }

            Console.WriteLine("\nНатисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}