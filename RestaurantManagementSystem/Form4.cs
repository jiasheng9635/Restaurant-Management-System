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
    public partial class Form4: Form
    {
        int tableNo, quantity;
        double itemPrice, defaultPrice;
        string itemName, itemType, quantity_Str, tableNo_Str, itemPrice_Str;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.ActiveControl = TableNoCB;

            TableNoCB.DisplayMember = "Text";
            TableNoCB.IntegralHeight = false;
            TableNoCB.MaxDropDownItems = 5;
            for (int i=1; i<=24; i++)
                TableNoCB.Items.Add(new { Text = i.ToString() });
            
            ItemTypeCB.DisplayMember = "Text";
            ItemTypeCB.IntegralHeight = false;
            ItemTypeCB.Items.Add(new { Text = "Food" });
            ItemTypeCB.Items.Add(new { Text = "Beverage" });

            QuantityCB.DisplayMember = "Text";
            QuantityCB.IntegralHeight = false;
            QuantityCB.MaxDropDownItems = 5;
            for (int i = 1; i <= 10; i++)
                QuantityCB.Items.Add(new { Text = i.ToString() });
            QuantityCB.SelectedIndex=0; // deafult choose 1

            ItemNameCB.DisplayMember = "Text";
            ItemNameCB.IntegralHeight = false;
            ItemNameCB.MaxDropDownItems = 5;
        }

        private void ItemTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemType = ItemTypeCB.Text;

            ItemNameCB.Items.Clear(); //clear all data before adding new
            ItemNameCB.Text = ""; //clear selection
            for (int i = 0; i < Form1.itemList.Count(); i++)
                if (ItemTypeCB.Text==Form1.itemList[i].item_Type)
                    ItemNameCB.Items.Add(new { Text = Form1.itemList[i].item_Name });
        }

        private void ItemNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemName = ItemNameCB.Text;

            int index = -1;
            for (int i = 0; i < Form1.itemList.Count(); i++)
                if (Form1.itemList[i].item_Name == itemName)
                    index = i;

            if (index != -1)
            {
                PriceTB.Text = Form1.itemList[index].item_Price.ToString();
                defaultPrice = Form1.itemList[index].item_Price;
            }
            else
                MessageBox.Show("Item Name is not in the list", "Warning");
        }

        private void TableNoCB_TextUpdate(object sender, EventArgs e)
        {
            tableNo_Str = TableNoCB.Text;
            try
            {
                tableNo = Convert.ToInt32(tableNo_Str); // try convert to integer
            }
            catch (FormatException) // popup error, havent implement yet
            {
                MessageBox.Show("Table Number is not a number", "Warning");
                TableNoCB.Text = "";
            }
        }

        private void ItemTypeCB_TextUpdate(object sender, EventArgs e)
        {
            itemType = ItemTypeCB.Text;

            ItemNameCB.Items.Clear(); //clear all data before adding new
            ItemNameCB.Text = ""; //clear selection
            for (int i = 0; i < Form1.itemList.Count(); i++)
                if (ItemTypeCB.Text == Form1.itemList[i].item_Type)
                    ItemNameCB.Items.Add(new { Text = Form1.itemList[i].item_Name });
        }

        private void ItemNameCB_TextUpdate(object sender, EventArgs e)
        {
            itemName = ItemNameCB.Text;
        }

        private void QuantityCB_TextUpdate(object sender, EventArgs e)
        {
            quantity_Str = QuantityCB.Text;
            try
            {
                quantity = Convert.ToInt32(quantity_Str); // try convert to integer
            }
            catch (FormatException) // popup error, havent implement yet
            {
                MessageBox.Show("Quantity is not a number", "Warning");
                QuantityCB.Text = "1";
            }
        }

        private void QuantityCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            quantity_Str = QuantityCB.Text;
            try
            {
                quantity = Convert.ToInt32(quantity_Str); // try convert to integer
            }
            catch (FormatException) // popup error, havent implement yet
            {
                MessageBox.Show("Quantity is not a number", "Warning");
                QuantityCB.Text = "1";
            }
            
        }

        private void PriceTB_TextChanged(object sender, EventArgs e)
        {
            itemPrice_Str = PriceTB.Text;

            try
            {
                itemPrice = Convert.ToDouble(itemPrice_Str); // try convert to double
            }
            catch (FormatException) // popup error, havent implement yet
            {
                MessageBox.Show("Price is not a decimal", "Warning");
                QuantityCB.Text = defaultPrice.ToString();
            }
        }
        
        private void TableNoCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableNo_Str = TableNoCB.Text;
            try
            {
                tableNo = Convert.ToInt32(tableNo_Str); // try convert to integer
            }
            catch (FormatException) // popup error, havent implement yet
            {
                MessageBox.Show("Table Number is not a number", "Warning");
                TableNoCB.Text = "";
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if(tableNo>0 && (itemType != "Food" || itemType != "Beverage") && itemName!= null && quantity>0 && itemPrice>=0) // error proof
                Form1.AddToOrderList(tableNo, itemType, itemName, quantity, itemPrice);
            else
                MessageBox.Show("A fill area is missing or incorrect", "Warning");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
