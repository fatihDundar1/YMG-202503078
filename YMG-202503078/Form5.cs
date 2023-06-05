using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using YMG_202503078;

namespace YMG_202503078
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

     
        private void button1_Click(object sender, EventArgs e)
        { 
            YıllıkYüzdeGetirisi.R = textBox1.Text;
            YıllıkYüzdeGetirisi.N = textBox2.Text;

            Banking banking = new YıllıkYüzdeGetirisi();


            label2.Text = Convert.ToString(banking.bankingCalculate());
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BalonKredi.pv = textBox3.Text;
            BalonKredi.ba = textBox4.Text;
            BalonKredi.R = textBox5.Text;
            BalonKredi.N = textBox6.Text;

            Banking banking = new BalonKredi();

            label6.Text = Convert.ToString(banking.bankingCalculate());
        }


        private void button3_Click(object sender, EventArgs e)
        {
            KredideKalanBakiye.pv = textBox7.Text;
            KredideKalanBakiye.p = textBox8.Text;   
            KredideKalanBakiye.R= textBox9.Text;
            KredideKalanBakiye.N = textBox10.Text;

            Banking banking= new KredideKalanBakiye();

            label8.Text= Convert.ToString(banking.bankingCalculate());
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.Text = "";
            label2.Text = "";
            label6.Text = "";
            label8.Text = "";
        }
    }
}
