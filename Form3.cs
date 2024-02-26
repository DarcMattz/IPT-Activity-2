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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private Form1 mainForm = null;
        public Form3(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        void insertData()
        {
            this.mainForm.skill.Columns.Add("Skills");
            this.mainForm.skill.Columns.Add("Level of Composition");
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                this.mainForm.skill.Rows.Add(row.Cells[0].Value, row.Cells[1].Value);
            }
        }

        bool haveData()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("You still didn't enter your skills yet.");
                return false;
            }
            return true;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            
            if(haveData())
            {
                insertData();
                this.mainForm.iconButton2.BackColor = Color.Bisque;
                this.mainForm.iconButton3.BackColor = Color.BurlyWood;
                Form4 certificate = new Form4(this.mainForm);
                this.Hide();
                certificate.TopLevel = false;
                this.mainForm.panel2.Controls.Add(certificate);
                certificate.Show();
            } 
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please Enter the Skill and it's Level.", "Error");
            }
            else
            {
                this.dataGridView1.Rows.Add(textBox1.Text, comboBox1.Text);
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row);
                }
            }
        }
    }
}
