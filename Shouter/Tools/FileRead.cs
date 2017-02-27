namespace Shouter.Tools
{
    using System.IO;

    public static class FileRead
    {
        public static string HtmlDocument(string path)
        {
            string document = File.ReadAllText(path);

            return document;
        }
    }
}