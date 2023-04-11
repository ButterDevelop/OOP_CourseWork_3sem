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
            this.tabPageMakeOrder = new System.Windows.Forms.TabPage();
            this.tabPageOrdersList = new System.Windows.Forms.TabPage();
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
            this.contextMenuStripListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemListView_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListView_Copy_CardNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListView_Copy_CreatedDate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListView_Copy_Cost = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListView_Copy_IsFinished = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListView_Copy_IsCancelled = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tabControlClient.SuspendLayout();
            this.tabPagePayments.SuspendLayout();
            this.contextMenuStripListView.SuspendLayout();
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
            // tabPageMakeOrder
            // 
            this.tabPageMakeOrder.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageMakeOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageMakeOrder.ImageKey = "MakeAnOrder.png";
            this.tabPageMakeOrder.Location = new System.Drawing.Point(4, 34);
            this.tabPageMakeOrder.Name = "tabPageMakeOrder";
            this.tabPageMakeOrder.Size = new System.Drawing.Size(970, 606);
            this.tabPageMakeOrder.TabIndex = 3;
            this.tabPageMakeOrder.Text = "Сделать заказ ";
            this.tabPageMakeOrder.UseVisualStyleBackColor = true;
            // 
            // tabPageOrdersList
            // 
            this.tabPageOrdersList.BackColor = System.Drawing.Color.Transparent;
            this.tabPageOrdersList.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageOrdersList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPageOrdersList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.listViewPayments.ContextMenuStrip = this.contextMenuStripListView;
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
            // contextMenuStripListView
            // 
            this.contextMenuStripListView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStripListView.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemListView_Copy,
            this.toolStripMenuItemListView_Copy_CardNumber,
            this.toolStripMenuItemListView_Copy_CreatedDate,
            this.toolStripMenuItemListView_Copy_Cost,
            this.toolStripMenuItemListView_Copy_IsFinished,
            this.toolStripMenuItemListView_Copy_IsCancelled});
            this.contextMenuStripListView.Name = "contextMenuStripListView";
            this.contextMenuStripListView.Size = new System.Drawing.Size(414, 196);
            // 
            // toolStripMenuItemListView_Copy
            // 
            this.toolStripMenuItemListView_Copy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemListView_Copy.Name = "toolStripMenuItemListView_Copy";
            this.toolStripMenuItemListView_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toolStripMenuItemListView_Copy.Size = new System.Drawing.Size(413, 32);
            this.toolStripMenuItemListView_Copy.Text = "Скопировать";
            this.toolStripMenuItemListView_Copy.Click += new System.EventHandler(this.toolStripMenuItemListView_Copy_Click);
            // 
            // toolStripMenuItemListView_Copy_CardNumber
            // 
            this.toolStripMenuItemListView_Copy_CardNumber.Name = "toolStripMenuItemListView_Copy_CardNumber";
            this.toolStripMenuItemListView_Copy_CardNumber.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.toolStripMenuItemListView_Copy_CardNumber.Size = new System.Drawing.Size(413, 32);
            this.toolStripMenuItemListView_Copy_CardNumber.Text = "Скопировать номер карты";
            this.toolStripMenuItemListView_Copy_CardNumber.Click += new System.EventHandler(this.toolStripMenuItemListView_Copy_CardNumber_Click);
            // 
            // toolStripMenuItemListView_Copy_CreatedDate
            // 
            this.toolStripMenuItemListView_Copy_CreatedDate.Name = "toolStripMenuItemListView_Copy_CreatedDate";
            this.toolStripMenuItemListView_Copy_CreatedDate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.toolStripMenuItemListView_Copy_CreatedDate.Size = new System.Drawing.Size(413, 32);
            this.toolStripMenuItemListView_Copy_CreatedDate.Text = "Скопировать время оплаты";
            this.toolStripMenuItemListView_Copy_CreatedDate.Click += new System.EventHandler(this.toolStripMenuItemListView_Copy_CreatedDate_Click);
            // 
            // toolStripMenuItemListView_Copy_Cost
            // 
            this.toolStripMenuItemListView_Copy_Cost.Name = "toolStripMenuItemListView_Copy_Cost";
            this.toolStripMenuItemListView_Copy_Cost.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.toolStripMenuItemListView_Copy_Cost.Size = new System.Drawing.Size(413, 32);
            this.toolStripMenuItemListView_Copy_Cost.Text = "Скопировать сумму оплаты";
            this.toolStripMenuItemListView_Copy_Cost.Click += new System.EventHandler(this.toolStripMenuItemListView_Copy_Cost_Click);
            // 
            // toolStripMenuItemListView_Copy_IsFinished
            // 
            this.toolStripMenuItemListView_Copy_IsFinished.Name = "toolStripMenuItemListView_Copy_IsFinished";
            this.toolStripMenuItemListView_Copy_IsFinished.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.toolStripMenuItemListView_Copy_IsFinished.Size = new System.Drawing.Size(413, 32);
            this.toolStripMenuItemListView_Copy_IsFinished.Text = "Скопировать \"Оплата прошла\"";
            this.toolStripMenuItemListView_Copy_IsFinished.Click += new System.EventHandler(this.toolStripMenuItemListView_Copy_IsFinished_Click);
            // 
            // toolStripMenuItemListView_Copy_IsCancelled
            // 
            this.toolStripMenuItemListView_Copy_IsCancelled.Name = "toolStripMenuItemListView_Copy_IsCancelled";
            this.toolStripMenuItemListView_Copy_IsCancelled.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.toolStripMenuItemListView_Copy_IsCancelled.Size = new System.Drawing.Size(413, 32);
            this.toolStripMenuItemListView_Copy_IsCancelled.Text = "Скопировать \"Оплата отменена\"";
            this.toolStripMenuItemListView_Copy_IsCancelled.Click += new System.EventHandler(this.toolStripMenuItemListView_Copy_IsCancelled_Click);
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
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.tabControlClient.ResumeLayout(false);
            this.tabPagePayments.ResumeLayout(false);
            this.tabPagePayments.PerformLayout();
            this.contextMenuStripListView.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListView_Copy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListView_Copy_CardNumber;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListView_Copy_CreatedDate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListView_Copy_Cost;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListView_Copy_IsFinished;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListView_Copy_IsCancelled;
        private System.Windows.Forms.Label labelBalanceText;
        private System.Windows.Forms.Label labelBalanceNumber;
        private System.Windows.Forms.ImageList imageListTabControlClient;
    }
}

