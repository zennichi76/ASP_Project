using EADP_Project.Entities;
using EADP_Project_Education.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project
{
    public partial class PurchaseHistory : System.Web.UI.Page
    {
        string current_logged_in_user;
        protected void Page_Load(object sender, EventArgs e)
        {
            current_logged_in_user = Request.Cookies["CurrentLoggedInUser"].Value;
            List<PurchasedItem> itemsList = new List<PurchasedItem>();
            Bookstore_BO bookstorebo = new Bookstore_BO();
            itemsList = bookstorebo.purchaseHistory(current_logged_in_user);
            receiptPanel.Visible = false;
            if (itemsList == null || itemsList.Count == 0)
            {
                ErrorMsgGridView.Visible = true;

            }
            else
            {
                itemsList.Reverse();
                PurchaseHistoryGridView.DataSource = itemsList;
                PurchaseHistoryGridView.DataBind();
                ErrorMsgGridView.Visible = false;

            }
        }

        protected void PurchaseHistoryGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List<PurchasedItem> itemsList = new List<PurchasedItem>();
            Bookstore_BO bookstorebo = new Bookstore_BO();
            itemsList = bookstorebo.purchaseHistory(current_logged_in_user);
            itemsList.Reverse();
            PurchaseHistoryGridView.DataSource = itemsList;
            PurchaseHistoryGridView.PageIndex = e.NewPageIndex;
            PurchaseHistoryGridView.DataBind();
        }

        protected void PurchaseHistoryGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            

        }

        protected void PurchaseHistoryGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            receiptPanel.Visible = true;
            GridViewRow row = PurchaseHistoryGridView.SelectedRow;
            ReceiptNoLB.Text = row.Cells[0].Text;
            ItemsLB.Text = row.Cells[1].Text;
            PriceLB.Text = row.Cells[2].Text;
            DateLB.Text = row.Cells[3].Text;
        }
    }
}