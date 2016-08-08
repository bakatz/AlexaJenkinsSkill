using System.Net.Http;
using System.Threading.Tasks;
using AlexaSkillsKit.Speechlet;

namespace AlexaJenkinsSkill.Lib.Speechlets.Interfaces
{
    public interface IJenkinsSpeechlet : ISpeechletAsync {
        Task<HttpResponseMessage> GetResponseAsync(HttpRequestMessage httpRequest);
    }
}
