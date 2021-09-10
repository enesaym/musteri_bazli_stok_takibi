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
    public partial class musteriekle : Form
    {
        public musteriekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Hatalar();
                if (durum == true)
                {
                    baglanti.Open();
                    OleDbCommand ekle = new OleDbCommand("insert into müşteriler(tc,ad,soyad,tel,adres,email) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','"+textBox5.Text+"')", baglanti);
                    ekle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Müşteri eklendi");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                }
                else
                {
                    MessageBox.Show("Bu müşteri zaten mevcut", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }

            }
            catch (Exception acıklama)
            {
                MessageBox.Show(acıklama.Message, "HATA!");
                baglanti.Close();
            }



        }
        
        
        bool durum;
        private void Hatalar()
        {

            baglanti.Open();  //girilen tc numarası veritabanında var mı diye bakar,hata mesajı için kullanılır.
            OleDbCommand komut = new OleDbCommand("select*from müşteriler where tc='" + textBox1.Text + "'", baglanti);
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

        private void musteriekle_Load(object sender, EventArgs e)
        {

        }
    }
}
