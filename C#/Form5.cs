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
In this form, we can access the information in the database and change the order of the data that we receive.*/
namespace ErhanHızlı_B1505._090016
{
    public partial class Form5 : Form
    {
        public Form5()
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

        private void verigir()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Books", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["b_type"].ToString();
                ekle.SubItems.Add(oku["b_name"].ToString());
                ekle.SubItems.Add(oku["b_author"].ToString());
                ekle.SubItems.Add(oku["b_code"].ToString());
                ekle.SubItems.Add(oku["b_price"].ToString());
                ekle.SubItems.Add(oku["b_stock"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button4.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Hide();
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Books where b_type  like '%" + textBox1.Text +
                "%' or b_name like '%" + textBox2.Text +
                "%' or b_author like '%" + textBox3.Text +
                "%' or b_code like '%" + textBox4.Text +
                "%' or b_price like '%" + textBox5.Text + 
                "%' or b_stock like '%" + textBox6.Text + 
                "%' ", baglanti);
            
   
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["b_type"].ToString();
                ekle.SubItems.Add(oku["b_name"].ToString());
                ekle.SubItems.Add(oku["b_author"].ToString());
                ekle.SubItems.Add(oku["b_code"].ToString());
                ekle.SubItems.Add(oku["b_price"].ToString());
                ekle.SubItems.Add(oku["b_stock"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();


        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            verigir();
            button4.Show();
            button7.Show();
            button6.Show();
            button8.Show();
            button9.Show();
            button10.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
                fr2.Show();
            this.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Books order by b_price", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["b_type"].ToString();
                ekle.SubItems.Add(oku["b_name"].ToString());
                ekle.SubItems.Add(oku["b_author"].ToString());
                ekle.SubItems.Add(oku["b_code"].ToString());
                ekle.SubItems.Add(oku["b_price"].ToString());
                ekle.SubItems.Add(oku["b_stock"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "-";
            textBox2.Text = "-";
            textBox3.Text = "-";
            textBox4.Text = "-";
            textBox5.Text = "-";
            textBox6.Text = "-";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Books order by b_type ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["b_type"].ToString();
                ekle.SubItems.Add(oku["b_name"].ToString());
                ekle.SubItems.Add(oku["b_author"].ToString());
                ekle.SubItems.Add(oku["b_code"].ToString());
                ekle.SubItems.Add(oku["b_price"].ToString());
                ekle.SubItems.Add(oku["b_stock"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Books order by b_name", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["b_type"].ToString();
                ekle.SubItems.Add(oku["b_name"].ToString());
                ekle.SubItems.Add(oku["b_author"].ToString());
                ekle.SubItems.Add(oku["b_code"].ToString());
                ekle.SubItems.Add(oku["b_price"].ToString());
                ekle.SubItems.Add(oku["b_stock"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Books order by b_author", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["b_type"].ToString();
                ekle.SubItems.Add(oku["b_name"].ToString());
                ekle.SubItems.Add(oku["b_author"].ToString());
                ekle.SubItems.Add(oku["b_code"].ToString());
                ekle.SubItems.Add(oku["b_price"].ToString());
                ekle.SubItems.Add(oku["b_stock"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Books order by b_code", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["b_type"].ToString();
                ekle.SubItems.Add(oku["b_name"].ToString());
                ekle.SubItems.Add(oku["b_author"].ToString());
                ekle.SubItems.Add(oku["b_code"].ToString());
                ekle.SubItems.Add(oku["b_price"].ToString());
                ekle.SubItems.Add(oku["b_stock"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Books order by b_stock", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["b_type"].ToString();
                ekle.SubItems.Add(oku["b_name"].ToString());
                ekle.SubItems.Add(oku["b_author"].ToString());
                ekle.SubItems.Add(oku["b_code"].ToString());
                ekle.SubItems.Add(oku["b_price"].ToString());
                ekle.SubItems.Add(oku["b_stock"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
