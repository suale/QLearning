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

namespace QLearning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {




            PictureBox[,] pictureBoxes = new PictureBox[50, 50];

            int tepe = 0, sol = 0;

            Random random = new Random();
            int secim = 0;

            for (int i = 0; i <= pictureBoxes.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= pictureBoxes.GetUpperBound(1); j++)
                {
                    pictureBoxes[i, j] = new PictureBox();
                    pictureBoxes[i, j].Height = 15;
                    pictureBoxes[i, j].Width = 25;
                    pictureBoxes[i, j].Left = sol;

                    pictureBoxes[i, j].Top = tepe;
                    pictureBoxes[i, j].BorderStyle = BorderStyle.FixedSingle;
                    pictureBoxes[i, j].Click += picturebox_Click;

                    void picturebox_Click(object a, EventArgs arg)
                    {
                        PictureBox box = (PictureBox)a;
                        if (box.BackColor == Color.White)
                        {
                            if (secim == 0)
                                box.BackColor = Color.LightSkyBlue;
                            else if (secim == 1)
                                box.BackColor = Color.LightSeaGreen;
                            else
                                MessageBox.Show("Başlangıç ve hedefi seçtiniz");
                            secim++;
                        }
                        else
                            MessageBox.Show("Lütfen seçiminizi beyaz kutulardan yapın");

                    }

                    int renk = random.Next();

                    if (renk % 2 == 0)
                        pictureBoxes[i, j].BackColor = Color.White;
                    else
                        pictureBoxes[i, j].BackColor = Color.Pink;
                    this.Controls.Add(pictureBoxes[i, j]);
                    sol = sol + 25;



                }
                sol = 0;
                tepe = tepe + 15;
            }

            Button kaydet = new Button();
            kaydet.Location = new Point(1275, 25);
            kaydet.Text = "Kaydet";
            kaydet.Click += new EventHandler(kaydetClick);
            this.Controls.Add(kaydet);

            void kaydetClick(object objs, EventArgs argss)
            {
                using (StreamWriter writetext = new StreamWriter("engeller.txt"))
                {
                    for (int i = 0; i <= pictureBoxes.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j < pictureBoxes.GetUpperBound(1); j++)
                        {
                            writetext.WriteLine("{0}, {1}, {2}",i+1,j+1,pictureBoxes[i,j].BackColor);
                        }
                    }

                }
            }

        }

        
    }
}
