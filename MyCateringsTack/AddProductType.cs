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
    public partial class AddProductType : UIForm
    {
        public AddProductType()
        {
            InitializeComponent();
        }
        public ProductTypes Types { get; set; }
        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddProductType_Load(object sender, EventArgs e)
        {
            if (Types != null)
                uiTextBox1.Text = Types.Name;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uiTextBox1.Text))
            {
                UIMessageTip.ShowError("商品类型名称不能为空！");
                return;
            }

            if (Types == null)
                Types = new ProductTypes();
            Types.Name = uiTextBox1.Text.Trim();
            bool bl = new BLL_ProductTypes().UpdateTypes(Types);
            if (bl)
                UIMessageTip.ShowOk("添加类别成功！");
            else
                UIMessageTip.ShowError("添加类别失败！");
            this.Close();

        }
    }
}
