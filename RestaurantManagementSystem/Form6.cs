using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagementSystem
{
    public partial class Form6 : Form
    {
        public string due, paid, change;
        public int table;

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.ActiveControl = PaidAmount;
        }

        public void updateDue(string totalPrice, int tablenum)
        {
            due = totalPrice;
            totalDue.Text = due;

            table = tablenum;
            tableNo.Text = table.ToString();

            PaidAmount.Text = null;
            Changes.Text = null;
        }

        public void updateChanges()
        {
            double d_change = Convert.ToDouble(paid) - Convert.ToDouble(due);
            Changes.Text = d_change.ToString("F");
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hardware Device is Missing", "Warning");
        }

        private void OpenDrawer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hardware Device is Missing", "Warning");
        }

        private void num1_Click(object sender, EventArgs e)
        {
            PaidAmount.Text = PaidAmount.Text + "1";
        }

        private void num2_Click(object sender, EventArgs e)
        {
            PaidAmount.Text = PaidAmount.Text + "2";
        }

        private void num3_Click(object sender, EventArgs e)
        {
            PaidAmount.Text = PaidAmount.Text + "3";
        }

        private void num4_Click(object sender, EventArgs e)
        {
            PaidAmount.Text = PaidAmount.Text + "4";
        }

        private void num5_Click(object sender, EventArgs e)
        {
            PaidAmount.Text = PaidAmount.Text + "5";
        }

        private void num6_Click(object sender, EventArgs e)
        {
            PaidAmount.Text = PaidAmount.Text + "6";
        }

        private void num7_Click(object sender, EventArgs e)
        {
            PaidAmount.Text = PaidAmount.Text + "7" ;
        }

        private void num8_Click(object sender, EventArgs e)
        {
            PaidAmount.Text = PaidAmount.Text + "8";
        }

        private void num9_Click(object sender, EventArgs e)
        {
            PaidAmount.Text = PaidAmount.Text + "9";
        }

        private void num0_Click(object sender, EventArgs e)
        {
            PaidAmount.Text = PaidAmount.Text + "0";
        }

        private void clear_Click(object sender, EventArgs e)
        {
            PaidAmount.Text = null;
            Changes.Text = null;
        }

        private void dot_Click(object sender, EventArgs e)
        {
            PaidAmount.Text = PaidAmount.Text + ".";
        }

        private void ok_Click(object sender, EventArgs e)
        {
            updateChanges();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (Changes.Text != null && Changes.Text != "")
            {
                if ( Convert.ToDouble(Changes.Text) >= 0 )
                {
                    this.Hide();
                    Form1.DeleteAllOrder(table, false);
                }
                else
                    MessageBox.Show("Paid Amount is insufficient", "Warning");
            }
            else
            {
                this.Hide();
                Form1.promptPayFail();
            }
        }

        private void PaidAmount_TextChanged(object sender, EventArgs e)
        {
            PaidAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            if (PaidAmount.Text != null || PaidAmount.Text != "")
            {
                try
                {
                    paid = PaidAmount.Text;
                }
                catch (FormatException) // popup error
                {
                    PaidAmount.Text = null;
                    Changes.Text = null;
                }
            }
        }

        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                updateChanges();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
