using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YMG_202503078
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gelecektekiDeğer.p = textBox1.Text;
            gelecektekiDeğer.R=textBox2.Text;
            gelecektekiDeğer.N=textBox3.Text;

            GeneralFinance generalFinance = new gelecektekiDeğer();
            label5.Text= Convert.ToString(generalFinance.generalFinanceCalculate());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            İkiyeKatlamaSüresi.R= textBox4.Text;
            GeneralFinance generalFinance = new İkiyeKatlamaSüresi();
            label8.Text = Convert.ToString(generalFinance.generalFinanceCalculate());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnüiteninBugünküDeğeri.p = textBox1.Text;
            AnüiteninBugünküDeğeri.R = textBox2.Text;
            AnüiteninBugünküDeğeri.N = textBox3.Text;

            GeneralFinance generalFinance = new AnüiteninBugünküDeğeri();
            label16.Text = Convert.ToString(generalFinance.generalFinanceCalculate());
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.Text = "";
            label5.Text = "";
            label8.Text = "";
            label16.Text = "";
        }
    }
}
