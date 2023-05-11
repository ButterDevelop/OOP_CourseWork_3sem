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
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
        public static string AddNewCarImagePath = "";

        public AdminForm()
        {
            InitializeComponent();

            toolTipOrderListCarPicture.SetToolTip(pictureBoxServiceReportList_CarPicture, "Фотография выбранного автомобиля.");
            toolTipOrderListCarPicture.SetToolTip(pictureBoxMakeServiceReport_CarPicture, "Фотография выбранного автомобиля.");

            tabControlAdmin.SelectedIndexChanged += TabControlAdmin_SelectedIndexChanged;

            listViewUsers.ColumnWidthChanging += ListViewPayments_ColumnWidthChanging;
            listViewServiceReportList.ColumnWidthChanging += ListViewServiceReportList_ColumnWidthChanging;

            listViewServiceReportList.ItemSelectionChanged += listViewServiceReportList_ItemSelectionChanged;
            listViewMakeServiceReport.ItemSelectionChanged += ListViewMakeServiceReport_ItemSelectionChanged;

            this.FormClosing += AdminForm_FormClosing;

            CarsOrderImages = UtilsControl.LoadCarsOrderImages();
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
            listViewServiceReportList_ItemSelectionChanged_SetDefault();
            ListViewMakeServiceReport_ItemSelectionChanged_SetDefault();
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

        private void buttonSettings_Save_Click(object sender, EventArgs e)
        {
            
        }

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

        #region Payments

        private void buttonPayments_CreatePayment_Click(object sender, EventArgs e)
        {

        }

        private void ListViewPayments_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewUsers.Columns[e.ColumnIndex].Width;
        }

        public void RefreshPaymentsList()
        {
            listViewUsers.Items.Clear();

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
                listViewUsers.Items.Add(item);
            }

            listViewUsers.Refresh();
        }

        private void toolStripMenuItemListView_Copy_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewUsers.SelectedItems;
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
                var selectedItems = listViewUsers.SelectedItems;
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
                var selectedItems = listViewUsers.SelectedItems;
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
                var selectedItems = listViewUsers.SelectedItems;
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
                var selectedItems = listViewUsers.SelectedItems;
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
                var selectedItems = listViewUsers.SelectedItems;
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
                string[] arr = new string[11];
                arr[0] = "";
                arr[1] = car.Id.ToString();
                arr[2] = car.IsHidden ? "Да" : "Нет";
                arr[3] = car.IsOnServiceNow ? "Обслуживается" : "В работе";
                arr[4] = car.Brand;
                arr[5] = car.Model;
                arr[6] = car.CarLicensePlate;
                arr[7] = car.PricePerHour.ToString("N2").Replace(",", ".");
                arr[8] = car.ProductionYear.ToString("yyyy");
                arr[9] = car.BuyTime.ToString();
                arr[10] = car.LastServiceTime == DateTime.MinValue ? "Не выставлено" : car.LastServiceTime.ToString();

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
                buttonMakeServiceReport_HideShowCar.Enabled = true;

                if (!car.IsOnServiceNow)
                    buttonMakeServiceReport_SendToService.Enabled = true;
                else
                    buttonMakeServiceReport_SendToService.Enabled = false;

                if (!car.IsHidden)
                    buttonMakeServiceReport_HideShowCar.Text = "Спрятать авто";
                else
                    buttonMakeServiceReport_HideShowCar.Text = "Показать авто";

                pictureBoxMakeServiceReport_CarPicture.Image = new Bitmap(CarsOrderImages[car.Id], pictureBoxMakeServiceReport_CarPicture.Size);
            }
            else
            {
                ListViewMakeServiceReport_ItemSelectionChanged_SetDefault();
            }
        }

        public void ListViewMakeServiceReport_ItemSelectionChanged_SetDefault()
        {
            pictureBoxMakeServiceReport_CarPicture.Image = null;
            buttonMakeServiceReport_OpenCarLocationMap.Enabled = false;
            buttonMakeServiceReport_SendToService.Enabled = false;
            buttonMakeServiceReport_HideShowCar.Enabled = false;
        }

        public void MakeServiceReport_AddNewCar_SetDefault()
        {
            pictureBoxMakeServiceReport_AddNewCarPicture.Image = null;
            labelClickThisToAddNewCarImage.Visible = true;

            textBoxMakeMakeServiceReport_NewCarBrand.Text = "";
            textBoxMakeMakeServiceReport_NewCarLicensePlate.Text = "";
            textBoxMakeMakeServiceReport_NewCarModel.Text = "";
            textBoxMakeMakeServiceReport_NewCarPricePerHour.Text = "";
            textBoxMakeMakeServiceReport_NewCarProductionYear.Text = "";

            textBoxMakeMakeServiceReport_NewCarBrand.BackColor = AllowedColor;
            textBoxMakeMakeServiceReport_NewCarLicensePlate.BackColor = AllowedColor;
            textBoxMakeMakeServiceReport_NewCarModel.BackColor = AllowedColor;
            textBoxMakeMakeServiceReport_NewCarPricePerHour.BackColor = AllowedColor;
            textBoxMakeMakeServiceReport_NewCarProductionYear.BackColor = AllowedColor;
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
            if (textBoxMakeMakeServiceReport_Description.Text == "")
            {
                MessageBox.Show("Вы не ввели ничего в описание, чтобы отправить автомобиль на обслуживание!", "Что-то пошло не так!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listViewMakeServiceReport.SelectedItems[0].Tag is null) return;
            var carId = (int)listViewMakeServiceReport.SelectedItems[0].Tag;
            var car = SaveLoadControl.Cars.FirstOrDefault(x => x.Id == carId);
            if (car is null) return;

            var result = MessageBox.Show("Вы уверены, что хотите отправить выбранный автомобиль на обслуживание?", "Отправить на обслуживание?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            ((Admin)SaveLoadControl.CurrentUser).PutCarOnService(car, textBoxMakeMakeServiceReport_Description.Text);

            MessageBox.Show("Автомобиль был успешно отправлен на обслуживание.", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshServiceReportList();
            RefreshMakeServiceReport();
        }

        private void textBoxMakeMakeServiceReport_NewCarBrand_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMakeMakeServiceReport_NewCarBrand.Text == "")
            {
                textBoxMakeMakeServiceReport_NewCarBrand.BackColor = DeniedColor;
            }
            else
            {
                textBoxMakeMakeServiceReport_NewCarBrand.BackColor = AllowedColor;
            }
        }

        private void textBoxMakeMakeServiceReport_NewCarModel_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMakeMakeServiceReport_NewCarModel.Text == "")
            {
                textBoxMakeMakeServiceReport_NewCarModel.BackColor = DeniedColor;
            }
            else
            {
                textBoxMakeMakeServiceReport_NewCarModel.BackColor = AllowedColor;
            }
        }

        private void textBoxMakeMakeServiceReport_NewCarPricePerHour_TextChanged(object sender, EventArgs e)
        {
            double cost = 0;
            if (!double.TryParse(textBoxMakeMakeServiceReport_NewCarPricePerHour.Text.Replace(".", ","), out cost) || cost <= 0)
            {
                textBoxMakeMakeServiceReport_NewCarPricePerHour.BackColor = DeniedColor;
            }
            else
            {
                textBoxMakeMakeServiceReport_NewCarPricePerHour.BackColor = AllowedColor;
            }
        }

        private void textBoxMakeMakeServiceReport_NewCarProductionYear_TextChanged(object sender, EventArgs e)
        {
            int year = 0;
            if (!int.TryParse(textBoxMakeMakeServiceReport_NewCarProductionYear.Text.Replace(".", ","), out year) || year < 1886)
            {
                textBoxMakeMakeServiceReport_NewCarProductionYear.BackColor = DeniedColor;
            }
            else
            {
                textBoxMakeMakeServiceReport_NewCarProductionYear.BackColor = AllowedColor;
            }
        }

        private void textBoxMakeMakeServiceReport_NewCarLicensePlate_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMakeMakeServiceReport_NewCarLicensePlate.Text == "")
            {
                textBoxMakeMakeServiceReport_NewCarLicensePlate.BackColor = DeniedColor;
            }
            else
            {
                textBoxMakeMakeServiceReport_NewCarLicensePlate.BackColor = AllowedColor;
            }
        }

        private void labelClickThisToAddNewCarImage_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp, *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            Image image;
            try
            {
                image = Image.FromFile(openFileDialog.FileName);
            }
            catch
            {
                MessageBox.Show("Не удаётся загрузить выбранную Вами картинку!", "Ошибка загрузки картинки!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pictureBoxMakeServiceReport_AddNewCarPicture.Image = new Bitmap(image, pictureBoxMakeServiceReport_AddNewCarPicture.Size);
            labelClickThisToAddNewCarImage.Visible = false;

            AddNewCarImagePath = openFileDialog.FileName;
        }

        private void pictureBoxMakeServiceReport_AddNewCarPicture_DoubleClick(object sender, EventArgs e)
        {
            labelClickThisToAddNewCarImage_DoubleClick(sender, e);
        }

        private void buttonMakeServiceReport_AddNewCar_Click(object sender, EventArgs e)
        {
            textBoxMakeMakeServiceReport_NewCarBrand_TextChanged(null, null);
            textBoxMakeMakeServiceReport_NewCarModel_TextChanged(null, null);
            textBoxMakeMakeServiceReport_NewCarPricePerHour_TextChanged(null, null);
            textBoxMakeMakeServiceReport_NewCarProductionYear_TextChanged(null, null);
            textBoxMakeMakeServiceReport_NewCarLicensePlate_TextChanged(null, null);

            if (textBoxMakeMakeServiceReport_NewCarBrand.BackColor == DeniedColor ||
                textBoxMakeMakeServiceReport_NewCarModel.BackColor == DeniedColor ||
                textBoxMakeMakeServiceReport_NewCarPricePerHour.BackColor == DeniedColor ||
                textBoxMakeMakeServiceReport_NewCarProductionYear.BackColor == DeniedColor ||
                textBoxMakeMakeServiceReport_NewCarLicensePlate.BackColor == DeniedColor)
            {
                MessageBox.Show("Вы ввели что-то не то! Попробуйте ещё раз!", "Ошибка при добавлении авто!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pictureBoxMakeServiceReport_AddNewCarPicture.Image is null)
            {
                MessageBox.Show("Вы не добавили фотографию для автомобиля!", "Ошибка при добавлении авто!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите добавить этот автомобиль в систему? Пожалуйста, перепроверьте данные.", "Подтверждение добавления автомобиля.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            if (!File.Exists(AddNewCarImagePath))
            {
                MessageBox.Show("Выбранного Вами файла фотографии для автомобиля больше не существует! Попробуйте ещё раз!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Car car = new Car(SaveLoadControl.Cars.Count, 
                              textBoxMakeMakeServiceReport_NewCarBrand.Text,
                              textBoxMakeMakeServiceReport_NewCarModel.Text,
                              textBoxMakeMakeServiceReport_NewCarLicensePlate.Text,
                              double.Parse(textBoxMakeMakeServiceReport_NewCarPricePerHour.Text.Replace(".", ",")),
                              new DateTime(int.Parse(textBoxMakeMakeServiceReport_NewCarProductionYear.Text), 1, 1),
                              DateTime.Now,
                              DateTime.MinValue,
                              0, 0, true);

            try
            {
                Image image = new Bitmap(Image.FromFile(AddNewCarImagePath), pictureBoxMakeServiceReport_AddNewCarPicture.Size);
                string path = $"images\\car_{car.Id}.png";
                image.Save(path);
                CarsOrderImages.Add(Image.FromFile(path));
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить заданную Вами фотографию!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveLoadControl.Cars.Add(car);

            MakeServiceReport_AddNewCar_SetDefault();

            RefreshMakeServiceReport();

            MessageBox.Show("Автомобиль был успешно добавлен в систему!", "Успешное добавление автомобиля!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonMakeServiceReport_HideShowCar_Click(object sender, EventArgs e)
        {
            if (listViewMakeServiceReport.SelectedItems[0].Tag is null) return;
            var carId = (int)listViewMakeServiceReport.SelectedItems[0].Tag;
            var car = SaveLoadControl.Cars.FirstOrDefault(x => x.Id == carId);
            if (car is null) return;

            car.HideOrShow();

            RefreshServiceReportList();
            RefreshMakeServiceReport();

            MessageBox.Show($"Автомобиль был успешно {(car.IsHidden ? "скрыт" : "показан")}.", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string[] arr = new string[11];
                arr[0] = ""; 
                arr[1] = report.Id.ToString();
                arr[2] = report.Worker is null ? "" : report.Worker.FullName.ToString();
                arr[3] = report.Worker is null ? "" : report.Worker.SalaryPerDay.ToString("N2").Replace(",", ".");
                arr[4] = report.StartedDate.ToString();
                arr[5] = report.PlannedCompletionDays == 0 ? "Не выставлено" : report.PlannedCompletionDays.ToString();
                arr[6] = report.FinishedDate == DateTime.MinValue ? "Не выставлено" : report.FinishedDate.ToString();
                arr[7] = report.AdditionalCost.ToString("N2").Replace(",", ".");
                arr[8] = report.Cost.ToString("N2").Replace(",", ".");
                arr[9] = report.IsStarted ? "Да" : "Нет";
                arr[10] = report.IsFinished ? "Да" : "Нет";

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

                textBoxServiceReportList_Description.Text = report.Description;
                textBoxServiceReportList_EmployeeReportString.Text = report.EmployeeReport;

                pictureBoxServiceReportList_CarPicture.Image = new Bitmap(CarsOrderImages[report.ServicedCar.Id], pictureBoxServiceReportList_CarPicture.Size);
                textBoxServiceReportList_CarBrand.Text = report.ServicedCar.Brand;
                textBoxServiceReportList_CarModel.Text = report.ServicedCar.Model;
                textBoxServiceReportList_ProductionYear.Text = report.ServicedCar.ProductionYear.ToString("yyyy");
                textBoxServiceReportList_PricePerHour.Text = report.ServicedCar.PricePerHour.ToString("N2").Replace(",", ".");
                textBoxServiceReportList_CarLicensePlate.Text = report.ServicedCar.CarLicensePlate;
                textBoxServiceReportList_LastServiceDate.Text = report.ServicedCar.LastServiceTime == DateTime.MinValue ? "Не выставлено" : report.ServicedCar.LastServiceTime.ToString("d");
            } 
            else
            {
                listViewServiceReportList_ItemSelectionChanged_SetDefault();
            }
        }

        public void listViewServiceReportList_ItemSelectionChanged_SetDefault()
        {
            textBoxServiceReportList_Description.Text = "";
            textBoxServiceReportList_EmployeeReportString.Text = "";

            pictureBoxServiceReportList_CarPicture.Image = null;
            textBoxServiceReportList_CarBrand.Text = "";
            textBoxServiceReportList_CarModel.Text = "";
            textBoxServiceReportList_ProductionYear.Text = "";
            textBoxServiceReportList_PricePerHour.Text = "";
            textBoxServiceReportList_CarLicensePlate.Text = "";
            textBoxServiceReportList_LastServiceDate.Text = "";
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
                              item.SubItems[3].Text + "\t" +
                              item.SubItems[4].Text + "\t" +
                              item.SubItems[5].Text + "\t" +
                              item.SubItems[6].Text + "\t" +
                              item.SubItems[7].Text + "\t" +
                              item.SubItems[8].Text + "\t" +
                              item.SubItems[9].Text + "\t" +
                              item.SubItems[10].Text;
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

        private void toolStripMenuItemListViewServiceReportList_Copy_FullName_Click(object sender, EventArgs e)
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

        private void toolStripMenuItemListViewServiceReportList_Copy_PricePerDay_Click(object sender, EventArgs e)
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

        private void toolStripMenuItemListViewServiceReportList_Copy_StartedDate_Click(object sender, EventArgs e)
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

        private void toolStripMenuItemListViewServiceReportList_Copy_PlannedDays_Click(object sender, EventArgs e)
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

        private void toolStripMenuItemListViewServiceReportList_Copy_FinishedDate_Click(object sender, EventArgs e)
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

        private void toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewServiceReportList.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[7].Text;
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
                    result += item.SubItems[8].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewServiceReportList_Copy_IsStarted_Click(object sender, EventArgs e)
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

        private void toolStripMenuItemListViewServiceReportList_Copy_IsFinished_Click(object sender, EventArgs e)
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

        #endregion
    }
}
