using Gatlin.WCF.Contracts;
using Gatlin.WCF.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Gatlin.WCF.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            OneTest();
            Console.ReadLine();
            //AutoReadAllService();
        }

        private static void OneTest()
        {
            //var binding = new WCFBinding();
            using (var host = new ServiceHost(typeof(BaseService)))
            {
                //host.AddServiceEndpoint(typeof(IBaseService), binding.Binding, $"{binding.PreAddress}127.0.0.1:{AppSetting.Get("Port")}/{nameof(BaseService)}");
                host.AddServiceEndpoint(typeof(IBaseService), new WSHttpBinding(), "http://127.0.0.1:9999/baseservice");
                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    behavior.HttpGetUrl = new Uri("http://127.0.0.1:9999/baseservice/metadata");
                    host.Description.Behaviors.Add(behavior);
                }
                host.Opened += delegate
                {
                    Console.WriteLine($" { nameof(BaseService)}已经启动！");
                };

                host.Open();
                Console.Read();
            }
        }

        private static void AutoReadAllService()
        {
            var currentPath = Environment.CurrentDirectory;
            var files = System.IO.Directory.GetFiles(currentPath);
            foreach (var file in files)
            {
                if (file.EndsWith("Services.dll", StringComparison.OrdinalIgnoreCase))
                {
                    var ass = Assembly.LoadFile(file);

                    var types = ass.GetTypes();
                    foreach (var type in types)
                    {
                        if (!type.IsClass)
                        {
                            continue;
                        }

                        foreach (Type item in type.GetInterfaces())
                        {
                            foreach (var obj in item.GetCustomAttributes(true))
                            {
                                if (string.Compare(obj.ToString(), "System.ServiceModel.ServiceContractAttribute", true) == 0)
                                {
                                    try
                                    {

                                    }
                                    catch (Exception)
                                    {

                                        throw;
                                    }
                                }
                            }
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
