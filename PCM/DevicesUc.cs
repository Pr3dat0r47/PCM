using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Data.SqlClient;

namespace PCM
{
    public partial class DevicesUc : UserControl
    {
        public string DeviceName;
        public int DeviceID;
        public int Price;
        public int TotalTime;
        public bool Single = true , SentToReciept = false;
        public DateTime STime,ETime;
        Stopwatch sw = new Stopwatch();
        public int status = 0;

        public DevicesUc(string DeviceName)
        {
            InitializeComponent();
            initial(DeviceName);
        }
        public void initial(string DeviceName)
        {
            Label label1 = new Label();
            this.DeviceName = DeviceName;
            label1.Text = DeviceName;
            label1.AutoSize = true;
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.SystemColors.Control;
            label1.Location = new System.Drawing.Point(this.Width / 4, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(126, 46);
            label1.TabIndex = 3;
            this.Controls.Add(label1);
            label1.Margin = new System.Windows.Forms.Padding(0, 0, this.Width / 4, 0);
        }
        public void StartTime()
        {
            status++;
            bunifuFlatButton1.Text = "ايقاف الوقت";
            bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(27)))), ((int)(((byte)(92)))));
            STime = DateTime.Now;
            string Query = "UPDATE item SET start_time = '" + STime.ToString() + "' WHERE item_name ='" + this.DeviceName + "'";
            Form1.Connection.Write(Query);
            sw.Start();
        }
        public void EndTime()
        {
            sw.Stop();
            ChooseReciept Select = new ChooseReciept(this);
            Select.Show();
            bunifuFlatButton1.Text = "اعادة الضبط";
            bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(203)))), ((int)(((byte)(0)))));
            bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(203)))), ((int)(((byte)(0)))));
            bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(203)))), ((int)(((byte)(0)))));
            bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(0)))));
            string Query = "select start_time from item where item_name = '" + this.Name + "'";
            SqlDataReader dr = Form1.Connection.Read(Query);
            Query = "UPDATE item SET start_time = '0' WHERE item_name ='" + this.DeviceName + "'";
            Form1.Connection.Write(Query);
            while (dr.Read())
            {
                STime = Convert.ToDateTime(dr["start_time"]);
            }
            ETime = DateTime.Now;
            TotalTime = Convert.ToInt32((ETime - STime).TotalMinutes);
            
            status++;
        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (status == 0)
            {
                this.StartTime();
            }
            else if (status == 1)
            {
                this.EndTime();
            }
            else
            {
                this.Reset_Time();
            }
        }
        void Reset_Time()
        {
            status = 0;
            bunifuFlatButton1.Text = "بدء الوقت";
            label2.Text = "00:00:00";
            bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            sw.Reset();
        }

        private void SingleRadio_Click(object sender, EventArgs e)
        {
            if (status != 0 && !Single)
            {
                //SShown = true;
                MessageBox.Show("يجب انهاء و اعادة ضبط الوقت اولا", "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                MultiRadio.Checked = true;
            }
            else
            {
                Single = true;
            }
        }

        private void MultiRadio_Click(object sender, EventArgs e)
        {
            if (status != 0 && Single)
            {
                //MShown = true;
                MessageBox.Show("يجب انهاء و اعادة ضبط الوقت اولا", "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                SingleRadio.Checked = true;
            }
            else
            {
                Single = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            long h = sw.Elapsed.Hours;
            long m = sw.Elapsed.Minutes;
            long s = sw.Elapsed.Seconds;
            long t = sw.Elapsed.Ticks;

            string strH = (h < 10) ? "0" + h : h + "";
            string strM = (m < 10) ? "0" + m : m + "";
            string strS = (s < 10) ? "0" + s : s + "";
            string AllTime = strH + ":" + strM + ":" + strS;
            label2.Text = AllTime;
        }
    }
}
