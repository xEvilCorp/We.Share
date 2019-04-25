using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WeShare.Web
{

    public static class IoC
    {
        public static AppDbContext AppDbContext => IoCContainer.Provider.GetService<AppDbContext>(); 
    }
    public static class IoCContainer
    {
        public static IServiceProvider Provider {get; set;}
        public static IConfiguration Configuration { get; set;}

        
    }
}