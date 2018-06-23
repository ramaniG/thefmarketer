using Fmarketer.Base;
using Fmarketer.Base.Enums;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models;
using Fmarketer.Models.Dto;
using Fmarketer.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fmarketer.Business
{
    public class MembershipBU
    {
        CredentialRepository credentialRepository;
        UserRepository userRepository;
        AdminRepository adminRepository;
        ConsultantRepository consultantRepository;
        SecurityTokenRepository securityTokenRepository;
        SecurityTokenBU securityTokenBU;

        UnitOfWork unitOfWork;

        public MembershipBU(UnitOfWork unit, CredentialRepository credential, UserRepository user, AdminRepository admin, ConsultantRepository consultant, SecurityTokenRepository securityToken)
        {
            credentialRepository = credential;
            userRepository = user;
            adminRepository = admin;
            consultantRepository = consultant;
            securityTokenRepository = securityToken;

            unitOfWork = unit;

            securityTokenBU = new SecurityTokenBU(unit, securityTokenRepository, user, consultant, admin);
        }

        public async Task<AddUserOutputDto> AddUserAsync(AddUserDto dto)
        {
            // TODO : Add new user based on different auth type

            // Create Credential
            var credential = await CreateCredentialAsync(dto);

            // Create User
            switch (dto.UserType) {
                case USERTYPES.User:
                    var user = await CreateUserAsync(dto, credential);
                    await unitOfWork.Complete();
                    return new AddUserOutputDto(credential, user);
                case USERTYPES.Consultant:
                    var consultant = await CreateConsultantAsync(dto, credential);
                    await unitOfWork.Complete();
                    return new AddUserOutputDto(credential, consultant);
                case USERTYPES.Admin:
                    var admin = await CreateAdminAsync(dto, credential);
                    await unitOfWork.Complete();
                    return new AddUserOutputDto(credential, admin);
                case USERTYPES.SuperAdmin:
                    break;
                default:
                    break;
            }

            return null;
        }

        public async Task UpdateUserAsync(UpdateUserDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);

            if (credential == null) {
                throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
            }

            // Check permission to update
            if (credential.Credential.UserType == USERTYPES.Admin || credential.Credential.UserType == USERTYPES.SuperAdmin) {
                // Admin can update any user
                await UpdateUserForAdminAsync(dto);
            } else if (credential.Credential.Id.Equals(new Guid(dto.Id))) {
                // Only can update if same user as logged in
                await UpdateUserForNormalAsync(dto);
            } else {
                throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
            }

            await unitOfWork.Complete();
        }

        public async Task DeleteUserAsync(DeleteUserDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);

            if (credential == null) {
                throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
            }

            // Check permission to update
            if (credential.Credential.UserType == USERTYPES.Admin || credential.Credential.UserType == USERTYPES.SuperAdmin) {
                // Admin can update any user
                await DeleteAsync(new Guid(dto.Id));
            } else if (credential.Credential.Id.Equals(new Guid(dto.Id))) {
                // Only can update if same user as logged in
                await DeleteAsync(new Guid(dto.Id));
            } else {
                throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
            }

            await unitOfWork.Complete();
        }

        public async Task<GetUsersOutputDto> GetUsersAsync(GetUserDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);

            if (credential == null) {
                throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
            }

            // Check permission to update
            if (credential.Credential.UserType == USERTYPES.Admin || credential.Credential.UserType == USERTYPES.SuperAdmin) {
                // Admin can update any user
                var list = new List<GetUserOutputDto>();
                // Get Admin
                var admins = await adminRepository.GetAll();
                foreach (var item in admins) {
                    list.Add(new GetUserOutputDto(item._Credential, item));
                }

                // Get Consultants
                var consultants = await consultantRepository.GetAll();
                foreach (var item in consultants) {
                    list.Add(new GetUserOutputDto(item._Credential, item));
                }

                // Get Users
                var users = await userRepository.GetAll();
                foreach (var item in users) {
                    list.Add(new GetUserOutputDto(item._Credential, item));
                }

                var output = new GetUsersOutputDto() {
                    Users = list
                };

                return output;
            }

            throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
        }

        private async Task<Credential> CreateCredentialAsync(AddUserDto dto)
        {
            var credential = new Credential() {
                AuthType = dto.AuthType,
                CredentialState = CREDENTIALSTATUS.Active, // TODO : Update when verification process in place
                Email = dto.Email, // TODO : Change to handle diff auth types
                NumberOfTry = 0,
                Password = dto.Password,
                Verified = true, // TODO : To be updated 
                UserType = dto.UserType
            };

            return await credentialRepository.AddAsync(credential);
        }

        private async Task<User> CreateUserAsync(AddUserDto dto, Credential credential)
        {
            var user = new User() {
                Contact = dto.Contact,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                ShowContact = dto.ShowContact,
                ShowEmail = dto.ShowEmail,
                _Credential = credential
            };

            return await userRepository.AddAsync(user);
        }

        private async Task<Admin> CreateAdminAsync(AddUserDto dto, Credential credential)
        {
            var admin = new Admin() {
                Contact = dto.Contact,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                _Credential = credential
            };

            return await adminRepository.AddAsync(admin);
        }

        private async Task<Consultant> CreateConsultantAsync(AddUserDto dto, Credential credential)
        {
            var consultant = new Consultant() {
                Contact = dto.Contact,
                Contact2 = dto.Contact2,
                ContactOpt = dto.ContactOpt,
                ContactOpt2 = dto.ContactOpt2,
                Email = dto.Email,
                Email2 = dto.Email2,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                _Credential = credential
            };

            return await consultantRepository.AddAsync(consultant);
        }

        private async Task UpdateUserForNormalAsync(UpdateUserDto dto)
        {
            var credential = await credentialRepository.Get(new Guid(dto.Id));

            if (credential == null) {
                throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
            }

            // Update Credential
            if (!string.IsNullOrEmpty(dto.Password)) {
                credential.Password = dto.Password;
                credentialRepository.UpdateWithPassword(credential);
            } 

            // Update User
            switch (credential.UserType) {
                case USERTYPES.User:
                    UpdateUser(dto, credential.Id);
                    break;
                case USERTYPES.Consultant:
                    UpdateConsultant(dto, credential.Id);
                    break;
                case USERTYPES.Admin:
                    UpdateAdmin(dto, credential.Id);
                    break;
                case USERTYPES.SuperAdmin:
                    break;
                default:
                    break;
            }
        }

        private async Task UpdateUserForAdminAsync(UpdateUserDto dto)
        {
            var credential = await credentialRepository.Get(new Guid(dto.Id));

            if (credential == null) {
                throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
            }

            // Update Credential
            credential.CredentialState = dto.CredentialState ?? credential.CredentialState;
            credential.NumberOfTry = dto.NumberOfTry ?? credential.NumberOfTry;
            credential.Verified = dto.Verified ?? credential.Verified;

            if (string.IsNullOrEmpty(dto.Password)) {
                credentialRepository.Update(credential);
            } else {
                credential.Password = dto.Password;
                credentialRepository.UpdateWithPassword(credential);
            }


            // Update User
            switch (credential.UserType) {
                case USERTYPES.User:
                    UpdateUser(dto, credential.Id);
                    break;
                case USERTYPES.Consultant:
                    UpdateConsultant(dto, credential.Id);
                    break;
                case USERTYPES.Admin:
                    UpdateAdmin(dto, credential.Id);
                    break;
                case USERTYPES.SuperAdmin:
                    break;
                default:
                    break;
            }
        }

        private void UpdateUser(UpdateUserDto dto, Guid Id)
        {
            var user = userRepository.FindByCredential(Id);

            user.Contact = (!string.IsNullOrEmpty(dto.Contact)) ? dto.Contact : user.Contact;
            user.FirstName = (!string.IsNullOrEmpty(dto.FirstName)) ? dto.FirstName : user.FirstName;
            user.LastName = (!string.IsNullOrEmpty(dto.LastName)) ? dto.LastName : user.LastName;
            user.ShowContact = dto.ShowContact ?? user.ShowContact;
            user.ShowEmail = dto.ShowEmail ?? user.ShowEmail;

            userRepository.Update(user);
        }

        private void UpdateAdmin(UpdateUserDto dto, Guid Id)
        {
            var admin = adminRepository.FindByCredential(Id);

            admin.Contact = (!string.IsNullOrEmpty(dto.Contact)) ? dto.Contact : admin.Contact;
            admin.FirstName = (!string.IsNullOrEmpty(dto.FirstName)) ? dto.FirstName : admin.FirstName;
            admin.LastName = (!string.IsNullOrEmpty(dto.LastName)) ? dto.LastName : admin.LastName;

            adminRepository.Update(admin);
        }

        private void UpdateConsultant(UpdateUserDto dto, Guid Id)
        {
            var consultant = consultantRepository.FindByCredential(Id);

            consultant.Contact = (!string.IsNullOrEmpty(dto.Contact)) ? dto.Contact : consultant.Contact;
            consultant.Contact2 = (!string.IsNullOrEmpty(dto.Contact2)) ? dto.Contact2 : consultant.Contact2;
            consultant.ContactOpt = dto.ContactOpt ?? consultant.ContactOpt;
            consultant.ContactOpt2 = dto.ContactOpt2 ?? consultant.ContactOpt2;
            consultant.Email2 = (!string.IsNullOrEmpty(dto.Email2)) ? dto.Email2 : consultant.Email2;
            consultant.FirstName = (!string.IsNullOrEmpty(dto.FirstName)) ? dto.FirstName : consultant.FirstName;
            consultant.LastName = (!string.IsNullOrEmpty(dto.LastName)) ? dto.LastName : consultant.LastName;

            consultantRepository.Update(consultant);
        }

        private async Task DeleteAsync(Guid Id)
        {
            var credential = await credentialRepository.Get(Id);

            if (credential == null) {
                throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
            }

            // Delete User
            switch (credential.UserType) {
                case USERTYPES.User:
                    var user = userRepository.FindByCredential(credential.Id);
                    userRepository.Remove(user);
                    break;
                case USERTYPES.Consultant:
                    var cons = consultantRepository.FindByCredential(credential.Id);
                    consultantRepository.Remove(cons);
                    break;
                case USERTYPES.Admin:
                    var admin = adminRepository.FindByCredential(credential.Id);
                    adminRepository.Remove(admin);
                    break;
                case USERTYPES.SuperAdmin:
                    break;
                default:
                    break;
            }

            credentialRepository.Remove(credential);
        }
    }
}
