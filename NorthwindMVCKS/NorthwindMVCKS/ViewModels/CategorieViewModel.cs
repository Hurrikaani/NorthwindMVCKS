﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindMVCKS.ViewModels
{
    public class CategorieViewModel
    {
        //public partial class Categories
        //{
        //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //    public Categories()
        //    {
        //        this.Products = new HashSet<Products>();
        //    }

            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public string Description { get; set; }
            public byte[] Picture { get; set; }

            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //public virtual ICollection<Products> Products { get; set; }
        }
    }
