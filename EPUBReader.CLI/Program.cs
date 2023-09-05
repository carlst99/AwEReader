namespace EPUBReader.CLI;

using System;
using System.IO;
using System.Linq;

public class Program
{
    internal static void Exit(string msg, bool usage = false)
    {
        Console.WriteLine($"{msg}");
        if (usage)
        {
            Console.WriteLine("\n");
            Usage();
        }
        Environment.Exit(1);
    }
    internal static void Usage()
    {
        string usageMessage = @$"Usage:
        {System.AppDomain.CurrentDomain.FriendlyName} /path/to/epub
        ";
        Console.WriteLine(usageMessage);
    }


    public static void Main(string[] args)
    {
        if (args.Count() != 1)
            Exit("Invalid amount of arguments", true);

        string filepath = args[0];
        if (!File.Exists(filepath))
        {
            string errMsg = @$"File: {filepath} does not exist";
            Exit(errMsg);
        }

        // Get the first arg of the program which will be the filepath
        Console.WriteLine(filepath);
        EPUB.deconstruct_epub_file(filepath);
    }

    // Pull apart the epub file



    // List it's contents



    // Display content of first page.
}
