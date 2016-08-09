using System.Threading.Tasks;
using AlexaJenkinsSkill.Lib.Entities;

namespace AlexaJenkinsSkill.Lib.Clients.Interfaces
{
    public interface IJenkinsClient {
        Task BuildWithParametersAsync(BuildWithParametersRequest request);
    }
}
