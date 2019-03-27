using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PropertyManagement.Domain.Reporting
{
    public class CsvReport
    {
        public CsvReport()
        {

        }

        public byte[] GenerateByteArray(List<string[]> data)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            foreach(var row in data)
            {
                var sb = new StringBuilder();
                foreach(var item in row)
                {
                    sb.Append($"{item},");
                }
                var csvRow = sb.ToString().TrimEnd(',');
                writer.Write(csvRow);
                writer.Write(Environment.NewLine);
            }
                       
            //writer.Write("Hello, World!");
            writer.Flush();
            stream.Position = 0;

            return stream.ToArray();
        }
    }
}
