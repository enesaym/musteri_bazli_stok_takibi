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
    public partial class modelekle : Form
    {
        public modelekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void modelekle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand ekle = new OleDbCommand("insert into modeller(id,ad) values('" + textBox1.Text + "','" + textBox2.Text + "')", baglanti);
                ekle.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Model eklendi");
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception acıklama)
            {
                MessageBox.Show(acıklama.Message, "HATA!");
                baglanti.Close();
            }
        }
    }
}
