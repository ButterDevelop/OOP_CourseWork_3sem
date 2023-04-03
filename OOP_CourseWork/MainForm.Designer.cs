namespace OOP_CourseWork
{
    partial class MainForm
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
            this.buttonLoadDB = new System.Windows.Forms.Button();
            this.buttonSaveDB = new System.Windows.Forms.Button();
            this.buttonCreateSomeData = new System.Windows.Forms.Button();
            this.buttonCheckData = new System.Windows.Forms.Button();
            this.buttonClearData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLoadDB
            // 
            this.buttonLoadDB.Location = new System.Drawing.Point(123, 189);
            this.buttonLoadDB.Name = "buttonLoadDB";
            this.buttonLoadDB.Size = new System.Drawing.Size(100, 45);
            this.buttonLoadDB.TabIndex = 0;
            this.buttonLoadDB.Text = "Load DB";
            this.buttonLoadDB.UseVisualStyleBackColor = true;
            this.buttonLoadDB.Click += new System.EventHandler(this.buttonLoadDB_Click);
            // 
            // buttonSaveDB
            // 
            this.buttonSaveDB.Location = new System.Drawing.Point(540, 189);
            this.buttonSaveDB.Name = "buttonSaveDB";
            this.buttonSaveDB.Size = new System.Drawing.Size(103, 45);
            this.buttonSaveDB.TabIndex = 1;
            this.buttonSaveDB.Text = "Save DB";
            this.buttonSaveDB.UseVisualStyleBackColor = true;
            this.buttonSaveDB.Click += new System.EventHandler(this.buttonSaveDB_Click);
            // 
            // buttonCreateSomeData
            // 
            this.buttonCreateSomeData.Location = new System.Drawing.Point(307, 189);
            this.buttonCreateSomeData.Name = "buttonCreateSomeData";
            this.buttonCreateSomeData.Size = new System.Drawing.Size(163, 45);
            this.buttonCreateSomeData.TabIndex = 2;
            this.buttonCreateSomeData.Text = "Create some data";
            this.buttonCreateSomeData.UseVisualStyleBackColor = true;
            this.buttonCreateSomeData.Click += new System.EventHandler(this.buttonCreateSomeData_Click);
            // 
            // buttonCheckData
            // 
            this.buttonCheckData.Location = new System.Drawing.Point(321, 305);
            this.buttonCheckData.Name = "buttonCheckData";
            this.buttonCheckData.Size = new System.Drawing.Size(137, 58);
            this.buttonCheckData.TabIndex = 3;
            this.buttonCheckData.Text = "Check data";
            this.buttonCheckData.UseVisualStyleBackColor = true;
            this.buttonCheckData.Click += new System.EventHandler(this.buttonCheckData_Click);
            // 
            // buttonClearData
            // 
            this.buttonClearData.Location = new System.Drawing.Point(321, 62);
            this.buttonClearData.Name = "buttonClearData";
            this.buttonClearData.Size = new System.Drawing.Size(137, 58);
            this.buttonClearData.TabIndex = 4;
            this.buttonClearData.Text = "Clear data";
            this.buttonClearData.UseVisualStyleBackColor = true;
            this.buttonClearData.Click += new System.EventHandler(this.buttonClearData_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonClearData);
            this.Controls.Add(this.buttonCheckData);
            this.Controls.Add(this.buttonCreateSomeData);
            this.Controls.Add(this.buttonSaveDB);
            this.Controls.Add(this.buttonLoadDB);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadDB;
        private System.Windows.Forms.Button buttonSaveDB;
        private System.Windows.Forms.Button buttonCreateSomeData;
        private System.Windows.Forms.Button buttonCheckData;
        private System.Windows.Forms.Button buttonClearData;
    }
}

