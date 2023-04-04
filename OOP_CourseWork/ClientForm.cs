using OOP_CourseWork.Controls;
using OOP_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CourseWork
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();

            MessageBox.Show(SaveLoadControl.CurrentUser.ToString());
        }
    }
}
