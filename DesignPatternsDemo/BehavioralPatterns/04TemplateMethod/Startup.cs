using System;

namespace TemplateMethod
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("---- Document Reader - PDF doc ----");
            DocumentReader documentReader = new PDFDocument();
            documentReader.OpenDocument();

            Console.WriteLine("---- Document Reader - RTF doc ----");
            documentReader = new RTFDocument();
            documentReader.OpenDocument();
        }
    }
}