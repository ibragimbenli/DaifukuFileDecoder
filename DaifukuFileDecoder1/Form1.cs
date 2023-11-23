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
            /*
             ************Eğer veriler text dosyasına yazılmak istenirse 38. satırdan sonra aşağıdaki kodlardan uygun olan eklenmelidir.
            //Environment.CurrentDirectory - Projenin exe'sinin bulunduğu Debug klasörünü bize verir.
            //File.AppendAllText(Environment.CurrentDirectory + @"\yaz.txt", Dosyaicrk + "\n"); //Gelen verileri üzerine ekleyerek yazar.
            //File.WriteAllText(Environment.CurrentDirectory + @"\yaz.txt", Dosyaicrk); //Gelen son veriyi texct dosyasının içini boşaltarak yazar.
            */
            openFileDialog1.Filter = "Text File| *.txt";
            OpenFileDialog Acdosya = new OpenFileDialog();
            Acdosya.ShowDialog();
            textBox1.Text = Acdosya.FileName;

            if (Acdosya.FileName == null || Acdosya.FileName == "") return;

            using (StreamReader Okunan = new StreamReader(Acdosya.FileName))
            {
                string Dosyaicrk = Okunan.ReadToEnd().Replace("\n", "");
                Dosyaicrk = Dosyaicrk.Replace("\r", "");

                textBox2.Text = Dosyaicrk;
                textBox4.Text = Dosyaicrk;
                int Sti = -1, Adet = 8, Say = 1;
                string KntrlWrd1 = "", KntrlWrd2 = "06 07 81";
                do
                {
                    Sti++;
                    if (Dosyaicrk.Length < Sti + KntrlWrd2.Length)
                        return;

                    KntrlWrd1 = Dosyaicrk.Substring(Sti, Adet);

                    if (KntrlWrd1 == KntrlWrd2)
                    {
                        Adet += 24;
                        KntrlWrd1 = Dosyaicrk.Substring(Sti, Adet);
                        Sti += 32;

                        MessageBox.Show(KntrlWrd1 + " Adt: " + Adet + " DosyaLength: " + Dosyaicrk.Length + " Sti: " + Sti + " Say:" + Say);

                        Adet = 8;
                        Say++;
                    }
                } while (KntrlWrd1 != "End log f");
            }

        }
    }
}
