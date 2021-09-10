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
    public partial class kullanicisil : Form
    {
        public kullanicisil()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != " ")
                {
                    baglanti.Open();
                    OleDbCommand sil = new OleDbCommand("delete from kullanicilar where kullaniciadi='" + textBox1.Text + "'", baglanti);
                    sil.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı silindi");
                    baglanti.Close();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı bos geçilemez !");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA");
                baglanti.Close();
            }
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            baglanti.Open();
            OleDbCommand doldur = new OleDbCommand("select * from kullanicilar where kullaniciadi='"+textBox1.Text+"'",baglanti);
            OleDbDataReader oku = doldur.ExecuteReader();
            while (oku.Read())
            {
                textBox2.Text = oku["ad"].ToString();
                textBox3.Text = oku["soyad"].ToString();
            }
            baglanti.Close();
            
         
        }

        private void kullanicisil_Load(object sender, EventArgs e)
        {

        }
    }
}
