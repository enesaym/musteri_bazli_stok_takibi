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
    public partial class kullaniciekle : Form
    {
        public kullaniciekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti= new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                {
                    baglanti.Open();
                    OleDbCommand ekle = new OleDbCommand("insert into kullanicilar(tcno,ad,soyad,yetki,kullaniciadi,parola) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + radioButton1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);
                    ekle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kullanıcı eklendi");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
                if (radioButton2.Checked == true)
                {
                    baglanti.Open();
                    OleDbCommand ekle = new OleDbCommand("insert into kullanicilar(tcno,ad,soyad,yetki,kullaniciadi,parola) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + radioButton2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);
                    ekle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kullanıcı eklendi");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
                
            }
            catch (Exception acıklama)
            {
                MessageBox.Show(acıklama.Message, "HATA!");
                baglanti.Close();
            }

        }

        private void kullanicilar_Load(object sender, EventArgs e)
        {

        }
    }
}
