using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FormExample
{
    public class Sprite
    {
        //instance variable
        private float x = 0;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        private float y = 0;

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        private float scale = 1;

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public int xpos;
        public int ypos;

        protected List<Sprite> children = new List<Sprite>();

        public Sprite()
        {
        }

        public Sprite(int xpos, int ypos)
        {
            this.xpos = xpos;
            this.ypos = ypos;
        }

        public void render(Graphics g)
        {
            Matrix original = g.Transform.Clone();
            g.ScaleTransform(scale,scale);
            g.TranslateTransform(x, y);
            paint(g);
            foreach(Sprite s in children)
            {
                s.render(g);
            }
            g.Transform = original;
        }

        public virtual void paint(Graphics g)
        {
            Random rand = new Random();
            int re = rand.Next(255);
            int gr = rand.Next(255);
            int bl = rand.Next(255);
            SolidBrush fill = new SolidBrush(Color.FromArgb(re, gr, bl));
            g.TranslateTransform(xpos + 45, ypos + 65);
            g.RotateTransform(Form1.s * 50);
            g.TranslateTransform(-(xpos + 45), -(ypos + 65));
            g.FillEllipse(fill, new Rectangle(Math.Abs(xpos), Math.Abs(ypos), 90, 130));

        }

        public void add(Sprite s)
        {
            children.Add(s);
        }



    }
}
