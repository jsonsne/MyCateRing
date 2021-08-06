using Sunny.UI; 

namespace MyCateringsTack
{
    public partial class FrmMain : UIHeaderAsideMainFrame
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, System.EventArgs e)
        {
            //节点和页面绑定
            Aside.TabControl = MainTabControl;
            //添加页面
            AddPage(new DefaultFrm(), 1001);//默认首页
            AddPage(new CateBillFrm(), 10021);//账单查询
            AddPage(new ConSumFrm(), 10022);//消费查询
            AddPage(new VipFrm(), 1003);//vip管理
            AddPage(new RoomTableFrm(), 1004);//房间餐桌管理
            AddPage(new ProductFrm(), 1005);//商品管理
            AddPage(new SystemFrm(), 1006);//系统管理

            //节点绑定
            Aside.SetNodePageIndex(Aside.Nodes[0],1001);
            Aside.SetNodePageIndex(Aside.Nodes[1].Nodes[0],10021);
            Aside.SetNodePageIndex(Aside.Nodes[1].Nodes[1],10022);
            Aside.SetNodePageIndex(Aside.Nodes[2],1003);
            Aside.SetNodePageIndex(Aside.Nodes[3],1004);
            Aside.SetNodePageIndex(Aside.Nodes[4],1005);
            Aside.SetNodePageIndex(Aside.Nodes[5],1006);

            //默认显示
            Aside.SelectPage(1001);


        }

        private void FrmMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
