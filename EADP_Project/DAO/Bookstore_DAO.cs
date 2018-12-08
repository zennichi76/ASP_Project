using EADP_Project.Entities;
using EADP_Project_Education.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace EADP_Project_Education.DAO
{
    public class Bookstore_DAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public List<Product> DataGridViewRetrieve()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            List<Product> DataGridList = new List<Product>();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT ImageURL, NAME, PRICE FROM Products ");

            SqlConnection myConn = new SqlConnection(DBConnect);

            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            da.Fill(ds, "GridView1");

            int rec_cnt = ds.Tables["GridView1"].Rows.Count;
            if (rec_cnt == 0)
            {
                DataGridList = null;
            }
            else
            {

                foreach (DataRow row in ds.Tables["GridView1"].Rows)
                {
                    Product objGrid = new Product();
                    objGrid.ImageURL = (row["ImageURL"]).ToString();
                    objGrid.Name = (row["NAME"]).ToString();
                    objGrid.Price = Convert.ToDecimal(row["PRICE"]);
                    DataGridList.Add(objGrid);
                }
            }
            return DataGridList;
        }

        public List<Product> DataGridViewRetrieveForCart()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            List<Product> DataGridList = new List<Product>();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT ImageURL, NAME, PRICE, Quantity FROM ShoppingCart ");

            SqlConnection myConn = new SqlConnection(DBConnect);

            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            da.Fill(ds, "GridViewCart");

            int rec_cnt = ds.Tables["GridViewCart"].Rows.Count;
            if (rec_cnt == 0)
            {
                DataGridList = null;
            }
            else
            {

                foreach (DataRow row in ds.Tables["GridViewCart"].Rows)
                {
                    Product objGrid = new Product();
                    objGrid.ImageURL = (row["ImageURL"]).ToString();
                    objGrid.Name = (row["NAME"]).ToString();
                    objGrid.Price = Convert.ToDecimal(row["PRICE"]);
                    objGrid.Quantity = Convert.ToInt32(row["Quantity"]);
                    DataGridList.Add(objGrid);
                }
            }
            return DataGridList;
        }

        public List<Product> filterEdulvlAnyProductInDB(String EduLevelAny)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            List<Product> DataGridList = new List<Product>();
            SqlCommand sqlCommand = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT ImageURL, NAME, PRICE FROM Products ");
            str.AppendLine("WHERE EduLevelAny = @paraEduLevelAny");

            SqlConnection myConn = new SqlConnection(DBConnect);

            da = new SqlDataAdapter(str.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEduLevelAny", EduLevelAny);

            da.Fill(ds, "GridView1");

            int count = ds.Tables["GridView1"].Rows.Count;
            if (count == 0)
            {
                DataGridList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables["GridView1"].Rows)
                {
                    Product objGrid = new Product();
                    objGrid.ImageURL = (row["ImageURL"]).ToString();
                    objGrid.Name = (row["NAME"]).ToString();
                    objGrid.Price = Convert.ToDecimal(row["PRICE"]);
                    DataGridList.Add(objGrid);
                }
            }
            return DataGridList;
        }

        public List<Product> filterEdulvlProductInDB(String EduLevel)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            List<Product> DataGridList = new List<Product>();
            SqlCommand sqlCommand = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT ImageURL, NAME, PRICE FROM Products ");
            str.AppendLine("WHERE EduLevel = @paraEduLevel");

            SqlConnection myConn = new SqlConnection(DBConnect);

            da = new SqlDataAdapter(str.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEduLevel", EduLevel);

            da.Fill(ds, "GridView1");

            int count = ds.Tables["GridView1"].Rows.Count;
            if (count == 0)
            {
                DataGridList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables["GridView1"].Rows)
                {
                    Product objGrid = new Product();
                    objGrid.ImageURL = (row["ImageURL"]).ToString();
                    objGrid.Name = (row["NAME"]).ToString();
                    objGrid.Price = Convert.ToDecimal(row["PRICE"]);
                    DataGridList.Add(objGrid);
                }
            }
            return DataGridList;
        }

        public List<Product> filterTypeAnyProductInDB(String TypeAny)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            List<Product> DataGridList = new List<Product>();
            SqlCommand sqlCommand = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT ImageURL, NAME, PRICE FROM Products ");
            str.AppendLine("WHERE TypeAny = @paraTypeAny");

            SqlConnection myConn = new SqlConnection(DBConnect);

            da = new SqlDataAdapter(str.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraTypeAny", TypeAny);

            da.Fill(ds, "GridView1");

            int count = ds.Tables["GridView1"].Rows.Count;
            if (count == 0)
            {
                DataGridList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables["GridView1"].Rows)
                {
                    Product objGrid = new Product();
                    objGrid.ImageURL = (row["ImageURL"]).ToString();
                    objGrid.Name = (row["NAME"]).ToString();
                    objGrid.Price = Convert.ToDecimal(row["PRICE"]);
                    DataGridList.Add(objGrid);
                }
            }
            return DataGridList;
        }

        public List<Product> filterTypeProductInDB(String Type)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            List<Product> DataGridList = new List<Product>();
            SqlCommand sqlCommand = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT ImageURL, NAME, PRICE FROM Products ");
            str.AppendLine("WHERE Type = @paraType");

            SqlConnection myConn = new SqlConnection(DBConnect);

            da = new SqlDataAdapter(str.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraType", Type);

            da.Fill(ds, "GridView1");

            int count = ds.Tables["GridView1"].Rows.Count;
            if (count == 0)
            {
                DataGridList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables["GridView1"].Rows)
                {
                    Product objGrid = new Product();
                    objGrid.ImageURL = (row["ImageURL"]).ToString();
                    objGrid.Name = (row["NAME"]).ToString();
                    objGrid.Price = Convert.ToDecimal(row["PRICE"]);
                    DataGridList.Add(objGrid);
                }
            }
            return DataGridList;
        }

        public List<Product> SortByAlphabet()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            List<Product> DataGridList = new List<Product>();
            SqlCommand sqlCommand = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT * FROM Products ");
            str.AppendLine("ORDER BY NAME ASC");

            SqlConnection myConn = new SqlConnection(DBConnect);

            da = new SqlDataAdapter(str.ToString(), myConn);
            da.Fill(ds, "GridView1");

            int count = ds.Tables["GridView1"].Rows.Count;
            if (count == 0)
            {
                DataGridList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables["GridView1"].Rows)
                {
                    Product objGrid = new Product();
                    objGrid.ImageURL = (row["ImageURL"]).ToString();
                    objGrid.Name = (row["NAME"]).ToString();
                    objGrid.Price = Convert.ToDecimal(row["PRICE"]);
                    DataGridList.Add(objGrid);
                }
            }
            return DataGridList;
        }

        public List<Product> SortByPriceLH()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            List<Product> DataGridList = new List<Product>();
            SqlCommand sqlCommand = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT * FROM Products ");
            str.AppendLine("ORDER BY PRICE ASC");

            SqlConnection myConn = new SqlConnection(DBConnect);

            da = new SqlDataAdapter(str.ToString(), myConn);
            da.Fill(ds, "GridView1");

            int count = ds.Tables["GridView1"].Rows.Count;
            if (count == 0)
            {
                DataGridList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables["GridView1"].Rows)
                {
                    Product objGrid = new Product();
                    objGrid.ImageURL = (row["ImageURL"]).ToString();
                    objGrid.Name = (row["NAME"]).ToString();
                    objGrid.Price = Convert.ToDecimal(row["PRICE"]);
                    DataGridList.Add(objGrid);
                }
            }
            return DataGridList;
        }

        public List<Product> SortByPriceHL()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            List<Product> DataGridList = new List<Product>();
            SqlCommand sqlCommand = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT * FROM Products ");
            str.AppendLine("ORDER BY PRICE DESC");

            SqlConnection myConn = new SqlConnection(DBConnect);

            da = new SqlDataAdapter(str.ToString(), myConn);
            da.Fill(ds, "GridView1");

            int count = ds.Tables["GridView1"].Rows.Count;
            if (count == 0)
            {
                DataGridList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables["GridView1"].Rows)
                {
                    Product objGrid = new Product();
                    objGrid.ImageURL = (row["ImageURL"]).ToString();
                    objGrid.Name = (row["NAME"]).ToString();
                    objGrid.Price = Convert.ToDecimal(row["PRICE"]);
                    DataGridList.Add(objGrid);
                }
            }
            return DataGridList;
        }

        public List<Product> SearchForProduct(String searchItem)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            List<Product> DataGridList = new List<Product>();
            SqlCommand sqlCommand = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT * FROM Products");
            str.AppendLine("WHERE NAME LIKE '%" + searchItem + "%'");

            SqlConnection myConn = new SqlConnection(DBConnect);

            da = new SqlDataAdapter(str.ToString(), myConn);
            da.Fill(ds, "GridView1");

            int count = ds.Tables["GridView1"].Rows.Count;
            if (count == 0)
            {
                DataGridList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables["GridView1"].Rows)
                {
                    Product objGrid = new Product();
                    objGrid.ImageURL = (row["ImageURL"]).ToString();
                    objGrid.Name = (row["NAME"]).ToString();
                    objGrid.Price = Convert.ToDecimal(row["PRICE"]);
                    DataGridList.Add(objGrid);
                }
            }
            return DataGridList;
        }

        public int uploadProductToDB(String productId, String ImageURL, String NAME, Double PRICE, String EduLevel, String Type, int Quantity, String Any, String TypeAny)
        {
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("INSERT INTO Products (ProductId,ImageURL,NAME,PRICE,EduLevel,Type,Quantity,EduLevelAny, TypeAny)");
            sqlStr.AppendLine("VALUES (@paraProductId, @paraImageURL, @paraNAME, @paraPRICE, @paraEduLevel, @paraType, @paraQuantity, @paraEduLevelAny, @paraTypeAny)");


            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraProductId", productId);
            sqlCmd.Parameters.AddWithValue("@paraImageURL", ImageURL);
            sqlCmd.Parameters.AddWithValue("@paraNAME", NAME);
            sqlCmd.Parameters.AddWithValue("@paraPRICE", PRICE);
            sqlCmd.Parameters.AddWithValue("@paraEduLevel", EduLevel);
            sqlCmd.Parameters.AddWithValue("@paraType", Type);
            sqlCmd.Parameters.AddWithValue("@paraEduLevelAny", Any);
            sqlCmd.Parameters.AddWithValue("@paraTypeAny", TypeAny);
            sqlCmd.Parameters.AddWithValue("@paraQuantity", Quantity);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }

        public Product RetrieveProductFromDB(int ProductId)
        {

            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            Product prod = new Product();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * FROM Products");
            sqlStr.AppendLine("WHERE ProductId = @paraProductId");

            da = new SqlDataAdapter(sqlStr.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraProductId", ProductId);
            da.Fill(ds, "UpdateTable");

            int count = ds.Tables["UpdateTable"].Rows.Count;
            if (count == 0)
            {
                prod = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables["UpdateTable"].Rows)
                {
                    prod.ProductId = Convert.ToInt32(row["ProductId"]);
                    prod.ImageURL = (row["ImageURL"]).ToString();
                    prod.Name = (row["NAME"]).ToString();
                    prod.Price = Convert.ToDecimal(row["PRICE"]);
                    prod.EduLevel = (row["EduLevel"]).ToString();
                    prod.Type = (row["Type"]).ToString();
                    prod.Quantity = Convert.ToInt32(row["Quantity"]);
                }
            }

            return prod;

        }

        public int EditProductToDB(String productId, String ImageURL, String NAME, Double PRICE, String EduLevel, String Type, int Quantity)
        {
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("UPDATE Products SET ProductId = @paraProductId ,ImageURL = @paraImageURL,NAME = @paraNAME,PRICE = @paraPRICE,EduLevel = @paraEduLevel, Type = @paraType, Quantity = @paraQuantity");
            sqlStr.AppendLine("WHERE ProductId = @paraProductId");

            string x = sqlStr.ToString();

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraProductId", productId);
            sqlCmd.Parameters.AddWithValue("@paraImageURL", ImageURL);
            sqlCmd.Parameters.AddWithValue("@paraNAME", NAME);
            sqlCmd.Parameters.AddWithValue("@paraPRICE", PRICE);
            sqlCmd.Parameters.AddWithValue("@paraEduLevel", EduLevel);
            sqlCmd.Parameters.AddWithValue("@paraType", Type);
            sqlCmd.Parameters.AddWithValue("@paraQuantity", Quantity);

            myConn.Open();


            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }

        public int DeleteProductToDB(String productId)
        {
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("DELETE FROM Products");
            sqlStr.AppendLine("WHERE ProductId = @paraProductId");

            string x = sqlStr.ToString();

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraProductId", productId);


            myConn.Open();

            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }

        public int RetrieveProductIdFromDB(String NAME)
        {
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("SELECT ProductId FROM Products");
            sqlStr.AppendLine("WHERE NAME = @paraNAME");

            string x = sqlStr.ToString();

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraNAME", NAME);


            myConn.Open();

            result = sqlCmd.ExecuteNonQuery();
            SqlDataReader dr = sqlCmd.ExecuteReader();
            while (dr.Read())
            {
                Bookstore.productId = dr["ProductId"].ToString();
            }
            myConn.Close();
            Product prodObj = new Product();
            prodObj.ProductId = Convert.ToInt32(Bookstore.productId);

            return prodObj.ProductId;

        }
        public int AddProductToCartDB(int ProductId, String ImageURL, String NAME, decimal PRICE, int Quantity)
        {
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("INSERT INTO ShoppingCart (ProductId, ImageURL,NAME,PRICE,Quantity)");
            sqlStr.AppendLine("VALUES (@paraProductId, @paraImageURL, @paraNAME, @paraPRICE, @paraQuantity)");


            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraProductId", ProductId);
            sqlCmd.Parameters.AddWithValue("@paraImageURL", ImageURL);
            sqlCmd.Parameters.AddWithValue("@paraNAME", NAME);
            sqlCmd.Parameters.AddWithValue("@paraPRICE", PRICE);
            sqlCmd.Parameters.AddWithValue("@paraQuantity", Quantity);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }

        public int retrieveQuantityFromDB(int productId)
        {
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("SELECT Quantity FROM Products");
            sqlStr.AppendLine("WHERE productId = @paraProductId");

            string x = sqlStr.ToString();

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraProductId", productId);


            myConn.Open();

            result = sqlCmd.ExecuteNonQuery();
            SqlDataReader dr = sqlCmd.ExecuteReader();
            int Quantity = 0;
            while (dr.Read())
            {
                Quantity = Convert.ToInt32(dr["Quantity"]);
            }
            myConn.Close();

            return Quantity;

        }

        public int retrieveIdFromCartDB(int productId)
        {
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("SELECT COUNT(*) FROM ShoppingCart");
            sqlStr.AppendLine("WHERE productId = @paraProductId");

            string x = sqlStr.ToString();

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraProductId", productId);


            myConn.Open();

            result = sqlCmd.ExecuteNonQuery();
            result = Convert.ToInt32(sqlCmd.ExecuteScalar());
            myConn.Close();

            return result;
        }

        public int updateQuantityInCartDB(int productId, int Quantity)
        {
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("UPDATE ShoppingCart SET Quantity =  Quantity + @paraQuantity");
            sqlStr.AppendLine("WHERE productId = @paraProductId");


            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraProductId", productId);
            sqlCmd.Parameters.AddWithValue("@paraQuantity", Quantity);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }

        public string retrieveImageFromDB(int productId)
        {
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("SELECT ImageURL FROM Products");
            sqlStr.AppendLine("WHERE productId = @paraProductId");

            string x = sqlStr.ToString();

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraProductId", productId);


            myConn.Open();

            result = sqlCmd.ExecuteNonQuery();
            SqlDataReader dr = sqlCmd.ExecuteReader();
            string ImageURL = "";
            while (dr.Read())
            {
                ImageURL = dr["ImageURL"].ToString();
            }
            myConn.Close();

            return ImageURL;

        }

        public int updateQuantityFromDB(int productId, int Quantity)
        {
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("UPDATE Products SET Quantity = @paraQuantity");
            sqlStr.AppendLine("WHERE productId = @paraProductId");


            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraProductId", productId);
            sqlCmd.Parameters.AddWithValue("@paraQuantity", Quantity);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }

        public string retrieveProductFromCart()
        {

            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT NAME FROM ShoppingCart");

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            myConn.Open();

            int result;
            string NAME = null;
            result = sqlCmd.ExecuteNonQuery();
            SqlDataReader dr = sqlCmd.ExecuteReader();
            StringBuilder itemList = new StringBuilder();
            while (dr.Read())
            {
                NAME = dr["NAME"].ToString();
                
                itemList.Append(NAME.Trim() + " | ");
            }
            
            myConn.Close();

            return itemList.ToString();
        }

        public string retrieveProductCostFromCart()
        {

            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT PRICE, Quantity FROM ShoppingCart");

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            myConn.Open();

            decimal resultPrice = 0;
            int resultQuantity = 0;
            decimal PRICE = 0, Sum = 0;
            resultPrice = sqlCmd.ExecuteNonQuery();
            SqlDataReader dr = sqlCmd.ExecuteReader();
            while (dr.Read())
            {
                resultPrice = Convert.ToDecimal(dr["PRICE"]);
                resultQuantity = Convert.ToInt32(dr["Quantity"]);
                PRICE = resultPrice * resultQuantity;
                Sum += PRICE;
            }

            myConn.Close();

            return Sum.ToString();
        }

        public int DeleteProductFromDBCart(String NAME)
        {
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("DELETE FROM ShoppingCart");
            sqlStr.AppendLine("WHERE NAME = @paraNAME");

            string x = sqlStr.ToString();

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraNAME", NAME);


            myConn.Open();

            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }

        public int DeleteAllFromDBCart()
        {
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("DELETE FROM ShoppingCart");

            string x = sqlStr.ToString();

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            myConn.Open();

            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }

        // Study Guide
        public List<Schedule> RetrieveGridViewSchedule()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            List<Schedule> DataGridList = new List<Schedule>();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT Monday, Tueday, Wednesday, Thursday, Friday, Saturday, Sunday FROM Schedule ");

            SqlConnection myConn = new SqlConnection(DBConnect);

            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            da.Fill(ds, "GridViewSchedule");

            int rec_cnt = ds.Tables["GridViewSchedule"].Rows.Count;
            if (rec_cnt == 0)
            {
                DataGridList = null;
            }
            else
            {

                foreach (DataRow row in ds.Tables["GridViewSchedule"].Rows)
                {
                    Schedule objGrid = new Schedule();
                    objGrid.Monday = (row["Monday"]).ToString();
                    objGrid.Tuesday = (row["Tuesday"]).ToString();
                    objGrid.Wednesday = (row["Wednesday"]).ToString();
                    objGrid.Wednesday = (row["Thursday"]).ToString();
                    objGrid.Wednesday = (row["Friday"]).ToString();
                    objGrid.Wednesday = (row["Saturday"]).ToString();
                    objGrid.Wednesday = (row["Sunday"]).ToString();
                    DataGridList.Add(objGrid);
                }
            }
            return DataGridList;
        }

        public int UploadToHistory(string userId, string receiptNum, string itemList, decimal Price, string purchaseDate)
        {
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("INSERT INTO CartHistory (UserId, ReceiptId, Items, Price, PurchaseDate)");
            sqlStr.AppendLine("VALUES (@paraUserId, @paraReceiptId, @paraItems, @paraPrice, @paraPurchaseDate)");


            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraUserId", userId);
            sqlCmd.Parameters.AddWithValue("@paraReceiptId", receiptNum);
            sqlCmd.Parameters.AddWithValue("@paraItems", itemList);
            sqlCmd.Parameters.AddWithValue("@paraPrice", Price);
            sqlCmd.Parameters.AddWithValue("@paraPurchaseDate", purchaseDate);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }
        public List<PurchasedItem> purchaseHistory(string userID)
        {
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //make adapter
            SqlDataAdapter da;
            //make dataset to store results (ResultSet equivalent in Java) 
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from [CartHistory] where");
            sqlCommand.AppendLine("UserId = @paraUserId");

            List<PurchasedItem> objList = new List<PurchasedItem>();
            

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraUserId", userID);

            da.Fill(ds, "itemTable"); //Executes command and fills data set with the results
            int rec_cnt = ds.Tables["itemTable"].Rows.Count; //recordcount
            if (rec_cnt == 0) //no record has been found
            {
                //return a null object 
                objList = null;
            }
            else if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables["itemTable"].Rows[i]; //First record
                    PurchasedItem obj = new PurchasedItem();
                    obj.historyID = int.Parse(row["historyID"].ToString());
                    obj.UserID = row["UserId"].ToString();
                    obj.items = row["Items"].ToString();
                    obj.ReceiptId = int.Parse(row["ReceiptId"].ToString());
                    obj.price = double.Parse(row["Price"].ToString());
                    obj.purchaseDate = row["PurchaseDate"].ToString();
                    objList.Add(obj);
                }
            }
            return objList;
        }
    }
}