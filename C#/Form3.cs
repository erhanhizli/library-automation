using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
In this form, we can learn the user name and password by answering the question.
    */
namespace ErhanHızlı_B1505._090016
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="Ankara" || textBox1.Text == "ankara" || textBox1.Text=="ANKARA")
            {
                MessageBox.Show("Username=admin\nPassword=1234");
                this.Hide();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
