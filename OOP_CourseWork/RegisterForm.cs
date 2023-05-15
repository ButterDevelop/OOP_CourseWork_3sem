using OOP_CourseWork.Controls;
using OOP_CourseWork.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OOP_CourseWork
{
    public partial class RegisterForm : Form
    {
        public static readonly Color AllowedColor = Color.AliceBlue;
        public static readonly Color DeniedColor = Color.FromArgb(255, 200, 220);
        private string _wasRegistered = "no";

        public RegisterForm()
        {
            InitializeComponent();
            
            this.textBoxUsername.KeyDown += Enter_KeyDown;
            this.textBoxPassword.KeyDown += Enter_KeyDown;
            this.textBoxFullname.KeyDown += Enter_KeyDown;
            this.textBoxEmail.KeyDown += Enter_KeyDown;
            this.maskedTextBoxPhoneNumber.KeyDown += Enter_KeyDown;

            toolTipUsername.SetToolTip(textBoxUsername, "Имя пользователя может состоять из символов латинского алфавита,\n" +
                                                        "символа нижнего подчёркивания и цифр.\n" +
                                                        "Вы не можете использовать имя пользователя, если оно уже занято.");
            toolTipPassword.SetToolTip(textBoxPassword, "Введите пароль, состоящий из любых символов.\nПароль должен быть достаточно сильным.");
            toolTipFullname.SetToolTip(textBoxFullname, "Введите 3 слова: Вашу фамилию, имя, отчество.");
            toolTipEmail.SetToolTip(textBoxEmail, "Введите Ваш действительный адрес электронной почты.\n" +
                                                  "Вы не можете использовать адрес, если он уже был использован.");
            toolTipPhoneNumber.SetToolTip(maskedTextBoxPhoneNumber, "Введите номер телефона в указанном формате.\n" +
                                                                    "Вы не можете использовать номер, если он уже был использован.");

            this.FormClosing += RegisterForm_FormClosing;
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

            if (textBoxUsername.TextLength != 0 && SaveLoadControl.Users.FirstOrDefault(x => x.UserName == textBoxUsername.Text) is null)
            {
                textBoxUsername.BackColor = AllowedColor;
            } else
            {
                textBoxUsername.BackColor = DeniedColor;
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (UtilsControl.CheckPasswordStrength(textBoxPassword.Text) < UtilsControl.PasswordScore.Medium)
            {
                textBoxPassword.BackColor = DeniedColor;
            } else
            {
                textBoxPassword.BackColor = AllowedColor;
            }
        }

        private void textBoxFullname_TextChanged(object sender, EventArgs e)
        {
            var r = new Regex("^\\S+\\s\\S+\\s\\S+$");
            if (r.IsMatch(textBoxFullname.Text))
            {
                textBoxFullname.BackColor = AllowedColor;
            }
            else
            {
                textBoxFullname.BackColor = DeniedColor;
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(SaveLoadControl.Users.FirstOrDefault(x => x.Email == textBoxEmail.Text) is null)) throw new Exception("This email is already taken.");

                MailAddress m = new MailAddress(textBoxEmail.TextLength == 0 ? " " : textBoxEmail.Text);

                textBoxEmail.BackColor = AllowedColor;
            }
            catch
            {
                textBoxEmail.BackColor = DeniedColor;
            }
        }

        private void maskedTextBoxPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            var r = new Regex("^\\+375\\s\\(\\d{2}\\)\\s\\d{3}\\-\\d{2}\\-\\d{2}$");
            if (r.IsMatch(maskedTextBoxPhoneNumber.Text) && SaveLoadControl.Users.FirstOrDefault(x => x.Phone == maskedTextBoxPhoneNumber.Text) is null)
            {
                maskedTextBoxPhoneNumber.BackColor = AllowedColor;
            }
            else
            {
                maskedTextBoxPhoneNumber.BackColor = DeniedColor;
            }
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonRegister_Click(this, new EventArgs());
                e.SuppressKeyPress = true;
            }
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_wasRegistered != "yes")
            {
                e.Cancel = false;
                this.Hide();
            } else
            {
                SaveLoadControl.SaveJSON();
                Application.Restart();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            textBoxUsername_TextChanged(this, new EventArgs());
            textBoxPassword_TextChanged(this, new EventArgs());
            textBoxFullname_TextChanged(this, new EventArgs());
            textBoxEmail_TextChanged(this, new EventArgs());
            maskedTextBoxPhoneNumber_TextChanged(this, new EventArgs());

            if (textBoxUsername.BackColor == DeniedColor || 
                textBoxPassword.BackColor == DeniedColor ||
                textBoxFullname.BackColor == DeniedColor ||
                textBoxEmail.BackColor == DeniedColor ||
                maskedTextBoxPhoneNumber.BackColor == DeniedColor)
            {
                MessageBox.Show("Проверьте введённые данные на корректность.", "Ошибка регистрации!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Client client = new Client(SaveLoadControl.Users.Count, textBoxUsername.Text, textBoxPassword.Text,
                                           textBoxFullname.Text, textBoxEmail.Text, maskedTextBoxPhoneNumber.Text);
                SaveLoadControl.Users.Add(client);

                MessageBox.Show("Успешная регистрация! Войдите в аккаунт для его использования.", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Не удалось зарегистрироваться по неизвестной причине!", "Ошибка регистрации!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
