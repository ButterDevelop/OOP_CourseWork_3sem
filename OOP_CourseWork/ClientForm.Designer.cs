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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.tabControlClient = new System.Windows.Forms.TabControl();
            this.tabPageOrdersList = new System.Windows.Forms.TabPage();
            this.tabPagePayments = new System.Windows.Forms.TabPage();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.tabPageMakeOrder = new System.Windows.Forms.TabPage();
            this.tabControlClient.SuspendLayout();
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
            this.tabPageSettings.Location = new System.Drawing.Point(4, 34);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(970, 606);
            this.tabPageSettings.TabIndex = 2;
            this.tabPageSettings.Text = " Настройки ";
            this.tabPageSettings.UseVisualStyleBackColor = true;
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
            this.tabControlClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlClient;
        private System.Windows.Forms.TabPage tabPageOrdersList;
        private System.Windows.Forms.TabPage tabPagePayments;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageMakeOrder;
    }
}

