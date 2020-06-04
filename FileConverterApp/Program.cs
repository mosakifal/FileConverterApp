using Autofac;
using FileConverter.Services.CsvToJson;
using FileConverter.Services.CsvToXml;
using FileConverterApp.Handler;
using Plossum.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Options options = new Options();
            CommandLineParser parser = new CommandLineParser(options);
            parser.Parse();
            Console.WriteLine(parser.UsageInfo.GetHeaderAsString(78));

            if (options.Help)
            {
                Console.WriteLine(parser.UsageInfo.GetOptionsAsString(78));
                Console.ReadLine();
            }
            else if (parser.HasErrors)
            {
                Console.WriteLine(parser.UsageInfo.GetErrorsAsString(78));
                Console.ReadLine();
            }
            Console.WriteLine($"path: {options.FilePath}");
            Console.WriteLine($"convertTo: {options.ConvertTo}");

            var container = BuildContainer();
            var csvToJson = container.Resolve<IConvertCsvToJson>();
            var csvToXml = container.Resolve<IConvertCsvToXml>();
            var convertHandler = new ConverterHandler(csvToJson, csvToXml);
            bool success = convertHandler.Convert(options);

            if (success)
            {
                Console.WriteLine("Your file has been converted and can be found in the same directory");
            }
            else
            {
                Console.WriteLine("Something went wrong during conversion");
            }

            Console.ReadLine();
        }

        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConvertCsvToJson>()
                   .As<IConvertCsvToJson>()
                   .InstancePerDependency();
            builder.RegisterType<ConvertCsvToXml>()
                   .As<IConvertCsvToXml>()
                   .InstancePerDependency();
            return builder.Build();
        }
    }
}
