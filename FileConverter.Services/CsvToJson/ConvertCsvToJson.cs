﻿using FileConverter.Services.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileConverter.Services.CsvToJson
{
    public class ConvertCsvToJson : IConvertCsvToJson
    {
        public bool Convert(string FilePath)
        {
            var success = false;

            var fileExists = File.Exists(FilePath);

            if (!fileExists)
            {
                return success;
            }

            var csvReader = new CsvReader();
            var formatedLines = csvReader.LoadCsv(FilePath);

            var headers = formatedLines[0].Split(',').ToArray();
            var addressHeaderPart1 = headers[1].Split('_');
            var addressHeaderPart2 = headers[2].Split('_');

            var values = formatedLines[1].Split(',');

            Dictionary<String, Object> result = new Dictionary<String, Object>();
            result[headers[0]] = values[0];

            Dictionary<String, Object> address = new Dictionary<String, Object>();
            result[addressHeaderPart1[0]] = address;
            address[addressHeaderPart2[1]] = values[1];
            address[addressHeaderPart2[1]] = values[2];

            try
            {
                var json = JsonConvert.SerializeObject(result);
                var destinationPath = FilePath.Replace(".csv", ".json");
                File.WriteAllText(destinationPath, json);
                success = true;
            }
            catch (Exception ex)
            {
                success = false;

                var baseException = ex.GetBaseException();
            }

            return success;
        }
    }
}
