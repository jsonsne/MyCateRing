﻿using Sunny.UI;
using BLL;
using MDL;

namespace MyCateringsTack
{
    public partial class VipFrm : UITitlePage
    {
        public VipFrm()
        {
            InitializeComponent();
        }
        //加载事件
        private void VipFrm_Load(object sender, System.EventArgs e)
        {
            uiDataGridView1.DataSource = new BLL_VipUsers().GetVipUsers();
            uiDataGridView1.SelectedIndex = 0;
        }

        //删除
        private void uiButton3_Click(object sender, System.EventArgs e)
        {
            if (uiDataGridView1.SelectedRows.Count <= 0)
            {
                UIMessageTip.ShowError("请选中要删除的数据列！");
                return;
            }

            if (System.Windows.Forms.MessageBox.Show("是否确认删除该会员？", "系统提示", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            int id = (int)uiDataGridView1.SelectedRows[0].Cells["vid"].Value;

            bool bl = new BLL_VipUsers().DeleteVipUser(id);
            if (bl)
                UIMessageTip.ShowOk("删除成功！");
            else
                UIMessageTip.ShowError("删除失败！");

            VipFrm_Load(null, null);
        }

        //查询
        private void uiButton4_Click(object sender, System.EventArgs e)
        {
            string txt = string.IsNullOrWhiteSpace(uiTextBox1.Text) ? "aaa" : uiTextBox1.Text.Trim();
            uiDataGridView1.DataSource = new BLL_VipUsers().GetVipUsers(txt);
        }

        //添加
        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            AddVipFrm vap = new AddVipFrm();
            vap.ShowDialog();
            VipFrm_Load(null, null);

        }

        //修改
        private void uiButton2_Click(object sender, System.EventArgs e)
        {

            if (uiDataGridView1.SelectedRows.Count <= 0)
            {
                UIMessageTip.ShowError("请选择要修改的行数据！");
                return;
            }

            AddVipFrm vap = new AddVipFrm();
            VipUsers vp = new VipUsers();
            vp.Id = (int)uiDataGridView1.SelectedRows[0].Cells["vid"].Value;
            vp.Name = uiDataGridView1.SelectedRows[0].Cells["vname"].Value.ToString();
            vp.Gender = uiDataGridView1.SelectedRows[0].Cells["vgender"].Value.ToString() == "男" ? false : true;
            vp.Phone = uiDataGridView1.SelectedRows[0].Cells["vphone"].Value.ToString();
            vp.VipId = (int)uiDataGridView1.SelectedRows[0].Cells["vcid"].Value;
            vp.EndDate = uiDataGridView1.SelectedRows[0].Cells["enddate"].Value.ToString();

            vap.VipUsers = vp;
            vap.ShowDialog();
            VipFrm_Load(null, null);
        }
    }
}
