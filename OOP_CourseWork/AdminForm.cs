using OOP_CourseWork.Controls;
using OOP_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OOP_CourseWork
{
    public partial class AdminForm : Form
    {
        public static readonly Color AllowedColor = Color.AliceBlue;
        public static readonly Color DeniedColor = Color.FromArgb(255, 200, 220);
        public static List<Image> CarsOrderImages = new List<Image>();
        public static string AddNewCarImagePath = "";

        public AdminForm()
        {
            InitializeComponent();

            toolTipOrderListCarPicture.SetToolTip(pictureBoxServiceReportList_CarPicture, "Фотография выбранного автомобиля.");
            toolTipOrderListCarPicture.SetToolTip(pictureBoxMakeServiceReport_CarPicture, "Фотография выбранного автомобиля.");

            toolTipUsersManagement_FindInTheTable.SetToolTip(textBoxUsersManagement_FindInTheTable, 
                                                             "Введите что-нибудь в это поле, чтобы запустить поиск по таблице. " +      
                                                             "Если в каком-то поле будет совпадение, то вся строка останется в таблице. " +                                                    
                                                             "Иначе она будет скрыта.");

            toolTipMakeServiceReport_PricePerHour.SetToolTip(textBoxMakeMakeServiceReport_NewCarPricePerHour, 
                                                             "Введите цену автомобиля в час. " +
                                                             "Сумма округляется автоматически до двух знаков после запятой.");

            toolTipMakeServiceReport_ProductionYear.SetToolTip(textBoxMakeMakeServiceReport_NewCarProductionYear, "Введите год производства автомобиля.");

            toolTipSettings_Password.SetToolTip(textBoxSettings_OldPassword, "Введите пароль, состоящий из любых символов.\nПароль должен быть достаточно сильным.");
            toolTipSettings_Password.SetToolTip(textBoxSettings_NewPassword, "Введите пароль, состоящий из любых символов.\nПароль должен быть достаточно сильным.");
            toolTipSettings_Password.SetToolTip(textBoxSettings_NewPasswordConfirmation, "Введите пароль, состоящий из любых символов.\nПароль должен быть достаточно сильным.");

            toolTipMakeServiceReport_HideOrShowCar.SetToolTip(buttonMakeServiceReport_HideShowCar, "Если скрыть автомобиль, то клиенты не будут иметь возможности его заказать. " + 
                                                                                             "Они не будут видеть этот автомобиль в списке для возможного заказа.");

            tabControlAdmin.SelectedIndexChanged += TabControlAdmin_SelectedIndexChanged;

            listViewServiceReportList.ColumnWidthChanging += ListViewServiceReportList_ColumnWidthChanging;
            listViewUsersManagement.ColumnWidthChanging += ListViewUsersManagement_ColumnWidthChanging;
            listViewMakeServiceReport.ColumnWidthChanging += ListViewMakeServiceReport_ColumnWidthChanging;

            listViewUsersManagement.ItemSelectionChanged += ListViewUsersManagement_ItemSelectionChanged;
            listViewServiceReportList.ItemSelectionChanged += listViewServiceReportList_ItemSelectionChanged;
            listViewMakeServiceReport.ItemSelectionChanged += ListViewMakeServiceReport_ItemSelectionChanged;

            this.FormClosing += AdminForm_FormClosing;

            dateTimePickerFinancialReport_FromDate.Value = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
            dateTimePickerFinancialReport_ToDate.Value = DateTime.Today.AddDays(-DateTime.Today.Day + 1 + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).AddSeconds(-1);

            textBoxUsersManagement_FindInTheTable.GotFocus += TextBoxUsersManagement_FindInTheTable_GotFocus;

            comboBoxMakeServiceReport_AddOrEditCarMode.SelectedIndex = 0;

            labelUsername.Text = SaveLoadControl.CurrentUser.UserName;

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
            if (tabControlAdmin.SelectedIndex == 2) //Вкладка "Управление пользователями"
            {
                RefreshUsersManagementList();
            } 
            else
            if (tabControlAdmin.SelectedIndex == 3) //Вкладка "Финансовый отчёт"
            {
                RefreshFinancialReport();
            }
            else
            if (tabControlAdmin.SelectedIndex == 4) //Вкладка "Настройки"
            {
                RefreshSettings();
            }
        }

        #region Financial Report

        public void RefreshFinancialReport()
        {
            buttonFinancialReport_GetReports_Click(null, null);
        }

        private void buttonFinancialReport_GetReports_Click(object sender, EventArgs e)
        {
            labelFinancialReport_PotentionalSalary.Text = ((Admin)SaveLoadControl.CurrentUser).GetPotentionalFinancialReport(dateTimePickerFinancialReport_FromDate.Value, dateTimePickerFinancialReport_ToDate.Value).ToString("N2").Replace(",", ".");
            labelFinancialReport_AvailableSalary.Text = ((Admin)SaveLoadControl.CurrentUser).GetFinancialReport(dateTimePickerFinancialReport_FromDate.Value, dateTimePickerFinancialReport_ToDate.Value).ToString("N2").Replace(",", ".");
        }

        private void labelFinancialReport_PotentionalSalary_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(labelFinancialReport_PotentionalSalary.Text);
                MessageBox.Show("Вы успешно скопировали сумму потенциального дохода!", "Скопировано!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }

        private void labelFinancialReport_AvailableSalary_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(labelFinancialReport_AvailableSalary.Text);
                MessageBox.Show("Вы успешно скопировали сумму доступного дохода!", "Скопировано!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }

        #endregion

        #region Settings

        public void RefreshSettings()
        {
            labelSettings_WholeCarsServicedByThisAdmin.Text = ((Admin)SaveLoadControl.CurrentUser).TotalCarsServiced.ToString();
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

        #region Users Management

        public void RefreshUsersManagementList()
        {
            listViewUsersManagement.Items.Clear();

            var users = SaveLoadControl.Users.OrderByDescending(x => x.Id);
            foreach (var user in users)
            {
                string[] arr = new string[9];
                arr[0] = string.Empty;
                arr[1] = user.Id.ToString();
                arr[2] = user.UserName;
                arr[3] = user.FullName;
                arr[4] = user.Email;
                arr[5] = user.Phone;
                arr[6] = user.Role == RolesContainer.Client ? "Клиент" : (user.Role == RolesContainer.Employee ? "Сотрудник" : "Администратор");
                arr[7] = user.IsAccountSetupCompleted ? "Да" : "Нет";
                arr[8] = user.AccountDeactivated ? "Да" : "Нет";

                if (textBoxUsersManagement_FindInTheTable.TextLength != 0)
                {
                    bool flag = false;
                    foreach (var str in arr)
                    {
                        if (str.ToLower().Contains(textBoxUsersManagement_FindInTheTable.Text.ToLower())) flag = true;
                    }
                    if (!flag) continue;
                }

                ListViewItem item = new ListViewItem(arr);
                item.Tag = user.Id;
                item.UseItemStyleForSubItems = false;
                listViewUsersManagement.Items.Add(item);
            }

            listViewUsersManagement.Refresh();
        }

        private void TextBoxUsersManagement_FindInTheTable_GotFocus(object sender, EventArgs e)
        {
            listViewUsersManagement.SelectedItems.Clear();
        }

        private void textBoxUsersManagement_FindInTheTable_TextChanged(object sender, EventArgs e)
        {
            RefreshUsersManagementList();
        }

        private void ListViewUsersManagement_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewServiceReportList.Columns[e.ColumnIndex].Width;
        }

        private void ListViewUsersManagement_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewUsersManagement.SelectedItems.Count != 0)
            {
                if (listViewUsersManagement.SelectedItems[0].Tag is null) return;
                var userId = (int)listViewUsersManagement.SelectedItems[0].Tag;
                var user = SaveLoadControl.Users.FirstOrDefault(x => x.Id == userId);
                if (user is null) return;

                if (user.Role == RolesContainer.Admin)
                {
                    SetUsersManagementDefaults();
                    return;
                }

                if ((user.Role == RolesContainer.Client && !((Client)user).AccountDeactivated) ||
                    (user.Role == RolesContainer.Employee && ((Employee)user).IsWorkingNow))
                {
                    buttonUsersManagement_DeactivateThisAccount.Enabled = true;
                    buttonUsersManagement_ActivateThisAccount.Enabled = false;
                }
                else
                {
                    buttonUsersManagement_DeactivateThisAccount.Enabled = false;
                    buttonUsersManagement_ActivateThisAccount.Enabled = true;
                }

                if (user.Role == RolesContainer.Client)
                {
                    buttonUsersManagement_SetRoleClient.Enabled = false;
                    buttonUsersManagement_DeactivateThisAccount.Text = "Деактивировать аккаунт";
                    buttonUsersManagement_ActivateThisAccount.Text = "Активировать аккаунт";
                }
                else
                {
                    buttonUsersManagement_SetRoleClient.Enabled = true;
                    buttonUsersManagement_DeactivateThisAccount.Text = "Уволить сотрудника";
                    buttonUsersManagement_ActivateThisAccount.Text = "Вернуть сотрудника";
                }

                if (user.Role == RolesContainer.Employee)
                    buttonUsersManagement_SetRoleEmployee.Enabled = false;
                else
                    buttonUsersManagement_SetRoleEmployee.Enabled = true;                    
            } 
            else
            {
                SetUsersManagementDefaults();
            }
        }

        public void SetUsersManagementDefaults()
        {
            buttonUsersManagement_DeactivateThisAccount.Text = "Деактивировать аккаунт";
            buttonUsersManagement_DeactivateThisAccount.Enabled = false;
            buttonUsersManagement_SetRoleClient.Enabled = false;
            buttonUsersManagement_SetRoleEmployee.Enabled = false;
        }

        private void buttonUsersManagement_SetRoleClient_Click(object sender, EventArgs e)
        {
            if (listViewUsersManagement.SelectedItems[0].Tag is null) return;
            var userId = (int)listViewUsersManagement.SelectedItems[0].Tag;
            var user = SaveLoadControl.Users.FirstOrDefault(x => x.Id == userId);
            if (user is null) return;

            var result = MessageBox.Show($"Вы уверены, что хотите сделать пользователя {user.UserName} снова клиентом?", "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            if (((Employee)user).DaysWorked > 0)
            {
                MessageBox.Show("Невозможно изменить роль на клиента! Аккаунт поучаствовал в работе как сотрудник!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newUser = new Client((Employee)user);
            SaveLoadControl.Users[userId] = newUser;

            RefreshUsersManagementList();
        }

        private void buttonUsersManagement_SetRoleEmployee_Click(object sender, EventArgs e)
        {
            if (listViewUsersManagement.SelectedItems[0].Tag is null) return;
            var userId = (int)listViewUsersManagement.SelectedItems[0].Tag;
            var user = SaveLoadControl.Users.FirstOrDefault(x => x.Id == userId);
            if (user is null) return;

            var result = MessageBox.Show($"Вы уверены, что хотите сделать пользователя {user.UserName} сотрудником?", "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            if (!(SaveLoadControl.Payments.FirstOrDefault(x => x.User.Id == userId) is null))
            {
                MessageBox.Show("Невозможно сделать пользователя сотрудником! Аккаунт поучаствовал в деятельности сервиса как клиент!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newUser = new Employee((Client)user);
            SaveLoadControl.Users[userId] = newUser;

            RefreshUsersManagementList();
        }

        private void buttonUsersManagement_DeactivateThisAccount_Click(object sender, EventArgs e)
        {
            if (listViewUsersManagement.SelectedItems[0].Tag is null) return;
            var userId = (int)listViewUsersManagement.SelectedItems[0].Tag;
            var user = SaveLoadControl.Users.FirstOrDefault(x => x.Id == userId);
            if (user is null) return;

            if (user.Role == RolesContainer.Employee)
            {
                if (!((Employee)user).IsWorkingNow)
                {
                    MessageBox.Show("Сотрудник уже уволен. Нельзя его уволить ещё раз.", "Сотрудник уволен!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ((Employee)user).FireEmployee();
                user.DeactivateAccount();
                MessageBox.Show($"Работник {user.FullName} был уволен.", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (((Client)user).AccountDeactivated)
                {
                    MessageBox.Show("Аккаунт уже деактивирован. Нельзя его деактивировать ещё раз.", "Аккаунт деактивирован!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ((Client)user).DeactivateAccount();
                MessageBox.Show($"Аккаунт {user.UserName} был деактивирован.", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            RefreshUsersManagementList();
        }

        private void buttonUsersManagement_ActivateThisAccount_Click(object sender, EventArgs e)
        {
            if (listViewUsersManagement.SelectedItems[0].Tag is null) return;
            var userId = (int)listViewUsersManagement.SelectedItems[0].Tag;
            var user = SaveLoadControl.Users.FirstOrDefault(x => x.Id == userId);
            if (user is null) return;

            if (user.Role == RolesContainer.Employee)
            {
                if (((Employee)user).IsWorkingNow)
                {
                    MessageBox.Show("Сотрудник НЕ был уволен. Нельзя его вернуть в этом случае.", "Сотрудник НЕ уволен!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ((Employee)user).HireEmployee();
                MessageBox.Show($"Работника {user.FullName} вернули.", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!((Client)user).AccountDeactivated)
                {
                    MessageBox.Show("Аккаунт и так активирован. Нельзя его активировать ещё раз.", "Аккаунт уже активирован!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ((Client)user).ActivateAccount();
                MessageBox.Show($"Аккаунт {user.UserName} был активирован.", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            RefreshUsersManagementList();
        }

        private void toolStripMenuItemListViewUsersManagement_Copy_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewUsersManagement.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[1].Text + "\t" +
                              item.SubItems[2].Text + "\t" +
                              item.SubItems[3].Text + "\t" +
                              item.SubItems[4].Text + "\t" +
                              item.SubItems[5].Text + "\t" +
                              item.SubItems[6].Text + "\t" +
                              item.SubItems[7].Text + "\t" +
                              item.SubItems[8].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }

                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewUsersManagement_Copy_ID_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewUsersManagement.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[1].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewUsersManagement_Copy_Username_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewUsersManagement.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[2].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewUsersManagement_FullName_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewUsersManagement.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[3].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewUsersManagement_Copy_Email_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewUsersManagement.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[4].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewUsersManagement_Copy_PhoneNumber_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewUsersManagement.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[5].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewUsersManagement_Copy_Role_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewUsersManagement.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[6].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewUsersManagement_Copy_AccountSetupCompleted_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewUsersManagement.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[7].Text;
                    if (selectedItems.Count > 1) result += Environment.NewLine;
                }
                Clipboard.SetText(result);
            }
            catch { }
        }

        private void toolStripMenuItemListViewUsersManagement_Copy_Deactivated_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                var selectedItems = listViewUsersManagement.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    result += item.SubItems[8].Text;
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
            buttonMakeServiceReport_AddNewCar.Enabled = true;
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

                if (comboBoxMakeServiceReport_AddOrEditCarMode.Text.Contains("Изменить"))
                {
                    pictureBoxMakeServiceReport_AddNewCarPicture.Image = new Bitmap(CarsOrderImages[car.Id], pictureBoxMakeServiceReport_CarPicture.Size);
                    AddNewCarImagePath = $"images\\car_{car.Id}.png";
                    textBoxMakeMakeServiceReport_NewCarBrand.Text = SaveLoadControl.Cars[carId].Brand;
                    textBoxMakeMakeServiceReport_NewCarModel.Text = SaveLoadControl.Cars[carId].Model;
                    textBoxMakeMakeServiceReport_NewCarLicensePlate.Text = SaveLoadControl.Cars[carId].CarLicensePlate;
                    textBoxMakeMakeServiceReport_NewCarPricePerHour.Text = SaveLoadControl.Cars[carId].PricePerHour.ToString().Replace(",", ".");
                    textBoxMakeMakeServiceReport_NewCarProductionYear.Text = SaveLoadControl.Cars[carId].ProductionYear.ToString("yyyy");
                }

                pictureBoxMakeServiceReport_CarPicture.Image = new Bitmap(CarsOrderImages[car.Id], pictureBoxMakeServiceReport_CarPicture.Size);
            }
            else
            {
                ListViewMakeServiceReport_ItemSelectionChanged_SetDefault();
                if (comboBoxMakeServiceReport_AddOrEditCarMode.Text.Contains("Изменить")) buttonMakeServiceReport_AddNewCar.Enabled = false;
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
                image = UtilsControl.LoadImageFromFileSafely(openFileDialog.FileName);
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
                MessageBox.Show("Вы ввели что-то не то! Попробуйте ещё раз!", "Ошибка при добавлении или изменении авто!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pictureBoxMakeServiceReport_AddNewCarPicture.Image is null)
            {
                MessageBox.Show("Вы не добавили фотографию для автомобиля!", "Ошибка при добавлении или изменении авто!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите добавить или изменить этот автомобиль в системе? Пожалуйста, перепроверьте данные.", "Подтверждение добавления или изменения автомобиля.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            if (!File.Exists(AddNewCarImagePath))
            {
                MessageBox.Show("Выбранного Вами файла фотографии для автомобиля больше не существует! Попробуйте ещё раз!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Car newCar = new Car(SaveLoadControl.Cars.Count, 
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
                Image image = new Bitmap(UtilsControl.LoadImageFromFileSafely(AddNewCarImagePath), pictureBoxMakeServiceReport_AddNewCarPicture.Size);
                if (comboBoxMakeServiceReport_AddOrEditCarMode.Text.Contains("Добавить"))
                {
                    string path = $"images\\car_{newCar.Id}.png";
                    image.Save(path);
                    CarsOrderImages.Add(UtilsControl.LoadImageFromFileSafely(path));
                }
                else
                {
                    if (listViewMakeServiceReport.SelectedItems[0].Tag is null) return;
                    var carId = (int)listViewMakeServiceReport.SelectedItems[0].Tag;
                    var car = SaveLoadControl.Cars.FirstOrDefault(x => x.Id == carId);
                    if (car is null) return;

                    string path = $"images\\car_{car.Id}.png";
                    if (File.Exists(path)) File.Delete(path);
                    image.Save(path);

                    CarsOrderImages[carId] = UtilsControl.LoadImageFromFileSafely(path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить заданную Вами фотографию!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxMakeServiceReport_AddOrEditCarMode.Text.Contains("Добавить"))
            {
                SaveLoadControl.Cars.Add(newCar);
            }
            else
            {
                if (listViewMakeServiceReport.SelectedItems[0].Tag is null) return;
                var carId = (int)listViewMakeServiceReport.SelectedItems[0].Tag;
                var car = SaveLoadControl.Cars.FirstOrDefault(x => x.Id == carId);
                if (car is null) return;

                SaveLoadControl.Cars[carId].Brand = textBoxMakeMakeServiceReport_NewCarBrand.Text;
                SaveLoadControl.Cars[carId].Model = textBoxMakeMakeServiceReport_NewCarModel.Text;
                SaveLoadControl.Cars[carId].CarLicensePlate = textBoxMakeMakeServiceReport_NewCarLicensePlate.Text;
                SaveLoadControl.Cars[carId].PricePerHour = double.Parse(textBoxMakeMakeServiceReport_NewCarPricePerHour.Text.Replace(".", ","));
                SaveLoadControl.Cars[carId].ProductionYear = new DateTime(int.Parse(textBoxMakeMakeServiceReport_NewCarProductionYear.Text), 1, 1);

                listViewMakeServiceReport.SelectedItems.Clear();
                ListViewMakeServiceReport_ItemSelectionChanged(null, null);
            }

            MakeServiceReport_AddNewCar_SetDefault();

            RefreshMakeServiceReport();

            MessageBox.Show("Автомобиль был успешно добавлен или изменён в системе!", "Успешное добавление или изменение автомобиля!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBoxMakeServiceReport_AddOrEditCarMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewMakeServiceReport.SelectedItems.Clear();
            ListViewMakeServiceReport_ItemSelectionChanged(null, null);
            if (comboBoxMakeServiceReport_AddOrEditCarMode.Text.Contains("Добавить"))
            {
                MakeServiceReport_AddNewCar_SetDefault();
                buttonMakeServiceReport_AddNewCar.Text = "Добавить авто";
            }
            else
            {
                buttonMakeServiceReport_AddNewCar.Text = "Изменить авто";
            }
        }

        private void buttonMakeServiceReport_HideShowCar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Вы уверены, что хотите {buttonMakeServiceReport_HideShowCar.Text.ToLower().Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]} автомобиль?", buttonMakeServiceReport_HideShowCar.Text + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

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
                arr[2] = report.Worker is null ? "Пока никто не взялся" : report.Worker.FullName.ToString();
                arr[3] = report.Worker is null ? "Пока никто не взялся" : Employee.SalaryPerDay.ToString("N2").Replace(",", ".");
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
