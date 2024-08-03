using Chola.Chola_DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chola
{
    public partial class frmPacketQue : Form
    {
        public string ConditionStatus = "";
        public string ScreenDis = "";
        public frmPacketQue(string ScreenDisplay)
        {
            InitializeComponent();
            ScreenDis = ScreenDisplay;
        }

        private void frmPacketQue_Load(object sender, EventArgs e)
        {
            try
            {
                cmb_Pck_Mode.Items.Clear();
                cmb_Pck_Mode.Items.Add("PDC");
                cmb_Pck_Mode.Items.Add("SPDC");
                cmb_Pck_Mode.Items.Add("Mandate");
                cmb_Pck_Mode.Items.Add("Others");

                string InwardFromdate = "";
                string InwardTodate = "";

                ConditionStatus = "";

                if (Inward_Fromdate.Checked == true)
                {
                    InwardFromdate = Inward_Fromdate.Value.ToString("yyyy-MM-dd");
                }
                if (Inward_Todate.Checked == true)
                {
                    InwardTodate = Inward_Todate.Value.ToString("yyyy-MM-dd");
                }
                if (InwardFromdate != "")
                {
                    ConditionStatus = " and a.packet_receiveddate >=" + "'" + InwardFromdate + "'";

                }

                if (InwardTodate != "")
                {
                    if (ConditionStatus != "")
                    {
                        ConditionStatus += " and a.packet_receiveddate <=" + "'" + InwardTodate + "'";
                    }
                    else
                    {
                        ConditionStatus = " and a.packet_receiveddate <=" + "'" + InwardTodate + "'";
                    }
                }

                if (ConditionStatus == "")
                {
                    ConditionStatus = "All";
                }

                LoadPacketdetails(ConditionStatus);

                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPacketdetails(string ConditionStatus)
        {
            try
            {
                gvscanlist.Columns.Clear();
                DataTable dtscanning = new DataTable();
                gvscanlist.DataSource = null;
                PacketBusiness ObjInward = new PacketBusiness();
                dtscanning = ObjInward.GetPacketDetails(ConditionStatus);
                gvscanlist.DataSource = dtscanning;

                if (gvscanlist.Columns["Packet Gid"] != null)
                {
                    gvscanlist.Columns["Packet Gnsa RefNo"].Width = 150;
                    gvscanlist.Columns["Packet Gid"].Visible = false;
                }
                if (dtscanning.Rows.Count > 0)
                {
                    if (ScreenDis == "PacketQueue")
                    {

                        DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                        col.UseColumnTextForButtonValue = true;
                        col.HeaderText = "Scan";
                        col.Text = "Scan";
                        col.Name = "Scan";
                        gvscanlist.Columns.Add(col);
                    }
                    else if (ScreenDis == "ScanQueue")
                    {
                        DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                        col.UseColumnTextForButtonValue = true;
                        col.HeaderText = "Scan Entry";
                        col.Text = "Scan Entry";
                        col.Name = "Scan Entry";
                        gvscanlist.Columns.Add(col);
                    }

                    if (GnsaRefNo_Txt.Text != "")
                    {
                        int Packetgid = Convert.ToInt32(gvscanlist.Rows[0].Cells["Packet Gid"].Value);
                        string PacketGnsaNo = gvscanlist.Rows[0].Cells["Packet Gnsa RefNo"].Value.ToString();
                        string AgreementNo = gvscanlist.Rows[0].Cells["Agreement No"].Value.ToString();
                        string PacketMode = gvscanlist.Rows[0].Cells["Packet Mode"].Value.ToString();
                        string PacketRecvDate = gvscanlist.Rows[0].Cells["Packet Received Date"].Value.ToString();
                        string StatusDesc = gvscanlist.Rows[0].Cells["Status Desc"].Value.ToString();
                        string Remarks = gvscanlist.Rows[0].Cells["Packet Remarks"].Value.ToString();
                        GnsaRefNo_Txt.Text = "";
                        frmScan objcheck = new frmScan(Packetgid, PacketRecvDate, PacketGnsaNo, PacketMode, AgreementNo, StatusDesc, Remarks);
                        objcheck.FormClosed += new FormClosedEventHandler(this.sc_FormClosed);
                        objcheck.StartPosition = FormStartPosition.CenterParent;
                        objcheck.ShowDialog();
                        GnsaRefNo_Txt.Focus();

                    }


                }
                else
                {
                    MessageBox.Show("No Packet List Available for Scanning Validation", "Chola", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                gvscanlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnref_Click(object sender, EventArgs e)
        {
            try
            {
                string InwardFromdate = "";
                string InwardTodate = "";
                ConditionStatus = "";

                if (Inward_Fromdate.Checked == true)
                {
                    InwardFromdate = Inward_Fromdate.Value.ToString("yyyy-MM-dd");
                }
                if (Inward_Todate.Checked == true)
                {
                    InwardTodate = Inward_Todate.Value.ToString("yyyy-MM-dd");
                }

                string PacketMode = cmb_Pck_Mode.Text;
                string GnsaRefNo = GnsaRefNo_Txt.Text;

                if (!(cmb_Pck_Mode.SelectedIndex > 0)) PacketMode = "";

                if (InwardFromdate != "")
                {
                    ConditionStatus = " and a.packet_receiveddate >=" + "'" + InwardFromdate + "'";

                }

                if (InwardTodate != "")
                {
                    if (ConditionStatus != "")
                    {
                        ConditionStatus += "and a.packet_receiveddate<=" + "'" + InwardTodate + "'";
                    }
                    else
                    {
                        ConditionStatus = "and a.packet_receiveddate<=" + "'" + InwardTodate + "'";
                    }
                }
                if (PacketMode != "")
                {
                    if (ConditionStatus != "")
                    {
                        ConditionStatus += "and a.packet_mode=" + "'" + PacketMode + "'";
                    }
                    else
                    {
                        ConditionStatus = "and a.packet_mode=" + "'" + PacketMode + "'";
                    }
                }
                if (GnsaRefNo != "")
                {
                    if (ConditionStatus != "")
                    {
                        ConditionStatus += "and a.packet_gnsarefno=" + "'" + GnsaRefNo + "'";
                    }
                    else
                    {
                        ConditionStatus = "and a.packet_gnsarefno=" + "'" + GnsaRefNo + "'";
                    }
                }
                if (ConditionStatus == "")
                {
                    ConditionStatus = "All";
                }

                LoadPacketdetails(ConditionStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            GnsaRefNo_Txt.Text = "";
            cmb_Pck_Mode.Text = "";

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void sc_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPacketQue_Load(sender, e);
        }

        private void gvscanlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                int col = gvscanlist.CurrentCell.ColumnIndex;
                int row = gvscanlist.CurrentCell.RowIndex;
                int Packetgid = Convert.ToInt32(gvscanlist.Rows[row].Cells["Packet Gid"].Value);
                string PacketGnsaNo = gvscanlist.Rows[row].Cells["Packet Gnsa RefNo"].Value.ToString();
                string AgreementNo = gvscanlist.Rows[row].Cells["Agreement No"].Value.ToString();
                string PacketMode = gvscanlist.Rows[row].Cells["Packet Mode"].Value.ToString();
                string PacketRecvDate = gvscanlist.Rows[row].Cells["Packet Received Date"].Value.ToString();
                string StatusDesc = gvscanlist.Rows[row].Cells["Status Desc"].Value.ToString();
                string Remarks = gvscanlist.Rows[row].Cells["Packet Remarks"].Value.ToString();
                if (gvscanlist.Columns[e.ColumnIndex].Name == "Scan")
                {
                    frmScan objcheck = new frmScan(Packetgid, PacketRecvDate, PacketGnsaNo, PacketMode, AgreementNo, StatusDesc, Remarks);
                    objcheck.FormClosed += new FormClosedEventHandler(this.sc_FormClosed);
                    objcheck.StartPosition = FormStartPosition.CenterParent;
                    objcheck.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
