using Fmarketer.Base;
using Fmarketer.Base.Enums;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models.Dto;
using Fmarketer.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fmarketer.Business
{
    public class UserBU
    {
        SecurityTokenRepository securityTokenRepository;
        ConsultantRepository consultantRepository;
        RequestRepository requestRepository;
        ReviewRepository reviewRepository;
        ChatRepository chatRepository;
        SecurityTokenBU securityTokenBU;

        public UserBU(SecurityTokenRepository securityToken, ConsultantRepository consultant, 
            RequestRepository request, ReviewRepository review, ChatRepository chat, UserRepository user)
        {
            securityTokenRepository = securityToken;
            consultantRepository = consultant;
            requestRepository = request;
            reviewRepository = review;
            chatRepository = chat;

            securityTokenBU = new SecurityTokenBU(securityTokenRepository, user, null, null);
        }

        public async Task<SearchConsultantOutputDto> SearchConsultantAsync(SearchConsultantDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);

            var consultants = consultantRepository.Find(c => !c.IsDeleted &&
                ((c.FirstName + " " + c.LastName).Contains(dto.Name) || string.IsNullOrEmpty(dto.Name)) &&
                c._Coverages.Any(v => v.State == dto.State.Value || !dto.State.HasValue) &&
                c._Services.Any(s => s.Service == dto.Service.Value || !dto.Service.HasValue) &&
                (c._Requests.Average(r => r._Review.Star) >= dto.MinRating.Value || !dto.MinRating.HasValue) &&
                (c._Requests.Average(r => r._Review.Star) <= dto.MaxRating.Value || !dto.MaxRating.HasValue));

            return new SearchConsultantOutputDto(consultants.ToList());
        }

        public async Task<SearchRequestOutputDto> SearchRequestAsync(SearchRequestDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);

            if (credential.Credential.UserType == USERTYPES.User) {
                var user = credential.User;
                var requests = user._Requests.FindAll(r => (r.Service == dto.Service.Value || !dto.Service.HasValue) &&
                    ((r._Consultant.FirstName + "" + r._Consultant.LastName).Contains(dto.Name) || string.IsNullOrEmpty(dto.Name))).OrderBy(x => x.Updated);

                return new SearchRequestOutputDto(requests.ToList());
            }

            throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
        }

        public async Task CreateRequestAsync(CreateRequestDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);
            var consultant = await consultantRepository.Get(new Guid(dto.ConsultantId));

            if (credential.Credential.UserType == USERTYPES.User) {
                var request = new Request() {
                    Message = dto.Message,
                    Service = dto.Service,
                    _User = credential.User,
                    _Consultant = consultant
                };

                await requestRepository.AddAsync(request);
            } 

            throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
        }

        public async Task SendChatAsync(SendChatDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);
            var request = await requestRepository.Get(new Guid(dto.RequestId));

            if (credential.Credential.UserType == USERTYPES.User) {
                var chat = new Chat() {
                    Message = dto.Message,
                    IsRead = false,
                    From = USERTYPES.User,
                    _Request = request
                };

                chat = await chatRepository.AddAsync(chat);

                request._Chats.Add(chat);
                requestRepository.Update(request);
            }

            throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
        }

        public async Task UpdateRequestAsync(UpdateRequestDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);
            var request = await requestRepository.Get(new Guid(dto.RequestId));

            if (request != null) {
                if (credential.Credential.UserType == USERTYPES.User && credential.User == request._User) {
                    if(!request.IsCompleted) {
                        request.IsActive = dto.IsActive ?? request.IsActive;
                        requestRepository.Update(request);
                    }
                }
            }

            throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
        }

        public async Task CompleteRequestAsync(CompleteRequestDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);
            var request = await requestRepository.Get(new Guid(dto.RequestId));

            if (credential.Credential.UserType == USERTYPES.User) {
                var review = new Review() {
                    IsPublic = dto.IsPublic,
                    Message = dto.Message,
                    Star = dto.Star                    
                };

                review = await reviewRepository.AddAsync(review);

                request.IsCompleted = true;
                request._Review = review;

                requestRepository.Update(request);
            }

            throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
        }
    }
}
