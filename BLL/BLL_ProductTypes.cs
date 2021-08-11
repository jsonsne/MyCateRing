using DAL;
using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_ProductTypes
    {
        public BLL_ProductTypes()
        {
            proType = new DAL_ProductTypes();
        }

        DAL_ProductTypes proType;

        /// <summary>
        /// 获取所有的商品类型
        /// </summary>
        /// <returns></returns>
        public List<ProductTypes> GetProductTypes() => proType.GetProductTypes();

        /// <summary>
        /// 更新商品类型(添加或修改)
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public bool UpdateTypes(ProductTypes pt) => proType.UpdateType(pt);

        /// <summary>
        /// 根据Id删除商品类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteTypes(int id) => proType.DeleteType(id);

        /// <summary>
        /// 删除时判断该商品类型是否包含商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool HasProduct(int id) => proType.HasProduct(id);
    }
}
