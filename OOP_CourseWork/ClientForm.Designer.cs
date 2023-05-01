using System;

namespace OOP_CourseWork
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.tabControlClient = new System.Windows.Forms.TabControl();
            this.tabPageOrdersList = new System.Windows.Forms.TabPage();
            this.buttonOrderList_ExtendTheOrder = new System.Windows.Forms.Button();
            this.buttonOrderList_OpenCarLocationMap = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxOrderList_LastServiceDate = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxOrderList_CarLicensePlate = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxOrderList_PricePerHour = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxOrderList_ProductionYear = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxOrderList_CarModel = new System.Windows.Forms.TextBox();
            this.labelOrderList_CarOrderInfo = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxOrderList_CarBrand = new System.Windows.Forms.TextBox();
            this.pictureBoxCarPicture = new System.Windows.Forms.PictureBox();
            this.buttonOrderList_CancelOrder = new System.Windows.Forms.Button();
            this.listViewOrderList = new System.Windows.Forms.ListView();
            this.columnHeaderOrderList_SpaceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOrderList_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOrderList_BookingDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOrderList_Hours = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOrderList_OrderEndDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOrderList_Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOrderList_OrderCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripListViewOrderList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemListViewOrderList_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewOrderList_Copy_ID = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewOrderList_Copy_BookingTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewOrderList_Copy_BookingHours = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewOrderList_Copy_OrderEndTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewOrderList_Copy_OrderStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListViewOrderList_Copy_OrderCost = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageMakeOrder = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxMakeAnOrder_BookingEndTime = new System.Windows.Forms.TextBox();
            this.dateTimePickerMakeAnOrder_BookingTime = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePickerMakeAnOrder_BookingDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonMakeAnOrder_CreateOrder = new System.Windows.Forms.Button();
            this.textBoxMakeAnOrder_BookingHours = new System.Windows.Forms.TextBox();
            this.listViewMakeAnOrder = new System.Windows.Forms.ListView();
            this.columnHeaderMakeAnOrder_SpaceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeAnOrder_BrandName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeAnOrder_ModelName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeAnOrder_ProductionYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMakeAnOrder_PricePerHour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.labelBalanceText = new System.Windows.Forms.Label();
            this.labelBalanceNumber = new System.Windows.Forms.Label();
            this.toolTipOrderHours = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipOrderBookingDateTime = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipOrderBookingEndDateTime = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipOrderListCarPicture = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlClient.SuspendLayout();
            this.tabPageOrdersList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarPicture)).BeginInit();
            this.contextMenuStripListViewOrderList.SuspendLayout();
            this.tabPageMakeOrder.SuspendLayout();
            this.tabPagePayments.SuspendLayout();
            this.contextMenuStripListViewPayments.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlClient
            // 
            this.tabControlClient.Controls.Add(this.tabPageOrdersList);
            this.tabControlClient.Controls.Add(this.tabPageMakeOrder);
            this.tabControlClient.Controls.Add(this.tabPagePayments);
            this.tabControlClient.Controls.Add(this.tabPageSettings);
            this.tabControlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlClient.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlClient.ImageList = this.imageListTabControlClient;
            this.tabControlClient.Location = new System.Drawing.Point(0, 0);
            this.tabControlClient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControlClient.Multiline = true;
            this.tabControlClient.Name = "tabControlClient";
            this.tabControlClient.SelectedIndex = 0;
            this.tabControlClient.Size = new System.Drawing.Size(978, 644);
            this.tabControlClient.TabIndex = 0;
            // 
            // tabPageOrdersList
            // 
            this.tabPageOrdersList.BackColor = System.Drawing.Color.Transparent;
            this.tabPageOrdersList.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageOrdersList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPageOrdersList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageOrdersList.Controls.Add(this.buttonOrderList_ExtendTheOrder);
            this.tabPageOrdersList.Controls.Add(this.buttonOrderList_OpenCarLocationMap);
            this.tabPageOrdersList.Controls.Add(this.label18);
            this.tabPageOrdersList.Controls.Add(this.textBoxOrderList_LastServiceDate);
            this.tabPageOrdersList.Controls.Add(this.label17);
            this.tabPageOrdersList.Controls.Add(this.textBoxOrderList_CarLicensePlate);
            this.tabPageOrdersList.Controls.Add(this.label16);
            this.tabPageOrdersList.Controls.Add(this.textBoxOrderList_PricePerHour);
            this.tabPageOrdersList.Controls.Add(this.label15);
            this.tabPageOrdersList.Controls.Add(this.textBoxOrderList_ProductionYear);
            this.tabPageOrdersList.Controls.Add(this.label14);
            this.tabPageOrdersList.Controls.Add(this.textBoxOrderList_CarModel);
            this.tabPageOrdersList.Controls.Add(this.labelOrderList_CarOrderInfo);
            this.tabPageOrdersList.Controls.Add(this.label13);
            this.tabPageOrdersList.Controls.Add(this.textBoxOrderList_CarBrand);
            this.tabPageOrdersList.Controls.Add(this.pictureBoxCarPicture);
            this.tabPageOrdersList.Controls.Add(this.buttonOrderList_CancelOrder);
            this.tabPageOrdersList.Controls.Add(this.listViewOrderList);
            this.tabPageOrdersList.ImageKey = "OrderList.png";
            this.tabPageOrdersList.Location = new System.Drawing.Point(4, 34);
            this.tabPageOrdersList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageOrdersList.Name = "tabPageOrdersList";
            this.tabPageOrdersList.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageOrdersList.Size = new System.Drawing.Size(970, 606);
            this.tabPageOrdersList.TabIndex = 0;
            this.tabPageOrdersList.Text = "Список заказов ";
            this.tabPageOrdersList.UseVisualStyleBackColor = true;
            // 
            // buttonOrderList_ExtendTheOrder
            // 
            this.buttonOrderList_ExtendTheOrder.Enabled = false;
            this.buttonOrderList_ExtendTheOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOrderList_ExtendTheOrder.Location = new System.Drawing.Point(580, 197);
            this.buttonOrderList_ExtendTheOrder.Name = "buttonOrderList_ExtendTheOrder";
            this.buttonOrderList_ExtendTheOrder.Size = new System.Drawing.Size(175, 40);
            this.buttonOrderList_ExtendTheOrder.TabIndex = 22;
            this.buttonOrderList_ExtendTheOrder.Text = "Продлить заказ";
            this.buttonOrderList_ExtendTheOrder.UseVisualStyleBackColor = true;
            this.buttonOrderList_ExtendTheOrder.Click += new System.EventHandler(this.buttonOrderList_ExtendTheOrder_Click);
            // 
            // buttonOrderList_OpenCarLocationMap
            // 
            this.buttonOrderList_OpenCarLocationMap.Enabled = false;
            this.buttonOrderList_OpenCarLocationMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOrderList_OpenCarLocationMap.Location = new System.Drawing.Point(387, 197);
            this.buttonOrderList_OpenCarLocationMap.Name = "buttonOrderList_OpenCarLocationMap";
            this.buttonOrderList_OpenCarLocationMap.Size = new System.Drawing.Size(175, 40);
            this.buttonOrderList_OpenCarLocationMap.TabIndex = 21;
            this.buttonOrderList_OpenCarLocationMap.Text = "Местоположение";
            this.buttonOrderList_OpenCarLocationMap.UseVisualStyleBackColor = true;
            this.buttonOrderList_OpenCarLocationMap.Click += new System.EventHandler(this.buttonOrderList_OpenCarLocationMap_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(768, 119);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(190, 25);
            this.label18.TabIndex = 20;
            this.label18.Text = "Дата обслуживания: ";
            // 
            // textBoxOrderList_LastServiceDate
            // 
            this.textBoxOrderList_LastServiceDate.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxOrderList_LastServiceDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOrderList_LastServiceDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOrderList_LastServiceDate.Location = new System.Drawing.Point(773, 148);
            this.textBoxOrderList_LastServiceDate.Name = "textBoxOrderList_LastServiceDate";
            this.textBoxOrderList_LastServiceDate.ReadOnly = true;
            this.textBoxOrderList_LastServiceDate.Size = new System.Drawing.Size(175, 31);
            this.textBoxOrderList_LastServiceDate.TabIndex = 19;
            this.textBoxOrderList_LastServiceDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // textBoxOrderList_CarLicensePlate
            // 
            this.textBoxOrderList_CarLicensePlate.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxOrderList_CarLicensePlate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOrderList_CarLicensePlate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOrderList_CarLicensePlate.Location = new System.Drawing.Point(580, 148);
            this.textBoxOrderList_CarLicensePlate.Name = "textBoxOrderList_CarLicensePlate";
            this.textBoxOrderList_CarLicensePlate.ReadOnly = true;
            this.textBoxOrderList_CarLicensePlate.Size = new System.Drawing.Size(175, 31);
            this.textBoxOrderList_CarLicensePlate.TabIndex = 17;
            this.textBoxOrderList_CarLicensePlate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // textBoxOrderList_PricePerHour
            // 
            this.textBoxOrderList_PricePerHour.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxOrderList_PricePerHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOrderList_PricePerHour.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOrderList_PricePerHour.Location = new System.Drawing.Point(387, 148);
            this.textBoxOrderList_PricePerHour.Name = "textBoxOrderList_PricePerHour";
            this.textBoxOrderList_PricePerHour.ReadOnly = true;
            this.textBoxOrderList_PricePerHour.Size = new System.Drawing.Size(175, 31);
            this.textBoxOrderList_PricePerHour.TabIndex = 15;
            this.textBoxOrderList_PricePerHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // textBoxOrderList_ProductionYear
            // 
            this.textBoxOrderList_ProductionYear.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxOrderList_ProductionYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOrderList_ProductionYear.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOrderList_ProductionYear.Location = new System.Drawing.Point(773, 82);
            this.textBoxOrderList_ProductionYear.Name = "textBoxOrderList_ProductionYear";
            this.textBoxOrderList_ProductionYear.ReadOnly = true;
            this.textBoxOrderList_ProductionYear.Size = new System.Drawing.Size(175, 31);
            this.textBoxOrderList_ProductionYear.TabIndex = 13;
            this.textBoxOrderList_ProductionYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // textBoxOrderList_CarModel
            // 
            this.textBoxOrderList_CarModel.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxOrderList_CarModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOrderList_CarModel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOrderList_CarModel.Location = new System.Drawing.Point(580, 82);
            this.textBoxOrderList_CarModel.Name = "textBoxOrderList_CarModel";
            this.textBoxOrderList_CarModel.ReadOnly = true;
            this.textBoxOrderList_CarModel.Size = new System.Drawing.Size(175, 31);
            this.textBoxOrderList_CarModel.TabIndex = 11;
            this.textBoxOrderList_CarModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelOrderList_CarOrderInfo
            // 
            this.labelOrderList_CarOrderInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrderList_CarOrderInfo.Location = new System.Drawing.Point(373, 14);
            this.labelOrderList_CarOrderInfo.Name = "labelOrderList_CarOrderInfo";
            this.labelOrderList_CarOrderInfo.Size = new System.Drawing.Size(588, 25);
            this.labelOrderList_CarOrderInfo.TabIndex = 10;
            this.labelOrderList_CarOrderInfo.Text = "Информация об автомобиле в выбранном заказе:";
            this.labelOrderList_CarOrderInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // textBoxOrderList_CarBrand
            // 
            this.textBoxOrderList_CarBrand.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxOrderList_CarBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOrderList_CarBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOrderList_CarBrand.Location = new System.Drawing.Point(387, 82);
            this.textBoxOrderList_CarBrand.Name = "textBoxOrderList_CarBrand";
            this.textBoxOrderList_CarBrand.ReadOnly = true;
            this.textBoxOrderList_CarBrand.Size = new System.Drawing.Size(175, 31);
            this.textBoxOrderList_CarBrand.TabIndex = 8;
            this.textBoxOrderList_CarBrand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBoxCarPicture
            // 
            this.pictureBoxCarPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxCarPicture.Location = new System.Drawing.Point(7, 7);
            this.pictureBoxCarPicture.Name = "pictureBoxCarPicture";
            this.pictureBoxCarPicture.Size = new System.Drawing.Size(360, 240);
            this.pictureBoxCarPicture.TabIndex = 7;
            this.pictureBoxCarPicture.TabStop = false;
            // 
            // buttonOrderList_CancelOrder
            // 
            this.buttonOrderList_CancelOrder.Enabled = false;
            this.buttonOrderList_CancelOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOrderList_CancelOrder.Location = new System.Drawing.Point(773, 197);
            this.buttonOrderList_CancelOrder.Name = "buttonOrderList_CancelOrder";
            this.buttonOrderList_CancelOrder.Size = new System.Drawing.Size(175, 40);
            this.buttonOrderList_CancelOrder.TabIndex = 6;
            this.buttonOrderList_CancelOrder.Text = "Отмена заказа";
            this.buttonOrderList_CancelOrder.UseVisualStyleBackColor = true;
            this.buttonOrderList_CancelOrder.Click += new System.EventHandler(this.buttonOrderList_CancelOrder_Click);
            // 
            // listViewOrderList
            // 
            this.listViewOrderList.BackColor = System.Drawing.Color.AliceBlue;
            this.listViewOrderList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewOrderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderOrderList_SpaceColumn,
            this.columnHeaderOrderList_ID,
            this.columnHeaderOrderList_BookingDateTime,
            this.columnHeaderOrderList_Hours,
            this.columnHeaderOrderList_OrderEndDateTime,
            this.columnHeaderOrderList_Status,
            this.columnHeaderOrderList_OrderCost});
            this.listViewOrderList.ContextMenuStrip = this.contextMenuStripListViewOrderList;
            this.listViewOrderList.FullRowSelect = true;
            this.listViewOrderList.GridLines = true;
            this.listViewOrderList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewOrderList.HideSelection = false;
            this.listViewOrderList.Location = new System.Drawing.Point(6, 253);
            this.listViewOrderList.Name = "listViewOrderList";
            this.listViewOrderList.Size = new System.Drawing.Size(955, 344);
            this.listViewOrderList.TabIndex = 5;
            this.listViewOrderList.UseCompatibleStateImageBehavior = false;
            this.listViewOrderList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderOrderList_SpaceColumn
            // 
            this.columnHeaderOrderList_SpaceColumn.Text = "Space Column";
            this.columnHeaderOrderList_SpaceColumn.Width = 0;
            // 
            // columnHeaderOrderList_ID
            // 
            this.columnHeaderOrderList_ID.Text = "№";
            this.columnHeaderOrderList_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderOrderList_ID.Width = 80;
            // 
            // columnHeaderOrderList_BookingDateTime
            // 
            this.columnHeaderOrderList_BookingDateTime.Text = "Время бронирования";
            this.columnHeaderOrderList_BookingDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderOrderList_BookingDateTime.Width = 210;
            // 
            // columnHeaderOrderList_Hours
            // 
            this.columnHeaderOrderList_Hours.Text = "Часы аренды";
            this.columnHeaderOrderList_Hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderOrderList_Hours.Width = 140;
            // 
            // columnHeaderOrderList_OrderEndDateTime
            // 
            this.columnHeaderOrderList_OrderEndDateTime.Text = "Окончание заказа";
            this.columnHeaderOrderList_OrderEndDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderOrderList_OrderEndDateTime.Width = 200;
            // 
            // columnHeaderOrderList_Status
            // 
            this.columnHeaderOrderList_Status.Text = "Статус заказа";
            this.columnHeaderOrderList_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderOrderList_Status.Width = 180;
            // 
            // columnHeaderOrderList_OrderCost
            // 
            this.columnHeaderOrderList_OrderCost.Text = "Сумма заказа";
            this.columnHeaderOrderList_OrderCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderOrderList_OrderCost.Width = 140;
            // 
            // contextMenuStripListViewOrderList
            // 
            this.contextMenuStripListViewOrderList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStripListViewOrderList.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripListViewOrderList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemListViewOrderList_Copy,
            this.toolStripMenuItemListViewOrderList_Copy_ID,
            this.toolStripMenuItemListViewOrderList_Copy_BookingTime,
            this.toolStripMenuItemListViewOrderList_Copy_BookingHours,
            this.toolStripMenuItemListViewOrderList_Copy_OrderEndTime,
            this.toolStripMenuItemListViewOrderList_Copy_OrderStatus,
            this.toolStripMenuItemListViewOrderList_Copy_OrderCost});
            this.contextMenuStripListViewOrderList.Name = "contextMenuStripListView";
            this.contextMenuStripListViewOrderList.Size = new System.Drawing.Size(474, 228);
            // 
            // toolStripMenuItemListViewOrderList_Copy
            // 
            this.toolStripMenuItemListViewOrderList_Copy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemListViewOrderList_Copy.Name = "toolStripMenuItemListViewOrderList_Copy";
            this.toolStripMenuItemListViewOrderList_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toolStripMenuItemListViewOrderList_Copy.Size = new System.Drawing.Size(473, 32);
            this.toolStripMenuItemListViewOrderList_Copy.Text = "Скопировать";
            this.toolStripMenuItemListViewOrderList_Copy.Click += new System.EventHandler(this.toolStripMenuItemListViewOrderList_Copy_Click);
            // 
            // toolStripMenuItemListViewOrderList_Copy_ID
            // 
            this.toolStripMenuItemListViewOrderList_Copy_ID.Name = "toolStripMenuItemListViewOrderList_Copy_ID";
            this.toolStripMenuItemListViewOrderList_Copy_ID.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.toolStripMenuItemListViewOrderList_Copy_ID.Size = new System.Drawing.Size(473, 32);
            this.toolStripMenuItemListViewOrderList_Copy_ID.Text = "Скопировать номер заказа";
            this.toolStripMenuItemListViewOrderList_Copy_ID.Click += new System.EventHandler(this.toolStripMenuItemListViewOrderList_Copy_ID_Click);
            // 
            // toolStripMenuItemListViewOrderList_Copy_BookingTime
            // 
            this.toolStripMenuItemListViewOrderList_Copy_BookingTime.Name = "toolStripMenuItemListViewOrderList_Copy_BookingTime";
            this.toolStripMenuItemListViewOrderList_Copy_BookingTime.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.toolStripMenuItemListViewOrderList_Copy_BookingTime.Size = new System.Drawing.Size(473, 32);
            this.toolStripMenuItemListViewOrderList_Copy_BookingTime.Text = "Скопировать время бронирования";
            this.toolStripMenuItemListViewOrderList_Copy_BookingTime.Click += new System.EventHandler(this.toolStripMenuItemListViewOrderList_Copy_BookingTime_Click);
            // 
            // toolStripMenuItemListViewOrderList_Copy_BookingHours
            // 
            this.toolStripMenuItemListViewOrderList_Copy_BookingHours.Name = "toolStripMenuItemListViewOrderList_Copy_BookingHours";
            this.toolStripMenuItemListViewOrderList_Copy_BookingHours.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.toolStripMenuItemListViewOrderList_Copy_BookingHours.Size = new System.Drawing.Size(473, 32);
            this.toolStripMenuItemListViewOrderList_Copy_BookingHours.Text = "Скопировать часы аренды";
            this.toolStripMenuItemListViewOrderList_Copy_BookingHours.Click += new System.EventHandler(this.toolStripMenuItemListViewOrderList_Copy_BookingHours_Click);
            // 
            // toolStripMenuItemListViewOrderList_Copy_OrderEndTime
            // 
            this.toolStripMenuItemListViewOrderList_Copy_OrderEndTime.Name = "toolStripMenuItemListViewOrderList_Copy_OrderEndTime";
            this.toolStripMenuItemListViewOrderList_Copy_OrderEndTime.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.toolStripMenuItemListViewOrderList_Copy_OrderEndTime.Size = new System.Drawing.Size(473, 32);
            this.toolStripMenuItemListViewOrderList_Copy_OrderEndTime.Text = "Скопировать время окончания заказа";
            this.toolStripMenuItemListViewOrderList_Copy_OrderEndTime.Click += new System.EventHandler(this.toolStripMenuItemListViewOrderList_Copy_OrderEndTime_Click);
            // 
            // toolStripMenuItemListViewOrderList_Copy_OrderStatus
            // 
            this.toolStripMenuItemListViewOrderList_Copy_OrderStatus.Name = "toolStripMenuItemListViewOrderList_Copy_OrderStatus";
            this.toolStripMenuItemListViewOrderList_Copy_OrderStatus.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.toolStripMenuItemListViewOrderList_Copy_OrderStatus.Size = new System.Drawing.Size(473, 32);
            this.toolStripMenuItemListViewOrderList_Copy_OrderStatus.Text = "Скопировать статус заказа";
            this.toolStripMenuItemListViewOrderList_Copy_OrderStatus.Click += new System.EventHandler(this.toolStripMenuItemListViewOrderList_Copy_OrderStatus_Click);
            // 
            // toolStripMenuItemListViewOrderList_Copy_OrderCost
            // 
            this.toolStripMenuItemListViewOrderList_Copy_OrderCost.Name = "toolStripMenuItemListViewOrderList_Copy_OrderCost";
            this.toolStripMenuItemListViewOrderList_Copy_OrderCost.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D6)));
            this.toolStripMenuItemListViewOrderList_Copy_OrderCost.Size = new System.Drawing.Size(473, 32);
            this.toolStripMenuItemListViewOrderList_Copy_OrderCost.Text = "Скопировать сумму заказа";
            this.toolStripMenuItemListViewOrderList_Copy_OrderCost.Click += new System.EventHandler(this.toolStripMenuItemListViewOrderList_Copy_OrderCost_Click);
            // 
            // tabPageMakeOrder
            // 
            this.tabPageMakeOrder.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageMakeOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageMakeOrder.Controls.Add(this.label12);
            this.tabPageMakeOrder.Controls.Add(this.textBoxMakeAnOrder_BookingEndTime);
            this.tabPageMakeOrder.Controls.Add(this.dateTimePickerMakeAnOrder_BookingTime);
            this.tabPageMakeOrder.Controls.Add(this.label11);
            this.tabPageMakeOrder.Controls.Add(this.dateTimePickerMakeAnOrder_BookingDate);
            this.tabPageMakeOrder.Controls.Add(this.label10);
            this.tabPageMakeOrder.Controls.Add(this.buttonMakeAnOrder_CreateOrder);
            this.tabPageMakeOrder.Controls.Add(this.textBoxMakeAnOrder_BookingHours);
            this.tabPageMakeOrder.Controls.Add(this.listViewMakeAnOrder);
            this.tabPageMakeOrder.ImageKey = "MakeAnOrder.png";
            this.tabPageMakeOrder.Location = new System.Drawing.Point(4, 34);
            this.tabPageMakeOrder.Name = "tabPageMakeOrder";
            this.tabPageMakeOrder.Size = new System.Drawing.Size(970, 606);
            this.tabPageMakeOrder.TabIndex = 3;
            this.tabPageMakeOrder.Text = "Сделать заказ ";
            this.tabPageMakeOrder.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(569, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(174, 25);
            this.label12.TabIndex = 11;
            this.label12.Text = "Время окончания: ";
            // 
            // textBoxMakeAnOrder_BookingEndTime
            // 
            this.textBoxMakeAnOrder_BookingEndTime.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxMakeAnOrder_BookingEndTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMakeAnOrder_BookingEndTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMakeAnOrder_BookingEndTime.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxMakeAnOrder_BookingEndTime.Location = new System.Drawing.Point(567, 43);
            this.textBoxMakeAnOrder_BookingEndTime.Name = "textBoxMakeAnOrder_BookingEndTime";
            this.textBoxMakeAnOrder_BookingEndTime.ReadOnly = true;
            this.textBoxMakeAnOrder_BookingEndTime.Size = new System.Drawing.Size(175, 31);
            this.textBoxMakeAnOrder_BookingEndTime.TabIndex = 4;
            this.textBoxMakeAnOrder_BookingEndTime.Text = "01.09.1939 04:00:00";
            this.textBoxMakeAnOrder_BookingEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimePickerMakeAnOrder_BookingTime
            // 
            this.dateTimePickerMakeAnOrder_BookingTime.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dateTimePickerMakeAnOrder_BookingTime.CustomFormat = "";
            this.dateTimePickerMakeAnOrder_BookingTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerMakeAnOrder_BookingTime.Location = new System.Drawing.Point(399, 43);
            this.dateTimePickerMakeAnOrder_BookingTime.Name = "dateTimePickerMakeAnOrder_BookingTime";
            this.dateTimePickerMakeAnOrder_BookingTime.ShowUpDown = true;
            this.dateTimePickerMakeAnOrder_BookingTime.Size = new System.Drawing.Size(128, 31);
            this.dateTimePickerMakeAnOrder_BookingTime.TabIndex = 2;
            this.dateTimePickerMakeAnOrder_BookingTime.Value = new System.DateTime(2023, 4, 19, 12, 44, 0, 0);
            this.dateTimePickerMakeAnOrder_BookingTime.ValueChanged += new System.EventHandler(this.dateTimePickerMakeAnOrder_BookingTime_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(278, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(209, 25);
            this.label11.TabIndex = 8;
            this.label11.Text = "Время бронирования: ";
            // 
            // dateTimePickerMakeAnOrder_BookingDate
            // 
            this.dateTimePickerMakeAnOrder_BookingDate.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dateTimePickerMakeAnOrder_BookingDate.CustomFormat = "";
            this.dateTimePickerMakeAnOrder_BookingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerMakeAnOrder_BookingDate.Location = new System.Drawing.Point(238, 43);
            this.dateTimePickerMakeAnOrder_BookingDate.Name = "dateTimePickerMakeAnOrder_BookingDate";
            this.dateTimePickerMakeAnOrder_BookingDate.Size = new System.Drawing.Size(155, 31);
            this.dateTimePickerMakeAnOrder_BookingDate.TabIndex = 1;
            this.dateTimePickerMakeAnOrder_BookingDate.Value = new System.DateTime(2023, 4, 20, 12, 44, 0, 0);
            this.dateTimePickerMakeAnOrder_BookingDate.ValueChanged += new System.EventHandler(this.dateTimePickerMakeAnOrder_BookingDate_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(174, 25);
            this.label10.TabIndex = 6;
            this.label10.Text = "Количество часов: ";
            // 
            // buttonMakeAnOrder_CreateOrder
            // 
            this.buttonMakeAnOrder_CreateOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMakeAnOrder_CreateOrder.Location = new System.Drawing.Point(795, 34);
            this.buttonMakeAnOrder_CreateOrder.Name = "buttonMakeAnOrder_CreateOrder";
            this.buttonMakeAnOrder_CreateOrder.Size = new System.Drawing.Size(147, 47);
            this.buttonMakeAnOrder_CreateOrder.TabIndex = 5;
            this.buttonMakeAnOrder_CreateOrder.Text = "Заказать";
            this.buttonMakeAnOrder_CreateOrder.UseVisualStyleBackColor = true;
            this.buttonMakeAnOrder_CreateOrder.Click += new System.EventHandler(this.buttonMakeAnOrder_CreateOrder_Click);
            // 
            // textBoxMakeAnOrder_BookingHours
            // 
            this.textBoxMakeAnOrder_BookingHours.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxMakeAnOrder_BookingHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMakeAnOrder_BookingHours.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMakeAnOrder_BookingHours.Location = new System.Drawing.Point(25, 43);
            this.textBoxMakeAnOrder_BookingHours.Name = "textBoxMakeAnOrder_BookingHours";
            this.textBoxMakeAnOrder_BookingHours.Size = new System.Drawing.Size(175, 31);
            this.textBoxMakeAnOrder_BookingHours.TabIndex = 0;
            this.textBoxMakeAnOrder_BookingHours.Text = "1";
            this.textBoxMakeAnOrder_BookingHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMakeAnOrder_BookingHours.TextChanged += new System.EventHandler(this.textBoxMakeAnOrder_BookingHours_TextChanged);
            // 
            // listViewMakeAnOrder
            // 
            this.listViewMakeAnOrder.BackColor = System.Drawing.Color.AliceBlue;
            this.listViewMakeAnOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewMakeAnOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderMakeAnOrder_SpaceColumn,
            this.columnHeaderMakeAnOrder_BrandName,
            this.columnHeaderMakeAnOrder_ModelName,
            this.columnHeaderMakeAnOrder_ProductionYear,
            this.columnHeaderMakeAnOrder_PricePerHour});
            this.listViewMakeAnOrder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewMakeAnOrder.HideSelection = false;
            this.listViewMakeAnOrder.Location = new System.Drawing.Point(6, 100);
            this.listViewMakeAnOrder.MultiSelect = false;
            this.listViewMakeAnOrder.Name = "listViewMakeAnOrder";
            this.listViewMakeAnOrder.Size = new System.Drawing.Size(955, 497);
            this.listViewMakeAnOrder.TabIndex = 6;
            this.listViewMakeAnOrder.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeaderMakeAnOrder_SpaceColumn
            // 
            this.columnHeaderMakeAnOrder_SpaceColumn.Text = "";
            this.columnHeaderMakeAnOrder_SpaceColumn.Width = 0;
            // 
            // columnHeaderMakeAnOrder_BrandName
            // 
            this.columnHeaderMakeAnOrder_BrandName.Text = "Марка автомобиля";
            this.columnHeaderMakeAnOrder_BrandName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeaderMakeAnOrder_ModelName
            // 
            this.columnHeaderMakeAnOrder_ModelName.Text = "Модель автомобиля";
            this.columnHeaderMakeAnOrder_ModelName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeaderMakeAnOrder_ProductionYear
            // 
            this.columnHeaderMakeAnOrder_ProductionYear.Text = "Год выпуска авто";
            this.columnHeaderMakeAnOrder_ProductionYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeaderMakeAnOrder_PricePerHour
            // 
            this.columnHeaderMakeAnOrder_PricePerHour.Text = "Цена в час";
            this.columnHeaderMakeAnOrder_PricePerHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // labelBalanceText
            // 
            this.labelBalanceText.AutoSize = true;
            this.labelBalanceText.BackColor = System.Drawing.Color.Transparent;
            this.labelBalanceText.Location = new System.Drawing.Point(730, 5);
            this.labelBalanceText.Name = "labelBalanceText";
            this.labelBalanceText.Size = new System.Drawing.Size(114, 25);
            this.labelBalanceText.TabIndex = 27;
            this.labelBalanceText.Text = "Ваш баланс:";
            this.labelBalanceText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBalanceNumber
            // 
            this.labelBalanceNumber.BackColor = System.Drawing.Color.Transparent;
            this.labelBalanceNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBalanceNumber.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelBalanceNumber.Location = new System.Drawing.Point(850, 5);
            this.labelBalanceNumber.Name = "labelBalanceNumber";
            this.labelBalanceNumber.Size = new System.Drawing.Size(119, 25);
            this.labelBalanceNumber.TabIndex = 28;
            this.labelBalanceNumber.Text = "0.00";
            this.labelBalanceNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(978, 644);
            this.Controls.Add(this.labelBalanceText);
            this.Controls.Add(this.labelBalanceNumber);
            this.Controls.Add(this.tabControlClient);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarSharingBY - клиент";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.tabControlClient.ResumeLayout(false);
            this.tabPageOrdersList.ResumeLayout(false);
            this.tabPageOrdersList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarPicture)).EndInit();
            this.contextMenuStripListViewOrderList.ResumeLayout(false);
            this.tabPageMakeOrder.ResumeLayout(false);
            this.tabPageMakeOrder.PerformLayout();
            this.tabPagePayments.ResumeLayout(false);
            this.tabPagePayments.PerformLayout();
            this.contextMenuStripListViewPayments.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlClient;
        private System.Windows.Forms.TabPage tabPageOrdersList;
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
        private System.Windows.Forms.Label labelBalanceText;
        private System.Windows.Forms.Label labelBalanceNumber;
        private System.Windows.Forms.ImageList imageListTabControlClient;
        private System.Windows.Forms.ListView listViewMakeAnOrder;
        private System.Windows.Forms.Button buttonMakeAnOrder_CreateOrder;
        private System.Windows.Forms.TextBox textBoxMakeAnOrder_BookingHours;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePickerMakeAnOrder_BookingDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePickerMakeAnOrder_BookingTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxMakeAnOrder_BookingEndTime;
        private System.Windows.Forms.ToolTip toolTipOrderHours;
        private System.Windows.Forms.ToolTip toolTipOrderBookingDateTime;
        private System.Windows.Forms.ToolTip toolTipOrderBookingEndDateTime;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeAnOrder_SpaceColumn;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeAnOrder_BrandName;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeAnOrder_ModelName;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeAnOrder_ProductionYear;
        private System.Windows.Forms.ColumnHeader columnHeaderMakeAnOrder_PricePerHour;
        private System.Windows.Forms.ListView listViewOrderList;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderList_SpaceColumn;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderList_BookingDateTime;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderList_OrderEndDateTime;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderList_Hours;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderList_Status;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderList_OrderCost;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderList_ID;
        private System.Windows.Forms.Button buttonOrderList_CancelOrder;
        private System.Windows.Forms.PictureBox pictureBoxCarPicture;
        private System.Windows.Forms.ToolTip toolTipOrderListCarPicture;
        private System.Windows.Forms.Label labelOrderList_CarOrderInfo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxOrderList_CarBrand;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxOrderList_CarModel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxOrderList_ProductionYear;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxOrderList_PricePerHour;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxOrderList_CarLicensePlate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxOrderList_LastServiceDate;
        private System.Windows.Forms.Button buttonOrderList_OpenCarLocationMap;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListViewOrderList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewOrderList_Copy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewOrderList_Copy_BookingTime;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewOrderList_Copy_BookingHours;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewOrderList_Copy_OrderEndTime;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewOrderList_Copy_OrderStatus;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewOrderList_Copy_OrderCost;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListViewOrderList_Copy_ID;
        private System.Windows.Forms.Button buttonOrderList_ExtendTheOrder;
    }
}

