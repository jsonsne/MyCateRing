using System;
using Sunny.UI;
using BLL;
using MDL;
namespace MyCateringsTack
{
    public partial class AddVipFrm : UIForm
    {
        public AddVipFrm()
        {
            InitializeComponent();
        }

        public VipUsers VipUsers;


        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //事件加载
        private void AddVipFrm_Load(object sender, EventArgs e)
        {
            uiComboBox2.DataSource = new BLL_VipCosts().GetVipCosts();
            uiComboBox2.DisplayMember = "name";
            uiComboBox2.ValueMember = "id";

            if (VipUsers != null)
            {
                uiTextBox1.Text = VipUsers.Name;
                uiTextBox2.Text = VipUsers.Phone;
                uiComboBox1.Text = VipUsers.Gender ? "女" : "男";
                uiComboBox2.SelectedValue = VipUsers.VipId;
                dateTimePicker1.Value = VipUsers.EndDate.ToDateTime();
            }

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(uiTextBox1.Text))
            {
                UIMessageTip.ShowError("会员姓名不能为空！");
                return;
            }

            if (string.IsNullOrWhiteSpace(uiTextBox2.Text))
            {
                UIMessageTip.ShowError("会员电话不能为空！");
                return;
            }

            if (DateTime.Compare(System.DateTime.Now, dateTimePicker1.Value) > 0)
            {
                UIMessageTip.ShowError("办理时间不能小于当前日期!");
                return;
            }

            if (VipUsers == null)
            {
                VipUsers = new VipUsers();
            }
            if (uiComboBox1.Text == "请选择")
            {
                UIMessageTip.ShowError("请选择会员的性别！");
                return;
            }
            if (uiComboBox2.Text =="请选择")
            {
                UIMessageTip.ShowError("请选择会员的等级！");
                return;
            }

            VipUsers.Name = uiTextBox1.Text.Trim();
            VipUsers.Phone = uiTextBox2.Text.Trim();
            VipUsers.Gender = uiComboBox1.Text == "男" ? false : true;
            VipUsers.VipId = uiComboBox2.SelectedValue == null ? VipUsers.VipId : (int)uiComboBox2.SelectedValue;
            VipUsers.EndDate = dateTimePicker1.Value.ToString();

            bool bl = new BLL_VipUsers().UpdateVip(VipUsers);
            if (bl)
                UIMessageTip.ShowOk("更新会员信息成功！");
            else
                UIMessageTip.ShowError("更新会员信息失败！");

            this.Close();
        }
    }
}
