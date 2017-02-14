using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Customers : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
{
if (!this.IsPostBack)
{
// Set color options.
lstBackColor.Items.Add("White");
lstBackColor.Items.Add("Red");
lstBackColor.Items.Add("Green");
lstBackColor.Items.Add("Blue");
lstBackColor.Items.Add("Yellow");
// Set font options.
lstFontName.Items.Add("Times New Roman");
lstFontName.Items.Add("Arial");
lstFontName.Items.Add("Verdana");
lstFontName.Items.Add("Tahoma");
// Set border style options by adding a series of
// ListItem objects.
ListItem item = new ListItem();
// The item text indicates the name of the option.
item.Text = BorderStyle.None.ToString();
// The item value records the corresponding integer
// from the enumeration. To obtain this value, you
// must cast the enumeration value to an integer,
// and then convert the number to a string so it
// can be placed in the HTML page.
item.Value = ((int)BorderStyle.None).ToString();
// Add the item.
lstBorder.Items.Add(item);
// Now repeat the process for two other border styles.
item = new ListItem();
item.Text = BorderStyle.Double.ToString();
item.Value = ((int)BorderStyle.Double).ToString();
lstBorder.Items.Add(item);
item = new ListItem();
item.Text = BorderStyle.Solid.ToString();
item.Value = ((int)BorderStyle.Solid).ToString();
lstBorder.Items.Add(item);
// Select the first border option.
lstBorder.SelectedIndex = 0;
// Set the picture.
imgDefault.ImageUrl = "defaultpic.png";
}
}
protected void cmdUpdate_Click(object sender, EventArgs e)
{
// Update the color.
pnlCard.BackColor = Color.FromName(lstBackColor.SelectedItem.Text);
// Update the font.

lblGreeting.Font.Name = lstFontName.SelectedItem.Text;
if (Int32.Parse(txtFontSize.Text) > 0)
{
lblGreeting.Font.Size =
FontUnit.Point(Int32.Parse(txtFontSize.Text));
}
// Update the border style. This requires two conversion steps.
// First, the value of the list item is converted from a string
// into an integer. Next, the integer is converted to a value in
// the BorderStyle enumeration.
int borderValue = Int32.Parse(lstBorder.SelectedItem.Value);
pnlCard.BorderStyle = (BorderStyle)borderValue;
// Update the picture.
if (chkPicture.Checked)
{
imgDefault.Visible = true;
}
else
{
imgDefault.Visible = false;
}
// Set the text.
lblGreeting.Text = txtGreeting.Text;
}
}