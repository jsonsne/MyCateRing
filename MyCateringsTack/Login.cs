using System;
using MDL;
using Sunny.UI;
using BLL;
namespace MyCateringsTack
{
    public partial class Login : UIForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void uiButton2_Click(object sender, EventArgs e)
        {
            var usCode = uiTextBox1.Text;
            var usPwd = uiTextBox2.Text;

            if (string.IsNullOrWhiteSpace(usCode) || string.IsNullOrWhiteSpace(usPwd))
            {
                UIMessageTip.ShowError("账号或密码不能为空！");
                return;
            }
            else
            {
                AdUsers us = new AdUsers() { UsCode = usCode,UsPwd=usPwd};
               if( new BLL_AdUsers().IsLoginSucees(us))
                {
                    this.Hide();
                    new FrmMain().Show();
                }
                else
                {
                    UIMessageTip.ShowError("账号或密码有误！", 1500);
                }

            }
        }
    }
}
