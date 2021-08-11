using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using MDL;
using Sunny.UI;
namespace MyCateringsTack
{
    public partial class PiAddTables : UIForm
    {
        public PiAddTables()
        {
            InitializeComponent();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //保存
        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(uiTextBox1.Text))
            {
                UIMessageTip.ShowError("餐桌前缀编号不能为空！");
                return;
            }

            if (string.IsNullOrWhiteSpace(uiTextBox2.Text))
            {
                UIMessageTip.ShowError("餐桌编号范围前置数字不能为空！");
                return;
            }

            if (string.IsNullOrWhiteSpace(uiTextBox3.Text))
            {
                UIMessageTip.ShowError("餐桌编号后置数字不能为空！");
                return;
            }

            if (uiComboBox1.SelectedValue == null)
            {
                UIMessageTip.ShowError("请选择房间类型！");
                return;
            }

            try
            {
                var str = uiTextBox1.Text.Trim();
                int start = int.Parse(uiTextBox2.Text.Trim());
                int end = int.Parse(uiTextBox3.Text.Trim());

                int rid = (int)uiComboBox1.SelectedValue;
                bool bl = false;
                for (int i = start; i <= end; i++)
                {
                    Tables t = new Tables();
                    t.Name = str + i;
                    t.Rid = rid;
                    bl = new BLL_Tables().UpdateTableNum(t);
                }
                if (bl)
                    UIMessageTip.ShowOk("批量生产餐桌成功！");
                else
                    UIMessageTip.ShowError("批量生产餐桌失败！");


            }
            catch (Exception)
            {
                MessageBox.Show("发生错误,请重启动尝试！", "系统提示", MessageBoxButtons.OK);
            }
            finally
            {
                this.Close();
            }

        }

        private void PiAddTables_Load(object sender, EventArgs e)
        {
            uiComboBox1.DataSource = new BLL_RoomType().GetRoomTypes();
            uiComboBox1.DisplayMember = "name";
            uiComboBox1.ValueMember = "id";
        }
    }
}
