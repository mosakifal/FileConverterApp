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

            _convertedFilePath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))), "ServicesTests/ConvertCsvToJsonTests/TestFile.json");
        }

        [TestMethod]
        public void ConverCsvToJson_Verifies_FileExists()
        {
            //Arrage
            _filePath = "";

            //Act
            bool result = _convertservice.Convert(_filePath);

            //Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void ConverCsvToJson_Converts_File_ToJson()
        {
            //Arrage

            //Act
            bool result = _convertservice.Convert(_filePath);
            var expected = File.Exists(_convertedFilePath) && result;

            //Assert
            Assert.AreEqual(result, true);
        }
    }
}
