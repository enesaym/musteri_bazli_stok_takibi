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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti=new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false; //ilk açılışta boş giriş denemesini engeller.
            this.AcceptButton = button1;this.CancelButton = button2;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool durum = false;
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select * from kullanicilar", baglanti);
            OleDbDataReader oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                if (radioButton1.Checked==true && oku["kullaniciadi"].ToString() == textBox1.Text && oku["parola"].ToString() == textBox2.Text && oku["yetki"].ToString() == "Yönetici")
                {
                    this.Hide();
                    Form2 yonetici = new Form2();
                    yonetici.Show();
                    durum = true;
                    break;
                }
                
                else if (radioButton2.Checked == true && oku["kullaniciadi"].ToString() == textBox1.Text && oku["parola"].ToString() == textBox2.Text && oku["yetki"].ToString() == "Kullanıcı")
                {
                    this.Hide();
                    Form3 kullanici = new Form3();
                    kullanici.Show();
                    durum = true;
                    break;
                }
            }
            if (durum == true)
            {
                MessageBox.Show("Hoşgeldiniz"+" "+oku["ad"].ToString()+" "+oku["soyad"],"Giriş başarılı");
            }
            else
            {
                textBox2.Clear();
                MessageBox.Show("Lütfen bilgileri tekrar kontrol ediniz", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
