using System.Threading.Tasks;
using AlexaSkillsKit.Speechlet;

namespace AlexaJenkinsSkill.Lib.Handlers.Interfaces
{
    public interface IIntentHandler {
        Task<SpeechletResponse> HandleAsync();
    }
}
