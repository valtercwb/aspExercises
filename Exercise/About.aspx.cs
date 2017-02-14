using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!this.IsPostBack){
            // The HtmlSelect control accepts text or ListItem objects.
            Currency.Items.Add(new ListItem("Euro", "0.85"));//Drop down list values
            Currency.Items.Add(new ListItem("Japanese Yen", "110.33"));
            Currency.Items.Add(new ListItem("Canadian Dollar","1.2"));            
        }
    }

    protected void Convert_ServerClick(object sender, EventArgs e)
    {
        decimal oldAmount;
        bool success = Decimal.TryParse(US.Value, out oldAmount);

        // decimal USAmount = Decimal.Parse(US.Value);//Retrieves the values from the textbox & convert it to a numeric value
        if ((oldAmount <=0) || (success==false))
        {
        Result.Style["color"] = "Red";
            Result.InnerText = "Specify a positive number";
        }else{
            Result.Style["color"] = "Black";
            ListItem item = Currency.Items[Currency.SelectedIndex];
            // Retrieve the selected ListItem object by its index number.
            decimal newAmount = oldAmount * Decimal.Parse(item.Value);
            Result.InnerText = oldAmount.ToString() + " U.S. dollars = ";// set the text of the of the p element
            Result.InnerText += newAmount.ToString()+" " + item.Text;
        }
       // else { 
        // The onversion Failed
           // Result.InnerText = "The number you typed in was not in the correct format."+
             //   "Use only numbers. Letters and characteres are not allowed!";
        //}
    }

    protected void ShowGraph_ServerClick(Object sender, EventArgs e) {
        Graph.Src = "Pic" + Currency.SelectedIndex.ToString() + ".png";
        Graph.Visible = true;
    }

    protected void ImgButton_ServerClick(Object sender, ImageClickEventArgs e)
    {
        Result.InnerText = "You clicked at (" + e.X.ToString() +", " + e.Y.ToString() + "). ";
        if ((e.Y < 100) && (e.Y > 20) && (e.X > 20) && (e.X < 275))
        {
            Result.InnerText += "You clicked on the button surface.";
        }
        else
        {
            Result.InnerText += "You clicked the button border.";
        }
    }

}
