using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISEdesign
{
    class ListViewItemComparer : IComparer
    {
        private int col;
        private System.Windows.Forms.SortOrder order;
        public ListViewItemComparer() 
        {
            col=0;
            order = SortOrder.Ascending;
        }

        public ListViewItemComparer(int column, SortOrder order) 
        {
            col=column;
            this.order = order;
        }

        public int Compare(object x, object y) 
        {
            int returnVal= -1;
            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                    ((ListViewItem)y).SubItems[col].Text);
            // Determine whether the sort order is descending.
            if ( order == SortOrder.Descending ) returnVal *= -1;
            // Invert the value returned by String.Compare.
            return returnVal;
        }
    }
}
