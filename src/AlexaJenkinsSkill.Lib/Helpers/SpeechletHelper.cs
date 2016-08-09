using AlexaSkillsKit.Speechlet;
using AlexaSkillsKit.UI;

namespace AlexaJenkinsSkill.Lib.Helpers
{
    public static class SpeechletHelper
    {
        public static SpeechletResponse BuildPlainTextResponse(string speechletName, string title, string output) {
            // Create the Simple card content.
            SimpleCard card = new SimpleCard {
                Title = $"{speechletName} - {title}",
                Content = $"{speechletName} - {output}"
            };

            // Create the plain text output.
            PlainTextOutputSpeech speech = new PlainTextOutputSpeech { Text = output };

            // Create the speechlet response.
            SpeechletResponse response = new SpeechletResponse {
                ShouldEndSession = true,
                OutputSpeech = speech,
                Card = card
            };
            return response;
        }
    }
}
