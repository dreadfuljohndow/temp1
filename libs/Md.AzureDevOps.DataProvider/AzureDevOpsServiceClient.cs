using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;

namespace Md.AzureDevOps.DataProvider
{
    public class AzureDevOpsServiceClient
    {
        private string personalAccessToken = "";

        private Uri  uri = new Uri ( "https://dev.azure.com");

        public void LoadData()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///     Execute a WIQL (Work Item Query Language) query to return a list of open bugs.
        /// </summary>
        /// <param name="project">The name of your project within your organization.</param>
        /// <returns>A list of <see cref="WorkItem"/> objects representing all the open bugs.</returns>
        public async Task<IList<WorkItem>> QueryOpenBugs(string project)
        {
            throw new NotImplementedException();
        }


        //[System.Convert]::ToBase64String([System.Text.Encoding]::ASCII.GetBytes(":$($token)"));

        //    $JSON = @'
        //    {
        //        "query": "SELECT [System.Id],[System.Title],[System.State] FROM workitems WHERE [System.TeamProject] = @project AND [system.WorkItemType] = 'Task' AND [System.State]='Done' "
        //    }
        //'@

        //    $response = Invoke-RestMethod -Uri $url -Headers @{Authorization = "Basic $token"} -Method Post -Body $JSON -ContentType application/json

        //Write-Host "result = $($response | ConvertTo-Json -Depth 100)"
    }
}
