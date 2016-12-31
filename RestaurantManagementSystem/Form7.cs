using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagementSystem
{
    public partial class Form7 : Form
    {
        string due, cardnum;
        int table;
        int[] icard = new int[4];
        string[] card = new string[4];
        Random rand = new Random();

        public Form7()
        {
            InitializeComponent();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (CardStatus.Text == "Approved")
            {
                this.Hide();
                Form1.DeleteAllOrder(table, false);
            }
            else
            {
                this.Hide();
                Form1.promptPayFail();
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.ActiveControl = DoneButton;
            ScanningLabel.Hide();
        }

        public void updateDue(string totalPrice, int tablenum)
        {
            due = totalPrice;
            totalDue.Text = due;

            table = tablenum;
            tableNo.Text = table.ToString();
        }

        private void ReadCard_Click(object sender, EventArgs e)
        {
            ReadCard.Enabled = false;
            DoneButton.Enabled = false;
            ScanningLabel.Show();
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                // Wait 100 milliseconds.
                Thread.Sleep(25);
                backgroundWorker1.ReportProgress(i);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            loadingBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // TODO: do something with final calculation.
            ScanningLabel.Hide();
            loadingBar.Value = 0;
            for(int i=0; i<4; i++)
                icard[i] = rand.Next(1000, 9999);
            cardnum = icard[0].ToString() + " " + icard[1].ToString() + " " + icard[2].ToString() + " " + icard[3].ToString();
            CardNo.Text = cardnum;
            BankName.Text = "COMB Berhad";
            int randStatus = icard[0] % 2;
            if (randStatus == 0)
                CardStatus.Text = "Approved";
            else if (randStatus == 1)
                CardStatus.Text = "Not Approved";
            ReadCard.Enabled = true;
            DoneButton.Enabled = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
