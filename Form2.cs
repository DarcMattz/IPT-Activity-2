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
    public partial class Form2 : Form
    {
        string path = string.Empty;

        private Form1 mainForm = null;
        public Form2(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        bool insertData()
        {
            if (isNotEmpty(textBox1.Text) && isNotEmpty(textBox2.Text) && isNotEmpty(comboBox1.Text) && isNotEmpty(path))
            {
                this.mainForm.IDNumber = textBox1.Text;
                this.mainForm.name = textBox2.Text;
                if (radioButton1.Checked) this.mainForm.sex = "Male";
                if (radioButton2.Checked) this.mainForm.sex = "Female";
                this.mainForm.birthdate = dateTimePicker1.Text;
                this.mainForm.civilStatus = comboBox1.Text;
                this.mainForm.picture = path;
                return true;
            }
            else
            {
                string message = "Please fill all the form to proceed!";
                MessageBox.Show(message, "Error");
                return false;
            }
            return true;
        }

        bool isNotEmpty(string data)
        {
            if(data == "") return false;
            else return true;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (insertData())
            {
                this.mainForm.iconButton1.BackColor = Color.Bisque;
                this.mainForm.iconButton2.BackColor = Color.BurlyWood;
                Form3 skills = new Form3(this.mainForm);
                this.Hide();
                skills.TopLevel = false;
                this.mainForm.panel2.Controls.Add(skills);
                skills.Show();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                path = open.FileName;
            }
        }
    }
}
