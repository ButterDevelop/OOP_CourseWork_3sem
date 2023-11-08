using DB_CourseWork.Models;
using System;
using System.Windows.Forms;

namespace DB_CourseWork
{
    partial class ChooseDBForm : Form
    {
        private DbType _chosenDbType;

        public ChooseDBForm()
        {
            InitializeComponent();
        }

        private void ChooseDBForm_Load(object sender, EventArgs e)
        {
            this.FormClosing += ChooseDBForm_FormClosing;
            comboBoxDbType.SelectedIndex = 0;
            _chosenDbType = DbType.None;
        }

        private void ChooseDBForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void comboBoxDbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxDbType.Text.ToLower())
            {
                case "csv":   _chosenDbType = DbType.CSV;   break;
                case "mongo": _chosenDbType = DbType.Mongo; break;
                case "sql":   _chosenDbType = DbType.SQL;   break;
                default:      _chosenDbType = DbType.None;  break;
            }
        }


        public DbType ChosenDbType 
        { 
            get { return _chosenDbType; } 
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            if (_chosenDbType == DbType.None)
            {
                MessageBox.Show("Вы ничего не выбрали!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Hide();
        }
    }
}
