using System;
using System.IO;
using System.Xml;

class XmlText
{
    static void Main()
    {
        string inputPath = "input.xml";
        string outputPath = "output.txt";

        using (XmlTextReader inputStream = new XmlTextReader(inputPath))
        {
            using (StreamWriter textOutput = new StreamWriter(outputPath))
            {
                while (!inputStream.EOF)
                {
                    inputStream.Read();
                    if (inputStream.NodeType == XmlNodeType.Text)
                    {
                        textOutput.WriteLine(inputStream.Value);
                    }
                }
            }
        }
    }
}