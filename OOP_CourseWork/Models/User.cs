using OOP_CourseWork.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CourseWork.Models
{
    internal class User
    {
        private int            _id;
        private string         _username;
        private string         _salt;
        private string         _hashedPassword;
        private string         _fullname;
        private string         _email;
        private string         _phone;
        private RolesContainer _role;
        private bool           _accountDeactivated;

        public User() 
        {
            _id = 0;
            _username = _salt = _hashedPassword = _fullname = _email = _phone = string.Empty;
            _accountDeactivated = false;
            _role = new RolesContainer();
        }

        public User(int id, string username, string salt, string hashedPassword, string fullname, string email, string phone, RolesContainer role, bool accountDeactivated)
        {
            _id = id;
            _username = username;
            _salt = salt;
            _hashedPassword = hashedPassword;
            _fullname = fullname;
            _email = email;
            _phone = phone;
            _role = role;
            _accountDeactivated = accountDeactivated;
        }

        public User(int id, string username, string password, string fullname, string email, string phone, RolesContainer role)
        {
            _id = id;
            _username = username;
            _salt = Convert.ToBase64String(CryptographyControl.GenerateSalt());
            _hashedPassword = CryptographyControl.HashPasswordWithSalt(password, _salt);
            _fullname = fullname;
            _email = email;
            _phone = phone;
            _role = role;
            _accountDeactivated = false;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string UserName
        {
            get
            {
                return _username;
            }
        }

        public string Salt
        {
            get
            {
                return _salt;
            }
        }

        public string HashedPassword
        {
            get
            {
                return _hashedPassword;
            }
        }

        public string FullName
        {
            get
            {
                return _fullname;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }
        }

        public RolesContainer Role
        {
            get
            {
                return _role;
            }
        }

        public bool AccountDeactivated
        {
            get
            {
                return _accountDeactivated;
            }
        }


        public override string ToString()
        {
            return _role.ToString() + ";" + _id + ";" + _username + ";" + _salt + ";" + _hashedPassword + ";" + _fullname + ";" + _email + ";" + _phone + ";" + _accountDeactivated;
        }

        public void ActivateAccount()
        {
            _accountDeactivated = false;
        }
        public void DeactivateAccount()
        {
            _accountDeactivated = true;
        }

        public bool IsPasswordCorrect(string password)
        {
            return CryptographyControl.HashPasswordWithSalt(password, _salt) == _hashedPassword;
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (IsPasswordCorrect(oldPassword))
            {
                _salt = Convert.ToBase64String(CryptographyControl.GenerateSalt());
                _hashedPassword = CryptographyControl.HashPasswordWithSalt(newPassword, _salt);
                return true;
            }
            return false;
        }
    }
}
