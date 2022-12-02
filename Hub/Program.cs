using Hub;
using Hub.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PuzzleCode;

var builder = new ConfigurationBuilder();
BuildConfig(builder);
var config = builder.Build();

using var host = CreateHostBuilder(args, config).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;
try
{
    await services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

static IHostBuilder CreateHostBuilder(string[] args, IConfigurationRoot? config)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddHttpClient<IInputClient, InputClient>(ConfigureClient(config));
            services.AddTransient<IInputService, InputService>();
            services.AddTransient<IFileService, FileService>();
            services.AddSingleton<IDayService, DayService>();
            services.AddSingleton<App>();
        });
}

static void BuildConfig(IConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
        .AddUserSecrets<Program>();
}

static Action<HttpClient> ConfigureClient(IConfigurationRoot config)
{
    return httpClient =>
    {
        httpClient.BaseAddress = new Uri(config.GetSection("AdventOfCode")["BaseAddress"]);
        httpClient.DefaultRequestHeaders.Add("cookie", config.GetSection("AdventOfCode")["Cookie"]);
    };
}