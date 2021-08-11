using MDL;
using Sunny.UI;
using BLL;
using System.Windows.Forms;

namespace MyCateringsTack
{
    public partial class AddSysUsersFrm : UIForm
    {
        public AddSysUsersFrm()
        {
            InitializeComponent();
        }

        public AdUsers MyAdUsers { get; set; }

        private void uiButton2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(uiTextBox1.Text))
            {
                UIMessageTip.ShowError("请输入完整信息！");
                return;
            }
            if (string.IsNullOrWhiteSpace(uiTextBox2.Text))
            {
                UIMessageTip.ShowError("请输入完整信息！");
                return;
            }
            if (string.IsNullOrWhiteSpace(uiTextBox3.Text))
            {
                UIMessageTip.ShowError("请输入完整信息！");
                return;
            }
            if (uiLabel2.Text != "原密码")
            {
                if (uiTextBox2.Text != uiTextBox3.Text)
                {
                    UIMessageTip.ShowError("请输入完整信息！");
                    return;
                }
            }
            if (MyAdUsers != null)
            {
                if (uiTextBox2.Text != MyAdUsers.UsPwd)
                {
                    UIMessageTip.ShowError("原密码输入错误！");
                    uiTextBox2.Text = "";

                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(uiTextBox4.Text))
            {
                UIMessageTip.ShowError("真实姓名不能为空！");
                return;
            }

            if (MyAdUsers == null)
                MyAdUsers = new AdUsers();
            MyAdUsers.Name = uiTextBox4.Text;
            MyAdUsers.UsCode = uiTextBox1.Text;
            MyAdUsers.UsPwd = uiTextBox3.Text;

            bool bl = new BLL_AdUsers().UpdateUsers(MyAdUsers);
            if (bl)
            {
                if (uiLabel2.Text == "原密码")
                {
                    UIMessageTip.ShowOk("修改成功,请重新登录！");
                    Application.Exit();
                }
                else
                    UIMessageTip.ShowOk("更新操作员信息成功！");

            }
            else
                UIMessageTip.ShowError("更新操作员信息失败！");

            this.Close();

        }

        private void AddSysUsersFrm_Load(object sender, System.EventArgs e)
        {
            if (MyAdUsers != null)
            {
                uiTextBox1.Text = MyAdUsers.UsCode;
                uiTextBox4.Text = MyAdUsers.Name;
            }
        }
    }
}
