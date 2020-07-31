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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Mayin_tarlasi mayin_tarlamiz;
        List<Mayin> mayinlarimiz;
        int bulunan_temiz_alan;
        int sayac;
        int ilkdeger;
        bool durum=false;
        bool final = false;
        

        private void Form1_Load(object sender, EventArgs e)
        {
          

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
            Mayinlari_goster();
        }
        public void yeni_oyun_baslat(int mayinsayisi)
        {
            lbl_durum.Text = "";
            mayin_tarlamiz = new Mayin_tarlasi(new Size(220, 220),mayinsayisi);//boyutu belirleme
            panel1.Size = mayin_tarlamiz.buyuklugu;
            bulunan_temiz_alan = 0;
            Mayin_ekle();
        }
        public void Mayin_ekle()
        {
            for (int x = 0; x < panel1.Width; x = x + 20)
            {
                for (int y = 0; y < panel1.Height; y = y + 20)
                {
                   
                    Button_ekle(new Point(x, y));
                }
            }
        }
        public void Button_ekle(Point loc)
        {
            Button btn = new Button();
            btn.Name =  loc.X +"" + loc.Y;
            btn.Size = new Size(20, 20);
            btn.Location = loc;
            btn.BackColor = Color.Gray;
            btn.ForeColor = Color.Black;
            btn.Click += new EventHandler(btn_Click);
            panel1.Controls.Add(btn);
        }

        

        public void btn_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            Mayin myn = mayin_tarlamiz.mayin_al_loc(btn.Location);
            durum = true;
            mayinlarimiz = new List<Mayin>();
            if (myn.mayin_var_mi)
            {   
                MessageBox.Show("Oyun Bitti");
                Mayinlari_goster();
               
            }
            else  
            
            {
                btn.BackColor = Color.Green;
                int s=etrafta_kac_mayin_var(myn);
                if (s== 0)
                {

                    mayinlarimiz.Add(myn);
                    for (int i = 0; i < mayinlarimiz.Count; i++)
                    {
                        Mayin item = mayinlarimiz[i];
                        if (item != null)
                        {
                            if (item.bakildi_==false&&item.mayin_var_mi==false)
                            {
                               Button btnx = (Button)panel1.Controls.Find(item.konum_al.X + "" + item.konum_al.Y, false)[0];
                                if (etrafta_kac_mayin_var(mayinlarimiz[i]) == 0)
                                {

                                    btnx.Enabled = false;

                                  
                                }
                                else
                                {
                                    btnx.Text = etrafta_kac_mayin_var(item).ToString();

                                }
                                bulunan_temiz_alan++;
                                item.bakildi_ = true;
                            }
                        }
                    }
                }
                else 
                {
                    btn.Text = s.ToString();
                    bulunan_temiz_alan++;
                }

            }
            if (bulunan_temiz_alan >= mayin_tarlamiz.toplam_alan - mayin_tarlamiz.toplam_mayin_sayisi)
            {
                final = true;
                MessageBox.Show("Tebrikler kazandınız");
               
            }
        }
        public int etrafta_kac_mayin_var(Mayin m)
        {
            int sayi = 0;
            if (m.konum_al.X > 0)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.Y < panel1.Height-20&&m.konum_al.X<panel1.Width-20)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y + 20)).mayin_var_mi)
                {
                    sayi++;

                }
            }
            if (m.konum_al.X <panel1.Width-20)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.X > 0&&m.konum_al.Y>0)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y - 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.Y > 0)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X, m.konum_al.Y - 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.X > 0&&m.konum_al.Y<panel1.Height-20)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y + 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.Y < panel1.Height-20)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X, m.konum_al.Y + 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.X > panel1.Width-20&&m.konum_al.Y>0)
            {
                if (mayin_tarlamiz.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y - 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }

            return sayi;
        }
       
        public void Mayinlari_goster()
        {
            foreach (Mayin item in mayin_tarlamiz.GetAllMayin)
            {
                if (item.mayin_var_mi)
                {
                  Button btn =  (Button)panel1.Controls.Find(item.konum_al.X + "" + item.konum_al.Y,false)[0];
                    btn.BackColor = Color.Red;
                    btn.ForeColor = Color.Red;
                  
                }
                
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            panel1.Controls.Clear();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
           // f2.Show();
            timerSure.Start();
            sayac =(int) numSure.Value;
            ilkdeger = (int)numSure.Value;
          
            labelSure.Text ="kalan sure :    " +sayac.ToString();
            int sayi = (int)numMayin.Value;
            yeni_oyun_baslat(sayi);
            DialogResult sonuc = new DialogResult();
            sonuc = MessageBox.Show("Yeni oyuna başlamak ister misiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if(sonuc==DialogResult.Yes)
            {
                panel1.Controls.Clear();
                yeni_oyun_baslat(sayi);
            }
           
           //f2.Show();


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int sayi1 = Convert.ToInt32(txtAlt.Text);
            int sayi2 = Convert.ToInt32(txtUst.Text);
            for (int i = sayi1; i < sayi2; i++)
            {
                int a = i / 100;
                int b = (i - a * 100) / 10;
                int c = (i - a * 100 - b * 10);

                int d = a * a * a + b * b * b + c * c * c;

                if (i == d)
                    listBox1.Items.Add(i);
            }

        }

        public void timerSure_Tick(object sender, EventArgs e)
        {
            sayac--;
            labelSure.Text ="kalan sure:   "+ sayac.ToString();
            if (durum == true)
            {
                sayac = ilkdeger;
            }
            if(final == true)
            {
                timerSure.Stop();
                labelSure.Text = "kalan sure:   " + sayac.ToString();

            }
            durum = false;
            if (sayac == 0)
            {
                Mayinlari_goster();
                timerSure.Stop();
                
                MessageBox.Show("Oyun Bitti");
               
                
               
            }
        }
    }
    }
    
