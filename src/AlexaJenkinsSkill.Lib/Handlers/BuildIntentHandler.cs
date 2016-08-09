using System.Threading.Tasks;
using AlexaJenkinsSkill.Lib.Clients.Interfaces;
using AlexaJenkinsSkill.Lib.Entities;
using AlexaJenkinsSkill.Lib.Handlers.Interfaces;
using AlexaJenkinsSkill.Lib.Helpers;
using AlexaSkillsKit.Speechlet;

namespace AlexaJenkinsSkill.Lib.Handlers
{
    public class BuildIntentHandler : IIntentHandler
    {
        private readonly IJenkinsClient _jenkinsClient;
        private readonly string _environmentName;

        public BuildIntentHandler(IJenkinsClient jenkinsClient, string environmentName) {
            _jenkinsClient = jenkinsClient;
            _environmentName = environmentName;
        }

        public async Task<SpeechletResponse> HandleAsync() {
            if (string.IsNullOrWhiteSpace(_environmentName)) {
                return SpeechletHelper.BuildPlainTextResponse("Build", "Build", "Sorry, I didn't understand what you were trying to build.");
            }

            await _jenkinsClient.BuildWithParametersAsync(new BuildWithParametersRequest() {Name = $"{_environmentName}.Deploy"}).ConfigureAwait(false);
            return SpeechletHelper.BuildPlainTextResponse("Build", "Build", $"Ok, I started the {_environmentName} build for you.");
        }
    }
}
