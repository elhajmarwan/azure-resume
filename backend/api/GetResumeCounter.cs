using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(   databaseName: "Counter_db", containerName: "Counter_container", Connection = "CosmosDbConnectionSetting", Id = "1", PartitionKey = "1"
            )] Counter counter,
            // [CosmosDB(   databaseName: "Counter_db", containerName: "Counter_container", Connection = "CosmosDbConnectionSetting", Id = "1", PartitionKey = "1"
            // )] Counter updatedCounter,
            ILogger log)
        {
            log.LogInformation("Processing GetResumeCounter.");

            if (counter == null)
            {
                return new NotFoundObjectResult("Document not found.");
            }

            // Exemple de traitement
            counter.Count += 1;

            return new OkObjectResult(counter);

        }
    }

}
