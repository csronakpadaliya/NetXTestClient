using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neuron.NetX.Administration;
using System.Collections;

namespace Neuron.TestClient
{
    public partial class NeuronConfigDataDocImporter : Form
    {
        private ListViewColumnSorter lvwColumnSorter;

        public NeuronConfigDataDocImporter()
        {
            InitializeComponent();

            ResizeLastLVColumn(listViewDocs, new EventArgs(), Resizing);

            lvwColumnSorter = new ListViewColumnSorter();
            listViewDocs.ListViewItemSorter = lvwColumnSorter;

        }

        public static void ResizeLastLVColumn(object sender, EventArgs e, bool resizing)
        {
            try
            {
                // Don't allow overlapping of SizeChanged calls
                if (!resizing)
                {
                    // Set the resizing flag
                    resizing = true;

                    System.Windows.Forms.ListView listView = sender as System.Windows.Forms.ListView;
                    listView.BeginUpdate();
                    if (listView != null)
                    {
                        int totalColumnWidth = 0;

                        // Get the sum of all column tags (**added a -1)
                        for (int i = 0; i < listView.Columns.Count - 1; i++)
                        {

                            // ** new
                            totalColumnWidth += listView.Columns[i].Width;
                        }

                        // **new
                        if (listView.ClientRectangle.Width > totalColumnWidth)
                            listView.Columns[listView.Columns.Count - 1].Width = listView.ClientRectangle.Width - totalColumnWidth;

                    }
                    listView.EndUpdate();
                }

                // Clear the resizing flag
                resizing = false;
            }
            catch { }
        }

        public ESBEntityBasis [] ListItems
        {
            get;
            set;
        }

        public ESBEntityBasis SelectedItem
        {
            get;
            private set;
        }

        private void listViewDocs_DoubleClick(object sender, EventArgs e)
        {
            if (listViewDocs.SelectedItems.Count > 0)
            {
                SelectedItem = (ESBEntityBasis)listViewDocs.SelectedItems[0].Tag;
                buttonOK.PerformClick();
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (listViewDocs.SelectedItems.Count == 0)
            {
                MessageBox.Show("There is no document selected");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private bool Resizing = false;
        private void listViewDocs_Resize(object sender, EventArgs e)
        {
            ResizeLastLVColumn(sender, e, Resizing);

        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void listViewDocs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            listViewDocs.Sort();
        }

        
        private void listViewDocs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDocs.SelectedItems.Count > 0)
            {
                SelectedItem = (ESBEntityBasis)listViewDocs.SelectedItems[0].Tag;
            }
        }

       

        private void FillListView(string searchClause)
        {
            this.listViewDocs.Items.Clear() ;

            foreach (ESBEntityBasis item in ListItems)
            {
                if (item != null)
                {
                    if (!string.IsNullOrEmpty(searchClause))
                        if (item.Name.IndexOf(searchClause, StringComparison.OrdinalIgnoreCase) == -1 && item.Group.IndexOf(searchClause, StringComparison.OrdinalIgnoreCase) == -1 && item.Description.IndexOf(searchClause, StringComparison.OrdinalIgnoreCase) == -1)
                            continue;

                    ListViewItem listItem = new ListViewItem(item.Name);

                    listItem.SubItems.Add(item.Group);

                    listItem.SubItems.Add(item.Description);

                    listItem.Tag = item;
                    this.listViewDocs.Items.Add(listItem);
                }
            }

            if (this.listViewDocs.Items.Count > 0)
            {
                this.listViewDocs.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                this.listViewDocs.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwColumnSorter.SortColumn = 0;
                lvwColumnSorter.Order = SortOrder.Ascending;
                this.listViewDocs.Sort();
            }

        }
        private void NeuronConfigDataDocImporter_Load(object sender, EventArgs e)
        {
            

            if (ListItems != null && ListItems.Length > 0)
            {

                FillListView(null);
            }
            else
            {
                MessageBox.Show("There were no documents found in the configuration");
                this.BeginInvoke(new MethodInvoker(UnloadMe));
            }
        }

        private void UnloadMe()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

       
    }
}
