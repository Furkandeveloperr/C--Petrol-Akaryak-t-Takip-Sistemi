using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Testt_Petroll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        //"

        SqlConnection baglanti = new SqlConnection(@"Data Source = FURKIMYDESKTOP; Initial Catalog = TestBenzin; Integrated Security = True");

      
          
        void listele()
        {
            //kurşunsuz 95
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tblbenzin where petroltur='kurşunsuz95'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblKurşunsuz95.Text = dr[3].ToString();
                progressBar1.Value = int.Parse(dr[4].ToString());
                LblKursunsuz95Litre.Text = dr[4].ToString();
            }
            baglanti.Close();


            //kurşunsuz 97
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from tblbenzin where petroltur='kurşunsuz97'", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblKurşunsuz97.Text = dr2[3].ToString();
                progressBar2.Value = int.Parse(dr2[4].ToString());
                LblKursunsuz97Litre.Text = dr2[4].ToString();
            }
            baglanti.Close();

            //Euro Dizel 10
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select * from tblbenzin where petroltur='EuroDiesel10'", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblEuroDiesel10.Text = dr3[3].ToString();
                progressBar3.Value = int.Parse(dr3[4].ToString());
                LblEuroDizelLitre.Text = dr3[4].ToString();
            }
            baglanti.Close();

            //Yeni Pro Dizel
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select * from tblbenzin where petroltur='YeniProDizel'", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblYeniProDizel.Text = dr4[3].ToString();
                progressBar4.Value = int.Parse(dr4[4].ToString());
                LblYeniProDizelLitre.Text = dr4[4].ToString();
            }
            baglanti.Close();


            //Gaz
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select * from tblbenzin where petroltur='Gaz'", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblGaz.Text = dr5[3].ToString();
                progressBar5.Value = int.Parse(dr5[4].ToString());
                LblGazLitre.Text = dr5[4].ToString();
            }
            baglanti.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)

            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox11.Text);
                komut.Parameters.AddWithValue("@p2", "Kursunsuz95");
                komut.Parameters.AddWithValue("@p3", numericUpDown1.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtKursunsuz95Fiyat.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");

                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(TxtKursunsuz95Fiyat.Text));
                MessageBox.Show("Satış yapıldı");
                baglanti.Close();

                baglanti.Open();
                int a;
                a = Convert.ToInt32(LblKursunsuz95Litre.Text) - Convert.ToInt32(numericUpDown1.Value);
                LblKursunsuz95Litre.Text = a.ToString();

                SqlCommand komut3 = new SqlCommand("update TBLBENZİN set STOK=@p1 where ID='1'", baglanti);
                komut3.Parameters.AddWithValue("@p1", a);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");
                listele();


            }
            else if (numericUpDown2.Value != 0)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox11.Text);
                komut.Parameters.AddWithValue("@p2", "Kursunsuz97");
                komut.Parameters.AddWithValue("@p3", numericUpDown2.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtKursunsuz97Fiyat.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");

                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar=mıktar+@p2", baglanti);
                komut2.Parameters.AddWithValue("@p2", decimal.Parse(TxtKursunsuz97Fiyat.Text));
                MessageBox.Show("Satış yapıldı");
                baglanti.Close();

                baglanti.Open();
                int a;
                a = Convert.ToInt32(LblKursunsuz97Litre.Text) - Convert.ToInt32(numericUpDown2.Value);
                LblKursunsuz97Litre.Text = a.ToString();

                SqlCommand komut3 = new SqlCommand("update TBLBENZİN set STOK=@p2 where ID='2'", baglanti);
                komut3.Parameters.AddWithValue("@p2", a);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");
                listele();
            }
            else if (numericUpDown3.Value != 0)
            {

                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox11.Text);
                komut.Parameters.AddWithValue("@p2", "EuroDiesel10");
                komut.Parameters.AddWithValue("@p3", numericUpDown3.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtEuroDizelFiyat.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");

                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", baglanti);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse(TxtEuroDizelFiyat.Text));
                MessageBox.Show("Satış yapıldı");
                baglanti.Close();

                baglanti.Open();
                int a;
                a = Convert.ToInt32(LblEuroDizelLitre.Text) - Convert.ToInt32(numericUpDown3.Value);
                LblEuroDizelLitre.Text = a.ToString();

                SqlCommand komut3 = new SqlCommand("update TBLBENZİN set STOK=@p3 where ID='3'", baglanti);
                komut3.Parameters.AddWithValue("@p3", a);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");
                listele();
            }
            else if (numericUpDown4.Value != 0)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox11.Text);
                komut.Parameters.AddWithValue("@p2", "YeniProDizel");
                komut.Parameters.AddWithValue("@p3", numericUpDown4.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtProDizelFiyat.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");

                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", baglanti);
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(TxtProDizelFiyat.Text));
                MessageBox.Show("Satış yapıldı");
                baglanti.Close();

                baglanti.Open();
                int a;
                a = Convert.ToInt32(LblYeniProDizelLitre.Text) - Convert.ToInt32(numericUpDown4.Value);
                LblYeniProDizelLitre.Text = a.ToString();

                SqlCommand komut3 = new SqlCommand("update TBLBENZİN set STOK=@p4 where ID='4'", baglanti);
                komut3.Parameters.AddWithValue("@p4", a);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");
                listele();
            }
            else if (numericUpDown5.Value != 0)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox11.Text);
                komut.Parameters.AddWithValue("@p2", "Gaz");
                komut.Parameters.AddWithValue("@p3", numericUpDown5.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtGazFiyat.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");

                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", baglanti);
                komut2.Parameters.AddWithValue("@p5", decimal.Parse(TxtGazFiyat.Text));
                MessageBox.Show("Satış yapıldı");
                baglanti.Close();

                baglanti.Open();
                int a;
                a = Convert.ToInt32(LblGazLitre.Text) - Convert.ToInt32(numericUpDown5.Value);
                LblGazLitre.Text = a.ToString();

                SqlCommand komut3 = new SqlCommand("update TBLBENZİN set STOK=@p5 where ID='5'", baglanti);
                komut3.Parameters.AddWithValue("@p5", a);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");
                listele();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            listele();



        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(LblKurşunsuz95.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunsuz95 * litre;
            TxtKursunsuz95Fiyat.Text = tutar.ToString();
            label23.Text = TxtKursunsuz95Fiyat.Text;

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz97, litre, tutar;
            kursunsuz97 = Convert.ToDouble(LblKurşunsuz97.Text);
            litre = Convert.ToDouble(numericUpDown2.Value);
            tutar = kursunsuz97 * litre;
            TxtKursunsuz97Fiyat.Text = tutar.ToString();
            label23.Text = TxtKursunsuz97Fiyat.Text;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
             double eurodizel, litre, tutar;
            eurodizel = Convert.ToDouble(LblEuroDiesel10.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = eurodizel * litre;
            TxtEuroDizelFiyat.Text = tutar.ToString();
            label23.Text = TxtEuroDizelFiyat.Text;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double prodizel, litre, tutar;
            prodizel = Convert.ToDouble(LblYeniProDizel.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = prodizel * litre;
            TxtProDizelFiyat.Text = tutar.ToString();
            label23.Text = TxtProDizelFiyat.Text;
        
       }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

            double gaz, litre, tutar;
            gaz = Convert.ToDouble(LblGaz.Text);
            litre = Convert.ToDouble(numericUpDown5.Value);
            tutar = gaz * litre;
            TxtGazFiyat.Text = tutar.ToString();
            label23.Text = TxtGazFiyat.Text;


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
