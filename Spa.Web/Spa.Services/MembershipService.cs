using Spa.Services.Abstract;
using System;
using System.Collections.Generic;
using Spa.Entities;
using Spa.Services.Utilities;
using Spa.Data.Repository;
using Spa.Data.Infrastructure;
using Spa.Data.Extension;
using System.Linq;
using System.Security.Principal;

namespace Spa.Services
{
    public class MembershipService : IMembershipService
    {
        #region PrivateMembers
        private IEntityBaseRepository<User> _userRepository;
        private IEntityBaseRepository<Role> _roleRepository;
        private IEntityBaseRepository<UserRole> _userRoleRepository;
        private IUnitOfWork _unitOfWork;
        private IEncryption _encryptionService;
        #endregion

        #region HelperMethods
        private void AddRoleToUser(User user, int roleId)
        {
            var role = _roleRepository.GetSingle(roleId);
            if (null == role)
                throw (new Exception("Role doesn't exists"));

            var userRole = new UserRole() { UserId = user.Id, RoleId = roleId };
            _userRoleRepository.Add(userRole);
        }

        private bool IsPasswordValid(User user, string password)
        {
            return string.Equals(user.HashedPassword, _encryptionService.EncryptPassword(password, user.PasswordSalt));
        }

        private bool IsUserValid(User user, string password)
        {
            if(IsPasswordValid(user, password))
            {
                return !user.IsLocked;
            }
            return false;
        }
        #endregion

        public MembershipService(IEntityBaseRepository<User> userRepository,IEntityBaseRepository<Role> roleRepository, 
            IEntityBaseRepository<UserRole> userRoleRepository, IUnitOfWork unitOfWork, IEncryption encryptionService)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;
            _encryptionService = encryptionService;
        }

        public User Createuser(string userName, string fullName, string password, string email, int[] roles)
        {
            var existingUser = _userRepository.GetSingleByUserName(userName);

            if(null != existingUser)
            {
                throw (new Exception("User already exists"));
            }

            var passwordSalt = _encryptionService.CreateSalt();
            // add user
            var user = new User()
            {
                DateCreated = DateTime.Now,
                Email = email,
                FullName = fullName,
                HashedPassword = _encryptionService.EncryptPassword(password, passwordSalt),
                IsLocked = false,
                PasswordSalt = passwordSalt,
                UserName = userName
            };
            _unitOfWork.Commit();

            foreach(var roleId in roles)
            {
                AddRoleToUser(user, roleId);
            }
            _unitOfWork.Commit();

            return user;
        }

        public User GetUser(int userId)
        {
            return _userRepository.GetSingle(userId);
        }

        public List<Role> GetUserRoles(string userName)
        {
            return _userRepository.GetSingleByUserName(userName).UserRoles.Select(s => s.Role).ToList();
        }

        public MembershipContext ValidateUser(string userName, string password)
        {
            var membershipContext = new MembershipContext();

            var user = _userRepository.GetSingleByUserName(userName);
            if(null != user && IsUserValid(user, password))
            {
                var roles = GetUserRoles(userName);
                membershipContext.User = user;

                var userIdenity = new GenericIdentity(userName);
                membershipContext.Principal = new GenericPrincipal(userIdenity, roles.Select(s => s.Name).ToArray());
            }

            return membershipContext;
        }
    }
}
