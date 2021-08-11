using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MDL;
using Sunny.UI;
using BLL;

namespace MyCateringsTack
{
    public partial class UpdateTable : UIForm
    {
        public UpdateTable()
        {
            InitializeComponent();
        }

        public Tables MyTables { get; set; }
        public string Txt { get; set; }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //保存更新餐桌
        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (MyTables == null)
            {
                MyTables = new Tables();
            }
            if (string.IsNullOrWhiteSpace(uiTextBox1.Text))
            {
                UIMessageTip.ShowError("餐桌名称不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(Txt) && uiComboBox1.SelectedValue == null)
            {
                UIMessageTip.ShowError("所在房间不能为空！");
                return;
            }

            MyTables.Name = uiTextBox1.Text.Trim();
            MyTables.Rid = uiComboBox1.SelectedValue == null ? MyTables.Rid : (int)uiComboBox1.SelectedValue;

            bool bl = new BLL_Tables().UpdateTableNum(MyTables);
            if (bl)
                UIMessageTip.ShowOk("更新餐桌成功！");
            else
                UIMessageTip.ShowOk("更新餐桌失败！");

            this.Close();
        }

        //事件加载
        private void UpdateTable_Load(object sender, EventArgs e)
        {
            if (MyTables != null)
            {
                uiTextBox1.Text = MyTables.Name;
                uiComboBox1.Text = Txt;
            }
            uiComboBox1.DataSource = new BLL_RoomType().GetRoomTypes();
            uiComboBox1.DisplayMember = "name";
            uiComboBox1.ValueMember = "id";
        }
    }
}
