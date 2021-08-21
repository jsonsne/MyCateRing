using BLL;
using MDL;
using Sunny.UI;
using System;

namespace MyCateringsTack
{
    public partial class AddKaiTaiFrm : UIForm
    {
        public AddKaiTaiFrm()
        {
            InitializeComponent();
        }

        public Kaitans MyTb { get; set; }

        private void uiButton2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(uiTextBox1.Text))
            {
                UIMessageTip.ShowError("请输入顾客人数！");
                return;
            }


            //更改餐桌状态
            new BLL_Tables().UpdateTableState((int)TableEnum.占用, MyTb.TbId);
            //添加订单表
            CaterBill cater = new CaterBill();
            cater.Id = $"DD{DateTime.Now.ToString("yyyyMMdd")}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}";
            cater.TableId = MyTb.TbId;
            cater.Renshu = int.Parse(uiTextBox1.Text);
            cater.UserId = StaticCommons.UsInfo.Id;
            new BLL_CaterBill().AddCaterBill(cater);

            if (uiCheckBox1.Checked)
            {
                new BLL_Tables().UpdateTableState((int)TableEnum.占用, MyTb.TbId);
                AddOrderFrm frm = new AddOrderFrm();
                frm.TableId = MyTb.TbId;
                this.Hide();
                frm.ShowDialog();
            }
            this.Close();

            uiTextBox1.Text = "";
            uiCheckBox1.Checked = false;
        }

        private void uiTextBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void AddKaiTaiFrm_Load(object sender, System.EventArgs e)
        {
            if (MyTb != null)
            {
                uiLabel2.Text = MyTb.TbName;
                uiLabel6.Text = MyTb.TyName;
                uiLabel7.Text = MyTb.TyMinCost.ToString();
                uiTextBox1.Watermark = "最大容纳人数" + MyTb.TyMaxRenshu;
            }
        }
    }
}
