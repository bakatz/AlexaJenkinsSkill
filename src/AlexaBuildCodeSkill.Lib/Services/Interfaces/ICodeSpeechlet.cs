using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AlexaSkillsKit.Speechlet;

namespace AlexaBuildCodeSkill.Lib.Services.Interfaces
{
    public interface ICodeSpeechlet : ISpeechletAsync {
        Task<HttpResponseMessage> GetResponseAsync(HttpRequestMessage httpRequest);
    }
}
