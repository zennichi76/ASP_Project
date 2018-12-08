using EADP_Project_Education.BO;
using EADP_Project_Education.DAO;
using EADP_Project_Education.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project_Education
{
    public partial class StaffCorner : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
                if (PanelCreate.Visible == true)
                {
                    PanelCreate.Visible = false;
                }
                else
                {
                    PanelCreate.Visible = true;
                    PanelDelete.Visible = false;
                    PanelUpdate.Visible = false;

                    //ensure clean
                    FileUploadImage.Attributes.Clear();
                    TB_ID_Add.Text = "";
                    TB_Name_Add.Text = "";
                    TB_Price_Add.Text = "";
                    Ddl_Edu_Add.SelectedValue = "-1";
                    Ddl_Item_Add.SelectedValue = "-1";
                    TB_Quantity_Add.Text = "";
                    lbl_Message.Visible = false;
                    lbl_Message.Text = "";
                    TB_Error_Add.Text = "";
                    TB_Error_Add.Visible = false;
                }

        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (PanelUpdate.Visible == true)
            {
                PanelUpdate.Visible = false;
            }
            else
            {
                PanelCreate.Visible = false;
                PanelDelete.Visible = false;
                PanelUpdate.Visible = true;

                //ensure clean
                FileUploadImage_Update.Attributes.Clear();
                TB_ID_Update.Text = "";
                TB_Name_Update.Text = "";
                TB_Price_Update.Text = "";
                Ddl_Edu_Update.SelectedValue = "-1";
                Ddl_Item_Update.SelectedValue = "-1";
                TB_Quantity_Update.Text = "";
                lbl_Message1.Visible = false;
                lbl_Message1.Text = "";
                TB_Error_Update.Text = "";
                TB_Error_Update.Visible = false;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (PanelDelete.Visible == true)
            {
                PanelDelete.Visible = false;
            }
            else
            {
                PanelCreate.Visible = false;
                PanelDelete.Visible = true;
                PanelUpdate.Visible = false;

                //ensure clean
                TB_ID_Delete.Text = "";
                lbl_Message2.Visible = false;
                lbl_Message2.Text = "";
                TB_Error_Delete.Text = "";
                TB_Error_Delete.Visible = false;
            }
        }

        protected void btn_Submit_Add_Click(object sender, EventArgs e)
        {
            Bookstore_BO bookstorebo = new Bookstore_BO();
            int ProductId = Convert.ToInt32(TB_ID_Add.Text);
            bookstorebo.retrieveProduct(ProductId);

            Product prodObj = bookstorebo.retrieveProduct(ProductId);
            
            if (prodObj != null)
            {
                TB_Error_Add.Text = "Product already exist, consider updating instead";
                TB_Error_Add.Visible = true;
            }
            else
            {
                {
                    int count = 0;
                    //validate file upload
                    string filename;
                    if (FileUploadImage.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(FileUploadImage.FileName);
                        if (extension == ".jpg" || extension == ".png")
                        {
                            filename = FileUploadImage.FileName;
                            FileUploadImage.PostedFile.SaveAs(Server.MapPath("~/Image/") + filename);
                            string ImageURL = "~/Image/" + filename;
                            lbl_Image_Name.Text = ImageURL;
                            //codes to send to BO
                        }
                        else
                        {
                            sb.AppendLine("File has to be .jpg or .png only");
                            count++;
                        }
                    }
                    else
                    {
                        sb.AppendLine("Please upload an image");
                        count++;
                    }

                    //validate ID Textbox
                    if (TB_ID_Add.Text.Trim() == "")
                    {
                        sb.AppendLine("Please indicate product ID");
                        count++;
                    }
                    else if (System.Text.RegularExpressions.Regex.IsMatch(TB_ID_Update.Text, " ^ [0-9]"))
                    {
                        sb.AppendLine("Please enter valid product ID");
                        count++;
                    }

                    //validate Name Textbox
                    if (TB_Name_Add.Text.Trim() == "")
                    {
                        sb.AppendLine("Please indicate product name");
                        count++;
                    }

                    //validate Price Textbox
                    if (TB_Price_Add.Text.Trim() == "" || TB_Price_Add.Text.All(Char.IsLetter))
                    {
                        sb.AppendLine("Please amend product price");
                        count++;
                    }

                    //validate Education DDL
                    if (Ddl_Edu_Add.SelectedItem.Text == "~Education Level~")
                    {
                        sb.AppendLine("Please indicate Education Level of product");
                        count++;
                    }

                    //validate Item DDL
                    if (Ddl_Item_Add.SelectedItem.Text == "~Item Type~")
                    {
                        sb.AppendLine("Please indicate product type");
                        count++;
                    }

                    //validate Quantity
                    if (TB_Quantity_Add.Text == "")
                    {
                        sb.AppendLine("Please enter available quantity of product");
                        count++;
                    }

                    if (count > 0)
                    {
                        lbl_Message.Text = "";
                        TB_Error_Add.Visible = true;
                        TB_Error_Add.Text = sb.ToString();
                    }
                    else
                    {
                        //codes to send to database

                        bookstorebo.uploadProduct(TB_ID_Add.Text, lbl_Image_Name.Text, TB_Name_Add.Text, Convert.ToDouble(TB_Price_Add.Text), Ddl_Edu_Add.SelectedItem.Text, Ddl_Item_Add.SelectedItem.Text, Convert.ToInt32(TB_Quantity_Add.Text), lbl_Any.Text, lbl_AnyType.Text);
                        FileUploadImage.Attributes.Clear();
                        TB_ID_Add.Text = "";
                        TB_Name_Add.Text = "";
                        TB_Price_Add.Text = "";
                        Ddl_Edu_Add.SelectedIndex = -1;
                        Ddl_Item_Add.SelectedIndex = -1;
                        TB_Quantity_Add.Text = "";
                        lbl_Message.Visible = true;
                        lbl_Message.Text = "Product has been added successfully!";
                        TB_Error_Add.Text = "";
                        TB_Error_Add.Visible = false;
                    }
                }
            }
        }

        protected void btn_image_change_update_Click(object sender, EventArgs e)
        {
            FileUploadImage_Update.Visible = true;
            btn_image_change_update.Visible = false;
            btn_image_cancel_update.Visible = true;
        }

        protected void btn_image_cancel_update_Click(object sender, EventArgs e)
        {
            FileUploadImage_Update.Visible = false;
            btn_image_change_update.Visible = true;
            btn_image_cancel_update.Visible = false;
        }

        protected void btn_ID_search_Click(object sender, EventArgs e)
        {
            if (TB_ID_Update.Text == "")
            {
                TB_Error_Update.Visible = true;
                TB_Error_Update.Text = "Please input product's ID";
            }
            else if (Regex.Matches(TB_ID_Update.Text, @"[a-zA-Z]").Count > 0)
            {
                TB_Error_Update.Visible = true;
                TB_Error_Update.Text = "Please input valid product ID";
            }
            else
            {
                //retrieve data from database
                Bookstore_BO bookstorebo = new Bookstore_BO();
                int ProductId = Convert.ToInt32(TB_ID_Update.Text);
                bookstorebo.retrieveProduct(ProductId);
                FileUploadImage_Update.Attributes.Clear();

                Product prodObj = bookstorebo.retrieveProduct(ProductId);

                try {
                    lbl_Image_Name1.Text = prodObj.ImageURL.ToString();
                    TB_Name_Update.Text = prodObj.Name;
                    TB_Price_Update.Text = prodObj.Price.ToString();
                    if (prodObj.EduLevel.ToString() == "Any")
                    {
                        Ddl_Edu_Update.SelectedIndex = 1;
                    }
                    else if (prodObj.EduLevel.ToString() == "Primary")
                    {
                        Ddl_Edu_Update.SelectedIndex = 2;
                    }
                    else if (prodObj.EduLevel.ToString() == "Secondary")
                    {
                        Ddl_Edu_Update.SelectedIndex = 3;
                    }
                    else
                    {
                        Ddl_Edu_Update.SelectedIndex = 4;
                    }

                    if (prodObj.Type.ToString() == "Textbooks")
                    {
                        Ddl_Item_Update.SelectedIndex = 1;
                    }
                    else if (prodObj.Type.ToString() == "Stationary")
                    {
                        Ddl_Item_Update.SelectedIndex = 2;
                    }
                    else
                    {
                        Ddl_Item_Update.SelectedIndex = 3;
                    }
                    TB_Quantity_Update.Text = prodObj.Quantity.ToString();
                    TB_Error_Update.Text = "";
                    TB_Error_Update.Visible = false;
                }
                catch
                {
                    TB_Error_Update.Text = "Product ID does no exist in database";
                    TB_Error_Update.Visible = true;
                }
            }
            
        }

        protected void btn_Submit_Update_Click(object sender, EventArgs e)
        {
            Bookstore_BO bookstorebo = new Bookstore_BO();
            int ProductId = Convert.ToInt32(TB_ID_Update.Text);
            bookstorebo.retrieveProduct(ProductId);
            Product prodObj = bookstorebo.retrieveProduct(ProductId);

            int count = 0;
            //validate file upload
            string filename;
            if (FileUploadImage_Update.Visible == true)
            {
                if (FileUploadImage_Update.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(FileUploadImage_Update.FileName);
                    if (extension == ".jpg" || extension == ".png")
                    {
                        filename = FileUploadImage_Update.FileName;
                        FileUploadImage_Update.PostedFile.SaveAs(Server.MapPath("~/Image/") + filename);
                        string ImageURL = "~/Image/" + filename;
                        lbl_Image_Name1.Text = ImageURL;
                    }
                    else
                    {
                        Response.Write("File has to be a jpg or png file");
                    }
                }
                else
                {
                    sb.AppendLine("Please upload an image");
                    count++;
                }
            }
            else
            {
                filename = prodObj.ImageURL.ToString();
                filename = filename.Substring(8);
                FileUploadImage_Update.SaveAs(Server.MapPath("~/Image/") + filename);
                lbl_Image_Name.Text = filename;
            }

            //validate ID Textbox
            if (TB_ID_Update.Text.Trim() == "")
            {
                sb.AppendLine("Please indicate product ID");
                count++;
            }

            //validate Name Textbox
            if (TB_Name_Update.Text.Trim() == "")
            {
                sb.AppendLine("Please indicate product name");
                count++;
            }

            //validate Price Textbox
            if (TB_Price_Update.Text == "" || TB_Price_Update.Text.All(Char.IsLetter))
            {
                sb.AppendLine("Please amend product price");
                count++;
            }

            //validate Education DDL
            if (Ddl_Edu_Update.SelectedItem.Text == "~Education Level~")
            {
                sb.AppendLine("Please indicate Education Level of product");
                count++;
            }

            //validate Item DDL
            if (Ddl_Item_Update.SelectedItem.Text == "~Item Type~")
            {
                sb.AppendLine("Please indicate product type");
                count++;
            }

            //validate Quantity
            if (TB_Quantity_Update.Text == "")
            {
                sb.AppendLine("Please enter available quantity of product");
                count++;
            }

            if (count > 0)
            {
                lbl_Message1.Text = "";
                TB_Error_Update.Visible = true;
                TB_Error_Update.Text = sb.ToString();
            }
            else
            {
                //update database
                bookstorebo.updateProduct(TB_ID_Update.Text, lbl_Image_Name1.Text, TB_Name_Update.Text, Convert.ToDouble(TB_Price_Update.Text), Ddl_Edu_Update.SelectedItem.Text, Ddl_Item_Update.SelectedItem.Text, Convert.ToInt32(TB_Quantity_Update.Text));
                FileUploadImage_Update.Attributes.Clear();
                TB_ID_Update.Text = "";
                TB_Name_Update.Text = "";
                TB_Price_Update.Text = "";
                Ddl_Edu_Add.SelectedIndex = -1;
                Ddl_Item_Add.SelectedIndex = -1;
                TB_Quantity_Update.Text = "";
                lbl_Message1.Visible = true;
                lbl_Message1.Text = "Product has been updated successfully!";
                TB_Error_Update.Text = "";
                TB_Error_Update.Visible = false;
            }

        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            if (TB_ID_Delete.Text == "")
            {
                TB_Error_Delete.Text = "Please Enter a product ID";
                TB_Error_Delete.Visible = true;
            }
            else
            {

                //delete product
                Bookstore_BO bookstorebo = new Bookstore_BO();
                bookstorebo.deleteProduct(TB_ID_Delete.Text);
                TB_ID_Delete.Text = "";
                lbl_Message2.Visible = true;
                lbl_Message2.Text = "Product has been deleted successfully!";
                TB_Error_Delete.Text = "";
                TB_Error_Delete.Visible = false;
            }
        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            FileUploadImage.Attributes.Clear();
            TB_ID_Add.Text = "";
            TB_Name_Add.Text = "";
            TB_Price_Add.Text = "";
            TB_ID_Update.Text = "";
            TB_Name_Update.Text = "";
            TB_Price_Update.Text = "";
            TB_Error_Add.Text = "";
            TB_Error_Add.Visible = false;
            TB_Error_Update.Text = "";
            TB_Error_Update.Visible = false;
            TB_Error_Delete.Text = "";
            TB_Error_Delete.Visible = false;
            lbl_Message.Visible = false;
        }

       
    }
}