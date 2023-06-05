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

namespace YMG_202503078
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private void Form3_Load(object sender, EventArgs e)
        {
            label4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox2.Text.Equals(textBox3.Text))
            {
                label4.Text = "Şifreniz ile şifre tekrarı uyuşmuyor";     
            }

            else
            {
                con = new SqlConnection("Data Source=DESKTOP-PHKFHU8\\SQLEXPRESS;Initial Catalog=FintechApp;Integrated Security=True");
               
                
               


                cmd = new SqlCommand("SELECT * FROM Authenticator WHERE CardNumber=@p3 AND CVV=@p4", con);
                cmd = new SqlCommand("SELECT * FROM Authenticator WHERE Bakiye>500", con);
                cmd.Parameters.AddWithValue("@p3", textBox3.Text);
                cmd.Parameters.AddWithValue("@p4", textBox4.Text);
                
                con.Open();

                dr = cmd.ExecuteReader();    
                if(dr.Read()) 
                {
                    cmd = new SqlCommand("INSERT INTO Musteriler (Sifre,KullaniciAdi) Values (@kullaniciAdi,@sifre)", con);

                    cmd.Parameters.AddWithValue("@kullaniciAdi", textBox1.Text);
                    cmd.Parameters.AddWithValue("@sifre", textBox2.Text);
                    MessageBox.Show("Kayıt oldunuz ve satın aldınız");
                }

                dr.Close();
                con.Close();

            }
        }
    }
}
