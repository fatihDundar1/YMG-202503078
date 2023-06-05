using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace YMG_202503078
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

      

            HisseBaşınaDefter.tÖ = textBox1.Text;
            HisseBaşınaDefter.hS = textBox2.Text;

            StockBond hisseBaşınaDefter = new HisseBaşınaDefter();
            label5.Text = Convert.ToString(hisseBaşınaDefter.stockBondCalculate());   

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SermayeKazançGetirisi.p1 = textBox3.Text;
            SermayeKazançGetirisi.p0 = textBox4.Text;

            StockBond sermayeKazanc = new SermayeKazançGetirisi();
            label9.Text = Convert.ToString(sermayeKazanc.stockBondCalculate());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VergiEşdeğeriGetiri.vG = textBox5.Text;
            VergiEşdeğeriGetiri.vO = textBox6.Text;  

            StockBond vergiEsdeger = new VergiEşdeğeriGetiri();
            label13.Text = Convert.ToString(vergiEsdeger.stockBondCalculate());
        }
    }
}
