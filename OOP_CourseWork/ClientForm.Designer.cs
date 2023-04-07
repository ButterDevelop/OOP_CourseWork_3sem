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
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDriverLicense = new System.Windows.Forms.TextBox();
            this.maskedTextBoxPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.labelSpliter = new System.Windows.Forms.Label();
            this.labelAccountSetupIsCompletedFine = new System.Windows.Forms.Label();
            this.labelAccountSetupIsNotCompleted = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNewPasswordConfirmation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOldPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.buttonDeactivateMyAccount = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCardNumber = new System.Windows.Forms.TextBox();
            this.labelPassport = new System.Windows.Forms.Label();
            this.textBoxPassport = new System.Windows.Forms.TextBox();
            this.labelDriverLicense = new System.Windows.Forms.Label();
            this.toolTipEmail = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPhoneNumber = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipCardNumber = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPassword = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlClient.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlClient
            // 
            this.tabControlClient.Controls.Add(this.tabPageMakeOrder);
            this.tabControlClient.Controls.Add(this.tabPageOrdersList);
            this.tabControlClient.Controls.Add(this.tabPagePayments);
            this.tabControlClient.Controls.Add(this.tabPageSettings);
            this.tabControlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlClient.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tabPageMakeOrder.Location = new System.Drawing.Point(4, 34);
            this.tabPageMakeOrder.Name = "tabPageMakeOrder";
            this.tabPageMakeOrder.Size = new System.Drawing.Size(970, 606);
            this.tabPageMakeOrder.TabIndex = 3;
            this.tabPageMakeOrder.Text = " Сделать заказ ";
            this.tabPageMakeOrder.UseVisualStyleBackColor = true;
            // 
            // tabPageOrdersList
            // 
            this.tabPageOrdersList.BackColor = System.Drawing.Color.Transparent;
            this.tabPageOrdersList.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageOrdersList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPageOrdersList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageOrdersList.Location = new System.Drawing.Point(4, 34);
            this.tabPageOrdersList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageOrdersList.Name = "tabPageOrdersList";
            this.tabPageOrdersList.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageOrdersList.Size = new System.Drawing.Size(970, 606);
            this.tabPageOrdersList.TabIndex = 0;
            this.tabPageOrdersList.Text = " Список заказов ";
            this.tabPageOrdersList.UseVisualStyleBackColor = true;
            // 
            // tabPagePayments
            // 
            this.tabPagePayments.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPagePayments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPagePayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPagePayments.Location = new System.Drawing.Point(4, 34);
            this.tabPagePayments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPagePayments.Name = "tabPagePayments";
            this.tabPagePayments.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPagePayments.Size = new System.Drawing.Size(970, 606);
            this.tabPagePayments.TabIndex = 1;
            this.tabPagePayments.Text = " Оплата ";
            this.tabPagePayments.UseVisualStyleBackColor = true;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.BackgroundImage = global::OOP_CourseWork.Properties.Resources.Background;
            this.tabPageSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageSettings.Controls.Add(this.textBoxPassword);
            this.tabPageSettings.Controls.Add(this.label6);
            this.tabPageSettings.Controls.Add(this.textBoxDriverLicense);
            this.tabPageSettings.Controls.Add(this.maskedTextBoxPhoneNumber);
            this.tabPageSettings.Controls.Add(this.labelSpliter);
            this.tabPageSettings.Controls.Add(this.labelAccountSetupIsCompletedFine);
            this.tabPageSettings.Controls.Add(this.labelAccountSetupIsNotCompleted);
            this.tabPageSettings.Controls.Add(this.label5);
            this.tabPageSettings.Controls.Add(this.textBoxNewPasswordConfirmation);
            this.tabPageSettings.Controls.Add(this.label4);
            this.tabPageSettings.Controls.Add(this.textBoxNewPassword);
            this.tabPageSettings.Controls.Add(this.buttonChangePassword);
            this.tabPageSettings.Controls.Add(this.label2);
            this.tabPageSettings.Controls.Add(this.textBoxOldPassword);
            this.tabPageSettings.Controls.Add(this.label3);
            this.tabPageSettings.Controls.Add(this.labelEmail);
            this.tabPageSettings.Controls.Add(this.textBoxEmail);
            this.tabPageSettings.Controls.Add(this.buttonDeactivateMyAccount);
            this.tabPageSettings.Controls.Add(this.buttonSave);
            this.tabPageSettings.Controls.Add(this.label1);
            this.tabPageSettings.Controls.Add(this.textBoxCardNumber);
            this.tabPageSettings.Controls.Add(this.labelPassport);
            this.tabPageSettings.Controls.Add(this.textBoxPassport);
            this.tabPageSettings.Controls.Add(this.labelDriverLicense);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 34);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(970, 606);
            this.tabPageSettings.TabIndex = 2;
            this.tabPageSettings.Text = " Настройки ";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(85, 66);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(300, 31);
            this.textBoxPassword.TabIndex = 0;
            this.textBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
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
            // textBoxDriverLicense
            // 
            this.textBoxDriverLicense.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxDriverLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDriverLicense.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDriverLicense.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxDriverLicense.Location = new System.Drawing.Point(85, 143);
            this.textBoxDriverLicense.Name = "textBoxDriverLicense";
            this.textBoxDriverLicense.Size = new System.Drawing.Size(300, 31);
            this.textBoxDriverLicense.TabIndex = 1;
            this.textBoxDriverLicense.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDriverLicense.TextChanged += new System.EventHandler(this.textBoxDriverLicense_TextChanged);
            // 
            // maskedTextBoxPhoneNumber
            // 
            this.maskedTextBoxPhoneNumber.BackColor = System.Drawing.Color.AliceBlue;
            this.maskedTextBoxPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBoxPhoneNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxPhoneNumber.Location = new System.Drawing.Point(85, 445);
            this.maskedTextBoxPhoneNumber.Mask = "+375 (99) 000-00-00";
            this.maskedTextBoxPhoneNumber.Name = "maskedTextBoxPhoneNumber";
            this.maskedTextBoxPhoneNumber.Size = new System.Drawing.Size(300, 31);
            this.maskedTextBoxPhoneNumber.TabIndex = 5;
            this.maskedTextBoxPhoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBoxPhoneNumber.TextChanged += new System.EventHandler(this.maskedTextBoxPhoneNumber_TextChanged);
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
            // labelAccountSetupIsCompletedFine
            // 
            this.labelAccountSetupIsCompletedFine.AutoSize = true;
            this.labelAccountSetupIsCompletedFine.BackColor = System.Drawing.Color.Transparent;
            this.labelAccountSetupIsCompletedFine.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelAccountSetupIsCompletedFine.Location = new System.Drawing.Point(611, 401);
            this.labelAccountSetupIsCompletedFine.Name = "labelAccountSetupIsCompletedFine";
            this.labelAccountSetupIsCompletedFine.Size = new System.Drawing.Size(225, 50);
            this.labelAccountSetupIsCompletedFine.TabIndex = 23;
            this.labelAccountSetupIsCompletedFine.Text = "Ваш аккаунт был усешно\r\nактивирован!";
            this.labelAccountSetupIsCompletedFine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelAccountSetupIsCompletedFine.Visible = false;
            // 
            // labelAccountSetupIsNotCompleted
            // 
            this.labelAccountSetupIsNotCompleted.AutoSize = true;
            this.labelAccountSetupIsNotCompleted.BackColor = System.Drawing.Color.Transparent;
            this.labelAccountSetupIsNotCompleted.ForeColor = System.Drawing.Color.Coral;
            this.labelAccountSetupIsNotCompleted.Location = new System.Drawing.Point(569, 376);
            this.labelAccountSetupIsNotCompleted.Name = "labelAccountSetupIsNotCompleted";
            this.labelAccountSetupIsNotCompleted.Size = new System.Drawing.Size(317, 100);
            this.labelAccountSetupIsNotCompleted.TabIndex = 22;
            this.labelAccountSetupIsNotCompleted.Text = "Ваш аккаунт ещё не активирован.\r\nЧтобы активировать его, требуется\r\nввести необхо" +
    "димые данные в\r\nпустых полях.";
            this.labelAccountSetupIsNotCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(600, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(262, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "Подтвердить новый пароль: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNewPasswordConfirmation
            // 
            this.textBoxNewPasswordConfirmation.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxNewPasswordConfirmation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNewPasswordConfirmation.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNewPasswordConfirmation.Location = new System.Drawing.Point(574, 244);
            this.textBoxNewPasswordConfirmation.Name = "textBoxNewPasswordConfirmation";
            this.textBoxNewPasswordConfirmation.Size = new System.Drawing.Size(300, 31);
            this.textBoxNewPasswordConfirmation.TabIndex = 9;
            this.textBoxNewPasswordConfirmation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNewPasswordConfirmation.UseSystemPasswordChar = true;
            this.textBoxNewPasswordConfirmation.TextChanged += new System.EventHandler(this.textBoxNewPasswordConfirmation_TextChanged);
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
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNewPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNewPassword.Location = new System.Drawing.Point(574, 154);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.Size = new System.Drawing.Size(300, 31);
            this.textBoxNewPassword.TabIndex = 8;
            this.textBoxNewPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNewPassword.UseSystemPasswordChar = true;
            this.textBoxNewPassword.TextChanged += new System.EventHandler(this.textBoxNewPassword_TextChanged);
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangePassword.Location = new System.Drawing.Point(643, 296);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(169, 47);
            this.buttonChangePassword.TabIndex = 10;
            this.buttonChangePassword.Text = "Сменить пароль";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
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
            // textBoxOldPassword
            // 
            this.textBoxOldPassword.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxOldPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOldPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOldPassword.Location = new System.Drawing.Point(574, 66);
            this.textBoxOldPassword.Name = "textBoxOldPassword";
            this.textBoxOldPassword.Size = new System.Drawing.Size(300, 31);
            this.textBoxOldPassword.TabIndex = 7;
            this.textBoxOldPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxOldPassword.UseSystemPasswordChar = true;
            this.textBoxOldPassword.TextChanged += new System.EventHandler(this.textBoxOldPassword_TextChanged);
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
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(85, 376);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(300, 31);
            this.textBoxEmail.TabIndex = 4;
            this.textBoxEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // buttonDeactivateMyAccount
            // 
            this.buttonDeactivateMyAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeactivateMyAccount.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonDeactivateMyAccount.Location = new System.Drawing.Point(616, 515);
            this.buttonDeactivateMyAccount.Name = "buttonDeactivateMyAccount";
            this.buttonDeactivateMyAccount.Size = new System.Drawing.Size(231, 43);
            this.buttonDeactivateMyAccount.TabIndex = 11;
            this.buttonDeactivateMyAccount.Text = "Деактивировать аккаунт";
            this.buttonDeactivateMyAccount.UseVisualStyleBackColor = true;
            this.buttonDeactivateMyAccount.Click += new System.EventHandler(this.buttonDeactivateMyAccount_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(154, 506);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(169, 61);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить настройки";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
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
            // textBoxCardNumber
            // 
            this.textBoxCardNumber.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxCardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCardNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCardNumber.Location = new System.Drawing.Point(85, 296);
            this.textBoxCardNumber.Name = "textBoxCardNumber";
            this.textBoxCardNumber.Size = new System.Drawing.Size(300, 31);
            this.textBoxCardNumber.TabIndex = 3;
            this.textBoxCardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCardNumber.TextChanged += new System.EventHandler(this.textBoxCardNumber_TextChanged);
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
            // textBoxPassport
            // 
            this.textBoxPassport.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxPassport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassport.Location = new System.Drawing.Point(85, 216);
            this.textBoxPassport.Name = "textBoxPassport";
            this.textBoxPassport.Size = new System.Drawing.Size(300, 31);
            this.textBoxPassport.TabIndex = 2;
            this.textBoxPassport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPassport.TextChanged += new System.EventHandler(this.textBoxPassport_TextChanged);
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
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(978, 644);
            this.Controls.Add(this.tabControlClient);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.tabControlClient.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlClient;
        private System.Windows.Forms.TabPage tabPageOrdersList;
        private System.Windows.Forms.TabPage tabPagePayments;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageMakeOrder;
        private System.Windows.Forms.Label labelDriverLicense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCardNumber;
        private System.Windows.Forms.Label labelPassport;
        private System.Windows.Forms.TextBox textBoxPassport;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNewPasswordConfirmation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.Button buttonChangePassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOldPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Button buttonDeactivateMyAccount;
        private System.Windows.Forms.Label labelAccountSetupIsNotCompleted;
        private System.Windows.Forms.Label labelAccountSetupIsCompletedFine;
        private System.Windows.Forms.Label labelSpliter;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPhoneNumber;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDriverLicense;
        private System.Windows.Forms.ToolTip toolTipEmail;
        private System.Windows.Forms.ToolTip toolTipPhoneNumber;
        private System.Windows.Forms.ToolTip toolTipCardNumber;
        private System.Windows.Forms.ToolTip toolTipPassword;
    }
}

