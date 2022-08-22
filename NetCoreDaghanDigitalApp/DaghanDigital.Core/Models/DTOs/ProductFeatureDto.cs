using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaghanDigital.Core.Models.DTOs
{
    public class ProductFeatureDto:BaseDto
    {

        public string Color { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int ProductId { get; set; }
    }
}
