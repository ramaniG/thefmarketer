using Fmarketer.DataAccess.Repository;
using Fmarketer.Models.Dto;
using Fmarketer.Models.Model;
using System;

namespace Fmarketer.Business
{
    public class Authentication
    {
        UserRepository _userRepository;

        public Authentication(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(LoginDto loginDto)
        {
            var user = _userRepository.FindByEmail(loginDto.Email);

            if (user != null)
            {
                if (BCrypt.BCryptHelper.CheckPassword(loginDto.Password, user.Password))
                {
                    user.LastLogin = DateTime.Now;
                    _userRepository.Update(user);
                    return user;
                }
            }

            return null;
        }
    }
}
