using FileConverter.Services;
using FileConverter.Services.CsvToJson;
using FileConverter.Services.CsvToXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverterApp.Handler
{
    public class ConverterHandler
    {
        private readonly IConvertCsvToJson _convertCsvToJson;
        private readonly IConvertCsvToXml _convertCsvToXml;

        public ConverterHandler(IConvertCsvToJson convertCsvToJson, IConvertCsvToXml convertCsvToXml)
        {
            _convertCsvToJson = convertCsvToJson;
            _convertCsvToXml = convertCsvToXml;
        }

        public bool Convert(Options options)
        {
            bool success = false;

            ConversionTypes type;
            Enum.TryParse(options.ConvertTo, out type);

            switch (type) 
            {
                case ConversionTypes.xml:
                    success = _convertCsvToXml.Convert(options.FilePath);
                    break;
                case ConversionTypes.json:
                    success = _convertCsvToJson.Convert(options.FilePath);
                    break;
            }

            return success;
        }
    }
}
