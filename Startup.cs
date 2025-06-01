using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: WebJobsStartup(typeof(Songs.Function.Startup))]
namespace Songs.Function
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddDbContext<YourDbContext>(options =>
                options.UseSqlServer(
                    Environment.GetEnvironmentVariable("SqlConnectionString"),
                    sqlOptions => sqlOptions.EnableRetryOnFailure())
            );
        }
    }
}