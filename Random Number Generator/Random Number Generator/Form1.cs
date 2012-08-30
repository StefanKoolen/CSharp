using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Random_Number_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Random r = new Random();
            label5.Text = r.Next(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)).ToString();
            label5.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AboutForm secondForm = new AboutForm();

            secondForm.Show();
        }
    }
}
