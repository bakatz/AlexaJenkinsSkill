using System;
using System.Threading.Tasks;
using AlexaJenkinsSkill.Lib.Handlers.Factories.Interfaces;
using AlexaJenkinsSkill.Lib.Helpers;
using AlexaJenkinsSkill.Lib.Speechlets.Interfaces;
using AlexaSkillsKit.Authentication;
using AlexaSkillsKit.Json;
using AlexaSkillsKit.Speechlet;

namespace AlexaJenkinsSkill.Lib.Speechlets
{
    public class JenkinsSpeechlet : SpeechletAsync, IJenkinsSpeechlet
    {
        private readonly IIntentHandlerFactory _intentHandlerFactory;

        public JenkinsSpeechlet(IIntentHandlerFactory intentHandlerFactory) {
            _intentHandlerFactory = intentHandlerFactory;
        }

        public override async Task<SpeechletResponse> OnIntentAsync(IntentRequest intentRequest, Session session) {
            var handler = _intentHandlerFactory.CreateIntentHandler(intentRequest.Intent);
            return await handler.HandleAsync().ConfigureAwait(false);
        }

        // TODO: not sure what this is/doesn't seem useful for now. maybe move into a base class at some point just to get it out of the way.
        public override Task<SpeechletResponse> OnLaunchAsync(LaunchRequest launchRequest, Session session) {
            const string onLaunchName = "OnLaunch";
            return Task.FromResult(SpeechletHelper.BuildPlainTextResponse(GetType().Name, onLaunchName, onLaunchName));
        }

        public override Task OnSessionStartedAsync(SessionStartedRequest sessionStartedRequest, Session session) {
            return Task.CompletedTask;
        }

        public override Task OnSessionEndedAsync(SessionEndedRequest sessionEndedRequest, Session session) {
            return Task.CompletedTask;
        }

        public override bool OnRequestValidation(SpeechletRequestValidationResult result, DateTime referenceTimeUtc,
            SpeechletRequestEnvelope requestEnvelope) {
            return true;
        }
    }
}
