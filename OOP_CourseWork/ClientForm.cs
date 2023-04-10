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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP_CourseWork
{
    public partial class ClientForm : Form
    {
        public static readonly Color AllowedColor = Color.AliceBlue;
        public static readonly Color DeniedColor = Color.FromArgb(255, 200, 220);

        public ClientForm()
        {
            InitializeComponent();

            toolTipPassword.SetToolTip(textBoxSettings_Password, "Введите пароль, состоящий из любых символов.\nПароль должен быть достаточно сильным.");
            toolTipPassword.SetToolTip(textBoxSettings_OldPassword, "Введите пароль, состоящий из любых символов.\nПароль должен быть достаточно сильным.");

            toolTipCardNumber.SetToolTip(textBoxSettings_CardNumber, "Введите 16 цифр - номер Вашей карты для\n" + 
                                                            "последующего пополнения баланса сервиса.");
            toolTipCardNumber.SetToolTip(textBoxPayment_CardNumber, "Введите 16 цифр - номер Вашей карты для\n" +
                                                            "последующего пополнения баланса сервиса.");

            toolTipEmail.SetToolTip(textBoxSettings_Email, "Введите Ваш действительный адрес электронной почты.\n" +
                                                           "Вы не можете использовать адрес, если он уже был использован.");
            toolTipPhoneNumber.SetToolTip(maskedTextBoxSettings_PhoneNumber, "Введите номер телефона в указанном формате.\n" +
                                                                             "Вы не можете использовать номер, если он уже был использован.");

            toolTipSecretCode.SetToolTip(textBoxPayments_SecretCode, "Введите секретный номер карты.\nОн состоит из трёх цифр.");
            toolTipCost.SetToolTip(textBoxPayments_Cost, "Введите сумму пополнения Вашего баланса на нашем сервисе.\n" +
                                                         "Сумма округляется автоматически до двух знаков после запятой.");

            tabControlClient.SelectedIndexChanged += TabControlClient_SelectedIndexChanged;

            this.FormClosing += ClientForm_FormClosing;
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти из программы?", "Точно выйти?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SaveLoadControl.SaveJSON();
                Environment.Exit(0);
            } else
            {
                e.Cancel = true;
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            RefreshBalanceNumber();
            UpdateSettingsTab();
            
            if (!SaveLoadControl.CurrentUser.IsAccountSetupCompleted) tabControlClient.SelectTab(3); //Переходим на вкладку "Настройки"
            tabControlClient.Deselecting += TabControlClient_Deselecting;
        }

        private void TabControlClient_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (!SaveLoadControl.CurrentUser.IsAccountSetupCompleted) //Если аккаунт не подтверждён
            {
                e.Cancel = true; //Отмена перехода по вкладке
                MessageBox.Show("Чтобы пользоваться сервисом, Вам нужно сначала подтвердить свой аккаунт. Сделать это можно в настройках.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TabControlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlClient.SelectedIndex == 0) //Вкладка "Сделать заказ"
            {
                
            }
            else
            if (tabControlClient.SelectedIndex == 1) //Вкладка "Список заказов"
            {

            }
            else
            if (tabControlClient.SelectedIndex == 2) //Вкладка "Пополнение баланса"
            {
                RefreshPaymentsList();
                textBoxPayment_CardNumber.Text = ((Client)SaveLoadControl.CurrentUser).CardNumber;
            } else
            if (tabControlClient.SelectedIndex == 3) //Вкладка "Настройки"
            {
                UpdateSettingsTab();
            }
        }

        #region Settings

        public void UpdateSettingsTab()
        {
            if (SaveLoadControl.CurrentUser.IsAccountSetupCompleted)
            {
                labelSettings_AccountSetupIsNotCompleted.Visible = false;
                labelSettings_AccountSetupIsCompletedFine.Visible = true;
            }
            else
            {
                labelSettings_AccountSetupIsNotCompleted.Visible = true;
                labelSettings_AccountSetupIsCompletedFine.Visible = false;
            }

            textBoxSettings_DriverLicense.Text = ((Client)SaveLoadControl.CurrentUser).DriverLicense;
            textBoxSettings_Passport.Text = ((Client)SaveLoadControl.CurrentUser).Passport;
            textBoxSettings_CardNumber.Text = ((Client)SaveLoadControl.CurrentUser).CardNumber;

            textBoxSettings_Email.Text = SaveLoadControl.CurrentUser.Email;
            maskedTextBoxSettings_PhoneNumber.Text = SaveLoadControl.CurrentUser.Phone;
        }

        private void textBoxSettings_Password_TextChanged(object sender, EventArgs e)
        {
            if (UtilsControl.CheckPasswordStrength(textBoxSettings_Password.Text) < UtilsControl.PasswordScore.Medium)
            {
                textBoxSettings_Password.BackColor = DeniedColor;
            }
            else
            {
                textBoxSettings_Password.BackColor = AllowedColor;
            }
        }

        private void textBoxSettings_DriverLicense_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSettings_DriverLicense.TextLength != 0)
            {
                textBoxSettings_DriverLicense.BackColor = AllowedColor;
            }
            else
            {
                textBoxSettings_DriverLicense.BackColor = DeniedColor;
            }
        }

        private void textBoxSettings_Passport_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSettings_Passport.TextLength != 0)
            {
                textBoxSettings_Passport.BackColor = AllowedColor;
            }
            else
            {
                textBoxSettings_Passport.BackColor = DeniedColor;
            }
        }

        private void textBoxSettings_CardNumber_TextChanged(object sender, EventArgs e)
        {
            var r = new Regex("^\\d{4}\\s?\\d{4}\\s?\\d{4}\\s?\\d{4}$");
            if (r.IsMatch(textBoxSettings_CardNumber.Text))
            {
                textBoxSettings_CardNumber.BackColor = AllowedColor;
            }
            else
            {
                textBoxSettings_CardNumber.BackColor = DeniedColor;
            }
        }

        private void textBoxSettings_Email_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(SaveLoadControl.Users.FirstOrDefault(x => x.Email == textBoxSettings_Email.Text) is null) && 
                    textBoxSettings_Email.Text != SaveLoadControl.CurrentUser.Email) 
                        throw new Exception("This email is already taken.");

                MailAddress m = new MailAddress(textBoxSettings_Email.TextLength == 0 ? " " : textBoxSettings_Email.Text);

                textBoxSettings_Email.BackColor = AllowedColor;
            }
            catch
            {
                textBoxSettings_Email.BackColor = DeniedColor;
            }
        }

        private void maskedTextBoxSettings_PhoneNumber_TextChanged(object sender, EventArgs e)
        {
            var r = new Regex("^\\+375\\s\\(\\d{2}\\)\\s\\d{3}\\-\\d{2}\\-\\d{2}$");
            if (r.IsMatch(maskedTextBoxSettings_PhoneNumber.Text) && (SaveLoadControl.Users.FirstOrDefault(x => x.Phone == maskedTextBoxSettings_PhoneNumber.Text) is null
                && maskedTextBoxSettings_PhoneNumber.Text != SaveLoadControl.CurrentUser.Phone))
            {
                maskedTextBoxSettings_PhoneNumber.BackColor = AllowedColor;
            }
            else
            {
                maskedTextBoxSettings_PhoneNumber.BackColor = DeniedColor;
            }
        }

        private void buttonSettings_Save_Click(object sender, EventArgs e)
        {
            textBoxSettings_Password_TextChanged(null, null);
            textBoxSettings_DriverLicense_TextChanged(null, null);
            textBoxSettings_Passport_TextChanged(null, null);
            textBoxSettings_CardNumber_TextChanged(null, null);
            textBoxSettings_Email_TextChanged(null, null);
            maskedTextBoxSettings_PhoneNumber_TextChanged(null, null);

            if (textBoxSettings_Password.BackColor == DeniedColor ||
                textBoxSettings_DriverLicense.BackColor == DeniedColor ||
                textBoxSettings_Passport.BackColor == DeniedColor ||
                textBoxSettings_CardNumber.BackColor == DeniedColor ||
                textBoxSettings_Email.BackColor == DeniedColor ||
                maskedTextBoxSettings_PhoneNumber.BackColor == DeniedColor)
            {
                MessageBox.Show("Проверьте введённые данные на корректность.", "Ошибка смены пароля!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string phoneNumber = maskedTextBoxSettings_PhoneNumber.Text.Replace(" (", "").Replace(") ", "").Replace("-", "");

            if (!SaveLoadControl.CurrentUser.ChangeEmail(textBoxSettings_Password.Text, textBoxSettings_Email.Text) ||
                !SaveLoadControl.CurrentUser.ChangePhoneNumber(textBoxSettings_Password.Text, phoneNumber) ||
                !((Client)SaveLoadControl.CurrentUser).ChangeSettings(textBoxSettings_Password.Text, textBoxSettings_DriverLicense.Text, 
                                                                      textBoxSettings_Passport.Text, textBoxSettings_CardNumber.Text))
            {
                MessageBox.Show("Не удалось изменить настройки! Возможно, указан неверный пароль?", "Смена настроек!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                textBoxSettings_Password.BackColor = AllowedColor;
                textBoxSettings_DriverLicense.BackColor = AllowedColor;
                textBoxSettings_Passport.BackColor = AllowedColor;
                textBoxSettings_CardNumber.BackColor = AllowedColor;
                textBoxSettings_Email.BackColor = AllowedColor;
                maskedTextBoxSettings_PhoneNumber.BackColor = AllowedColor;

                SaveLoadControl.CurrentUser.CompleteAccountSetup();
                labelSettings_AccountSetupIsNotCompleted.Visible = false;
                labelSettings_AccountSetupIsCompletedFine.Visible = true;

                MessageBox.Show("Настройки были успешно изменёны!", "Смена настроек!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Change Password

        private void textBoxSettings_OldPassword_TextChanged(object sender, EventArgs e)
        {
            if (UtilsControl.CheckPasswordStrength(textBoxSettings_OldPassword.Text) < UtilsControl.PasswordScore.Medium)
            {
                textBoxSettings_OldPassword.BackColor = DeniedColor;
            }
            else
            {
                textBoxSettings_OldPassword.BackColor = AllowedColor;
            }
        }

        private void textBoxSettings_NewPassword_TextChanged(object sender, EventArgs e)
        {
            if (UtilsControl.CheckPasswordStrength(textBoxSettings_NewPassword.Text) < UtilsControl.PasswordScore.Medium)
            {
                textBoxSettings_NewPassword.BackColor = DeniedColor;
            }
            else
            {
                textBoxSettings_NewPassword.BackColor = AllowedColor;
            }
        }

        private void textBoxSettings_NewPasswordConfirmation_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSettings_NewPasswordConfirmation.TextLength != 0 && textBoxSettings_NewPasswordConfirmation.Text != textBoxSettings_NewPassword.Text)
            {
                textBoxSettings_NewPasswordConfirmation.BackColor = DeniedColor;
            }
            else
            {
                textBoxSettings_NewPasswordConfirmation.BackColor = AllowedColor;
            }
        }

        private void buttonSettings_ChangePassword_Click(object sender, EventArgs e)
        {
            textBoxSettings_OldPassword_TextChanged(null, null);
            textBoxSettings_NewPassword_TextChanged(null, null);
            textBoxSettings_NewPasswordConfirmation_TextChanged(null, null);

            if (textBoxSettings_OldPassword.BackColor == DeniedColor ||
                textBoxSettings_NewPassword.BackColor == DeniedColor ||
                textBoxSettings_NewPasswordConfirmation.BackColor == DeniedColor)
            {
                MessageBox.Show("Проверьте введённые данные на корректность.", "Ошибка смены пароля!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SaveLoadControl.CurrentUser.ChangePassword(textBoxSettings_OldPassword.Text, textBoxSettings_NewPassword.Text))
            {
                MessageBox.Show("Пароль был успешно изменён!", "Смена пароля!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                MessageBox.Show("Не удалось изменить пароль!", "Смена пароля!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void buttonSettings_DeactivateMyAccount_Click(object sender, EventArgs e)
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

                SaveLoadControl.SaveJSON();
                Application.Restart();
            }
        }

        public void RefreshBalanceNumber()
        {
            labelBalanceNumber.Text = ((Client)SaveLoadControl.CurrentUser).Balance.ToString().Replace(",", ".");
        }

        #region Payments

        private void textBoxPayments_SecretCode_TextChanged(object sender, EventArgs e)
        {
            int code = 0;
            if (!int.TryParse(textBoxPayments_SecretCode.Text, out code) || textBoxPayments_SecretCode.TextLength != 3)
            {
                textBoxPayments_SecretCode.BackColor = DeniedColor;
            }
            else
            {
                textBoxPayments_SecretCode.BackColor = AllowedColor;
            }
        }

        private void textBoxPayments_Cost_TextChanged(object sender, EventArgs e)
        {
            double cost = 0;
            if (!double.TryParse(textBoxPayments_Cost.Text.Replace(".", ","), out cost))
            {
                textBoxPayments_Cost.BackColor = DeniedColor;
            }
            else
            {
                textBoxPayments_Cost.BackColor = AllowedColor;
            }
        }

        private void buttonPayments_CreatePayment_Click(object sender, EventArgs e)
        {
            textBoxPayments_SecretCode_TextChanged(null, null);
            textBoxPayments_Cost_TextChanged(null, null);

            if (textBoxPayments_SecretCode.BackColor == DeniedColor ||
                textBoxPayments_Cost.BackColor == DeniedColor)
            {
                MessageBox.Show("Проверьте введённые данные на корректность.", "Ошибка при попытке оплаты!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (((Client)SaveLoadControl.CurrentUser).BalanceDeposit(Math.Round(double.Parse(textBoxPayments_Cost.Text.Replace(".", ",")), 2), textBoxPayments_SecretCode.Text))
            {
                textBoxPayments_SecretCode.Text = "000";
                MessageBox.Show("Успешно! Информация об оплате теперь отображается в списке оплат.", "Успешная оплата!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Ошибка! Не удалось провести оплату. Проверьте введённые данные.", "Ошибка оплаты!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RefreshBalanceNumber();
            RefreshPaymentsList();
        }

        public void RefreshPaymentsList()
        {
            listViewPayments.Items.Clear();

            var payments = SaveLoadControl.BankTransactions.Where(x => !(x.User is null) && x.User.UserName == SaveLoadControl.CurrentUser.UserName)
                                                           .OrderByDescending(x => x.CreatedTime);
            foreach (var pay in payments)
            {
                string[] arr = new string[6];
                arr[0] = string.Empty;
                arr[1] = pay.User is null ? pay.ToCardNumberOrBankAccountNumber : pay.FromCardNumberOrBankAccountNumber;
                arr[2] = pay.CreatedTime.ToString();
                arr[3] = (pay.IsCancelled ? "?" : (pay.User is null ? "+" : "-")) + pay.TotalAmount.ToString().Replace(",", ".");
                arr[4] = pay.IsFinished ? "Да" : "Нет";
                arr[5] = pay.IsCancelled ? "Да" : "Нет";

                ListViewItem item = new ListViewItem(arr);
                item.UseItemStyleForSubItems = false;
                item.SubItems[3].ForeColor = pay.IsCancelled ? Color.DarkGray : (pay.User is null ? Color.Green : Color.DarkRed);
                item.SubItems[4].ForeColor = pay.IsFinished ? Color.Green : Color.DarkRed;
                item.SubItems[5].ForeColor = pay.IsCancelled ? Color.Green : Color.DarkRed;
                listViewPayments.Items.Add(item);
            }

            listViewPayments.Refresh();
        }

        private void toolStripMenuItemListView_Copy_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewPayments.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[1].Text + "\t" + 
                              item.SubItems[2].Text + "\t" + 
                              item.SubItems[3].Text + "\t" + 
                              item.SubItems[4].Text + "\t" + 
                              item.SubItems[5].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListView_Copy_CardNumber_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewPayments.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[1].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListView_Copy_CreatedDate_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewPayments.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[2].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListView_Copy_Cost_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewPayments.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[3].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListView_Copy_IsFinished_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewPayments.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[4].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListView_Copy_IsCancelled_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewPayments.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[5].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        #endregion
    }
}
