using System;

namespace OOP_CourseWork
{
    partial class EmployeeForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            this.tabControlEmployee = new System.Windows.Forms.TabControl();
            this.tabPageServiceReportList = new System.Windows.Forms.TabPage();
            this.buttonMakeServiceReport_EditOrder = new System.Windows.Forms.Button();
            this.buttonMakeServiceReport_EndOrder = new System.Windows.Forms.Button();
            this.buttonMakeServiceReport_TakeOrder = new System.Windows.Forms.Button();
            this.textBoxServiceReportList_EmployeeReportString = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxServiceReportList_Description = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxServiceReportList_LastServiceDate = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxServiceReportList_CarLicensePlate = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxServiceReportList_PricePerHour = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxServiceReportList_ProductionYear = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxServiceReportList_CarModel = new System.Windows.Forms.TextBox();
            this.labelServiceReportList_CarOrderInfo = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxServiceReportList_CarBrand = new System.Windows.Forms.TextBox();
            this.pictureBoxServiceReportList_CarPicture = new System.Windows.Forms.PictureBox();
            this.listViewServiceReportList = new System.Windows.Forms.ListView();
            this.columnHeaderServiceReportList_SpaceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_EmployeeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_CostPerDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_StartedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_PlannedCompletionDays = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_FinishedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_AdditionalCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_FullCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_IsStarted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_IsFinished = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripListViewServiceReportList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemListViewOrderList_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_ID = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_FullName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_PricePerDay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_StartedDate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_PlannedDays = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_FinishedDate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_Cost = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_IsStarted = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_IsFinished = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.buttonSettings_Save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSettings_CardNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSettings_NewPasswordConfirmation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSettings_NewPassword = new System.Windows.Forms.TextBox();
            this.buttonSettings_ChangePassword = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSettings_OldPassword = new System.Windows.Forms.TextBox();
            this.imageListTabControlEmployee = new System.Windows.Forms.ImageList(this.components);
            this.toolTipOrderListCarPicture = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSettings_Password = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.labelSettings_TotalSalaryPayed = new System.Windows.Forms.Label();
            this.labelUsernameText = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.tabControlEmployee.SuspendLayout();
            this.tabPageServiceReportList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServiceReportList_CarPicture)).BeginInit();
            this.contextMenuStripListViewServiceReportList.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlEmployee
            // 
            this.tabControlEmployee.Controls.Add(this.tabPageServiceReportList);
            this.tabControlEmployee.Controls.Add(this.tabPageSettings);
            this.tabControlEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlEmployee.ImageList = this.imageListTabControlEmployee;
            this.tabControlEmployee.Location = new System.Drawing.Point(0, 0);
            this.tabControlEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControlEmployee.Multiline = true;
            this.tabControlEmployee.Name = "tabControlEmployee";
            this.tabControlEmployee.SelectedIndex = 0;
            this.tabControlEmployee.Size = new System.Drawing.Size(1813, 644);
            this.tabControlEmployee.TabIndex = 0;
            // 
            // tabPageServiceReportList
            // 
            this.tabPageServiceReportList.BackColor = System.Drawing.Color.Transparent;
            this.tabPageServiceReportList.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageServiceReportList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageServiceReportList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageServiceReportList.Controls.Add(this.buttonMakeServiceReport_EditOrder);
            this.tabPageServiceReportList.Controls.Add(this.buttonMakeServiceReport_EndOrder);
            this.tabPageServiceReportList.Controls.Add(this.buttonMakeServiceReport_TakeOrder);
            this.tabPageServiceReportList.Controls.Add(this.textBoxServiceReportList_EmployeeReportString);
            this.tabPageServiceReportList.Controls.Add(this.label24);
            this.tabPageServiceReportList.Controls.Add(this.textBoxServiceReportList_Description);
            this.tabPageServiceReportList.Controls.Add(this.label23);
            this.tabPageServiceReportList.Controls.Add(this.label10);
            this.tabPageServiceReportList.Controls.Add(this.label18);
            this.tabPageServiceReportList.Controls.Add(this.textBoxServiceReportList_LastServiceDate);
            this.tabPageServiceReportList.Controls.Add(this.label17);
            this.tabPageServiceReportList.Controls.Add(this.textBoxServiceReportList_CarLicensePlate);
            this.tabPageServiceReportList.Controls.Add(this.label16);
            this.tabPageServiceReportList.Controls.Add(this.textBoxServiceReportList_PricePerHour);
            this.tabPageServiceReportList.Controls.Add(this.label15);
            this.tabPageServiceReportList.Controls.Add(this.textBoxServiceReportList_ProductionYear);
            this.tabPageServiceReportList.Controls.Add(this.label14);
            this.tabPageServiceReportList.Controls.Add(this.textBoxServiceReportList_CarModel);
            this.tabPageServiceReportList.Controls.Add(this.labelServiceReportList_CarOrderInfo);
            this.tabPageServiceReportList.Controls.Add(this.label13);
            this.tabPageServiceReportList.Controls.Add(this.textBoxServiceReportList_CarBrand);
            this.tabPageServiceReportList.Controls.Add(this.pictureBoxServiceReportList_CarPicture);
            this.tabPageServiceReportList.Controls.Add(this.listViewServiceReportList);
            this.tabPageServiceReportList.ImageKey = "OrderList.png";
            this.tabPageServiceReportList.Location = new System.Drawing.Point(4, 34);
            this.tabPageServiceReportList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageServiceReportList.Name = "tabPageServiceReportList";
            this.tabPageServiceReportList.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageServiceReportList.Size = new System.Drawing.Size(1805, 606);
            this.tabPageServiceReportList.TabIndex = 0;
            this.tabPageServiceReportList.Text = "Сервисные отчёты ";
            this.tabPageServiceReportList.UseVisualStyleBackColor = true;
            // 
            // buttonMakeServiceReport_EditOrder
            // 
            this.buttonMakeServiceReport_EditOrder.Enabled = false;
            this.buttonMakeServiceReport_EditOrder.FlatAppearance.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonMakeServiceReport_EditOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMakeServiceReport_EditOrder.Location = new System.Drawing.Point(387, 194);
            this.buttonMakeServiceReport_EditOrder.Name = "buttonMakeServiceReport_EditOrder";
            this.buttonMakeServiceReport_EditOrder.Size = new System.Drawing.Size(175, 40);
            this.buttonMakeServiceReport_EditOrder.TabIndex = 41;
            this.buttonMakeServiceReport_EditOrder.Text = "Изменить поля";
            this.buttonMakeServiceReport_EditOrder.UseVisualStyleBackColor = true;
            this.buttonMakeServiceReport_EditOrder.Click += new System.EventHandler(this.buttonMakeServiceReport_EditOrder_Click);
            // 
            // buttonMakeServiceReport_EndOrder
            // 
            this.buttonMakeServiceReport_EndOrder.Enabled = false;
            this.buttonMakeServiceReport_EndOrder.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.buttonMakeServiceReport_EndOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMakeServiceReport_EndOrder.Location = new System.Drawing.Point(773, 194);
            this.buttonMakeServiceReport_EndOrder.Name = "buttonMakeServiceReport_EndOrder";
            this.buttonMakeServiceReport_EndOrder.Size = new System.Drawing.Size(175, 40);
            this.buttonMakeServiceReport_EndOrder.TabIndex = 40;
            this.buttonMakeServiceReport_EndOrder.Text = "Сдать заказ";
            this.buttonMakeServiceReport_EndOrder.UseVisualStyleBackColor = true;
            this.buttonMakeServiceReport_EndOrder.Click += new System.EventHandler(this.buttonMakeServiceReport_EndOrder_Click);
            // 
            // buttonMakeServiceReport_TakeOrder
            // 
            this.buttonMakeServiceReport_TakeOrder.Enabled = false;
            this.buttonMakeServiceReport_TakeOrder.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.buttonMakeServiceReport_TakeOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMakeServiceReport_TakeOrder.Location = new System.Drawing.Point(580, 194);
            this.buttonMakeServiceReport_TakeOrder.Name = "buttonMakeServiceReport_TakeOrder";
            this.buttonMakeServiceReport_TakeOrder.Size = new System.Drawing.Size(175, 40);
            this.buttonMakeServiceReport_TakeOrder.TabIndex = 39;
            this.buttonMakeServiceReport_TakeOrder.Text = "Взять заказ";
            this.buttonMakeServiceReport_TakeOrder.UseVisualStyleBackColor = true;
            this.buttonMakeServiceReport_TakeOrder.Click += new System.EventHandler(this.buttonMakeServiceReport_TakeOrder_Click);
            // 
            // textBoxServiceReportList_EmployeeReportString
            // 
            this.textBoxServiceReportList_EmployeeReportString.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxServiceReportList_EmployeeReportString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxServiceReportList_EmployeeReportString.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxServiceReportList_EmployeeReportString.Location = new System.Drawing.Point(1015, 158);
            this.textBoxServiceReportList_EmployeeReportString.Multiline = true;
            this.textBoxServiceReportList_EmployeeReportString.Name = "textBoxServiceReportList_EmployeeReportString";
            this.textBoxServiceReportList_EmployeeReportString.Size = new System.Drawing.Size(771, 76);
            this.textBoxServiceReportList_EmployeeReportString.TabIndex = 7;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(1002, 120);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(795, 25);
            this.label24.TabIndex = 38;
            this.label24.Text = "Ваш отчёт о проделанной работе:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxServiceReportList_Description
            // 
            this.textBoxServiceReportList_Description.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxServiceReportList_Description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxServiceReportList_Description.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxServiceReportList_Description.Location = new System.Drawing.Point(1014, 52);
            this.textBoxServiceReportList_Description.Multiline = true;
            this.textBoxServiceReportList_Description.Name = "textBoxServiceReportList_Description";
            this.textBoxServiceReportList_Description.ReadOnly = true;
            this.textBoxServiceReportList_Description.Size = new System.Drawing.Size(771, 61);
            this.textBoxServiceReportList_Description.TabIndex = 6;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(1001, 14);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(795, 25);
            this.label23.TabIndex = 36;
            this.label23.Text = "Причина отправки авто на обслуживание:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Azure;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(967, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 240);
            this.label10.TabIndex = 34;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(772, 120);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(179, 25);
            this.label18.TabIndex = 20;
            this.label18.Text = "Последний сервис: ";
            // 
            // textBoxServiceReportList_LastServiceDate
            // 
            this.textBoxServiceReportList_LastServiceDate.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxServiceReportList_LastServiceDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxServiceReportList_LastServiceDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxServiceReportList_LastServiceDate.Location = new System.Drawing.Point(773, 148);
            this.textBoxServiceReportList_LastServiceDate.Name = "textBoxServiceReportList_LastServiceDate";
            this.textBoxServiceReportList_LastServiceDate.ReadOnly = true;
            this.textBoxServiceReportList_LastServiceDate.Size = new System.Drawing.Size(175, 31);
            this.textBoxServiceReportList_LastServiceDate.TabIndex = 5;
            this.textBoxServiceReportList_LastServiceDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(591, 119);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(155, 25);
            this.label17.TabIndex = 18;
            this.label17.Text = "Номерной знак: ";
            // 
            // textBoxServiceReportList_CarLicensePlate
            // 
            this.textBoxServiceReportList_CarLicensePlate.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxServiceReportList_CarLicensePlate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxServiceReportList_CarLicensePlate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxServiceReportList_CarLicensePlate.Location = new System.Drawing.Point(580, 148);
            this.textBoxServiceReportList_CarLicensePlate.Name = "textBoxServiceReportList_CarLicensePlate";
            this.textBoxServiceReportList_CarLicensePlate.ReadOnly = true;
            this.textBoxServiceReportList_CarLicensePlate.Size = new System.Drawing.Size(175, 31);
            this.textBoxServiceReportList_CarLicensePlate.TabIndex = 4;
            this.textBoxServiceReportList_CarLicensePlate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(423, 120);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 25);
            this.label16.TabIndex = 16;
            this.label16.Text = "Цена в час: ";
            // 
            // textBoxServiceReportList_PricePerHour
            // 
            this.textBoxServiceReportList_PricePerHour.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxServiceReportList_PricePerHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxServiceReportList_PricePerHour.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxServiceReportList_PricePerHour.Location = new System.Drawing.Point(387, 148);
            this.textBoxServiceReportList_PricePerHour.Name = "textBoxServiceReportList_PricePerHour";
            this.textBoxServiceReportList_PricePerHour.ReadOnly = true;
            this.textBoxServiceReportList_PricePerHour.Size = new System.Drawing.Size(175, 31);
            this.textBoxServiceReportList_PricePerHour.TabIndex = 3;
            this.textBoxServiceReportList_PricePerHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(801, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 25);
            this.label15.TabIndex = 14;
            this.label15.Text = "Год выпуска: ";
            // 
            // textBoxServiceReportList_ProductionYear
            // 
            this.textBoxServiceReportList_ProductionYear.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxServiceReportList_ProductionYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxServiceReportList_ProductionYear.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxServiceReportList_ProductionYear.Location = new System.Drawing.Point(773, 82);
            this.textBoxServiceReportList_ProductionYear.Name = "textBoxServiceReportList_ProductionYear";
            this.textBoxServiceReportList_ProductionYear.ReadOnly = true;
            this.textBoxServiceReportList_ProductionYear.Size = new System.Drawing.Size(175, 31);
            this.textBoxServiceReportList_ProductionYear.TabIndex = 2;
            this.textBoxServiceReportList_ProductionYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(602, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 25);
            this.label14.TabIndex = 12;
            this.label14.Text = "Модель авто: ";
            // 
            // textBoxServiceReportList_CarModel
            // 
            this.textBoxServiceReportList_CarModel.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxServiceReportList_CarModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxServiceReportList_CarModel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxServiceReportList_CarModel.Location = new System.Drawing.Point(580, 82);
            this.textBoxServiceReportList_CarModel.Name = "textBoxServiceReportList_CarModel";
            this.textBoxServiceReportList_CarModel.ReadOnly = true;
            this.textBoxServiceReportList_CarModel.Size = new System.Drawing.Size(175, 31);
            this.textBoxServiceReportList_CarModel.TabIndex = 1;
            this.textBoxServiceReportList_CarModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelServiceReportList_CarOrderInfo
            // 
            this.labelServiceReportList_CarOrderInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServiceReportList_CarOrderInfo.Location = new System.Drawing.Point(373, 14);
            this.labelServiceReportList_CarOrderInfo.Name = "labelServiceReportList_CarOrderInfo";
            this.labelServiceReportList_CarOrderInfo.Size = new System.Drawing.Size(588, 25);
            this.labelServiceReportList_CarOrderInfo.TabIndex = 10;
            this.labelServiceReportList_CarOrderInfo.Text = "Информация об автомобиле в выбранном сервисном отчёте:";
            this.labelServiceReportList_CarOrderInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(416, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 25);
            this.label13.TabIndex = 9;
            this.label13.Text = "Марка авто: ";
            // 
            // textBoxServiceReportList_CarBrand
            // 
            this.textBoxServiceReportList_CarBrand.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxServiceReportList_CarBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxServiceReportList_CarBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxServiceReportList_CarBrand.Location = new System.Drawing.Point(387, 82);
            this.textBoxServiceReportList_CarBrand.Name = "textBoxServiceReportList_CarBrand";
            this.textBoxServiceReportList_CarBrand.ReadOnly = true;
            this.textBoxServiceReportList_CarBrand.Size = new System.Drawing.Size(175, 31);
            this.textBoxServiceReportList_CarBrand.TabIndex = 0;
            this.textBoxServiceReportList_CarBrand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBoxServiceReportList_CarPicture
            // 
            this.pictureBoxServiceReportList_CarPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxServiceReportList_CarPicture.Location = new System.Drawing.Point(7, 7);
            this.pictureBoxServiceReportList_CarPicture.Name = "pictureBoxServiceReportList_CarPicture";
            this.pictureBoxServiceReportList_CarPicture.Size = new System.Drawing.Size(360, 240);
            this.pictureBoxServiceReportList_CarPicture.TabIndex = 7;
            this.pictureBoxServiceReportList_CarPicture.TabStop = false;
            // 
            // listViewServiceReportList
            // 
            this.listViewServiceReportList.BackColor = System.Drawing.Color.AliceBlue;
            this.listViewServiceReportList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewServiceReportList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderServiceReportList_SpaceColumn,
            this.columnHeaderServiceReportList_ID,
            this.columnHeaderServiceReportList_EmployeeName,
            this.columnHeaderServiceReportList_CostPerDay,
            this.columnHeaderServiceReportList_StartedDate,
            this.columnHeaderServiceReportList_PlannedCompletionDays,
            this.columnHeaderServiceReportList_FinishedDate,
            this.columnHeaderServiceReportList_AdditionalCost,
            this.columnHeaderServiceReportList_FullCost,
            this.columnHeaderServiceReportList_IsStarted,
            this.columnHeaderServiceReportList_IsFinished});
            this.listViewServiceReportList.ContextMenuStrip = this.contextMenuStripListViewServiceReportList;
            this.listViewServiceReportList.FullRowSelect = true;
            this.listViewServiceReportList.GridLines = true;
            this.listViewServiceReportList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewServiceReportList.HideSelection = false;
            this.listViewServiceReportList.Location = new System.Drawing.Point(7, 253);
            this.listViewServiceReportList.Name = "listViewServiceReportList";
            this.listViewServiceReportList.Size = new System.Drawing.Size(1789, 344);
            this.listViewServiceReportList.TabIndex = 8;
            this.listViewServiceReportList.UseCompatibleStateImageBehavior = false;
            this.listViewServiceReportList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderServiceReportList_SpaceColumn
            // 
            this.columnHeaderServiceReportList_SpaceColumn.Text = "Space Column";
            this.columnHeaderServiceReportList_SpaceColumn.Width = 0;
            // 
            // columnHeaderServiceReportList_ID
            // 
            this.columnHeaderServiceReportList_ID.Text = "ID";
            this.columnHeaderServiceReportList_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_ID.Width = 100;
            // 
            // columnHeaderServiceReportList_EmployeeName
            // 
            this.columnHeaderServiceReportList_EmployeeName.Text = "Взявшийся сотрудник";
            this.columnHeaderServiceReportList_EmployeeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_EmployeeName.Width = 240;
            // 
            // columnHeaderServiceReportList_CostPerDay
            // 
            this.columnHeaderServiceReportList_CostPerDay.Text = "Цена в день";
            this.columnHeaderServiceReportList_CostPerDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_CostPerDay.Width = 200;
            // 
            // columnHeaderServiceReportList_StartedDate
            // 
            this.columnHeaderServiceReportList_StartedDate.Text = "Начало";
            this.columnHeaderServiceReportList_StartedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_StartedDate.Width = 200;
            // 
            // columnHeaderServiceReportList_PlannedCompletionDays
            // 
            this.columnHeaderServiceReportList_PlannedCompletionDays.Text = "Срок (дни)";
            this.columnHeaderServiceReportList_PlannedCompletionDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_PlannedCompletionDays.Width = 200;
            // 
            // columnHeaderServiceReportList_FinishedDate
            // 
            this.columnHeaderServiceReportList_FinishedDate.Text = "Окончание";
            this.columnHeaderServiceReportList_FinishedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_FinishedDate.Width = 200;
            // 
            // columnHeaderServiceReportList_AdditionalCost
            // 
            this.columnHeaderServiceReportList_AdditionalCost.Text = "Доп. цена";
            this.columnHeaderServiceReportList_AdditionalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_AdditionalCost.Width = 200;
            // 
            // columnHeaderServiceReportList_FullCost
            // 
            this.columnHeaderServiceReportList_FullCost.Text = "Вся цена";
            this.columnHeaderServiceReportList_FullCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_FullCost.Width = 200;
            // 
            // columnHeaderServiceReportList_IsStarted
            // 
            this.columnHeaderServiceReportList_IsStarted.Text = "Начато";
            this.columnHeaderServiceReportList_IsStarted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_IsStarted.Width = 120;
            // 
            // columnHeaderServiceReportList_IsFinished
            // 
            this.columnHeaderServiceReportList_IsFinished.Text = "Завершено";
            this.columnHeaderServiceReportList_IsFinished.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_IsFinished.Width = 120;
            // 
            // contextMenuStripListViewServiceReportList
            // 
            this.contextMenuStripListViewServiceReportList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStripListViewServiceReportList.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripListViewServiceReportList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemListViewOrderList_Copy,
            this.toolStripMenuItemListViewServiceReportList_Copy_ID,
            this.toolStripMenuItemListViewServiceReportList_Copy_FullName,
            this.toolStripMenuItemListViewServiceReportList_Copy_PricePerDay,
            this.toolStripMenuItemListViewServiceReportList_Copy_StartedDate,
            this.toolStripMenuItemListViewServiceReportList_Copy_PlannedDays,
            this.toolStripMenuItemListViewServiceReportList_Copy_FinishedDate,
            this.toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost,
            this.toolStripMenuItemListViewServiceReportList_Copy_Cost,
            this.toolStripMenuItemListViewServiceReportList_Copy_IsStarted,
            this.toolStripMenuItemListViewServiceReportList_Copy_IsFinished});
            this.contextMenuStripListViewServiceReportList.Name = "contextMenuStripListView";
            this.contextMenuStripListViewServiceReportList.Size = new System.Drawing.Size(483, 356);
            // 
            // toolStripMenuItemListViewOrderList_Copy
            // 
            this.toolStripMenuItemListViewOrderList_Copy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemListViewOrderList_Copy.Name = "toolStripMenuItemListViewOrderList_Copy";
            this.toolStripMenuItemListViewOrderList_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toolStripMenuItemListViewOrderList_Copy.Size = new System.Drawing.Size(482, 32);
            this.toolStripMenuItemListViewOrderList_Copy.Text = "Скопировать";
            this.toolStripMenuItemListViewOrderList_Copy.Click += new System.EventHandler(this.toolStripMenuItemListViewServiceReportList_Copy_Click);
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_ID
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_ID.Name = "toolStripMenuItemListViewServiceReportList_Copy_ID";
            this.toolStripMenuItemListViewServiceReportList_Copy_ID.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.toolStripMenuItemListViewServiceReportList_Copy_ID.Size = new System.Drawing.Size(482, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_ID.Text = "Скопировать ID отчёта";
            this.toolStripMenuItemListViewServiceReportList_Copy_ID.Click += new System.EventHandler(this.toolStripMenuItemListViewServiceReportList_Copy_ID_Click);
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_FullName
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_FullName.Name = "toolStripMenuItemListViewServiceReportList_Copy_FullName";
            this.toolStripMenuItemListViewServiceReportList_Copy_FullName.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.toolStripMenuItemListViewServiceReportList_Copy_FullName.Size = new System.Drawing.Size(482, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_FullName.Text = "Скопировать полное имя сотрудника";
            this.toolStripMenuItemListViewServiceReportList_Copy_FullName.Click += new System.EventHandler(this.toolStripMenuItemListViewServiceReportList_Copy_FullName_Click);
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_PricePerDay
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_PricePerDay.Name = "toolStripMenuItemListViewServiceReportList_Copy_PricePerDay";
            this.toolStripMenuItemListViewServiceReportList_Copy_PricePerDay.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.toolStripMenuItemListViewServiceReportList_Copy_PricePerDay.Size = new System.Drawing.Size(482, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_PricePerDay.Text = "Скопировать цену в день";
            this.toolStripMenuItemListViewServiceReportList_Copy_PricePerDay.Click += new System.EventHandler(this.toolStripMenuItemListViewServiceReportList_Copy_PricePerDay_Click);
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_StartedDate
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_StartedDate.Name = "toolStripMenuItemListViewServiceReportList_Copy_StartedDate";
            this.toolStripMenuItemListViewServiceReportList_Copy_StartedDate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.toolStripMenuItemListViewServiceReportList_Copy_StartedDate.Size = new System.Drawing.Size(482, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_StartedDate.Text = "Скопировать дату начала работ";
            this.toolStripMenuItemListViewServiceReportList_Copy_StartedDate.Click += new System.EventHandler(this.toolStripMenuItemListViewServiceReportList_Copy_StartedDate_Click);
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_PlannedDays
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_PlannedDays.Name = "toolStripMenuItemListViewServiceReportList_Copy_PlannedDays";
            this.toolStripMenuItemListViewServiceReportList_Copy_PlannedDays.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.toolStripMenuItemListViewServiceReportList_Copy_PlannedDays.Size = new System.Drawing.Size(482, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_PlannedDays.Text = "Скопировать срок выполнения (в днях)";
            this.toolStripMenuItemListViewServiceReportList_Copy_PlannedDays.Click += new System.EventHandler(this.toolStripMenuItemListViewServiceReportList_Copy_PlannedDays_Click);
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_FinishedDate
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_FinishedDate.Name = "toolStripMenuItemListViewServiceReportList_Copy_FinishedDate";
            this.toolStripMenuItemListViewServiceReportList_Copy_FinishedDate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D6)));
            this.toolStripMenuItemListViewServiceReportList_Copy_FinishedDate.Size = new System.Drawing.Size(482, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_FinishedDate.Text = "Скопировать дату окончания";
            this.toolStripMenuItemListViewServiceReportList_Copy_FinishedDate.Click += new System.EventHandler(this.toolStripMenuItemListViewServiceReportList_Copy_FinishedDate_Click);
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost.Name = "toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost";
            this.toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D7)));
            this.toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost.Size = new System.Drawing.Size(482, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost.Text = "Скопировать доп. цену";
            this.toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost.Click += new System.EventHandler(this.toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost_Click);
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_Cost
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_Cost.Name = "toolStripMenuItemListViewServiceReportList_Copy_Cost";
            this.toolStripMenuItemListViewServiceReportList_Copy_Cost.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D8)));
            this.toolStripMenuItemListViewServiceReportList_Copy_Cost.Size = new System.Drawing.Size(482, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_Cost.Text = "Скопировать всю цену";
            this.toolStripMenuItemListViewServiceReportList_Copy_Cost.Click += new System.EventHandler(this.toolStripMenuItemListViewServiceReportList_Copy_Cost_Click);
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_IsStarted
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_IsStarted.Name = "toolStripMenuItemListViewServiceReportList_Copy_IsStarted";
            this.toolStripMenuItemListViewServiceReportList_Copy_IsStarted.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D9)));
            this.toolStripMenuItemListViewServiceReportList_Copy_IsStarted.Size = new System.Drawing.Size(482, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_IsStarted.Text = "Скопировать \"Начато\"";
            this.toolStripMenuItemListViewServiceReportList_Copy_IsStarted.Click += new System.EventHandler(this.toolStripMenuItemListViewServiceReportList_Copy_IsStarted_Click);
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_IsFinished
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_IsFinished.Name = "toolStripMenuItemListViewServiceReportList_Copy_IsFinished";
            this.toolStripMenuItemListViewServiceReportList_Copy_IsFinished.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.toolStripMenuItemListViewServiceReportList_Copy_IsFinished.Size = new System.Drawing.Size(482, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_IsFinished.Text = "Скопировать \"Завершено\"";
            this.toolStripMenuItemListViewServiceReportList_Copy_IsFinished.Click += new System.EventHandler(this.toolStripMenuItemListViewServiceReportList_Copy_IsFinished_Click);
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageSettings.Controls.Add(this.labelSettings_TotalSalaryPayed);
            this.tabPageSettings.Controls.Add(this.label1);
            this.tabPageSettings.Controls.Add(this.buttonSettings_Save);
            this.tabPageSettings.Controls.Add(this.label3);
            this.tabPageSettings.Controls.Add(this.textBoxSettings_CardNumber);
            this.tabPageSettings.Controls.Add(this.label5);
            this.tabPageSettings.Controls.Add(this.textBoxSettings_NewPasswordConfirmation);
            this.tabPageSettings.Controls.Add(this.label4);
            this.tabPageSettings.Controls.Add(this.textBoxSettings_NewPassword);
            this.tabPageSettings.Controls.Add(this.buttonSettings_ChangePassword);
            this.tabPageSettings.Controls.Add(this.label2);
            this.tabPageSettings.Controls.Add(this.textBoxSettings_OldPassword);
            this.tabPageSettings.ImageKey = "Settings.png";
            this.tabPageSettings.Location = new System.Drawing.Point(4, 34);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(1805, 606);
            this.tabPageSettings.TabIndex = 2;
            this.tabPageSettings.Text = "Настройки ";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // buttonSettings_Save
            // 
            this.buttonSettings_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings_Save.Location = new System.Drawing.Point(796, 449);
            this.buttonSettings_Save.Name = "buttonSettings_Save";
            this.buttonSettings_Save.Size = new System.Drawing.Size(169, 61);
            this.buttonSettings_Save.TabIndex = 5;
            this.buttonSettings_Save.Text = "Сохранить настройки";
            this.buttonSettings_Save.UseVisualStyleBackColor = true;
            this.buttonSettings_Save.Click += new System.EventHandler(this.buttonSettings_Save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(795, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 75);
            this.label3.TabIndex = 26;
            this.label3.Text = "Номер карты или\r\nбанковского счёта\r\nдля выплат:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSettings_CardNumber
            // 
            this.textBoxSettings_CardNumber.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxSettings_CardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSettings_CardNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSettings_CardNumber.Location = new System.Drawing.Point(729, 402);
            this.textBoxSettings_CardNumber.Name = "textBoxSettings_CardNumber";
            this.textBoxSettings_CardNumber.Size = new System.Drawing.Size(300, 31);
            this.textBoxSettings_CardNumber.TabIndex = 4;
            this.textBoxSettings_CardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettings_CardNumber.TextChanged += new System.EventHandler(this.textBoxSettings_CardNumber_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(755, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(262, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "Подтвердите новый пароль: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSettings_NewPasswordConfirmation
            // 
            this.textBoxSettings_NewPasswordConfirmation.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxSettings_NewPasswordConfirmation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSettings_NewPasswordConfirmation.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSettings_NewPasswordConfirmation.Location = new System.Drawing.Point(729, 207);
            this.textBoxSettings_NewPasswordConfirmation.Name = "textBoxSettings_NewPasswordConfirmation";
            this.textBoxSettings_NewPasswordConfirmation.Size = new System.Drawing.Size(299, 31);
            this.textBoxSettings_NewPasswordConfirmation.TabIndex = 2;
            this.textBoxSettings_NewPasswordConfirmation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettings_NewPasswordConfirmation.UseSystemPasswordChar = true;
            this.textBoxSettings_NewPasswordConfirmation.TextChanged += new System.EventHandler(this.textBoxSettings_NewPasswordConfirmation_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(809, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Новый пароль: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSettings_NewPassword
            // 
            this.textBoxSettings_NewPassword.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxSettings_NewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSettings_NewPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSettings_NewPassword.Location = new System.Drawing.Point(729, 128);
            this.textBoxSettings_NewPassword.Name = "textBoxSettings_NewPassword";
            this.textBoxSettings_NewPassword.Size = new System.Drawing.Size(299, 31);
            this.textBoxSettings_NewPassword.TabIndex = 1;
            this.textBoxSettings_NewPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettings_NewPassword.UseSystemPasswordChar = true;
            this.textBoxSettings_NewPassword.TextChanged += new System.EventHandler(this.textBoxSettings_NewPassword_TextChanged);
            // 
            // buttonSettings_ChangePassword
            // 
            this.buttonSettings_ChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings_ChangePassword.Location = new System.Drawing.Point(796, 259);
            this.buttonSettings_ChangePassword.Name = "buttonSettings_ChangePassword";
            this.buttonSettings_ChangePassword.Size = new System.Drawing.Size(168, 47);
            this.buttonSettings_ChangePassword.TabIndex = 3;
            this.buttonSettings_ChangePassword.Text = "Сменить пароль";
            this.buttonSettings_ChangePassword.UseVisualStyleBackColor = true;
            this.buttonSettings_ChangePassword.Click += new System.EventHandler(this.buttonSettings_ChangePassword_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(804, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Старый пароль: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSettings_OldPassword
            // 
            this.textBoxSettings_OldPassword.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxSettings_OldPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSettings_OldPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSettings_OldPassword.Location = new System.Drawing.Point(729, 53);
            this.textBoxSettings_OldPassword.Name = "textBoxSettings_OldPassword";
            this.textBoxSettings_OldPassword.Size = new System.Drawing.Size(299, 31);
            this.textBoxSettings_OldPassword.TabIndex = 0;
            this.textBoxSettings_OldPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettings_OldPassword.UseSystemPasswordChar = true;
            this.textBoxSettings_OldPassword.TextChanged += new System.EventHandler(this.textBoxSettings_OldPassword_TextChanged);
            // 
            // imageListTabControlEmployee
            // 
            this.imageListTabControlEmployee.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTabControlEmployee.ImageStream")));
            this.imageListTabControlEmployee.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTabControlEmployee.Images.SetKeyName(0, "OrderList.png");
            this.imageListTabControlEmployee.Images.SetKeyName(1, "Settings.png");
            // 
            // toolTipOrderListCarPicture
            // 
            this.toolTipOrderListCarPicture.AutomaticDelay = 250;
            this.toolTipOrderListCarPicture.AutoPopDelay = 5000;
            this.toolTipOrderListCarPicture.InitialDelay = 250;
            this.toolTipOrderListCarPicture.ReshowDelay = 50;
            this.toolTipOrderListCarPicture.ToolTipTitle = "Время окончания";
            // 
            // toolTipSettings_Password
            // 
            this.toolTipSettings_Password.AutomaticDelay = 250;
            this.toolTipSettings_Password.AutoPopDelay = 5000;
            this.toolTipSettings_Password.InitialDelay = 250;
            this.toolTipSettings_Password.ReshowDelay = 50;
            this.toolTipSettings_Password.ToolTipTitle = "Ваш текущий пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(780, 522);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Всего выплачено Вам:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSettings_TotalSalaryPayed
            // 
            this.labelSettings_TotalSalaryPayed.BackColor = System.Drawing.Color.Transparent;
            this.labelSettings_TotalSalaryPayed.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettings_TotalSalaryPayed.ForeColor = System.Drawing.Color.SeaGreen;
            this.labelSettings_TotalSalaryPayed.Location = new System.Drawing.Point(780, 547);
            this.labelSettings_TotalSalaryPayed.Name = "labelSettings_TotalSalaryPayed";
            this.labelSettings_TotalSalaryPayed.Size = new System.Drawing.Size(202, 42);
            this.labelSettings_TotalSalaryPayed.TabIndex = 28;
            this.labelSettings_TotalSalaryPayed.Text = "0";
            this.labelSettings_TotalSalaryPayed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelUsernameText
            // 
            this.labelUsernameText.AutoSize = true;
            this.labelUsernameText.BackColor = System.Drawing.Color.Transparent;
            this.labelUsernameText.Location = new System.Drawing.Point(1372, 5);
            this.labelUsernameText.Name = "labelUsernameText";
            this.labelUsernameText.Size = new System.Drawing.Size(223, 25);
            this.labelUsernameText.TabIndex = 42;
            this.labelUsernameText.Text = "Ваше имя пользователя:";
            this.labelUsernameText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelUsername
            // 
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelUsername.Location = new System.Drawing.Point(1601, 5);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(200, 25);
            this.labelUsername.TabIndex = 43;
            this.labelUsername.Text = "User";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1813, 644);
            this.Controls.Add(this.labelUsernameText);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.tabControlEmployee);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "EmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarSharingBY - администратор";
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            this.tabControlEmployee.ResumeLayout(false);
            this.tabPageServiceReportList.ResumeLayout(false);
            this.tabPageServiceReportList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServiceReportList_CarPicture)).EndInit();
            this.contextMenuStripListViewServiceReportList.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlEmployee;
        private System.Windows.Forms.TabPage tabPageServiceReportList;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSettings_NewPasswordConfirmation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSettings_NewPassword;
        private System.Windows.Forms.Button buttonSettings_ChangePassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSettings_OldPassword;
        private System.Windows.Forms.ImageList imageListTabControlEmployee;
        private System.Windows.Forms.ListView listViewServiceReportList;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_SpaceColumn;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_FinishedDate;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_StartedDate;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_AdditionalCost;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_IsFinished;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_ID;
        private System.Windows.Forms.PictureBox pictureBoxServiceReportList_CarPicture;
        private System.Windows.Forms.ToolTip toolTipOrderListCarPicture;
        private System.Windows.Forms.Label labelServiceReportList_CarOrderInfo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxServiceReportList_CarBrand;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxServiceReportList_CarModel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxServiceReportList_ProductionYear;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxServiceReportList_PricePerHour;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxServiceReportList_CarLicensePlate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxServiceReportList_LastServiceDate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListViewServiceReportList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewOrderList_Copy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_PricePerDay;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_Cost;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_ID;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_PlannedCompletionDays;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_CostPerDay;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_FullCost;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_IsStarted;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_EmployeeName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxServiceReportList_EmployeeReportString;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxServiceReportList_Description;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_FullName;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_StartedDate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_PlannedDays;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_FinishedDate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_IsStarted;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_IsFinished;
        private System.Windows.Forms.ToolTip toolTipSettings_Password;
        private System.Windows.Forms.Button buttonSettings_Save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSettings_CardNumber;
        private System.Windows.Forms.Button buttonMakeServiceReport_TakeOrder;
        private System.Windows.Forms.Button buttonMakeServiceReport_EndOrder;
        private System.Windows.Forms.Button buttonMakeServiceReport_EditOrder;
        private System.Windows.Forms.Label labelSettings_TotalSalaryPayed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUsernameText;
        private System.Windows.Forms.Label labelUsername;
    }
}

