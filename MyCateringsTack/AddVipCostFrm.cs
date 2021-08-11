using MDL;
using Sunny.UI;
using BLL;
namespace MyCateringsTack
{
    public partial class AddVipCostFrm : UIForm
    {
        public AddVipCostFrm()
        {
            InitializeComponent();
        }

        public VipCost MyVipCost { get; set; }

        private void uiButton2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void uiTextBox2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && e.KeyChar!='.')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(uiTextBox1.Text))
            {
                UIMessageTip.ShowError("请输入会员等级！");
                return;
            }

            if (string.IsNullOrWhiteSpace(uiTextBox2.Text))
            {
                UIMessageTip.ShowError("请输入会员等级折扣！");
                return;
            }

            if (MyVipCost == null)
                MyVipCost = new VipCost();
            MyVipCost.Name = uiTextBox1.Text;
            MyVipCost.ZheKou = double.Parse(uiTextBox2.Text);

            bool bl = new BLL_VipCosts().UpdateVipCost(MyVipCost);
            if (bl)
                UIMessageTip.ShowOk("更新会员信息成功！");
            else
                UIMessageTip.ShowOk("更新会员信息失败！");
            this.Close();



        }

        private void AddVipCostFrm_Load(object sender, System.EventArgs e)
        {
            if (MyVipCost != null)
            {
                uiTextBox1.Text = MyVipCost.Name;
                uiTextBox2.Text = MyVipCost.ZheKou.ToString();
            }
        }
    }
}
