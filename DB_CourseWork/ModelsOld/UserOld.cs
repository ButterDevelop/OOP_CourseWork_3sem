﻿using DB_CourseWork.Controls;
using DB_CourseWork.Models;
using System;

namespace OOP_CourseWork.Models
{
    public class UserOld
    {
        private int            _id;
        private string         _username;
        private string         _salt;
        private string         _hashedPassword;
        private string         _fullname;
        private string         _email;
        private string         _phone;
        private RolesContainer _role;
        private bool           _isAccountSetupCompleted;
        private bool           _accountDeactivated;

        public UserOld() 
        {
            _id = 0;
            _username = _salt = _hashedPassword = _fullname = _email = _phone = string.Empty;
            _accountDeactivated = false;
            _isAccountSetupCompleted = false;
            _role = new RolesContainer();
        }

        public UserOld(string username, string salt, string hashedPassword, string fullname, string email, string phone, RolesContainer role, bool isAccountSetupCompleted, bool accountDeactivated)
        {
            _id = 0;
            _username = username;
            _salt = salt;
            _hashedPassword = hashedPassword;
            _fullname = fullname;
            _email = email;
            _phone = phone;
            _role = role;
            _isAccountSetupCompleted = isAccountSetupCompleted;
            _accountDeactivated = accountDeactivated;
        }

        public UserOld(string username, string password, string fullname, string email, string phone, RolesContainer role)
        {
            _id = 0;
            _username = username;
            _salt = Convert.ToBase64String(CryptographyControl.GenerateSalt());
            _hashedPassword = CryptographyControl.HashPasswordWithSalt(password, _salt);
            _fullname = fullname;
            _email = email;
            _phone = phone;
            _role = role;
            _isAccountSetupCompleted = false;
            _accountDeactivated = false;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public string Salt
        {
            get
            {
                return _salt;
            }
            set
            {
                _salt = value;
            }
        }

        public string HashedPassword
        {
            get
            {
                return _hashedPassword;
            }
            set
            {
                _hashedPassword = value;
            }
        }

        public string FullName
        {
            get
            {
                return _fullname;
            }
            set
            {
                _fullname = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }

        public RolesContainer Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }

        public bool IsAccountSetupCompleted
        {
            get
            {
                return _isAccountSetupCompleted;
            }
            set
            {
                _isAccountSetupCompleted = value;
            }
        }

        public bool AccountDeactivated
        {
            get
            {
                return _accountDeactivated;
            }
            set
            {
                _accountDeactivated = value;
            }
        }


        public override string ToString()
        {
            return _role.ToString() + ";" + _id + ";" + _username + ";" + _salt + ";" + _hashedPassword + ";" + _fullname + ";" + _email + ";" + 
                     _phone + ";" + _accountDeactivated;
        }


        public void CompleteAccountSetup()
        {
            _isAccountSetupCompleted = true;
        }

        public void ActivateAccount()
        {
            _accountDeactivated = false;
        }
        public void DeactivateAccount()
        {
            _accountDeactivated = true;
        }

    }
}
