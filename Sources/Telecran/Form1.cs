using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dessin
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private Bitmap b;
        private Pen myPen = new Pen(Color.Red, 3);
        private Point p1, p2;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            b = new Bitmap(Width, Height);
            g = Graphics.FromImage(b);
            p1 = new Point(this.Width / 2, this.Height / 2);
            p2 = new Point();
            p2 = p1;
            this.KeyPreview = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(b, 0, 0);
        }

        private void toUp()
        {
            p2.Y -= 10;
            g.DrawLine(myPen, p1, p2);
            p1 = p2;
            Invalidate();
        }

        

        private void toLeft()
        {
            p2.X -= 10;
            g.DrawLine(myPen, p1, p2);
            p1 = p2;
            Invalidate();
        }

        

        private void toDown()
        {
            p2.Y += 10;
            g.DrawLine(myPen, p1, p2);
            p1 = p2;
            Invalidate();
        }

        

        private void toRight()
        {
            p2.X += 10;
            g.DrawLine(myPen, p1, p2);
            p1 = p2;
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode) 
            {
                case (Keys.Up): toUp();  break;
                case (Keys.Left): toLeft(); break;
                case (Keys.Right): toRight(); break;
                case (Keys.Down): toDown(); break;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            b = new Bitmap(b, this.Size);
            g = Graphics.FromImage(b);
            g.Clear(this.BackColor);

        }
    }
}
