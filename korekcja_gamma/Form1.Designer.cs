namespace korekcja_gamma
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wczytaj = new System.Windows.Forms.Button();
            this.labelgamma = new System.Windows.Forms.Label();
            this.suwakgamma = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.kontrast = new System.Windows.Forms.RadioButton();
            this.sepia = new System.Windows.Forms.RadioButton();
            this.jasnosc = new System.Windows.Forms.RadioButton();
            this.gamma = new System.Windows.Forms.RadioButton();
            this.suwakkontrast = new System.Windows.Forms.TrackBar();
            this.suwaksepia = new System.Windows.Forms.TrackBar();
            this.suwakjasnosc = new System.Windows.Forms.TrackBar();
            this.labeljasnosc = new System.Windows.Forms.Label();
            this.labelsepia = new System.Windows.Forms.Label();
            this.labelkontrast = new System.Windows.Forms.Label();
            this.suwakekspozycja = new System.Windows.Forms.TrackBar();
            this.labelekspozycja = new System.Windows.Forms.Label();
            this.suwaknegatyw = new System.Windows.Forms.TrackBar();
            this.labelnegatyw = new System.Windows.Forms.Label();
            this.zapisz = new System.Windows.Forms.Button();
            this.wczytaj2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bsuma = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.zapisz2 = new System.Windows.Forms.Button();
            this.bodejmowanie = new System.Windows.Forms.Button();
            this.broznica = new System.Windows.Forms.Button();
            this.bmnozenie = new System.Windows.Forms.Button();
            this.bodwrotnosc = new System.Windows.Forms.Button();
            this.bnegacja = new System.Windows.Forms.Button();
            this.bCiemniejsze = new System.Windows.Forms.Button();
            this.bjasniejsze = new System.Windows.Forms.Button();
            this.bWyłaczenie = new System.Windows.Forms.Button();
            this.bnakladka = new System.Windows.Forms.Button();
            this.bostre = new System.Windows.Forms.Button();
            this.blagodne = new System.Windows.Forms.Button();
            this.brozcienczenie = new System.Windows.Forms.Button();
            this.bwypalenie = new System.Windows.Forms.Button();
            this.breflect = new System.Windows.Forms.Button();
            this.histogram = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.histogram2 = new System.Windows.Forms.PictureBox();
            this.histogram3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.transformacjajasnosc = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.suwakgamma)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suwakkontrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suwaksepia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suwakjasnosc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suwakekspozycja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suwaknegatyw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformacjajasnosc)).BeginInit();
            this.SuspendLayout();
            // 
            // wczytaj
            // 
            this.wczytaj.Location = new System.Drawing.Point(91, 12);
            this.wczytaj.Name = "wczytaj";
            this.wczytaj.Size = new System.Drawing.Size(100, 23);
            this.wczytaj.TabIndex = 1;
            this.wczytaj.Text = "Wczytaj Obraz";
            this.wczytaj.UseVisualStyleBackColor = true;
            this.wczytaj.Click += new System.EventHandler(this.wczytaj_Click);
            // 
            // labelgamma
            // 
            this.labelgamma.AutoSize = true;
            this.labelgamma.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelgamma.Location = new System.Drawing.Point(140, 236);
            this.labelgamma.Name = "labelgamma";
            this.labelgamma.Size = new System.Drawing.Size(109, 31);
            this.labelgamma.TabIndex = 2;
            this.labelgamma.Text = "Gamma";
            // 
            // suwakgamma
            // 
            this.suwakgamma.LargeChange = 10;
            this.suwakgamma.Location = new System.Drawing.Point(2, 273);
            this.suwakgamma.Maximum = 400;
            this.suwakgamma.Minimum = 1;
            this.suwakgamma.Name = "suwakgamma";
            this.suwakgamma.Size = new System.Drawing.Size(397, 45);
            this.suwakgamma.TabIndex = 3;
            this.suwakgamma.TickFrequency = 10;
            this.suwakgamma.Value = 100;
            this.suwakgamma.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.kontrast);
            this.groupBox1.Controls.Add(this.sepia);
            this.groupBox1.Controls.Add(this.jasnosc);
            this.groupBox1.Controls.Add(this.gamma);
            this.groupBox1.Location = new System.Drawing.Point(49, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ustawienia";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(142, 66);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Negatyw";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.negatyw_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(142, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(79, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Ekspozycja";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.ekspozycja_CheckedChanged);
            // 
            // kontrast
            // 
            this.kontrast.AutoSize = true;
            this.kontrast.Location = new System.Drawing.Point(142, 19);
            this.kontrast.Name = "kontrast";
            this.kontrast.Size = new System.Drawing.Size(64, 17);
            this.kontrast.TabIndex = 3;
            this.kontrast.TabStop = true;
            this.kontrast.Text = "Kontrast";
            this.kontrast.UseVisualStyleBackColor = true;
            this.kontrast.CheckedChanged += new System.EventHandler(this.kontrast_CheckedChanged);
            // 
            // sepia
            // 
            this.sepia.AutoSize = true;
            this.sepia.Location = new System.Drawing.Point(24, 66);
            this.sepia.Name = "sepia";
            this.sepia.Size = new System.Drawing.Size(52, 17);
            this.sepia.TabIndex = 2;
            this.sepia.TabStop = true;
            this.sepia.Text = "Sepia";
            this.sepia.UseVisualStyleBackColor = true;
            this.sepia.CheckedChanged += new System.EventHandler(this.sepia_CheckedChanged);
            // 
            // jasnosc
            // 
            this.jasnosc.AutoSize = true;
            this.jasnosc.Location = new System.Drawing.Point(24, 42);
            this.jasnosc.Name = "jasnosc";
            this.jasnosc.Size = new System.Drawing.Size(64, 17);
            this.jasnosc.TabIndex = 1;
            this.jasnosc.Text = "Jasność";
            this.jasnosc.UseVisualStyleBackColor = true;
            this.jasnosc.CheckedChanged += new System.EventHandler(this.jasnosc_CheckedChanged);
            // 
            // gamma
            // 
            this.gamma.AutoSize = true;
            this.gamma.Checked = true;
            this.gamma.Location = new System.Drawing.Point(24, 19);
            this.gamma.Name = "gamma";
            this.gamma.Size = new System.Drawing.Size(61, 17);
            this.gamma.TabIndex = 0;
            this.gamma.TabStop = true;
            this.gamma.Text = "Gamma";
            this.gamma.UseVisualStyleBackColor = true;
            this.gamma.CheckedChanged += new System.EventHandler(this.gamma_CheckedChanged);
            // 
            // suwakkontrast
            // 
            this.suwakkontrast.Location = new System.Drawing.Point(2, 273);
            this.suwakkontrast.Maximum = 256;
            this.suwakkontrast.Minimum = -256;
            this.suwakkontrast.Name = "suwakkontrast";
            this.suwakkontrast.Size = new System.Drawing.Size(397, 45);
            this.suwakkontrast.TabIndex = 9;
            this.suwakkontrast.TickFrequency = 10;
            this.suwakkontrast.Visible = false;
            this.suwakkontrast.ValueChanged += new System.EventHandler(this.trackBar4_ValueChanged);
            // 
            // suwaksepia
            // 
            this.suwaksepia.Location = new System.Drawing.Point(2, 273);
            this.suwaksepia.Maximum = 256;
            this.suwaksepia.Minimum = -256;
            this.suwaksepia.Name = "suwaksepia";
            this.suwaksepia.Size = new System.Drawing.Size(397, 45);
            this.suwaksepia.TabIndex = 7;
            this.suwaksepia.TickFrequency = 10;
            this.suwaksepia.Visible = false;
            this.suwaksepia.ValueChanged += new System.EventHandler(this.trackBar3_ValueChanged);
            // 
            // suwakjasnosc
            // 
            this.suwakjasnosc.LargeChange = 10;
            this.suwakjasnosc.Location = new System.Drawing.Point(2, 273);
            this.suwakjasnosc.Maximum = 256;
            this.suwakjasnosc.Minimum = -256;
            this.suwakjasnosc.Name = "suwakjasnosc";
            this.suwakjasnosc.Size = new System.Drawing.Size(397, 45);
            this.suwakjasnosc.TabIndex = 5;
            this.suwakjasnosc.TabStop = false;
            this.suwakjasnosc.TickFrequency = 10;
            this.suwakjasnosc.Visible = false;
            this.suwakjasnosc.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // labeljasnosc
            // 
            this.labeljasnosc.AutoSize = true;
            this.labeljasnosc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labeljasnosc.Location = new System.Drawing.Point(140, 236);
            this.labeljasnosc.Name = "labeljasnosc";
            this.labeljasnosc.Size = new System.Drawing.Size(115, 31);
            this.labeljasnosc.TabIndex = 6;
            this.labeljasnosc.Text = "Jasność";
            this.labeljasnosc.Visible = false;
            // 
            // labelsepia
            // 
            this.labelsepia.AutoSize = true;
            this.labelsepia.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelsepia.Location = new System.Drawing.Point(155, 236);
            this.labelsepia.Name = "labelsepia";
            this.labelsepia.Size = new System.Drawing.Size(83, 31);
            this.labelsepia.TabIndex = 8;
            this.labelsepia.Text = "Sepia";
            this.labelsepia.Visible = false;
            // 
            // labelkontrast
            // 
            this.labelkontrast.AutoSize = true;
            this.labelkontrast.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelkontrast.Location = new System.Drawing.Point(139, 236);
            this.labelkontrast.Name = "labelkontrast";
            this.labelkontrast.Size = new System.Drawing.Size(116, 31);
            this.labelkontrast.TabIndex = 10;
            this.labelkontrast.Text = "Kontrast";
            this.labelkontrast.Visible = false;
            // 
            // suwakekspozycja
            // 
            this.suwakekspozycja.Location = new System.Drawing.Point(2, 274);
            this.suwakekspozycja.Maximum = 256;
            this.suwakekspozycja.Minimum = -256;
            this.suwakekspozycja.Name = "suwakekspozycja";
            this.suwakekspozycja.Size = new System.Drawing.Size(397, 45);
            this.suwakekspozycja.TabIndex = 11;
            this.suwakekspozycja.TickFrequency = 10;
            this.suwakekspozycja.Visible = false;
            this.suwakekspozycja.ValueChanged += new System.EventHandler(this.trackBar5_ValueChanged);
            // 
            // labelekspozycja
            // 
            this.labelekspozycja.AutoSize = true;
            this.labelekspozycja.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelekspozycja.Location = new System.Drawing.Point(122, 239);
            this.labelekspozycja.Name = "labelekspozycja";
            this.labelekspozycja.Size = new System.Drawing.Size(153, 31);
            this.labelekspozycja.TabIndex = 12;
            this.labelekspozycja.Text = "Ekspozycja";
            this.labelekspozycja.Visible = false;
            // 
            // suwaknegatyw
            // 
            this.suwaknegatyw.Location = new System.Drawing.Point(145, 273);
            this.suwaknegatyw.Maximum = 1;
            this.suwaknegatyw.Name = "suwaknegatyw";
            this.suwaknegatyw.Size = new System.Drawing.Size(104, 45);
            this.suwaknegatyw.TabIndex = 13;
            this.suwaknegatyw.Visible = false;
            this.suwaknegatyw.ValueChanged += new System.EventHandler(this.negatyw_ValueChanged_1);
            // 
            // labelnegatyw
            // 
            this.labelnegatyw.AutoSize = true;
            this.labelnegatyw.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelnegatyw.Location = new System.Drawing.Point(134, 239);
            this.labelnegatyw.Name = "labelnegatyw";
            this.labelnegatyw.Size = new System.Drawing.Size(121, 31);
            this.labelnegatyw.TabIndex = 14;
            this.labelnegatyw.Text = "Negatyw";
            this.labelnegatyw.Visible = false;
            // 
            // zapisz
            // 
            this.zapisz.Location = new System.Drawing.Point(202, 12);
            this.zapisz.Name = "zapisz";
            this.zapisz.Size = new System.Drawing.Size(101, 23);
            this.zapisz.TabIndex = 15;
            this.zapisz.Text = "Zapisz Obraz";
            this.zapisz.UseVisualStyleBackColor = true;
            this.zapisz.Click += new System.EventHandler(this.zapisz_Click);
            // 
            // wczytaj2
            // 
            this.wczytaj2.Location = new System.Drawing.Point(424, 12);
            this.wczytaj2.Name = "wczytaj2";
            this.wczytaj2.Size = new System.Drawing.Size(100, 23);
            this.wczytaj2.TabIndex = 16;
            this.wczytaj2.Text = "Wczytaj Obrazy";
            this.wczytaj2.UseVisualStyleBackColor = true;
            this.wczytaj2.Click += new System.EventHandler(this.wczytaj2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(424, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 194);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(704, 152);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(248, 194);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // bsuma
            // 
            this.bsuma.Location = new System.Drawing.Point(424, 53);
            this.bsuma.Name = "bsuma";
            this.bsuma.Size = new System.Drawing.Size(75, 23);
            this.bsuma.TabIndex = 19;
            this.bsuma.Text = "Suma";
            this.bsuma.UseVisualStyleBackColor = true;
            this.bsuma.Click += new System.EventHandler(this.bsuma_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(530, 12);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(306, 45);
            this.trackBar1.TabIndex = 20;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // zapisz2
            // 
            this.zapisz2.Location = new System.Drawing.Point(842, 12);
            this.zapisz2.Name = "zapisz2";
            this.zapisz2.Size = new System.Drawing.Size(110, 23);
            this.zapisz2.TabIndex = 21;
            this.zapisz2.Text = "Zapisz Obraz";
            this.zapisz2.UseVisualStyleBackColor = true;
            this.zapisz2.Click += new System.EventHandler(this.zapisz2_Click);
            // 
            // bodejmowanie
            // 
            this.bodejmowanie.Location = new System.Drawing.Point(506, 53);
            this.bodejmowanie.Name = "bodejmowanie";
            this.bodejmowanie.Size = new System.Drawing.Size(83, 23);
            this.bodejmowanie.TabIndex = 22;
            this.bodejmowanie.Text = "Odejmowanie";
            this.bodejmowanie.UseVisualStyleBackColor = true;
            this.bodejmowanie.Click += new System.EventHandler(this.bodejmowanie_Click);
            // 
            // broznica
            // 
            this.broznica.Location = new System.Drawing.Point(782, 54);
            this.broznica.Name = "broznica";
            this.broznica.Size = new System.Drawing.Size(75, 23);
            this.broznica.TabIndex = 23;
            this.broznica.Text = "Różnica";
            this.broznica.UseVisualStyleBackColor = true;
            this.broznica.Click += new System.EventHandler(this.Roznica_Click);
            // 
            // bmnozenie
            // 
            this.bmnozenie.Location = new System.Drawing.Point(863, 53);
            this.bmnozenie.Name = "bmnozenie";
            this.bmnozenie.Size = new System.Drawing.Size(89, 23);
            this.bmnozenie.TabIndex = 24;
            this.bmnozenie.Text = "Mnożenie";
            this.bmnozenie.UseVisualStyleBackColor = true;
            this.bmnozenie.Click += new System.EventHandler(this.bmnozenie_Click);
            // 
            // bodwrotnosc
            // 
            this.bodwrotnosc.Location = new System.Drawing.Point(609, 53);
            this.bodwrotnosc.Name = "bodwrotnosc";
            this.bodwrotnosc.Size = new System.Drawing.Size(157, 23);
            this.bodwrotnosc.TabIndex = 25;
            this.bodwrotnosc.Text = "Mnożenie odwrotności";
            this.bodwrotnosc.UseVisualStyleBackColor = true;
            this.bodwrotnosc.Click += new System.EventHandler(this.bodwrotnosc_Click);
            // 
            // bnegacja
            // 
            this.bnegacja.Location = new System.Drawing.Point(424, 83);
            this.bnegacja.Name = "bnegacja";
            this.bnegacja.Size = new System.Drawing.Size(75, 23);
            this.bnegacja.TabIndex = 26;
            this.bnegacja.Text = "Negacja";
            this.bnegacja.UseVisualStyleBackColor = true;
            this.bnegacja.Click += new System.EventHandler(this.bnegacja_Click);
            // 
            // bCiemniejsze
            // 
            this.bCiemniejsze.Location = new System.Drawing.Point(506, 83);
            this.bCiemniejsze.Name = "bCiemniejsze";
            this.bCiemniejsze.Size = new System.Drawing.Size(83, 23);
            this.bCiemniejsze.TabIndex = 27;
            this.bCiemniejsze.Text = "Ciemniejsze";
            this.bCiemniejsze.UseVisualStyleBackColor = true;
            this.bCiemniejsze.Click += new System.EventHandler(this.bCiemniejsze_Click);
            // 
            // bjasniejsze
            // 
            this.bjasniejsze.Location = new System.Drawing.Point(609, 82);
            this.bjasniejsze.Name = "bjasniejsze";
            this.bjasniejsze.Size = new System.Drawing.Size(75, 23);
            this.bjasniejsze.TabIndex = 28;
            this.bjasniejsze.Text = "Jaśniejsze";
            this.bjasniejsze.UseVisualStyleBackColor = true;
            this.bjasniejsze.Click += new System.EventHandler(this.bjasniejsze_Click);
            // 
            // bWyłaczenie
            // 
            this.bWyłaczenie.Location = new System.Drawing.Point(691, 82);
            this.bWyłaczenie.Name = "bWyłaczenie";
            this.bWyłaczenie.Size = new System.Drawing.Size(75, 23);
            this.bWyłaczenie.TabIndex = 29;
            this.bWyłaczenie.Text = "Wyłączenie";
            this.bWyłaczenie.UseVisualStyleBackColor = true;
            this.bWyłaczenie.Click += new System.EventHandler(this.bWyłaczenie_Click);
            // 
            // bnakladka
            // 
            this.bnakladka.Location = new System.Drawing.Point(781, 83);
            this.bnakladka.Name = "bnakladka";
            this.bnakladka.Size = new System.Drawing.Size(75, 23);
            this.bnakladka.TabIndex = 30;
            this.bnakladka.Text = "Nakładka";
            this.bnakladka.UseVisualStyleBackColor = true;
            this.bnakladka.Click += new System.EventHandler(this.bnakladka_Click);
            // 
            // bostre
            // 
            this.bostre.Location = new System.Drawing.Point(862, 83);
            this.bostre.Name = "bostre";
            this.bostre.Size = new System.Drawing.Size(90, 23);
            this.bostre.TabIndex = 31;
            this.bostre.Text = "Ostre światło";
            this.bostre.UseVisualStyleBackColor = true;
            this.bostre.Click += new System.EventHandler(this.bostre_Click);
            // 
            // blagodne
            // 
            this.blagodne.Location = new System.Drawing.Point(494, 112);
            this.blagodne.Name = "blagodne";
            this.blagodne.Size = new System.Drawing.Size(75, 23);
            this.blagodne.TabIndex = 32;
            this.blagodne.Text = "Łagodne światło";
            this.blagodne.UseVisualStyleBackColor = true;
            this.blagodne.Click += new System.EventHandler(this.blagodne_Click);
            // 
            // brozcienczenie
            // 
            this.brozcienczenie.Location = new System.Drawing.Point(576, 111);
            this.brozcienczenie.Name = "brozcienczenie";
            this.brozcienczenie.Size = new System.Drawing.Size(83, 23);
            this.brozcienczenie.TabIndex = 33;
            this.brozcienczenie.Text = "Rozcieńczenie";
            this.brozcienczenie.UseVisualStyleBackColor = true;
            this.brozcienczenie.Click += new System.EventHandler(this.brozcienczenie_Click);
            // 
            // bwypalenie
            // 
            this.bwypalenie.Location = new System.Drawing.Point(666, 112);
            this.bwypalenie.Name = "bwypalenie";
            this.bwypalenie.Size = new System.Drawing.Size(75, 23);
            this.bwypalenie.TabIndex = 34;
            this.bwypalenie.Text = "Wypalanie";
            this.bwypalenie.UseVisualStyleBackColor = true;
            this.bwypalenie.Click += new System.EventHandler(this.bwypalenie_Click);
            // 
            // breflect
            // 
            this.breflect.Location = new System.Drawing.Point(748, 112);
            this.breflect.Name = "breflect";
            this.breflect.Size = new System.Drawing.Size(75, 23);
            this.breflect.TabIndex = 35;
            this.breflect.Text = "Reflect mode";
            this.breflect.UseVisualStyleBackColor = true;
            this.breflect.Click += new System.EventHandler(this.breflect_Click);
            // 
            // histogram
            // 
            this.histogram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histogram.Location = new System.Drawing.Point(22, 443);
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size(281, 165);
            this.histogram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.histogram.TabIndex = 36;
            this.histogram.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(394, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 39);
            this.label1.TabIndex = 37;
            this.label1.Text = "Histogramy";
            // 
            // histogram2
            // 
            this.histogram2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histogram2.Location = new System.Drawing.Point(345, 443);
            this.histogram2.Name = "histogram2";
            this.histogram2.Size = new System.Drawing.Size(281, 165);
            this.histogram2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.histogram2.TabIndex = 38;
            this.histogram2.TabStop = false;
            // 
            // histogram3
            // 
            this.histogram3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histogram3.Location = new System.Drawing.Point(671, 443);
            this.histogram3.Name = "histogram3";
            this.histogram3.Size = new System.Drawing.Size(281, 165);
            this.histogram3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.histogram3.TabIndex = 39;
            this.histogram3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(106, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 24);
            this.label2.TabIndex = 40;
            this.label2.Text = "CZERWONY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(434, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 24);
            this.label3.TabIndex = 41;
            this.label3.Text = "ZIELONY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(759, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 24);
            this.label4.TabIndex = 42;
            this.label4.Text = "NIEBIESKI";
            // 
            // transformacjajasnosc
            // 
            this.transformacjajasnosc.Location = new System.Drawing.Point(16, 359);
            this.transformacjajasnosc.Maximum = 255;
            this.transformacjajasnosc.Name = "transformacjajasnosc";
            this.transformacjajasnosc.Size = new System.Drawing.Size(372, 45);
            this.transformacjajasnosc.TabIndex = 43;
            this.transformacjajasnosc.TickFrequency = 10;
            this.transformacjajasnosc.Scroll += new System.EventHandler(this.transformacjajasnosc_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(123, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 25);
            this.label5.TabIndex = 44;
            this.label5.Text = "Transformacja";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 626);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.transformacjajasnosc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.histogram3);
            this.Controls.Add(this.histogram2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.histogram);
            this.Controls.Add(this.breflect);
            this.Controls.Add(this.bwypalenie);
            this.Controls.Add(this.brozcienczenie);
            this.Controls.Add(this.blagodne);
            this.Controls.Add(this.bostre);
            this.Controls.Add(this.bnakladka);
            this.Controls.Add(this.bWyłaczenie);
            this.Controls.Add(this.bjasniejsze);
            this.Controls.Add(this.bCiemniejsze);
            this.Controls.Add(this.bnegacja);
            this.Controls.Add(this.bodwrotnosc);
            this.Controls.Add(this.bmnozenie);
            this.Controls.Add(this.broznica);
            this.Controls.Add(this.bodejmowanie);
            this.Controls.Add(this.zapisz2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.bsuma);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.wczytaj2);
            this.Controls.Add(this.zapisz);
            this.Controls.Add(this.labelnegatyw);
            this.Controls.Add(this.suwaknegatyw);
            this.Controls.Add(this.labelekspozycja);
            this.Controls.Add(this.suwakekspozycja);
            this.Controls.Add(this.labelkontrast);
            this.Controls.Add(this.suwakjasnosc);
            this.Controls.Add(this.suwaksepia);
            this.Controls.Add(this.suwakkontrast);
            this.Controls.Add(this.labelsepia);
            this.Controls.Add(this.labeljasnosc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.suwakgamma);
            this.Controls.Add(this.labelgamma);
            this.Controls.Add(this.wczytaj);
            this.Name = "Form1";
            this.Text = "Grafika";
            ((System.ComponentModel.ISupportInitialize)(this.suwakgamma)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suwakkontrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suwaksepia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suwakjasnosc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suwakekspozycja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suwaknegatyw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformacjajasnosc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button wczytaj;
        private System.Windows.Forms.Label labelgamma;
        private System.Windows.Forms.TrackBar suwakgamma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton jasnosc;
        private System.Windows.Forms.RadioButton gamma;
        private System.Windows.Forms.TrackBar suwakjasnosc;
        private System.Windows.Forms.Label labeljasnosc;
        private System.Windows.Forms.TrackBar suwaksepia;
        private System.Windows.Forms.Label labelsepia;
        private System.Windows.Forms.RadioButton sepia;
        private System.Windows.Forms.RadioButton kontrast;
        private System.Windows.Forms.TrackBar suwakkontrast;
        private System.Windows.Forms.Label labelkontrast;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TrackBar suwakekspozycja;
        private System.Windows.Forms.Label labelekspozycja;
        private System.Windows.Forms.TrackBar suwaknegatyw;
        private System.Windows.Forms.Label labelnegatyw;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button zapisz;
        private System.Windows.Forms.Button wczytaj2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button bsuma;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button zapisz2;
        private System.Windows.Forms.Button bodejmowanie;
        private System.Windows.Forms.Button broznica;
        private System.Windows.Forms.Button bmnozenie;
        private System.Windows.Forms.Button bodwrotnosc;
        private System.Windows.Forms.Button bnegacja;
        private System.Windows.Forms.Button bCiemniejsze;
        private System.Windows.Forms.Button bjasniejsze;
        private System.Windows.Forms.Button bWyłaczenie;
        private System.Windows.Forms.Button bnakladka;
        private System.Windows.Forms.Button bostre;
        private System.Windows.Forms.Button blagodne;
        private System.Windows.Forms.Button brozcienczenie;
        private System.Windows.Forms.Button bwypalenie;
        private System.Windows.Forms.Button breflect;
        private System.Windows.Forms.PictureBox histogram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox histogram2;
        private System.Windows.Forms.PictureBox histogram3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar transformacjajasnosc;
        private System.Windows.Forms.Label label5;
    }
}

