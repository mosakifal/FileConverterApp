using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileConverter.Services.Helper
{
    public class CsvReader
    {
        public List<string> LoadCsv(string filePath)
        {
            var lines = File.ReadAllLines(filePath).ToList();

            var formatedLines = new List<string>();

            foreach (var line in lines)
            {
                var formatedLine = line.TrimEnd(',');
                formatedLines.Add(formatedLine);
            }
            return formatedLines;
        }
    }
}
