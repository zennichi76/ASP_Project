using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Project.Entities
{
    public class PurchasedItem
    {
        public int historyID { get; set; }
        public string UserID { get; set; }
        public int ReceiptId { get; set; }
        public string items { get; set; }
        public double price { get; set; }
        public string purchaseDate { get; set; }
        public PurchasedItem()
        {

        }

    }
}