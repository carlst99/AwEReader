namespace EPUBReader.CLI;

using System;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;
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
    }
    /*
        This appears to be the format of a EPUB 2.0 File - Under the hood it's all HTML files lmao,
        That should make rendering it easy said than done, provided it also provides css files.
        .
        ├── META-INF/
        │   └── container.xml
        └── OEBPS/
            ├── content.opf
            ├── toc.ncx
            ├── chapter1.html
            ├── images/
            │   └── cover.jpg
            └── styles/
                └── main.css


        Pulling it appart it probably going to look something like this:

        using (ZipArchive epubArchive = ZipFile.OpenRead(epubFilePath))
        {
            // Read container.xml to find the root content file
            ZipArchiveEntry containerEntry = epubArchive.GetEntry("META-INF/container.xml");
            XElement containerXml = XElement.Load(containerEntry.Open());
            XNamespace ns = "urn:oasis:names:tc:opendocument:xmlns:container";
            XElement rootFileElement = containerXml.Descendants(ns + "rootfile").FirstOrDefault();
            string contentFilePath = rootFileElement?.Attribute("full-path")?.Value;

            if (!string.IsNullOrEmpty(contentFilePath))
            {
                // Read content.opf to get metadata and spine
                ZipArchiveEntry contentEntry = epubArchive.GetEntry(contentFilePath);
                XElement contentOpfXml = XElement.Load(contentEntry.Open());
                // Parse content.opf XML and retrieve metadata and spine information
                // ...

                // Read spine items in order
                // ...

                // Read content files and process them
                // ...
            }
            else
            {
                Console.WriteLine("Could not find root content file path.");
            }
        }
    */

    // Pull apart the epub file



    // List it's contents



    // Display content of first page.
}
