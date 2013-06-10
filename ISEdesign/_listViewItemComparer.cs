using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISEdesign
{
    class _listViewItemComparer : IComparer
    {
        private int col;
        private SortOrder order;

        public _listViewItemComparer() 
        {
            col=0;
            order = SortOrder.Ascending;
        }
        public _listViewItemComparer(int column, SortOrder order) 
        {
            col=column;
            this.order = order;
        }
        public int Compare(object x, object y) 
        {
            int returnVal= -1;
            if ( col == 0 )//Name = string
            {
                returnVal = String.Compare( ((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text );
                if(order == SortOrder.Ascending) return returnVal;
                else return returnVal *= -1;
            }
            else //Decimals
            {            
                ListViewItem listX = (ListViewItem)x;
                ListViewItem listY = (ListViewItem)y;

                // Convert column text to numbers before comparing.
                // If the conversion fails, just use the value 0.
                decimal listXVal, listYVal;
                char[] avoidPercentage = { '%' };
                try { listXVal = Decimal.Parse( listX.SubItems[col].Text.TrimEnd( avoidPercentage ) ); }
                catch { listXVal = 0; }

                try { listYVal = Decimal.Parse( listY.SubItems[col].Text ); }
                catch { listYVal = 0; }

                returnVal = Decimal.Compare( listXVal, listYVal );
                if ( order == SortOrder.Ascending ) return returnVal;
                else return returnVal *= -1;
            }
        }     
    }
}

