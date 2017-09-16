using System;
using System.Linq;
using MusiUploaderWeb.Models.DB;
using MusiUploaderWeb.Models.ViewModel;
using MusiUploaderWeb.Models.Repository;
using System.Collections.Generic;
using MusiUploaderWeb.Interfaces;

namespace MusiUploaderWeb.Models.EntityManager
{
    public class UserManager
    {
        private IRoleRepository roleRepository;
        private IUserRepository userRepository;

        public UserManager()
        {
            this.roleRepository = new RoleRepository(new MusicEntities());
            this.userRepository = new UserRepository(new MusicEntities());
        }

        public void AddUserAccount(UserSignUpView user)
        {
            User newUser = new User();
            newUser.LoginName = user.LoginName;
            newUser.PasswordEncryptedText = user.Password;
            newUser.RowCreatedUserID = user.UserID > 0 ? user.UserID : 1;
            newUser.RowModifiedUserID = user.UserID > 0 ? user.UserID : 1; ;
            newUser.RowCreatedDateTime = DateTime.Now;
            newUser.RowMOdifiedDateTime = DateTime.Now;

            userRepository.Add(newUser);

            UserProfile userProfile = new UserProfile();
            userProfile.UserID = newUser.UserID;
            userProfile.FirstName = user.FirstName;
            userProfile.LastName = user.LastName;
            userProfile.Gender = user.Gender;
            userProfile.RowCreatedUserID = user.UserID > 0 ? user.UserID : 1;
            userProfile.RowModifiedUserID = user.UserID > 0 ? user.UserID : 1;
            userProfile.RowCreatedDateTime = DateTime.Now;
            userProfile.RowModifiedDateTime = DateTime.Now;

            userRepository.Add(userProfile);

            UserRole userRole = new UserRole();
            var lookupRole = roleRepository.GetRoleByName(Helpers.Consts.LookupRoleNames.Guest);
            userRole.LookupRoleID = lookupRole.LookupRoleID;
            userRole.UserID = user.UserID;
            userRole.IsActive = true;
            userRole.RowCreatedUserID = 1;
            userRole.RowModifiedUserID = 1;
            userRole.RowCreatedDateTime = DateTime.Now;
            userRole.RowModifiedDateTime = DateTime.Now;

            userRepository.Add(userRole);

            userRepository.Save();
        }


        public bool IsLoginNameExist(string loginName)
        {
            var exists = userRepository.UserExists(loginName);
            return exists;
        }

        public string GetUserPassword(string loginName)
        {
            return userRepository.GetPassword(loginName);
        }

        public bool IsUserInRole(string username, string roleName)
        {
            var user = userRepository.GetByUserName(username);
            if (user != null)
            {
                var role = userRepository.GetUserRole(user.UserID);
                if (role == roleName)
                    return true;
            }

            return false;
        }

        public string GetUserRoleByUsername(string username)
        {
            var role = string.Empty;
            var user = userRepository.GetByUserName(username);
            if (user != null)
            {
                role = userRepository.GetUserRole(user.UserID);
            }

            return role;
        }

        public List<LookupAvailableRole> GetAllRoles()
        {
            var roles = roleRepository.GetAllRoles();

            var availableRoles = roles.Select(r => new LookupAvailableRole
            {
                LookupRoleID = r.LookupRoleID,
                RoleName = r.RoleName,
                RoleDescription = r.RoleDescription
            }).ToList();

            return availableRoles;
        }

        public int GetUserID(string username)
        {
            var user = userRepository.GetByUserName(username);
            if (user != null)
                return user.UserID;
       
            return 0;
        }
        public List<UserSignUpView> GetAllUserProfiles()
        {
            var profiles = new List<UserSignUpView>();
            var users = userRepository.GetAll().ToList();
            UserSignUpView profile;

            foreach (var user in users)
            {
                profile = new UserSignUpView();
                profile.UserID = user.UserID;
                profile.LoginName = user.LoginName;
                profile.Password = user.PasswordEncryptedText;

                var userProfile = userRepository.GetUserProfileByUserID(user.UserID);
                if (userProfile != null)
                {
                    profile.FirstName = userProfile.FirstName;
                    profile.LastName = userProfile.LastName;
                    profile.Gender = userProfile.Gender;
                }

                var userRole = userRepository.GetUserRoleByUserID(user.UserID);
                var lookupRole = userRepository.GetUserRole(user.UserID);
                if (userRole != null)
                {
                    profile.LookupRoleID = userRole.LookupRoleID;
                    profile.RoleName = lookupRole;
                    profile.IsRoleActive = userRole.IsActive;
                }

                profiles.Add(profile);
            }

            return profiles;
        }

        public UserDataView GetUserDataView(string loginName)
        {
            var userData = new UserDataView();
            var profiles = GetAllUserProfiles();
            var roles = GetAllRoles();

            int userAssignedRoleID = 0, userID = 0;
            string userGender = string.Empty;

            userID = GetUserID(loginName);

            userAssignedRoleID = userRepository.GetUserRoleByUserID(userID).LookupRoleID;
            userGender = userRepository.GetUserProfileByUserID(userID).Gender;
      
            List<Gender> genders = new List<Gender>();
            genders.Add(new Gender
            {
                Text = "Male",
                Value = "M"
            });
            genders.Add(new Gender
            {
                Text = "Female",
                Value = "F"
            });

            userData.UserProfile = profiles;
            userData.UserRoles = new UserRoles
            {
                SelectedRoleID = userAssignedRoleID,
                UserRoleList = roles
            };
            userData.UserGender = new UserGender
            {
                SelectedGender = userGender,
                Gender = genders
            };
            return userData;
        }

        public void UpdateUserAccount(UserSignUpView user)
        {
            userRepository.UpdateUser(user);
        }

        public void DeleteUser(int userID)
        {
            userRepository.DeleteUser(userID);
        }

        public UserSignUpView GetUserProfile(int userID)
        {
            var userProfileView = userRepository.GetUserProfileView(userID);
            return userProfileView;
        }
    }
}