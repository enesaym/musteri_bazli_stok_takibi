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
    public partial class ürünsil : Form
    {
        public ürünsil()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void ürünsil_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand sil = new OleDbCommand("delete from ürünler where barkodno='" + textBox1.Text + "'", baglanti);
                sil.ExecuteNonQuery();
                MessageBox.Show("Ürün silindi");
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!");
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
                    textBox2.Text = oku["marka"].ToString();
                    textBox3.Text = oku["model"].ToString();
                    textBox4.Text = oku["adet"].ToString();   
            }
            baglanti.Close();            
        }
    }
}
