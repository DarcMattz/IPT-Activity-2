using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPT_assignment_2
{
    public partial class Form1 : Form
    {
        public string IDNumber, name, sex, birthdate, civilStatus, picture;
        public DataTable skill = new DataTable();
        public DataTable cert = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.iconButton1.BackColor = Color.BurlyWood;
            Form2 profile = new Form2(this);
            profile.TopLevel = false;
            panel2.Controls.Add(profile);
            profile.Show();
        }
    }
}
