using System;

namespace MoodAnalyzerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyzer");
            Type type = typeof(MoodAnalyse);
            Console.WriteLine(type.FullName);
        }
    }
}
