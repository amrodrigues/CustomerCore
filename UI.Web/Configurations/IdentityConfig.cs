﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Web.Configurations
{
    public static class IdentityConfig
    {

        public static void AddSocialAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                });
        }
    }
}