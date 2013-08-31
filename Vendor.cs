using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Asset_Mng
{
    public partial class Vendor : Form
    {
        public Vendor()
        {
            InitializeComponent();
        }

       /* private void ÝÑæÔäÏåBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
          //  this.ÝÑæÔäÏåBindingSource.EndEdit();
          //  this.ÝÑæÔäÏåTableAdapter.Update(this.asset_MngDataSet.ÝÑæÔäÏå);

        }*/

        private void Vendor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'asset_MngDataSet.ÝÑæÔäÏå' table. You can move, or remove it, as needed.
           this.فروشندهTableAdapter.Fill(asset_MngDataSet.فروشنده);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void فروشندهBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.فروشندهBindingSource.EndEdit();
            this.فروشندهTableAdapter.Fill(this.asset_MngDataSet.فروشنده);
        }

        private void فروشندهDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}