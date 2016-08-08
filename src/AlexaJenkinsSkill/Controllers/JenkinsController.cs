using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AlexaJenkinsSkill.Lib.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlexaJenkinsSkill.Controllers
{
    public class JenkinsController : ApiController // TODO: using a shim for ApiController because the alexa library is for the old version of .net
    {
        private readonly ICodeSpeechlet _speechlet;

        public JenkinsController(ICodeSpeechlet speechlet) {
            _speechlet = speechlet;
        }

        [HttpPost]
        [Route("api/jenkins/build")]
        public async Task<HttpResponseMessage> BuildAsync() {
            return await _speechlet.GetResponseAsync(Request);
        }

        [HttpGet]
        [Route("api/jenkins/ping")]
        public string Ping() {
            return "Pong";
        }
    }
}
