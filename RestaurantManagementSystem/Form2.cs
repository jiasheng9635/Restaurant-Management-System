using System;
using System.Collections;
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
    public partial class Form2 : Form
    {
        public int totalqueue =0;
        public Queue QItemName = new Queue();
        public Queue QItemType = new Queue();
        public Queue QTableNo = new Queue();
        public Queue QQuantity = new Queue();

        public Form2()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            initKitchenLV();
            hardupdateKitchenVL();
        }

        private void hardupdateKitchenVL()
        {
            Object[] tempItemName = new Object[totalqueue];
            QItemName.CopyTo(tempItemName, 0);
            Object[] tempItemType = new Object[totalqueue];
            QItemType.CopyTo(tempItemType, 0);
            Object[] tempTableNo = new Object[totalqueue];
            QTableNo.CopyTo(tempTableNo, 0);
            Object[] tempQuantity = new Object[totalqueue];
            QQuantity.CopyTo(tempQuantity, 0);

            for (int i=0; i<totalqueue; i++)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { tempItemName[i].ToString(), tempItemType[i].ToString(), tempQuantity[i].ToString(), tempTableNo[i].ToString() });
                KitchenLV.Items.AddRange(new ListViewItem[] { listViewItem });
            }
        }

        private void initKitchenLV()
        {
            KitchenLV.Clear(); // reset list view

            KitchenLV.Columns.Add("Name", 311, HorizontalAlignment.Left);
            KitchenLV.Columns.Add("Item Type", 100, HorizontalAlignment.Left);
            KitchenLV.Columns.Add("Quantity", 80, HorizontalAlignment.Left);
            KitchenLV.Columns.Add("Table No", 80, HorizontalAlignment.Left);
            KitchenLV.View = View.Details; // Manual sort
        }

        public void updateKitchenVL(string AitemName, string AitemType, int Aquantity, int AtableNo)
        {
            ListViewItem listViewItem = new ListViewItem(new string[] { AitemName, AitemType, Aquantity.ToString(), AtableNo.ToString() });
            KitchenLV.Items.AddRange(new ListViewItem[] { listViewItem });
            QTableNo.Enqueue(AtableNo);
            QItemName.Enqueue(AitemName);
            QQuantity.Enqueue(Aquantity);
            QItemType.Enqueue(AitemType);
            totalqueue++;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (KitchenLV.Items.Count > 0)
            {
                KitchenLV.Items[0].Remove();
                QTableNo.Dequeue();
                QItemName.Dequeue();
                QQuantity.Dequeue();
                QItemType.Dequeue();
                totalqueue--;
            }
            else
                MessageBox.Show("No Item is in the list", "Warning");
        }

        private void VoidButton_Click(object sender, EventArgs e)
        {
            if(KitchenLV.Items.Count>0)
            {
                Form1.DeleteOneOrder(Convert.ToInt32(QTableNo.Peek()), QItemType.Peek().ToString(), QItemName.Peek().ToString(), Convert.ToInt32(QQuantity.Peek()), true);
                Form1.notifyCounter(QQuantity.Peek(), QItemName.Peek(), QTableNo.Peek());
                KitchenLV.Items[0].Remove();
                QTableNo.Dequeue();
                QItemName.Dequeue();
                QQuantity.Dequeue();
                QItemType.Dequeue();
                totalqueue--;
            }
            else
                MessageBox.Show("No Item is in the list", "Warning");
        }

        public void deleteinqueue(string searchitemName, string searchitemType, int searchtableNo,  int searchquantity)
        {
            Object[] tempItemName2 = new Object[totalqueue + 1];
            QItemName.CopyTo(tempItemName2, 0);
            Object[] tempItemType2 = new Object[totalqueue + 1];
            QItemType.CopyTo(tempItemType2, 0);
            Object[] tempTableNo2 = new Object[totalqueue + 1];
            QTableNo.CopyTo(tempTableNo2, 0);
            Object[] tempQuantity2 = new Object[totalqueue + 1];
            QQuantity.CopyTo(tempQuantity2, 0);
            
            // error proof
            int totalcounter = 0;
            for (int i = 0; i < totalqueue + 1; i++)
                if (Convert.ToInt32(tempTableNo2[i]) == searchtableNo)
                    if (tempItemName2[i].ToString() == searchitemName)
                        totalcounter = totalcounter + Convert.ToInt32(tempQuantity2[i]); // calculate 

            for (int i = 0; i < totalqueue + 1; i++) // delete order
            {
                if (Convert.ToInt32(tempTableNo2[i]) == searchtableNo)
                {
                    if (tempItemName2[i].ToString() == searchitemName)
                    {
                        tempItemName2[i] = null;
                        tempItemType2[i] = null;
                        tempTableNo2[i] = null;
                        tempQuantity2[i] = null;
                    }
                }
            }

            if (totalcounter > searchquantity) // add to most back if there is a difference
            {
                // create new order to the list
                tempItemName2[totalqueue] = searchitemName;
                tempItemType2[totalqueue] = searchitemType;
                tempTableNo2[totalqueue] = searchtableNo;
                tempQuantity2[totalqueue] = totalcounter - searchquantity;
            }
            else if (totalcounter == searchquantity)// delete all if equal or over limit
            {
                totalqueue--;
            }
            else
            {
                int itempreparedcount = searchquantity - totalcounter;
                MessageBox.Show(String.Format("{0} of {1} is already prepared", itempreparedcount, searchitemName), "Warning To Counter");
            }

            // reset queue
            QItemName.Clear();
            QItemType.Clear();
            QTableNo.Clear();
            QQuantity.Clear();

            // update new queue
            for (int i = 0; i < tempItemName2.Count(); i++)
            {
                if (tempItemName2[i] != null)
                {
                    QItemName.Enqueue(tempItemName2[i]);
                    QItemType.Enqueue(tempItemType2[i]);
                    QTableNo.Enqueue(tempTableNo2[i]);
                    QQuantity.Enqueue(tempQuantity2[i]);
                }
            }

            // update gui
            initKitchenLV();
            for (int i = 0; i < tempItemName2.Count(); i++)
            {
                if (tempItemName2[i] != null)
                {
                    ListViewItem listViewItem = new ListViewItem(new string[] { tempItemName2[i].ToString(), tempItemType2[i].ToString(), tempQuantity2[i].ToString(), tempTableNo2[i].ToString() });
                    KitchenLV.Items.AddRange(new ListViewItem[] { listViewItem });
                }
            }
        }

        public void deleteallinqueue(int searchtable)
        {
            Object[] tempItemName3 = new Object[totalqueue];
            QItemName.CopyTo(tempItemName3, 0);
            Object[] tempItemType3 = new Object[totalqueue];
            QItemType.CopyTo(tempItemType3, 0);
            Object[] tempTableNo3 = new Object[totalqueue];
            QTableNo.CopyTo(tempTableNo3, 0);
            Object[] tempQuantity3 = new Object[totalqueue];
            QQuantity.CopyTo(tempQuantity3, 0);

            int totaldeleted = 0;
            for (int i = 0; i < totalqueue; i++)
            {
                if (Convert.ToInt32(tempTableNo3[i]) == searchtable)
                {
                    totaldeleted++; // calculate deleted

                    tempItemName3[i] = null;
                    tempItemType3[i] = null;
                    tempTableNo3[i] = null;
                    tempQuantity3[i] = null;
                }
            }

            // reset queue
            QItemName.Clear();
            QItemType.Clear();
            QTableNo.Clear();
            QQuantity.Clear();

            // enqueue new list
            for (int i = 0; i < totalqueue; i++)
            {
                if (tempItemName3[i] != null)
                {
                    QItemName.Enqueue(tempItemName3[i]);
                    QItemType.Enqueue(tempItemType3[i]);
                    QTableNo.Enqueue(tempTableNo3[i]);
                    QQuantity.Enqueue(tempQuantity3[i]);
                }
            }

            // update gui
            initKitchenLV();
            for (int i = 0; i < totalqueue; i++)
            {
                if (tempItemName3[i] != null)
                {
                    ListViewItem listViewItem = new ListViewItem(new string[] { tempItemName3[i].ToString(), tempItemType3[i].ToString(), tempQuantity3[i].ToString(), tempTableNo3[i].ToString() });
                    KitchenLV.Items.AddRange(new ListViewItem[] { listViewItem });
                }
            }

            totalqueue -= totaldeleted;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
