using OOP_CourseWork.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CourseWork
{
    public partial class LoginForm : Form
    {
        public static readonly Color AllowedColor = Color.AliceBlue;
        public static readonly Color DeniedColor = Color.FromArgb(255, 200, 220);
        private string _wasLogedIn = "no";
        private RegisterForm _registerForm = new RegisterForm();

        public LoginForm()
        {
            InitializeComponent();
            
            this.textBoxUsername.KeyDown += Enter_KeyDown;
            this.textBoxPassword.KeyDown += Enter_KeyDown;

            toolTipUsername.SetToolTip(textBoxUsername, "Имя пользователя может состоять из символов латинского алфавита,\n" +
                                                        "символа нижнего подчёркивания и цифр.\n" +
                                                        "Вы не можете использовать имя пользователя, если оно уже занято.");
            toolTipPassword.SetToolTip(textBoxPassword, "Введите пароль, состоящий из любых символов.\nПароль должен быть достаточно сильным.");

            this.FormClosing += LoginForm_FormClosing;
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUsername.TextLength > 0)
            {
                char c = textBoxUsername.Text[textBoxUsername.TextLength - 1];
                if (!char.IsLetter(c) && !char.IsDigit(c) && c != '_')
                {
                    textBoxUsername.Text = textBoxUsername.Text.Remove(textBoxUsername.TextLength - 1, 1);
                    return;
                }
            }

            if (textBoxUsername.TextLength != 0 && SaveLoadControl.Users.FirstOrDefault(x => x.UserName == textBoxUsername.Text && !x.AccountDeactivated) is null)
            {
                textBoxUsername.BackColor = DeniedColor;
            }
            else
            {
                textBoxUsername.BackColor = AllowedColor;
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (UtilsControl.CheckPasswordStrength(textBoxPassword.Text) < UtilsControl.PasswordScore.Medium)
            {
                textBoxPassword.BackColor = DeniedColor;
            }
            else
            {
                textBoxPassword.BackColor = AllowedColor;
            }
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
                SaveLoadControl.SaveJSON();
                Environment.Exit(0);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            textBoxUsername_TextChanged(this, new EventArgs());
            textBoxPassword_TextChanged(this, new EventArgs());

            if (textBoxUsername.BackColor == DeniedColor || textBoxPassword.BackColor == DeniedColor)
            {
                MessageBox.Show("Проверьте введённые данные на корректность.", "Ошибка входа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            _registerForm.ShowDialog();
            this.Show();
        }
    }
}
