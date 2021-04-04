using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Linq;

namespace RallyBus.RoleForUser
{
    public static class GetRolesForUser
    {
        [FunctionName("GetRolesForUser")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            
            string userId = req.Query["objectId"];

            List<Role> rolesList = new List<Role>();
            string[] roles = {};
            RoleArray rolesArray = new RoleArray();
            rolesArray.roles = roles;

             using (var client = new HttpClient())
                {

                    string tokenURL = "https://login.microsoftonline.com/demo.onmicrosoft.com/oauth2/v2.0/token";

                    var requestContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "client_credentials"),
                        new KeyValuePair<string, string>("client_id", ""),
                        new KeyValuePair<string, string>("scope", "https://graph.microsoft.com/.default"),
                        new KeyValuePair<string, string>("client_secret", "")
                    });


                    var response1 = await client.PostAsync(tokenURL, requestContent);
                    var responseContent = await response1.Content.ReadAsStringAsync();

                    var tokenObj = Newtonsoft.Json.Linq.JObject.Parse(responseContent);
                    JToken accessToke = tokenObj.GetValue("access_token");
                    string accessToken = tokenObj.GetValue("access_token").Value<string>();

                    string requestUrl = $"https://graph.microsoft.com/v1.0/users/{userId}/memberOf?$select=displayName";

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    HttpResponseMessage response = await client.SendAsync(request);

                    if(response.StatusCode == System.Net.HttpStatusCode.OK){
                        var responseString = await response.Content.ReadAsStringAsync();
                        var rolesData = JObject.Parse(responseString);

                        if(rolesData["value"].HasValues){
                            var groups = rolesData["value"];
                            rolesList = groups.ToObject<List<Role>>();
                            roles = rolesList.Select(r => r.displayName).ToArray();
                            rolesArray.roles = roles;
                        }    
                    }                            
                }         

            return new OkObjectResult(rolesArray);
        }
    }

    public class Role{
        public string displayName { get; set; }
    }

    public class RoleArray{
        public string[] roles { get; set; }
    }
}
