using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_RoomType
    {
        DAL_RoomType rt;
        public BLL_RoomType()
        {
            rt = new DAL_RoomType();
        }

        /// <summary>
        /// 获取所有的房间类型
        /// </summary>
        /// <returns></returns>
        public List<RoomType> GetRoomTypes() => rt.GetRoomTypes();

        /// <summary>
        /// 更新房间类型
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public bool UpdateRoomtype(RoomType room) => rt.Update(room);

        /// <summary>
        /// 删除房间类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteRoom(int id) => rt.DeleteRoom(id);

        /// <summary>
        /// 根据房间类型获取餐桌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool GetRomCount(int id) => rt.ByIdRoomCount(id);
    }
}
