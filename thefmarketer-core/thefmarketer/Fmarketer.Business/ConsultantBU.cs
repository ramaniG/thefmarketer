using Fmarketer.Base;
using Fmarketer.Base.Enums;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models;
using Fmarketer.Models.Dto;
using Fmarketer.Models.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        UnitOfWork unitOfWork;

        public ConsultantBU(UnitOfWork unit, SecurityTokenRepository securityToken, ConsultantRepository consultant, ConsultantCoverageRepository coverage, 
            ConsultantServiceRepository service, RequestRepository request, ChatRepository chat)
        {
            securityTokenRepository = securityToken;
            consultantRepository = consultant;
            coverageRepository = coverage;
            serviceRepository = service;
            requestRepository = request;
            chatRepository = chat;

            unitOfWork = unit;

            securityTokenBU = new SecurityTokenBU(unit, securityTokenRepository, null, consultant, null);
        }

        public async Task AddStateAsync(AddStateDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);            

            if (credential.Credential.UserType == USERTYPES.Consultant) {
                if (!(credential.Consultant._Coverages.Exists(c => c.State == dto.State))) {
                    var consultant = credential.Consultant;
                    var coverage = new ConsultantCoverage() {
                        Location = dto.Location,
                        State = dto.State,
                        _Consultant = consultant
                    };

                    coverage = await coverageRepository.AddAsync(coverage);
                    await unitOfWork.Complete();
                }
            }

            throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
        }

        public async Task AddServiceAsync(AddServiceDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);

            if (credential.Credential.UserType == USERTYPES.Consultant) {
                var consultant = credential.Consultant;
                var service = new ConsultantService() {
                    ActiveSince = dto.ActiveSince,
                    ClientScale = dto.ClientScale,
                    Company = dto.Company,
                    LicenseActive = dto.LicenseActive,
                    Proof = dto.Proof,
                    RegistrationNo = dto.RegistrationNo,
                    Service = dto.Service,
                    YearsOfExp = dto.YearsOfExp,
                    _Consultant = consultant
                };

                service = await serviceRepository.AddAsync(service);
                await unitOfWork.Complete();
            }

            throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
        }

        public async Task UpdateStateAsync(UpdateStateDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);

            if (credential.Credential.UserType == USERTYPES.Consultant) {
                var coverage = await coverageRepository.Get(new Guid(dto.CoverageId));
                if (coverage != null) {
                    coverage.Location = (!string.IsNullOrEmpty(dto.Location)) ? dto.Location : coverage.Location;
                    coverage.State = (dto.State) ?? coverage.State;
                    coverage.IsDeleted = (dto.IsDeleted) ?? coverage.IsDeleted;

                    coverageRepository.Update(coverage);
                    await unitOfWork.Complete();
                }
            }

            throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
        }

        public async Task UpdateServiceAsync(UpdateServiceDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);

            if (credential.Credential.UserType == USERTYPES.Consultant) {
                var service = await serviceRepository.Get(new Guid(dto.ServiceId));
                if (service != null) {
                    service.ActiveSince = (dto.ActiveSince) ?? service.ActiveSince;
                    service.ClientScale = (dto.ClientScale) ?? service.ClientScale;
                    service.Company = (!string.IsNullOrEmpty(dto.Company)) ? dto.Company : service.Company;
                    service.LicenseActive = (dto.LicenseActive) ?? service.LicenseActive;
                    service.Proof = (!string.IsNullOrEmpty(dto.Proof)) ? dto.Proof : service.Proof;
                    service.RegistrationNo = (!string.IsNullOrEmpty(dto.RegistrationNo)) ? dto.RegistrationNo : service.RegistrationNo;
                    service.Service = (dto.Service) ?? service.Service;
                    service.YearsOfExp = (dto.YearsOfExp) ?? service.YearsOfExp;
                    service.IsDeleted = (dto.IsDeleted) ?? service.IsDeleted;

                    serviceRepository.Update(service);
                    await unitOfWork.Complete();
                }
            }

            throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
        }

        public async Task<SearchRequestOutputDto> SearchRequestAsync(SearchRequestDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);

            if (credential.Credential.UserType == USERTYPES.Consultant) {
                var consultant = credential.Consultant;
                var requests = consultant._Requests.FindAll(r => (r.Service == dto.Service.Value || !dto.Service.HasValue) &&
                    ((r._User.FirstName + "" + r._User.LastName).Contains(dto.Name) || string.IsNullOrEmpty(dto.Name))).OrderBy(x => x.Updated);

                return new SearchRequestOutputDto(requests.ToList());
            }

            throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
        }

        public async Task SendChatAsync(SendChatDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);
            var request = await requestRepository.Get(new Guid(dto.RequestId));

            if (credential.Credential.UserType == USERTYPES.Consultant) {
                var chat = new Chat() {
                    Message = dto.Message,
                    IsRead = false,
                    From = USERTYPES.Consultant,
                    _Request = request
                };

                chat = await chatRepository.AddAsync(chat);

                request._Chats.Add(chat);
                requestRepository.Update(request);

                await unitOfWork.Complete();
            }

            throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
        }
    }
}
