using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace _19010011077
{
    public partial class ürünekle : Form
    {
        public ürünekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void ürünekle_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand ekle = new OleDbCommand("select ad from kategoriler", baglanti);
            OleDbDataReader oku = ekle.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["ad"].ToString());
            }
            OleDbCommand ekle2 = new OleDbCommand("select ad from markalar", baglanti);
            OleDbDataReader oku2 = ekle2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox2.Items.Add(oku2["ad"].ToString());
            }
            OleDbCommand ekle3 = new OleDbCommand("select ad from modeller", baglanti);
            OleDbDataReader oku3 = ekle3.ExecuteReader();
            while (oku3.Read())
            {
                comboBox3.Items.Add(oku3["ad"].ToString());
            }
            baglanti.Close();
        }

        bool durum;
        private void Hatalar()
        {

            baglanti.Open();  //girilen barkod numarası veritabanında var mı diye bakar,hata mesajı için kullanılır.
            OleDbCommand komut = new OleDbCommand("select*from ürünler where barkodno='" + textBox1.Text + "'", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            baglanti.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Hatalar();
                if (durum == true)
                {
                    baglanti.Open();
                    OleDbCommand ekle = new OleDbCommand("insert into ürünler(barkodno,kategori,marka,model,adet,fiyat,tarih) values('" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value + "')", baglanti);
                    ekle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Ürün eklendi");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show("Bu kayıt zaten mevcut", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }

            }
            catch (Exception acıklama)
            {
                MessageBox.Show(acıklama.Message, "HATA!");
                baglanti.Close();
            }
        }
    }
}
