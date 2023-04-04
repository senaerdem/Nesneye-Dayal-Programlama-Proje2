/***********************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**		          BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**			  NESNEYE DAYALI PROGRAMLAMA DERSİ
**				2021-2022 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 02
**				ÖĞRENCİ ADI............: Sena Nur ERDEM
**				ÖĞRENCİ NUMARASI.......: G201210033
**              DERSİN ALINDIĞI GRUP...: B (İkinci Öğretim)
*************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mynamespace
{
    public partial class MyForm : Form
    {
        private Button btnHesapla;
        private TextBox txtSayi;
        private Label lblYazi;
        private Label lblIsim;
        private Label lblTextBoxIsim;

        public MyForm()
        {
            this.BackColor = Color.Pink;
            this.Text = "Fatura Tutarı Hesaplama";
            // buton oluşturdum
            btnHesapla = new Button();
            btnHesapla.Text = "&HESAPLA";
            btnHesapla.Left = 50;
            btnHesapla.Top = 200;
            btnHesapla.Click += BtnHesapla_Click;
            // textbox oluşturdum
            txtSayi = new TextBox();
            txtSayi.Left = 80;
            txtSayi.Top = 60;

            // label oluşturdum
            lblYazi = new Label();
            lblYazi.Left = 80;
            lblYazi.Top = 100;
            lblYazi.Size = new Size(150, 40);
            lblYazi.BorderStyle = BorderStyle.Fixed3D;
            // label oluşturdum
            lblIsim = new Label();
            lblIsim.Left = 25;
            lblIsim.Top = 100;
            lblIsim.Text = "Okunuş:";
            // textbox oluşturdum
            lblTextBoxIsim = new Label();
            lblTextBoxIsim.Left = 25;
            lblTextBoxIsim.Top = 60;
            lblTextBoxIsim.Text = "Sayı:";

            this.Controls.Add(btnHesapla);
            this.Controls.Add(txtSayi);
            this.Controls.Add(lblYazi);
            this.Controls.Add(lblIsim);
            this.Controls.Add(lblTextBoxIsim);
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            lblYazi.Text = "";
            decimal sayi;
            sayi = Convert.ToDecimal(txtSayi.Text);

            string sonuc;
            string kurus;
            yaziyaCevir(sayi, out sonuc);
            lblYazi.Text = sonuc;
        }

        private static bool sayiyiOku(decimal sayi, out string gecici) //girilen tutarı basamaklarına ayırarak okuttum 
        {
            string[] strbir = {
                "Bir", "İki", "Üç", "Dört", "Beş", "Altı", "Yedi", "Sekiz",
                "Dokuz", "On", "On bir", "On iki", "On üç", "On dört",
                "On beş", "On altı", "On yedi", "On sekiz", "On dokuz",
            };

            string[] stron = {
                  "On", "Yirmi", "Otuz", "Kırk", "Elli", "Altmış",
                  "Yetmiş", "Seksen", "Doksan", "Yüz"
            };

            string sonuc = "";
            gecici = "";
            int birler, onlar, yuzler;

            if (sayi > 1000)
                return false;

            yuzler = (int)sayi / 100;
            sayi = sayi - yuzler * 100;
            if (sayi < 20)
            {
                onlar = 0;
                birler = (int)sayi;
                sayi = sayi - yuzler * 100;
            }
            else
            {
                onlar = (int)sayi / 10;
                sayi = sayi - onlar * 10;
                birler = (int)sayi;
            }

            sonuc = "";

            if (yuzler > 0)
            {
                sonuc += strbir[yuzler - 1];
                sonuc += " Yüz ";
            }
            if (onlar > 0)
            {
                sonuc += stron[onlar - 1];
                sonuc += " ";
            }
            if (birler > 0)
            {
                sonuc += strbir[birler - 1];
                sonuc += " ";
            }

            gecici = sonuc;
            return true;
        }

        private static bool sayiyiOku1(decimal sayi, out string gecicikurus) //girilen tutarın kuruş kısmını basamaklarına göre ayırarak okuttum
        {
            string[] strbir = {
                "Bir", "İki", "Üç", "Dört", "Beş", "Altı", "Yedi", "Sekiz",
                "Dokuz", "On", "Onbir", "Oniki", "Onüç", "Ondört",
                "Onbeş", "Onaltı", "Onyedi", "Onsekiz", "Ondokuz",
            };

            string[] stron = {
                  "On", "Yirmi", "Otuz", "Kırk", "Elli", "Altmış",
                  "Yetmiş", "Seksen", "Doksan", "Yüz"
            };

            int birler, onlar;
            string sayi2 = Convert.ToString(sayi);

            string kurus = sayi2.Substring(sayi2.IndexOf(',') + 1, 2);

            onlar = Convert.ToInt32(kurus) / 10;
            birler = Convert.ToInt32(kurus) % 10;

            gecicikurus = "";

            if (onlar > 0)
            {
                gecicikurus += stron[onlar - 1];
                gecicikurus += " ";
            }
            if (birler > 0)
            {
                gecicikurus += strbir[birler - 1];
                gecicikurus += " ";
            }

            kurus = gecicikurus;

            if (kurus == "")
            {
                gecicikurus = "Sıfır ";
            }

            return true;
        }

        private static bool yaziyaCevir(decimal sayi, out string sonuc) //tutarı yazdırdım
        {
            string sayi1 = Convert.ToString(sayi);
            string gecicisonuc = "";
            string gecicikurus = "";
            int binler;
            int onlar;
            int temp;
            sonuc = "";

            if (sayi < 0 || sayi > 99999)
            {
                MessageBox.Show("Desteklenmeyen aralık!");
                return false;
            }

            if (sayi == 0)
            {
                MessageBox.Show("Sıfır");
                return false;
            }

            if (sayi < 1000)
            {
                sayiyiOku(sayi, out gecicisonuc);
                sayiyiOku1(sayi, out gecicikurus);

                if (sayi1.Contains(","))
                {
                    sonuc += gecicisonuc + "TL" + " " + gecicikurus + "Kuruş";

                    if (sonuc.Contains("Bir Yüz"))
                    {
                        sonuc = sonuc.Replace("Bir Yüz", "Yüz");
                    }
                }
                else
                {
                    sonuc += gecicisonuc + "TL";
                    if (sonuc.Contains("Bir Yüz"))
                    {
                        sonuc = sonuc.Replace("Bir Yüz", "Yüz");
                    }
                }
            }
            else
            {
                binler = (int)sayi / 1000;
                temp = (int)sayi - binler * 1000;
                sayiyiOku(binler, out gecicisonuc);
                sonuc += gecicisonuc;
                sonuc += "Bin ";

                sayiyiOku(temp, out gecicisonuc);
                sayiyiOku1(sayi, out gecicikurus);


                if (sayi1.Contains(","))
                {
                    sonuc += gecicisonuc + "TL" + " " + gecicikurus + "Kuruş";

                    if (sayi >= 100 && sayi < 200 && sonuc.Contains("Bir Yüz"))
                    {
                        sonuc = sonuc.Replace("Bir Yüz", "Yüz");
                    }

                    if (sayi < 2000 && sayi >= 1000 && sonuc.Contains("Bir Bin"))
                    {
                        sonuc = sonuc.Replace("Bir Bin", "Bin");
                        sonuc = sonuc.Replace("Bir Yüz", "Yüz");
                    }
                }
                else
                {
                    sonuc += gecicisonuc + "TL";

                    if (sayi >= 100 && sayi < 200 && sonuc.Contains("Bir Yüz"))
                    {
                        sonuc = sonuc.Replace("Bir Yüz", "Yüz");
                    }

                    if (sayi < 2000 && sayi >= 1000 && sonuc.Contains("Bir Bin"))
                    {
                        sonuc = sonuc.Replace("Bir Bin", "Bin");
                        sonuc = sonuc.Replace("Bir Yüz", "Yüz");
                    }
                }
            }
            return true;
        }
        public static void Main()
        {
            Application.Run(new MyForm());
        }
    }
}