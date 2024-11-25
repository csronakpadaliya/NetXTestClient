using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace Neuron.TestClient
{
    public class Sorter : IComparer
    {
        // Initialize the variables to default
        public int column = 0;
        public bool bAscending = true;

        // Using the Compare function of IComparer
        public int Compare(object x, object y)
        {
            // Cast the objects to ListViewItems
            ListViewItem lvi1 = (ListViewItem)x;
            ListViewItem lvi2 = (ListViewItem)y;

            // If the column is the string columns
            //if (column != 2)
            //{
                string lvi1String = lvi1.SubItems[column].ToString();
                string lvi2String = lvi2.SubItems[column].ToString();

                // Return the normal Compare
                if (bAscending)
                    return String.Compare(lvi1String, lvi2String);

                // Return the negated Compare
                return -String.Compare(lvi1String, lvi2String);
            //}

            //// The column is the Age column
            //int lvi1Int = ParseListItemString(lvi1.SubItems[column].ToString());
            //int lvi2Int = ParseListItemString(lvi2.SubItems[column].ToString());

            //// Return the normal compare.. if x < y then return -1
            //if (bAscending)
            //{
            //    if (lvi1Int < lvi2Int)
            //        return -1;
            //    else if (lvi1Int == lvi2Int)
            //        return 0;

            //    return 1;
            //}

            //// Return the opposites for descending
            //if (lvi1Int > lvi2Int)
            //    return -1;
            //else if (lvi1Int == lvi2Int)
            //    return 0;

            //return 1;
        }

        private int ParseListItemString(string x)
        {
            //ListViewItems are returned like this: "ListViewSubItem: {19}"
            int counter = 0;
            for (int i = x.Length - 1; i >= 0; i--, counter++)
            {
                if (x[i] == '{')
                    break;
            }

            return Int32.Parse(x.Substring(x.Length - counter, counter - 1));
        }
    }
}