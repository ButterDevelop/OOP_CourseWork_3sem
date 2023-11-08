using Microsoft.VisualBasic;
using DB_CourseWork.Controls;
using DB_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DB_CourseWork
{
    partial class EmployeeForm : Form
    {
        public static readonly Color AllowedColor = Color.AliceBlue;
        public static readonly Color DeniedColor = Color.FromArgb(255, 200, 220);
        public static Dictionary<int, Image> CarsOrderImages = new Dictionary<int, Image>();
        public static string AddNewCarImagePath = "";

        private DatabaseContext _dbContext;

        public EmployeeForm(DatabaseContext dbContext)
        {
            InitializeComponent();

            _dbContext = dbContext;

            toolTipOrderListCarPicture.SetToolTip(pictureBoxServiceReportList_CarPicture, "Фотография выбранного автомобиля.");
            toolTipSettings_Password.SetToolTip(textBoxSettings_OldPassword, "Введите пароль, состоящий из любых символов.\nПароль должен быть достаточно сильным.");
            toolTipSettings_Password.SetToolTip(textBoxSettings_NewPassword, "Введите пароль, состоящий из любых символов.\nПароль должен быть достаточно сильным.");
            toolTipSettings_Password.SetToolTip(textBoxSettings_NewPasswordConfirmation, "Введите пароль, состоящий из любых символов.\nПароль должен быть достаточно сильным.");

            tabControlEmployee.SelectedIndexChanged += TabControlEmployee_SelectedIndexChanged;

            listViewServiceReportList.ColumnWidthChanging += ListViewServiceReportList_ColumnWidthChanging;

            listViewServiceReportList.ItemSelectionChanged += listViewServiceReportList_ItemSelectionChanged;

            this.FormClosing += EmployeeForm_FormClosing;

            labelUsername.Text = _dbContext.CurrentUser.UserName;

            CarsOrderImages = UtilsControl.LoadCarsOrderImages();
        }

        private void EmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти из программы?", "Точно выйти?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            } 
            else
            {
                e.Cancel = true;
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            RefreshServiceReportList();
            
            if (!_dbContext.CurrentUser.IsAccountSetupCompleted) tabControlEmployee.SelectTab(1); //Переходим на вкладку "Настройки"
            tabControlEmployee.Deselecting += TabControlEmployee_Deselecting;
        }

        private void TabControlEmployee_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_dbContext.CurrentUser.IsAccountSetupCompleted) //Если аккаунт не подтверждён
            {
                e.Cancel = true; //Отмена перехода по вкладке
                MessageBox.Show("Чтобы пользоваться сервисом, Вам нужно сначала подтвердить свой аккаунт. Сделать это можно в настройках.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TabControlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewServiceReportList_ItemSelectionChanged_SetDefault();
            if (tabControlEmployee.SelectedIndex == 0) //Вкладка "Список заказов"
            {
                RefreshServiceReportList();
            }
            else
            if (tabControlEmployee.SelectedIndex == 1) //Вкладка "Настройки"
            {
                RefreshSettings();
            }
        }

        #region Settings

        public void RefreshSettings()
        {
            labelSettings_TotalSalaryPayed.Text = ((Employee)_dbContext.CurrentUser).TotalSalaryPayed.ToString("N2").Replace(",", ".");
            textBoxSettings_CardNumber.Text = ((Employee)_dbContext.CurrentUser).BankAccountNumber;
        }

        private void textBoxSettings_CardNumber_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSettings_CardNumber.TextLength != 0)
            {
                textBoxSettings_CardNumber.BackColor = AllowedColor;
            }
            else
            {
                textBoxSettings_CardNumber.BackColor = DeniedColor;
            }
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

        private void buttonSettings_Save_Click(object sender, EventArgs e)
        {
            textBoxSettings_Password_TextChanged(null, null);
            textBoxSettings_CardNumber_TextChanged(null, null);

            if (textBoxSettings_CardNumber.BackColor == DeniedColor ||
                textBoxSettings_Password.BackColor == DeniedColor)
            {
                MessageBox.Show("Проверьте введённые данные на корректность.", "Ошибка смены настроек!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_dbContext.CurrentUser.IsPasswordCorrect(textBoxSettings_Password.Text))
            {
                MessageBox.Show("Вы ввели неверный пароль! Нельзя изменить настройки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ((Employee)_dbContext.CurrentUser).BankAccountNumber = textBoxSettings_CardNumber.Text;
            _dbContext.CurrentUser.CompleteAccountSetup();
            _dbContext.Employees.Update((Employee)_dbContext.CurrentUser);

            MessageBox.Show("Настройки были успешно изменёны!", "Смена настроек!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                _dbContext.Employees.Update((Employee)_dbContext.CurrentUser);
                MessageBox.Show("Пароль был успешно изменён!", "Смена пароля!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                MessageBox.Show("Не удалось изменить пароль!", "Смена пароля!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Service Report list

        public void RefreshServiceReportList()
        {
            listViewServiceReportList.Items.Clear();

            var reports = _dbContext.ServiceReports.GetAll().Where(x => x.WorkerId == -1 || x.WorkerId == _dbContext.CurrentUser.Id).OrderByDescending(x => x.StartedDate).ToArray();

            int counter = reports.Length;
            foreach (var report in reports)
            {
                var reportWorker = report.WorkerId == -1 ? null : _dbContext.Employees.Get(report.WorkerId);

                string[] arr = new string[11];
                arr[0] = ""; 
                arr[1] = report.Id.ToString();
                arr[2] = report.WorkerId == -1 ? "Пока никто не взялся" : reportWorker.FullName.ToString();
                arr[3] = report.WorkerId == -1 ? "Пока никто не взялся" : Employee.SalaryPerDay.ToString("N2").Replace(",", ".");
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
                var report = _dbContext.ServiceReports.GetAll().FirstOrDefault(x => x.Id == reportId);
                if (report is null) return;

                textBoxServiceReportList_Description.Text = report.Description;
                textBoxServiceReportList_EmployeeReportString.Text = report.EmployeeReport;

                if (!(report.WorkerId == -1) && !report.IsFinished)
                {
                    buttonMakeServiceReport_EditOrder.Enabled = true;
                    buttonMakeServiceReport_EndOrder.Enabled = true;
                }
                else
                {
                    buttonMakeServiceReport_EditOrder.Enabled = false;
                    buttonMakeServiceReport_EndOrder.Enabled = false;
                }

                if (report.WorkerId == -1)
                {
                    buttonMakeServiceReport_TakeOrder.Enabled = true;
                }
                else
                {
                    buttonMakeServiceReport_TakeOrder.Enabled = false;
                }

                var servicedCar = _dbContext.Cars.Get(report.ServicedCarId);
                pictureBoxServiceReportList_CarPicture.Image  = new Bitmap(CarsOrderImages[report.ServicedCarId], pictureBoxServiceReportList_CarPicture.Size);
                textBoxServiceReportList_CarBrand.Text        = servicedCar.Brand;
                textBoxServiceReportList_CarModel.Text        = servicedCar.Model;
                textBoxServiceReportList_ProductionYear.Text  = servicedCar.ProductionYear.ToString("yyyy");
                textBoxServiceReportList_PricePerHour.Text    = servicedCar.PricePerHour.ToString("N2").Replace(",", ".");
                textBoxServiceReportList_CarLicensePlate.Text = servicedCar.CarLicensePlate;
                textBoxServiceReportList_LastServiceDate.Text = servicedCar.LastServiceTime == DateTime.MinValue ? "Не выставлено" : servicedCar.LastServiceTime.ToString("d");
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

            buttonMakeServiceReport_EditOrder.Enabled = false;
            buttonMakeServiceReport_EndOrder.Enabled = false;
            buttonMakeServiceReport_TakeOrder.Enabled = false;
        }

        private void buttonMakeServiceReport_TakeOrder_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите взять этот заказ?", "Уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            if (listViewServiceReportList.SelectedItems[0].Tag is null) return;
            var reportId = (int)listViewServiceReportList.SelectedItems[0].Tag;
            var report = _dbContext.ServiceReports.GetAll().FirstOrDefault(x => x.Id == reportId);
            if (report is null) return;

            report.WorkerId = _dbContext.CurrentUser.Id;
            _dbContext.ServiceReports.Update(report);

            MessageBox.Show("Вы успешно взяли заказ на обслуживание!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshServiceReportList();
        }

        private void buttonMakeServiceReport_EndOrder_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите завершить этот заказ?", "Уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            if (textBoxServiceReportList_EmployeeReportString.TextLength == 0)
            {
                MessageBox.Show("Вы не написали ничего в отчёте о выполненной работе!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listViewServiceReportList.SelectedItems[0].Tag is null) return;
            var reportId = (int)listViewServiceReportList.SelectedItems[0].Tag;
            var report = _dbContext.ServiceReports.GetAll().FirstOrDefault(x => x.Id == reportId);
            if (report is null) return;

            report.EmployeeReport = textBoxServiceReportList_EmployeeReportString.Text;
            report.FinishService();
            _dbContext.ServiceReports.Update(report);

            MessageBox.Show("Вы успешно сдали заказ!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshServiceReportList();
        }

        private void buttonMakeServiceReport_EditOrder_Click(object sender, EventArgs e)
        {
            if (listViewServiceReportList.SelectedItems[0].Tag is null) return;
            var reportId = (int)listViewServiceReportList.SelectedItems[0].Tag;
            var report = _dbContext.ServiceReports.GetAll().FirstOrDefault(x => x.Id == reportId);
            if (report is null) return;

            string str_planned_days = Interaction.InputBox("Хотите изменить количество дней для выполнения заказа? " +
                                                           "По умолчанию выставлено текущее значение.",
                                                           "Изменение информации о выбраннном заказе", report.PlannedCompletionDays.ToString());
            if (str_planned_days != "")
            {
                int planned_days = 0;
                if (!int.TryParse(str_planned_days, out planned_days) || planned_days <= 0 || planned_days > 365)
                {
                    MessageBox.Show("Вы ввели что-то не то! Попробуйте ещё раз!", "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                report.PlannedCompletionDays = planned_days;
            }

            RefreshServiceReportList();

            string str_additional_cost = Interaction.InputBox("Хотите изменить доп. цену для заказа? " +
                                                              "По умолчанию выставлено текущее значение.",
                                                              "Изменение информации о выбраннном заказе", report.AdditionalCost.ToString("N2").Replace(",", "."));
            if (str_additional_cost != "")
            {
                double additional_cost = 0;
                if (!double.TryParse(str_additional_cost.Replace(".", ","), out additional_cost) || additional_cost <= 0 || additional_cost > 1000000)
                {
                    MessageBox.Show("Вы ввели что-то не то! Попробуйте ещё раз!", "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                report.AdditionalCost = additional_cost;
            }

            _dbContext.ServiceReports.Update(report);

            RefreshServiceReportList();

            MessageBox.Show("Параметры для заказа были успешно изменены!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
