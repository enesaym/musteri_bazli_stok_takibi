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
    public partial class pesinsatis : Form
    {
        public pesinsatis()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void pesinsatis_Load(object sender, EventArgs e)
        {

        }
        int a, b, c;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToInt32(textBox2.Text);
                baglanti.Open();
                OleDbCommand yap = new OleDbCommand("select * from ürünler where barkodno='" + textBox1.Text + "'", baglanti);
                OleDbDataReader oku = yap.ExecuteReader();
                while (oku.Read())
                {
                    b = Convert.ToInt32(oku["adet"].ToString());
                    c = b - a;
                }
                baglanti.Close();
                baglanti.Open();
                OleDbCommand sat = new OleDbCommand("update ürünler set adet='" + c + "'where barkodno='" + textBox1.Text + "'", baglanti);
                sat.ExecuteNonQuery();
                baglanti.Close();
                baglanti.Open();
                OleDbCommand sat_log = new OleDbCommand("insert into satislar(barkodno,ürünadi,tarih,fiyat,adet) values('" + textBox1.Text + "','" + comboBox2.Text + " " + comboBox3.Text + "','" + dateTimePicker1.Value + "','" + textBox3.Text + "','" + textBox2.Text + "')", baglanti);
                sat_log.ExecuteNonQuery();
                baglanti.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                MessageBox.Show("Ürün satıldı");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();

            }



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
            }
            baglanti.Close();
        }
    }
}
