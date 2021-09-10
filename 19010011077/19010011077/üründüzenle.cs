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
    public partial class üründüzenle : Form
    {
        public üründüzenle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void üründüzenle_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand yap = new OleDbCommand("select * from ürünler where barkodno='" + textBox1.Text + "'", baglanti);
            OleDbDataReader oku = yap.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Text = oku["kategori"].ToString();
                comboBox2.Text = oku["marka"].ToString();
                comboBox3.Text = oku["model"].ToString();
                textBox2.Text= oku["adet"].ToString();
                textBox3.Text= oku["fiyat"].ToString();
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti.Open();
                OleDbCommand güncelle = new OleDbCommand("update ürünler set adet='" + textBox2.Text + "',tarih='" + dateTimePicker1.Value + "',fiyat='" + textBox3.Text + "'where barkodno='" + textBox1.Text + "'", baglanti);
                güncelle.ExecuteNonQuery();
                baglanti.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                MessageBox.Show("Ürün güncellendi");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!");
                baglanti.Close();

            }
        }
    }
    
}
