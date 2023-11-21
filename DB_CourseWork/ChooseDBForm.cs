using DB_CourseWork.Controls;
using DB_CourseWork.Models;
using System;
using System.Windows.Forms;

namespace DB_CourseWork
{
    partial class ChooseDBForm : Form
    {
        private bool _fullCloseClicked = true;

        public ChooseDBForm()
        {
            InitializeComponent();
        }

        private void ChooseDBForm_Load(object sender, EventArgs e)
        {
            comboBoxDbType.SelectedIndex = 0;

            this.FormClosing += ChooseDBForm_FormClosing;
        }

        private void ChooseDBForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_fullCloseClicked)
            {
                e.Cancel = true;
                Environment.Exit(0);
            }
        }

        private void comboBoxDbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxDbType.Text.ToLower())
            {
                case "csv":   DatabaseContext.DatabaseTypeName = "csv";   DatabaseContext.ChosenDbType = DbType.CSV;   break;
                case "mongo": DatabaseContext.DatabaseTypeName = "mongo"; DatabaseContext.ChosenDbType = DbType.Mongo; break;
                case "sql":   DatabaseContext.DatabaseTypeName = "sql";   DatabaseContext.ChosenDbType = DbType.SQL;   break;
                default:      DatabaseContext.DatabaseTypeName = "";      DatabaseContext.ChosenDbType = DbType.None;  break;
            }
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            if (DatabaseContext.ChosenDbType == DbType.None)
            {
                MessageBox.Show("Вы ничего не выбрали!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _fullCloseClicked = false;
            this.Close();
        }
    }
}
