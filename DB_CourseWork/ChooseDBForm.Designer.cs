namespace DB_CourseWork
{
    partial class ChooseDBForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseDBForm));
            this.buttonChoose = new System.Windows.Forms.Button();
            this.labelChooseDbType = new System.Windows.Forms.Label();
            this.toolTipUsername = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPassword = new System.Windows.Forms.ToolTip(this.components);
            this.comboBoxDbType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonChoose
            // 
            this.buttonChoose.BackColor = System.Drawing.Color.Transparent;
            this.buttonChoose.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.buttonChoose.FlatAppearance.BorderSize = 2;
            this.buttonChoose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonChoose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChoose.Location = new System.Drawing.Point(85, 76);
            this.buttonChoose.Name = "buttonChoose";
            this.buttonChoose.Size = new System.Drawing.Size(100, 40);
            this.buttonChoose.TabIndex = 2;
            this.buttonChoose.Text = "Выбрать";
            this.buttonChoose.UseVisualStyleBackColor = false;
            this.buttonChoose.Click += new System.EventHandler(this.buttonChoose_Click);
            // 
            // labelChooseDbType
            // 
            this.labelChooseDbType.AutoSize = true;
            this.labelChooseDbType.BackColor = System.Drawing.Color.Transparent;
            this.labelChooseDbType.Location = new System.Drawing.Point(81, 9);
            this.labelChooseDbType.Name = "labelChooseDbType";
            this.labelChooseDbType.Size = new System.Drawing.Size(110, 20);
            this.labelChooseDbType.TabIndex = 4;
            this.labelChooseDbType.Text = "База данных:";
            // 
            // toolTipUsername
            // 
            this.toolTipUsername.AutomaticDelay = 250;
            this.toolTipUsername.AutoPopDelay = 5000;
            this.toolTipUsername.InitialDelay = 250;
            this.toolTipUsername.ReshowDelay = 50;
            this.toolTipUsername.ToolTipTitle = "Имя пользователя";
            // 
            // toolTipPassword
            // 
            this.toolTipPassword.AutomaticDelay = 250;
            this.toolTipPassword.AutoPopDelay = 5000;
            this.toolTipPassword.InitialDelay = 250;
            this.toolTipPassword.ReshowDelay = 50;
            this.toolTipPassword.ToolTipTitle = "Пароль";
            // 
            // comboBoxDbType
            // 
            this.comboBoxDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDbType.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.comboBoxDbType.FormattingEnabled = true;
            this.comboBoxDbType.Items.AddRange(new object[] {
            "CSV",
            "Mongo",
            "SQL"});
            this.comboBoxDbType.Location = new System.Drawing.Point(12, 34);
            this.comboBoxDbType.Name = "comboBoxDbType";
            this.comboBoxDbType.Size = new System.Drawing.Size(250, 33);
            this.comboBoxDbType.TabIndex = 5;
            this.comboBoxDbType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDbType_SelectedIndexChanged);
            // 
            // ChooseDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DB_CourseWork.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(278, 124);
            this.Controls.Add(this.comboBoxDbType);
            this.Controls.Add(this.labelChooseDbType);
            this.Controls.Add(this.buttonChoose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseDBForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тип БД";
            this.Load += new System.EventHandler(this.ChooseDBForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChoose;
        private System.Windows.Forms.Label labelChooseDbType;
        private System.Windows.Forms.ToolTip toolTipUsername;
        private System.Windows.Forms.ToolTip toolTipPassword;
        private System.Windows.Forms.ComboBox comboBoxDbType;
    }
}