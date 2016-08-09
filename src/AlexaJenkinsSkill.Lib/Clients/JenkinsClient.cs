using System;
using System.Net;
using System.Threading.Tasks;
using AlexaJenkinsSkill.Lib.Clients.Interfaces;
using AlexaJenkinsSkill.Lib.Entities;
using AlexaJenkinsSkill.Lib.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace AlexaJenkinsSkill.Lib.Clients
{
    public class JenkinsClient : IJenkinsClient
    {
        private readonly IOptions<JenkinsOptions> _jenkinsOptions;
        private readonly ILogger<JenkinsClient> _logger;

        public JenkinsClient(IOptions<JenkinsOptions> jenkinsOptions, ILogger<JenkinsClient> logger) {
            _jenkinsOptions = jenkinsOptions;
            _logger = logger;
        }

        public async Task BuildWithParametersAsync(BuildWithParametersRequest request) {
            if (request == null) {
                throw new ArgumentNullException(nameof(request));
            }

            var client = new RestClient(_jenkinsOptions.Value.JenkinsBaseUri) {
                Authenticator = new HttpBasicAuthenticator(_jenkinsOptions.Value.JenkinsUserName, _jenkinsOptions.Value.JenkinsApiKey)
            };

            var restRequest = new RestRequest($"/job/{request.Name.ToLower()}/buildWithParameters", Method.POST);
            restRequest.AddQueryParameter("token", _jenkinsOptions.Value.JenkinsAuthenticationToken);
            restRequest.AddQueryParameter("PublishRoles", "All");

            var response = await client.ExecutePostTaskAsync(restRequest);
            if (response?.StatusCode != HttpStatusCode.Created) {
                throw new InvalidOperationException("Jenkins returned an unexpected response.");
            }
        }
    }
}
