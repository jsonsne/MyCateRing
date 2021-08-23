using MDL;
using Sunny.UI;
using System;
using System.Windows.Forms;

namespace MyCateringsTack
{
    public partial class FrmMain : UIHeaderAsideMainFrame
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        public void FrmMain_Load(object sender, System.EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            uiLabel3.Text = StaticCommons.UsInfo.UsCode;
            //节点和页面绑定
            Aside.TabControl = MainTabControl;
            var vp = new VipFrm();
            var cbi = new CateBillFrm();
            var cda = new ConSumFrm();
            var df = new DefaultFrm(vp,cbi,cda);
            //添加页面 
            AddPage(df, 1001);//默认首页
            AddPage(cbi, 10021);//账单查询
            AddPage(cda, 10022);//消费查询
            AddPage(vp, 1003);//vip管理
            AddPage(new RoomTableFrm(df), 1004);//房间餐桌管理
            AddPage(new ProductFrm(), 1005);//商品管理
            AddPage(new SystemFrm(), 1006);//系统管理

            //节点绑定
            Aside.SetNodePageIndex(Aside.Nodes[0], 1001);
            Aside.SetNodePageIndex(Aside.Nodes[1].Nodes[0], 10021);
            Aside.SetNodePageIndex(Aside.Nodes[1].Nodes[1], 10022);
            Aside.SetNodePageIndex(Aside.Nodes[2], 1003);
            Aside.SetNodePageIndex(Aside.Nodes[3], 1004);
            Aside.SetNodePageIndex(Aside.Nodes[4], 1005);
            Aside.SetNodePageIndex(Aside.Nodes[5], 1006);

            //默认显示
            Aside.SelectPage(1001);


        }

        private void FrmMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void uiLinkLabel1_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("您确定要注销登录吗？", "系统提示", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Restart();
                this.Close();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void Aside_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
            //var str = Aside.SelectedNode.Text;
            //switch (str)
            //{
            //    case "餐饮首页":
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
