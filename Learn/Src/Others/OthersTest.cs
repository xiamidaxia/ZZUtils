using System;
using System.Configuration;
using System.IO;
using NUnit.Framework;

namespace Learn.Others
{
    public class OthersTest
    {
        [Test]
        public void AppSettingsTest()
        {
            var appSettings = ConfigurationSettings.AppSettings;
            Console.WriteLine(appSettings.Get("Setting1"));
            Console.WriteLine(appSettings["Setting1"]);
        }

        [Test]
        public void AppDomainTest()
        {
            var rootDir = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(rootDir);
            Console.WriteLine(File.Exists(Path.Combine(rootDir, "Learn.dll")));
            var fileInfo = new FileInfo(Path.Combine(rootDir, "Learn.dll"));
            Console.WriteLine(fileInfo.Length);
        }

    }
}