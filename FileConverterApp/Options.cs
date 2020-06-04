using Plossum.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverterApp
{
    [CommandLineManager(ApplicationName = "File converter", Copyright = "Copyright (c) Mohamed Adjagbe")]
    public class Options
    {
        private string _path;
        private string _type;

        [CommandLineOption(Description = "Displays this help text")]
        public bool Help = false;

        [CommandLineOption(Description = "Specifies the file path", MinOccurs = 1)]
        public string FilePath
        {
            get { return _path; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new InvalidOptionValueException("The file path must not be empty");
                _path = value;
            }
        }

        [CommandLineOption(Description = "Specifies the type we are converting to", MinOccurs = 1)]
        public string ConvertTo
        {
            get { return _type; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new InvalidOptionValueException("The type must not be empty");
                _type = value;
            }
        }
    }
}
