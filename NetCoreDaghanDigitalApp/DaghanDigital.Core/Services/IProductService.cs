using DaghanDigital.Core.Models.DTOs;
using DaghanDigital.Core.Models.Entities;
using DaghanDigital.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaghanDigital.Core.Services
{
    public interface IProductService:IService<Product>
    {
        //Wep Projesinde dönüş değeri farklı olduğu için bunu aktif ettim
        Task<List<ProductWithCategoryDto>> GetProductWithCategory();



        /* WEP projesinde dönüş değeri olarak CustomResponseDto ya ihtiyacım olmadığı için API projesinde kullanılan ProductServiceWithCaching şimdilik bunu pasif hale getiriyorum
         * API Projesinde dönüş değeri olarak status yazan aşağıdaki method yerine yukarıdaki methodu kullanacağım
         * Yukarıdaki methodu kullandığımız zaman ApıController da bulunan CustomBaseControllerdaki CreateActionResult methodu geri dönüş değeri olarak CustomResponseDto beklediğinden hata çıkmaktadır.
         * Bu yüzden Apı Projesini şimdilik unloaded yapacağım. Bu sayede proje derlenirken API derlenmeyecektir.
         */
        //Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductWithCategory();
    }
}
