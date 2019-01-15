using EADP_Project.BO;
using EADP_Project.Entities;
using EADP_Project_Education.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project_Education
{
    public partial class Bookstore : System.Web.UI.Page , IHttpModule
    {
        private StreamWriter sw;
       
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (new EventHandler(this.Application_BeginRequest));
        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {
            if (!File.Exists(@"C:\Users\Yun\Desktop\ASP_Project\ASP_Project\EADP_Project\App_Data\logger.txt"))
            {
                //sw = new StreamWriter(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\App_Data\logger.txt");
                sw = new StreamWriter(@"C:\Users\Yun\Desktop\ASP_Project\ASP_Project\EADP_Project\App_Data\logger.txt");
            }
            else
            {
                sw = File.AppendText(@"C:\Users\Yun\Desktop\ASP_Project\ASP_Project\EADP_Project\App_Data\logger.txt");
            }
            string ip = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.GetValue(1).ToString();
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            path = path.Substring(1);
            sw.WriteLine(ip + " sends request at {0} while accessing page " + path, DateTime.Now);
            sw.Close();
        }

        Bookstore_BO bookstorebo = new Bookstore_BO();
        private String current_logged_in_user;
        private user current_user_obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            current_logged_in_user = Request.Cookies["CurrentLoggedInUser"].Value;

            UserBO userbo = new UserBO();
            current_user_obj = userbo.getUserById(current_logged_in_user);
            GridView1.DataSource = bookstorebo.GridViewTable();
            GridView1.DataBind();

            if (current_user_obj.role == "Staff")
            {
                HL_StaffCorner.Visible = true;
            }
            else
            {
                HL_StaffCorner.Visible = false;
            }
        }

        protected void ddl_EduLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string EduLevel = ddl_EduLevel.SelectedItem.ToString();
            if (EduLevel == "Any")
            {
                GridView1.DataSource = bookstorebo.filterEdulvlAny(EduLevel);
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = bookstorebo.filterEdulvl(EduLevel);
                GridView1.DataBind();
            }
        }

        protected void ddl_ItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = ddl_ItemType.SelectedItem.ToString();
            if (type == "Any")
            {
                GridView1.DataSource = bookstorebo.filterTypeAny(type);
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = bookstorebo.filterType(type);
                GridView1.DataBind();
            }
            
        }

        protected void ddl_Sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string order = ddl_Sort.SelectedValue;
            if (order == "1")
            {
                GridView1.DataSource = bookstorebo.sortByAlphabet();
                GridView1.DataBind();
            }
            else if (order == "2")
            {
                GridView1.DataSource = bookstorebo.sortByPriceLH();
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = bookstorebo.sortByPriceHL();
                GridView1.DataBind();
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            string searchItem = TB_Search.Text;
            GridView1.DataSource = bookstorebo.searchForProduct(searchItem);
            GridView1.DataBind();
        }

        public static string productId;
        public int productIdQuantity;
        public void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_Item.Text = GridView1.SelectedRow.Cells[2].Text;
            PanelQuantity.Visible = true;
        }

        public string ImageURL, NAME;
        public decimal PRICE;
        int Quantity;
        protected void btn_AddCart_Click(object sender, EventArgs e)
        {
            Bookstore_BO bookstorebo = new Bookstore_BO();
            productId = bookstorebo.retrieveProductId(lbl_Item.Text).ToString();
            int OldQuantity = Convert.ToInt32(bookstorebo.retrieveProductQuantity(Convert.ToInt32(productId)));
            int NewQuantity = OldQuantity - Convert.ToInt32(TB_Quantity.Text);
            if(NewQuantity >= 0)
            {
                int IdExist = Convert.ToInt32(bookstorebo.retrieveProductIdFromCart(Convert.ToInt32(productId)));
                if(IdExist > 0)
                {
                    bookstorebo.updateQuantityInCartDB(Convert.ToInt32(productId), Convert.ToInt32(TB_Quantity.Text));
                }
                else
                {
                    ImageURL = bookstorebo.retrieveImageString(Convert.ToInt32(productId));
                    NAME = GridView1.SelectedRow.Cells[2].Text.ToString();
                    PRICE = Convert.ToDecimal(GridView1.SelectedRow.Cells[3].Text);
                    Quantity = Convert.ToInt32(TB_Quantity.Text.Trim());
                    bookstorebo.AddProduct(Convert.ToInt32(productId), ImageURL, NAME, PRICE, Quantity);

                }

            }
            else
            {
                lbl_Error.Visible = true;
            }

            
            lbl_Item.Text = "";
            TB_Quantity.Text = "";
            lbl_Success.Visible = true;
        }
    }
}