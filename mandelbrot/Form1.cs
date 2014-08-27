using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mandelbrot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void go()
        {
            //double MinRe = -0.5;
            //double MaxRe = 0.5;
            //double MinIm = -0.6;

            double MinRe = Convert.ToDouble(textBox1.Text);
            double MaxRe = Convert.ToDouble(textBox2.Text);
            double MinIm = Convert.ToDouble(textBox3.Text);
            double MaxIm = Convert.ToDouble(textBox4.Text);

            //double MaxIm = MinIm + (MaxRe - MinRe) * this.Height / this.Width;
            double Re_factor = (MaxRe - MinRe) / (this.Width - 1);
            double Im_factor = (MaxIm - MinIm) / (this.Height - 1);

            Re_factor /= Convert.ToDouble(textBox5.Text);
            Im_factor /= Convert.ToDouble(textBox5.Text);
            int MaxIterations = Convert.ToInt32(textBox6.Text);

            Graphics g = this.CreateGraphics();

            g.Clear(Color.White);
            for (int y = 0; y < this.Height; ++y)
            {
                //g.FillRectangle(new SolidBrush(Color.White), 0, y, this.Width, 1);
                double c_im = MaxIm - y * Im_factor;
                for (int x = 0; x < this.Width; ++x)
                {
                    double c_re = MinRe + x * Re_factor;

                    double Z_re = c_re, Z_im = c_im;

                    bool isInside = true;

                    for (int n = 0; n < MaxIterations; ++n)
                    {
                        double Z_re2 = Z_re * Z_re, Z_im2 = Z_im * Z_im;
                        if (Z_re2 + Z_im2 > 4)
                        {
                            double s = ((double)n / (double)MaxIterations) * 255d;
                            //g.FillRectangle(new SolidBrush(Color.White), x, y, 1, 1);
                            g.FillRectangle(new SolidBrush(getKleur((int)s)), x, y, 1, 1);

                            isInside = false;
                            break;
                        }
                        Z_im = 2 * Z_re * Z_im + c_im;
                        Z_re = Z_re2 - Z_im2 + c_re;
                    }
                    if (isInside)
                    {
                        //putpixel(x, y);
                        //g.FillRectangle(Brushes.Black, x, y, 1, 1);
                    }
                }
            }
        }

        void go(double minre, double maxre, double minim, double maxim)
        {
            //double MinRe = -0.5;
            //double MaxRe = 0.5;
            //double MinIm = -0.6;

            double MinRe = minre;
            double MaxRe = maxre;
            double MinIm = minim;
            double MaxIm = maxim;

            textBox1.Text = "" + MinRe;
            textBox2.Text = "" + MaxRe;
            textBox3.Text = "" + MinIm;
            textBox4.Text = "" + MaxIm;


            //double MaxIm = MinIm + (MaxRe - MinRe) * this.Height / this.Width;
            double Re_factor = (MaxRe - MinRe) / (this.Width - 1);
            double Im_factor = (MaxIm - MinIm) / (this.Height - 1);

            //Re_factor /= Convert.ToDouble(textBox5.Text);
            //Im_factor /= Convert.ToDouble(textBox5.Text);
            int MaxIterations = Convert.ToInt32(textBox6.Text);

            Graphics g = this.CreateGraphics();

            g.Clear(Color.White);
            for (int y = 0; y < this.Height; ++y)
            {
                //g.FillRectangle(new SolidBrush(Color.White), 0, y, this.Width, 1);
                double c_im = MaxIm - y * Im_factor;
                for (int x = 0; x < this.Width; ++x)
                {
                    double c_re = MinRe + x * Re_factor;

                    double Z_re = c_re, Z_im = c_im;

                    bool isInside = true;

                    for (int n = 0; n < MaxIterations; ++n)
                    {
                        double Z_re2 = Z_re * Z_re, Z_im2 = Z_im * Z_im;
                        if (Z_re2 + Z_im2 > 4)
                        {
                            double s = ((double)n / (double)MaxIterations) * 255d;
                            //g.FillRectangle(new SolidBrush(Color.White), x, y, 1, 1);
                            g.FillRectangle(new SolidBrush(getKleur((int)s)), x, y, 1, 1);

                            isInside = false;
                            break;
                        }
                        Z_im = 2 * Z_re * Z_im + c_im;
                        Z_re = Z_re2 - Z_im2 + c_re;
                    }
                    if (isInside)
                    {
                        //putpixel(x, y);
                        //g.FillRectangle(Brushes.Black, x, y, 1, 1);
                    }
                }
            }
        }

        Color getKleur(int v)
        {
            return Color.FromArgb(v, 0, 0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            go();
        }


        double minX = -2;
        double maxX = 1;
        double minY = -1.2;
        double maxY = 1.2;
        double diffX = 1.5;
        double diffY = 1.2;
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double x = (((double)e.X / (double)this.Width) * (maxX - minX)) + minX;
            minX = x - diffX;
            maxX = x + diffX;
            double y = ((1-((double)e.Y / (double)this.Height)) * (maxY - minY)) + minY;
            minY = y - diffY;
            maxY = y + diffY;
            go(minX, maxX, minY, maxY);
            diffX *= 0.2;
            diffY *= 0.2;
        }
    }
}
