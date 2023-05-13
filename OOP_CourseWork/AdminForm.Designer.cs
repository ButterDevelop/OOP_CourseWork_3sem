using System;

namespace OOP_CourseWork
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.tabControlAdmin = new System.Windows.Forms.TabControl();
            this.tabPageServiceReportList = new System.Windows.Forms.TabPage();
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
            this.tabPageMakeOrder = new System.Windows.Forms.TabPage();
            this.buttonMakeServiceReport_HideShowCar = new System.Windows.Forms.Button();
            this.labelClickThisToAddNewCarImage = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxMakeMakeServiceReport_NewCarLicensePlate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxMakeMakeServiceReport_NewCarPricePerHour = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxMakeMakeServiceReport_NewCarProductionYear = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxMakeMakeServiceReport_NewCarModel = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxMakeMakeServiceReport_NewCarBrand = new System.Windows.Forms.TextBox();
            this.pictureBoxMakeServiceReport_AddNewCarPicture = new System.Windows.Forms.PictureBox();
            this.labelSpliter = new System.Windows.Forms.Label();
            this.buttonMakeServiceReport_AddNewCar = new System.Windows.Forms.Button();
            this.buttonMakeServiceReport_OpenCarLocationMap = new System.Windows.Forms.Button();
            this.textBoxMakeMakeServiceReport_Description = new System.Windows.Forms.TextBox();
            this.labelMakeServiceReport_CarOrderInfo = new System.Windows.Forms.Label();
            this.pictureBoxMakeServiceReport_CarPicture = new System.Windows.Forms.PictureBox();
            this.buttonMakeServiceReport_SendToService = new System.Windows.Forms.Button();
            this.listViewMakeServiceReport = new System.Windows.Forms.ListView();
            this.columnHeaderMakeServiceReport_SpaceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_IsHidden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_IsNowOnService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_Brand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_CarLicensePlate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_PricePerHour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_ProductionYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_BuyTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_LastServiceTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripListViewMakeServiceReport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemListViewMakeServiceReport_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewMakeServiceReport_Copy_ID = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewMakeServiceReport_Copy_Status = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBrand = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarModel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLicensePlate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarPricePerHour = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarProductionYear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBuyTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLastServiceDate = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageUsersManagement = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUsersManagement_FindInTheTable = new System.Windows.Forms.TextBox();
            this.buttonUsersManagement_DeactivateThisAccount = new System.Windows.Forms.Button();
            this.buttonUsersManagement_SetRoleClient = new System.Windows.Forms.Button();
            this.buttonUsersManagement_SetRoleEmployee = new System.Windows.Forms.Button();
            this.listViewUsersManagement = new System.Windows.Forms.ListView();
            this.columnHeaderUsersManagement_SpaceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUsersManagement_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUsersManagement_Username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUsersManagement_FullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUsersManagement_Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUsersManagement_PhoneNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUsersManagement_Role = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUsersManagement_IsAccountSetupCompleted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUsersManagement_IsDeactivated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripListViewUsersManagement = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemListViewPayments_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewPayments_Copy_CardNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewPayments_Copy_CreatedDate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewPayments_Copy_Cost = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewPayments_Copy_IsFinished = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewPayments_Copy_IsCancelled = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageFinancialReport = new System.Windows.Forms.TabPage();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.labelSettings_WholeCarsServicedByThisAdmin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSettings_NewPasswordConfirmation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSettings_NewPassword = new System.Windows.Forms.TextBox();
            this.buttonSettings_ChangePassword = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSettings_OldPassword = new System.Windows.Forms.TextBox();
            this.imageListTabControlAdmin = new System.Windows.Forms.ImageList(this.components);
            this.toolTipOrderListCarPicture = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipMakeServiceReport_PricePerHour = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipMakeServiceReport_ProductionYear = new System.Windows.Forms.ToolTip(this.components);
            this.buttonUsersManagement_ActivateThisAccount = new System.Windows.Forms.Button();
            this.dateTimePickerFinancialReport_FromDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFinancialReport_ToDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonFinancialReport_GetReports = new System.Windows.Forms.Button();
            this.labelFinancialReport_PotentionalSalary = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelFinancialReport_AvailableSalary = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.toolTipUsersManagement_FindInTheTable = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSettings_Password = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipMakeServiceReport_HideOrShowCar = new System.Windows.Forms.ToolTip(this.components);
            this.labelFinancialReport_ClickThisNumberToCopyIt = new System.Windows.Forms.Label();
            this.tabControlAdmin.SuspendLayout();
            this.tabPageServiceReportList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServiceReportList_CarPicture)).BeginInit();
            this.contextMenuStripListViewServiceReportList.SuspendLayout();
            this.tabPageMakeOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMakeServiceReport_AddNewCarPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMakeServiceReport_CarPicture)).BeginInit();
            this.contextMenuStripListViewMakeServiceReport.SuspendLayout();
            this.tabPageUsersManagement.SuspendLayout();
            this.contextMenuStripListViewUsersManagement.SuspendLayout();
            this.tabPageFinancialReport.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlAdmin
            // 
            this.tabControlAdmin.Controls.Add(this.tabPageServiceReportList);
            this.tabControlAdmin.Controls.Add(this.tabPageMakeOrder);
            this.tabControlAdmin.Controls.Add(this.tabPageUsersManagement);
            this.tabControlAdmin.Controls.Add(this.tabPageFinancialReport);
            this.tabControlAdmin.Controls.Add(this.tabPageSettings);
            this.tabControlAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAdmin.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlAdmin.ImageList = this.imageListTabControlAdmin;
            this.tabControlAdmin.Location = new System.Drawing.Point(0, 0);
            this.tabControlAdmin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControlAdmin.Multiline = true;
            this.tabControlAdmin.Name = "tabControlAdmin";
            this.tabControlAdmin.SelectedIndex = 0;
            this.tabControlAdmin.Size = new System.Drawing.Size(1813, 644);
            this.tabControlAdmin.TabIndex = 0;
            // 
            // tabPageServiceReportList
            // 
            this.tabPageServiceReportList.BackColor = System.Drawing.Color.Transparent;
            this.tabPageServiceReportList.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageServiceReportList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageServiceReportList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            // textBoxServiceReportList_EmployeeReportString
            // 
            this.textBoxServiceReportList_EmployeeReportString.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxServiceReportList_EmployeeReportString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxServiceReportList_EmployeeReportString.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxServiceReportList_EmployeeReportString.Location = new System.Drawing.Point(1015, 158);
            this.textBoxServiceReportList_EmployeeReportString.Multiline = true;
            this.textBoxServiceReportList_EmployeeReportString.Name = "textBoxServiceReportList_EmployeeReportString";
            this.textBoxServiceReportList_EmployeeReportString.ReadOnly = true;
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
            this.label24.Text = "Отчёт сотрудника о проделанной работе:";
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
            // tabPageMakeOrder
            // 
            this.tabPageMakeOrder.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageMakeOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageMakeOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageMakeOrder.Controls.Add(this.buttonMakeServiceReport_HideShowCar);
            this.tabPageMakeOrder.Controls.Add(this.labelClickThisToAddNewCarImage);
            this.tabPageMakeOrder.Controls.Add(this.label11);
            this.tabPageMakeOrder.Controls.Add(this.textBoxMakeMakeServiceReport_NewCarLicensePlate);
            this.tabPageMakeOrder.Controls.Add(this.label12);
            this.tabPageMakeOrder.Controls.Add(this.textBoxMakeMakeServiceReport_NewCarPricePerHour);
            this.tabPageMakeOrder.Controls.Add(this.label19);
            this.tabPageMakeOrder.Controls.Add(this.textBoxMakeMakeServiceReport_NewCarProductionYear);
            this.tabPageMakeOrder.Controls.Add(this.label20);
            this.tabPageMakeOrder.Controls.Add(this.textBoxMakeMakeServiceReport_NewCarModel);
            this.tabPageMakeOrder.Controls.Add(this.label21);
            this.tabPageMakeOrder.Controls.Add(this.label22);
            this.tabPageMakeOrder.Controls.Add(this.textBoxMakeMakeServiceReport_NewCarBrand);
            this.tabPageMakeOrder.Controls.Add(this.pictureBoxMakeServiceReport_AddNewCarPicture);
            this.tabPageMakeOrder.Controls.Add(this.labelSpliter);
            this.tabPageMakeOrder.Controls.Add(this.buttonMakeServiceReport_AddNewCar);
            this.tabPageMakeOrder.Controls.Add(this.buttonMakeServiceReport_OpenCarLocationMap);
            this.tabPageMakeOrder.Controls.Add(this.textBoxMakeMakeServiceReport_Description);
            this.tabPageMakeOrder.Controls.Add(this.labelMakeServiceReport_CarOrderInfo);
            this.tabPageMakeOrder.Controls.Add(this.pictureBoxMakeServiceReport_CarPicture);
            this.tabPageMakeOrder.Controls.Add(this.buttonMakeServiceReport_SendToService);
            this.tabPageMakeOrder.Controls.Add(this.listViewMakeServiceReport);
            this.tabPageMakeOrder.ImageKey = "car.png";
            this.tabPageMakeOrder.Location = new System.Drawing.Point(4, 34);
            this.tabPageMakeOrder.Name = "tabPageMakeOrder";
            this.tabPageMakeOrder.Size = new System.Drawing.Size(1805, 606);
            this.tabPageMakeOrder.TabIndex = 3;
            this.tabPageMakeOrder.Text = "Авто и сервис ";
            this.tabPageMakeOrder.UseVisualStyleBackColor = true;
            // 
            // buttonMakeServiceReport_HideShowCar
            // 
            this.buttonMakeServiceReport_HideShowCar.Enabled = false;
            this.buttonMakeServiceReport_HideShowCar.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.buttonMakeServiceReport_HideShowCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMakeServiceReport_HideShowCar.Location = new System.Drawing.Point(1219, 197);
            this.buttonMakeServiceReport_HideShowCar.Name = "buttonMakeServiceReport_HideShowCar";
            this.buttonMakeServiceReport_HideShowCar.Size = new System.Drawing.Size(175, 40);
            this.buttonMakeServiceReport_HideShowCar.TabIndex = 47;
            this.buttonMakeServiceReport_HideShowCar.Text = "Спрятать авто";
            this.buttonMakeServiceReport_HideShowCar.UseVisualStyleBackColor = true;
            this.buttonMakeServiceReport_HideShowCar.Click += new System.EventHandler(this.buttonMakeServiceReport_HideShowCar_Click);
            // 
            // labelClickThisToAddNewCarImage
            // 
            this.labelClickThisToAddNewCarImage.AutoSize = true;
            this.labelClickThisToAddNewCarImage.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClickThisToAddNewCarImage.Location = new System.Drawing.Point(890, 90);
            this.labelClickThisToAddNewCarImage.Name = "labelClickThisToAddNewCarImage";
            this.labelClickThisToAddNewCarImage.Size = new System.Drawing.Size(257, 75);
            this.labelClickThisToAddNewCarImage.TabIndex = 46;
            this.labelClickThisToAddNewCarImage.Text = "Нажмите, чтобы добавить\r\nфотографию для нового\r\nавтомобиля";
            this.labelClickThisToAddNewCarImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelClickThisToAddNewCarImage.DoubleClick += new System.EventHandler(this.labelClickThisToAddNewCarImage_DoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1423, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 25);
            this.label11.TabIndex = 45;
            this.label11.Text = "Номерной знак: ";
            // 
            // textBoxMakeMakeServiceReport_NewCarLicensePlate
            // 
            this.textBoxMakeMakeServiceReport_NewCarLicensePlate.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxMakeMakeServiceReport_NewCarLicensePlate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMakeMakeServiceReport_NewCarLicensePlate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMakeMakeServiceReport_NewCarLicensePlate.Location = new System.Drawing.Point(1412, 148);
            this.textBoxMakeMakeServiceReport_NewCarLicensePlate.Name = "textBoxMakeMakeServiceReport_NewCarLicensePlate";
            this.textBoxMakeMakeServiceReport_NewCarLicensePlate.Size = new System.Drawing.Size(175, 31);
            this.textBoxMakeMakeServiceReport_NewCarLicensePlate.TabIndex = 7;
            this.textBoxMakeMakeServiceReport_NewCarLicensePlate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMakeMakeServiceReport_NewCarLicensePlate.TextChanged += new System.EventHandler(this.textBoxMakeMakeServiceReport_NewCarLicensePlate_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1255, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 25);
            this.label12.TabIndex = 43;
            this.label12.Text = "Цена в час: ";
            // 
            // textBoxMakeMakeServiceReport_NewCarPricePerHour
            // 
            this.textBoxMakeMakeServiceReport_NewCarPricePerHour.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxMakeMakeServiceReport_NewCarPricePerHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMakeMakeServiceReport_NewCarPricePerHour.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMakeMakeServiceReport_NewCarPricePerHour.Location = new System.Drawing.Point(1219, 148);
            this.textBoxMakeMakeServiceReport_NewCarPricePerHour.Name = "textBoxMakeMakeServiceReport_NewCarPricePerHour";
            this.textBoxMakeMakeServiceReport_NewCarPricePerHour.Size = new System.Drawing.Size(175, 31);
            this.textBoxMakeMakeServiceReport_NewCarPricePerHour.TabIndex = 6;
            this.textBoxMakeMakeServiceReport_NewCarPricePerHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMakeMakeServiceReport_NewCarPricePerHour.TextChanged += new System.EventHandler(this.textBoxMakeMakeServiceReport_NewCarPricePerHour_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1633, 54);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(124, 25);
            this.label19.TabIndex = 41;
            this.label19.Text = "Год выпуска: ";
            // 
            // textBoxMakeMakeServiceReport_NewCarProductionYear
            // 
            this.textBoxMakeMakeServiceReport_NewCarProductionYear.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxMakeMakeServiceReport_NewCarProductionYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMakeMakeServiceReport_NewCarProductionYear.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMakeMakeServiceReport_NewCarProductionYear.Location = new System.Drawing.Point(1605, 82);
            this.textBoxMakeMakeServiceReport_NewCarProductionYear.Name = "textBoxMakeMakeServiceReport_NewCarProductionYear";
            this.textBoxMakeMakeServiceReport_NewCarProductionYear.Size = new System.Drawing.Size(175, 31);
            this.textBoxMakeMakeServiceReport_NewCarProductionYear.TabIndex = 5;
            this.textBoxMakeMakeServiceReport_NewCarProductionYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMakeMakeServiceReport_NewCarProductionYear.TextChanged += new System.EventHandler(this.textBoxMakeMakeServiceReport_NewCarProductionYear_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(1434, 54);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(132, 25);
            this.label20.TabIndex = 39;
            this.label20.Text = "Модель авто: ";
            // 
            // textBoxMakeMakeServiceReport_NewCarModel
            // 
            this.textBoxMakeMakeServiceReport_NewCarModel.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxMakeMakeServiceReport_NewCarModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMakeMakeServiceReport_NewCarModel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMakeMakeServiceReport_NewCarModel.Location = new System.Drawing.Point(1412, 82);
            this.textBoxMakeMakeServiceReport_NewCarModel.Name = "textBoxMakeMakeServiceReport_NewCarModel";
            this.textBoxMakeMakeServiceReport_NewCarModel.Size = new System.Drawing.Size(175, 31);
            this.textBoxMakeMakeServiceReport_NewCarModel.TabIndex = 4;
            this.textBoxMakeMakeServiceReport_NewCarModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMakeMakeServiceReport_NewCarModel.TextChanged += new System.EventHandler(this.textBoxMakeMakeServiceReport_NewCarModel_TextChanged);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(1205, 14);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(588, 25);
            this.label21.TabIndex = 37;
            this.label21.Text = "Редактирование или добавление автомобиля в базу данных:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(1248, 54);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(119, 25);
            this.label22.TabIndex = 36;
            this.label22.Text = "Марка авто: ";
            // 
            // textBoxMakeMakeServiceReport_NewCarBrand
            // 
            this.textBoxMakeMakeServiceReport_NewCarBrand.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxMakeMakeServiceReport_NewCarBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMakeMakeServiceReport_NewCarBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMakeMakeServiceReport_NewCarBrand.Location = new System.Drawing.Point(1219, 82);
            this.textBoxMakeMakeServiceReport_NewCarBrand.Name = "textBoxMakeMakeServiceReport_NewCarBrand";
            this.textBoxMakeMakeServiceReport_NewCarBrand.Size = new System.Drawing.Size(175, 31);
            this.textBoxMakeMakeServiceReport_NewCarBrand.TabIndex = 3;
            this.textBoxMakeMakeServiceReport_NewCarBrand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMakeMakeServiceReport_NewCarBrand.TextChanged += new System.EventHandler(this.textBoxMakeMakeServiceReport_NewCarBrand_TextChanged);
            // 
            // pictureBoxMakeServiceReport_AddNewCarPicture
            // 
            this.pictureBoxMakeServiceReport_AddNewCarPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxMakeServiceReport_AddNewCarPicture.Location = new System.Drawing.Point(839, 7);
            this.pictureBoxMakeServiceReport_AddNewCarPicture.Name = "pictureBoxMakeServiceReport_AddNewCarPicture";
            this.pictureBoxMakeServiceReport_AddNewCarPicture.Size = new System.Drawing.Size(360, 240);
            this.pictureBoxMakeServiceReport_AddNewCarPicture.TabIndex = 34;
            this.pictureBoxMakeServiceReport_AddNewCarPicture.TabStop = false;
            this.pictureBoxMakeServiceReport_AddNewCarPicture.DoubleClick += new System.EventHandler(this.pictureBoxMakeServiceReport_AddNewCarPicture_DoubleClick);
            // 
            // labelSpliter
            // 
            this.labelSpliter.BackColor = System.Drawing.Color.Azure;
            this.labelSpliter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSpliter.Location = new System.Drawing.Point(796, 7);
            this.labelSpliter.Name = "labelSpliter";
            this.labelSpliter.Size = new System.Drawing.Size(28, 240);
            this.labelSpliter.TabIndex = 33;
            this.labelSpliter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonMakeServiceReport_AddNewCar
            // 
            this.buttonMakeServiceReport_AddNewCar.FlatAppearance.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonMakeServiceReport_AddNewCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMakeServiceReport_AddNewCar.Location = new System.Drawing.Point(1605, 142);
            this.buttonMakeServiceReport_AddNewCar.Name = "buttonMakeServiceReport_AddNewCar";
            this.buttonMakeServiceReport_AddNewCar.Size = new System.Drawing.Size(175, 40);
            this.buttonMakeServiceReport_AddNewCar.TabIndex = 8;
            this.buttonMakeServiceReport_AddNewCar.Text = "Добавить авто";
            this.buttonMakeServiceReport_AddNewCar.UseVisualStyleBackColor = true;
            this.buttonMakeServiceReport_AddNewCar.Click += new System.EventHandler(this.buttonMakeServiceReport_AddNewCar_Click);
            // 
            // buttonMakeServiceReport_OpenCarLocationMap
            // 
            this.buttonMakeServiceReport_OpenCarLocationMap.Enabled = false;
            this.buttonMakeServiceReport_OpenCarLocationMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMakeServiceReport_OpenCarLocationMap.Location = new System.Drawing.Point(379, 197);
            this.buttonMakeServiceReport_OpenCarLocationMap.Name = "buttonMakeServiceReport_OpenCarLocationMap";
            this.buttonMakeServiceReport_OpenCarLocationMap.Size = new System.Drawing.Size(175, 40);
            this.buttonMakeServiceReport_OpenCarLocationMap.TabIndex = 1;
            this.buttonMakeServiceReport_OpenCarLocationMap.Text = "Местоположение";
            this.buttonMakeServiceReport_OpenCarLocationMap.UseVisualStyleBackColor = true;
            this.buttonMakeServiceReport_OpenCarLocationMap.Click += new System.EventHandler(this.buttonMakeServiceReport_OpenCarLocationMap_Click);
            // 
            // textBoxMakeMakeServiceReport_Description
            // 
            this.textBoxMakeMakeServiceReport_Description.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxMakeMakeServiceReport_Description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMakeMakeServiceReport_Description.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMakeMakeServiceReport_Description.Location = new System.Drawing.Point(379, 57);
            this.textBoxMakeMakeServiceReport_Description.Multiline = true;
            this.textBoxMakeMakeServiceReport_Description.Name = "textBoxMakeMakeServiceReport_Description";
            this.textBoxMakeMakeServiceReport_Description.Size = new System.Drawing.Size(402, 124);
            this.textBoxMakeMakeServiceReport_Description.TabIndex = 0;
            // 
            // labelMakeServiceReport_CarOrderInfo
            // 
            this.labelMakeServiceReport_CarOrderInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMakeServiceReport_CarOrderInfo.Location = new System.Drawing.Point(374, 14);
            this.labelMakeServiceReport_CarOrderInfo.Name = "labelMakeServiceReport_CarOrderInfo";
            this.labelMakeServiceReport_CarOrderInfo.Size = new System.Drawing.Size(407, 25);
            this.labelMakeServiceReport_CarOrderInfo.TabIndex = 28;
            this.labelMakeServiceReport_CarOrderInfo.Text = "Причина отправки авто на обслуживание:";
            this.labelMakeServiceReport_CarOrderInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxMakeServiceReport_CarPicture
            // 
            this.pictureBoxMakeServiceReport_CarPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxMakeServiceReport_CarPicture.Location = new System.Drawing.Point(7, 7);
            this.pictureBoxMakeServiceReport_CarPicture.Name = "pictureBoxMakeServiceReport_CarPicture";
            this.pictureBoxMakeServiceReport_CarPicture.Size = new System.Drawing.Size(360, 240);
            this.pictureBoxMakeServiceReport_CarPicture.TabIndex = 25;
            this.pictureBoxMakeServiceReport_CarPicture.TabStop = false;
            // 
            // buttonMakeServiceReport_SendToService
            // 
            this.buttonMakeServiceReport_SendToService.Enabled = false;
            this.buttonMakeServiceReport_SendToService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMakeServiceReport_SendToService.Location = new System.Drawing.Point(604, 197);
            this.buttonMakeServiceReport_SendToService.Name = "buttonMakeServiceReport_SendToService";
            this.buttonMakeServiceReport_SendToService.Size = new System.Drawing.Size(177, 40);
            this.buttonMakeServiceReport_SendToService.TabIndex = 2;
            this.buttonMakeServiceReport_SendToService.Text = "На обслуживание";
            this.buttonMakeServiceReport_SendToService.UseVisualStyleBackColor = true;
            this.buttonMakeServiceReport_SendToService.Click += new System.EventHandler(this.buttonMakeServiceReport_SendToService_Click);
            // 
            // listViewMakeServiceReport
            // 
            this.listViewMakeServiceReport.BackColor = System.Drawing.Color.AliceBlue;
            this.listViewMakeServiceReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewMakeServiceReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderMakeServiceReport_SpaceColumn,
            this.columnHeaderMakeServiceReport_ID,
            this.columnHeaderMakeServiceReport_IsHidden,
            this.columnHeaderMakeServiceReport_IsNowOnService,
            this.columnHeaderMakeServiceReport_Brand,
            this.columnHeaderMakeServiceReport_Model,
            this.columnHeaderMakeServiceReport_CarLicensePlate,
            this.columnHeaderMakeServiceReport_PricePerHour,
            this.columnHeaderMakeServiceReport_ProductionYear,
            this.columnHeaderMakeServiceReport_BuyTime,
            this.columnHeaderMakeServiceReport_LastServiceTime});
            this.listViewMakeServiceReport.ContextMenuStrip = this.contextMenuStripListViewMakeServiceReport;
            this.listViewMakeServiceReport.FullRowSelect = true;
            this.listViewMakeServiceReport.GridLines = true;
            this.listViewMakeServiceReport.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewMakeServiceReport.HideSelection = false;
            this.listViewMakeServiceReport.Location = new System.Drawing.Point(7, 253);
            this.listViewMakeServiceReport.Name = "listViewMakeServiceReport";
            this.listViewMakeServiceReport.Size = new System.Drawing.Size(1789, 344);
            this.listViewMakeServiceReport.TabIndex = 9;
            this.listViewMakeServiceReport.UseCompatibleStateImageBehavior = false;
            this.listViewMakeServiceReport.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderMakeServiceReport_SpaceColumn
            // 
            this.columnHeaderMakeServiceReport_SpaceColumn.Text = "Space Column";
            this.columnHeaderMakeServiceReport_SpaceColumn.Width = 0;
            // 
            // columnHeaderMakeServiceReport_ID
            // 
            this.columnHeaderMakeServiceReport_ID.Text = "ID";
            this.columnHeaderMakeServiceReport_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_ID.Width = 70;
            // 
            // columnHeaderMakeServiceReport_IsHidden
            // 
            this.columnHeaderMakeServiceReport_IsHidden.Text = "Скрыта";
            this.columnHeaderMakeServiceReport_IsHidden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_IsHidden.Width = 80;
            // 
            // columnHeaderMakeServiceReport_IsNowOnService
            // 
            this.columnHeaderMakeServiceReport_IsNowOnService.Text = "Статус";
            this.columnHeaderMakeServiceReport_IsNowOnService.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_IsNowOnService.Width = 150;
            // 
            // columnHeaderMakeServiceReport_Brand
            // 
            this.columnHeaderMakeServiceReport_Brand.Text = "Марка автомобиля";
            this.columnHeaderMakeServiceReport_Brand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_Brand.Width = 240;
            // 
            // columnHeaderMakeServiceReport_Model
            // 
            this.columnHeaderMakeServiceReport_Model.Text = "Модель автомобиля";
            this.columnHeaderMakeServiceReport_Model.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_Model.Width = 240;
            // 
            // columnHeaderMakeServiceReport_CarLicensePlate
            // 
            this.columnHeaderMakeServiceReport_CarLicensePlate.Text = "Номерной знак";
            this.columnHeaderMakeServiceReport_CarLicensePlate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_CarLicensePlate.Width = 180;
            // 
            // columnHeaderMakeServiceReport_PricePerHour
            // 
            this.columnHeaderMakeServiceReport_PricePerHour.Text = "Цена в час";
            this.columnHeaderMakeServiceReport_PricePerHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_PricePerHour.Width = 160;
            // 
            // columnHeaderMakeServiceReport_ProductionYear
            // 
            this.columnHeaderMakeServiceReport_ProductionYear.Text = "Год производства";
            this.columnHeaderMakeServiceReport_ProductionYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_ProductionYear.Width = 180;
            // 
            // columnHeaderMakeServiceReport_BuyTime
            // 
            this.columnHeaderMakeServiceReport_BuyTime.Text = "Дата покупки компанией";
            this.columnHeaderMakeServiceReport_BuyTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_BuyTime.Width = 240;
            // 
            // columnHeaderMakeServiceReport_LastServiceTime
            // 
            this.columnHeaderMakeServiceReport_LastServiceTime.Text = "Последнее обслуживание";
            this.columnHeaderMakeServiceReport_LastServiceTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_LastServiceTime.Width = 240;
            // 
            // contextMenuStripListViewMakeServiceReport
            // 
            this.contextMenuStripListViewMakeServiceReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStripListViewMakeServiceReport.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripListViewMakeServiceReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemListViewMakeServiceReport_Copy,
            this.toolStripMenuItemListViewMakeServiceReport_Copy_ID,
            this.toolStripMenuItemListViewMakeServiceReport_Copy_Status,
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBrand,
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarModel,
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLicensePlate,
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarPricePerHour,
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarProductionYear,
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBuyTime,
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLastServiceDate});
            this.contextMenuStripListViewMakeServiceReport.Name = "contextMenuStripListView";
            this.contextMenuStripListViewMakeServiceReport.Size = new System.Drawing.Size(632, 324);
            // 
            // toolStripMenuItemListViewMakeServiceReport_Copy
            // 
            this.toolStripMenuItemListViewMakeServiceReport_Copy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemListViewMakeServiceReport_Copy.Name = "toolStripMenuItemListViewMakeServiceReport_Copy";
            this.toolStripMenuItemListViewMakeServiceReport_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toolStripMenuItemListViewMakeServiceReport_Copy.Size = new System.Drawing.Size(631, 32);
            this.toolStripMenuItemListViewMakeServiceReport_Copy.Text = "Скопировать";
            this.toolStripMenuItemListViewMakeServiceReport_Copy.Click += new System.EventHandler(this.toolStripMenuItemListViewMakeServiceReport_Copy_Click);
            // 
            // toolStripMenuItemListViewMakeServiceReport_Copy_ID
            // 
            this.toolStripMenuItemListViewMakeServiceReport_Copy_ID.Name = "toolStripMenuItemListViewMakeServiceReport_Copy_ID";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_ID.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.toolStripMenuItemListViewMakeServiceReport_Copy_ID.Size = new System.Drawing.Size(631, 32);
            this.toolStripMenuItemListViewMakeServiceReport_Copy_ID.Text = "Скопировать ID автомобиля";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_ID.Click += new System.EventHandler(this.toolStripMenuItemListViewMakeServiceReport_Copy_ID_Click);
            // 
            // toolStripMenuItemListViewMakeServiceReport_Copy_Status
            // 
            this.toolStripMenuItemListViewMakeServiceReport_Copy_Status.Name = "toolStripMenuItemListViewMakeServiceReport_Copy_Status";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_Status.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.toolStripMenuItemListViewMakeServiceReport_Copy_Status.Size = new System.Drawing.Size(631, 32);
            this.toolStripMenuItemListViewMakeServiceReport_Copy_Status.Text = "Скопировать статус";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_Status.Click += new System.EventHandler(this.toolStripMenuItemListViewMakeServiceReport_Copy_Status_Click);
            // 
            // toolStripMenuItemListViewMakeServiceReport_Copy_CarBrand
            // 
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBrand.Name = "toolStripMenuItemListViewMakeServiceReport_Copy_CarBrand";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBrand.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBrand.Size = new System.Drawing.Size(631, 32);
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBrand.Text = "Скопировать марку автомобиля";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBrand.Click += new System.EventHandler(this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBrand_Click);
            // 
            // toolStripMenuItemListViewMakeServiceReport_Copy_CarModel
            // 
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarModel.Name = "toolStripMenuItemListViewMakeServiceReport_Copy_CarModel";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarModel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarModel.Size = new System.Drawing.Size(631, 32);
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarModel.Text = "Скопировать модель автомобиля";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarModel.Click += new System.EventHandler(this.toolStripMenuItemListViewMakeServiceReport_Copy_CarModel_Click);
            // 
            // toolStripMenuItemListViewMakeServiceReport_Copy_CarLicensePlate
            // 
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLicensePlate.Name = "toolStripMenuItemListViewMakeServiceReport_Copy_CarLicensePlate";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLicensePlate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLicensePlate.Size = new System.Drawing.Size(631, 32);
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLicensePlate.Text = "Скопировать номерной знак";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLicensePlate.Click += new System.EventHandler(this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLicensePlate_Click);
            // 
            // toolStripMenuItemListViewMakeServiceReport_Copy_CarPricePerHour
            // 
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarPricePerHour.Name = "toolStripMenuItemListViewMakeServiceReport_Copy_CarPricePerHour";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarPricePerHour.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D6)));
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarPricePerHour.Size = new System.Drawing.Size(631, 32);
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarPricePerHour.Text = "Скопировать цену в час";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarPricePerHour.Click += new System.EventHandler(this.toolStripMenuItemListViewMakeServiceReport_Copy_CarPricePerHour_Click);
            // 
            // toolStripMenuItemListViewMakeServiceReport_Copy_CarProductionYear
            // 
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarProductionYear.Name = "toolStripMenuItemListViewMakeServiceReport_Copy_CarProductionYear";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarProductionYear.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D7)));
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarProductionYear.Size = new System.Drawing.Size(631, 32);
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarProductionYear.Text = "Скопировать год производства автомобиля";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarProductionYear.Click += new System.EventHandler(this.toolStripMenuItemListViewMakeServiceReport_Copy_CarProductionYear_Click);
            // 
            // toolStripMenuItemListViewMakeServiceReport_Copy_CarBuyTime
            // 
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBuyTime.Name = "toolStripMenuItemListViewMakeServiceReport_Copy_CarBuyTime";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBuyTime.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D8)));
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBuyTime.Size = new System.Drawing.Size(631, 32);
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBuyTime.Text = "Скопировать дату покупки автомобиля";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBuyTime.Click += new System.EventHandler(this.toolStripMenuItemListViewMakeServiceReport_Copy_CarBuyTime_Click);
            // 
            // toolStripMenuItemListViewMakeServiceReport_Copy_CarLastServiceDate
            // 
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLastServiceDate.Name = "toolStripMenuItemListViewMakeServiceReport_Copy_CarLastServiceDate";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLastServiceDate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D9)));
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLastServiceDate.Size = new System.Drawing.Size(631, 32);
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLastServiceDate.Text = "Скопировать дату последнего обслуживания автомобиля";
            this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLastServiceDate.Click += new System.EventHandler(this.toolStripMenuItemListViewMakeServiceReport_Copy_CarLastServiceDate_Click);
            // 
            // tabPageUsersManagement
            // 
            this.tabPageUsersManagement.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageUsersManagement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageUsersManagement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageUsersManagement.Controls.Add(this.buttonUsersManagement_ActivateThisAccount);
            this.tabPageUsersManagement.Controls.Add(this.label3);
            this.tabPageUsersManagement.Controls.Add(this.textBoxUsersManagement_FindInTheTable);
            this.tabPageUsersManagement.Controls.Add(this.buttonUsersManagement_DeactivateThisAccount);
            this.tabPageUsersManagement.Controls.Add(this.buttonUsersManagement_SetRoleClient);
            this.tabPageUsersManagement.Controls.Add(this.buttonUsersManagement_SetRoleEmployee);
            this.tabPageUsersManagement.Controls.Add(this.listViewUsersManagement);
            this.tabPageUsersManagement.ImageKey = "users.png";
            this.tabPageUsersManagement.Location = new System.Drawing.Point(4, 34);
            this.tabPageUsersManagement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageUsersManagement.Name = "tabPageUsersManagement";
            this.tabPageUsersManagement.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageUsersManagement.Size = new System.Drawing.Size(1805, 606);
            this.tabPageUsersManagement.TabIndex = 1;
            this.tabPageUsersManagement.Text = "Управление пользователями ";
            this.tabPageUsersManagement.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 25);
            this.label3.TabIndex = 38;
            this.label3.Text = "Поиск по таблице: ";
            // 
            // textBoxUsersManagement_FindInTheTable
            // 
            this.textBoxUsersManagement_FindInTheTable.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxUsersManagement_FindInTheTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUsersManagement_FindInTheTable.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsersManagement_FindInTheTable.Location = new System.Drawing.Point(16, 49);
            this.textBoxUsersManagement_FindInTheTable.Name = "textBoxUsersManagement_FindInTheTable";
            this.textBoxUsersManagement_FindInTheTable.Size = new System.Drawing.Size(316, 31);
            this.textBoxUsersManagement_FindInTheTable.TabIndex = 0;
            this.textBoxUsersManagement_FindInTheTable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxUsersManagement_FindInTheTable.TextChanged += new System.EventHandler(this.textBoxUsersManagement_FindInTheTable_TextChanged);
            // 
            // buttonUsersManagement_DeactivateThisAccount
            // 
            this.buttonUsersManagement_DeactivateThisAccount.Enabled = false;
            this.buttonUsersManagement_DeactivateThisAccount.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonUsersManagement_DeactivateThisAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUsersManagement_DeactivateThisAccount.Location = new System.Drawing.Point(1298, 33);
            this.buttonUsersManagement_DeactivateThisAccount.Name = "buttonUsersManagement_DeactivateThisAccount";
            this.buttonUsersManagement_DeactivateThisAccount.Size = new System.Drawing.Size(235, 47);
            this.buttonUsersManagement_DeactivateThisAccount.TabIndex = 3;
            this.buttonUsersManagement_DeactivateThisAccount.Text = "Деактивировать аккаунт";
            this.buttonUsersManagement_DeactivateThisAccount.UseVisualStyleBackColor = true;
            this.buttonUsersManagement_DeactivateThisAccount.Click += new System.EventHandler(this.buttonUsersManagement_DeactivateThisAccount_Click);
            // 
            // buttonUsersManagement_SetRoleClient
            // 
            this.buttonUsersManagement_SetRoleClient.Enabled = false;
            this.buttonUsersManagement_SetRoleClient.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.buttonUsersManagement_SetRoleClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUsersManagement_SetRoleClient.Location = new System.Drawing.Point(848, 33);
            this.buttonUsersManagement_SetRoleClient.Name = "buttonUsersManagement_SetRoleClient";
            this.buttonUsersManagement_SetRoleClient.Size = new System.Drawing.Size(209, 47);
            this.buttonUsersManagement_SetRoleClient.TabIndex = 1;
            this.buttonUsersManagement_SetRoleClient.Text = "Сделать клиентом";
            this.buttonUsersManagement_SetRoleClient.UseVisualStyleBackColor = true;
            this.buttonUsersManagement_SetRoleClient.Click += new System.EventHandler(this.buttonUsersManagement_SetRoleClient_Click);
            // 
            // buttonUsersManagement_SetRoleEmployee
            // 
            this.buttonUsersManagement_SetRoleEmployee.Enabled = false;
            this.buttonUsersManagement_SetRoleEmployee.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.buttonUsersManagement_SetRoleEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUsersManagement_SetRoleEmployee.Location = new System.Drawing.Point(1073, 33);
            this.buttonUsersManagement_SetRoleEmployee.Name = "buttonUsersManagement_SetRoleEmployee";
            this.buttonUsersManagement_SetRoleEmployee.Size = new System.Drawing.Size(209, 47);
            this.buttonUsersManagement_SetRoleEmployee.TabIndex = 2;
            this.buttonUsersManagement_SetRoleEmployee.Text = "Сделать сотрудником";
            this.buttonUsersManagement_SetRoleEmployee.UseVisualStyleBackColor = true;
            this.buttonUsersManagement_SetRoleEmployee.Click += new System.EventHandler(this.buttonUsersManagement_SetRoleEmployee_Click);
            // 
            // listViewUsersManagement
            // 
            this.listViewUsersManagement.BackColor = System.Drawing.Color.AliceBlue;
            this.listViewUsersManagement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewUsersManagement.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderUsersManagement_SpaceColumn,
            this.columnHeaderUsersManagement_ID,
            this.columnHeaderUsersManagement_Username,
            this.columnHeaderUsersManagement_FullName,
            this.columnHeaderUsersManagement_Email,
            this.columnHeaderUsersManagement_PhoneNumber,
            this.columnHeaderUsersManagement_Role,
            this.columnHeaderUsersManagement_IsAccountSetupCompleted,
            this.columnHeaderUsersManagement_IsDeactivated});
            this.listViewUsersManagement.ContextMenuStrip = this.contextMenuStripListViewUsersManagement;
            this.listViewUsersManagement.FullRowSelect = true;
            this.listViewUsersManagement.GridLines = true;
            this.listViewUsersManagement.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewUsersManagement.HideSelection = false;
            this.listViewUsersManagement.Location = new System.Drawing.Point(6, 100);
            this.listViewUsersManagement.Name = "listViewUsersManagement";
            this.listViewUsersManagement.Size = new System.Drawing.Size(1790, 497);
            this.listViewUsersManagement.TabIndex = 4;
            this.listViewUsersManagement.UseCompatibleStateImageBehavior = false;
            this.listViewUsersManagement.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderUsersManagement_SpaceColumn
            // 
            this.columnHeaderUsersManagement_SpaceColumn.Text = "Space Column";
            this.columnHeaderUsersManagement_SpaceColumn.Width = 0;
            // 
            // columnHeaderUsersManagement_ID
            // 
            this.columnHeaderUsersManagement_ID.Text = "ID";
            this.columnHeaderUsersManagement_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderUsersManagement_ID.Width = 100;
            // 
            // columnHeaderUsersManagement_Username
            // 
            this.columnHeaderUsersManagement_Username.Text = "Имя пользователя";
            this.columnHeaderUsersManagement_Username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderUsersManagement_Username.Width = 240;
            // 
            // columnHeaderUsersManagement_FullName
            // 
            this.columnHeaderUsersManagement_FullName.Text = "Полное имя";
            this.columnHeaderUsersManagement_FullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderUsersManagement_FullName.Width = 260;
            // 
            // columnHeaderUsersManagement_Email
            // 
            this.columnHeaderUsersManagement_Email.Text = "Email";
            this.columnHeaderUsersManagement_Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderUsersManagement_Email.Width = 260;
            // 
            // columnHeaderUsersManagement_PhoneNumber
            // 
            this.columnHeaderUsersManagement_PhoneNumber.Text = "Номер телефона";
            this.columnHeaderUsersManagement_PhoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderUsersManagement_PhoneNumber.Width = 240;
            // 
            // columnHeaderUsersManagement_Role
            // 
            this.columnHeaderUsersManagement_Role.Text = "Роль";
            this.columnHeaderUsersManagement_Role.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderUsersManagement_Role.Width = 200;
            // 
            // columnHeaderUsersManagement_IsAccountSetupCompleted
            // 
            this.columnHeaderUsersManagement_IsAccountSetupCompleted.Text = "Аккаунт подтверждён?";
            this.columnHeaderUsersManagement_IsAccountSetupCompleted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderUsersManagement_IsAccountSetupCompleted.Width = 240;
            // 
            // columnHeaderUsersManagement_IsDeactivated
            // 
            this.columnHeaderUsersManagement_IsDeactivated.Text = "Аккаунт деактивирован?";
            this.columnHeaderUsersManagement_IsDeactivated.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderUsersManagement_IsDeactivated.Width = 240;
            // 
            // contextMenuStripListViewUsersManagement
            // 
            this.contextMenuStripListViewUsersManagement.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStripListViewUsersManagement.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripListViewUsersManagement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemListViewPayments_Copy,
            this.toolStripMenuItemListViewPayments_Copy_CardNumber,
            this.toolStripMenuItemListViewPayments_Copy_CreatedDate,
            this.toolStripMenuItemListViewPayments_Copy_Cost,
            this.toolStripMenuItemListViewPayments_Copy_IsFinished,
            this.toolStripMenuItemListViewPayments_Copy_IsCancelled});
            this.contextMenuStripListViewUsersManagement.Name = "contextMenuStripListView";
            this.contextMenuStripListViewUsersManagement.Size = new System.Drawing.Size(426, 196);
            // 
            // toolStripMenuItemListViewPayments_Copy
            // 
            this.toolStripMenuItemListViewPayments_Copy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemListViewPayments_Copy.Name = "toolStripMenuItemListViewPayments_Copy";
            this.toolStripMenuItemListViewPayments_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toolStripMenuItemListViewPayments_Copy.Size = new System.Drawing.Size(425, 32);
            this.toolStripMenuItemListViewPayments_Copy.Text = "Скопировать";
            this.toolStripMenuItemListViewPayments_Copy.Click += new System.EventHandler(this.toolStripMenuItemListView_Copy_Click);
            // 
            // toolStripMenuItemListViewPayments_Copy_CardNumber
            // 
            this.toolStripMenuItemListViewPayments_Copy_CardNumber.Name = "toolStripMenuItemListViewPayments_Copy_CardNumber";
            this.toolStripMenuItemListViewPayments_Copy_CardNumber.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.toolStripMenuItemListViewPayments_Copy_CardNumber.Size = new System.Drawing.Size(425, 32);
            this.toolStripMenuItemListViewPayments_Copy_CardNumber.Text = "Скопировать номер карты";
            this.toolStripMenuItemListViewPayments_Copy_CardNumber.Click += new System.EventHandler(this.toolStripMenuItemListView_Copy_CardNumber_Click);
            // 
            // toolStripMenuItemListViewPayments_Copy_CreatedDate
            // 
            this.toolStripMenuItemListViewPayments_Copy_CreatedDate.Name = "toolStripMenuItemListViewPayments_Copy_CreatedDate";
            this.toolStripMenuItemListViewPayments_Copy_CreatedDate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.toolStripMenuItemListViewPayments_Copy_CreatedDate.Size = new System.Drawing.Size(425, 32);
            this.toolStripMenuItemListViewPayments_Copy_CreatedDate.Text = "Скопировать время оплаты";
            this.toolStripMenuItemListViewPayments_Copy_CreatedDate.Click += new System.EventHandler(this.toolStripMenuItemListView_Copy_CreatedDate_Click);
            // 
            // toolStripMenuItemListViewPayments_Copy_Cost
            // 
            this.toolStripMenuItemListViewPayments_Copy_Cost.Name = "toolStripMenuItemListViewPayments_Copy_Cost";
            this.toolStripMenuItemListViewPayments_Copy_Cost.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.toolStripMenuItemListViewPayments_Copy_Cost.Size = new System.Drawing.Size(425, 32);
            this.toolStripMenuItemListViewPayments_Copy_Cost.Text = "Скопировать сумму оплаты";
            this.toolStripMenuItemListViewPayments_Copy_Cost.Click += new System.EventHandler(this.toolStripMenuItemListView_Copy_Cost_Click);
            // 
            // toolStripMenuItemListViewPayments_Copy_IsFinished
            // 
            this.toolStripMenuItemListViewPayments_Copy_IsFinished.Name = "toolStripMenuItemListViewPayments_Copy_IsFinished";
            this.toolStripMenuItemListViewPayments_Copy_IsFinished.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.toolStripMenuItemListViewPayments_Copy_IsFinished.Size = new System.Drawing.Size(425, 32);
            this.toolStripMenuItemListViewPayments_Copy_IsFinished.Text = "Скопировать \"Оплата прошла\"";
            this.toolStripMenuItemListViewPayments_Copy_IsFinished.Click += new System.EventHandler(this.toolStripMenuItemListView_Copy_IsFinished_Click);
            // 
            // toolStripMenuItemListViewPayments_Copy_IsCancelled
            // 
            this.toolStripMenuItemListViewPayments_Copy_IsCancelled.Name = "toolStripMenuItemListViewPayments_Copy_IsCancelled";
            this.toolStripMenuItemListViewPayments_Copy_IsCancelled.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.toolStripMenuItemListViewPayments_Copy_IsCancelled.Size = new System.Drawing.Size(425, 32);
            this.toolStripMenuItemListViewPayments_Copy_IsCancelled.Text = "Скопировать \"Оплата отменена\"";
            this.toolStripMenuItemListViewPayments_Copy_IsCancelled.Click += new System.EventHandler(this.toolStripMenuItemListView_Copy_IsCancelled_Click);
            // 
            // tabPageFinancialReport
            // 
            this.tabPageFinancialReport.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageFinancialReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageFinancialReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageFinancialReport.Controls.Add(this.labelFinancialReport_ClickThisNumberToCopyIt);
            this.tabPageFinancialReport.Controls.Add(this.labelFinancialReport_AvailableSalary);
            this.tabPageFinancialReport.Controls.Add(this.label26);
            this.tabPageFinancialReport.Controls.Add(this.labelFinancialReport_PotentionalSalary);
            this.tabPageFinancialReport.Controls.Add(this.label9);
            this.tabPageFinancialReport.Controls.Add(this.buttonFinancialReport_GetReports);
            this.tabPageFinancialReport.Controls.Add(this.label7);
            this.tabPageFinancialReport.Controls.Add(this.label6);
            this.tabPageFinancialReport.Controls.Add(this.dateTimePickerFinancialReport_ToDate);
            this.tabPageFinancialReport.Controls.Add(this.dateTimePickerFinancialReport_FromDate);
            this.tabPageFinancialReport.ImageKey = "moneybag.png";
            this.tabPageFinancialReport.Location = new System.Drawing.Point(4, 34);
            this.tabPageFinancialReport.Name = "tabPageFinancialReport";
            this.tabPageFinancialReport.Size = new System.Drawing.Size(1805, 606);
            this.tabPageFinancialReport.TabIndex = 4;
            this.tabPageFinancialReport.Text = "Финансовый отчёт ";
            this.tabPageFinancialReport.UseVisualStyleBackColor = true;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageSettings.Controls.Add(this.labelSettings_WholeCarsServicedByThisAdmin);
            this.tabPageSettings.Controls.Add(this.label1);
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
            // labelSettings_WholeCarsServicedByThisAdmin
            // 
            this.labelSettings_WholeCarsServicedByThisAdmin.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettings_WholeCarsServicedByThisAdmin.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelSettings_WholeCarsServicedByThisAdmin.Location = new System.Drawing.Point(759, 474);
            this.labelSettings_WholeCarsServicedByThisAdmin.Name = "labelSettings_WholeCarsServicedByThisAdmin";
            this.labelSettings_WholeCarsServicedByThisAdmin.Size = new System.Drawing.Size(253, 56);
            this.labelSettings_WholeCarsServicedByThisAdmin.TabIndex = 23;
            this.labelSettings_WholeCarsServicedByThisAdmin.Text = "0";
            this.labelSettings_WholeCarsServicedByThisAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(759, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 56);
            this.label1.TabIndex = 22;
            this.label1.Text = "Всего машин отправлено\r\nна обслуживание Вами:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(759, 236);
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
            this.textBoxSettings_NewPasswordConfirmation.Location = new System.Drawing.Point(733, 264);
            this.textBoxSettings_NewPasswordConfirmation.Name = "textBoxSettings_NewPasswordConfirmation";
            this.textBoxSettings_NewPasswordConfirmation.Size = new System.Drawing.Size(299, 31);
            this.textBoxSettings_NewPasswordConfirmation.TabIndex = 9;
            this.textBoxSettings_NewPasswordConfirmation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettings_NewPasswordConfirmation.UseSystemPasswordChar = true;
            this.textBoxSettings_NewPasswordConfirmation.TextChanged += new System.EventHandler(this.textBoxSettings_NewPasswordConfirmation_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(813, 147);
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
            this.textBoxSettings_NewPassword.Location = new System.Drawing.Point(733, 174);
            this.textBoxSettings_NewPassword.Name = "textBoxSettings_NewPassword";
            this.textBoxSettings_NewPassword.Size = new System.Drawing.Size(299, 31);
            this.textBoxSettings_NewPassword.TabIndex = 8;
            this.textBoxSettings_NewPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettings_NewPassword.UseSystemPasswordChar = true;
            this.textBoxSettings_NewPassword.TextChanged += new System.EventHandler(this.textBoxSettings_NewPassword_TextChanged);
            // 
            // buttonSettings_ChangePassword
            // 
            this.buttonSettings_ChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings_ChangePassword.Location = new System.Drawing.Point(800, 324);
            this.buttonSettings_ChangePassword.Name = "buttonSettings_ChangePassword";
            this.buttonSettings_ChangePassword.Size = new System.Drawing.Size(168, 47);
            this.buttonSettings_ChangePassword.TabIndex = 10;
            this.buttonSettings_ChangePassword.Text = "Сменить пароль";
            this.buttonSettings_ChangePassword.UseVisualStyleBackColor = true;
            this.buttonSettings_ChangePassword.Click += new System.EventHandler(this.buttonSettings_ChangePassword_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(808, 58);
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
            this.textBoxSettings_OldPassword.Location = new System.Drawing.Point(733, 86);
            this.textBoxSettings_OldPassword.Name = "textBoxSettings_OldPassword";
            this.textBoxSettings_OldPassword.Size = new System.Drawing.Size(299, 31);
            this.textBoxSettings_OldPassword.TabIndex = 7;
            this.textBoxSettings_OldPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettings_OldPassword.UseSystemPasswordChar = true;
            this.textBoxSettings_OldPassword.TextChanged += new System.EventHandler(this.textBoxSettings_OldPassword_TextChanged);
            // 
            // imageListTabControlAdmin
            // 
            this.imageListTabControlAdmin.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTabControlAdmin.ImageStream")));
            this.imageListTabControlAdmin.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTabControlAdmin.Images.SetKeyName(0, "OrderList.png");
            this.imageListTabControlAdmin.Images.SetKeyName(1, "car.png");
            this.imageListTabControlAdmin.Images.SetKeyName(2, "moneybag.png");
            this.imageListTabControlAdmin.Images.SetKeyName(3, "users.png");
            this.imageListTabControlAdmin.Images.SetKeyName(4, "Settings.png");
            // 
            // toolTipOrderListCarPicture
            // 
            this.toolTipOrderListCarPicture.AutomaticDelay = 250;
            this.toolTipOrderListCarPicture.AutoPopDelay = 5000;
            this.toolTipOrderListCarPicture.InitialDelay = 250;
            this.toolTipOrderListCarPicture.ReshowDelay = 50;
            this.toolTipOrderListCarPicture.ToolTipTitle = "Время окончания";
            // 
            // toolTipMakeServiceReport_PricePerHour
            // 
            this.toolTipMakeServiceReport_PricePerHour.AutomaticDelay = 250;
            this.toolTipMakeServiceReport_PricePerHour.AutoPopDelay = 5000;
            this.toolTipMakeServiceReport_PricePerHour.InitialDelay = 250;
            this.toolTipMakeServiceReport_PricePerHour.ReshowDelay = 50;
            this.toolTipMakeServiceReport_PricePerHour.ToolTipTitle = "Цена аренды автомобиля в час";
            // 
            // toolTipMakeServiceReport_ProductionYear
            // 
            this.toolTipMakeServiceReport_ProductionYear.AutomaticDelay = 250;
            this.toolTipMakeServiceReport_ProductionYear.AutoPopDelay = 5000;
            this.toolTipMakeServiceReport_ProductionYear.InitialDelay = 250;
            this.toolTipMakeServiceReport_ProductionYear.ReshowDelay = 50;
            this.toolTipMakeServiceReport_ProductionYear.ToolTipTitle = "Год производства автомобиля";
            // 
            // buttonUsersManagement_ActivateThisAccount
            // 
            this.buttonUsersManagement_ActivateThisAccount.Enabled = false;
            this.buttonUsersManagement_ActivateThisAccount.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonUsersManagement_ActivateThisAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUsersManagement_ActivateThisAccount.Location = new System.Drawing.Point(1548, 33);
            this.buttonUsersManagement_ActivateThisAccount.Name = "buttonUsersManagement_ActivateThisAccount";
            this.buttonUsersManagement_ActivateThisAccount.Size = new System.Drawing.Size(235, 47);
            this.buttonUsersManagement_ActivateThisAccount.TabIndex = 39;
            this.buttonUsersManagement_ActivateThisAccount.Text = "Активировать аккаунт";
            this.buttonUsersManagement_ActivateThisAccount.UseVisualStyleBackColor = true;
            this.buttonUsersManagement_ActivateThisAccount.Click += new System.EventHandler(this.buttonUsersManagement_ActivateThisAccount_Click);
            // 
            // dateTimePickerFinancialReport_FromDate
            // 
            this.dateTimePickerFinancialReport_FromDate.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dateTimePickerFinancialReport_FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFinancialReport_FromDate.Location = new System.Drawing.Point(581, 70);
            this.dateTimePickerFinancialReport_FromDate.Name = "dateTimePickerFinancialReport_FromDate";
            this.dateTimePickerFinancialReport_FromDate.Size = new System.Drawing.Size(218, 31);
            this.dateTimePickerFinancialReport_FromDate.TabIndex = 0;
            // 
            // dateTimePickerFinancialReport_ToDate
            // 
            this.dateTimePickerFinancialReport_ToDate.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dateTimePickerFinancialReport_ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFinancialReport_ToDate.Location = new System.Drawing.Point(901, 70);
            this.dateTimePickerFinancialReport_ToDate.Name = "dateTimePickerFinancialReport_ToDate";
            this.dateTimePickerFinancialReport_ToDate.Size = new System.Drawing.Size(218, 31);
            this.dateTimePickerFinancialReport_ToDate.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(624, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "С этой даты: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(939, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 25);
            this.label7.TabIndex = 19;
            this.label7.Text = "И до этой даты: ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonFinancialReport_GetReports
            // 
            this.buttonFinancialReport_GetReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFinancialReport_GetReports.Location = new System.Drawing.Point(739, 139);
            this.buttonFinancialReport_GetReports.Name = "buttonFinancialReport_GetReports";
            this.buttonFinancialReport_GetReports.Size = new System.Drawing.Size(223, 67);
            this.buttonFinancialReport_GetReports.TabIndex = 20;
            this.buttonFinancialReport_GetReports.Text = "Получить финансовый\r\nотчёт по датам";
            this.buttonFinancialReport_GetReports.UseVisualStyleBackColor = true;
            this.buttonFinancialReport_GetReports.Click += new System.EventHandler(this.buttonFinancialReport_GetReports_Click);
            // 
            // labelFinancialReport_PotentionalSalary
            // 
            this.labelFinancialReport_PotentionalSalary.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFinancialReport_PotentionalSalary.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelFinancialReport_PotentionalSalary.Location = new System.Drawing.Point(892, 273);
            this.labelFinancialReport_PotentionalSalary.Name = "labelFinancialReport_PotentionalSalary";
            this.labelFinancialReport_PotentionalSalary.Size = new System.Drawing.Size(253, 56);
            this.labelFinancialReport_PotentionalSalary.TabIndex = 25;
            this.labelFinancialReport_PotentionalSalary.Text = "0";
            this.labelFinancialReport_PotentionalSalary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelFinancialReport_PotentionalSalary.Click += new System.EventHandler(this.labelFinancialReport_PotentionalSalary_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(543, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(296, 140);
            this.label9.TabIndex = 24;
            this.label9.Text = "Потенциальный доход\r\nпо выбранным датам\r\n(учитывая автомобили\r\nна обслуживании, \r" +
    "\nкоторые не закончены пока):";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFinancialReport_AvailableSalary
            // 
            this.labelFinancialReport_AvailableSalary.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFinancialReport_AvailableSalary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelFinancialReport_AvailableSalary.Location = new System.Drawing.Point(892, 435);
            this.labelFinancialReport_AvailableSalary.Name = "labelFinancialReport_AvailableSalary";
            this.labelFinancialReport_AvailableSalary.Size = new System.Drawing.Size(253, 56);
            this.labelFinancialReport_AvailableSalary.TabIndex = 27;
            this.labelFinancialReport_AvailableSalary.Text = "0";
            this.labelFinancialReport_AvailableSalary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelFinancialReport_AvailableSalary.Click += new System.EventHandler(this.labelFinancialReport_AvailableSalary_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(581, 428);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(218, 84);
            this.label26.TabIndex = 26;
            this.label26.Text = "Доступный доход\r\nпо выбранным датам\r\n(без обслуживания):";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolTipUsersManagement_FindInTheTable
            // 
            this.toolTipUsersManagement_FindInTheTable.AutomaticDelay = 250;
            this.toolTipUsersManagement_FindInTheTable.AutoPopDelay = 5000;
            this.toolTipUsersManagement_FindInTheTable.InitialDelay = 250;
            this.toolTipUsersManagement_FindInTheTable.ReshowDelay = 50;
            this.toolTipUsersManagement_FindInTheTable.ToolTipTitle = "Поиск по таблице";
            // 
            // toolTipSettings_Password
            // 
            this.toolTipSettings_Password.AutomaticDelay = 250;
            this.toolTipSettings_Password.AutoPopDelay = 5000;
            this.toolTipSettings_Password.InitialDelay = 250;
            this.toolTipSettings_Password.ReshowDelay = 50;
            this.toolTipSettings_Password.ToolTipTitle = "Ваш текущий пароль";
            // 
            // toolTipMakeServiceReport_HideOrShowCar
            // 
            this.toolTipMakeServiceReport_HideOrShowCar.AutomaticDelay = 250;
            this.toolTipMakeServiceReport_HideOrShowCar.AutoPopDelay = 5000;
            this.toolTipMakeServiceReport_HideOrShowCar.InitialDelay = 250;
            this.toolTipMakeServiceReport_HideOrShowCar.ReshowDelay = 50;
            this.toolTipMakeServiceReport_HideOrShowCar.ToolTipTitle = "Спрятать или показать автомобиль";
            // 
            // labelFinancialReport_ClickThisNumberToCopyIt
            // 
            this.labelFinancialReport_ClickThisNumberToCopyIt.AutoSize = true;
            this.labelFinancialReport_ClickThisNumberToCopyIt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelFinancialReport_ClickThisNumberToCopyIt.Location = new System.Drawing.Point(681, 540);
            this.labelFinancialReport_ClickThisNumberToCopyIt.Name = "labelFinancialReport_ClickThisNumberToCopyIt";
            this.labelFinancialReport_ClickThisNumberToCopyIt.Size = new System.Drawing.Size(380, 25);
            this.labelFinancialReport_ClickThisNumberToCopyIt.TabIndex = 28;
            this.labelFinancialReport_ClickThisNumberToCopyIt.Text = "Нажмите на число, чтобы его скопировать";
            this.labelFinancialReport_ClickThisNumberToCopyIt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1813, 644);
            this.Controls.Add(this.tabControlAdmin);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarSharingBY - администратор";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.tabControlAdmin.ResumeLayout(false);
            this.tabPageServiceReportList.ResumeLayout(false);
            this.tabPageServiceReportList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServiceReportList_CarPicture)).EndInit();
            this.contextMenuStripListViewServiceReportList.ResumeLayout(false);
            this.tabPageMakeOrder.ResumeLayout(false);
            this.tabPageMakeOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMakeServiceReport_AddNewCarPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMakeServiceReport_CarPicture)).EndInit();
            this.contextMenuStripListViewMakeServiceReport.ResumeLayout(false);
            this.tabPageUsersManagement.ResumeLayout(false);
            this.tabPageUsersManagement.PerformLayout();
            this.contextMenuStripListViewUsersManagement.ResumeLayout(false);
            this.tabPageFinancialReport.ResumeLayout(false);
            this.tabPageFinancialReport.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlAdmin;
        private System.Windows.Forms.TabPage tabPageServiceReportList;
        private System.Windows.Forms.TabPage tabPageUsersManagement;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageMakeOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSettings_NewPasswordConfirmation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSettings_NewPassword;
        private System.Windows.Forms.Button buttonSettings_ChangePassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSettings_OldPassword;
        private System.Windows.Forms.ListView listViewUsersManagement;
        private System.Windows.Forms.ColumnHeader columnHeaderUsersManagement_Username;
        private System.Windows.Forms.ColumnHeader columnHeaderUsersManagement_FullName;
        private System.Windows.Forms.ColumnHeader columnHeaderUsersManagement_Email;
        private System.Windows.Forms.ColumnHeader columnHeaderUsersManagement_PhoneNumber;
        private System.Windows.Forms.Button buttonUsersManagement_SetRoleEmployee;
        private System.Windows.Forms.ColumnHeader columnHeaderUsersManagement_ID;
        private System.Windows.Forms.ColumnHeader columnHeaderUsersManagement_SpaceColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListViewUsersManagement;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewPayments_Copy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewPayments_Copy_CardNumber;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewPayments_Copy_CreatedDate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewPayments_Copy_Cost;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewPayments_Copy_IsFinished;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewPayments_Copy_IsCancelled;
        private System.Windows.Forms.ImageList imageListTabControlAdmin;
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
        private System.Windows.Forms.Label labelMakeServiceReport_CarOrderInfo;
        private System.Windows.Forms.PictureBox pictureBoxMakeServiceReport_CarPicture;
        private System.Windows.Forms.Button buttonMakeServiceReport_SendToService;
        private System.Windows.Forms.ListView listViewMakeServiceReport;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeServiceReport_SpaceColumn;
        private System.Windows.Forms.TextBox textBoxMakeMakeServiceReport_Description;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeServiceReport_ID;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeServiceReport_Brand;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeServiceReport_Model;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeServiceReport_CarLicensePlate;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeServiceReport_PricePerHour;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeServiceReport_ProductionYear;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeServiceReport_BuyTime;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeServiceReport_LastServiceTime;
        private System.Windows.Forms.Button buttonMakeServiceReport_OpenCarLocationMap;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeServiceReport_IsNowOnService;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListViewMakeServiceReport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewMakeServiceReport_Copy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewMakeServiceReport_Copy_ID;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewMakeServiceReport_Copy_Status;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewMakeServiceReport_Copy_CarBrand;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewMakeServiceReport_Copy_CarModel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewMakeServiceReport_Copy_CarLicensePlate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewMakeServiceReport_Copy_CarPricePerHour;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewMakeServiceReport_Copy_CarProductionYear;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewMakeServiceReport_Copy_CarBuyTime;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewMakeServiceReport_Copy_CarLastServiceDate;
        private System.Windows.Forms.Button buttonMakeServiceReport_AddNewCar;
        private System.Windows.Forms.ColumnHeader columnHeaderUsersManagement_Role;
        private System.Windows.Forms.ColumnHeader columnHeaderUsersManagement_IsAccountSetupCompleted;
        private System.Windows.Forms.ColumnHeader columnHeaderUsersManagement_IsDeactivated;
        private System.Windows.Forms.Label labelSpliter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxMakeMakeServiceReport_NewCarLicensePlate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxMakeMakeServiceReport_NewCarPricePerHour;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxMakeMakeServiceReport_NewCarProductionYear;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxMakeMakeServiceReport_NewCarModel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBoxMakeMakeServiceReport_NewCarBrand;
        private System.Windows.Forms.PictureBox pictureBoxMakeServiceReport_AddNewCarPicture;
        private System.Windows.Forms.Label labelClickThisToAddNewCarImage;
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
        private System.Windows.Forms.ToolTip toolTipMakeServiceReport_PricePerHour;
        private System.Windows.Forms.ToolTip toolTipMakeServiceReport_ProductionYear;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeServiceReport_IsHidden;
        private System.Windows.Forms.Button buttonMakeServiceReport_HideShowCar;
        private System.Windows.Forms.Label labelSettings_WholeCarsServicedByThisAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageFinancialReport;
        private System.Windows.Forms.Button buttonUsersManagement_DeactivateThisAccount;
        private System.Windows.Forms.Button buttonUsersManagement_SetRoleClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUsersManagement_FindInTheTable;
        private System.Windows.Forms.Button buttonUsersManagement_ActivateThisAccount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinancialReport_ToDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinancialReport_FromDate;
        private System.Windows.Forms.Button buttonFinancialReport_GetReports;
        private System.Windows.Forms.Label labelFinancialReport_AvailableSalary;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label labelFinancialReport_PotentionalSalary;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolTip toolTipUsersManagement_FindInTheTable;
        private System.Windows.Forms.ToolTip toolTipSettings_Password;
        private System.Windows.Forms.ToolTip toolTipMakeServiceReport_HideOrShowCar;
        private System.Windows.Forms.Label labelFinancialReport_ClickThisNumberToCopyIt;
    }
}

