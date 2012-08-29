using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phone_Cost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AboutForm secondFrom = new AboutForm();
            secondFrom.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label9.Visible = false;
            label10.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int kprijs = Convert.ToInt32(textBox1.Text);
            int zprijs = Convert.ToInt32(textBox2.Text);
            int tprijs = Convert.ToInt32(textBox5.Text);
            int kperiode = Convert.ToInt32(textBox3.Text);
            int zperiode = Convert.ToInt32(textBox4.Text);
            int totaal = 0;

            if (kprijs > 0.9 && zprijs > 0.9)
            {
                if (kperiode > 1 && zperiode > 1)
                {

                    totaal = kprijs * kperiode + zprijs * zperiode + tprijs;
                    label9.Text = totaal.ToString();                   
                    label9.Visible = true;
                    label10.Visible = true;
                }
                else MessageBox.Show("Controleer of je de velden goed hebt ingevuld!");
            }
            else MessageBox.Show("Controleer of je de velden goed hebt ingevuld!");
         }
    }
}