using OOP_CourseWork.Controls;
using OOP_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CourseWork
{
    public partial class ClientForm : Form
    {
        public static readonly Color AllowedColor = Color.AliceBlue;
        public static readonly Color DeniedColor = Color.FromArgb(255, 200, 220);

        public ClientForm()
        {
            InitializeComponent();

            toolTipPassword.SetToolTip(textBoxPassword, "Введите пароль, чтобы изменить настройки.");
            toolTipCardNumber.SetToolTip(textBoxCardNumber, "Введите 16 цифр - номер Вашей карты для\n" + 
                                                            "последующего пополнения баланса сервиса.");
            toolTipEmail.SetToolTip(textBoxEmail, "Введите Ваш действительный адрес электронной почты.\n" +
                                                  "Вы не можете использовать адрес, если он уже был использован.");
            toolTipPhoneNumber.SetToolTip(maskedTextBoxPhoneNumber, "Введите номер телефона в указанном формате.\n" +
                                                                    "Вы не можете использовать номер, если он уже был использован.");

            tabControlClient.SelectedIndexChanged += TabControlClient_SelectedIndexChanged;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            UpdateSettingsTab();
        }

        private void TabControlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlClient.SelectedIndex == 0)
            {

            }
            else
            if (tabControlClient.SelectedIndex == 1)
            {

            }
            else
            if (tabControlClient.SelectedIndex == 2)
            {

            } else
            if (tabControlClient.SelectedIndex == 3)
            {
                UpdateSettingsTab();
            }
        }

        #region Settings

        public void UpdateSettingsTab()
        {
            if (SaveLoadControl.CurrentUser.IsAccountSetupCompleted)
            {
                labelAccountSetupIsNotCompleted.Visible = false;
                labelAccountSetupIsCompletedFine.Visible = true;
            }
            else
            {
                labelAccountSetupIsNotCompleted.Visible = true;
                labelAccountSetupIsCompletedFine.Visible = false;
            }

            textBoxDriverLicense.Text = ((Client)SaveLoadControl.CurrentUser).DriverLicense;
            textBoxPassport.Text = ((Client)SaveLoadControl.CurrentUser).Passport;
            textBoxCardNumber.Text = ((Client)SaveLoadControl.CurrentUser).CardNumber;

            textBoxEmail.Text = SaveLoadControl.CurrentUser.Email;
            maskedTextBoxPhoneNumber.Text = SaveLoadControl.CurrentUser.Phone;
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

        private void textBoxDriverLicense_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDriverLicense.TextLength != 0)
            {
                textBoxDriverLicense.BackColor = AllowedColor;
            }
            else
            {
                textBoxDriverLicense.BackColor = DeniedColor;
            }
        }

        private void textBoxPassport_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassport.TextLength != 0)
            {
                textBoxPassport.BackColor = AllowedColor;
            }
            else
            {
                textBoxPassport.BackColor = DeniedColor;
            }
        }

        private void textBoxCardNumber_TextChanged(object sender, EventArgs e)
        {
            var r = new Regex("^\\d{4}\\s?\\d{4}\\s?\\d{4}\\s?\\d{4}$");
            if (r.IsMatch(textBoxCardNumber.Text))
            {
                textBoxCardNumber.BackColor = AllowedColor;
            }
            else
            {
                textBoxCardNumber.BackColor = DeniedColor;
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(SaveLoadControl.Users.FirstOrDefault(x => x.Email == textBoxEmail.Text) is null) && 
                    textBoxEmail.Text != SaveLoadControl.CurrentUser.Email) 
                        throw new Exception("This email is already taken.");

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
            if (r.IsMatch(maskedTextBoxPhoneNumber.Text) && (SaveLoadControl.Users.FirstOrDefault(x => x.Phone == maskedTextBoxPhoneNumber.Text) is null
                && maskedTextBoxPhoneNumber.Text != SaveLoadControl.CurrentUser.Phone))
            {
                maskedTextBoxPhoneNumber.BackColor = AllowedColor;
            }
            else
            {
                maskedTextBoxPhoneNumber.BackColor = DeniedColor;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            textBoxPassword_TextChanged(null, null);
            textBoxDriverLicense_TextChanged(null, null);
            textBoxPassport_TextChanged(null, null);
            textBoxCardNumber_TextChanged(null, null);
            textBoxEmail_TextChanged(null, null);
            maskedTextBoxPhoneNumber_TextChanged(null, null);

            if (textBoxPassword.BackColor == DeniedColor ||
                textBoxDriverLicense.BackColor == DeniedColor ||
                textBoxPassport.BackColor == DeniedColor ||
                textBoxCardNumber.BackColor == DeniedColor ||
                textBoxEmail.BackColor == DeniedColor ||
                maskedTextBoxPhoneNumber.BackColor == DeniedColor)
            {
                MessageBox.Show("Проверьте введённые данные на корректность.", "Ошибка смены пароля!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string phoneNumber = maskedTextBoxPhoneNumber.Text.Replace(" (", "").Replace(") ", "").Replace("-", "");

            if (!SaveLoadControl.CurrentUser.ChangeEmail(textBoxPassword.Text, textBoxEmail.Text) ||
                !SaveLoadControl.CurrentUser.ChangePhoneNumber(textBoxPassword.Text, phoneNumber) ||
                !((Client)SaveLoadControl.CurrentUser).ChangeSettings(textBoxPassword.Text, textBoxDriverLicense.Text, 
                                                                      textBoxPassport.Text, textBoxCardNumber.Text))
            {
                textBoxPassword.BackColor = AllowedColor;
                textBoxDriverLicense.BackColor = AllowedColor;
                textBoxPassport.BackColor = AllowedColor;
                textBoxCardNumber.BackColor = AllowedColor;
                textBoxEmail.BackColor = AllowedColor;
                maskedTextBoxPhoneNumber.BackColor = AllowedColor;

                SaveLoadControl.CurrentUser.CompleteAccountSetup();
                labelAccountSetupIsNotCompleted.Visible = false;
                labelAccountSetupIsCompletedFine.Visible = true;

                MessageBox.Show("Настройки были успешно изменёны!", "Смена настроек!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Не удалось изменить настройки! Возможно, указан неверный пароль?", "Смена настроек!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Change Password

        private void textBoxOldPassword_TextChanged(object sender, EventArgs e)
        {
            if (UtilsControl.CheckPasswordStrength(textBoxOldPassword.Text) < UtilsControl.PasswordScore.Medium)
            {
                textBoxOldPassword.BackColor = DeniedColor;
            }
            else
            {
                textBoxOldPassword.BackColor = AllowedColor;
            }
        }

        private void textBoxNewPassword_TextChanged(object sender, EventArgs e)
        {
            if (UtilsControl.CheckPasswordStrength(textBoxNewPassword.Text) < UtilsControl.PasswordScore.Medium)
            {
                textBoxNewPassword.BackColor = DeniedColor;
            }
            else
            {
                textBoxNewPassword.BackColor = AllowedColor;
            }
        }

        private void textBoxNewPasswordConfirmation_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNewPasswordConfirmation.TextLength != 0 && textBoxNewPasswordConfirmation.Text == textBoxOldPassword.Text)
            {
                textBoxNewPasswordConfirmation.BackColor = DeniedColor;
            }
            else
            {
                textBoxNewPasswordConfirmation.BackColor = AllowedColor;
            }
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            textBoxOldPassword_TextChanged(null, null);
            textBoxNewPassword_TextChanged(null, null);
            textBoxNewPasswordConfirmation_TextChanged(null, null);

            if (textBoxOldPassword.BackColor == DeniedColor ||
                textBoxNewPassword.BackColor == DeniedColor ||
                textBoxNewPasswordConfirmation.BackColor == DeniedColor)
            {
                MessageBox.Show("Проверьте введённые данные на корректность.", "Ошибка смены пароля!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SaveLoadControl.CurrentUser.ChangePassword(textBoxOldPassword.Text, textBoxNewPassword.Text))
            {
                MessageBox.Show("Пароль был успешно изменён!", "Смена пароля!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                MessageBox.Show("Не удалось изменить пароль!", "Смена пароля!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void buttonDeactivateMyAccount_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы нажали кнопку деактивации своего аккаунта.\n" + 
                                         "Вы уверены, что хотите это сделать? Это сравнимо с полным удалением аккаунта.\n" + 
                                         "Больше Вы не сможете им воспользоваться или восстановить.", "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //Отменяем текущие заказы, если они есть у пользователя
                foreach (var order in SaveLoadControl.Orders.Where(x => !x.IsCancelled && x.OrderBookingTime >= DateTime.Now)) order.Cancel();
                //Деактивация аккаунта
                SaveLoadControl.CurrentUser.DeactivateAccount();

                MessageBox.Show("Ваш аккаунт был деактивирован. Приложение будет перезапущено.", "Успешно.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Application.Restart();
            }
        }
    }
}
