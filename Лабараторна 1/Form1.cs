using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лабараторна_1
{
    public partial class Form1 : Form
    {
        Service service = new Service();


        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = (Image)new Bitmap(780, 400);
            DrawCoordinatePlane(Graphics.FromImage(pictureBox1.Image));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            service.InitProgram(Graphics.FromHwnd(pictureBox1.Handle));
        }

        private void DrawCoordinatePlane(Graphics graph)
        {
            Point curr = new Point( 10, pictureBox1.Height - 10);

            for (int i = 0; i < 30; i++)
            {
                graph.DrawLine(Pens.Black, new Point(curr.X, curr.Y - 5), new Point(curr.X, curr.Y + 5));
                Point other = new Point(curr.X + 26, curr.Y);
                graph.DrawLine(Pens.Black, curr, other);
                curr = other;
            }
        }
    }
}
