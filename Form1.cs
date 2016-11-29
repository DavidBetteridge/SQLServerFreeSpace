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
    public partial class Form1 : Form
    {
        private const int GAM_SIZE = 511232;
        private string currentRead = "";
        private Data data = new Data();

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.data.Extents = new bool[5000000];
            this.hScrollBar1.Minimum = 0;
            this.hScrollBar1.Maximum = this.data.Extents.Length;

            //LoadAndStoreData();
            LoadData();
        }

        private void LoadAndStoreData()
        {
            var sb = new SqlConnectionStringBuilder();
            sb.InitialCatalog = "S2C1_UKPortal";
            sb.DataSource = "HD08";
            sb.IntegratedSecurity = true;

            using (var cn = new SqlConnection(sb.ToString()))
            {
                cn.Open();
                cn.InfoMessage += Cn_InfoMessage;

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "DBCC TRACEON(3604)";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    ReadGAMPage(cn, cmd, 2);
                    for (int gamNumber = 1; gamNumber <= 75; gamNumber++)
                    {
                        ReadGAMPage(cn, cmd, gamNumber * GAM_SIZE);
                    }
                }
            }

            using (var file = File.Create(@"c:\temp\allocations.bin"))
            {
                Serializer.Serialize(file, this.data);
            }
        }

        private void LoadData()
        {
            using (var file = File.OpenRead(@"c:\temp\allocations.bin"))
            {
                this.data = Serializer.Deserialize<Data>(file);
            }
        }

        private void ReadGAMPage(SqlConnection cn, SqlCommand cmd, int pageNumber)
        {
            cmd.CommandText = "DBCC PAGE(0, 1," + pageNumber + ",3)";
            this.currentRead = "";
            cmd.ExecuteNonQuery();

            //Skip till we reach
            //GAM: Extent Alloc Status @0x00000000154DA0C2
            var allLines = this.currentRead
                               .Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                               .Where(l => l.StartsWith("("))
                               .ToList();

            foreach (var line in allLines)
            {
                //(1:0)        -(1:32072)    = ALLOCATED
                //(1:32080) -              = NOT ALLOCATED
                var bits = line.Replace(" ", "").Split('-');
                var bits2 = bits[1].Split('=');
                var from = bits[0];
                var to = bits2[0];

                var fromPage = from.Replace("(", "").Replace(")", "").Split(':')[1];
                var toPage = fromPage;
                if (!string.IsNullOrWhiteSpace(to))
                {
                    toPage = to.Replace("(", "").Replace(")", "").Split(':')[1];
                }

                for (int extentNumber = int.Parse(fromPage) / 8; extentNumber <= (int.Parse(toPage) / 8); extentNumber++)
                {
                    this.data.Extents[extentNumber] = (bits2[1] == "ALLOCATED");
                }
            }

        }

        private void Cn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            foreach (SqlError info in e.Errors)
            {
                currentRead += info.Message;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var allocatedBrush = new SolidBrush(Color.Red);
            var unallocatedBrush = new SolidBrush(Color.Green);

            var currentFrameSize = 0;
            var windowSize = 100;
            var frameAllocated = 0;
            var nextX = 0;
            var midPoint = 500 - (windowSize / 2);
            for (int i = this.hScrollBar1.Value; i < this.hScrollBar1.Value + (1000 * windowSize); i++)
            {
                currentFrameSize++;
                if (this.data.Extents[i]) frameAllocated++;

                if (currentFrameSize == windowSize)
                {
                    g.DrawLine(Pens.Green, nextX, 500, nextX, 500 - windowSize);
                    g.DrawLine(Pens.Red, nextX, midPoint + (frameAllocated / 2), nextX, midPoint - (frameAllocated / 2));

                    currentFrameSize = 0;
                    frameAllocated = 0;
                    nextX++;
                }

                if (i * 8 % GAM_SIZE <= 10)
                {
                    g.DrawLine(Pens.Black, nextX - 1, 500, nextX - 1, 500 - windowSize - 25);
                }

                if (i * 8 % GAM_SIZE == 0)
                {
                    g.DrawString("Gam: " + ((i * 8) / GAM_SIZE), this.Font, new SolidBrush(Color.Black), nextX, 500 - windowSize - 25);
                }
            }


        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
