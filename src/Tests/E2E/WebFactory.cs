//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.AspNetCore.TestHost;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
//using System.IO;
//using Microsoft.Extensions.Caching.Memory;

//namespace LibraryApp.Tests.E2E
//{
//    public class WebFactory : WebApplicationFactory<TestStartup>
//    {
//        protected override IHost CreateHost(IHostBuilder builder)
//        {
//            builder.UseContentRoot(Directory.GetCurrentDirectory());
//            return base.CreateHost(builder);
//        }
//        protected override IHostBuilder CreateHostBuilder()
//        {
//            return Host.CreateDefaultBuilder().ConfigureWebHost((builder) =>
//            {
//                builder.UseStartup<TestStartup>().UseTestServer();
//            });
//        }
//    }
//}


