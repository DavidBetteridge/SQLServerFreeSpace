using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ProtoBuf;

namespace DisplayFreeSpace
{
    public partial class MainForm : Form
    {
        private const int GAM_SIZE = 511232;
        private const int WINDOW_SIZE = 100;
        private const int BOTTOM_OF_TOP_GRAPH = 200;
        private const int BOTTOM_OF_LOWER_GRAPH = 400;

        private string path1;
        private string path2;
        private Data data1 = new Data();
        private Data data2 = new Data();

        public MainForm(string path1, string path2)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.path1 = path1;
            this.path2 = path2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadData()
        {
            using (var file = File.OpenRead(this.path1))
            {
                this.data1 = Serializer.Deserialize<Data>(file);
            }

            if (!string.IsNullOrWhiteSpace(this.path2))
            {
                using (var file = File.OpenRead(this.path2))
                {
                    this.data2 = Serializer.Deserialize<Data>(file);
                }
            }

            this.hScrollBar1.Minimum = 0;
            this.hScrollBar1.Maximum = this.data1.Extents.Length - (this.ClientSize.Width * WINDOW_SIZE);
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var allocatedBrush = new SolidBrush(Color.Red);
            var unallocatedBrush = new SolidBrush(Color.Green);

            var currentFrameSize1 = 0;
            var frameAllocated1 = 0;
            var nextX1 = 0;
            var currentFrameSize2 = 0;
            var frameAllocated2 = 0;
            var nextX2 = 0;

            var midPoint = BOTTOM_OF_LOWER_GRAPH - (WINDOW_SIZE / 2);
            var midPoint2 = BOTTOM_OF_TOP_GRAPH - (WINDOW_SIZE / 2);

            g.FillRectangle(new SolidBrush(Color.LightGray), 0, BOTTOM_OF_LOWER_GRAPH - WINDOW_SIZE - 25, this.ClientSize.Width, 25);
            g.FillRectangle(Brushes.LightGray, 0, BOTTOM_OF_TOP_GRAPH - WINDOW_SIZE - 25, this.ClientSize.Width, 25);

            for (int i = this.hScrollBar1.Value; i < this.hScrollBar1.Value + (this.ClientSize.Width * WINDOW_SIZE); i++)
            {
                // File 1
                currentFrameSize1++;
                DrawFile1(g, ref currentFrameSize1, WINDOW_SIZE, ref frameAllocated1, ref nextX1, midPoint, i);

                // File2
                currentFrameSize2++;
                DrawFile2(g, ref currentFrameSize2, WINDOW_SIZE, ref frameAllocated2, ref nextX2, midPoint2, i);
            }

            var titleFont = new Font(this.Font.FontFamily, 12, FontStyle.Regular);

            g.DrawLine(Pens.Black, 0, BOTTOM_OF_LOWER_GRAPH, this.ClientSize.Width, BOTTOM_OF_LOWER_GRAPH);
            g.DrawLine(Pens.Black, 0, BOTTOM_OF_LOWER_GRAPH - WINDOW_SIZE, this.ClientSize.Width, BOTTOM_OF_LOWER_GRAPH - WINDOW_SIZE);
            g.DrawLine(Pens.Black, 0, BOTTOM_OF_LOWER_GRAPH - WINDOW_SIZE - 25, this.ClientSize.Width, BOTTOM_OF_LOWER_GRAPH - WINDOW_SIZE - 25);
            g.DrawString(this.path1, titleFont, new SolidBrush(Color.Black), 5, BOTTOM_OF_LOWER_GRAPH - WINDOW_SIZE - 55);

            g.DrawLine(Pens.Black, 0, BOTTOM_OF_TOP_GRAPH, this.ClientSize.Width, BOTTOM_OF_TOP_GRAPH);
            g.DrawLine(Pens.Black, 0, BOTTOM_OF_TOP_GRAPH - WINDOW_SIZE, this.ClientSize.Width, BOTTOM_OF_TOP_GRAPH - WINDOW_SIZE);
            g.DrawLine(Pens.Black, 0, BOTTOM_OF_TOP_GRAPH - WINDOW_SIZE - 25, this.ClientSize.Width, BOTTOM_OF_TOP_GRAPH - WINDOW_SIZE - 25);
            g.DrawString(this.path2, titleFont, new SolidBrush(Color.Black), 5, BOTTOM_OF_TOP_GRAPH - WINDOW_SIZE - 55);

        }

        private void DrawFile1(Graphics g, ref int currentFrameSize, int windowSize, ref int frameAllocated, ref int nextX, int midPoint, int i)
        {
            if (i < this.data1.Extents.Length)
            {
                if (this.data1.Extents[i]) frameAllocated++;

                if (currentFrameSize == windowSize)
                {
                    g.DrawLine(Pens.Green, nextX, BOTTOM_OF_LOWER_GRAPH, nextX, BOTTOM_OF_LOWER_GRAPH - windowSize);
                    g.DrawLine(Pens.Red, nextX, midPoint + (frameAllocated / 2), nextX, midPoint - (frameAllocated / 2));

                    currentFrameSize = 0;
                    frameAllocated = 0;
                    nextX++;
                }
            }
            else
            {
                if (currentFrameSize == windowSize)
                {
                    currentFrameSize = 0;
                    frameAllocated = 0;
                    nextX++;
                }
            }

            if (i * 8 % GAM_SIZE <= 10)
            {
                g.DrawLine(Pens.Black, nextX - 1, BOTTOM_OF_LOWER_GRAPH, nextX - 1, BOTTOM_OF_LOWER_GRAPH - windowSize - 25);
            }

            if (i * 8 % GAM_SIZE == 0)
            {
                g.DrawString("Gam: " + ((i * 8) / GAM_SIZE), this.Font, new SolidBrush(Color.Black), nextX, BOTTOM_OF_LOWER_GRAPH - windowSize - 20);
            }
        }

        private void DrawFile2(Graphics g, ref int currentFrameSize, int windowSize, ref int frameAllocated, ref int nextX, int midPoint, int i)
        {
            if (i < this.data2.Extents.Length)
            {
                if (this.data2.Extents[i]) frameAllocated++;

                if (currentFrameSize == windowSize)
                {
                    g.DrawLine(Pens.Green, nextX, BOTTOM_OF_TOP_GRAPH, nextX, BOTTOM_OF_TOP_GRAPH - windowSize);
                    g.DrawLine(Pens.Red, nextX, midPoint + (frameAllocated / 2), nextX, midPoint - (frameAllocated / 2));

                    currentFrameSize = 0;
                    frameAllocated = 0;
                    nextX++;
                }
            }
            else
            {
                if (currentFrameSize == windowSize)
                {
                    currentFrameSize = 0;
                    frameAllocated = 0;
                    nextX++;
                }
            }

            if (i * 8 % GAM_SIZE <= 10)
            {
                g.DrawLine(Pens.Black, nextX - 1, BOTTOM_OF_TOP_GRAPH, nextX - 1, BOTTOM_OF_TOP_GRAPH - windowSize - 25);
            }

            if (i * 8 % GAM_SIZE == 0)
            {
                g.DrawString("Gam: " + ((i * 8) / GAM_SIZE), this.Font, new SolidBrush(Color.Black), nextX, BOTTOM_OF_TOP_GRAPH - windowSize - 20);
            }
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
