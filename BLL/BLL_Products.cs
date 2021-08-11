using DAL;
using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Products
    {
        DAL_Products prd;
        public BLL_Products()
        {
            prd = new DAL_Products();
        }

        /// <summary>
        /// 获取所有的商品列表
        /// </summary>
        /// <returns></returns>
        public List<Products> GetProducts(int t = 0, string str = "aa") => prd.GetProducts(t,str);

        /// <summary>
        /// 添加或修改
        /// </summary>
        /// <param name="ps"></param>
        /// <returns></returns>
        public bool UpdateProducts(Products ps) => prd.UpdateProducts(ps);

        /// <summary>
        /// 下架商品不做物理删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteProduct(int id) => prd.DeleteProduct(id);

    }
}
