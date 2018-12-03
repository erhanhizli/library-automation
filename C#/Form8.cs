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
We use this form to delete data from the database. 
*/
namespace ErhanHızlı_B1505._090016
{
    public partial class Form8 : Form
    {
        public Form8()
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
        private void verisil()
        {
            baglanti.Open();

            string sil = "delete from books where b_name='"+textBox1.Text+"'";

            SqlCommand komut = new SqlCommand(sil, baglanti);
            
            komut.ExecuteNonQuery();

            MessageBox.Show("Book deleted.");
            textBox1.Clear();
            baglanti.Close();

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verisil();
        }

      

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Show();
            this.Hide();
        }
    }
}
