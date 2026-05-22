using System;
using System.Text;
using System.Threading;

namespace ThreadCounterApp;

internal class Program
{
    private static readonly object Locker = new();

    private static int _counter;
    private static bool _isPaused;
    private static bool _isRunning = true;
    private static int _colorIndex;

    private static readonly ConsoleColor[] Colors =
    {
        ConsoleColor.White,
        ConsoleColor.Green,
        ConsoleColor.Yellow,
        ConsoleColor.Cyan,
        ConsoleColor.Magenta,
        ConsoleColor.Red
    };

    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        Console.ForegroundColor = Colors[_colorIndex];

        Console.WriteLine("Практична робота №6 — потоки та бінди клавіш");
        Console.WriteLine("P - пауза/продовження | R - скинути | C - змінити колір | Q - вихід");
        Console.WriteLine();

        Thread keyListenerThread = new(HandleKeyboardInput)
        {
            IsBackground = true,
            Name = "Keyboard listener thread"
        };

        keyListenerThread.Start();

        while (IsRunning())
        {
            bool paused;
            int value;

            lock (Locker)
            {
                paused = _isPaused;

                if (!paused)
                {
                    _counter++;
                }

                value = _counter;
            }

            if (paused)
            {
                WriteThreadSafe($"Counter paused: {value}");
            }
            else
            {
                WriteThreadSafe($"Counter: {value}");
            }

            Thread.Sleep(1000);
        }

        Console.ResetColor();
        Console.CursorVisible = true;
        Console.WriteLine("Програму завершено.");
    }

    private static void HandleKeyboardInput()
    {
        while (IsRunning())
        {
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);

            lock (Locker)
            {
                switch (key.Key)
                {
                    case ConsoleKey.P:
                        _isPaused = !_isPaused;
                        Console.WriteLine(_isPaused
                            ? "[P] Лічильник поставлено на паузу."
                            : "[P] Лічильник продовжено.");
                        break;

                    case ConsoleKey.R:
                        _counter = 0;
                        Console.WriteLine("[R] Лічильник скинуто до 0.");
                        break;

                    case ConsoleKey.C:
                        _colorIndex = (_colorIndex + 1) % Colors.Length;
                        Console.ForegroundColor = Colors[_colorIndex];
                        Console.WriteLine($"[C] Колір змінено на {Colors[_colorIndex]}.");
                        break;

                    case ConsoleKey.Q:
                        _isRunning = false;
                        Console.WriteLine("[Q] Завершення програми...");
                        break;
                }
            }
        }
    }

    private static bool IsRunning()
    {
        lock (Locker)
        {
            return _isRunning;
        }
    }

    private static void WriteThreadSafe(string text)
    {
        lock (Locker)
        {
            Console.WriteLine(text);
        }
    }
}
