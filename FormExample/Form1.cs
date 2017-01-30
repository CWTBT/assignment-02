using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;


namespace FormExample
{
    public partial class Form1 : Form
    {
        public static Form form;
        public static Thread thread;
        public static int s = 100;
        public static int fps = 60;
        public static double running_fps = 60.0;
        public static double incrediblehihgspeed = 100;
        Sprite oval = new Sprite();
        

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            form = this;
            thread = new Thread(new ThreadStart(run));
            thread.Start();

        }

        public static void run()
        {
            DateTime last = DateTime.Now;
            DateTime now = last;
            TimeSpan frameTime = new TimeSpan(10000000 / fps);
            while (true)
            {
                DateTime temp = DateTime.Now;
                running_fps = .9 * running_fps + .1 * 1000.0 / (temp - now).TotalMilliseconds;
                Console.WriteLine(running_fps);
                now = temp;
                TimeSpan diff = now - last;
                if (diff.TotalMilliseconds< frameTime.TotalMilliseconds)
                    Thread.Sleep((frameTime-diff).Milliseconds);
                last = DateTime.Now;
                
                s++;
                incrediblehihgspeed += 1 / running_fps;
                form.Invoke(new MethodInvoker(form.Refresh));
                
            }
        }

        private void UpdateSize()
        {
            
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            thread.Abort();
        }

        protected override void OnResize(EventArgs e)
        {

            
            Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            
            base.OnMouseDown(e);
            Random rand = new Random();
            int xpos = rand.Next(ClientSize.Width);
            int ypos = rand.Next(ClientSize.Height);
            oval.add(new Sprite(xpos, ypos));
            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            //Refresh();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == 'a')
            {
                
                for (int i = 0; i < 100; i++)
                {
                    Random rand = new Random();
                    int xpos = rand.Next(ClientSize.Width);
                    int ypos = rand.Next(ClientSize.Height);
                    oval.add(new Sprite(xpos, ypos));
                }
            }
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            int v = (int)(200 + 100 * Math.Sin(incrediblehihgspeed * 10));
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, v, v);
            e.Graphics.DrawString("FPS: " + running_fps, new Font("Ubuntu", 10), Brushes.Brown, 00, 250);
            e.Graphics.DrawString("speed: " + incrediblehihgspeed, new Font("Ubuntu", 10), Brushes.Brown, 00, 500);

            oval.render(e.Graphics);


        }


    }
    
}
