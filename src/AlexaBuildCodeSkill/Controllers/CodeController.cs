using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using AlexaBuildCodeSkill.Lib.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlexaBuildCodeSkill.Controllers
{
    public class CodeController : ApiController // TODO: using a shim for ApiController because the alexa library is for the old version of .net
    {
        private readonly ICodeSpeechlet _speechlet;

        public CodeController(ICodeSpeechlet speechlet) {
            _speechlet = speechlet;
        }

        // POST api/code/build
        [HttpPost]
        [Route("api/code/build")]
        public async Task<HttpResponseMessage> BuildAsync() {
            return await _speechlet.GetResponseAsync(Request);
        }
    }
}
