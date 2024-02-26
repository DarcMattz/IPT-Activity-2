using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace IPT_assignment_2
{
    public partial class Form5 : Form
    {
        private Form1 mainForm = null;
        public Form5(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.mainForm.skill;
            dataGridView2.DataSource = this.mainForm.cert;
            label2.Text = this.mainForm.IDNumber;
            label3.Text = this.mainForm.name;
            label4.Text = this.mainForm.sex;
            label5.Text = this.mainForm.birthdate;
            label6.Text = this.mainForm.civilStatus;
            pictureBox1.Image = new Bitmap(this.mainForm.picture);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.mainForm.iconButton6.BackColor = Color.Bisque;
            this.mainForm.iconButton1.BackColor = Color.BurlyWood;
            Form2 skill = new Form2(this.mainForm);
            this.Hide();
            skill.TopLevel = false;
            this.mainForm.panel2.Controls.Add(skill);
            skill.Show();
        }
    }
}
