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

            toolTipOrderListCarPicture.SetToolTip(pictureBoxServiceReportList_CarPicture, "Фотография автомобиля выбранного заказа.");

            tabControlAdmin.SelectedIndexChanged += TabControlAdmin_SelectedIndexChanged;

            listViewPayments.ColumnWidthChanging += ListViewPayments_ColumnWidthChanging;
            listViewServiceReportList.ColumnWidthChanging += ListViewServiceReportList_ColumnWidthChanging;

            listViewServiceReportList.ItemSelectionChanged += listViewServiceReportList_ItemSelectionChanged;
            listViewMakeServiceReport.ItemSelectionChanged += ListViewMakeServiceReport_ItemSelectionChanged;

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
            RefreshServiceReportList();
            
            if (!SaveLoadControl.CurrentUser.IsAccountSetupCompleted) tabControlAdmin.SelectTab(3); //Переходим на вкладку "Настройки"
            tabControlAdmin.Deselecting += TabControlAdmin_Deselecting;
        }

        public void LoadCarsOrderImages()
        {
            CarsOrderImages.Clear();
            for (int i = 0; i < SaveLoadControl.Cars.Count; i++)
            {
                CarsOrderImages.Add(Image.FromFile($"images\\car_{i}.png"));
            }
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
                RefreshServiceReportList();
            }
            else
            if (tabControlAdmin.SelectedIndex == 1) //Вкладка "Отправить на обслуживание"
            {
                RefreshMakeServiceReport();
            }
            else
            if (tabControlAdmin.SelectedIndex == 2) //Вкладка "Пополнение баланса"
            {
                RefreshPaymentsList();
            } 
            else
            if (tabControlAdmin.SelectedIndex == 3) //Вкладка "Настройки"
            {
                
            }
        }

        #region Settings

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

        #region Make Service Report

        public void RefreshMakeServiceReport()
        {
            listViewMakeServiceReport.Items.Clear();

            var cars = SaveLoadControl.Cars.OrderByDescending(x => x.Id).ToArray();

            foreach (var car in cars)
            {
                string[] arr = new string[10];
                arr[0] = "";
                arr[1] = (car.Id + 1).ToString();
                arr[2] = car.IsOnServiceNow ? "Обслуживается" : "В работе";
                arr[3] = car.Brand;
                arr[4] = car.Model;
                arr[5] = car.CarLicensePlate;
                arr[6] = car.PricePerHour.ToString("N2").Replace(",", ".");
                arr[7] = car.ProductionYear.ToString("yyyy");
                arr[8] = car.BuyTime.ToString();
                arr[9] = car.LastServiceTime.ToString();

                ListViewItem item = new ListViewItem(arr);
                item.Tag = car.Id;
                item.UseItemStyleForSubItems = false;
                item.ForeColor = car.IsOnServiceNow ? Color.Red : Color.Green;
                listViewMakeServiceReport.Items.Add(item);
            }

            listViewMakeServiceReport.Refresh();
        }

        private void ListViewMakeServiceReport_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewServiceReportList.Columns[e.ColumnIndex].Width;
        }

        private void ListViewMakeServiceReport_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewMakeServiceReport.SelectedItems.Count != 0)
            {
                if (listViewMakeServiceReport.SelectedItems[0].Tag is null) return;
                var carId = (int)listViewMakeServiceReport.SelectedItems[0].Tag;
                var car = SaveLoadControl.Cars.FirstOrDefault(x => x.Id == carId);
                if (car is null) return;

                buttonMakeServiceReport_OpenCarLocationMap.Enabled = true;

                if (!car.IsOnServiceNow)
                {
                    buttonMakeServiceReport_SendToService.Enabled = true;
                }
                else
                {
                    buttonMakeServiceReport_SendToService.Enabled = false;
                }

                pictureBoxMakeServiceReport_CarPicture.Image = new Bitmap(CarsOrderImages[car.Id], pictureBoxMakeServiceReport_CarPicture.Size);
            }
            else
            {
                pictureBoxMakeServiceReport_CarPicture.Image = null;
                buttonMakeServiceReport_OpenCarLocationMap.Enabled = false;
                buttonMakeServiceReport_SendToService.Enabled = false;
            }
        }

        private void buttonMakeServiceReport_OpenCarLocationMap_Click(object sender, EventArgs e)
        {
            if (listViewMakeServiceReport.SelectedItems.Count == 0)
            {
                MessageBox.Show("Вы не выбрали машину, чтобы открыть её местоположение!", "Невозможно найти машину!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listViewMakeServiceReport.SelectedItems[0].Tag is null) return;
            var carId = (int)listViewMakeServiceReport.SelectedItems[0].Tag;
            var car = SaveLoadControl.Cars.FirstOrDefault(x => x.Id == carId);
            if (car is null) return;

            var result = MessageBox.Show("Вы будете перенаправлены на сторонний сайт \"Google Maps\" для просмотра местоположения автомобиля.", "Открыть карту?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                car.CheckCarLocation();
                MessageBox.Show("Карта будет открыта через несколько секунд.", "Карта открывается.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start($"https://www.google.com/maps/search/{car.LocationX.ToString().Replace(",", ".")},+{car.LocationY.ToString().Replace(",", ".")}");
            }
        }

        private void buttonMakeServiceReport_SendToService_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItemListViewMakeServiceReport_Copy_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewMakeServiceReport.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[1].Text + "\t" +
                              item.SubItems[2].Text + "\t" +
                              item.SubItems[3].Text + "\t" +
                              item.SubItems[4].Text + "\t" +
                              item.SubItems[5].Text + "\t" +
                              item.SubItems[6].Text + "\t" +
                              item.SubItems[7].Text + "\t" +
                              item.SubItems[8].Text + "\t" +
                              item.SubItems[9].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }

                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewMakeServiceReport_Copy_ID_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewMakeServiceReport.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[1].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewMakeServiceReport_Copy_Status_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewMakeServiceReport.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[2].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewMakeServiceReport_Copy_CarBrand_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewMakeServiceReport.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[3].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewMakeServiceReport_Copy_CarModel_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewMakeServiceReport.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[4].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewMakeServiceReport_Copy_CarLicensePlate_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewMakeServiceReport.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[5].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewMakeServiceReport_Copy_CarPricePerHour_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewMakeServiceReport.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[6].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewMakeServiceReport_Copy_CarProductionYear_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewMakeServiceReport.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[7].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewMakeServiceReport_Copy_CarBuyTime_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewMakeServiceReport.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[8].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewMakeServiceReport_Copy_CarLastServiceDate_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewMakeServiceReport.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[9].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        #endregion

        #region Service Report list

        public void RefreshServiceReportList()
        {
            listViewServiceReportList.Items.Clear();

            var reports = SaveLoadControl.ServiceReports.OrderByDescending(x => x.StartedDate).ToArray();

            int counter = reports.Length;
            foreach (var report in reports)
            {
                string[] arr = new string[13];
                arr[0] = ""; 
                arr[1] = report.Id.ToString();
                arr[2] = report.Description;
                arr[3] = report.StartedDate.ToString();
                arr[4] = report.FinishedDate.ToString();
                arr[5] = report.Cost.ToString("N2").Replace(",", ".");
                arr[6] = report.PlannedCompletionDays.ToString();
                arr[7] = report.IsStarted.ToString();
                arr[8] = report.IsFinished.ToString();
                arr[9] = report.AdditionalCost.ToString("N2").Replace(",", ".");
                arr[10] = report.Worker is null ? "" : report.Worker.FullName.ToString();
                arr[11] = report.Worker is null ? "" : report.Worker.SalaryPerDay.ToString("N2").Replace(",", ".");
                arr[12] = report.EmployeeReport;

                ListViewItem item = new ListViewItem(arr);
                item.Tag = report.Id;
                item.UseItemStyleForSubItems = false;
                item.ForeColor = report.IsFinished ? Color.Green : Color.Red;
                listViewServiceReportList.Items.Add(item);
            }

            listViewServiceReportList.Refresh();
        }

        private void ListViewServiceReportList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewServiceReportList.Columns[e.ColumnIndex].Width;
        }

        private void listViewServiceReportList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewServiceReportList.SelectedItems.Count != 0)
            {
                if (listViewServiceReportList.SelectedItems[0].Tag is null) return;
                var reportId = (int)listViewServiceReportList.SelectedItems[0].Tag;
                var report = SaveLoadControl.ServiceReports.FirstOrDefault(x => x.Id == reportId);
                if (report is null) return;

                pictureBoxServiceReportList_CarPicture.Image = new Bitmap(CarsOrderImages[report.ServicedCar.Id], pictureBoxServiceReportList_CarPicture.Size);
                textBoxServiceReportList_CarBrand.Text = report.ServicedCar.Brand;
                textBoxServiceReportList_CarModel.Text = report.ServicedCar.Model;
                textBoxServiceReportList_ProductionYear.Text = report.ServicedCar.ProductionYear.ToString("yyyy");
                textBoxServiceReportList_PricePerHour.Text = report.ServicedCar.PricePerHour.ToString("N2").Replace(",", ".");
                textBoxServiceReportList_CarLicensePlate.Text = report.ServicedCar.CarLicensePlate;
                textBoxServiceReportList_LastServiceDate.Text = report.ServicedCar.LastServiceTime.ToString("d");
            } 
            else
            {
                pictureBoxServiceReportList_CarPicture.Image = null;
                textBoxServiceReportList_CarBrand.Text = "";
                textBoxServiceReportList_CarModel.Text = "";
                textBoxServiceReportList_ProductionYear.Text = "";
                textBoxServiceReportList_PricePerHour.Text = "";
                textBoxServiceReportList_CarLicensePlate.Text = "";
                textBoxServiceReportList_LastServiceDate.Text = "";
            }
        }

        private void toolStripMenuItemListViewServiceReportList_Copy_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewServiceReportList.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[1].Text + "\t" +
                              item.SubItems[2].Text + "\t" +
                              item.SubItems[5].Text + "\t" +
                              item.SubItems[9].Text + "\t" +
                              item.SubItems[10].Text + "\t" +
                              item.SubItems[12].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }

                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewServiceReportList_Copy_ID_Click(object sender, EventArgs e)
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

        private void toolStripMenuItemListViewServiceReportList_Copy_Description_Click(object sender, EventArgs e)
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

        private void toolStripMenuItemListViewServiceReportList_Copy_Cost_Click(object sender, EventArgs e)
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

        private void toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewServiceReportList.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[9].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewServiceReportList_Copy_EmployeeName_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewServiceReportList.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[10].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewServiceReportList_Copy_EmployeeReport_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewServiceReportList.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[12].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        #endregion
    }
}
