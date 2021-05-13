using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalesmanProductManagement.Models
{
    public class Tbl_Product
    {    
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
  
        public Nullable<int> CategoryId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public String SalesmanUserId { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Tbl_Category Tbl_Category { get; set; }
      
    }
}