using Fmarketer.Base;
using Fmarketer.Base.Enums;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models.Dto;
using Fmarketer.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fmarketer.Business
{
    public class UserManagement
    {
        CredentialRepository credentialRepository;
        UserRepository userRepository;
        AdminRepository adminRepository;
        ConsultantRepository consultantRepository;
        SecurityTokenRepository securityTokenRepository;

        public UserManagement(CredentialRepository credentialRepository, UserRepository userRepository, AdminRepository adminRepository, 
            ConsultantRepository consultantRepository, SecurityTokenRepository securityTokenRepository)
        {
            this.credentialRepository = credentialRepository;
            this.userRepository = userRepository;
            this.adminRepository = adminRepository;
            this.consultantRepository = consultantRepository;
            this.securityTokenRepository = securityTokenRepository;
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
                    credential._User = user;
                    break;
                case USERTYPES.Consultant:
                    var consultant = await CreateConsultantAsync(dto, credential);
                    credential._Consultant = consultant;
                    break;
                case USERTYPES.Admin:
                    var admin = await CreateAdminAsync(dto, credential);
                    credential._Admin = admin;
                    break;
                case USERTYPES.SuperAdmin:
                    break;
                default:
                    break;
            }

            // Update Credential
            credentialRepository.Update(credential);

            return new AddUserOutputDto(credential);
        }

        public async Task UpdateUserAsync(UpdateUserDto dto)
        {
            // Check Credential
            var credential = await CheckTokenAsync(dto.Token);

            if (credential == null) {
                throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
            }

            // Check permission to update
            if (credential.UserType == USERTYPES.Admin || credential.UserType == USERTYPES.SuperAdmin) {
                // Admin can update any user
                await UpdateUserForAdminAsync(dto); 
            }
            else if (credential.Id.Equals(new Guid(dto.Id))) {
                // Only can update if same user as logged in
                await UpdateUserForNormalAsync(dto);
            }

            throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
        }

        public async Task DeleteUserAsync(DeleteUserDto dto)
        {
            // Check Credential
            var credential = await CheckTokenAsync(dto.Token);

            if (credential == null) {
                throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
            }

            // Check permission to update
            if (credential.UserType == USERTYPES.Admin || credential.UserType == USERTYPES.SuperAdmin) {
                // Admin can update any user
                await DeleteAsync(new Guid(dto.Id));
            } else if (credential.Id.Equals(new Guid(dto.Id))) {
                // Only can update if same user as logged in
                await DeleteAsync(new Guid(dto.Id));
            }

            throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
        }

        public async Task<GetUserOutputDto> GetUsersAsync(GetUserDto dto)
        {
            // Check Credential
            var credential = await CheckTokenAsync(dto.Token);

            if (credential == null) {
                throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
            }

            // Check permission to update
            if (credential.UserType == USERTYPES.Admin || credential.UserType == USERTYPES.SuperAdmin) {
                // Admin can update any user
                var user = await credentialRepository.GetAll();

                var output = new GetUserOutputDto() {
                    Credentials = user.ToList()
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

        private async Task<Credential> CheckTokenAsync(string token)
        {
            var secToken = await securityTokenRepository.CheckAndUpdateAsync(new Guid(token));

            if (secToken == null) {
                throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
            }

            return secToken._Credential;
        }

        private async Task UpdateUserForNormalAsync(UpdateUserDto dto)
        {
            var credential = await credentialRepository.Get(new Guid(dto.Id));

            if (credential == null) {
                throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
            }

            // Update Credential
            credential.Password = (!string.IsNullOrEmpty(dto.Password)) ? dto.Password : credential.Password;
            credentialRepository.Update(credential);

            // Update User
            switch (credential.UserType) {
                case USERTYPES.User:
                    await UpdateUser(dto, credential._User.Id);
                    break;
                case USERTYPES.Consultant:
                    await UpdateConsultant(dto, credential._Consultant.Id);
                    break;
                case USERTYPES.Admin:
                    await UpdateAdmin(dto, credential._Admin.Id);
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
            credential.Password = (!string.IsNullOrEmpty(dto.Password)) ? dto.Password : credential.Password;
            credential.Verified = dto.Verified ?? credential.Verified;
            credentialRepository.Update(credential);

            // Update User
            switch (credential.UserType) {
                case USERTYPES.User:
                    await UpdateUser(dto, credential._User.Id);
                    break;
                case USERTYPES.Consultant:
                    await UpdateConsultant(dto, credential._Consultant.Id);
                    break;
                case USERTYPES.Admin:
                    await UpdateAdmin(dto, credential._Admin.Id);
                    break;
                case USERTYPES.SuperAdmin:
                    break;
                default:
                    break;
            }
        }

        private async Task UpdateUser(UpdateUserDto dto, Guid Id)
        {
            var user = await userRepository.Get(Id);

            user.Contact = (!string.IsNullOrEmpty(dto.Contact)) ? dto.Contact : user.Contact;
            user.FirstName = (!string.IsNullOrEmpty(dto.FirstName)) ? dto.FirstName : user.FirstName;
            user.LastName = (!string.IsNullOrEmpty(dto.LastName)) ? dto.LastName : user.LastName;
            user.ShowContact = dto.ShowContact ?? user.ShowContact;
            user.ShowEmail = dto.ShowEmail ?? user.ShowEmail;

            userRepository.Update(user);
        }

        private async Task UpdateAdmin(UpdateUserDto dto, Guid Id)
        {
            var admin = await adminRepository.Get(Id);

            admin.Contact = (!string.IsNullOrEmpty(dto.Contact)) ? dto.Contact : admin.Contact;
            admin.FirstName = (!string.IsNullOrEmpty(dto.FirstName)) ? dto.FirstName : admin.FirstName;
            admin.LastName = (!string.IsNullOrEmpty(dto.LastName)) ? dto.LastName : admin.LastName;

            adminRepository.Update(admin);
        }

        private async Task UpdateConsultant(UpdateUserDto dto, Guid Id)
        {
            var consultant = await consultantRepository.Get(Id);

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
                    userRepository.Remove(credential._User);
                    break;
                case USERTYPES.Consultant:
                    consultantRepository.Remove(credential._Consultant);
                    break;
                case USERTYPES.Admin:
                    adminRepository.Remove(credential._Admin);
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
