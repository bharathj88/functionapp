using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Songs.Function
{
    public class youtubeupdate
    {
        private readonly YourDbContext _dbContext;

        public youtubeupdate(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("youtubeupdate")]
        public async Task<IActionResult> Run(
            [HttpTrigger("post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // Example: Add a new song to the database
            var song = new Song
            {
                Id=1,
                Title = "Example Song",
                Artist = "Example Artist",
                ReleaseDate = DateTime.UtcNow
            };

            _dbContext.Songs.Add(song);
            await _dbContext.SaveChangesAsync();
            return new OkObjectResult("Song added successfully");
        }
    }
}
