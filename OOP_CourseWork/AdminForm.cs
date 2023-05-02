using Microsoft.VisualBasic;
using OOP_CourseWork.Controls;
using OOP_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CourseWork
{
    public partial class AdminForm : Form
    {
        public static readonly Color AllowedColor = Color.AliceBlue;
        public static readonly Color DeniedColor = Color.FromArgb(255, 200, 220);
        public Size ImageSize = new Size(252, 168);
        public static List<Image> CarsOrderImages = new List<Image>();

        public AdminForm()
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

            toolTipOrderHours.SetToolTip(textBoxMakeAnOrder_BookingHours, "Введите количество часов, на которые хотите арендовать автомобиль.\n" + 
                                                                          "Не может превышать 192-х часов (8 суток).");

            toolTipOrderBookingDateTime.SetToolTip(dateTimePickerMakeAnOrder_BookingDate, "Укажите время, на которое бронируете автомобиль.\n" + 
                                                                                          "Это будет время начала Вашего заказа.");
            toolTipOrderBookingDateTime.SetToolTip(dateTimePickerMakeAnOrder_BookingTime, "Укажите время, на которое бронируете автомобиль.\n" +
                                                                                          "Это будет время начала Вашего заказа.");

            toolTipOrderBookingEndDateTime.SetToolTip(textBoxMakeAnOrder_BookingEndTime,  "Время окончания заказа, рассчитанное с помощью указанных Вами параметров.");

            toolTipOrderListCarPicture.SetToolTip(pictureBoxCarPicture, "Фотография автомобиля выбранного заказа.");

            tabControlAdmin.SelectedIndexChanged += TabControlAdmin_SelectedIndexChanged;

            listViewPayments.ColumnWidthChanging += ListViewPayments_ColumnWidthChanging;
            listViewServiceReportList.ColumnWidthChanging += ListViewOrderList_ColumnWidthChanging;

            listViewServiceReportList.ItemSelectionChanged += ListViewOrderList_ItemSelectionChanged;

            this.FormClosing += AdminForm_FormClosing;

            LoadCarsOrderImages();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void AdminForm_Load(object sender, EventArgs e)
        {
            RefreshBalanceNumber();
            UpdateSettingsTab();
            RefreshOrderList();
            
            if (!SaveLoadControl.CurrentUser.IsAccountSetupCompleted) tabControlAdmin.SelectTab(3); //Переходим на вкладку "Настройки"
            tabControlAdmin.Deselecting += TabControlAdmin_Deselecting;
        }

        private void TabControlAdmin_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (!SaveLoadControl.CurrentUser.IsAccountSetupCompleted) //Если аккаунт не подтверждён
            {
                e.Cancel = true; //Отмена перехода по вкладке
                MessageBox.Show("Чтобы пользоваться сервисом, Вам нужно сначала подтвердить свой аккаунт. Сделать это можно в настройках.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TabControlAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlAdmin.SelectedIndex == 0) //Вкладка "Список заказов"
            {
                RefreshOrderList();
            }
            else
            if (tabControlAdmin.SelectedIndex == 1) //Вкладка "Сделать заказ"
            {
                SetDefaultMakeAnOrderValues();
                RefreshMakeAnOrderList();
            }
            else
            if (tabControlAdmin.SelectedIndex == 2) //Вкладка "Пополнение баланса"
            {
                RefreshPaymentsList();
                textBoxPayment_CardNumber.Text = ((Admin)SaveLoadControl.CurrentUser).CardNumber;
            } else
            if (tabControlAdmin.SelectedIndex == 3) //Вкладка "Настройки"
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

            textBoxSettings_DriverLicense.Text = ((Admin)SaveLoadControl.CurrentUser).DriverLicense;
            textBoxSettings_Passport.Text = ((Admin)SaveLoadControl.CurrentUser).Passport;
            textBoxSettings_CardNumber.Text = ((Admin)SaveLoadControl.CurrentUser).CardNumber;

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
                !((Admin)SaveLoadControl.CurrentUser).ChangeSettings(textBoxSettings_Password.Text, textBoxSettings_DriverLicense.Text, 
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
            labelBalanceNumber.Text = ((Admin)SaveLoadControl.CurrentUser).Balance.ToString().Replace(",", ".");
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

            if (((Admin)SaveLoadControl.CurrentUser).BalanceDeposit(Math.Round(double.Parse(textBoxPayments_Cost.Text.Replace(".", ",")), 2), textBoxPayments_SecretCode.Text))
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

        private void ListViewPayments_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewPayments.Columns[e.ColumnIndex].Width;
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

            var cars = SaveLoadControl.Cars.OrderBy(x => x.PricePerHour).ToArray();

            ImageList imageListLarge = new ImageList();
            imageListLarge.ImageSize = ImageSize;
            for (int i = 0; i < cars.Count(); i++)
            {
                Image image = new Bitmap(CarsOrderImages[i], ImageSize);
                
                if (SaveLoadControl.Cars[cars[i].Id].IsOnServiceNow)
                {
                    image = DrawTextOnImage(image, ImageSize, "Сейчас на\nобслуживании", 13);
                } 
                else
                if (SaveLoadControl.Cars[cars[i].Id].IsOrderedNow)
                {
                    image = DrawTextOnImage(image, ImageSize, "Уже\nзаказана", 16);
                }

                imageListLarge.Images.Add(image);
            }
            listViewMakeAnOrder.LargeImageList = imageListLarge;

            foreach (var car in cars)
            {
                string title = "";
                title += car.Brand.Name + " ";
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

            if (SaveLoadControl.Orders.Count(x => x.OrderPayment.User == SaveLoadControl.CurrentUser && x.OrderPayment.CreatedTime >= DateTime.Now.AddHours(-1)) >= 3)
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
            Car car = SaveLoadControl.Cars[carId];

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

            Payment payment = new Payment(SaveLoadControl.Payments.Count, (Admin)SaveLoadControl.CurrentUser, hours * car.PricePerHour);
            if (!payment.Pay())
            {
                MessageBox.Show("Заказ НЕ был создан, его не удалось оплатить! Кажется, у Вас недостаточно средств на балансе.", "Ошибка оплаты!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Order order = new Order(SaveLoadControl.Orders.Count, payment, car, (Admin)SaveLoadControl.CurrentUser, bookingDateTime, hours);
            SaveLoadControl.Orders.Add(order);

            RefreshBalanceNumber();
            RefreshMakeAnOrderList();

            dateTimePickerMakeAnOrder_BookingDate.Value = bookingDateTime;
            dateTimePickerMakeAnOrder_BookingTime.Value = bookingDateTime;
            MessageBox.Show($"Заказ был успешно создан! Начало времени бронирования: {bookingDateTime}.", "Заказ создан успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LoadCarsOrderImages()
        {
            CarsOrderImages.Clear();
            for (int i = 0; i < SaveLoadControl.Cars.Count; i++)
            {
                CarsOrderImages.Add(Image.FromFile($"images\\car_{i}.png"));
            }
        }

        #endregion

        #region Order list

        public void RefreshOrderList()
        {
            /*SaveLoadControl.Orders.Clear();
            SaveLoadControl.Payments.Clear();
            ((Admin)SaveLoadControl.CurrentUser).BalanceIncrease(20);*/

            listViewServiceReportList.Items.Clear();

            var orders = SaveLoadControl.Orders.Where(x => x.OrderPayment.User.Id == SaveLoadControl.CurrentUser.Id)
                                               .OrderByDescending(x => x.OrderBookingTime).ToArray();

            int counter = orders.Length;
            foreach (var order in orders)
            {
                string[] arr = new string[7];
                arr[0] = "";
                arr[1] = (counter--).ToString();
                arr[2] = order.OrderBookingTime.ToString();
                arr[3] = order.OrderHours.ToString();
                arr[4] = order.OrderBookingTime.AddHours(order.OrderHours).ToString();
                arr[5] = order.IsCancelled ? "Отменён" : (order.OrderBookingTime.AddHours(order.OrderHours) <= DateTime.Now ? "Закончен" : "Активен");
                arr[6] = order.OrderPayment.Cost.ToString("N2").Replace(",", ".");

                ListViewItem item = new ListViewItem(arr);
                item.Tag = order.Id;
                item.UseItemStyleForSubItems = false;
                item.ForeColor = order.IsCancelled ? Color.Red : Color.Green;
                listViewServiceReportList.Items.Add(item);
            }

            listViewServiceReportList.Refresh();
        }

        private void ListViewOrderList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewServiceReportList.Columns[e.ColumnIndex].Width;
        }

        private void ListViewOrderList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewServiceReportList.SelectedItems.Count != 0)
            {
                if (listViewServiceReportList.SelectedItems[0].Tag is null) return;
                var orderId = (int)listViewServiceReportList.SelectedItems[0].Tag;
                var order = SaveLoadControl.Orders.FirstOrDefault(x => x.Id == orderId);
                if (order is null) return;

                if (!order.IsCancelled && order.OrderBookingTime > DateTime.Now)
                    buttonServiceReportList_CancelOrder.Enabled = true;
                else
                    buttonServiceReportList_CancelOrder.Enabled = false;

                if (!order.IsCancelled && order.OrderBookingTime.AddHours(order.OrderHours) >= DateTime.Now)
                {
                    buttonServiceReportList_OpenCarLocationMap.Enabled = true;
                    buttonServiceReportList_ExtendTheOrder.Enabled = true;
                }
                else
                {
                    buttonServiceReportList_OpenCarLocationMap.Enabled = false;
                    buttonServiceReportList_ExtendTheOrder.Enabled = false;
                }

                pictureBoxCarPicture.Image = new Bitmap(CarsOrderImages[order.OrderedCar.Id], pictureBoxCarPicture.Size);
                textBoxServiceReportList_CarBrand.Text = order.OrderedCar.Brand.Name;
                textBoxServiceReportList_CarModel.Text = order.OrderedCar.Model;
                textBoxServiceReportList_ProductionYear.Text = order.OrderedCar.ProductionYear.ToString("yyyy");
                textBoxServiceReportList_PricePerHour.Text = order.OrderedCar.PricePerHour.ToString("N2").Replace(",", ".");
                textBoxServiceReportList_CarLicensePlate.Text = order.OrderedCar.CarLicensePlate;
                textBoxServiceReportList_LastServiceDate.Text = order.OrderedCar.LastServiceTime.ToString("d");
            } else
            {
                pictureBoxCarPicture.Image = null;
                textBoxServiceReportList_CarBrand.Text = "";
                textBoxServiceReportList_CarModel.Text = "";
                textBoxServiceReportList_ProductionYear.Text = "";
                textBoxServiceReportList_PricePerHour.Text = "";
                textBoxServiceReportList_CarLicensePlate.Text = "";
                textBoxServiceReportList_LastServiceDate.Text = "";
                buttonServiceReportList_CancelOrder.Enabled = false;
                buttonServiceReportList_OpenCarLocationMap.Enabled = false;
                buttonServiceReportList_ExtendTheOrder.Enabled = false;
            }
        }

        private void buttonOrderList_CancelOrder_Click(object sender, EventArgs e)
        {
            if (listViewServiceReportList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Вы не выбрали заказа, чтобы его отменить!", "Невозможно отменить заказ!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите отменить выбранный заказ?", "Отменить заказ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            if (listViewServiceReportList.SelectedItems[0].Tag is null) return;
            var orderId = (int)listViewServiceReportList.SelectedItems[0].Tag;
            var order = SaveLoadControl.Orders.FirstOrDefault(x => x.Id == orderId);
            if (order is null) return;

            if (order.IsCancelled)
            {
                MessageBox.Show("Заказ уже отменён! Нельзя отменить его ещё раз!", "Заказ уже отменён.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonServiceReportList_CancelOrder.Enabled = false;
                return;
            }

            if (order.OrderBookingTime <= DateTime.Now)
            {
                MessageBox.Show("Время брони наступило, заказ уже открыт! Невозможно отменить его!", "Невозможно отменить заказ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonServiceReportList_CancelOrder.Enabled = false;
                return;
            }

            bool cancel_result = order.Cancel();
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
            if (listViewServiceReportList.SelectedItems[0].Tag is null) return;
            var orderId = (int)listViewServiceReportList.SelectedItems[0].Tag;
            var order = SaveLoadControl.Orders.FirstOrDefault(x => x.Id == orderId);
            if (order is null) return;

            if (order.IsCancelled || order.OrderBookingTime.AddHours(order.OrderHours) < DateTime.Now)
            {
                MessageBox.Show("Заказ уже закончен или отменён! Невозможно продлить его!", "Невозможно продлить заказ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonServiceReportList_ExtendTheOrder.Enabled = false;
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
            if (listViewServiceReportList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Вы не выбрали заказа, чтобы открыть местоположение машины!", "Невозможно найти машину!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listViewServiceReportList.SelectedItems[0].Tag is null) return;
            var orderId = (int)listViewServiceReportList.SelectedItems[0].Tag;
            var order = SaveLoadControl.Orders.FirstOrDefault(x => x.Id == orderId);
            if (order is null) return;

            if (order.IsCancelled || order.OrderBookingTime.AddHours(order.OrderHours) < DateTime.Now)
            {
                MessageBox.Show("Заказ уже закончен или отменён! Невозможно просмотреть местоположение автомобиля!", "Невозможно найти автомобиль!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonServiceReportList_OpenCarLocationMap.Enabled = false;
                return;
            }

            var result = MessageBox.Show("Вы будете перенаправлены на сторонний сайт \"Google Maps\" для просмотра местоположения автомобиля.", "Открыть карту?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                order.OrderedCar.CheckCarLocation();
                MessageBox.Show("Карта будет открыта через несколько секунд.", "Карта открывается.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start($"https://www.google.com/maps/search/{order.OrderedCar.LocationX.ToString().Replace(",", ".")},+{order.OrderedCar.LocationY.ToString().Replace(",", ".")}");
            }
        }

        private void toolStripMenuItemListViewOrderList_Copy_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewServiceReportList.SelectedItems;
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
                var selectedItems = listViewServiceReportList.SelectedItems;
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
                var selectedItems = listViewServiceReportList.SelectedItems;
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
                var selectedItems = listViewServiceReportList.SelectedItems;
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
                var selectedItems = listViewServiceReportList.SelectedItems;
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
                var selectedItems = listViewServiceReportList.SelectedItems;
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
                var selectedItems = listViewServiceReportList.SelectedItems;
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
