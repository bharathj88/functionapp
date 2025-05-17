using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

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
        public void Run([BlobTrigger("")]Stream myBlob, string name,Uri uri, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
            // Example: Add a new song to the database
            var song = new Song
            {
                Title = "Example Song",
                Artist = "Example Artist",
                ReleaseDate = DateTime.UtcNow
            };

            _dbContext.Songs.Add(song);
            _dbContext.SaveChanges();
            
        }
    }
}
