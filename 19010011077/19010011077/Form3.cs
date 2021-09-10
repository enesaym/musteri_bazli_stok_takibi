using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19010011077
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void formgetir(Form frm)
        {
            pictureBox1.Enabled = false;
            pictureBox1.Visible = false;
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {            
            timer1.Enabled = true;
            foreach  (Control ctrl in this.Controls)
            {
                if(ctrl is MdiClient)
                {
                    ctrl.BackColor=Color.FromArgb(0,118,212);
                }
            }           
        }

        private void şifremiDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            
            sifredegistir sifregnc = new sifredegistir();
            if (Application.OpenForms["sifredegistir"] == null)
            {
                formgetir(sifregnc);
            }
                  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString();
        }

        private void oTURUMUKAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 grs = new Form1();
            grs.Show();
        }

        private void kategoriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kategoriekle ktg = new kategoriekle();
            if (Application.OpenForms["kategoriekle"] == null)
            {
                formgetir(ktg);
            }          
        }

        private void markaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            markaekle markekle = new markaekle();
            if (Application.OpenForms["markaekle"] == null)
            {
                formgetir(markekle);
            }
        }

        private void modelEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modelekle mdlekle = new modelekle();
            if (Application.OpenForms["modelekle"] == null)
            {
                formgetir(mdlekle);
            }
        }

        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ürünekle üekle = new ürünekle();
            if (Application.OpenForms["ürünekle"] == null) 
            {   
                formgetir(üekle); 
            }
        }

        private void ürünSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ürünsil üsil = new ürünsil();
            if (Application.OpenForms["ürünsil"] == null)
            {
                formgetir(üsil);
            }
        }

        private void ürünGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            üründüzenle ürndüzenle = new üründüzenle();
            if (Application.OpenForms["üründüzenle"] == null)
            {
                formgetir(ürndüzenle);
            } 
        }

        private void stokKontrolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stokkontrol stkontrol = new stokkontrol();
            if (Application.OpenForms["stkontrol"] == null)
            {
                formgetir(stkontrol);
            }
                
        }

        private void müşteriBakiyeGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musteriekle mstekle = new musteriekle();
            if (Application.OpenForms["mstekle"] == null)
            {
                formgetir(mstekle);
            }
                
        }

        private void müşteriDetayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musteridetay msdetay = new musteridetay();
            if (Application.OpenForms["msdetay"] == null)
            {
                formgetir(msdetay);
            }
        }

        private void müşteriDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musteriduzenle mstduzenle = new musteriduzenle();
            if (Application.OpenForms["mstduzenle"] == null)
            {
                formgetir(mstduzenle);
            }
        }

        private void müşteriSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musterisil mstsil = new musterisil();
            if (Application.OpenForms["mstsil"] == null)
            {
                formgetir(mstsil);
            }
        }

        private void müşteriyeSatışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pesinsatis psnsatis = new pesinsatis();
            if (Application.OpenForms["psnsatis"] == null)
            {
                formgetir(psnsatis);
            }
        }

        private void parekendeSatışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vadelisatis vsatis = new vadelisatis();
            if (Application.OpenForms["vadelisatis"] == null)
            {
                formgetir(vsatis);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
