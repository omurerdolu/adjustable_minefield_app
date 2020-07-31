using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MehmetOmurErdolu153311035
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       
        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Mayinlari_goster();
            f1.Mayin_ekle();
            
            




        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
