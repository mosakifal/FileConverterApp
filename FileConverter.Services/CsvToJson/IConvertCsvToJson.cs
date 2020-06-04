using System;
using System.Collections.Generic;
using System.Text;

namespace FileConverter.Services.CsvToJson
{
    public interface IConvertCsvToJson
    {
        bool Convert(string FilePath);
    }
}
