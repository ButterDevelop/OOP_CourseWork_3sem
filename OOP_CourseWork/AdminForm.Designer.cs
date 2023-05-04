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
            this.columnHeaderServiceReportList_Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_StartedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_FinishedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_FullCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_PlannedCompletionDays = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_IsStarted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_IsFinished = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_AdditionalCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_EmployeeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_CostPerDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceReportList_ReportString = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.tabPageMakeOrder = new System.Windows.Forms.TabPage();
            this.buttonMakeServiceReport_OpenCarLocationMap = new System.Windows.Forms.Button();
            this.textBoxMakeMakeServiceReport_Description = new System.Windows.Forms.TextBox();
            this.labelMakeServiceReport_CarOrderInfo = new System.Windows.Forms.Label();
            this.pictureBoxMakeServiceReport_CarPicture = new System.Windows.Forms.PictureBox();
            this.buttonMakeServiceReport_SendToService = new System.Windows.Forms.Button();
            this.listViewMakeServiceReport = new System.Windows.Forms.ListView();
            this.columnHeaderMakeServiceReport_SpaceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_IsNowOnService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_Brand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_CarLicensePlate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_PricePerHour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_ProductionYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_BuyTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeServiceReport_LastServiceTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripListViewServiceReportList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemListViewOrderList_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_ID = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_Description = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_Cost = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_EmployeeName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewServiceReportList_Copy_EmployeeReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPagePayments = new System.Windows.Forms.TabPage();
            this.buttonPayments_CreatePayment = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxPayments_Cost = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPayments_SecretCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPayment_CardNumber = new System.Windows.Forms.TextBox();
            this.listViewPayments = new System.Windows.Forms.ListView();
            this.columnHeaderPayment_SpaceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPayment_CardNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPayment_CreatedTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPayment_Cost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPayment_IsFinished = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPayment_IsCancelled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripListViewPayments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemListViewPayments_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewPayments_Copy_CardNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewPayments_Copy_CreatedDate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewPayments_Copy_Cost = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewPayments_Copy_IsFinished = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewPayments_Copy_IsCancelled = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.textBoxSettings_Password = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSettings_DriverLicense = new System.Windows.Forms.TextBox();
            this.maskedTextBoxSettings_PhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.labelSpliter = new System.Windows.Forms.Label();
            this.labelSettings_AccountSetupIsCompletedFine = new System.Windows.Forms.Label();
            this.labelSettings_AccountSetupIsNotCompleted = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSettings_NewPasswordConfirmation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSettings_NewPassword = new System.Windows.Forms.TextBox();
            this.buttonSettings_ChangePassword = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSettings_OldPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxSettings_Email = new System.Windows.Forms.TextBox();
            this.buttonSettings_DeactivateMyAccount = new System.Windows.Forms.Button();
            this.buttonSettings_Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSettings_CardNumber = new System.Windows.Forms.TextBox();
            this.labelPassport = new System.Windows.Forms.Label();
            this.textBoxSettings_Passport = new System.Windows.Forms.TextBox();
            this.labelDriverLicense = new System.Windows.Forms.Label();
            this.imageListTabControlClient = new System.Windows.Forms.ImageList(this.components);
            this.toolTipEmail = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPhoneNumber = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipCardNumber = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPassword = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSecretCode = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipCost = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipOrderHours = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipOrderBookingDateTime = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipOrderBookingEndDateTime = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipOrderListCarPicture = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlAdmin.SuspendLayout();
            this.tabPageServiceReportList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServiceReportList_CarPicture)).BeginInit();
            this.contextMenuStripListViewMakeServiceReport.SuspendLayout();
            this.tabPageMakeOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMakeServiceReport_CarPicture)).BeginInit();
            this.contextMenuStripListViewServiceReportList.SuspendLayout();
            this.tabPagePayments.SuspendLayout();
            this.contextMenuStripListViewPayments.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlAdmin
            // 
            this.tabControlAdmin.Controls.Add(this.tabPageServiceReportList);
            this.tabControlAdmin.Controls.Add(this.tabPageMakeOrder);
            this.tabControlAdmin.Controls.Add(this.tabPagePayments);
            this.tabControlAdmin.Controls.Add(this.tabPageSettings);
            this.tabControlAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAdmin.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlAdmin.ImageList = this.imageListTabControlClient;
            this.tabControlAdmin.Location = new System.Drawing.Point(0, 0);
            this.tabControlAdmin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControlAdmin.Multiline = true;
            this.tabControlAdmin.Name = "tabControlAdmin";
            this.tabControlAdmin.SelectedIndex = 0;
            this.tabControlAdmin.Size = new System.Drawing.Size(978, 644);
            this.tabControlAdmin.TabIndex = 0;
            // 
            // tabPageServiceReportList
            // 
            this.tabPageServiceReportList.BackColor = System.Drawing.Color.Transparent;
            this.tabPageServiceReportList.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageServiceReportList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPageServiceReportList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.tabPageServiceReportList.Size = new System.Drawing.Size(970, 606);
            this.tabPageServiceReportList.TabIndex = 0;
            this.tabPageServiceReportList.Text = "Сервисные отчёты ";
            this.tabPageServiceReportList.UseVisualStyleBackColor = true;
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
            this.textBoxServiceReportList_LastServiceDate.TabIndex = 19;
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
            this.textBoxServiceReportList_CarLicensePlate.TabIndex = 17;
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
            this.textBoxServiceReportList_PricePerHour.TabIndex = 15;
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
            this.textBoxServiceReportList_ProductionYear.TabIndex = 13;
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
            this.textBoxServiceReportList_CarModel.TabIndex = 11;
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
            this.textBoxServiceReportList_CarBrand.TabIndex = 8;
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
            this.columnHeaderServiceReportList_Description,
            this.columnHeaderServiceReportList_StartedDate,
            this.columnHeaderServiceReportList_FinishedDate,
            this.columnHeaderServiceReportList_FullCost,
            this.columnHeaderServiceReportList_PlannedCompletionDays,
            this.columnHeaderServiceReportList_IsStarted,
            this.columnHeaderServiceReportList_IsFinished,
            this.columnHeaderServiceReportList_AdditionalCost,
            this.columnHeaderServiceReportList_EmployeeName,
            this.columnHeaderServiceReportList_CostPerDay,
            this.columnHeaderServiceReportList_ReportString});
            this.listViewServiceReportList.ContextMenuStrip = this.contextMenuStripListViewMakeServiceReport;
            this.listViewServiceReportList.FullRowSelect = true;
            this.listViewServiceReportList.GridLines = true;
            this.listViewServiceReportList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewServiceReportList.HideSelection = false;
            this.listViewServiceReportList.Location = new System.Drawing.Point(7, 253);
            this.listViewServiceReportList.Name = "listViewServiceReportList";
            this.listViewServiceReportList.Size = new System.Drawing.Size(955, 344);
            this.listViewServiceReportList.TabIndex = 5;
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
            this.columnHeaderServiceReportList_ID.Text = "№";
            this.columnHeaderServiceReportList_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeaderServiceReportList_Description
            // 
            this.columnHeaderServiceReportList_Description.Text = "Описание";
            this.columnHeaderServiceReportList_Description.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_Description.Width = 210;
            // 
            // columnHeaderServiceReportList_StartedDate
            // 
            this.columnHeaderServiceReportList_StartedDate.Text = "Начало";
            this.columnHeaderServiceReportList_StartedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_StartedDate.Width = 180;
            // 
            // columnHeaderServiceReportList_FinishedDate
            // 
            this.columnHeaderServiceReportList_FinishedDate.Text = "Окончание";
            this.columnHeaderServiceReportList_FinishedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_FinishedDate.Width = 180;
            // 
            // columnHeaderServiceReportList_FullCost
            // 
            this.columnHeaderServiceReportList_FullCost.Text = "Вся цена";
            this.columnHeaderServiceReportList_FullCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_FullCost.Width = 150;
            // 
            // columnHeaderServiceReportList_PlannedCompletionDays
            // 
            this.columnHeaderServiceReportList_PlannedCompletionDays.Text = "Срок (дни)";
            this.columnHeaderServiceReportList_PlannedCompletionDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_PlannedCompletionDays.Width = 120;
            // 
            // columnHeaderServiceReportList_IsStarted
            // 
            this.columnHeaderServiceReportList_IsStarted.Text = "Начато";
            this.columnHeaderServiceReportList_IsStarted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_IsStarted.Width = 100;
            // 
            // columnHeaderServiceReportList_IsFinished
            // 
            this.columnHeaderServiceReportList_IsFinished.Text = "Закончено";
            this.columnHeaderServiceReportList_IsFinished.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_IsFinished.Width = 100;
            // 
            // columnHeaderServiceReportList_AdditionalCost
            // 
            this.columnHeaderServiceReportList_AdditionalCost.Text = "Доп. цена";
            this.columnHeaderServiceReportList_AdditionalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_AdditionalCost.Width = 150;
            // 
            // columnHeaderServiceReportList_EmployeeName
            // 
            this.columnHeaderServiceReportList_EmployeeName.Text = "Работник";
            this.columnHeaderServiceReportList_EmployeeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_EmployeeName.Width = 180;
            // 
            // columnHeaderServiceReportList_CostPerDay
            // 
            this.columnHeaderServiceReportList_CostPerDay.Text = "Цена в день";
            this.columnHeaderServiceReportList_CostPerDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_CostPerDay.Width = 150;
            // 
            // columnHeaderServiceReportList_ReportString
            // 
            this.columnHeaderServiceReportList_ReportString.Text = "Отчёт работника";
            this.columnHeaderServiceReportList_ReportString.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderServiceReportList_ReportString.Width = 200;
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
            this.toolStripMenuItemListViewMakeServiceReport_Copy_ID.Text = "Скопировать номер автомобиля";
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
            // tabPageMakeOrder
            // 
            this.tabPageMakeOrder.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageMakeOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageMakeOrder.Controls.Add(this.buttonMakeServiceReport_OpenCarLocationMap);
            this.tabPageMakeOrder.Controls.Add(this.textBoxMakeMakeServiceReport_Description);
            this.tabPageMakeOrder.Controls.Add(this.labelMakeServiceReport_CarOrderInfo);
            this.tabPageMakeOrder.Controls.Add(this.pictureBoxMakeServiceReport_CarPicture);
            this.tabPageMakeOrder.Controls.Add(this.buttonMakeServiceReport_SendToService);
            this.tabPageMakeOrder.Controls.Add(this.listViewMakeServiceReport);
            this.tabPageMakeOrder.ImageKey = "MakeAnOrder.png";
            this.tabPageMakeOrder.Location = new System.Drawing.Point(4, 34);
            this.tabPageMakeOrder.Name = "tabPageMakeOrder";
            this.tabPageMakeOrder.Size = new System.Drawing.Size(970, 606);
            this.tabPageMakeOrder.TabIndex = 3;
            this.tabPageMakeOrder.Text = "Авто и сервис ";
            this.tabPageMakeOrder.UseVisualStyleBackColor = true;
            // 
            // buttonMakeServiceReport_OpenCarLocationMap
            // 
            this.buttonMakeServiceReport_OpenCarLocationMap.Enabled = false;
            this.buttonMakeServiceReport_OpenCarLocationMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMakeServiceReport_OpenCarLocationMap.Location = new System.Drawing.Point(389, 197);
            this.buttonMakeServiceReport_OpenCarLocationMap.Name = "buttonMakeServiceReport_OpenCarLocationMap";
            this.buttonMakeServiceReport_OpenCarLocationMap.Size = new System.Drawing.Size(175, 40);
            this.buttonMakeServiceReport_OpenCarLocationMap.TabIndex = 31;
            this.buttonMakeServiceReport_OpenCarLocationMap.Text = "Местоположение";
            this.buttonMakeServiceReport_OpenCarLocationMap.UseVisualStyleBackColor = true;
            this.buttonMakeServiceReport_OpenCarLocationMap.Click += new System.EventHandler(this.buttonMakeServiceReport_OpenCarLocationMap_Click);
            // 
            // textBoxMakeMakeServiceReport_Description
            // 
            this.textBoxMakeMakeServiceReport_Description.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxMakeMakeServiceReport_Description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMakeMakeServiceReport_Description.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMakeMakeServiceReport_Description.Location = new System.Drawing.Point(389, 57);
            this.textBoxMakeMakeServiceReport_Description.Multiline = true;
            this.textBoxMakeMakeServiceReport_Description.Name = "textBoxMakeMakeServiceReport_Description";
            this.textBoxMakeMakeServiceReport_Description.Size = new System.Drawing.Size(559, 124);
            this.textBoxMakeMakeServiceReport_Description.TabIndex = 30;
            this.textBoxMakeMakeServiceReport_Description.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelMakeServiceReport_CarOrderInfo
            // 
            this.labelMakeServiceReport_CarOrderInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMakeServiceReport_CarOrderInfo.Location = new System.Drawing.Point(374, 14);
            this.labelMakeServiceReport_CarOrderInfo.Name = "labelMakeServiceReport_CarOrderInfo";
            this.labelMakeServiceReport_CarOrderInfo.Size = new System.Drawing.Size(588, 25);
            this.labelMakeServiceReport_CarOrderInfo.TabIndex = 28;
            this.labelMakeServiceReport_CarOrderInfo.Text = "Причина отправки автомобиля на обслуживание:";
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
            this.buttonMakeServiceReport_SendToService.Location = new System.Drawing.Point(679, 197);
            this.buttonMakeServiceReport_SendToService.Name = "buttonMakeServiceReport_SendToService";
            this.buttonMakeServiceReport_SendToService.Size = new System.Drawing.Size(269, 40);
            this.buttonMakeServiceReport_SendToService.TabIndex = 24;
            this.buttonMakeServiceReport_SendToService.Text = "Отправить на обслуживание";
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
            this.columnHeaderMakeServiceReport_IsNowOnService,
            this.columnHeaderMakeServiceReport_Brand,
            this.columnHeaderMakeServiceReport_Model,
            this.columnHeaderMakeServiceReport_CarLicensePlate,
            this.columnHeaderMakeServiceReport_PricePerHour,
            this.columnHeaderMakeServiceReport_ProductionYear,
            this.columnHeaderMakeServiceReport_BuyTime,
            this.columnHeaderMakeServiceReport_LastServiceTime});
            this.listViewMakeServiceReport.ContextMenuStrip = this.contextMenuStripListViewServiceReportList;
            this.listViewMakeServiceReport.FullRowSelect = true;
            this.listViewMakeServiceReport.GridLines = true;
            this.listViewMakeServiceReport.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewMakeServiceReport.HideSelection = false;
            this.listViewMakeServiceReport.Location = new System.Drawing.Point(7, 253);
            this.listViewMakeServiceReport.Name = "listViewMakeServiceReport";
            this.listViewMakeServiceReport.Size = new System.Drawing.Size(955, 344);
            this.listViewMakeServiceReport.TabIndex = 23;
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
            this.columnHeaderMakeServiceReport_ID.Text = "№";
            this.columnHeaderMakeServiceReport_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.columnHeaderMakeServiceReport_Brand.Width = 200;
            // 
            // columnHeaderMakeServiceReport_Model
            // 
            this.columnHeaderMakeServiceReport_Model.Text = "Модель автомобиля";
            this.columnHeaderMakeServiceReport_Model.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_Model.Width = 200;
            // 
            // columnHeaderMakeServiceReport_CarLicensePlate
            // 
            this.columnHeaderMakeServiceReport_CarLicensePlate.Text = "Номерной знак";
            this.columnHeaderMakeServiceReport_CarLicensePlate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_CarLicensePlate.Width = 160;
            // 
            // columnHeaderMakeServiceReport_PricePerHour
            // 
            this.columnHeaderMakeServiceReport_PricePerHour.Text = "Цена в час";
            this.columnHeaderMakeServiceReport_PricePerHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_PricePerHour.Width = 150;
            // 
            // columnHeaderMakeServiceReport_ProductionYear
            // 
            this.columnHeaderMakeServiceReport_ProductionYear.Text = "Год произв.";
            this.columnHeaderMakeServiceReport_ProductionYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_ProductionYear.Width = 120;
            // 
            // columnHeaderMakeServiceReport_BuyTime
            // 
            this.columnHeaderMakeServiceReport_BuyTime.Text = "Дата покупки";
            this.columnHeaderMakeServiceReport_BuyTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_BuyTime.Width = 180;
            // 
            // columnHeaderMakeServiceReport_LastServiceTime
            // 
            this.columnHeaderMakeServiceReport_LastServiceTime.Text = "Последнее обслуж.";
            this.columnHeaderMakeServiceReport_LastServiceTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMakeServiceReport_LastServiceTime.Width = 180;
            // 
            // contextMenuStripListViewServiceReportList
            // 
            this.contextMenuStripListViewServiceReportList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStripListViewServiceReportList.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripListViewServiceReportList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemListViewOrderList_Copy,
            this.toolStripMenuItemListViewServiceReportList_Copy_ID,
            this.toolStripMenuItemListViewServiceReportList_Copy_Description,
            this.toolStripMenuItemListViewServiceReportList_Copy_Cost,
            this.toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost,
            this.toolStripMenuItemListViewServiceReportList_Copy_EmployeeName,
            this.toolStripMenuItemListViewServiceReportList_Copy_EmployeeReport});
            this.contextMenuStripListViewServiceReportList.Name = "contextMenuStripListView";
            this.contextMenuStripListViewServiceReportList.Size = new System.Drawing.Size(406, 228);
            // 
            // toolStripMenuItemListViewOrderList_Copy
            // 
            this.toolStripMenuItemListViewOrderList_Copy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemListViewOrderList_Copy.Name = "toolStripMenuItemListViewOrderList_Copy";
            this.toolStripMenuItemListViewOrderList_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toolStripMenuItemListViewOrderList_Copy.Size = new System.Drawing.Size(405, 32);
            this.toolStripMenuItemListViewOrderList_Copy.Text = "Скопировать";
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_ID
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_ID.Name = "toolStripMenuItemListViewServiceReportList_Copy_ID";
            this.toolStripMenuItemListViewServiceReportList_Copy_ID.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.toolStripMenuItemListViewServiceReportList_Copy_ID.Size = new System.Drawing.Size(405, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_ID.Text = "Скопировать номер отчёта";
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_Description
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_Description.Name = "toolStripMenuItemListViewServiceReportList_Copy_Description";
            this.toolStripMenuItemListViewServiceReportList_Copy_Description.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.toolStripMenuItemListViewServiceReportList_Copy_Description.Size = new System.Drawing.Size(405, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_Description.Text = "Скопировать описание";
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_Cost
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_Cost.Name = "toolStripMenuItemListViewServiceReportList_Copy_Cost";
            this.toolStripMenuItemListViewServiceReportList_Copy_Cost.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.toolStripMenuItemListViewServiceReportList_Copy_Cost.Size = new System.Drawing.Size(405, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_Cost.Text = "Скопировать всю цену";
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost.Name = "toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost";
            this.toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost.Size = new System.Drawing.Size(405, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost.Text = "Скопировать доп. цену";
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_EmployeeName
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_EmployeeName.Name = "toolStripMenuItemListViewServiceReportList_Copy_EmployeeName";
            this.toolStripMenuItemListViewServiceReportList_Copy_EmployeeName.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.toolStripMenuItemListViewServiceReportList_Copy_EmployeeName.Size = new System.Drawing.Size(405, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_EmployeeName.Text = "Скопировать имя работника";
            // 
            // toolStripMenuItemListViewServiceReportList_Copy_EmployeeReport
            // 
            this.toolStripMenuItemListViewServiceReportList_Copy_EmployeeReport.Name = "toolStripMenuItemListViewServiceReportList_Copy_EmployeeReport";
            this.toolStripMenuItemListViewServiceReportList_Copy_EmployeeReport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D6)));
            this.toolStripMenuItemListViewServiceReportList_Copy_EmployeeReport.Size = new System.Drawing.Size(405, 32);
            this.toolStripMenuItemListViewServiceReportList_Copy_EmployeeReport.Text = "Скопировать отчёт работника";
            // 
            // tabPagePayments
            // 
            this.tabPagePayments.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPagePayments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPagePayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPagePayments.Controls.Add(this.buttonPayments_CreatePayment);
            this.tabPagePayments.Controls.Add(this.label9);
            this.tabPagePayments.Controls.Add(this.textBoxPayments_Cost);
            this.tabPagePayments.Controls.Add(this.label8);
            this.tabPagePayments.Controls.Add(this.textBoxPayments_SecretCode);
            this.tabPagePayments.Controls.Add(this.label7);
            this.tabPagePayments.Controls.Add(this.textBoxPayment_CardNumber);
            this.tabPagePayments.Controls.Add(this.listViewPayments);
            this.tabPagePayments.ImageKey = "BalanceTopUp.png";
            this.tabPagePayments.Location = new System.Drawing.Point(4, 34);
            this.tabPagePayments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPagePayments.Name = "tabPagePayments";
            this.tabPagePayments.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPagePayments.Size = new System.Drawing.Size(970, 606);
            this.tabPagePayments.TabIndex = 1;
            this.tabPagePayments.Text = "Пополнение баланса ";
            this.tabPagePayments.UseVisualStyleBackColor = true;
            // 
            // buttonPayments_CreatePayment
            // 
            this.buttonPayments_CreatePayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPayments_CreatePayment.Location = new System.Drawing.Point(783, 33);
            this.buttonPayments_CreatePayment.Name = "buttonPayments_CreatePayment";
            this.buttonPayments_CreatePayment.Size = new System.Drawing.Size(147, 47);
            this.buttonPayments_CreatePayment.TabIndex = 3;
            this.buttonPayments_CreatePayment.Text = "Пополнить";
            this.buttonPayments_CreatePayment.UseVisualStyleBackColor = true;
            this.buttonPayments_CreatePayment.Click += new System.EventHandler(this.buttonPayments_CreatePayment_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(623, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 25);
            this.label9.TabIndex = 6;
            this.label9.Text = "Сумма: ";
            // 
            // textBoxPayments_Cost
            // 
            this.textBoxPayments_Cost.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxPayments_Cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPayments_Cost.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPayments_Cost.Location = new System.Drawing.Point(574, 42);
            this.textBoxPayments_Cost.Name = "textBoxPayments_Cost";
            this.textBoxPayments_Cost.Size = new System.Drawing.Size(175, 31);
            this.textBoxPayments_Cost.TabIndex = 2;
            this.textBoxPayments_Cost.Text = "100.00";
            this.textBoxPayments_Cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPayments_Cost.TextChanged += new System.EventHandler(this.textBoxPayments_Cost_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(379, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 25);
            this.label8.TabIndex = 4;
            this.label8.Text = "Секретный код: ";
            // 
            // textBoxPayments_SecretCode
            // 
            this.textBoxPayments_SecretCode.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxPayments_SecretCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPayments_SecretCode.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPayments_SecretCode.Location = new System.Drawing.Point(366, 42);
            this.textBoxPayments_SecretCode.Name = "textBoxPayments_SecretCode";
            this.textBoxPayments_SecretCode.Size = new System.Drawing.Size(175, 31);
            this.textBoxPayments_SecretCode.TabIndex = 1;
            this.textBoxPayments_SecretCode.Text = "000";
            this.textBoxPayments_SecretCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPayments_SecretCode.TextChanged += new System.EventHandler(this.textBoxPayments_SecretCode_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "Номер карты: ";
            // 
            // textBoxPayment_CardNumber
            // 
            this.textBoxPayment_CardNumber.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxPayment_CardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPayment_CardNumber.Enabled = false;
            this.textBoxPayment_CardNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPayment_CardNumber.Location = new System.Drawing.Point(34, 42);
            this.textBoxPayment_CardNumber.Name = "textBoxPayment_CardNumber";
            this.textBoxPayment_CardNumber.ReadOnly = true;
            this.textBoxPayment_CardNumber.Size = new System.Drawing.Size(300, 31);
            this.textBoxPayment_CardNumber.TabIndex = 0;
            this.textBoxPayment_CardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listViewPayments
            // 
            this.listViewPayments.BackColor = System.Drawing.Color.AliceBlue;
            this.listViewPayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewPayments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPayment_SpaceColumn,
            this.columnHeaderPayment_CardNumber,
            this.columnHeaderPayment_CreatedTime,
            this.columnHeaderPayment_Cost,
            this.columnHeaderPayment_IsFinished,
            this.columnHeaderPayment_IsCancelled});
            this.listViewPayments.ContextMenuStrip = this.contextMenuStripListViewPayments;
            this.listViewPayments.FullRowSelect = true;
            this.listViewPayments.GridLines = true;
            this.listViewPayments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewPayments.HideSelection = false;
            this.listViewPayments.Location = new System.Drawing.Point(6, 100);
            this.listViewPayments.Name = "listViewPayments";
            this.listViewPayments.Size = new System.Drawing.Size(955, 497);
            this.listViewPayments.TabIndex = 4;
            this.listViewPayments.UseCompatibleStateImageBehavior = false;
            this.listViewPayments.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderPayment_SpaceColumn
            // 
            this.columnHeaderPayment_SpaceColumn.Text = "Space Column";
            this.columnHeaderPayment_SpaceColumn.Width = 0;
            // 
            // columnHeaderPayment_CardNumber
            // 
            this.columnHeaderPayment_CardNumber.Text = "Номер карты";
            this.columnHeaderPayment_CardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderPayment_CardNumber.Width = 210;
            // 
            // columnHeaderPayment_CreatedTime
            // 
            this.columnHeaderPayment_CreatedTime.Text = "Дата оплаты";
            this.columnHeaderPayment_CreatedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderPayment_CreatedTime.Width = 240;
            // 
            // columnHeaderPayment_Cost
            // 
            this.columnHeaderPayment_Cost.Text = "Сумма";
            this.columnHeaderPayment_Cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderPayment_Cost.Width = 155;
            // 
            // columnHeaderPayment_IsFinished
            // 
            this.columnHeaderPayment_IsFinished.Text = "Оплата прошла";
            this.columnHeaderPayment_IsFinished.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderPayment_IsFinished.Width = 150;
            // 
            // columnHeaderPayment_IsCancelled
            // 
            this.columnHeaderPayment_IsCancelled.Text = "Оплата отменена";
            this.columnHeaderPayment_IsCancelled.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderPayment_IsCancelled.Width = 170;
            // 
            // contextMenuStripListViewPayments
            // 
            this.contextMenuStripListViewPayments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStripListViewPayments.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripListViewPayments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemListViewPayments_Copy,
            this.toolStripMenuItemListViewPayments_Copy_CardNumber,
            this.toolStripMenuItemListViewPayments_Copy_CreatedDate,
            this.toolStripMenuItemListViewPayments_Copy_Cost,
            this.toolStripMenuItemListViewPayments_Copy_IsFinished,
            this.toolStripMenuItemListViewPayments_Copy_IsCancelled});
            this.contextMenuStripListViewPayments.Name = "contextMenuStripListView";
            this.contextMenuStripListViewPayments.Size = new System.Drawing.Size(426, 196);
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
            // tabPageSettings
            // 
            this.tabPageSettings.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageSettings.Controls.Add(this.textBoxSettings_Password);
            this.tabPageSettings.Controls.Add(this.label6);
            this.tabPageSettings.Controls.Add(this.textBoxSettings_DriverLicense);
            this.tabPageSettings.Controls.Add(this.maskedTextBoxSettings_PhoneNumber);
            this.tabPageSettings.Controls.Add(this.labelSpliter);
            this.tabPageSettings.Controls.Add(this.labelSettings_AccountSetupIsCompletedFine);
            this.tabPageSettings.Controls.Add(this.labelSettings_AccountSetupIsNotCompleted);
            this.tabPageSettings.Controls.Add(this.label5);
            this.tabPageSettings.Controls.Add(this.textBoxSettings_NewPasswordConfirmation);
            this.tabPageSettings.Controls.Add(this.label4);
            this.tabPageSettings.Controls.Add(this.textBoxSettings_NewPassword);
            this.tabPageSettings.Controls.Add(this.buttonSettings_ChangePassword);
            this.tabPageSettings.Controls.Add(this.label2);
            this.tabPageSettings.Controls.Add(this.textBoxSettings_OldPassword);
            this.tabPageSettings.Controls.Add(this.label3);
            this.tabPageSettings.Controls.Add(this.labelEmail);
            this.tabPageSettings.Controls.Add(this.textBoxSettings_Email);
            this.tabPageSettings.Controls.Add(this.buttonSettings_DeactivateMyAccount);
            this.tabPageSettings.Controls.Add(this.buttonSettings_Save);
            this.tabPageSettings.Controls.Add(this.label1);
            this.tabPageSettings.Controls.Add(this.textBoxSettings_CardNumber);
            this.tabPageSettings.Controls.Add(this.labelPassport);
            this.tabPageSettings.Controls.Add(this.textBoxSettings_Passport);
            this.tabPageSettings.Controls.Add(this.labelDriverLicense);
            this.tabPageSettings.ImageKey = "Settings.png";
            this.tabPageSettings.Location = new System.Drawing.Point(4, 34);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(970, 606);
            this.tabPageSettings.TabIndex = 2;
            this.tabPageSettings.Text = "Настройки ";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // textBoxSettings_Password
            // 
            this.textBoxSettings_Password.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxSettings_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSettings_Password.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSettings_Password.Location = new System.Drawing.Point(85, 66);
            this.textBoxSettings_Password.Name = "textBoxSettings_Password";
            this.textBoxSettings_Password.Size = new System.Drawing.Size(300, 31);
            this.textBoxSettings_Password.TabIndex = 0;
            this.textBoxSettings_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettings_Password.UseSystemPasswordChar = true;
            this.textBoxSettings_Password.TextChanged += new System.EventHandler(this.textBoxSettings_Password_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(111, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(242, 25);
            this.label6.TabIndex = 26;
            this.label6.Text = "Номер водительских прав:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSettings_DriverLicense
            // 
            this.textBoxSettings_DriverLicense.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxSettings_DriverLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSettings_DriverLicense.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSettings_DriverLicense.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxSettings_DriverLicense.Location = new System.Drawing.Point(85, 143);
            this.textBoxSettings_DriverLicense.Name = "textBoxSettings_DriverLicense";
            this.textBoxSettings_DriverLicense.Size = new System.Drawing.Size(300, 31);
            this.textBoxSettings_DriverLicense.TabIndex = 1;
            this.textBoxSettings_DriverLicense.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettings_DriverLicense.TextChanged += new System.EventHandler(this.textBoxSettings_DriverLicense_TextChanged);
            // 
            // maskedTextBoxSettings_PhoneNumber
            // 
            this.maskedTextBoxSettings_PhoneNumber.BackColor = System.Drawing.Color.AliceBlue;
            this.maskedTextBoxSettings_PhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBoxSettings_PhoneNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxSettings_PhoneNumber.Location = new System.Drawing.Point(85, 445);
            this.maskedTextBoxSettings_PhoneNumber.Mask = "+375 (99) 000-00-00";
            this.maskedTextBoxSettings_PhoneNumber.Name = "maskedTextBoxSettings_PhoneNumber";
            this.maskedTextBoxSettings_PhoneNumber.Size = new System.Drawing.Size(300, 31);
            this.maskedTextBoxSettings_PhoneNumber.TabIndex = 5;
            this.maskedTextBoxSettings_PhoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBoxSettings_PhoneNumber.TextChanged += new System.EventHandler(this.maskedTextBoxSettings_PhoneNumber_TextChanged);
            // 
            // labelSpliter
            // 
            this.labelSpliter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSpliter.Location = new System.Drawing.Point(468, 24);
            this.labelSpliter.Name = "labelSpliter";
            this.labelSpliter.Size = new System.Drawing.Size(28, 558);
            this.labelSpliter.TabIndex = 24;
            this.labelSpliter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSettings_AccountSetupIsCompletedFine
            // 
            this.labelSettings_AccountSetupIsCompletedFine.AutoSize = true;
            this.labelSettings_AccountSetupIsCompletedFine.BackColor = System.Drawing.Color.Transparent;
            this.labelSettings_AccountSetupIsCompletedFine.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelSettings_AccountSetupIsCompletedFine.Location = new System.Drawing.Point(611, 401);
            this.labelSettings_AccountSetupIsCompletedFine.Name = "labelSettings_AccountSetupIsCompletedFine";
            this.labelSettings_AccountSetupIsCompletedFine.Size = new System.Drawing.Size(236, 50);
            this.labelSettings_AccountSetupIsCompletedFine.TabIndex = 23;
            this.labelSettings_AccountSetupIsCompletedFine.Text = "Ваш аккаунт был успешно\r\nподтверждён!";
            this.labelSettings_AccountSetupIsCompletedFine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSettings_AccountSetupIsCompletedFine.Visible = false;
            // 
            // labelSettings_AccountSetupIsNotCompleted
            // 
            this.labelSettings_AccountSetupIsNotCompleted.AutoSize = true;
            this.labelSettings_AccountSetupIsNotCompleted.BackColor = System.Drawing.Color.Transparent;
            this.labelSettings_AccountSetupIsNotCompleted.ForeColor = System.Drawing.Color.Coral;
            this.labelSettings_AccountSetupIsNotCompleted.Location = new System.Drawing.Point(569, 376);
            this.labelSettings_AccountSetupIsNotCompleted.Name = "labelSettings_AccountSetupIsNotCompleted";
            this.labelSettings_AccountSetupIsNotCompleted.Size = new System.Drawing.Size(310, 100);
            this.labelSettings_AccountSetupIsNotCompleted.TabIndex = 22;
            this.labelSettings_AccountSetupIsNotCompleted.Text = "Ваш аккаунт ещё не подтверждён.\r\nЧтобы подтвердить его, требуется\r\nввести необход" +
    "имые данные в\r\nпустых полях.";
            this.labelSettings_AccountSetupIsNotCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(600, 216);
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
            this.textBoxSettings_NewPasswordConfirmation.Location = new System.Drawing.Point(574, 244);
            this.textBoxSettings_NewPasswordConfirmation.Name = "textBoxSettings_NewPasswordConfirmation";
            this.textBoxSettings_NewPasswordConfirmation.Size = new System.Drawing.Size(300, 31);
            this.textBoxSettings_NewPasswordConfirmation.TabIndex = 9;
            this.textBoxSettings_NewPasswordConfirmation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettings_NewPasswordConfirmation.UseSystemPasswordChar = true;
            this.textBoxSettings_NewPasswordConfirmation.TextChanged += new System.EventHandler(this.textBoxSettings_NewPasswordConfirmation_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(654, 127);
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
            this.textBoxSettings_NewPassword.Location = new System.Drawing.Point(574, 154);
            this.textBoxSettings_NewPassword.Name = "textBoxSettings_NewPassword";
            this.textBoxSettings_NewPassword.Size = new System.Drawing.Size(300, 31);
            this.textBoxSettings_NewPassword.TabIndex = 8;
            this.textBoxSettings_NewPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettings_NewPassword.UseSystemPasswordChar = true;
            this.textBoxSettings_NewPassword.TextChanged += new System.EventHandler(this.textBoxSettings_NewPassword_TextChanged);
            // 
            // buttonSettings_ChangePassword
            // 
            this.buttonSettings_ChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings_ChangePassword.Location = new System.Drawing.Point(643, 296);
            this.buttonSettings_ChangePassword.Name = "buttonSettings_ChangePassword";
            this.buttonSettings_ChangePassword.Size = new System.Drawing.Size(169, 47);
            this.buttonSettings_ChangePassword.TabIndex = 10;
            this.buttonSettings_ChangePassword.Text = "Сменить пароль";
            this.buttonSettings_ChangePassword.UseVisualStyleBackColor = true;
            this.buttonSettings_ChangePassword.Click += new System.EventHandler(this.buttonSettings_ChangePassword_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(649, 38);
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
            this.textBoxSettings_OldPassword.Location = new System.Drawing.Point(574, 66);
            this.textBoxSettings_OldPassword.Name = "textBoxSettings_OldPassword";
            this.textBoxSettings_OldPassword.Size = new System.Drawing.Size(300, 31);
            this.textBoxSettings_OldPassword.TabIndex = 7;
            this.textBoxSettings_OldPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettings_OldPassword.UseSystemPasswordChar = true;
            this.textBoxSettings_OldPassword.TextChanged += new System.EventHandler(this.textBoxSettings_OldPassword_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(157, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Номер телефона: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.BackColor = System.Drawing.Color.Transparent;
            this.labelEmail.Location = new System.Drawing.Point(200, 348);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(60, 25);
            this.labelEmail.TabIndex = 15;
            this.labelEmail.Text = "Email:";
            this.labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSettings_Email
            // 
            this.textBoxSettings_Email.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxSettings_Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSettings_Email.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSettings_Email.Location = new System.Drawing.Point(85, 376);
            this.textBoxSettings_Email.Name = "textBoxSettings_Email";
            this.textBoxSettings_Email.Size = new System.Drawing.Size(300, 31);
            this.textBoxSettings_Email.TabIndex = 4;
            this.textBoxSettings_Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettings_Email.TextChanged += new System.EventHandler(this.textBoxSettings_Email_TextChanged);
            // 
            // buttonSettings_DeactivateMyAccount
            // 
            this.buttonSettings_DeactivateMyAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings_DeactivateMyAccount.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonSettings_DeactivateMyAccount.Location = new System.Drawing.Point(616, 515);
            this.buttonSettings_DeactivateMyAccount.Name = "buttonSettings_DeactivateMyAccount";
            this.buttonSettings_DeactivateMyAccount.Size = new System.Drawing.Size(231, 43);
            this.buttonSettings_DeactivateMyAccount.TabIndex = 11;
            this.buttonSettings_DeactivateMyAccount.Text = "Деактивировать аккаунт";
            this.buttonSettings_DeactivateMyAccount.UseVisualStyleBackColor = true;
            this.buttonSettings_DeactivateMyAccount.Click += new System.EventHandler(this.buttonSettings_DeactivateMyAccount_Click);
            // 
            // buttonSettings_Save
            // 
            this.buttonSettings_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings_Save.Location = new System.Drawing.Point(154, 506);
            this.buttonSettings_Save.Name = "buttonSettings_Save";
            this.buttonSettings_Save.Size = new System.Drawing.Size(169, 61);
            this.buttonSettings_Save.TabIndex = 6;
            this.buttonSettings_Save.Text = "Сохранить настройки";
            this.buttonSettings_Save.UseVisualStyleBackColor = true;
            this.buttonSettings_Save.Click += new System.EventHandler(this.buttonSettings_Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(110, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Номер карты для списаний: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSettings_CardNumber
            // 
            this.textBoxSettings_CardNumber.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxSettings_CardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSettings_CardNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSettings_CardNumber.Location = new System.Drawing.Point(85, 296);
            this.textBoxSettings_CardNumber.Name = "textBoxSettings_CardNumber";
            this.textBoxSettings_CardNumber.Size = new System.Drawing.Size(300, 31);
            this.textBoxSettings_CardNumber.TabIndex = 3;
            this.textBoxSettings_CardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettings_CardNumber.TextChanged += new System.EventHandler(this.textBoxSettings_CardNumber_TextChanged);
            // 
            // labelPassport
            // 
            this.labelPassport.AutoSize = true;
            this.labelPassport.BackColor = System.Drawing.Color.Transparent;
            this.labelPassport.Location = new System.Drawing.Point(136, 188);
            this.labelPassport.Name = "labelPassport";
            this.labelPassport.Size = new System.Drawing.Size(197, 25);
            this.labelPassport.TabIndex = 7;
            this.labelPassport.Text = "Паспортные данные: ";
            this.labelPassport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSettings_Passport
            // 
            this.textBoxSettings_Passport.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxSettings_Passport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSettings_Passport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSettings_Passport.Location = new System.Drawing.Point(85, 216);
            this.textBoxSettings_Passport.Name = "textBoxSettings_Passport";
            this.textBoxSettings_Passport.Size = new System.Drawing.Size(300, 31);
            this.textBoxSettings_Passport.TabIndex = 2;
            this.textBoxSettings_Passport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSettings_Passport.TextChanged += new System.EventHandler(this.textBoxSettings_Passport_TextChanged);
            // 
            // labelDriverLicense
            // 
            this.labelDriverLicense.AutoSize = true;
            this.labelDriverLicense.BackColor = System.Drawing.Color.Transparent;
            this.labelDriverLicense.ForeColor = System.Drawing.Color.Black;
            this.labelDriverLicense.Location = new System.Drawing.Point(174, 38);
            this.labelDriverLicense.Name = "labelDriverLicense";
            this.labelDriverLicense.Size = new System.Drawing.Size(118, 25);
            this.labelDriverLicense.TabIndex = 5;
            this.labelDriverLicense.Text = "Ваш пароль:";
            this.labelDriverLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageListTabControlClient
            // 
            this.imageListTabControlClient.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTabControlClient.ImageStream")));
            this.imageListTabControlClient.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTabControlClient.Images.SetKeyName(0, "MakeAnOrder.png");
            this.imageListTabControlClient.Images.SetKeyName(1, "OrderList.png");
            this.imageListTabControlClient.Images.SetKeyName(2, "BalanceTopUp.png");
            this.imageListTabControlClient.Images.SetKeyName(3, "Settings.png");
            // 
            // toolTipEmail
            // 
            this.toolTipEmail.AutomaticDelay = 250;
            this.toolTipEmail.AutoPopDelay = 5000;
            this.toolTipEmail.InitialDelay = 250;
            this.toolTipEmail.ReshowDelay = 50;
            this.toolTipEmail.ToolTipTitle = "Email";
            // 
            // toolTipPhoneNumber
            // 
            this.toolTipPhoneNumber.AutomaticDelay = 250;
            this.toolTipPhoneNumber.AutoPopDelay = 5000;
            this.toolTipPhoneNumber.InitialDelay = 250;
            this.toolTipPhoneNumber.ReshowDelay = 50;
            this.toolTipPhoneNumber.ToolTipTitle = "Номер телефона";
            // 
            // toolTipCardNumber
            // 
            this.toolTipCardNumber.AutomaticDelay = 250;
            this.toolTipCardNumber.AutoPopDelay = 5000;
            this.toolTipCardNumber.InitialDelay = 250;
            this.toolTipCardNumber.ReshowDelay = 50;
            this.toolTipCardNumber.ToolTipTitle = "Номер карты";
            // 
            // toolTipPassword
            // 
            this.toolTipPassword.AutomaticDelay = 250;
            this.toolTipPassword.AutoPopDelay = 5000;
            this.toolTipPassword.InitialDelay = 250;
            this.toolTipPassword.ReshowDelay = 50;
            this.toolTipPassword.ToolTipTitle = "Ваш текущий пароль";
            // 
            // toolTipSecretCode
            // 
            this.toolTipSecretCode.AutomaticDelay = 250;
            this.toolTipSecretCode.AutoPopDelay = 5000;
            this.toolTipSecretCode.InitialDelay = 250;
            this.toolTipSecretCode.ReshowDelay = 50;
            this.toolTipSecretCode.ToolTipTitle = "Секретный код";
            // 
            // toolTipCost
            // 
            this.toolTipCost.AutomaticDelay = 250;
            this.toolTipCost.AutoPopDelay = 5000;
            this.toolTipCost.InitialDelay = 250;
            this.toolTipCost.ReshowDelay = 50;
            this.toolTipCost.ToolTipTitle = "Сумма пополнения";
            // 
            // toolTipOrderHours
            // 
            this.toolTipOrderHours.AutomaticDelay = 250;
            this.toolTipOrderHours.AutoPopDelay = 5000;
            this.toolTipOrderHours.InitialDelay = 250;
            this.toolTipOrderHours.ReshowDelay = 50;
            this.toolTipOrderHours.ToolTipTitle = "Временной промежуток аренды";
            // 
            // toolTipOrderBookingDateTime
            // 
            this.toolTipOrderBookingDateTime.AutomaticDelay = 250;
            this.toolTipOrderBookingDateTime.AutoPopDelay = 5000;
            this.toolTipOrderBookingDateTime.InitialDelay = 250;
            this.toolTipOrderBookingDateTime.ReshowDelay = 50;
            this.toolTipOrderBookingDateTime.ToolTipTitle = "Время бронирования";
            // 
            // toolTipOrderBookingEndDateTime
            // 
            this.toolTipOrderBookingEndDateTime.AutomaticDelay = 250;
            this.toolTipOrderBookingEndDateTime.AutoPopDelay = 5000;
            this.toolTipOrderBookingEndDateTime.InitialDelay = 250;
            this.toolTipOrderBookingEndDateTime.ReshowDelay = 50;
            this.toolTipOrderBookingEndDateTime.ToolTipTitle = "Время окончания";
            // 
            // toolTipOrderListCarPicture
            // 
            this.toolTipOrderListCarPicture.AutomaticDelay = 250;
            this.toolTipOrderListCarPicture.AutoPopDelay = 5000;
            this.toolTipOrderListCarPicture.InitialDelay = 250;
            this.toolTipOrderListCarPicture.ReshowDelay = 50;
            this.toolTipOrderListCarPicture.ToolTipTitle = "Время окончания";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(978, 644);
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
            this.contextMenuStripListViewMakeServiceReport.ResumeLayout(false);
            this.tabPageMakeOrder.ResumeLayout(false);
            this.tabPageMakeOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMakeServiceReport_CarPicture)).EndInit();
            this.contextMenuStripListViewServiceReportList.ResumeLayout(false);
            this.tabPagePayments.ResumeLayout(false);
            this.tabPagePayments.PerformLayout();
            this.contextMenuStripListViewPayments.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlAdmin;
        private System.Windows.Forms.TabPage tabPageServiceReportList;
        private System.Windows.Forms.TabPage tabPagePayments;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageMakeOrder;
        private System.Windows.Forms.Label labelDriverLicense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSettings_CardNumber;
        private System.Windows.Forms.Label labelPassport;
        private System.Windows.Forms.TextBox textBoxSettings_Passport;
        private System.Windows.Forms.Button buttonSettings_Save;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSettings_NewPasswordConfirmation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSettings_NewPassword;
        private System.Windows.Forms.Button buttonSettings_ChangePassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSettings_OldPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxSettings_Email;
        private System.Windows.Forms.Button buttonSettings_DeactivateMyAccount;
        private System.Windows.Forms.Label labelSettings_AccountSetupIsNotCompleted;
        private System.Windows.Forms.Label labelSettings_AccountSetupIsCompletedFine;
        private System.Windows.Forms.Label labelSpliter;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxSettings_PhoneNumber;
        private System.Windows.Forms.TextBox textBoxSettings_Password;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSettings_DriverLicense;
        private System.Windows.Forms.ToolTip toolTipEmail;
        private System.Windows.Forms.ToolTip toolTipPhoneNumber;
        private System.Windows.Forms.ToolTip toolTipCardNumber;
        private System.Windows.Forms.ToolTip toolTipPassword;
        private System.Windows.Forms.ListView listViewPayments;
        private System.Windows.Forms.ColumnHeader columnHeaderPayment_CreatedTime;
        private System.Windows.Forms.ColumnHeader columnHeaderPayment_Cost;
        private System.Windows.Forms.ColumnHeader columnHeaderPayment_IsFinished;
        private System.Windows.Forms.ColumnHeader columnHeaderPayment_IsCancelled;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPayment_CardNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPayments_SecretCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPayments_Cost;
        private System.Windows.Forms.Button buttonPayments_CreatePayment;
        private System.Windows.Forms.ToolTip toolTipSecretCode;
        private System.Windows.Forms.ToolTip toolTipCost;
        private System.Windows.Forms.ColumnHeader columnHeaderPayment_CardNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderPayment_SpaceColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListViewPayments;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewPayments_Copy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewPayments_Copy_CardNumber;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewPayments_Copy_CreatedDate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewPayments_Copy_Cost;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewPayments_Copy_IsFinished;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewPayments_Copy_IsCancelled;
        private System.Windows.Forms.ImageList imageListTabControlClient;
        private System.Windows.Forms.ToolTip toolTipOrderHours;
        private System.Windows.Forms.ToolTip toolTipOrderBookingDateTime;
        private System.Windows.Forms.ToolTip toolTipOrderBookingEndDateTime;
        private System.Windows.Forms.ListView listViewServiceReportList;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_SpaceColumn;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_Description;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_Description;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_Cost;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_AdditionalCost;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_EmployeeName;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_EmployeeReport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewServiceReportList_Copy_ID;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_PlannedCompletionDays;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_CostPerDay;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_FullCost;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_IsStarted;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_EmployeeName;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceReportList_ReportString;
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
    }
}

