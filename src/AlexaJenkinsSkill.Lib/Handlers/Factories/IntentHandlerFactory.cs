using System;
using AlexaJenkinsSkill.Lib.Clients.Interfaces;
using AlexaJenkinsSkill.Lib.Handlers.Factories.Interfaces;
using AlexaJenkinsSkill.Lib.Handlers.Interfaces;
using AlexaSkillsKit.Slu;

namespace AlexaJenkinsSkill.Lib.Handlers.Factories
{
    public class IntentHandlerFactory : IIntentHandlerFactory
    {
        private readonly IJenkinsClient _jenkinsClient;
        private const string BuildIntent = "Build";

        public IntentHandlerFactory(IJenkinsClient jenkinsClient) {
            _jenkinsClient = jenkinsClient;
        }

        public IIntentHandler CreateIntentHandler(Intent intent) {
            if (intent == null) {
                throw new ArgumentNullException(nameof(intent));
            }

            switch (intent.Name) {
                case BuildIntent:
                    return new BuildIntentHandler(_jenkinsClient, intent.Slots["Environment"].Value);
                default:
                    throw new InvalidOperationException($"{intent.Name} is not supported.");
            }
        }
    }
}
