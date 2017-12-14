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
        private Pen myPen = new Pen(Color.Red, 4);
        private Point p1, p2;
        private int x,y,shift=10;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            b = new Bitmap(Width, Height);
            g = Graphics.FromImage(b);
            x=this.Width / 2;
            y = this.Height / 2;
            p1 = new Point(x, y);
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
            y = p2.Y - shift;
            if (y > 30)
            {
                p2.Y = y;
                g.DrawLine(myPen, p1, p2);
                p1 = p2;
                Invalidate();
            }
        }

        

        private void toLeft()
        {
            x = p2.X - shift;
            if (x > 0)
            {
                p2.X = x;
                g.DrawLine(myPen, p1, p2);
                p1 = p2;
                Invalidate();
            }
        }

        

        private void toDown()
        {
            y = p2.Y + shift;
            if (y < this.Height - 45)
            {
                p2.Y = y;
                g.DrawLine(myPen, p1, p2);
                p1 = p2;
                Invalidate();
            }
        }

        

        private void toRight()
        {
            x = p2.X + shift;
            if (x < this.Width - 18)
            {
                p2.X = x;
                g.DrawLine(myPen, p1, p2);
                p1 = p2;
                Invalidate();
            }
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

        
        private void couleurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.Color = myPen.Color;

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                myPen.Color = MyDialog.Color;
            }
        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog mySaveFileDialog = new SaveFileDialog();
            mySaveFileDialog.Filter = "Image bmp (*.bmp) | *.bmp";
            if (mySaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                b.Save(mySaveFileDialog.FileName);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            myPen.Width =1;
            checkItems(toolStripMenuItem2);
        }

        private void checkItems(ToolStripMenuItem item)
        {
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;
            item.Checked = true;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            myPen.Width = 2;
            checkItems(toolStripMenuItem3);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            myPen.Width = 3;
            checkItems(toolStripMenuItem4);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            myPen.Width = 4;
            checkItems(toolStripMenuItem5);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            myPen.Width = 5;
            checkItems(toolStripMenuItem6);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            myPen.Width = 6;
            checkItems(toolStripMenuItem7);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            myPen.Width = 7;
            checkItems(toolStripMenuItem8);
        }

        private void shiftItem(ToolStripMenuItem item)
        {
            toolStripMenuItem9.Checked = false;
            toolStripMenuItem10.Checked = false;
            toolStripMenuItem11.Checked = false;
            toolStripMenuItem12.Checked = false;
            toolStripMenuItem13.Checked = false;
            
            item.Checked = true;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            shift = 1;
            shiftItem(toolStripMenuItem9);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            shift = 5;
            shiftItem(toolStripMenuItem10);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            shift = 10;
            shiftItem(toolStripMenuItem11);
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            shift = 20;
            shiftItem(toolStripMenuItem12);
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            shift = 30;
            shiftItem(toolStripMenuItem13);
        }

        private void effacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(this.BackColor);
            x = this.Width / 2;
            y = this.Height / 2;
            p2.X = x; p2.Y = y;
            p1 = p2;
            g.DrawLine(myPen, p1, p2);
            Invalidate();
        }

       

        
    }
}
