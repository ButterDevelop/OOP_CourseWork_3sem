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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace OOP_CourseWork
{
    public partial class EmployeeForm : Form
    {
        public static readonly Color AllowedColor = Color.AliceBlue;
        public static readonly Color DeniedColor = Color.FromArgb(255, 200, 220);
        public Size ImageSize = new Size(252, 168);
        public static List<Image> CarsOrderImages = new List<Image>();
        public static string AddNewCarImagePath = "";

        public EmployeeForm()
        {
            InitializeComponent();

            toolTipOrderListCarPicture.SetToolTip(pictureBoxServiceReportList_CarPicture, "Фотография выбранного автомобиля.");
            toolTipSettings_Password.SetToolTip(textBoxSettings_OldPassword, "Введите пароль, состоящий из любых символов.\nПароль должен быть достаточно сильным.");
            toolTipSettings_Password.SetToolTip(textBoxSettings_NewPassword, "Введите пароль, состоящий из любых символов.\nПароль должен быть достаточно сильным.");
            toolTipSettings_Password.SetToolTip(textBoxSettings_NewPasswordConfirmation, "Введите пароль, состоящий из любых символов.\nПароль должен быть достаточно сильным.");

            tabControlEmployee.SelectedIndexChanged += TabControlEmployee_SelectedIndexChanged;

            listViewServiceReportList.ColumnWidthChanging += ListViewServiceReportList_ColumnWidthChanging;

            listViewServiceReportList.ItemSelectionChanged += listViewServiceReportList_ItemSelectionChanged;

            this.FormClosing += EmployeeForm_FormClosing;

            labelUsername.Text = SaveLoadControl.CurrentUser.UserName;

            CarsOrderImages = UtilsControl.LoadCarsOrderImages();
        }

        private void EmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            RefreshServiceReportList();
            
            if (!SaveLoadControl.CurrentUser.IsAccountSetupCompleted) tabControlEmployee.SelectTab(1); //Переходим на вкладку "Настройки"
            tabControlEmployee.Deselecting += TabControlEmployee_Deselecting;
        }

        private void TabControlEmployee_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (!SaveLoadControl.CurrentUser.IsAccountSetupCompleted) //Если аккаунт не подтверждён
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
            labelSettings_TotalSalaryPayed.Text = ((Employee)SaveLoadControl.CurrentUser).TotalSalaryPayed.ToString("N2").Replace(",", ".");
            textBoxSettings_CardNumber.Text = ((Employee)SaveLoadControl.CurrentUser).BankAccountNumber;
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

        private void buttonSettings_Save_Click(object sender, EventArgs e)
        {
            textBoxSettings_CardNumber_TextChanged(null, null);

            if (textBoxSettings_CardNumber.BackColor == DeniedColor)
            {
                MessageBox.Show("Проверьте введённые данные на корректность.", "Ошибка смены настроек!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ((Employee)SaveLoadControl.CurrentUser).BankAccountNumber = textBoxSettings_CardNumber.Text;
            SaveLoadControl.CurrentUser.CompleteAccountSetup();

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

        #region Service Report list

        public void RefreshServiceReportList()
        {
            listViewServiceReportList.Items.Clear();

            var reports = SaveLoadControl.ServiceReports.Where(x => x.Worker is null || x.Worker.Id == SaveLoadControl.CurrentUser.Id).OrderByDescending(x => x.StartedDate).ToArray();

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

                if (!(report.Worker is null) && !report.IsFinished)
                {
                    buttonMakeServiceReport_EditOrder.Enabled = true;
                    buttonMakeServiceReport_EndOrder.Enabled = true;
                }
                else
                {
                    buttonMakeServiceReport_EditOrder.Enabled = false;
                    buttonMakeServiceReport_EndOrder.Enabled = false;
                }

                if (report.Worker is null)
                {
                    buttonMakeServiceReport_TakeOrder.Enabled = true;
                }
                else
                {
                    buttonMakeServiceReport_TakeOrder.Enabled = false;
                }

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
            var report = SaveLoadControl.ServiceReports.FirstOrDefault(x => x.Id == reportId);
            if (report is null) return;

            report.Worker = (Employee)SaveLoadControl.CurrentUser;

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
            var report = SaveLoadControl.ServiceReports.FirstOrDefault(x => x.Id == reportId);
            if (report is null) return;

            report.EmployeeReport = textBoxServiceReportList_EmployeeReportString.Text;
            report.FinishService();

            MessageBox.Show("Вы успешно сдали заказ!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshServiceReportList();
        }

        private void buttonMakeServiceReport_EditOrder_Click(object sender, EventArgs e)
        {
            if (listViewServiceReportList.SelectedItems[0].Tag is null) return;
            var reportId = (int)listViewServiceReportList.SelectedItems[0].Tag;
            var report = SaveLoadControl.ServiceReports.FirstOrDefault(x => x.Id == reportId);
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
