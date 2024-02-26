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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private Form1 mainForm = null;
        public Form4(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        void insertData()
        {
            this.mainForm.cert.Columns.Add("Certification");
            this.mainForm.cert.Columns.Add("Certifying Body");
            this.mainForm.cert.Columns.Add("Valid From");
            this.mainForm.cert.Columns.Add("Valid To");
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                this.mainForm.cert.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value);
            }
        }

        bool haveData()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("You still didn't enter your certifications yet.");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (haveData())
            {
                insertData();
                this.mainForm.iconButton3.BackColor = Color.Bisque;
                this.mainForm.iconButton6.BackColor = Color.BurlyWood;
                Form5 result = new Form5(this.mainForm);
                this.Hide();
                result.TopLevel = false;
                this.mainForm.panel2.Controls.Add(result);
                result.Show();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please Enter the Certification and it's Body.", "Error");
                return;
            }
            else if(dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("There's a conflict with the date.", "Error");
                return;
            }
            this.dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, dateTimePicker1.Text, dateTimePicker2.Text);
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
