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
    public partial class sifredegistir : Form
    {
        public sifredegistir()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            bool onay = false;
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select * from kullanicilar", baglanti);
            OleDbDataReader oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                if (oku["kullaniciadi"].ToString() == textBox1.Text && oku["parola"].ToString() == textBox2.Text && textBox3.Text!=" ")
                {
                    OleDbCommand sguncelle = new OleDbCommand("update kullanicilar set parola='" + textBox3.Text + "'where parola='" + textBox2.Text + "'", baglanti);
                    sguncelle.ExecuteNonQuery();
                    MessageBox.Show("Şifre değiştirildi");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    onay = true;
                }
            }
            if(onay==false)
            {
                MessageBox.Show("Lütfen bilgileri tekrar kontrol ediniz", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();

        }

        private void sifredegistir_Load(object sender, EventArgs e)
        {

        }
    }
}
