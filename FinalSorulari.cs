using System;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using Hesaplama.dll;

/*
Formun loadında textBoxların visiblesini false yap. Registry oluştur dosya içinde dosya şeklinde ve bi şifresi olsun.
button tıklaması ile şifre istiyor. şifre ynalışsa registry dosyalarını sil.
şifre doğru ise button visible'sini true yap.
başka bir button tıklaması ile array liste veri aktarıcaz.
dll ile ortalama hesapla ve textBoxa yaz.
button tıklaması ile veritabanına ekle.
Button tıklaması ile rastgele bir kişinin bilgileirni textBoxlara yazdır.
*/

namespace WindowsFormsApp72
{
    public partial class Form1 : Form
    {
        Formun loadında textBoxların visiblesini false yap. Registry oluştur dosya içinde dosya şeklinde ve bi şifresi olsun.
button tıklaması ile şifre istiyor. şifre ynalışsa registry dosyalarını sil.
şifre doğru ise button visible'sini true yap.
başka bir button tıklaması ile array liste veri aktarıcaz.
dll ile ortalama hesapla ve textBoxa yaz.
button tıklaması ile veritabanına ekle.
Button tıklaması ile rastgele bir kişinin bilgileirni textBoxlara yazdır.
*/
        // DLL İÇERİĞİ 
        /*
         * public class Hesap
         * {
         *      public double ortalama(int vize, int final)
         *      {
         *      return ((double)vize*0.4 + (double)final*0.6;
         *      }
         *  }
         */
        SqlConnection con = new SqlConnection("DataSource=Destkop;inital Catalog=tablo");
        Hesap hsb = new Hesap();
        bool aktif = false;
        int sifre = 2001;

        public Form1()
        {
            InitializeComponent();
        }

        void textler()
        {
            textBox1.Visible = aktif;
            textBox2.Visible = aktif;
            textBox3.Visible = aktif;
            textBox4.Visible = aktif;
            textBox5.Visible = aktif;
            textBox6.Visible = aktif;
            textBox7.Visible = aktif;
            textBox8.Visible = aktif;
            textBox9.Visible = aktif;
            textBox10.Visible = aktif;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Registry.CurrentUser.CreateSubKey("dosya1").CreateSubKey("dosya2").SetValue("Bora", sifre);
            textler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sifre = int.Parse(Interaction.InputBox("Sifre", ""));
            if (sifre != (int)Registry.CurrentUser.OpenSubKey("dosya1").OpenSubKey("dosya2").GetValue("Bora"))
                Registry.CurrentUser.DeleteSubKeyTree("dosya1");
            else
            {
                aktif = true;
                textler();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArrayList al = new ArrayList();
            al.Add(textBox1.Text);
            al.Add(textBox2.Text);
            al.Add(textBox3.Text);
            al.Add(textBox4.Text);
            al.Add(textBox5.Text);
            al.Add(textBox6.Text);
            al.Add(textBox7.Text);
            al.Add(textBox8.Text);
            al.Add(textBox9.Text);
            al.Add(textBox10.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox10.Visible == true)
                textBox10.Text = hsb.ortalama(int.Parse(textBox8.Text), int.Parse(textBox9.Text));

            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into ogrenci Values(" + textBox1.Text + "," + textBox2.Text + ",'" + textBox3.Text + "'," + textBox4.Text + "," + textBox5.Text + "," + textBox6.Text + "," + textBox7.Text + "," + textBox8.Text + "," + textBox9.Text + "," + textBox10.Text + ")", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from ogrenci where id=1",con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox1.Text = dr[1].ToString();
                textBox1.Text = dr[2].ToString();
                textBox1.Text = dr[3].ToString();
                textBox1.Text = dr[4].ToString();
                textBox1.Text = dr[5].ToString();
                textBox1.Text = dr[6].ToString();
                textBox1.Text = dr[7].ToString();
                textBox1.Text = dr[8].ToString();
                textBox1.Text = dr[9].ToString();
                textBox1.Text = dr[10].ToString();
            }
            con.Close();

        }
    }
}
