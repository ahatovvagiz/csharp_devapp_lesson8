using System;
using System.IO;
using System.Linq;

class Program
{
    static void SearchFiles(string directory, string extension, string searchText)
    {
        try
        {
            string[] files = Directory.GetFiles(directory, $"*.{extension}", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                if (File.ReadAllText(file).Contains(searchText))
                {
                    Console.WriteLine($"Файл \"{file}\" содержит текст \"{searchText}\".");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
    }

    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Укажите расширение файла и текст для поиска.");
            return;
        }

        string extension = args[0];
        string searchText = args[1];

        string currentDirectory = Directory.GetCurrentDirectory();
        SearchFiles(currentDirectory, extension, searchText);
    }
}