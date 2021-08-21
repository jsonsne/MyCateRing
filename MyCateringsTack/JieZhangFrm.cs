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
    public partial class JieZhangFrm : UIForm
    {
        public JieZhangFrm()
        {
            InitializeComponent();
        }
        public Tables Mytb { get; set; }

        //事件加载
        private void JieZhangFrm_Load(object sender, EventArgs e)
        {
            lblcz.Text = Mytb.Name;
            List<CaterDetail> list = new BLL_CaterDetail().GetCaters(Mytb.Id);
            lblzh.Text = list[0].BiiId;
            lblje.Text = lblys.Text = lblss.Text = list.Select(c => c.SumPrice).Sum().ToString();
            uiDataGridView1.DataSource = list;
        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(uiTextBox1.Text))
            {
                lblhym.Text =
                lblyhjb.Text =
                lblhyzk.Text =
                lblhyId.Text = "";
                return;
            }

            int id = int.Parse(uiTextBox1.Text);
            ShowVipUsers vipUsers = new BLL_VipUsers().GetVipUsers(id);
            if (vipUsers.Id != 0)
            {
                lblhym.Text = vipUsers.Name;
                lblyhjb.Text = vipUsers.VName;
                lblhyzk.Text = vipUsers.ZheKou.ToString();
                lblhyId.Text = vipUsers.Id.ToString();

                double sumprice = Convert.ToDouble(lblje.Text);
                double yh = (sumprice * vipUsers.ZheKou);
                lblss.Text = yh.ToString();
                lblyh.Text = (sumprice - yh).ToString();
            }
        }

        private void uiTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (e.KeyChar < '1' || e.KeyChar > '9')
                    e.Handled = true;
            }
        }

        private void uiTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(uiTextBox2.Text))
            {
                return;
            }
            double money = Convert.ToDouble(uiTextBox2.Text);
            double sumprice = Convert.ToDouble(lblss.Text);
            double rs = money - sumprice;
            if (rs < 0)
                lblyz.Text = "无法支付";
            else
                lblyz.Text = rs.ToString();
        }

        private void uiTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (e.KeyChar < '0' || e.KeyChar > '9')
                    e.Handled = true;
            }
        }

        //结账咯
        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (lblyz.Text == "无法支付" || string.IsNullOrWhiteSpace(lblyz.Text))
            {
                UIMessageTip.ShowError("无法支付！");
                return;
            }
            CaterBill cater = new CaterBill();
            cater.Id = lblzh.Text;
            cater.VipId = Convert.ToInt32(lblhyId.Text);
            cater.Sumprice = Convert.ToDouble(lblss.Text);
            cater.FinishDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //填充订单表
            bool bl = new BLL_CaterBill().UpdateCaterBii(cater);
            //更改餐桌状态
            if (bl)
            {
                new BLL_Tables().UpdateTableState((int)TableEnum.可用, Mytb.Id);
                MessageBox.Show("感谢您的惠顾，期待您下次光临本店！", "支付成功", MessageBoxButtons.OK);
                this.Close();
            }
            else
                UIMessageTip.ShowError("发生异常！");

        }
    }
}