using System.Threading.Tasks;
using AlexaJenkinsSkill.Lib.Services.Interfaces;
using AlexaSkillsKit.Speechlet;
using Microsoft.Extensions.Logging;

namespace AlexaJenkinsSkill.Lib.Services
{
    public class CodeSpeechlet : SpeechletAsync, ICodeSpeechlet
    {
        private readonly ILogger<CodeSpeechlet> _logger;

        public CodeSpeechlet(ILogger<CodeSpeechlet> logger) {
            _logger = logger;
        }

        public override Task<SpeechletResponse> OnIntentAsync(IntentRequest intentRequest, Session session) {
            _logger.LogInformation("Beginning OnIntentAsync");
            _logger.LogInformation("Ending OnIntentAsync");
            return null;
        }

        public override Task<SpeechletResponse> OnLaunchAsync(LaunchRequest launchRequest, Session session) {
            _logger.LogInformation("Beginning OnLaunchAsync");
            _logger.LogInformation("Ending OnLaunchAsync");
            return null;
        }

        public override Task OnSessionStartedAsync(SessionStartedRequest sessionStartedRequest, Session session) {
            _logger.LogInformation("Beginning OnSessionStartedAsync");
            _logger.LogInformation("Ending OnSessionStartedAsync");
            return Task.CompletedTask;
        }

        public override Task OnSessionEndedAsync(SessionEndedRequest sessionEndedRequest, Session session) {
            _logger.LogInformation("Beginning OnSessionEndedAsync");
            _logger.LogInformation("Ending OnSessionEndedAsync");
            return Task.CompletedTask;
        }
    }
}
