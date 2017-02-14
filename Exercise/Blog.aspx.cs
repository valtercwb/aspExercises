using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Blog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    // Configure the table's appearance.
    // This could also be performed in the .aspx file
    // or in the cmdCreate_Click event handler.
    tbl.BorderStyle = BorderStyle.Inset;
    tbl.BorderWidth = Unit.Pixel(1);
    
    }

    protected void cmdCreate_Click(object sender, EventArgs e)
    {
        // Remove all the current rows and cells.
        // This is not necessary if EnableViewState is set to false.
        tbl.Controls.Clear();
        int rows = Int32.Parse(txtRows.Text);
        int cols = Int32.Parse(txtCols.Text);
        for (int row = 0; row < rows; row++)
        {
            // Create a new TableRow object.
            TableRow rowNew = new TableRow();
            // Put the TableRow in the Table.
            tbl.Controls.Add(rowNew);
            for (int col = 0; col < cols; col++)
            {
                // Create a new TableCell object.
                TableCell cellNew = new TableCell();
                cellNew.Text = "Example Cell (" + row.ToString() + ",";
                cellNew.Text += col.ToString() + ")";
                if (chkBorder.Checked)
                {
                    cellNew.BorderStyle = BorderStyle.Inset;
                    cellNew.BorderWidth = Unit.Pixel(1);
                }
                // Put the TableCell in the TableRow.
                rowNew.Controls.Add(cellNew);
            }
        }
    }
}