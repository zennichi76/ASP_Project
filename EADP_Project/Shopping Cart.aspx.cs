using EADP_Project_Education.BO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project_Education
{
    public partial class Shopping_Cart : System.Web.UI.Page
    {
        Bookstore_BO bookstorebo = new Bookstore_BO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridViewCart.DataSource = bookstorebo.GridViewTableSC();
                GridViewCart.DataBind();
            }
        }


        protected void btn_pay_Click(object sender, EventArgs e)
        {
            PanelPaymentSelection.Visible = true;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DropDownList1.SelectedValue) == 1)
            {
                Panel_Entry.Visible = true;
                Panel_Cash.Visible = false;
            }
            else if (Convert.ToInt32(DropDownList1.SelectedValue) == 2)
            {
                Panel_Cash.Visible = true;
                Panel_Entry.Visible = false;
                PanelCartDisplay.Visible = false;
                PanelPaymentSelection.Visible = false;

                Random rnd = new Random();
                int receiptNum = rnd.Next(100000, 999999);

                lbl_ReceiptNum.Text = receiptNum.ToString();
                lbl_ItemList.Text = bookstorebo.retrieveProductFromCart();
                lbl_Cost.Text = bookstorebo.retrieveProductCostForCart();
                lbl_PurchaseDate.Text = DateTime.Now.ToString("dd MMMM yyyy hh:mm tt");
            }
            else if (Convert.ToInt32(DropDownList1.SelectedValue) == 0)
            {
                Panel_Entry.Visible = false;

            }
        }



        protected void TB_CardNum_TextChanged(object sender, EventArgs e)
        { 
            if (TB_CardNum.Text.StartsWith("4") && TB_CardNum.Text.Length == 16)
            {
                ImageCardType.ImageUrl = "~/img/visa.png";
            }
            else if (TB_CardNum.Text.StartsWith("5") && TB_CardNum.Text.Length == 16)
            {
                ImageCardType.ImageUrl = "~/img/MasterCard_Logo.svg.png";
            }
        }

        protected void btn_Proceed_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            if(TB_CardNum.Text == "")
            {
                count++;
                sb.AppendLine("Ensure that your credit card number is filled in");
            }
            if (TB_CardCVV.Text == "")
            {
                count++;
                sb.AppendLine("Ensure that your CVV number is filled in");
            }
            if (TB_CardDate.Text == "")
            {
                count++;
                sb.AppendLine("Ensure that your credit card expiry date is filled in");
            }
            if (TB_CardName.Text == "")
            {
                count++;
                sb.AppendLine("Ensure that your name is filled in");
            }
            
            if(count > 0)
            {
                TB_ErrorCard.Visible = true;
                TB_ErrorCard.Text = sb.ToString();
            }
            else
            {
                Panel_Cash.Visible = true;
                Panel_Entry.Visible = false;
                PanelCartDisplay.Visible = false;
                PanelPaymentSelection.Visible = false;

                Random rnd = new Random();
                int receiptNum = rnd.Next(100000, 999999);

                lbl_ReceiptNum.Text = receiptNum.ToString();
                lbl_ItemList.Text = bookstorebo.retrieveProductFromCart();
                lbl_Cost.Text = bookstorebo.retrieveProductCostForCart();
                lbl_PurchaseDate.Text = DateTime.Now.ToString("dd MMMM yyyy hh:mm tt");
            }
        }

        protected void btn_Done_Click(object sender, EventArgs e)
        {
            string User_ID = Request.Cookies["CurrentLoggedInUser"].Value;
            bookstorebo.uploadToHistory(User_ID, lbl_ReceiptNum.Text, lbl_ItemList.Text, Convert.ToDecimal(lbl_Cost.Text), lbl_PurchaseDate.Text);

            bookstorebo.deleteAllFromCart();
            Response.Redirect("Shopping Cart.aspx");
        }

        protected void GridViewCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            bookstorebo.deleteProductFromCart(GridViewCart.SelectedRow.Cells[2].Text);
            Response.Redirect("Shopping Cart.aspx");
        }
    }
}