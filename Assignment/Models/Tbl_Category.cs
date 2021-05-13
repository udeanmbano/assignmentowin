using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesmanProductManagement.Models
{
    public class Tbl_Category
    {
     
        public Tbl_Category()
        {
            this.Tbl_Product = new HashSet<Tbl_Product>();
        }
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public String SalesmanUserId { get; set; }
        public virtual ICollection<Tbl_Product> Tbl_Product { get; set; }
     
    }
}