namespace SimpleMVC.Utilities
{
    using System.IO;

    public static class FileRead
    {
        #region Methods
        public static string HtmlDocument(string path)
        {
            string document = File.ReadAllText(path);

            return document;
        }

        public static byte[] Image(string path)
        {
            byte[] image = File.ReadAllBytes(path);

            return image;
        }
        #endregion
    }
}