using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.JSInterop.Helpers.Services
{
    public static class ServiceConfiguration
    {
        /// <summary>
        /// Adds the Blazor Interop Handler singleton services to the specified IServiceCollection
        /// </summary>
        public static void AddBlazorInteropHandlers(this IServiceCollection services)
        {
            services.AddSingleton<IElementHandler, ElementHandler>();
            services.AddSingleton<IWindowHandler, WindowHandler>();
        }
    }
}
