using System;
using System.Collections.Generic;
using System.Text;

namespace FileConverter.Services.CsvToXml
{
    public interface IConvertCsvToXml
    {
        bool Convert(string FilePath);
    }
}
