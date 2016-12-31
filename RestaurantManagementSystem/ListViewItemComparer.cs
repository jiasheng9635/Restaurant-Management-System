using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagementSystem
{
    class ListViewItemComparer : IComparer
    {
        private int col;
        private SortOrder order;
        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y)
        {
            int returnVal;
            // Determine whether the type being compared is a date type.  
            try
            {
                // Parse the two objects passed as a parameter as a DateTime.  
                DateTime firstDate = DateTime.Parse(((ListViewItem)x).SubItems[col].Text);
                DateTime secondDate = DateTime.Parse(((ListViewItem)y).SubItems[col].Text);
                // Compare the two dates.  
                returnVal = DateTime.Compare(firstDate, secondDate);
            }
            // If neither compared object has a valid date format
            catch
            {
                try
                {
                    // Compare the two items as a numeric.  
                    double d1 = double.Parse(((ListViewItem)x).SubItems[col].Text);
                    double d2 = double.Parse(((ListViewItem)y).SubItems[col].Text);
                    
                    returnVal = d1.CompareTo(d2);
                }
                catch
                {
                    // Compare the two items as a string.  
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                ((ListViewItem)y).SubItems[col].Text);
                }
            }
            // Determine whether the sort order is descending.  
            if (order == SortOrder.Descending)
                // Invert the value returned by String.Compare.  
                returnVal *= -1;
            return returnVal;
        }
    }
}
