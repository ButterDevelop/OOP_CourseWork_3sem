using OOP_CourseWork.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CourseWork
{
    public partial class LoginForm : Form
    {
        private string _wasLogedIn = "no";

        public LoginForm()
        {
            InitializeComponent();

            SaveLoadControl.LoadJSON();
            
            this.textBoxUsername.KeyDown += Enter_KeyDown;
            this.textBoxPassword.KeyDown += Enter_KeyDown;
            this.FormClosing += LoginForm_FormClosing;
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(this, new EventArgs());
                e.SuppressKeyPress = true;
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_wasLogedIn != "yes")
            {
                Environment.Exit(0);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var user = SaveLoadControl.Users.FirstOrDefault(x => x.UserName == textBoxUsername.Text.Trim() && !x.AccountDeactivated);
            if (user != null)
            {
                if (user.IsPasswordCorrect(textBoxPassword.Text))
                {
                    _wasLogedIn = "yes";
                    SaveLoadControl.CurrentUser = user;
                    this.Close();
                    return;
                }
            }

            MessageBox.Show("Неверное имя пользователя или пароль!", "Ошибка входа!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
