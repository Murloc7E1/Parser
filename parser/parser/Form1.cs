using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parser
{
    public partial class Fotm1 : Form
    {
        CurrentParser p;
        public Fotm1()
        {
            InitializeComponent();
            p = new CurrentParser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string res = p.pars();
                richTextBox1.Text = res;
            }
            catch
            {
                MessageBox.Show("Возникла ошибка\nВозможно нет подключения к сети!!!");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {

            }
            else
            {
               MessageBox.Show("Заполните оба поля!!!");
            }
        }
    }
}
