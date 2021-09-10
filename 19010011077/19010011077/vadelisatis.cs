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
    public partial class vadelisatis : Form
    {
        public vadelisatis()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand yap = new OleDbCommand("select * from müşteriler where tc='" + textBox1.Text + "'", baglanti);
            OleDbDataReader oku = yap.ExecuteReader();
            while (oku.Read())
            {
                textBox2.Text = oku["ad"].ToString();
                textBox3.Text = oku["soyad"].ToString();
                textBox4.Text = oku["tel"].ToString();
                textBox5.Text = oku["adres"].ToString();
                textBox6.Text = oku["email"].ToString();
            }
            baglanti.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand yap2 = new OleDbCommand("select * from ürünler where barkodno='" + textBox7.Text + "'", baglanti);
            OleDbDataReader oku2 = yap2.ExecuteReader();
            while (oku2.Read())
            {
                textBox8.Text = oku2["kategori"].ToString();
                textBox9.Text = oku2["marka"].ToString();
                textBox10.Text = oku2["model"].ToString();
            }
            baglanti.Close();
        }
        int a, b, c,w;

        private void vadelisatis_Load(object sender, EventArgs e)
        {

        }

        float x, y, z,toplam;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                x = Convert.ToInt32(textBox11.Text);
                y = Convert.ToInt32(textBox12.Text);
                z = x * y;
                baglanti.Open();
                OleDbCommand yapma = new OleDbCommand("select * from müşteriler where tc='" + textBox1.Text + "'", baglanti);
                OleDbDataReader okuma = yapma.ExecuteReader();
                while (okuma.Read())
                {
                    w = Convert.ToInt32(okuma["borc"]);
                    toplam = z + w;
                }
                baglanti.Close();
                baglanti.Open();
                OleDbCommand satma = new OleDbCommand("update müşteriler set borc='" + toplam + "'where tc='" + textBox1.Text + "'", baglanti);
                satma.ExecuteNonQuery();
                baglanti.Close();
                a = Convert.ToInt32(textBox11.Text);
                baglanti.Open();
                OleDbCommand yap = new OleDbCommand("select * from ürünler where barkodno='" + textBox7.Text + "'", baglanti);
                OleDbDataReader oku = yap.ExecuteReader();
                while (oku.Read())
                {
                    b = Convert.ToInt32(oku["adet"].ToString());
                    c = b - a;
                }
                baglanti.Close();
                baglanti.Open();
                OleDbCommand sat = new OleDbCommand("update ürünler set adet='" + c + "'where barkodno='" + textBox7.Text + "'", baglanti);
                sat.ExecuteNonQuery();
                baglanti.Close();
                baglanti.Open();
                OleDbCommand sat_log = new OleDbCommand("insert into satislar(barkodno,ürünadi,tarih,fiyat,adet) values('" + textBox7.Text + "','" + textBox9.Text + " " + textBox10.Text + "','" + dateTimePicker1.Value + "','" + textBox12.Text + "','" + textBox11.Text + "')", baglanti);
                sat_log.ExecuteNonQuery();
                baglanti.Close();
                float taksit=Convert.ToInt32(numericUpDown1.Value) ;
                for (int i = 1; i <taksit+1 ; i++)
                {
                    baglanti.Open();
                    OleDbCommand mst_log = new OleDbCommand("insert into mstdetay(taksit,tcno,barkodno,ürünadi,adet,fiyat,tarih,id) values('" + i + "','" + textBox1.Text +"','"+textBox7.Text+"','" + textBox9.Text+" "+textBox10.Text+ "','" + textBox11.Text + "','" + toplam/taksit + "','"+dateTimePicker1.Value+"','"+i+"')", baglanti);
                    mst_log.ExecuteNonQuery();
                    baglanti.Close();
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                MessageBox.Show("Ürün satıldı");

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();

            }
        }
    }
}
