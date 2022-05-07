using Gatlin.WCF.Contracts;
using Gatlin.WCF.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace Gatlin.WCF.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            OneTest();
            //AutoReadAllService();
        }

        private static void OneTest()
        {
            var binding = new WCFBinding();
            using (var host = new ServiceHost(typeof(BaseService)))
            {
                host.AddServiceEndpoint(typeof(IBaseService), binding.Binding, $"{binding.PreAddress}127.0.0.1:{AppSetting.Get("Port")}/{nameof(BaseService)}");
                host.Opened += delegate
                {
                    Console.WriteLine($" { nameof(BaseService)}已经启动！");
                };

                host.Open();
            }
        }

        private static void AutoReadAllService()
        {
            var currentPath = Environment.CurrentDirectory;
            var files = System.IO.Directory.GetFiles(currentPath);
            foreach (var file in files)
            {
                if (file.EndsWith("Contracts.dll", StringComparison.OrdinalIgnoreCase))
                {
                    var ass = Assembly.LoadFile(file);

                    var types = ass.GetTypes();
                    foreach (var type in types)
                    {
                        if (!type.IsInterface)
                        {
                            continue;
                        }

                        using (var host = new ServiceHost(type))
                        {
                            host.Opened += delegate
                            {
                                Console.WriteLine($"{type}已经启动！");
                            };

                            host.Open();
                        }

                    }
                }
            }

        }

    }
}
