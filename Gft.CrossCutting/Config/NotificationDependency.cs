using Gft.Documentation.Notification;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gft.CrossCutting.Config
{
    public static class NotificationDependency
    {
        public static void AddNotificationPattern(this IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
        }
    }
}
