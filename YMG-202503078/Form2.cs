using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YMG_202503078;

namespace YMG_202503078
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Form7 form = new Form7();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8();
            form.Show();
        }

        
    }
}
