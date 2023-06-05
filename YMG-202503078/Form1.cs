using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace YMG_202503078
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-PHKFHU8\\SQLEXPRESS;Initial Catalog=FintechApp;Integrated Security=True");

           

            cmd = new SqlCommand("SELECT * FROM Musteriler WHERE Sifre=sifre AND KullaniciAdi=kullaniciAdi", con);
            cmd.Parameters.AddWithValue("@kullaniciAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("@sifre", textBox2.Text);

            con.Open();

            dr = cmd.ExecuteReader();


            if (dr.Read())
            {

                Form2 frm = new Form2();
                frm.Show();


            }

            else
                MessageBox.Show(" Kullanıcı Adı veya Şifre Hatalı");


            dr.Close();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Form2 frm = new Form2();
            frm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();  
            form3.Show();
        }

       
    }
}
