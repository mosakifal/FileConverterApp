using System;
using System.IO;
using FileConverter.Services.CsvToJson;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileConverter.UnitTests.ServicesTests.ConvertCsvToJsonTests
{
    [TestClass]
    public class ConvertCsvToJsonTests
    {
        private string _filePath;
        private string _convertedFilePath;
        ConvertCsvToJson _convertservice;

        [TestInitialize]
        public void Setup()
        {
            _convertservice = new ConvertCsvToJson();

            _filePath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))), "ServicesTests/ConvertCsvToJsonTests/TestFile.csv");

            _filePath = _filePath.Replace("file:\\", "");

            _convertedFilePath = _filePath.Replace(".csv", ".json");
        }

        [TestMethod]
        public void ConverCsvToJson_Converts_File_ToJson()
        {
            //Arrange

            //Act
            bool result = _convertservice.Convert(_filePath);
            var expected = File.Exists(_convertedFilePath) && result;

            //Assert
            Assert.AreEqual(result, true);
        }
    }
}
