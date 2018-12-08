using EADP_Project.Entities;
using EADP_Project_Education.DAO;
using EADP_Project_Education.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EADP_Project_Education.BO
{

    public class Bookstore_BO
    {
        Bookstore_DAO bookstoredao = new Bookstore_DAO();

        public List<Product> GridViewTable()
        {
            List<Product> quickProduct = new List<Product>();
            quickProduct = bookstoredao.DataGridViewRetrieve();
            return quickProduct;
        }

        public List<Product> GridViewTableSC()
        {
            List<Product> quickProduct = new List<Product>();
            quickProduct = bookstoredao.DataGridViewRetrieveForCart();
            return quickProduct;
        }

        public List<Product> filterEdulvlAny(String EduLevelAny)
        {
            List<Product> quickProduct = new List<Product>();
            quickProduct = bookstoredao.filterEdulvlAnyProductInDB(EduLevelAny);
            return quickProduct;
        }

        public List<Product> filterEdulvl(String EduLevel)
        {
            List<Product> quickProduct = new List<Product>();
            quickProduct = bookstoredao.filterEdulvlProductInDB(EduLevel);
            return quickProduct;
        }

        public List<Product> filterTypeAny(String TypeAny)
        {
            List<Product> quickProduct = new List<Product>();
            quickProduct = bookstoredao.filterTypeAnyProductInDB(TypeAny);
            return quickProduct;
        }

        public List<Product> filterType(String Type)
        {
            List<Product> quickProduct = new List<Product>();
            quickProduct = bookstoredao.filterTypeProductInDB(Type);
            return quickProduct;
        }

        public string uploadProduct(String productId, String ImageURL, String NAME, Double PRICE, String EduLevel, String Type, int Quantity, String EduLevelAny, String TypeAny)
        {
            string result = "";
            if (result == ""){
                bookstoredao.uploadProductToDB(productId, ImageURL, NAME, PRICE, EduLevel, Type, Quantity, EduLevelAny, TypeAny);
            }
            else
            {
                result = "Error";
            }

            return "";
        }

        public List<Product> sortByAlphabet()
        {
            List<Product> quickProduct = new List<Product>();
            quickProduct = bookstoredao.SortByAlphabet();
            return quickProduct;
        }

        public List<Product> sortByPriceLH()
        {
            List<Product> quickProduct = new List<Product>();
            quickProduct = bookstoredao.SortByPriceLH();
            return quickProduct;
        }

        public List<Product> sortByPriceHL()
        {
            List<Product> quickProduct = new List<Product>();
            quickProduct = bookstoredao.SortByPriceHL();
            return quickProduct;
        }

        public List<Product> searchForProduct(String searchItem)
        {
            List<Product> quickProduct = new List<Product>();
            quickProduct = bookstoredao.SearchForProduct(searchItem);
            return quickProduct;
        }

        Bookstore_DAO bookstoredaoretrieve = new Bookstore_DAO();
        public Product retrieveProduct(int ProductId)
        {
            Product result = null;
         
            result = bookstoredao.RetrieveProductFromDB(ProductId);

            return result;
        }

        Bookstore_DAO bookstoredaoupdate = new Bookstore_DAO();
        public string updateProduct(String productId, String ImageURL, String NAME, Double PRICE, String EduLevel, String Type, int Quantity)
        {
            string result = "";
            if (result == "")
            {
                bookstoredao.EditProductToDB(productId, ImageURL, NAME, PRICE, EduLevel, Type, Quantity);
            }
            else
            {
                result = "Error";
            }

            return "";
        }

        Bookstore_DAO bookstoredaodelete = new Bookstore_DAO();
        public string deleteProduct(String productId)
        {
            string result = "";
            if (result == "")
            {
                bookstoredao.DeleteProductToDB(productId);
            }
            else
            {
                result = "Error";
            }

            return "";
        }

        public int retrieveProductId(String NAME)
        {
            int result = 0;
            result = bookstoredao.RetrieveProductIdFromDB(NAME);
            return result;
        }

        public string retrieveProductQuantity(int productId)
        {
            string result;
            result = bookstoredao.retrieveQuantityFromDB(productId).ToString();
            return result;
        }

        public string retrieveProductIdFromCart(int productId)
        {
            string result;
            result = bookstoredao.retrieveIdFromCartDB(productId).ToString();
            return result;
        }

        public string updateQuantityInCartDB(int productId, int Quantity)
        {
            string result = "";
            if (result == "")
            {
                bookstoredao.updateQuantityInCartDB(productId, Quantity);
            }
            else
            {
                result = "Error";
            }

            return "";
        }

        public string updateQuantity(int productId ,int Quantity)
        {
            string result = "";
            if (result == "")
            {
                bookstoredao.updateQuantityFromDB(productId, Quantity);
            }
            else
            {
                result = "Error";
            }

            return "";
        }

        public string retrieveImageString(int productId)
        {
            string result;
            result = bookstoredao.retrieveImageFromDB(productId).ToString();
            return result;
        }

        public string AddProduct(int ProductId, String ImageURL, String NAME, decimal PRICE, int Quantity)
        {
            string result = "";
            if (result == "")
            {
                bookstoredao.AddProductToCartDB(ProductId, ImageURL, NAME, PRICE, Quantity);
            }
            else
            {
                result = "Error";
            }

            return "";
        }

        public string retrieveProductFromCart()
        {
            string result;
            result = bookstoredao.retrieveProductFromCart();
            return result;
        }

        public string retrieveProductCostForCart()
        {
            string result;
            result = bookstoredao.retrieveProductCostFromCart();
            return result;
        }

        public string deleteProductFromCart(String NAME)
        {
            string result = "";
            if (result == "")
            {
                bookstoredao.DeleteProductFromDBCart(NAME);
            }
            else
            {
                result = "Error";
            }

            return "";
        }

        public string deleteAllFromCart()
        {
            string result = "";
            if (result == "")
            {
                bookstoredao.DeleteAllFromDBCart();
            }
            else
            {
                result = "Error";
            }

            return "";
        }

        //Study Guide
        public List<Schedule> ScheduleTable()
        {
            List<Schedule> quickSchedule = new List<Schedule>();
            quickSchedule = bookstoredao.RetrieveGridViewSchedule();
            return quickSchedule;
        }

        public string uploadToHistory(string userId, string receiptNum, string itemList, decimal Price, string purchaseDate)
        {
            string result = "";
            if (result == "")
            {
                bookstoredao.UploadToHistory(userId, receiptNum, itemList, Price, purchaseDate);
            }
            else
            {
                result = "Error";
            }

            return "";
        }
        public List<PurchasedItem> purchaseHistory(string userID)
        {
            return bookstoredao.purchaseHistory(userID);
        }

    }
}