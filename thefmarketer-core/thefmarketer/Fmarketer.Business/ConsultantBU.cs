using Fmarketer.DataAccess.Repository;
using Fmarketer.Models.Dto;

namespace Fmarketer.Business
{
    public class ConsultantBU
    {
        SecurityTokenRepository securityTokenRepository;
        ConsultantRepository consultantRepository;
        ConsultantCoverageRepository coverageRepository;
        ConsultantServiceRepository serviceRepository;
        RequestRepository requestRepository;
        ChatRepository chatRepository;
        SecurityTokenBU securityTokenBU;

        public ConsultantBU(SecurityTokenRepository securityToken, ConsultantRepository consultant, ConsultantCoverageRepository coverage, 
            ConsultantServiceRepository service, RequestRepository request, ChatRepository chat)
        {
            securityTokenRepository = securityToken;
            consultantRepository = consultant;
            coverageRepository = coverage;
            serviceRepository = service;
            requestRepository = request;
            chatRepository = chat;

            securityTokenBU = new SecurityTokenBU(securityTokenRepository);
        }

        public void AddState(AddStateDto dto)
        {

        }

        public void AddService(AddServiceDto dto)
        {

        }

        public void UpdateState(UpdateStateDto dto)
        {

        }

        public void UpdateService(UpdateServiceDto dto)
        {

        }

        public SearchRequestOutputDto SearchRequest(SearchRequestDto dto)
        {

        }
    }
}
