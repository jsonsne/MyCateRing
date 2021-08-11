using Sunny.UI;
using BLL;
using MDL;
namespace MyCateringsTack
{
    public partial class SystemFrm : UITitlePage
    {
        public SystemFrm()
        {
            InitializeComponent();
        }

        //事件加载
        private void SystemFrm_Load(object sender, System.EventArgs e)
        {
            uiDataGridView1.DataSource = new BLL_AdUsers().GetUsers();
            uiDataGridView2.DataSource = new BLL_VipCosts().GetVipCosts();
        }



        //添加会员等级
        private void uiButton6_Click(object sender, System.EventArgs e)
        {
            AddVipCostFrm costFrm = new AddVipCostFrm();
            costFrm.ShowDialog();
            SystemFrm_Load(null, null);

        }
        //修改会员等级
        private void uiButton5_Click(object sender, System.EventArgs e)
        {
            if (uiDataGridView2.SelectedRows.Count <= 0)
            {
                UIMessageTip.ShowError("请选择要修改的数据行！");
                return;
            }

            AddVipCostFrm costFrm = new AddVipCostFrm();
            VipCost cost = new VipCost();
            cost.Name = uiDataGridView2.SelectedRows[0].Cells["vname"].Value.ToString();
            cost.ZheKou = (double)uiDataGridView2.SelectedRows[0].Cells["vzhekou"].Value;
            costFrm.MyVipCost = cost;
            costFrm.ShowDialog();
            SystemFrm_Load(null, null);
        }
        //删除会员等级
        private void uiButton4_Click(object sender, System.EventArgs e)
        {
            if (uiDataGridView2.SelectedRows.Count <= 0)
            {
                UIMessageTip.ShowError("请选择要删除的数据行！");
                return;
            }
            int id = (int)uiDataGridView2.SelectedRows[0].Cells["vid"].Value;

            bool bl = new BLL_VipCosts().IsExistsVipUs(id);
            if (!bl)
            {
                UIMessageTip.ShowError("该会员已有顾客开通不能删除！");
                return;
            }

            if (System.Windows.Forms.MessageBox.Show("是否确认删除？", "系统提示", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            bl = new BLL_VipCosts().DeleteVipCost(id);
            if (bl)
                UIMessageTip.ShowOk("删除成功！");
            else
                UIMessageTip.ShowError("删除失败！");


            SystemFrm_Load(null, null);

        }
        //添加操作员
        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            AddSysUsersFrm usersFrm = new AddSysUsersFrm();
            usersFrm.uiLabel2.Text = "登录密码";
            usersFrm.uiLabel3.Text = "确认密码";
            usersFrm.ShowDialog();
            SystemFrm_Load(null, null);
        }
        //修改操作员
        private void uiButton2_Click(object sender, System.EventArgs e)
        {
            if (uiDataGridView1.SelectedRows.Count <= 0)
            {
                UIMessageTip.ShowError("请选择要修改的数据行！");
                return;
            }
            AddSysUsersFrm usersFrm = new AddSysUsersFrm();
            AdUsers us = new AdUsers();
            us.UsCode = uiDataGridView1.SelectedRows[0].Cells["cCode"].Value.ToString();
            us.UsPwd = uiDataGridView1.SelectedRows[0].Cells["cpwd"].Value.ToString();
            us.Id = (int)uiDataGridView1.SelectedRows[0].Cells["cid"].Value;
            us.Name= uiDataGridView1.SelectedRows[0].Cells["cname"].Value.ToString();

            usersFrm.MyAdUsers = us;
            usersFrm.uiLabel2.Text = "原密码"; 
            usersFrm.uiLabel3.Text = "新密码"; 
            usersFrm.ShowDialog();
            SystemFrm_Load(null, null);
        }
        //删除操作员
        private void uiButton3_Click(object sender, System.EventArgs e)
        {
            if (uiDataGridView1.SelectedRows.Count <= 0)
            {
                UIMessageTip.ShowError("请选择要删除的操作员！");
                return;
            }

            AdUsers us = new AdUsers();
            us.UsCode = uiDataGridView1.SelectedRows[0].Cells["cCode"].Value.ToString();
            us.UsPwd = uiDataGridView1.SelectedRows[0].Cells["cpwd"].Value.ToString();
            us.Id= (int)uiDataGridView1.SelectedRows[0].Cells["cid"].Value;
            bool bl = new BLL_AdUsers().IsLoginSucees(us);
            if (bl)
            {
                UIMessageTip.ShowError("该操作员正处于登录中，不能删除！");
                return;
            }

            if (System.Windows.Forms.MessageBox.Show("是否确认删除？", "系统提示", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            bl = new BLL_AdUsers().DelUsers(us.Id);
            if (bl)
                UIMessageTip.ShowOk("删除成功！");
            else
                UIMessageTip.ShowError("删除失败！");

            SystemFrm_Load(null, null);


        }
    }
}
