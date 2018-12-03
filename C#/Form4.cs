using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using Microsoft.Win32;
/*
This form can be registered by entering the information on the registration form this form. 
Created records will be stored in the database.  */
namespace ErhanHızlı_B1505._090016
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            DatabaseHelper.CreateIfNotExists(connString);
        }

        private static string GetInstanceName()
        {
            string ins = null;
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    ins = Environment.MachineName + @"\" + instanceKey.GetValueNames().FirstOrDefault();
                }
            }
            return ins;

        }
        //SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0DI0N96\\SQLEXPRESS01;Integrated Security=SSPI;Initial Catalog=library");
        static string connString = String.Format("Data Source={0};Integrated Security=SSPI;Initial Catalog=library", GetInstanceName());  
        SqlConnection baglanti = new SqlConnection(connString);

        private void verikaydet() {
         baglanti.Open();
           

            string kayit = "insert into books values (@b_type,@b_name,@b_author,@b_code,@b_price,@b_stock)";
            
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            
            komut.Parameters.AddWithValue("@b_type", textBox1.Text);
            komut.Parameters.AddWithValue("@b_name", textBox2.Text);
            komut.Parameters.AddWithValue("@b_author", textBox3.Text);
            komut.Parameters.AddWithValue("@b_code", textBox4.Text);
            komut.Parameters.AddWithValue("@b_price", textBox5.Text);
            komut.Parameters.AddWithValue("@b_stock", textBox6.Text);
            
            
            komut.ExecuteNonQuery();
            

            baglanti.Close();
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!="" && textBox3.Text!="" && textBox4.Text!="" && textBox5.Text!="" && textBox6.Text != "")
            {
                verikaydet();
                MessageBox.Show("Saved");
            }
            else
                MessageBox.Show("Please enter all information!");
               }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
