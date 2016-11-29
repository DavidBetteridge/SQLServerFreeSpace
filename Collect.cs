using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using ProtoBuf;
using System.Threading.Tasks;

namespace DisplayFreeSpace
{
    public partial class Collect : UserControl
    {
        private const int GAM_SIZE = 511232;
        private string currentRead = "";
        private Data data = new Data();

        public Collect()
        {
            InitializeComponent();
        }

        private void Collect_Load(object sender, EventArgs e)
        {
            this.txtDatabaseName.Text = "Bauer";
            this.txtDatabaseServerName.Text = ".";
            this.txtStorageFile.Text = @"c:\temp\aaa.bin";
            this.lblProgress.Visible = false;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(this.txtDatabaseName.Text))
                {
                    MessageBox.Show("Please enter the database name", "Collect Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtDatabaseName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(this.txtDatabaseServerName.Text))
                {
                    MessageBox.Show("Please enter the database server name", "Collect Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtDatabaseServerName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(this.txtStorageFile.Text))
                {
                    MessageBox.Show("Please enter the location for the storage file", "Collect Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtStorageFile.Focus();
                    return;
                }

                lblProgress.Visible = true;

                var sb = new SqlConnectionStringBuilder();
                sb.InitialCatalog = this.txtDatabaseName.Text;
                sb.DataSource = this.txtDatabaseServerName.Text; ;
                sb.IntegratedSecurity = true;
                lblProgress.Text = "Connecting to the database";

                using (var cn = new SqlConnection(sb.ToString()))
                {
                    await cn.OpenAsync();
                    cn.InfoMessage += Cn_InfoMessage;

                    using (var cmd = new SqlCommand())
                    {
                        this.lblProgress.Text = $"Setting trace flag.";
                        cmd.Connection = cn;
                        cmd.CommandText = "DBCC TRACEON(3604)";
                        cmd.CommandType = CommandType.Text;
                        await cmd.ExecuteNonQueryAsync();

                        this.lblProgress.Text = $"Calculating number of GAM intervals";
                        cmd.CommandText = "SELECT total_page_count FROM sys.dm_db_file_space_usage";
                        var totalIntervalCount = (long)(await cmd.ExecuteScalarAsync());
                        totalIntervalCount = totalIntervalCount / 511232;

                        this.data.Extents = new bool[(totalIntervalCount+1) * 511232 / 8];
                        this.lblProgress.Text = $"Getting data for GAM interval 0 of {totalIntervalCount}.";
                        await ReadGAMPage(cn, cmd, 2);

                        for (int gamNumber = 1; gamNumber <= totalIntervalCount; gamNumber++)
                        {
                            this.lblProgress.Text = $"Getting data for GAM interval {gamNumber} of {totalIntervalCount}.";
                            await ReadGAMPage(cn, cmd, gamNumber * GAM_SIZE);
                        }
                    }
                }

                lblProgress.Text = "Creating storage file";
                using (var file = File.Create(this.txtStorageFile.Text))
                {
                    Serializer.Serialize(file, this.data);
                }

                lblProgress.Visible = false;
                MessageBox.Show("Complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ReadGAMPage(SqlConnection cn, SqlCommand cmd, int pageNumber)
        {
            cmd.CommandText = "DBCC PAGE(0, 1," + pageNumber + ",3)";
            this.currentRead = "";
            await cmd.ExecuteNonQueryAsync();

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

    }
}
