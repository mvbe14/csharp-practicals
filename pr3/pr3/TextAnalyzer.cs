using System;
using System.IO;

namespace FileSystemPractice
{
    public static class TextAnalyzer
    {
        public static void Run(string inputPath, string outputPath)
        {
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "Hello world!\nThis is a test story.\nC# is awesome.");
            }

            int lineCount = 0;
            int wordCount = 0;
            int charCount = 0;

            using (StreamReader reader = new StreamReader(inputPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineCount++;
                    charCount += line.Length;

                    string[] words = line.Split(new char[] { ' ', '.', ',', '!', '?', '-', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    wordCount += words.Length;
                }
            }

            string report = $"=== СТАТИСТИКА ТЕКСТУ ===\n" +
                            $"Кількість рядків: {lineCount}\n" +
                            $"Кількість слів: {wordCount}\n" +
                            $"Кількість символів: {charCount}\n";

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.Write(report);
            }

            Console.WriteLine("[Завдання 1] Звіт успішно записано в " + outputPath);
        }
    }
}