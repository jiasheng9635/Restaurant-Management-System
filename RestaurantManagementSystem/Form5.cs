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
    public partial class Form5 : Form
    {
        int tableNo, quantity;
        string itemName, itemType, quantity_Str, tableNo_Str;

        public Form5()
        {
            InitializeComponent();
        }

        private void ItemNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemName = ItemNameCB.Text;
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
                MessageBox.Show("Quantity is not a decimal", "Warning");
                TableNoCB.Text = "1";
            }
        }

        private void deleteOne_Click(object sender, EventArgs e)
        {
            if (tableNo > 0 && (itemType != "Food" || itemType != "Beverage") && itemName != null && quantity > 0) // error proof
                Form1.DeleteOneOrder(tableNo, itemType, itemName, quantity, false);
            else
                MessageBox.Show("A fill area is missing or incorrect", "Warning");
        }

        private void deleteAll_Click(object sender, EventArgs e)
        {
            if (tableNo > 0) // error proof
                Form1.DeleteAllOrder(tableNo,true);
            else
                MessageBox.Show("Table Number is missing", "Warning");
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Hide();
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
                MessageBox.Show("Quantity is not a decimal", "Warning");
                TableNoCB.Text = "1";
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.ActiveControl = TableNoCB;

            TableNoCB.DisplayMember = "Text";
            TableNoCB.IntegralHeight = false;
            TableNoCB.MaxDropDownItems = 5;
            for (int i = 1; i <= 24; i++)
                TableNoCB.Items.Add(new { Text = i.ToString() });

            ItemTypeCB.DisplayMember = "Text";
            ItemTypeCB.IntegralHeight = false;
            ItemTypeCB.Items.Add(new { Text = "Food" });
            ItemTypeCB.Items.Add(new { Text = "Beverage" });
            /*
            ItemTypeCB.MaxDropDownItems = 5;
            for (int i = 0; i < Form1.itemList.Count(); i++)
                ItemTypeCB.Items.Add(new { Text = Form1.itemList[i].item_Type });
            // delete repeated item type
            for (int i = 0; i < ItemTypeCB.Items.Count; i++)
                for (int y = 0; y < ItemTypeCB.Items.Count; y++)
                    if (y != i && ItemTypeCB.Items[i].Equals(ItemTypeCB.Items[y]))
                        ItemTypeCB.Items.RemoveAt(i);
                        */

            QuantityCB.DisplayMember = "Text";
            QuantityCB.IntegralHeight = false;
            QuantityCB.MaxDropDownItems = 5;
            for (int i = 1; i <= 10; i++)
                QuantityCB.Items.Add(new { Text = i.ToString() });
            QuantityCB.SelectedIndex = 0; // deafult choose 1

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
                if (ItemTypeCB.Text == Form1.itemList[i].item_Type)
                    ItemNameCB.Items.Add(new { Text = Form1.itemList[i].item_Name });
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
