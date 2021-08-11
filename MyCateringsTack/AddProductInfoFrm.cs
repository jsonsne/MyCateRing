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
    public partial class AddProductInfoFrm : UIForm
    {
        public AddProductInfoFrm()
        {
            InitializeComponent();
        }

        public Products MyProperty { get; set; }
        public string Txt { get; set; }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //保存商品
        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (MyProperty == null)
                MyProperty = new Products();

            if (string.IsNullOrWhiteSpace(uiTextBox1.Text))
            {
                UIMessageTip.ShowError("商品名称不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(uiTextBox2.Text))
            {
                UIMessageTip.ShowError("商品简拼不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(uiTextBox4.Text))
            {
                UIMessageTip.ShowError("商品价格不能为空！");
                return;
            }
            if (uiComboBox1.SelectedValue == null && MyProperty == null)
            {
                UIMessageTip.ShowError("商品类型不能为空！");
                return;
            }

            try
            {
                MyProperty.Name = uiTextBox1.Text;
                MyProperty.JianPin = uiTextBox2.Text;
                MyProperty.Price = double.Parse(uiTextBox4.Text);
                MyProperty.PType = uiComboBox1.SelectedValue == null ? MyProperty.PType : (int)uiComboBox1.SelectedValue;

                bool bl = new BLL_Products().UpdateProducts(MyProperty);
                if (bl)
                {
                    UIMessageTip.ShowOk("更新商品数据完成！");
                }
                else
                    UIMessageTip.ShowOk("更新商品数据失败！");

            }
            catch (Exception)
            {
                MessageBox.Show("出错了,ZZ！");
            }
            finally
            {
                this.Close();
            }


        }

        //事件加载
        private void AddProductInfoFrm_Load(object sender, EventArgs e)
        {
            uiComboBox1.DataSource = new BLL_ProductTypes().GetProductTypes();
            uiComboBox1.DisplayMember = "name";
            uiComboBox1.ValueMember = "id";


            if (MyProperty != null)
            {
                uiTextBox1.Text = MyProperty.Name;
                uiTextBox2.Text = MyProperty.JianPin;
                uiTextBox4.Text = MyProperty.Price.ToString();
                uiComboBox1.Text = Txt;
            }

        }
    }
}
