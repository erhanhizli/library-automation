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
We can pass this form to our other form when the username and password with login panel is correct.
To find out the username and password we can press 'Forgot password' and go to the password learning screen.
    */
namespace ErhanHızlı_B1505._090016
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            if (textBox1.Text == "admin" && textBox2.Text == "1234")
            {
                f2.Show();
                this.Hide();
            }
            else
                MessageBox.Show("username or password wrong ");
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
