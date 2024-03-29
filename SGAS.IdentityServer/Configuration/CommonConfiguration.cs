using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.ResponseCompression;
using System.Globalization;
using System.IO.Compression;

namespace SGAS.IdentityServer.Configuration
{
    public static class CommonConfiguration
    {
        public static void AddCommonConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.Configure<RequestLocalizationOptions>(
                          opt =>
                          {
                              var cultures = new List<CultureInfo>()
                              {
                        new CultureInfo("en-US"),
                        new CultureInfo("pt-BR")
                              };

                              opt.DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR");
                              opt.SupportedCultures = cultures;
                              opt.SupportedUICultures = cultures;
                          });
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml" });
            });


            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
            services.Configure<IISOptions>(o =>
            {
                o.ForwardClientCertificate = false;
            });

            services.AddMvc();
            services.AddControllers();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }
    }
}
