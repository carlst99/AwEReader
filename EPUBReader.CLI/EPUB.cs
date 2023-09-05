namespace EPUBReader.CLI;

using System;
using System.IO.Compression;
using System.Xml.Linq;
using System.Linq;

// This appears to be the format of a EPUB 2.0 File - Under the hood it's all HTML files lmao,
// That should make rendering it easy said than done, provided it also provides css files.
// .
// ├── META-INF/
// │   └── container.xml
// └── OEBPS/
//     ├── content.opf
//     ├── toc.ncx
//     ├── chapter1.html
//     ├── images/
//     │   └── cover.jpg
//     └── styles/
//         └── main.css
internal class EPUB
{
    internal ZipArchiveEntry infoFile;
    internal ZipArchiveEntry coverImage;
    internal ZipArchiveEntry bookCover;
    internal ZipArchiveEntry package;
    internal ZipArchiveEntry tocFiles;
    internal ZipArchiveEntry index;
    internal ZipArchiveEntry[] chapters;
    internal ZipArchiveEntry[] cssFiles;


    internal static void deconstruct_epub_file(string epubFile)
    {
        ZipArchive epubArchive = ZipFile.OpenRead(epubFile);
        foreach (ZipArchiveEntry entry in epubArchive.Entries)
        {
            Console.WriteLine(entry.ToString());
        }

        // Need to do a bunch of verification that the core files exist.
        // Some may or may not be present. But there is a minimum that is required.
        //
        // Once we do a bunch of verification and stuff to make sure the epub file is complete.
        // We then need to make objects of each entry type that points to some sort of file.
        // Either CSS/HTML or XML and go from there.
        //
        // We then use composition to build up a big EPUB object.

        ZipArchiveEntry containerEntry = epubArchive.GetEntry("META-INF/container.xml");
        XElement containerXml = XElement.Load(containerEntry.Open());
        XNamespace nameSpace = "urn:oasis:names:tc:opendocument:xmlns:container";
        XElement rootFileElement = containerXml.Descendants(nameSpace + "rootfile").FirstOrDefault();
        string contentFilePath = rootFileElement?.Attribute("full-path")?.Value;

        if (!string.IsNullOrEmpty(contentFilePath))
        {
            // Read content.opf to get metadata and spine
            ZipArchiveEntry contentEntry = epubArchive.GetEntry(contentFilePath);
            XElement contentOpfXml = XElement.Load(contentEntry.Open());
            // Parse content.opf XML and retrieve metadata and spine information
            //
            // Read spine tiems in order
            //
            // read content files and process them
        }
        else
        {
            Console.WriteLine("Could not find root conent file path.");
        }
    }
}
