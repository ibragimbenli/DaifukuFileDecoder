using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaifukuFileDecoder1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnfileSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text File| *.log";
            OpenFileDialog Acdosya = new OpenFileDialog();
            Acdosya.ShowDialog();
            textBox1.Text = Acdosya.FileName;

            if (Acdosya.FileName == null || Acdosya.FileName == "") return;

            using (StreamReader Okunan = new StreamReader(Acdosya.FileName))
            {
                //File.AppendAllText(@"C:\Users\ibrahim.benli\Desktop\yaz.txt", Environment.NewLine);
                string Dosyaicrk = Okunan.ReadToEnd().Replace("\n", "");
                Dosyaicrk = Dosyaicrk.Replace(" ", " ").Replace("\r", "");
                
                textBox2.Text = Dosyaicrk;
                textBox4.Text = Dosyaicrk;
                int Sti = -1, Adet = 8, Say = 1;
                string KntrlWrd1 = "", KntrlWrd2 = "06 07 81";
                do
                {
                    Sti++;
                    if (Dosyaicrk.Length < Sti + 8) 
                        return;

                    KntrlWrd1 = Dosyaicrk.Substring(Sti, Adet);

                    if (KntrlWrd1 == KntrlWrd2)
                    {
                        Adet = Adet + 24;
                        KntrlWrd1 = Dosyaicrk.Substring(Sti, Adet);
                        Sti += 32;

                        MessageBox.Show(KntrlWrd1 + " Adt: " + Adet + " Sti: " + Sti + " Say:" + Say);
                        
                        Adet = 8;
                        Say++;
                    }
                } while (KntrlWrd1 != "End log f");
            }

        }
    }
}
