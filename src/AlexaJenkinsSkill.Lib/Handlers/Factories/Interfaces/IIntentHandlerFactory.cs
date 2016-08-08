using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexaJenkinsSkill.Lib.Handlers.Interfaces;
using AlexaSkillsKit.Slu;

namespace AlexaJenkinsSkill.Lib.Handlers.Factories.Interfaces
{
    public interface IIntentHandlerFactory {
        IIntentHandler CreateIntentHandler(Intent intent);
    }
}
