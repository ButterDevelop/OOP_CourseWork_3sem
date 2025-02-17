﻿using Microsoft.VisualBasic;
using DB_CourseWork.Controls;
using DB_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DB_CourseWork
{
    partial class ClientForm : Form
    {
        public static readonly Color AllowedColor = Color.AliceBlue;
        public static readonly Color DeniedColor = Color.FromArgb(255, 200, 220);
        public Size ImageSize = new Size(240, 160);
        public static Dictionary<int, Image> CarsOrderImages = new Dictionary<int, Image>();

        private DatabaseContext _dbContext;

        public ClientForm(DatabaseContext dbContext)
        {
            InitializeComponent();

            _dbContext = dbContext;

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

            toolTipOrderHours.SetToolTip(textBoxMakeAnOrder_BookingHours, "Введите количество часов, на которые хотите арендовать автомобиль.\n" + 
                                                                          "Не может превышать 192-х часов (8 суток).");

            toolTipOrderBookingDateTime.SetToolTip(dateTimePickerMakeAnOrder_BookingDate, "Укажите время, на которое бронируете автомобиль.\n" + 
                                                                                          "Это будет время начала Вашего заказа.");
            toolTipOrderBookingDateTime.SetToolTip(dateTimePickerMakeAnOrder_BookingTime, "Укажите время, на которое бронируете автомобиль.\n" +
                                                                                          "Это будет время начала Вашего заказа.");

            toolTipOrderBookingEndDateTime.SetToolTip(textBoxMakeAnOrder_BookingEndTime,  "Время окончания заказа, рассчитанное с помощью указанных Вами параметров.");

            toolTipOrderListCarPicture.SetToolTip(pictureBoxCarPicture, "Фотография автомобиля выбранного заказа.");

            tabControlClient.SelectedIndexChanged += TabControlClient_SelectedIndexChanged;

            listViewPayments.ColumnWidthChanging += ListViewPayments_ColumnWidthChanging;
            listViewOrderList.ColumnWidthChanging += ListViewOrderList_ColumnWidthChanging;

            listViewOrderList.ItemSelectionChanged += ListViewOrderList_ItemSelectionChanged;

            this.FormClosing += ClientForm_FormClosing;

            labelUsername.Text = _dbContext.CurrentUser.UserName;

            CarsOrderImages = UtilsControl.LoadCarsOrderImages();
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти из программы?", "Точно выйти?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                BeginInvoke(new Action(() =>
                {
                    Environment.Exit(0);
                }));
            } 
            else
            {
                e.Cancel = true;
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            RefreshBalanceNumber();
            UpdateSettingsTab();
            RefreshOrderList();
            
            if (!_dbContext.CurrentUser.IsAccountSetupCompleted) tabControlClient.SelectTab(3); //Переходим на вкладку "Настройки"
            tabControlClient.Deselecting += TabControlClient_Deselecting;
        }

        private void TabControlClient_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_dbContext.CurrentUser.IsAccountSetupCompleted) //Если аккаунт не подтверждён
            {
                e.Cancel = true; //Отмена перехода по вкладке
                MessageBox.Show("Чтобы пользоваться сервисом, Вам нужно сначала подтвердить свой аккаунт. Сделать это можно в настройках.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TabControlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewOrderList_ItemSelectionChanged_SetDefault();
            if (tabControlClient.SelectedIndex == 0) //Вкладка "Список заказов"
            {
                RefreshOrderList();
            }
            else
            if (tabControlClient.SelectedIndex == 1) //Вкладка "Сделать заказ"
            {
                SetDefaultMakeAnOrderValues();
                RefreshMakeAnOrderList();
            }
            else
            if (tabControlClient.SelectedIndex == 2) //Вкладка "Пополнение баланса"
            {
                RefreshPaymentsList();
                textBoxPayment_CardNumber.Text = ((Client)_dbContext.CurrentUser).CardNumber;
            } 
            else
            if (tabControlClient.SelectedIndex == 3) //Вкладка "Настройки"
            {
                UpdateSettingsTab();
            }
        }

        #region Settings

        public void UpdateSettingsTab()
        {
            if (_dbContext.CurrentUser.IsAccountSetupCompleted)
            {
                labelSettings_AccountSetupIsNotCompleted.Visible = false;
                labelSettings_AccountSetupIsCompletedFine.Visible = true;
            }
            else
            {
                labelSettings_AccountSetupIsNotCompleted.Visible = true;
                labelSettings_AccountSetupIsCompletedFine.Visible = false;
            }

            textBoxSettings_DriverLicense.Text = ((Client)_dbContext.CurrentUser).DriverLicense;
            textBoxSettings_Passport.Text = ((Client)_dbContext.CurrentUser).Passport;
            textBoxSettings_CardNumber.Text = ((Client)_dbContext.CurrentUser).CardNumber;

            textBoxSettings_Email.Text = _dbContext.CurrentUser.Email;
            maskedTextBoxSettings_PhoneNumber.Text = _dbContext.CurrentUser.Phone;
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
                if (!(_dbContext.GetAllUsers().FirstOrDefault(x => x.Email == textBoxSettings_Email.Text) is null) && 
                    textBoxSettings_Email.Text != _dbContext.CurrentUser.Email) 
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
            if (r.IsMatch(maskedTextBoxSettings_PhoneNumber.Text) && (_dbContext.GetAllUsers().FirstOrDefault(x => x.Phone == maskedTextBoxSettings_PhoneNumber.Text) is null
                && maskedTextBoxSettings_PhoneNumber.Text != _dbContext.CurrentUser.Phone))
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
                MessageBox.Show("Проверьте введённые данные на корректность.", "Ошибка смены настроек!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string phoneNumber = maskedTextBoxSettings_PhoneNumber.Text.Replace(" (", "").Replace(") ", "").Replace("-", "");

            if (!_dbContext.CurrentUser.ChangeEmail(textBoxSettings_Password.Text, textBoxSettings_Email.Text) ||
                !_dbContext.CurrentUser.ChangePhoneNumber(textBoxSettings_Password.Text, phoneNumber) ||
                !((Client)_dbContext.CurrentUser).ChangeSettings(textBoxSettings_Password.Text, textBoxSettings_DriverLicense.Text, 
                                                                      textBoxSettings_Passport.Text, textBoxSettings_CardNumber.Text))
            {
                MessageBox.Show("Не удалось изменить настройки! Возможно, указан неверный пароль?", "Смена настроек!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else
            {
                textBoxSettings_Password.BackColor = AllowedColor;
                textBoxSettings_DriverLicense.BackColor = AllowedColor;
                textBoxSettings_Passport.BackColor = AllowedColor;
                textBoxSettings_CardNumber.BackColor = AllowedColor;
                textBoxSettings_Email.BackColor = AllowedColor;
                maskedTextBoxSettings_PhoneNumber.BackColor = AllowedColor;

                _dbContext.CurrentUser.CompleteAccountSetup();
                _dbContext.Clients.Update((Client)_dbContext.CurrentUser);

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

            if (_dbContext.CurrentUser.ChangePassword(textBoxSettings_OldPassword.Text, textBoxSettings_NewPassword.Text))
            {
                _dbContext.Clients.Update((Client)_dbContext.CurrentUser);
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
                if (textBoxSettings_Password.Text == "")
                {
                    MessageBox.Show("Для того, чтобы деактивировать аккаунт, Вам нужно ввести свой текущий пароль в поле \"Ваш пароль\".", "Одну секунду!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!_dbContext.CurrentUser.IsPasswordCorrect(textBoxSettings_Password.Text))
                {
                    MessageBox.Show("Вы ввели неверный пароль в поле \"Ваш пароль\"! Невозможно деактивировать аккаунт!", "Ошибка деактивации!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Отменяем текущие заказы, если они есть у пользователя
                foreach (var order in _dbContext.Orders.GetAll().Where(x => !x.IsCancelled && x.OrderBookingTime >= DateTime.UtcNow))
                {
                    order.Cancel();
                    _dbContext.Orders.Update(order);
                }
                //Деактивация аккаунта
                _dbContext.CurrentUser.DeactivateAccount();
                _dbContext.Clients.Update((Client)_dbContext.CurrentUser);

                MessageBox.Show("Ваш аккаунт был деактивирован. Приложение будет перезапущено.", "Успешно.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Environment.Exit(0);
            }
        }

        public void RefreshBalanceNumber()
        {
            labelBalanceNumber.Text = ((Client)_dbContext.CurrentUser).Balance.ToString().Replace(",", ".");
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
            if (!double.TryParse(textBoxPayments_Cost.Text.Replace(".", ","), out cost) || cost <= 0)
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

            var result = MessageBox.Show("Вы уверены, что хотите пополнить свой баланс?", "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            if (((Client)_dbContext.CurrentUser).BalanceDeposit(Math.Round(double.Parse(textBoxPayments_Cost.Text.Replace(".", ",")), 2), textBoxPayments_SecretCode.Text))
            {
                _dbContext.Clients.Update((Client)_dbContext.CurrentUser);
                textBoxPayments_SecretCode.Text = "000";
                MessageBox.Show("Успешно! Информация об оплате теперь отображается в списке оплат.", "Успешная оплата!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                MessageBox.Show("Ошибка! Не удалось провести оплату. Проверьте введённые данные.", "Ошибка оплаты!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RefreshBalanceNumber();
            RefreshPaymentsList();
        }

        private void ListViewPayments_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewPayments.Columns[e.ColumnIndex].Width;
        }

        public void RefreshPaymentsList()
        {
            listViewPayments.Items.Clear();

            var payments = _dbContext.BankTransactions.GetAll().Where(x => x.UserId.HasValue && _dbContext.Clients.Get(x.UserId.Value).UserName == _dbContext.CurrentUser.UserName)
                                                               .OrderByDescending(x => x.CreatedTime);
            foreach (var pay in payments)
            {
                string[] arr = new string[6];
                arr[0] = string.Empty;
                arr[1] = !pay.UserId.HasValue ? pay.ToCardNumberOrBankAccountNumber : pay.FromCardNumberOrBankAccountNumber;
                arr[2] = pay.CreatedTime.ToString();
                arr[3] = (pay.IsCancelled ? "?" : (!pay.UserId.HasValue ? "+" : "-")) + pay.TotalAmount.ToString().Replace(",", ".");
                arr[4] = pay.IsFinished ? "Да" : "Нет";
                arr[5] = pay.IsCancelled ? "Да" : "Нет";

                ListViewItem item = new ListViewItem(arr);
                item.UseItemStyleForSubItems = false;
                item.SubItems[3].ForeColor = pay.IsCancelled ? Color.DarkGray : (!pay.UserId.HasValue ? Color.Green : Color.DarkRed);
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

        #region Make an order

        public Image DrawTextOnImage(Image image, Size imageSize, string text, int fontSize)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.RotateTransform(45);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                GraphicsPath p = new GraphicsPath();
                var fontFamily = FontFamily.Families.FirstOrDefault(x => x.Name == "Tahoma");
                p.AddString(
                    text,
                    fontFamily is null ? FontFamily.GenericSansSerif : fontFamily,
                    (int)FontStyle.Bold,
                    g.DpiY * fontSize / 72,
                    new PointF((float)(imageSize.Width / 1.7), -1 * imageSize.Height / 4),
                    sf);
                g.DrawPath(Pens.DarkGray, p);
                g.FillPath(Brushes.DarkGray, p);
                g.DrawString(text, new Font("Tahoma", fontSize, FontStyle.Bold), Brushes.Red, new PointF((float)(imageSize.Width / 1.7), -1 * imageSize.Height / 4), sf);
            }

            return image;
        }

        public void RefreshMakeAnOrderList()
        {
            listViewMakeAnOrder.Items.Clear();

            var cars = _dbContext.Cars.GetAll().Where(x => !x.IsHidden).OrderBy(x => x.PricePerHour).ToArray();

            ImageList imageListLarge = new ImageList();
            imageListLarge.ImageSize = ImageSize;
            for (int i = 0; i < cars.Count(); i++)
            {
                Image image = new Bitmap(CarsOrderImages[cars[i].Id], ImageSize);
                
                if (_dbContext.Cars.Get(cars[i].Id).IsOnServiceNow)
                {
                    image = DrawTextOnImage(image, ImageSize, "Сейчас на\nобслуживании", 13);
                } 
                else
                if (_dbContext.Cars.Get(cars[i].Id).IsOrderedNow)
                {
                    image = DrawTextOnImage(image, ImageSize, "Уже\nзаказана", 16);
                }

                imageListLarge.Images.Add(image);
            }
            listViewMakeAnOrder.LargeImageList = imageListLarge;

            foreach (var car in cars)
            {
                string title = "";
                title += car.Brand + " ";
                title += car.Model + ", ";
                title += car.ProductionYear.Year.ToString() + "-го года выпуска, ";
                title += car.PricePerHour.ToString().Replace(",", ".") + " рублей в час";

                ListViewItem item = new ListViewItem(title);
                item.Tag = car.Id;
                item.UseItemStyleForSubItems = false;
                item.ForeColor = (car.IsOrderedNow || car.IsOnServiceNow) ? Color.Red : Color.Green;
                item.ImageIndex = listViewMakeAnOrder.Items.Count;
                listViewMakeAnOrder.Items.Add(item);
            }

            listViewMakeAnOrder.Refresh();
        }

        public void SetDefaultMakeAnOrderValues()
        {
            dateTimePickerMakeAnOrder_BookingDate.MinDate = DateTime.Now.AddSeconds(-1);
            dateTimePickerMakeAnOrder_BookingDate.MaxDate = DateTime.Now.AddDays(7);
            dateTimePickerMakeAnOrder_BookingTime.MinDate = DateTime.Now.AddSeconds(-1);
            dateTimePickerMakeAnOrder_BookingDate.Value = DateTime.Now;
            dateTimePickerMakeAnOrder_BookingTime.Value = DateTime.Now;
            SetBookingEndDate();
        }

        public void SetBookingEndDate()
        {
            int hours = 0;
            if (!int.TryParse(textBoxMakeAnOrder_BookingHours.Text, out hours) || hours <= 0 || hours > 192) return; //999999

            textBoxMakeAnOrder_BookingEndTime.Text = new DateTime(dateTimePickerMakeAnOrder_BookingDate.Value.Year,
                                                                  dateTimePickerMakeAnOrder_BookingDate.Value.Month,
                                                                  dateTimePickerMakeAnOrder_BookingDate.Value.Day,
                                                                  dateTimePickerMakeAnOrder_BookingTime.Value.Hour,
                                                                  dateTimePickerMakeAnOrder_BookingTime.Value.Minute,
                                                                  dateTimePickerMakeAnOrder_BookingTime.Value.Second).AddHours(hours).ToString();
        }

        private void textBoxMakeAnOrder_BookingHours_TextChanged(object sender, EventArgs e)
        {
            int hours = 0;
            if (!int.TryParse(textBoxMakeAnOrder_BookingHours.Text, out hours) || hours <= 0 || hours > 192) //999999
            {
                textBoxMakeAnOrder_BookingHours.BackColor = DeniedColor;
            }
            else
            {
                textBoxMakeAnOrder_BookingHours.BackColor = AllowedColor;
            }
            SetBookingEndDate();
        }

        private void dateTimePickerMakeAnOrder_BookingDate_ValueChanged(object sender, EventArgs e)
        {
            SetBookingEndDate();
        }

        private void dateTimePickerMakeAnOrder_BookingTime_ValueChanged(object sender, EventArgs e)
        {
            SetBookingEndDate();
        }

        private void buttonMakeAnOrder_CreateOrder_Click(object sender, EventArgs e)
        {
            textBoxMakeAnOrder_BookingHours_TextChanged(null, null);

            if (textBoxMakeAnOrder_BookingHours.BackColor == DeniedColor)
            {
                MessageBox.Show("Проверьте введённые данные на корректность.", "Ошибка при попытке сделать заказ!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listViewMakeAnOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Вы не выбрали, что хотите заказать!", "Ошибка при попытке сделать заказ!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_dbContext.Orders.GetAll().Count(x => DatabaseContext.DbContext.Payments.Get(x.OrderPaymentId).UserId == _dbContext.CurrentUser.Id 
                                                 && DatabaseContext.DbContext.Payments.Get(x.OrderPaymentId).CreatedTime >= DateTime.UtcNow.AddHours(-1)) >= 3)
            {
                MessageBox.Show("Вы сделали слишком много заказов за последний час! Подождите немного!", "Вы сделали 3 заказа за последний час.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show($"Вы уверены, что хотите заказать автомобиль " +
                                         $"\"{listViewMakeAnOrder.SelectedItems[0].Text}\"?", "Подтверждение заказа", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            int hours = 0;
            Regex regex = new Regex("Машина\\s\\#(\\d*)\\,\\s");
            if (!int.TryParse(textBoxMakeAnOrder_BookingHours.Text, out hours) || hours <= 0 || hours > 192 || listViewMakeAnOrder.SelectedItems[0].Tag is null)
            {
                MessageBox.Show("Во время создания заказа произола ошибка! Попробуйте позже.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int carId = (int)listViewMakeAnOrder.SelectedItems[0].Tag;
            Car car = _dbContext.Cars.Get(carId);

            if (car.IsOrderedNow || car.IsOnServiceNow)
            {
                MessageBox.Show("Данный автомобиль сейчас недоступен для заказа. Причина указана на фотографии.", "Невозможно заказать автомобиль!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime bookingDateTime = new DateTime(dateTimePickerMakeAnOrder_BookingDate.Value.Year,
                                                    dateTimePickerMakeAnOrder_BookingDate.Value.Month,
                                                    dateTimePickerMakeAnOrder_BookingDate.Value.Day,
                                                    dateTimePickerMakeAnOrder_BookingTime.Value.Hour,
                                                    dateTimePickerMakeAnOrder_BookingTime.Value.Minute,
                                                    dateTimePickerMakeAnOrder_BookingTime.Value.Second);
            if ((bookingDateTime - DateTime.Now).TotalMinutes < 30) bookingDateTime = DateTime.Now.AddMinutes(30);

            Payment payment = new Payment((Client)_dbContext.CurrentUser, hours * car.PricePerHour);
            if (!payment.Pay())
            {
                MessageBox.Show("Заказ НЕ был создан, его не удалось оплатить! Кажется, у Вас недостаточно средств на балансе.", "Ошибка оплаты!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Order order = new Order(payment, car, (Client)_dbContext.CurrentUser, bookingDateTime.ToUniversalTime(), hours);
            _dbContext.Orders.Add(order);

            RefreshBalanceNumber();
            RefreshMakeAnOrderList();

            dateTimePickerMakeAnOrder_BookingDate.Value = bookingDateTime;
            dateTimePickerMakeAnOrder_BookingTime.Value = bookingDateTime;
            MessageBox.Show($"Заказ был успешно создан! Начало времени бронирования: {bookingDateTime}.", "Заказ создан успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Order list

        public void RefreshOrderList()
        {
            listViewOrderList.Items.Clear();

            var orders = _dbContext.Orders.GetAll().Where(x => DatabaseContext.DbContext.Payments.Get(x.OrderPaymentId).UserId == _dbContext.CurrentUser.Id)
                                                   .OrderByDescending(x => x.OrderBookingTime).ToArray();

            int counter = orders.Length;
            foreach (var order in orders)
            {
                var orderPayment = DatabaseContext.DbContext.Payments.Get(order.OrderPaymentId);

                string[] arr = new string[7];
                arr[0] = "";
                arr[1] = (counter--).ToString();
                arr[2] = order.OrderBookingTime.ToLocalTime().ToString();
                arr[3] = order.OrderHours.ToString();
                arr[4] = order.OrderBookingTime.AddHours(order.OrderHours).ToLocalTime().ToString();
                arr[5] = order.IsCancelled ? "Отменён" : (order.OrderBookingTime.AddHours(order.OrderHours) <= DateTime.UtcNow ? "Закончен" : "Активен");
                arr[6] = orderPayment.Cost.ToString("N2").Replace(",", ".");

                ListViewItem item = new ListViewItem(arr);
                item.Tag = order.Id;
                item.UseItemStyleForSubItems = false;
                item.ForeColor = order.IsCancelled ? Color.Red : Color.Green;
                listViewOrderList.Items.Add(item);
            }

            listViewOrderList.Refresh();
        }

        private void ListViewOrderList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewOrderList.Columns[e.ColumnIndex].Width;
        }

        private void ListViewOrderList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewOrderList.SelectedItems.Count != 0)
            {
                if (listViewOrderList.SelectedItems[0].Tag is null) return;
                var orderId = (int)listViewOrderList.SelectedItems[0].Tag;
                var order = _dbContext.Orders.GetAll().FirstOrDefault(x => x.Id == orderId);
                if (order is null) return;

                if (!order.IsCancelled && order.OrderBookingTime > DateTime.UtcNow)
                    buttonOrderList_CancelOrder.Enabled = true;
                else
                    buttonOrderList_CancelOrder.Enabled = false;

                if (!order.IsCancelled && order.OrderBookingTime.AddHours(order.OrderHours) >= DateTime.UtcNow)
                {
                    buttonOrderList_OpenCarLocationMap.Enabled = true;
                    buttonOrderList_ExtendTheOrder.Enabled = true;
                }
                else
                {
                    buttonOrderList_OpenCarLocationMap.Enabled = false;
                    buttonOrderList_ExtendTheOrder.Enabled = false;
                }

                var orderedCar = DatabaseContext.DbContext.Cars.Get(order.OrderedCarId);
                pictureBoxCarPicture.Image            = new Bitmap(CarsOrderImages[orderedCar.Id], pictureBoxCarPicture.Size);
                textBoxOrderList_CarBrand.Text        = orderedCar.Brand;
                textBoxOrderList_CarModel.Text        = orderedCar.Model;
                textBoxOrderList_ProductionYear.Text  = orderedCar.ProductionYear.ToString("yyyy");
                textBoxOrderList_PricePerHour.Text    = orderedCar.PricePerHour.ToString("N2").Replace(",", ".");
                textBoxOrderList_CarLicensePlate.Text = orderedCar.CarLicensePlate;
                textBoxOrderList_LastServiceDate.Text = orderedCar.LastServiceTime == new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) ? "Пока не было" : orderedCar.LastServiceTime.ToString("d");
            } 
            else
            {
                ListViewOrderList_ItemSelectionChanged_SetDefault();
            }
        }

        public void ListViewOrderList_ItemSelectionChanged_SetDefault()
        {
            pictureBoxCarPicture.Image = null;
            textBoxOrderList_CarBrand.Text = "";
            textBoxOrderList_CarModel.Text = "";
            textBoxOrderList_ProductionYear.Text = "";
            textBoxOrderList_PricePerHour.Text = "";
            textBoxOrderList_CarLicensePlate.Text = "";
            textBoxOrderList_LastServiceDate.Text = "";
            buttonOrderList_CancelOrder.Enabled = false;
            buttonOrderList_OpenCarLocationMap.Enabled = false;
            buttonOrderList_ExtendTheOrder.Enabled = false;
        }

        private void buttonOrderList_CancelOrder_Click(object sender, EventArgs e)
        {
            if (listViewOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Вы не выбрали заказа, чтобы его отменить!", "Невозможно отменить заказ!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите отменить выбранный заказ?", "Отменить заказ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            if (listViewOrderList.SelectedItems[0].Tag is null) return;
            var orderId = (int)listViewOrderList.SelectedItems[0].Tag;
            var order = _dbContext.Orders.GetAll().FirstOrDefault(x => x.Id == orderId);
            if (order is null) return;

            if (order.IsCancelled)
            {
                MessageBox.Show("Заказ уже отменён! Нельзя отменить его ещё раз!", "Заказ уже отменён.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonOrderList_CancelOrder.Enabled = false;
                return;
            }

            if (order.OrderBookingTime <= DateTime.UtcNow)
            {
                MessageBox.Show("Время брони наступило, заказ уже открыт! Невозможно отменить его!", "Невозможно отменить заказ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonOrderList_CancelOrder.Enabled = false;
                return;
            }

            bool cancel_result = order.Cancel();
            _dbContext.Orders.Update(order);
            RefreshOrderList();
            RefreshBalanceNumber();
            if (cancel_result)
            {
                MessageBox.Show("Заказ был отменён успешно! Сумма заказа была возвращена на Ваш баланс.", "Успешная отмена заказа!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось отменить заказ по какой-то причине! Попробуйте ещё раз!", "Не удалось отменить заказ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOrderList_ExtendTheOrder_Click(object sender, EventArgs e)
        {
            if (listViewOrderList.SelectedItems[0].Tag is null) return;
            var orderId = (int)listViewOrderList.SelectedItems[0].Tag;
            var order = _dbContext.Orders.GetAll().FirstOrDefault(x => x.Id == orderId);
            if (order is null) return;

            if (order.IsCancelled || order.OrderBookingTime.AddHours(order.OrderHours) < DateTime.UtcNow)
            {
                MessageBox.Show("Заказ уже закончен или отменён! Невозможно продлить его!", "Невозможно продлить заказ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonOrderList_ExtendTheOrder.Enabled = false;
                return;
            }

            string str_hours = Interaction.InputBox("На какое количество часов Вы желаете продлить заказ?\n" + 
                                                    "Нельзя продлить заказ так, чтобы суммарно он составлял 192 часа (8 суток).\n" + 
                                                    $"Тем самым, максимальное разрешённое количество часов на продление: {192 - order.OrderHours}.\n", 
                                                    "Продление заказа", "1");
            if (str_hours == "") return;

            int hours = 0;
            if (!int.TryParse(str_hours, out hours) || hours <= 0 || hours > 192)
            {
                MessageBox.Show("Вы ввели что-то не то! Попробуйте ещё раз!", "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool result = order.ExtendOrder(hours);
            _dbContext.Orders.Update(order);
            RefreshOrderList();
            RefreshBalanceNumber();
            if (!result)
            {
                MessageBox.Show("Заказ не удалось продлить. Либо у Вас не хватает средств на балансе, либо количество арендных часов превышает допустимое.", "Не удалось продлить заказ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Заказ был успешно продлён на выбранное количество часов: {hours}. Новое время окончания заказа: {order.OrderBookingTime.AddHours(order.OrderHours)}.", "Заказ продлён успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonOrderList_OpenCarLocationMap_Click(object sender, EventArgs e)
        {
            if (listViewOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Вы не выбрали заказа, чтобы открыть местоположение машины!", "Невозможно найти машину!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listViewOrderList.SelectedItems[0].Tag is null) return;
            var orderId = (int)listViewOrderList.SelectedItems[0].Tag;
            var order = _dbContext.Orders.GetAll().FirstOrDefault(x => x.Id == orderId);
            if (order is null) return;

            if (order.IsCancelled || order.OrderBookingTime.AddHours(order.OrderHours) < DateTime.UtcNow)
            {
                MessageBox.Show("Заказ уже закончен или отменён! Невозможно просмотреть местоположение автомобиля!", "Невозможно найти автомобиль!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonOrderList_OpenCarLocationMap.Enabled = false;
                return;
            }

            var result = MessageBox.Show("Вы будете перенаправлены на сторонний сайт \"Google Maps\" для просмотра местоположения автомобиля.", "Открыть карту?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var orderedCar = DatabaseContext.DbContext.Cars.Get(order.OrderedCarId);
                orderedCar.CheckCarLocation();
                MessageBox.Show("Карта будет открыта через несколько секунд.", "Карта открывается.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start($"https://www.google.com/maps/search/{orderedCar.LocationX.ToString().Replace(",", ".")},+{orderedCar.LocationY.ToString().Replace(",", ".")}");
            }
        }

        private void toolStripMenuItemListViewOrderList_Copy_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewOrderList.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[1].Text + "\t" +
                              item.SubItems[2].Text + "\t" +
                              item.SubItems[3].Text + "\t" +
                              item.SubItems[4].Text + "\t" +
                              item.SubItems[5].Text + "\t" +
                              item.SubItems[6].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }

                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewOrderList_Copy_ID_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewOrderList.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[1].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewOrderList_Copy_BookingTime_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewOrderList.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[2].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewOrderList_Copy_BookingHours_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewOrderList.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[3].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewOrderList_Copy_OrderEndTime_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewOrderList.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[4].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewOrderList_Copy_OrderStatus_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewOrderList.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[5].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewOrderList_Copy_OrderCost_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewOrderList.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[6].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        #endregion
    }
}
