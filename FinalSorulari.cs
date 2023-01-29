using System;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
using Microsoft.Win32;
using Hesaplama.dll;

namespace WindowsFormsApp73
{
/*
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
    
    public partial class Form1 : Form
    {
        Hesap hsb = new Hesap();
        SqlConnection con = new SqlConnection();
        int sifre = 2001;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;

            Registry.CurrentUser.CreateSubKey("dosya1").CreateSubKey("dosya2").SetValue("emre", sifre);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kullanici = int.Parse(Interaction.InputBox("Şifre gir", "Sifre"));
            if (sifre == kullanici)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
            }
            else Registry.CurrentUser.DeleteSubKeyTree("dosya1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArrayList al = new ArrayList();

            al.Add(textBox1.Text);
            al.Add(textBox2.Text);
            al.Add(textBox3.Text);
            al.Add(textBox4.Text);
            al.Add(textBox5.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int vize = Convert.ToInt32(textBox3.Text);
            int final = Convert.ToInt32(textBox4.Text);

            textBox5.Text = hsb.ortalama(vize, final).ToString();

            con.Open();
            string cumle = String.Format("Insert into tablo values({0},'{1}',{2},{3},{4})", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            SqlCommand cmd = new SqlCommand(cumle, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from tablo where id=1", con);
            SqlDataReader dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox5.Text = dr[4].ToString();
            }
            con.Close();
        }
    }
}
