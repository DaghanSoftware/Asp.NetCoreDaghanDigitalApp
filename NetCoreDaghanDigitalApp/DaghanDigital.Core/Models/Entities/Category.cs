using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaghanDigital.Core.Models.Entities
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }

        //Navigation Property
        public ICollection<Product> Products { get; set; }
    }
}
