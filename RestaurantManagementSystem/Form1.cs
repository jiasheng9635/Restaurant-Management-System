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
    public partial class Form1 : Form
    {
        public static List<Panel> listPanel = new List<Panel>();
        public static List<Item> itemList = new List<Item>();
        public static List<Order> orderList = new List<Order>();
        public static List<Order> report = new List<Order>();
        public static Form2 chef = new Form2();
        public static Form4 newItem = new Form4();
        public static Form5 cancelItem = new Form5();
        public static Form6 cash = new Form6();
        public static Form7 card = new Form7();
        public static int selectedTableNo = 0;

        public static Database1DataSetTableAdapters.ItemTableAdapter itemTableAdapter = new Database1DataSetTableAdapters.ItemTableAdapter();
        public static Database1DataSetTableAdapters.OrderDetailTableAdapter orderDetailTableAdapter = new Database1DataSetTableAdapters.OrderDetailTableAdapter();
        public static Database1DataSetTableAdapters.OrderTableAdapter orderTableAdapter = new Database1DataSetTableAdapters.OrderTableAdapter();

        string loginID, loginPass, itemName, itemType, itemPrice_Str;
        double itemPrice=-1;
        private int sortColumn = -1;
        int backvalue = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chef.Hide();
            cash.Hide();
            card.Hide();
            newItem.Hide();
            cancelItem.Hide();

            this.ActiveControl = loginIDTB; // focus username textbox
            listPanel.Add(panel1);
            listPanel.Add(panel3);
            listPanel.Add(panel4);
            listPanel.Add(panel5);

            initListView();
            initTableLV();
            initReportLV();

            itemNameDelete.DisplayMember = "Text";
            itemNameDelete.IntegralHeight = false;
            itemNameDelete.MaxDropDownItems = 5;

            DateCounter.Text = DateTime.Now.ToString("d/M/yyyy");
            DateReport.Text = DateTime.Now.ToString("d/M/yyyy");

            ModeCB.DisplayMember = "Text";
            ModeCB.IntegralHeight = false;
            ModeCB.MaxDropDownItems = 5;
            ModeCB.Items.Add(new { Text = "Daily" });
            ModeCB.Items.Add(new { Text = "Monthly" });
            ModeCB.Items.Add(new { Text = "Yearly" });
            ModeCB.Items.Add(new { Text = "Quantity" });
            ModeCB.TabIndex = 0;
            
            itemTypeCB.DisplayMember = "Text";
            itemTypeCB.IntegralHeight = false;
            itemTypeCB.Items.Add(new { Text = "Food" });
            itemTypeCB.Items.Add(new { Text = "Beverage" });

            for (int i = 0; i < System.Convert.ToInt32(itemTableAdapter.GetCount()) + 1; i++)
            {
                if (itemTableAdapter.GetName(i) != null)
                    itemList.Add(new Item() { item_Name = itemTableAdapter.GetName(i), item_Type = itemTableAdapter.GetType(i), item_Price = System.Convert.ToDouble(itemTableAdapter.GetPrice(i)) });
            }

            for (int i = 0; i < itemTableAdapter.GetCount() + 1; i++)
            {
                if (itemTableAdapter.GetName(i) != null)
                    itemNameDelete.Items.Add(new { Text = itemTableAdapter.GetName(i) });
                
            }

            for(int i = 0; i < System.Convert.ToInt32(itemTableAdapter.GetCount()) + 1; i++)
            {
                if(itemTableAdapter.GetName(i) != null)
                {
                    double tempoPrice = System.Convert.ToDouble(itemTableAdapter.GetPrice(i));
                    ListViewItem hardcodedItem = new ListViewItem(new string[] { itemTableAdapter.GetName(i), itemTableAdapter.GetType(i), tempoPrice.ToString("F") });
                    ItemLV.Items.AddRange(new ListViewItem[] { hardcodedItem });
                }
            }

            for (int i = 0; i < System.Convert.ToInt32(orderDetailTableAdapter.GetCount()) + 1; i++)
            {
                DateTime temp = new DateTime(0001, 1, 1);
                if(System.Convert.ToDateTime(orderDetailTableAdapter.GetDate(i)) != temp)
                    report.Add(new Order() { tableNo = System.Convert.ToInt32(orderDetailTableAdapter.GetTableNo(i)), itemType = orderDetailTableAdapter.GetType(i), itemName = orderDetailTableAdapter.GetName(i), quantity = System.Convert.ToInt32(orderDetailTableAdapter.GetQuantity(i)), price = System.Decimal.ToDouble(System.Convert.ToInt32(orderDetailTableAdapter.GetPrice(i))), date = System.Convert.ToDateTime(orderDetailTableAdapter.GetDate(i)) });
            }
        }

        private void initListView()
        {
            // Item List View in Modify Item
            ItemLV.Columns.Add("Item Name", 269, HorizontalAlignment.Left);
            ItemLV.Columns.Add("Item Type", 100, HorizontalAlignment.Left);
            ItemLV.Columns.Add("Item Price", 100, HorizontalAlignment.Right);
            ItemLV.View = View.Details; // Manual sort
        }

        private void initTableLV()
        {
            // Table List View in Counter Menu
            TableLV.Columns.Add("Name", 150, HorizontalAlignment.Left);
            TableLV.Columns.Add("Qty", 30, HorizontalAlignment.Right);
            TableLV.Columns.Add("Price", 63, HorizontalAlignment.Right);
            TableLV.View = View.Details; // Manual sort
        }

        private void initReportLV()
        {
            // Table List View in Counter Menu
            ReportLV.Columns.Add("Date", 150, HorizontalAlignment.Left);
            ReportLV.Columns.Add("Total Item(s) Sold", 200, HorizontalAlignment.Right);
            ReportLV.Columns.Add("Income", 200, HorizontalAlignment.Right);
            ReportLV.View = View.Details; // Manual sort
        }

        private void ReportLV_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                ReportLV.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (ReportLV.Sorting == SortOrder.Ascending)
                    ReportLV.Sorting = SortOrder.Descending;
                else
                    ReportLV.Sorting = SortOrder.Ascending;
            }
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            ReportLV.ListViewItemSorter = new ListViewItemComparer(e.Column, ReportLV.Sorting);

            // Call the sort method to manually sort.
            ReportLV.Sort();
        }

        public static void AddToOrderList(int AtableNo, string AitemType, string AitemName, int Aquantity, double AitemPrice)
        {
            int sentQuantity = Aquantity;

            // error proof
            var item = orderList.FirstOrDefault(x => x.tableNo == AtableNo && x.itemType == AitemType && x.itemName == AitemName);
            if (item != null)
            {
                Aquantity = Aquantity + item.quantity;
                orderList.Remove(item);
            }

            Order order = new Order();
            order.tableNo = AtableNo;
            order.itemType = AitemType;
            order.itemName = AitemName;
            order.quantity = Aquantity;
            order.price = AitemPrice* Aquantity;
            order.date = DateTime.Now;
            orderList.Add(order);

            chef.updateKitchenVL(AitemName, AitemType, sentQuantity, AtableNo);
        }

        public static void DeleteOneOrder(int DtableNo, string DitemType, string DitemName, int Dquantity, bool kitchen)
        {
            Order order = new Order();
            order.tableNo = DtableNo;
            order.itemType = DitemType;
            order.itemName = DitemName;
            order.quantity = Dquantity;
            order.date = DateTime.Now;

            var item = orderList.FirstOrDefault(x => x.tableNo == DtableNo && x.itemType == DitemType && x.itemName == DitemName);
            if (item != null)
            {
                if (item.quantity > Dquantity)
                {
                    order.quantity = item.quantity - Dquantity;
                    var searchPrice = itemList.FirstOrDefault(x => x.item_Name == DitemName);
                    order.price = ((item.quantity - Dquantity) * searchPrice.item_Price);
                    orderList.Remove(item);
                    orderList.Add(order);

                    if(!kitchen)
                    {
                        chef.deleteinqueue(DitemName, DitemType, DtableNo, Dquantity);
                        MessageBox.Show(String.Format("{0} of {1} from table {2} has been cancelled", Dquantity, DitemName, DtableNo), "Warning To Chef");
                    }
                }
                else if (item.quantity < Dquantity) //error proof
                {
                    MessageBox.Show("Quantity is overlimit", "Warning");
                }
                else
                {
                    orderList.Remove(item);
                    if (!kitchen)
                    {
                        chef.deleteinqueue(DitemName, DitemType, DtableNo, Dquantity);
                        MessageBox.Show(String.Format("{0} of {1} from table {2} has been cancelled", Dquantity, DitemName, DtableNo), "Warning To Chef");
                    }
                }
            }
            else
                MessageBox.Show("Item is not in the list", "Warning");
        }

        public static void DeleteAllOrder(int DAtableNo, bool Cancel)
        {
            bool success = false;

            var deleteorder = orderList.FirstOrDefault(x => x.tableNo == DAtableNo);
            do
            {
                if (!Cancel) // Add to report
                {
                    report.Add(deleteorder);
                    for(int i=0; i<orderList.Count(); i++)
                    {
                        if (orderList[i].tableNo == DAtableNo)
                        {
                            int tempID = System.Convert.ToInt32(itemTableAdapter.GetID(orderList[i].itemName));
                            orderTableAdapter.InsertItem(System.Convert.ToInt32(orderDetailTableAdapter.GetCount()) + 1, orderList[i].tableNo, orderList[i].date);
                            orderDetailTableAdapter.InsertItem(System.Convert.ToInt32(orderDetailTableAdapter.GetCount()) + 1, tempID, orderList[i].quantity);
                                
                        }
                    }
                }

                success = orderList.Remove(deleteorder);
                deleteorder = orderList.FirstOrDefault(x => x.tableNo == DAtableNo);
            } while (deleteorder != null);
               
            if (Cancel && success)
            {
                chef.deleteallinqueue(DAtableNo);
                MessageBox.Show(String.Format("All order from table {0} has been cancelled", DAtableNo), "Warning To Chef");
            }
            if (!Cancel && success)
                MessageBox.Show(String.Format("Table {0} has paid succesfully", DAtableNo), "Success");
            if (!success)
                MessageBox.Show("Table has no order", "Warning");
        }

        public static void notifyCounter(Object qquantity, Object qitemname, Object qtableno)
        {
            MessageBox.Show(String.Format("{0} of {1} from table {2} has been cancelled", qquantity, qitemname, qtableno), "Warning To Counter");
        }

        public static void promptPayFail()
        {
            MessageBox.Show("Payment Fail", "Warning");
        }
        
        public void updateTableLV(int tableNumber)
        {
            TableLV.Clear(); // reset list view
            initTableLV(); // reset table

            for (int i=0; i<orderList.Count; i++)
            {
                if(orderList[i].tableNo.Equals(tableNumber))
                {
                    ListViewItem listViewItem = new ListViewItem(new string[] { orderList[i].itemName, orderList[i].quantity.ToString(), orderList[i].price.ToString() });
                    TableLV.Items.AddRange(new ListViewItem[] { listViewItem });
                }
            }
        }

        private void updateTotalPriceTB(int tableNumber)
        {
            double totalPrice = 0.00;

            List<Order> ordertableno = orderList.FindAll(
            delegate (Order od)
            {
                return od.tableNo == tableNumber;
            }
            );

            for (int i=0; i< ordertableno.Count; i++)
                totalPrice = totalPrice + ordertableno[i].price;

            totalPriceTB.Text = totalPrice.ToString("F");
        }
        
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (loginID == "admin" && loginPass == "admin")
                listPanel[1].BringToFront();
            else if (loginID == "admin" && loginPass != "admin")
            {
                MessageBox.Show("Wrong Password, Please try again", "Warning");
                loginPassTB.Text = "";
            }
            else
            {
                MessageBox.Show("ID does not exists, Please try again", "Warning");
                loginIDTB.Text = "";
                loginPassTB.Text = "";
            }
        }

        private void ModeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportLV.Clear();
            initReportLV();
            if (ModeCB.Text == "Daily")
                showDailyReport();
            else if (ModeCB.Text == "Monthly")
                showMonthlyReport();
            else if (ModeCB.Text == "Yearly")
                showYearlyReport();
            else if (ModeCB.Text == "Quantity")
                showQuantityReport();

            int totalsold = 0;
            double totalincome = 0;
            for (int i = 0; i < report.Count; i++)
            {
                totalsold = totalsold + report[i].quantity;
                totalincome = totalincome + report[i].price;
            }
            TotalSoldLB.Text = "Total Item(s) Sold = " + totalsold.ToString();
            TotalIncomeLB.Text = "Total Income = RM" + totalincome.ToString("F");
        }

        private void showDailyReport()
        {
            // show all day
            List<DateTime> daily = new List<DateTime>();
            // add all date
            for (int i = 0; i < report.Count; i++)
                daily.Add(report[i].date);
            // delete repeated days
            for (int x = 0; x < report.Count; x++)
                for (int i = 0; i < daily.Count; i++)
                    for (int j = 0; j < daily.Count; j++)
                        if (j != i)
                            if (daily[i].Year == daily[j].Year)
                                if (daily[i].Month == daily[j].Month)
                                    if (daily[i].Day == daily[j].Day)
                                        daily.RemoveAt(i);
            
            // find total item sold
            int[] Sold = new int[daily.Count];

            for (int i = 0; i < daily.Count; i++)
                for (int j = 0; j < report.Count; j++)
                    if (daily[i].Year == report[j].date.Year)
                        if (daily[i].Month == report[j].date.Month)
                            if (daily[i].Day == report[j].date.Day)
                                Sold[i] = Sold[i] + report[j].quantity;

            // find total income
            double[] Income = new double[daily.Count];

            for (int i = 0; i < daily.Count; i++)
                for (int j = 0; j < report.Count; j++)
                    if (daily[i].Year == report[j].date.Year)
                        if (daily[i].Month == report[j].date.Month)
                            if (daily[i].Day == report[j].date.Day)
                                Income[i] = Income[i] + report[j].price;

            for (int i = 0; i < daily.Count; i++)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { daily[i].ToString(), Sold[i].ToString(), Income[i].ToString("F") });
                ReportLV.Items.AddRange(new ListViewItem[] { listViewItem });
            }
            ReportLV.ListViewItemSorter = new ListViewItemComparer();
            ReportLV.Sort();
        }

        private void showMonthlyReport()
        {
            // show all month
            List<DateTime> monthly = new List<DateTime>();
            // add all date
            for (int i = 0; i < report.Count; i++)
                monthly.Add(report[i].date);
            // delete repeated days
            for (int x = 0; x < report.Count; x++)
                for (int i = 0; i < monthly.Count; i++)
                    for (int j = 0; j < monthly.Count; j++)
                        if (j != i)
                            if (monthly[i].Year == monthly[j].Year)
                                if (monthly[i].Month == monthly[j].Month)
                                    monthly.RemoveAt(i);

            // find total item sold
            int[] Sold = new int[monthly.Count];

            for (int i = 0; i < monthly.Count; i++)
                for (int j = 0; j < report.Count; j++)
                    if (monthly[i].Year == report[j].date.Year)
                        if (monthly[i].Month == report[j].date.Month)
                            Sold[i] = Sold[i] + report[j].quantity;

            // find total income
            double[] Income = new double[monthly.Count];

            for (int i = 0; i < monthly.Count; i++)
                for (int j = 0; j < report.Count; j++)
                    if (monthly[i].Year == report[j].date.Year)
                        if (monthly[i].Month == report[j].date.Month)
                            Income[i] = Income[i] + report[j].price;

            for (int i = 0; i < monthly.Count; i++)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { monthly[i].ToString("M/yyyy"), Sold[i].ToString(), Income[i].ToString("F") });
                ReportLV.Items.AddRange(new ListViewItem[] { listViewItem });
            }
            ReportLV.ListViewItemSorter = new ListViewItemComparer();
            ReportLV.Sort();
        }

        private void showYearlyReport()
        {
            // show all yearly
            List<DateTime> yearly = new List<DateTime>();
            // add all date
            for (int i = 0; i < report.Count; i++)
                yearly.Add(report[i].date);
            // delete repeated days
            for (int x = 0; x < report.Count; x++)
                for (int i = 0; i < yearly.Count; i++)
                    for (int j = 0; j < yearly.Count; j++)
                        if (j != i)
                            if (yearly[i].Year == yearly[j].Year)
                                yearly.RemoveAt(i);
            

            // find total item sold
            int[] Sold = new int[yearly.Count];

            for (int i = 0; i < yearly.Count; i++)
                for (int j = 0; j < report.Count; j++)
                    if (yearly[i].Year == report[j].date.Year)
                        Sold[i] = Sold[i] + report[j].quantity;

            // find total income
            double[] Income = new double[yearly.Count];

            for (int i = 0; i < yearly.Count; i++)
                for (int j = 0; j < report.Count; j++)
                    if (yearly[i].Year == report[j].date.Year)
                        Income[i] = Income[i] + report[j].price;

            for (int i = 0; i < yearly.Count; i++)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { yearly[i].ToString("yyyy"), Sold[i].ToString(), Income[i].ToString("F") });
                ReportLV.Items.AddRange(new ListViewItem[] { listViewItem });
            }
            ReportLV.ListViewItemSorter = new ListViewItemComparer();
            ReportLV.Sort();
        }

        private void showQuantityReport()
        {
            ReportLV.Clear(); // Reset

            ReportLV.Columns.Add("Date", 150, HorizontalAlignment.Left);
            ReportLV.Columns.Add("Item(s) Sold", 200, HorizontalAlignment.Right);
            ReportLV.Columns.Add("Item Name", 200, HorizontalAlignment.Left);
            ReportLV.View = View.Details; // Manual sort

            for (int i = 0; i < report.Count; i++)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { report[i].date.ToString(), report[i].quantity.ToString(), report[i].itemName.ToString() });
                ReportLV.Items.AddRange(new ListViewItem[] { listViewItem });
            }
        }

        private void loginIDTB_TextChanged(object sender, EventArgs e)
        {
            loginID = loginIDTB.Text;
        }

        private void loginPassTB_TextChanged_1(object sender, EventArgs e)
        {
            loginPass = loginPassTB.Text;
            loginPassTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (loginID == "admin" && loginPass == "admin")
                {
                    listPanel[1].BringToFront();
                }
            }
        }

        private void ChefLogin_Click(object sender, EventArgs e)
        {
            chef.Show();
            chef.Focus();
        }

        private void LogOutButtonManager_Click(object sender, EventArgs e)
        {
            listPanel[0].BringToFront();
            loginPassTB.Text = "";
        }

        private void NewItemButton_Click(object sender, EventArgs e)
        {
            newItem.ShowDialog();
            updateTableLV(selectedTableNo);
        }

        private void ModifyListButton_Click(object sender, EventArgs e)
        {
            listPanel[3].BringToFront();
        }

        private void itemPriceTB_TextChanged(object sender, EventArgs e)
        {
            itemPrice_Str = itemPriceTB.Text;
        }

        private void BackButtonModify_Click(object sender, EventArgs e)
        {
            listPanel[1].BringToFront();
        }

        private void backButtonReport_Click(object sender, EventArgs e)
        {
            listPanel[1].BringToFront();
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            listPanel[2].BringToFront();
        }

        private void CancelItemButton_Click(object sender, EventArgs e)
        {
            cancelItem.ShowDialog();
            updateTableLV(selectedTableNo);
        }

        private void CardPaymentButton_Click(object sender, EventArgs e)
        {
            if (selectedTableNo > 0)
            {
                double totalPrice = 0;

                List<Order> ordertableno = orderList.FindAll(
                delegate (Order od)
                {
                    return od.tableNo == selectedTableNo;
                }
                );

                for (int i = 0; i < ordertableno.Count; i++)
                    totalPrice = totalPrice + ordertableno[i].price;

                card.ShowDialog();
                card.updateDue(totalPrice.ToString("F"), selectedTableNo);
                updateTableLV(selectedTableNo);
            }
            else
                MessageBox.Show("No Table Selected", "Warning");
        }

        private void CashPaymentButton_Click(object sender, EventArgs e)
        {
            if(selectedTableNo > 0 )
            {
                double totalPrice = 0.00;

                List<Order> ordertableno = orderList.FindAll(
                delegate (Order od)
                {
                    return od.tableNo == selectedTableNo;
                }
                );

                for (int i = 0; i < ordertableno.Count; i++)
                    totalPrice = totalPrice + ordertableno[i].price;

                cash.ShowDialog();
                cash.updateDue(totalPrice.ToString("F"), selectedTableNo);
                updateTableLV(selectedTableNo);
            }
            else
                MessageBox.Show("No Table Selected", "Warning");
        }

        private void resetAllTableColor()
        {
            table1.BackColor = SystemColors.ControlDark;
            table2.BackColor = SystemColors.ControlDark;
            table3.BackColor = SystemColors.ControlDark;
            table4.BackColor = SystemColors.ControlDark;
            table5.BackColor = SystemColors.ControlDark;
            table6.BackColor = SystemColors.ControlDark;
            table7.BackColor = SystemColors.ControlDark;
            table8.BackColor = SystemColors.ControlDark;
            table9.BackColor = SystemColors.ControlDark;
            table10.BackColor = SystemColors.ControlDark;
            table11.BackColor = SystemColors.ControlDark;
            table12.BackColor = SystemColors.ControlDark;
            table13.BackColor = SystemColors.ControlDark;
            table14.BackColor = SystemColors.ControlDark;
            table15.BackColor = SystemColors.ControlDark;
            table16.BackColor = SystemColors.ControlDark;
            table17.BackColor = SystemColors.ControlDark;
            table18.BackColor = SystemColors.ControlDark;
            table19.BackColor = SystemColors.ControlDark;
            table20.BackColor = SystemColors.ControlDark;
            table21.BackColor = SystemColors.ControlDark;
            table22.BackColor = SystemColors.ControlDark;
            table23.BackColor = SystemColors.ControlDark;
            table24.BackColor = SystemColors.ControlDark;
        }

        private void table1_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table1.BackColor = SystemColors.Highlight;

            updateTableLV(1);
            updateTotalPriceTB(1);
            selectedTableNo = 1;
        }

        private void table2_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table2.BackColor = SystemColors.Highlight;

            updateTableLV(2);
            updateTotalPriceTB(2);
            selectedTableNo = 2;
        }

        private void table3_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table3.BackColor = SystemColors.Highlight;

            updateTableLV(3);
            updateTotalPriceTB(3);
            selectedTableNo = 3;
        }

        private void table4_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table4.BackColor = SystemColors.Highlight;

            updateTableLV(4);
            updateTotalPriceTB(4);
            selectedTableNo = 4;
        }

        private void table5_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table5.BackColor = SystemColors.Highlight;

            updateTableLV(5);
            updateTotalPriceTB(5);
            selectedTableNo = 5;
        }

        private void table6_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table6.BackColor = SystemColors.Highlight;

            updateTableLV(6);
            updateTotalPriceTB(6);
            selectedTableNo = 6;
        }

        private void table7_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table7.BackColor = SystemColors.Highlight;

            updateTableLV(7);
            updateTotalPriceTB(7);
            selectedTableNo = 7;
        }

        private void table8_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table8.BackColor = SystemColors.Highlight;

            updateTableLV(8);
            updateTotalPriceTB(8);
            selectedTableNo = 8;
        }

        private void table9_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table9.BackColor = SystemColors.Highlight;

            updateTableLV(9);
            updateTotalPriceTB(9);
            selectedTableNo = 9;
        }

        private void table10_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table10.BackColor = SystemColors.Highlight;

            updateTableLV(10);
            updateTotalPriceTB(10);
            selectedTableNo = 10;
        }

        private void table11_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table11.BackColor = SystemColors.Highlight;

            updateTableLV(11);
            updateTotalPriceTB(11);
            selectedTableNo = 11;
        }

        private void table12_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table12.BackColor = SystemColors.Highlight;

            updateTableLV(12);
            updateTotalPriceTB(12);
            selectedTableNo = 12;
        }

        private void table13_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table13.BackColor = SystemColors.Highlight;

            updateTableLV(13);
            updateTotalPriceTB(13);
            selectedTableNo = 13;
        }

        private void table14_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table14.BackColor = SystemColors.Highlight;

            updateTableLV(14);
            updateTotalPriceTB(14);
            selectedTableNo = 14;
        }

        private void table15_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table15.BackColor = SystemColors.Highlight;

            updateTableLV(15);
            updateTotalPriceTB(15);
            selectedTableNo = 15;
        }

        private void table16_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table16.BackColor = SystemColors.Highlight;

            updateTableLV(16);
            updateTotalPriceTB(16);
            selectedTableNo = 16;
        }

        private void table17_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table17.BackColor = SystemColors.Highlight;

            updateTableLV(17);
            updateTotalPriceTB(17);
            selectedTableNo = 17;
        }

        private void table18_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table18.BackColor = SystemColors.Highlight;

            updateTableLV(18);
            updateTotalPriceTB(18);
            selectedTableNo = 18;
        }

        private void table19_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table19.BackColor = SystemColors.Highlight;

            updateTableLV(19);
            updateTotalPriceTB(19);
            selectedTableNo = 19;
        }

        private void table20_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table20.BackColor = SystemColors.Highlight;

            updateTableLV(20);
            updateTotalPriceTB(20);
            selectedTableNo = 20;
        }

        private void table21_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table21.BackColor = SystemColors.Highlight;

            updateTableLV(21);
            updateTotalPriceTB(21);
            selectedTableNo = 21;
        }

        private void table22_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table22.BackColor = SystemColors.Highlight;

            updateTableLV(22);
            updateTotalPriceTB(22);
            selectedTableNo = 22;
        }

        private void table23_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table23.BackColor = SystemColors.Highlight;

            updateTableLV(23);
            updateTotalPriceTB(23);
            selectedTableNo = 23;
        }

        private void table24_Click(object sender, EventArgs e)
        {
            resetAllTableColor();
            table24.BackColor = SystemColors.Highlight;

            updateTableLV(24);
            updateTotalPriceTB(24);
            selectedTableNo = 24;
        }

        private void PrintReceiptButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hardware Device is Missing", "Warning");
        }

        private void itemTypeCB_TextUpdate(object sender, EventArgs e)
        {
            itemType = itemTypeCB.Text;
        }

        private void itemTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemType = itemTypeCB.Text;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hardware Device is Missing", "Warning");
        }

        private void itemNameTB_TextChanged(object sender, EventArgs e)
        {
            itemName = itemNameTB.Text;
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            try
            {
                itemPrice = Convert.ToDouble(itemPrice_Str); // try convert to double

                ListViewItem searchItem = null;
                int index = 0;
                bool itemExist = false;
                do
                {
                    if (index < ItemLV.Items.Count)
                    {
                        searchItem = ItemLV.FindItemWithText(itemName, false, index, false);
                        if (searchItem != null)
                        {
                            itemExist = true;
                            index = searchItem.Index + 1;
                            break;
                        }
                    }
                    else
                        searchItem = null;

                } while (searchItem != null);

                if (itemName != "" && itemName != null && itemPrice >= 0 && itemPrice_Str != null && !itemExist && (itemType != "Food" || itemType != "Beverage"))
                {
                    itemList.Add(new Item() { item_Name = itemName, item_Type = itemType, item_Price = itemPrice }); // add to list

                    itemTableAdapter.InsertItem(System.Convert.ToInt32(itemTableAdapter.GetCount()) + 1, itemName, System.Convert.ToDecimal(itemPrice), itemType);

                    itemNameDelete.Items.Add(new { Text = itemName }); // add to delete box

                    ListViewItem listViewItem = new ListViewItem(new string[] { itemName, itemType, itemPrice.ToString("F") });
                    ItemLV.Items.AddRange(new ListViewItem[] { listViewItem }); // add to list view
                }
                else if (itemExist)
                    MessageBox.Show("Item Name already exists", "Warning");
                else
                    MessageBox.Show("A fill area is missing or incorrect", "Warning");
            }
            catch (FormatException) // popup error, havent implement yet
            {
                MessageBox.Show("Item Price is not a decimal", "Warning");
            }
        }

        private void DeleteItemButton_Click(object sender, EventArgs e)
        {
            string itemName = itemNameDelete.Text;

            if (itemName != null) // error proof
            {
                var itemToRemove = itemList.FirstOrDefault(r => r.item_Name == itemName);

                if (itemToRemove != null)
                {
                    itemList.Remove(itemToRemove); // remove from list

                    itemTableAdapter.DeleteItem(System.Convert.ToString(itemName));

                    itemNameDelete.Items.Remove(itemNameDelete.SelectedItem); // remove from delete box

                    // search view list box and delete
                    ListViewItem searchItem = null;
                    int index = 0;
                    do
                    {
                        if (index < ItemLV.Items.Count)
                        {
                            searchItem = ItemLV.FindItemWithText(itemName, false, index, false);
                            if (searchItem != null)
                            {
                                ItemLV.Items.Remove(searchItem);
                                index = searchItem.Index + 1;
                            }
                        }
                        else
                            searchItem = null;

                    } while (searchItem != null);
                }
                else
                    MessageBox.Show("Item name is not in the list", "Warning");
            }
            else
                MessageBox.Show("A fill is missing or incorrect", "Warning");
            itemNameDelete.Text = "";
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
