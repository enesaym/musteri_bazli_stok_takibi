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
    public partial class musterisil : Form
    {
        public musterisil()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void musterisil_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            {
                baglanti.Open();
                OleDbCommand yap = new OleDbCommand("select * from müşteriler where tc='" + textBox1.Text + "'", baglanti);
                OleDbDataReader oku = yap.ExecuteReader();
                while (oku.Read())
                {
                    textBox2.Text = oku["ad"].ToString();
                    textBox3.Text = oku["soyad"].ToString();
                    textBox4.Text = oku["tel"].ToString();
                    textBox5.Text = oku["email"].ToString();
                }
                baglanti.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand sil = new OleDbCommand("delete from müşteriler where tc='" + textBox1.Text + "'", baglanti);
                sil.ExecuteNonQuery();
                MessageBox.Show("Müşteri silindi");
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!");
                baglanti.Close();
            }
        }
    }
}
