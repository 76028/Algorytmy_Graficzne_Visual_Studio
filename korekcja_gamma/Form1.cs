//Korekcja gamma obrazu
//(c) 2012 by Tomasz Lubinski
//www.algorytm.org

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Imaging;

namespace korekcja_gamma
{
    public partial class Form1 : Form
    {
        private Image zrodlo,zrodlo2,zrodlo3;
        private int bytesPerPixel;
        private Obraz wynik,wynik2;

        public Form1()
        {
            zrodlo = null;
            bytesPerPixel = 0;
            InitializeComponent();
        }

        private void wczytaj_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Otwórz obraz";
            dlg.Filter = "pliki jpg (*.jpg)|*.jpg|pliki png (*.png)|*.png|wszystkie pliki (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                zrodlo = new Bitmap(dlg.OpenFile());
                bytesPerPixel = Image.GetPixelFormatSize(zrodlo.PixelFormat) / 8;
                wynik = new Obraz();
                wynik.obrazWynikowy.Image = new Bitmap(dlg.OpenFile());
                wynik.obrazWynikowy.Height = wynik.obrazWynikowy.Image.Height;
                wynik.obrazWynikowy.Width = wynik.obrazWynikowy.Image.Width;
                wynik.obrazWynikowy.Refresh();
                wynik.ClientSize = new System.Drawing.Size(wynik.obrazWynikowy.Width + 24, wynik.obrazWynikowy.Height + 32);
                wynik.Show();
                wynik.Refresh();
            }
            dlg.Dispose();
        }

        private void wczytaj2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Otwórz obraz";
            dlg.Filter = "pliki jpg (*.jpg)|*.jpg|pliki png (*.png)|*.png|wszystkie pliki (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                zrodlo2 = new Bitmap(dlg.OpenFile());
                bytesPerPixel = Image.GetPixelFormatSize(zrodlo2.PixelFormat) / 8;
                wynik2 = new Obraz();
                wynik2.obrazWynikowy.Image = new Bitmap(dlg.OpenFile());
                wynik2.obrazWynikowy.Height = wynik2.obrazWynikowy.Image.Height;
                wynik2.obrazWynikowy.Width = wynik2.obrazWynikowy.Image.Width;
                wynik2.obrazWynikowy.Refresh();
                wynik2.ClientSize = new System.Drawing.Size(wynik2.obrazWynikowy.Width + 24, wynik2.obrazWynikowy.Height + 32);
                pictureBox1.Image = zrodlo2;
                wynik2.Show();
                wynik2.Refresh();
            }
            dlg.Dispose();

            dlg.Title = "Otwórz obraz";
            dlg.Filter = "pliki jpg (*.jpg)|*.jpg|pliki png (*.png)|*.png|wszystkie pliki (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                zrodlo3 = new Bitmap(dlg.OpenFile());
                bytesPerPixel = Image.GetPixelFormatSize(zrodlo3.PixelFormat) / 8;
                pictureBox2.Image = zrodlo3;
            }
            dlg.Dispose();
        }



        private void zapisz_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog();
            save.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            save.InitialDirectory = @"C:\";
            save.DefaultExt = "png";
            save.AddExtension = true;
            if (wynik.obrazWynikowy.Image == null)
            {
                var message = "Najpierw otwórz zdjęcie";
                var caption = "Błąd";
                var buttons = MessageBoxButtons.OK;
                var messageBoxIcon = MessageBoxIcon.Warning;
                MessageBox.Show(message, caption, buttons, messageBoxIcon);
            }

            else if (save.ShowDialog() == DialogResult.OK)
            {
                wynik.obrazWynikowy.Image.Save(save.FileName);
            }
        }

        private void zapisz2_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog();
            save.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            save.InitialDirectory = @"C:\";
            save.DefaultExt = "png";
            save.AddExtension = true;
            if (wynik2.obrazWynikowy.Image == null)
            {
                var message = "Najpierw otwórz zdjęcie";
                var caption = "Błąd";
                var buttons = MessageBoxButtons.OK;
                var messageBoxIcon = MessageBoxIcon.Warning;
                MessageBox.Show(message, caption, buttons, messageBoxIcon);
            }

            else if (save.ShowDialog() == DialogResult.OK)
            {
                wynik2.obrazWynikowy.Image.Save(save.FileName);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            //Przygotuj tablice LUT
            byte[] LUT = new byte[256];
            double gamma = suwakgamma.Value / 100.0;
            for (int i = 0; i < 256; i++)
            {
                if ((255 * Math.Pow(i / 255.0, 1 / gamma)) > 255)
                {
                    LUT[i] = 255;
                }
                else
                {
                    LUT[i] = (byte)(255 * Math.Pow(i / 255.0, 1 / gamma));
                }
            }

            //Nie rob nic wiecej jezeli obraz jest jeszcze niewczytany
            if (zrodlo == null)
            {
                return;
            }

            //Kopiuj obrazek zrodlowy
            Bitmap bitmap = (Bitmap)zrodlo.Clone();
            
            wynik.obrazWynikowy.Image = bitmap;

            //Pobierz wartosc wszystkich punktow obrazu
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            byte[] pixelValues = new byte[Math.Abs(bmpData.Stride) * bitmap.Height];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixelValues, 0, pixelValues.Length);

            //Korekcja gamma dla kazdego punktu zgodnie z tablica LUT
            for (int i = 0; i < pixelValues.Length; i++)
            {
                pixelValues[i] = LUT[pixelValues[i]];
            }

            //Ustaw wartosc wszystkich punktow obrazu
            System.Runtime.InteropServices.Marshal.Copy(pixelValues, 0, bmpData.Scan0, pixelValues.Length);
            bitmap.UnlockBits(bmpData);

            bitmap = new Bitmap(wynik.obrazWynikowy.Image);
            rysujhistogramred(bitmap);
            rysujhistogramgreen(bitmap);
            rysujhistogramblue(bitmap);
        }


        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {

                var temp =zrodlo;
                var bmap = (Bitmap)temp.Clone();
                if (suwakjasnosc.Value < -255) suwakjasnosc.Value = -255;
                if (suwakjasnosc.Value > 255) suwakjasnosc.Value = 255;
                Color c;
                for (var i = 0; i < bmap.Width; i++)
                    for (var j = 0; j < bmap.Height; j++)
                    {
                        c = bmap.GetPixel(i, j);
                        var cR = c.R + suwakjasnosc.Value;
                        var cG = c.G + suwakjasnosc.Value;
                        var cB = c.B + suwakjasnosc.Value;

                        if (cR < 0) cR = 1;
                        if (cR > 255) cR = 255;

                        if (cG < 0) cG = 1;
                        if (cG > 255) cG = 255;

                        if (cB < 0) cB = 1;
                        if (cB > 255) cB = 255;

                        bmap.SetPixel(i, j, System.Drawing.Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                    }

            rysujhistogramred(bmap);
            rysujhistogramgreen(bmap);
            rysujhistogramblue(bmap);
            wynik.obrazWynikowy.Image = bmap;
           
        }



        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            //Nie rob nic wiecej jezeli obraz jest jeszcze niewczytany
            if (zrodlo == null)
            {
                return;
            }

            //Sprawdz czy obraz wynikowy bedzie kolorowy
            if (bytesPerPixel < 3)
            {
                MessageBox.Show("Nieprawidłowy format pliku wejściowego");
            }

            //Pobierz wartosc sepii
            int sepia = suwaksepia.Value;

            //Przygotuj tablice LUT dla kanalu R (czerwien)
            byte[] LUTR = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                if (i + 2 * sepia > 255)
                {
                    LUTR[i] = 255;
                }
                else
                {
                    LUTR[i] = (byte)(i + 2 * sepia);
                }
            }

            //Przygotuj tablice LUT dla kanalu G (zielen)
            byte[] LUTG = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                if (i + sepia > 255)
                {
                    LUTG[i] = 255;
                }
                else
                {
                    LUTG[i] = (byte)(i + sepia);
                }
            }

            //Kopiuj obrazek zrodlowy
            Bitmap bitmap = (Bitmap)zrodlo.Clone();          
            wynik.obrazWynikowy.Image = bitmap;
            //Pobierz wartosc wszystkich punktow obrazu
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            byte[] pixelValues = new byte[Math.Abs(bmpData.Stride) * bitmap.Height];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixelValues, 0, pixelValues.Length);

            //Sepia dla kazdego punktu obrazu
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    int index = y * bmpData.Stride + x * bytesPerPixel;
                    int val = (int)(0.299 * pixelValues[index + 2] + 0.587 * pixelValues[index + 1] + 0.114 * pixelValues[index]);
                    pixelValues[index + 2] = LUTR[val];
                    pixelValues[index + 1] = LUTG[val];
                    pixelValues[index] = (byte)val;
                }
            }
            
            //Ustaw wartosc wszystkich punktow obrazu
            System.Runtime.InteropServices.Marshal.Copy(pixelValues, 0, bmpData.Scan0, pixelValues.Length);
            bitmap.UnlockBits(bmpData);

            rysujhistogramblue(bitmap);
            rysujhistogramred(bitmap);
            rysujhistogramgreen(bitmap);
            

        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            double contrast = suwakkontrast.Value;
            var temp = zrodlo;
            var bmap = (Bitmap)temp.Clone();
            if (contrast < -255) contrast = -255;
            if (contrast >255) contrast = 255;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (var i = 0; i < bmap.Width; i++)
                for (var j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    var pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrast;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;

                    var pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrast;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;

                    var pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrast;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;

                    bmap.SetPixel(i, j, Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            rysujhistogramred(bmap);
            rysujhistogramgreen(bmap);
            rysujhistogramblue(bmap);
            wynik.obrazWynikowy.Image = (Bitmap)bmap.Clone();
        }


        private void trackBar5_ValueChanged(object sender, EventArgs e)
        {
            //Przygotuj tablice LUT i pokaz ja na wykresie
            byte[] LUT = new byte[256];
            double a;
            if (suwakekspozycja.Value <= 0)
            {
                a = 1.0 + (suwakekspozycja.Value / 256.0);
            }
            else
            {
                a = 256.0 / Math.Pow(2, Math.Log(257 - suwakekspozycja.Value, 2));
            }
            for (int i = 0; i < 256; i++)
            {
                if (a * i > 255)
                {
                    LUT[i] = 255;
                }
                else
                {
                    LUT[i] = (byte)(a * i);
                }
            }

            //Nie rob nic wiecej jezeli obraz jest jeszcze niewczytany
            if (zrodlo == null)
            {
                return;
            }

            //Kopiuj obrazek zrodlowy
            Bitmap bitmap = (Bitmap)zrodlo.Clone();
            wynik.obrazWynikowy.Image = bitmap;

            //Pobierz wartosc wszystkich punktow obrazu
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            byte[] pixelValues = new byte[Math.Abs(bmpData.Stride) * bitmap.Height];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixelValues, 0, pixelValues.Length);

            //Zmien ekspozycje kazdego punktu zgodnie z tablica LUT
            for (int i = 0; i < pixelValues.Length; i++)
            {
                pixelValues[i] = LUT[pixelValues[i]];
            }

            //Ustaw wartosc wszystkich punktow obrazu
            System.Runtime.InteropServices.Marshal.Copy(pixelValues, 0, bmpData.Scan0, pixelValues.Length);
            bitmap.UnlockBits(bmpData);
            rysujhistogramred(bitmap);
            rysujhistogramgreen(bitmap);
            rysujhistogramblue(bitmap);
        }

        private void negatyw_ValueChanged_1(object sender, EventArgs e)
        {
            //Nie rob nic wiecej jezeli obraz jest jeszcze niewczytany
            if (zrodlo == null)
            {
                return;
            }


            if (suwaknegatyw.Value == 1)
            {
                //Kopiuj obrazek zrodlowy
                Bitmap bitmap = (Bitmap)zrodlo.Clone();
                wynik.obrazWynikowy.Image = bitmap;
                int R, G, B;
                for (int i = 0; i < bitmap.Width; i++)
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        Color pixel = bitmap.GetPixel(i, j);
                        R = pixel.R;
                        G = pixel.G;
                        B = pixel.B;

                        bitmap.SetPixel(i, j, Color.FromArgb(255 - R, 255 - G, 255 - B));
                    }
                rysujhistogramred(bitmap);
                rysujhistogramgreen(bitmap);
                rysujhistogramblue(bitmap);
            }
            else
            {
                
                Bitmap bitmap = (Bitmap)zrodlo.Clone();
                wynik.obrazWynikowy.Image = bitmap;
                rysujhistogramred(bitmap);
                rysujhistogramgreen(bitmap);
                rysujhistogramblue(bitmap);

            }
            

        }


        private void trackBar_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();

            int R, G, B;
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixel = bitmap2.GetPixel(x, y);
                    Color pixel2 = bitmap.GetPixel(x, y);
                    R = (((255 - trackBar1.Value) * pixel2.R) >> 8) + ((trackBar1.Value * pixel.R) >> 8);
                    G = (((255 - trackBar1.Value) * pixel2.G) >> 8) + ((trackBar1.Value * pixel.G) >> 8);
                    B = (((255 - trackBar1.Value) * pixel2.B) >> 8) + ((trackBar1.Value * pixel.B) >> 8);
                    if (R < 0)
                        R = 1;
                    if (R > 255)
                        R = 255;

                    if (G < 0)
                        G = 1;
                    if (G > 255)
                        G = 255;

                    if (B < 0)
                        B = 1;
                    if (B > 255)
                        B = 255;
                    bitmap3.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
            rysujhistogramred(bitmap);
            rysujhistogramgreen(bitmap);
            rysujhistogramblue(bitmap);
            wynik2.obrazWynikowy.Image = bitmap3;
        }

        private void bsuma_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();
            Color pixel1;
            Color pixel2;
            double R = 0;
            double G = 0;
            double B = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel1 = bitmap.GetPixel(i, j);
                    pixel2 = bitmap2.GetPixel(i, j);
                    double pixel1R = (double)pixel1.R / 255.0;
                    double pixel1G = (double)pixel1.G / 255.0;
                    double pixel1B = (double)pixel1.B / 255.0;
                    double pixel2R = (double)pixel2.R / 255.0;
                    double pixel2G = (double)pixel2.G / 255.0;
                    double pixel2B = (double)pixel2.B / 255.0;

                    R = pixel1R + pixel2R;
                    G = pixel1G + pixel2G;
                    B = pixel1B + pixel2B;

                    R = Math.Round(R * 255);
                    G = Math.Round(G * 255);
                    B = Math.Round(B * 255);

                    if (R > 255.0) R = 255.0;
                    if (G > 255.0) G = 255.0;
                    if (B > 255.0) B = 255.0;
                    if (R < 0.0) R = 0.0;
                    if (G < 0.0) G = 0.0;
                    if (B < 0.0) B = 0.0;

                    bitmap3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));

                }
            }

            wynik2.obrazWynikowy.Image = bitmap3;
        }


        private void gamma_CheckedChanged(object sender, EventArgs e)
        {
            labelgamma.Visible = true;
            suwakgamma.Visible = true;

            labeljasnosc.Visible = false;
            suwakjasnosc.Visible = false;

            labelsepia.Visible = false;
            suwaksepia.Visible = false;

            labelkontrast.Visible = false;
            suwakkontrast.Visible = false;

            labelekspozycja.Visible = false;
            suwakekspozycja.Visible = false;

            labelnegatyw.Visible = false;
            suwaknegatyw.Visible = false;
        }

        private void jasnosc_CheckedChanged(object sender, EventArgs e)
        {
            labelgamma.Visible = false;
            suwakgamma.Visible = false;

            labeljasnosc.Visible = true;
            suwakjasnosc.Visible = true;

            labelsepia.Visible = false;
            suwaksepia.Visible = false;

            labelkontrast.Visible = false;
            suwakkontrast.Visible = false;

            labelekspozycja.Visible = false;
            suwakekspozycja.Visible = false;

            labelnegatyw.Visible = false;
            suwaknegatyw.Visible = false;
        }


        private void sepia_CheckedChanged(object sender, EventArgs e)
        {
            labelgamma.Visible = false;
            suwakgamma.Visible = false;

            labeljasnosc.Visible = false;
            suwakjasnosc.Visible = false;

            labelsepia.Visible = true;
            suwaksepia.Visible = true;

            labelkontrast.Visible = false;
            suwakkontrast.Visible = false;

            labelekspozycja.Visible = false;
            suwakekspozycja.Visible = false;

            labelnegatyw.Visible = false;
            suwaknegatyw.Visible = false;
        }

        private void bodejmowanie_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();
            Color pixel1;
            Color pixel2;
            double R = 0;
            double G = 0;
            double B = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel1 = bitmap.GetPixel(i, j);
                    pixel2 = bitmap2.GetPixel(i, j);
                    double pixel1R = (double)pixel1.R / 255.0;
                    double pixel1G = (double)pixel1.G / 255.0;
                    double pixel1B = (double)pixel1.B / 255.0;
                    double pixel2R = (double)pixel2.R / 255.0;
                    double pixel2G = (double)pixel2.G / 255.0;
                    double pixel2B = (double)pixel2.B / 255.0;

                    R = pixel1R - pixel2R;
                    G = pixel1G - pixel2G;
                    B = pixel1B - pixel2B;
                    R = Math.Round(R * 255);
                    G = Math.Round(G * 255);
                    B = Math.Round(B * 255);

                    if (R > 255.0) R = 255.0;
                    if (G > 255.0) G = 255.0;
                    if (B > 255.0) B = 255.0;
                    if (R < 0.0) R = 0.0;
                    if (G < 0.0) G = 0.0;
                    if (B < 0.0) B = 0.0;

                    bitmap3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));

                }
            }
            wynik2.obrazWynikowy.Image = bitmap3;
        }



        private void Roznica_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();
            Color pixel1;
            Color pixel2;
            double R = 0;
            double G = 0;
            double B = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel1 = bitmap.GetPixel(i, j);
                    pixel2 = bitmap2.GetPixel(i, j);
                    double pixel1R = (double)pixel1.R / 255.0;
                    double pixel1G = (double)pixel1.G / 255.0;
                    double pixel1B = (double)pixel1.B / 255.0;
                    double pixel2R = (double)pixel2.R / 255.0;
                    double pixel2G = (double)pixel2.G / 255.0;
                    double pixel2B = (double)pixel2.B / 255.0;

                    R = Math.Abs(pixel1R - pixel2R);
                    G = Math.Abs(pixel1G - pixel2G);
                    B = Math.Abs(pixel1B - pixel2B);

                    R = Math.Round(R * 255);
                    G = Math.Round(G * 255);
                    B = Math.Round(B * 255);

                    if (R > 255.0) R = 255.0;
                    if (G > 255.0) G = 255.0;
                    if (B > 255.0) B = 255.0;
                    if (R < 0.0) R = 0.0;
                    if (G < 0.0) G = 0.0;
                    if (B < 0.0) B = 0.0;

                    bitmap3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));

                }
            }
            wynik2.obrazWynikowy.Image = bitmap3;
        }

        private void bmnozenie_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();
            Color pixel1;
            Color pixel2;
            double R = 0;
            double G = 0;
            double B = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel1 = bitmap.GetPixel(i, j);
                    pixel2 = bitmap2.GetPixel(i, j);
                    double pixel1R = (double)pixel1.R / 255.0;
                    double pixel1G = (double)pixel1.G / 255.0;
                    double pixel1B = (double)pixel1.B / 255.0;
                    double pixel2R = (double)pixel2.R / 255.0;
                    double pixel2G = (double)pixel2.G / 255.0;
                    double pixel2B = (double)pixel2.B / 255.0;

                    R = pixel1R * pixel2R;
                    G = pixel1G * pixel2G;
                    B = pixel1B * pixel2B;

                    R = Math.Round(R * 255);
                    G = Math.Round(G * 255);
                    B = Math.Round(B * 255);

                    if (R > 255.0) R = 255.0;
                    if (G > 255.0) G = 255.0;
                    if (B > 255.0) B = 255.0;
                    if (R < 0.0) R = 0.0;
                    if (G < 0.0) G = 0.0;
                    if (B < 0.0) B = 0.0;

                    bitmap3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));

                }
            }
            wynik2.obrazWynikowy.Image = bitmap3;
        }

        private void bodwrotnosc_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();
            Color pixel1;
            Color pixel2;
            double R = 0;
            double G = 0;
            double B = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel1 = bitmap.GetPixel(i, j);
                    pixel2 = bitmap2.GetPixel(i, j);
                    double pixel1R = (double)pixel1.R / 255.0;
                    double pixel1G = (double)pixel1.G / 255.0;
                    double pixel1B = (double)pixel1.B / 255.0;
                    double pixel2R = (double)pixel2.R / 255.0;
                    double pixel2G = (double)pixel2.G / 255.0;
                    double pixel2B = (double)pixel2.B / 255.0;

                    R = 1 - ((1 - pixel1R) * (1 - pixel2R));
                    G = 1 - ((1 - pixel1G) * (1 - pixel2G));
                    B = 1 - ((1 - pixel1B) * (1 - pixel2B));

                    R = Math.Round(R * 255);
                    G = Math.Round(G * 255);
                    B = Math.Round(B * 255);

                    if (R > 255.0) R = 255.0;
                    if (G > 255.0) G = 255.0;
                    if (B > 255.0) B = 255.0;
                    if (R < 0.0) R = 0.0;
                    if (G < 0.0) G = 0.0;
                    if (B < 0.0) B = 0.0;

                    bitmap3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));

                }
            }
            wynik2.obrazWynikowy.Image = bitmap3;
        }

        private void bnegacja_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();
            Color pixel1;
            Color pixel2;
            double R = 0;
            double G = 0;
            double B = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel1 = bitmap.GetPixel(i, j);
                    pixel2 = bitmap2.GetPixel(i, j);
                    double pixel1R = (double)pixel1.R / 255.0;
                    double pixel1G = (double)pixel1.G / 255.0;
                    double pixel1B = (double)pixel1.B / 255.0;
                    double pixel2R = (double)pixel2.R / 255.0;
                    double pixel2G = (double)pixel2.G / 255.0;
                    double pixel2B = (double)pixel2.B / 255.0;

                    R = 1 - (Math.Abs(1 - pixel1R - pixel2R));
                    G = 1 - (Math.Abs(1 - pixel1G - pixel2G));
                    B = 1 - (Math.Abs(1 - pixel1B - pixel2B));

                    R = Math.Round(R * 255);
                    G = Math.Round(G * 255);
                    B = Math.Round(B * 255);

                    if (R > 255.0) R = 255.0;
                    if (G > 255.0) G = 255.0;
                    if (B > 255.0) B = 255.0;
                    if (R < 0.0) R = 0.0;
                    if (G < 0.0) G = 0.0;
                    if (B < 0.0) B = 0.0;

                    bitmap3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));

                }
            }
            wynik2.obrazWynikowy.Image = bitmap3;
        }

        private void bCiemniejsze_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();
            Color pixel1;
            Color pixel2;
            double R = 0;
            double G = 0;
            double B = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel1 = bitmap.GetPixel(i, j);
                    pixel2 = bitmap2.GetPixel(i, j);
                    double pixel1R = (double)pixel1.R / 255.0;
                    double pixel1G = (double)pixel1.G / 255.0;
                    double pixel1B = (double)pixel1.B / 255.0;
                    double pixel2R = (double)pixel2.R / 255.0;
                    double pixel2G = (double)pixel2.G / 255.0;
                    double pixel2B = (double)pixel2.B / 255.0;

                    if (pixel1R < pixel2R)
                    {
                        R = pixel1R;
                    }
                    else
                    {
                        R = pixel2R;
                    }
                    if (pixel1G < pixel2G)
                    {
                        G = pixel1G;
                    }
                    else
                    {
                        G = pixel2G;
                    }
                    if (pixel1B < pixel2B)
                    {
                        B = pixel1B;
                    }
                    else
                    {
                        B = pixel2B;
                    }

                    R = Math.Round(R * 255);
                    G = Math.Round(G * 255);
                    B = Math.Round(B * 255);

                    if (R > 255.0) R = 255.0;
                    if (G > 255.0) G = 255.0;
                    if (B > 255.0) B = 255.0;
                    if (R < 0.0) R = 0.0;
                    if (G < 0.0) G = 0.0;
                    if (B < 0.0) B = 0.0;

                    bitmap3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));

                }
            }
            wynik2.obrazWynikowy.Image = bitmap3;
        }



        private void bjasniejsze_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();
            Color pixel1;
            Color pixel2;
            double R = 0;
            double G = 0;
            double B = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel1 = bitmap.GetPixel(i, j);
                    pixel2 = bitmap2.GetPixel(i, j);
                    double pixel1R = (double)pixel1.R / 255.0;
                    double pixel1G = (double)pixel1.G / 255.0;
                    double pixel1B = (double)pixel1.B / 255.0;
                    double pixel2R = (double)pixel2.R / 255.0;
                    double pixel2G = (double)pixel2.G / 255.0;
                    double pixel2B = (double)pixel2.B / 255.0;

                    if (pixel1R > pixel2R)
                    {
                        R = pixel1R;
                    }
                    else
                    {
                        R = pixel2R;
                    }
                    if (pixel1G > pixel2G)
                    {
                        G = pixel1G;
                    }
                    else
                    {
                        G = pixel2G;
                    }
                    if (pixel1B > pixel2B)
                    {
                        B = pixel1B;
                    }
                    else
                    {
                        B = pixel2B;
                    }

                    R = Math.Round(R * 255);
                    G = Math.Round(G * 255);
                    B = Math.Round(B * 255);

                    if (R > 255.0) R = 255.0;
                    if (G > 255.0) G = 255.0;
                    if (B > 255.0) B = 255.0;
                    if (R < 0.0) R = 0.0;
                    if (G < 0.0) G = 0.0;
                    if (B < 0.0) B = 0.0;

                    bitmap3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));

                }
            }
            wynik2.obrazWynikowy.Image = bitmap3;
        }

        private void bWyłaczenie_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();
            Color pixel1;
            Color pixel2;
            double R = 0;
            double G = 0;
            double B = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel1 = bitmap.GetPixel(i, j);
                    pixel2 = bitmap2.GetPixel(i, j);
                    double pixel1R = (double)pixel1.R / 255.0;
                    double pixel1G = (double)pixel1.G / 255.0;
                    double pixel1B = (double)pixel1.B / 255.0;
                    double pixel2R = (double)pixel2.R / 255.0;
                    double pixel2G = (double)pixel2.G / 255.0;
                    double pixel2B = (double)pixel2.B / 255.0;

                    R = pixel1R + pixel2R - 2 * pixel1R * pixel2R;
                    G = pixel1G + pixel2G - 2 * pixel1G * pixel2G;
                    B = pixel1B + pixel2B - 2 * pixel1B * pixel2B;

                    R = Math.Round(R * 255);
                    G = Math.Round(G * 255);
                    B = Math.Round(B * 255);

                    if (R > 255.0) R = 255.0;
                    if (G > 255.0) G = 255.0;
                    if (B > 255.0) B = 255.0;
                    if (R < 0.0) R = 0.0;
                    if (G < 0.0) G = 0.0;
                    if (B < 0.0) B = 0.0;

                    bitmap3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));

                }
            }
            wynik2.obrazWynikowy.Image = bitmap3;
        }

        private void bnakladka_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();
            Color pixel1;
            Color pixel2;
            double R = 0;
            double G = 0;
            double B = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel1 = bitmap.GetPixel(i, j);
                    pixel2 = bitmap2.GetPixel(i, j);
                    double pixel1R = (double)pixel1.R / 255.0;
                    double pixel1G = (double)pixel1.G / 255.0;
                    double pixel1B = (double)pixel1.B / 255.0;
                    double pixel2R = (double)pixel2.R / 255.0;
                    double pixel2G = (double)pixel2.G / 255.0;
                    double pixel2B = (double)pixel2.B / 255.0;

                    if (pixel1R < 0.5)
                    {
                        R = 2 * pixel1R * pixel2R;
                    }
                    else
                    {
                        R = 1 - (2 * (1 - pixel1R) * (1 - pixel2R));
                    }
                    if (pixel1G < 0.5)
                    {
                        G = 2 * pixel1G * pixel2G;
                    }
                    else
                    {
                        G = 1 - (2 * (1 - pixel1G) * (1 - pixel2G));
                    }
                    if (pixel1B < 0.5)
                    {
                        B = 2 * pixel1B * pixel2B;
                    }
                    else
                    {
                        B = 1 - (2 * (1 - pixel1B) * (1 - pixel2B));
                    }

                    R = Math.Round(R * 255);
                    G = Math.Round(G * 255);
                    B = Math.Round(B * 255);

                    if (R > 255.0) R = 255.0;
                    if (G > 255.0) G = 255.0;
                    if (B > 255.0) B = 255.0;
                    if (R < 0.0) R = 0.0;
                    if (G < 0.0) G = 0.0;
                    if (B < 0.0) B = 0.0;

                    bitmap3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));

                }
            }
            wynik2.obrazWynikowy.Image = bitmap3;
        }

        private void bostre_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();
            Color pixel1;
            Color pixel2;
            double R = 0;
            double G = 0;
            double B = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel1 = bitmap.GetPixel(i, j);
                    pixel2 = bitmap2.GetPixel(i, j);
                    double pixel1R = (double)pixel1.R / 255.0;
                    double pixel1G = (double)pixel1.G / 255.0;
                    double pixel1B = (double)pixel1.B / 255.0;
                    double pixel2R = (double)pixel2.R / 255.0;
                    double pixel2G = (double)pixel2.G / 255.0;
                    double pixel2B = (double)pixel2.B / 255.0;

                    if (pixel2R < 0.0)
                    {
                        R = 2 * pixel1R * pixel2R;
                    }
                    else
                    {
                        R = 1 - (2 * (1 - pixel1R) * (1 - pixel2R));
                    }
                    if (pixel2G < 0.0)
                    {
                        G = 2 * pixel1G * pixel2G;
                    }
                    else
                    {
                        G = 1 - (2 * (1 - pixel1G) * (1 - pixel2G));
                    }
                    if (pixel2B < 0.0)
                    {
                        B = 2 * pixel1B * pixel2B;
                    }
                    else
                    {
                        B = 1 - (2 * (1 - pixel1B) * (1 - pixel2B));
                    }

                    R = Math.Round(R * 255);
                    G = Math.Round(G * 255);
                    B = Math.Round(B * 255);

                    if (R > 255.0) R = 255.0;
                    if (G > 255.0) G = 255.0;
                    if (B > 255.0) B = 255.0;
                    if (R < 0.0) R = 0.0;
                    if (G < 0.0) G = 0.0;
                    if (B < 0.0) B = 0.0;

                    bitmap3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));

                }
            }
            wynik2.obrazWynikowy.Image = bitmap3;
        }

        private void blagodne_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();
            Color pixel1;
            Color pixel2;
            double R = 0;
            double G = 0;
            double B = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel1 = bitmap.GetPixel(i, j);
                    pixel2 = bitmap2.GetPixel(i, j);
                    double pixel1R = (double)pixel1.R / 255.0;
                    double pixel1G = (double)pixel1.G / 255.0;
                    double pixel1B = (double)pixel1.B / 255.0;
                    double pixel2R = (double)pixel2.R / 255.0;
                    double pixel2G = (double)pixel2.G / 255.0;
                    double pixel2B = (double)pixel2.B / 255.0;

                    if (pixel2R < 0.5)
                    {
                        R = (2 * pixel1R * pixel2R) + (Math.Pow(pixel1R, 2) * (1 - 2 * pixel2R));
                    }
                    else
                    {
                        R = 2 * pixel1R * (1 - pixel2R) + Math.Sqrt(pixel1R) * (2 * pixel2R - 1);
                    }
                    if (pixel2G < 0.5)
                    {
                        G = (2 * pixel1G * pixel2G) + (Math.Pow(pixel1G, 2) * (1 - 2 * pixel2G));
                    }
                    else
                    {
                        G = 2 * pixel1G * (1 - pixel2G) + Math.Sqrt(pixel1G) * (2 * pixel2G - 1);
                    }
                    if (pixel2B < 0.5)
                    {
                        B = (2 * pixel1B * pixel2B) + (Math.Pow(pixel1B, 2) * (1 - 2 * pixel2B));
                    }
                    else
                    {
                        B = 2 * pixel1B * (1 - pixel2B) + Math.Sqrt(pixel1B) * (2 * pixel2B - 1);
                    }

                    R = Math.Round(R * 255);
                    G = Math.Round(G * 255);
                    B = Math.Round(B * 255);

                    if (R > 255.0) R = 255.0;
                    if (G > 255.0) G = 255.0;
                    if (B > 255.0) B = 255.0;
                    if (R < 0.0) R = 0.0;
                    if (G < 0.0) G = 0.0;
                    if (B < 0.0) B = 0.0;

                    bitmap3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));

                }
            }
            wynik2.obrazWynikowy.Image = bitmap3;
        }

        private void brozcienczenie_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();
            Color pixel1;
            Color pixel2;
            double R = 0;
            double G = 0;
            double B = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel1 = bitmap.GetPixel(i, j);
                    pixel2 = bitmap2.GetPixel(i, j);
                    double pixel1R = (double)pixel1.R / 255.0;
                    double pixel1G = (double)pixel1.G / 255.0;
                    double pixel1B = (double)pixel1.B / 255.0;
                    double pixel2R = (double)pixel2.R / 255.0;
                    double pixel2G = (double)pixel2.G / 255.0;
                    double pixel2B = (double)pixel2.B / 255.0;

                    R = pixel1R / (1 - pixel2R);
                    G = pixel1G / (1 - pixel2G);
                    B = pixel1B / (1 - pixel2B);

                    R = Math.Round(R * 255);
                    G = Math.Round(G * 255);
                    B = Math.Round(B * 255);

                    if (R > 255.0) R = 255.0;
                    if (G > 255.0) G = 255.0;
                    if (B > 255.0) B = 255.0;
                    if (R < 0.0) R = 0.0;
                    if (G < 0.0) G = 0.0;
                    if (B < 0.0) B = 0.0;

                    bitmap3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));

                }
            }
            wynik2.obrazWynikowy.Image = bitmap3;
        }

        private void bwypalenie_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();
            Color pixel1;
            Color pixel2;
            double R = 0;
            double G = 0;
            double B = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel1 = bitmap.GetPixel(i, j);
                    pixel2 = bitmap2.GetPixel(i, j);
                    double pixel1R = (double)pixel1.R / 255.0;
                    double pixel1G = (double)pixel1.G / 255.0;
                    double pixel1B = (double)pixel1.B / 255.0;
                    double pixel2R = (double)pixel2.R / 255.0;
                    double pixel2G = (double)pixel2.G / 255.0;
                    double pixel2B = (double)pixel2.B / 255.0;

                    R = 1 - ((1 - pixel1R) / pixel2R);
                    G = 1 - ((1 - pixel1G) / pixel2G);
                    B = 1 - ((1 - pixel1B) / pixel2B);

                    R = Math.Round(R * 255);
                    G = Math.Round(G * 255);
                    B = Math.Round(B * 255);

                    if (R > 255.0) R = 255.0;
                    if (G > 255.0) G = 255.0;
                    if (B > 255.0) B = 255.0;
                    if (R < 0.0) R = 0.0;
                    if (G < 0.0) G = 0.0;
                    if (B < 0.0) B = 0.0;

                    bitmap3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));

                }
            }
            wynik2.obrazWynikowy.Image = bitmap3;
        }

        private void breflect_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)zrodlo2.Clone();
            Bitmap bitmap2 = (Bitmap)zrodlo3.Clone();
            Bitmap bitmap3 = (Bitmap)zrodlo2.Clone();
            Color pixel1;
            Color pixel2;
            double R = 0;
            double G = 0;
            double B = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel1 = bitmap.GetPixel(i, j);
                    pixel2 = bitmap2.GetPixel(i, j);
                    double pixel1R = (double)pixel1.R / 255.0;
                    double pixel1G = (double)pixel1.G / 255.0;
                    double pixel1B = (double)pixel1.B / 255.0;
                    double pixel2R = (double)pixel2.R / 255.0;
                    double pixel2G = (double)pixel2.G / 255.0;
                    double pixel2B = (double)pixel2.B / 255.0;

                    R = Math.Pow(pixel1R, 2) / (1 - pixel2R);
                    G = Math.Pow(pixel1G, 2) / (1 - pixel2G);
                    B = Math.Pow(pixel1B, 2) / (1 - pixel2B);

                    R = Math.Round(R * 255);
                    G = Math.Round(G * 255);
                    B = Math.Round(B * 255);

                    if (R > 255.0) R = 255.0;
                    if (G > 255.0) G = 255.0;
                    if (B > 255.0) B = 255.0;
                    if (R < 0.0) R = 0.0;
                    if (G < 0.0) G = 0.0;
                    if (B < 0.0) B = 0.0;

                    bitmap3.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));

                }
            }

            wynik2.obrazWynikowy.Image = bitmap3;
        }

        private void kontrast_CheckedChanged(object sender, EventArgs e)
        {
            labelgamma.Visible = false;
            suwakgamma.Visible = false;

            labeljasnosc.Visible = false;
            suwakjasnosc.Visible = false;

            labelsepia.Visible = false;
            suwaksepia.Visible = false;

            labelkontrast.Visible = true;
            suwakkontrast.Visible = true;

            labelekspozycja.Visible = false;
            suwakekspozycja.Visible = false;

            labelnegatyw.Visible = false;
            suwaknegatyw.Visible = false;
        }

        private void ekspozycja_CheckedChanged(object sender, EventArgs e)
        {
            labelgamma.Visible = false;
            suwakgamma.Visible = false;

            labeljasnosc.Visible = false;
            suwakjasnosc.Visible = false;

            labelsepia.Visible = false;
            suwaksepia.Visible = false;

            labelkontrast.Visible = false;
            suwakkontrast.Visible = false;

            labelekspozycja.Visible = true;
            suwakekspozycja.Visible = true;

            labelnegatyw.Visible = false;
            suwaknegatyw.Visible = false;
        }

        private void negatyw_CheckedChanged(object sender, EventArgs e)
        {
            labelgamma.Visible = false;
            suwakgamma.Visible = false;

            labeljasnosc.Visible = false;
            suwakjasnosc.Visible = false;

            labelsepia.Visible = false;
            suwaksepia.Visible = false;

            labelkontrast.Visible = false;
            suwakkontrast.Visible = false;

            labelekspozycja.Visible = false;
            suwakekspozycja.Visible = false;

            labelnegatyw.Visible = true;
            suwaknegatyw.Visible = true;
        }

        private void transformacjajasnosc_Scroll(object sender, EventArgs e)
        {
            Bitmap bmap = new Bitmap(zrodlo);
            for (int Xcount = 0; Xcount < bmap.Width; Xcount++)
            {
                for (int Ycount = 0; Ycount < bmap.Height; Ycount++)
                {
                    Color pixelColor = bmap.GetPixel(Xcount, Ycount);
                    double red = 255 * Math.Pow(pixelColor.R / 255.0, transformacjajasnosc.Value * 0.1);
                    double green = 255 * Math.Pow(pixelColor.G / 255.0, transformacjajasnosc.Value * 0.1);
                    double blue = 255 * Math.Pow(pixelColor.B / 255.0, transformacjajasnosc.Value * 0.1);
                    bmap.SetPixel(Xcount, Ycount, Color.FromArgb(Convert.ToInt32(red), Convert.ToInt32(green), Convert.ToInt32(blue)));
                }
            }
            rysujhistogramred(bmap);
            rysujhistogramgreen(bmap);
            rysujhistogramblue(bmap);
            wynik.obrazWynikowy.Image = bmap;
        }

        void rysujhistogramred(Bitmap hist)
        {
            Bitmap bmp = hist;
            int[] histogram_r = new int[256];
            float max = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int redValue = bmp.GetPixel(i, j).R;
                    histogram_r[redValue]++;
                    if (max < histogram_r[redValue])
                        max = histogram_r[redValue];
                }
            }

            int histHeight = 232;
            Bitmap img = new Bitmap(256, histHeight + 10);
            using (Graphics g = Graphics.FromImage(img))
            {
                for (int i = 0; i < histogram_r.Length; i++)
                {
                    float pct = histogram_r[i] / max;  
                    g.DrawLine(Pens.Red,
                        new Point(i, img.Height - 5),
                        new Point(i, img.Height - 5 - (int)(pct * histHeight)) 
                        );
                }
            }
            histogram.Image = img;
        }
        void rysujhistogramgreen(Bitmap hist)
        {
            Bitmap bmp = hist;
            int[] histogram_g = new int[256];
            float max = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int greenValue = bmp.GetPixel(i, j).G;
                    histogram_g[greenValue]++;
                    if (max < histogram_g[greenValue])
                        max = histogram_g[greenValue];
                }
            }

            int histHeight = 232;
            Bitmap img = new Bitmap(256, histHeight + 10);
            using (Graphics g = Graphics.FromImage(img))
            {
                for (int i = 0; i < histogram_g.Length; i++)
                {
                    float pct = histogram_g[i] / max;
                    g.DrawLine(Pens.Green,
                        new Point(i, img.Height - 5),
                        new Point(i, img.Height - 5 - (int)(pct * histHeight))
                        );
                }
            }
            histogram2.Image = img;
        }
        void rysujhistogramblue(Bitmap hist)
        {
            Bitmap bmp = hist;
            int[] histogram_b = new int[256];
            float max = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int bValue = bmp.GetPixel(i, j).B;
                    histogram_b[bValue]++;
                    if (max < histogram_b[bValue])
                        max = histogram_b[bValue];
                }
            }

            int histHeight = 232;
            Bitmap img = new Bitmap(256, histHeight + 10);
            using (Graphics g = Graphics.FromImage(img))
            {
                for (int i = 0; i < histogram_b.Length; i++)
                {
                    float pct = histogram_b[i] / max;
                    g.DrawLine(Pens.Blue,
                        new Point(i, img.Height - 5),
                        new Point(i, img.Height - 5 - (int)(pct * histHeight))
                        );
                }
            }
            histogram3.Image = img;
        }
        
    }
}
