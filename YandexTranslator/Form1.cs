using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YandexTranslator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }
        private YandexTranslator yt = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (yt == null)
            {
                yt = new YandexTranslator();
                yt.Work();
                MessageBox.Show("Finish");  
            }
            else
            {
                MessageBox.Show("It is already running");
            }
        }
    }
}
