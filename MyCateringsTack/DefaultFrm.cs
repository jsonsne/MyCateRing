using BLL;
using MDL;
using Sunny.UI;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyCateringsTack
{
    public partial class DefaultFrm : UITitlePage
    {
        public DefaultFrm()
        {
            InitializeComponent();
        }

        private void DefaultFrm_Load(object sender, System.EventArgs e)
        {
            Maploop();
        }

        //生成房间餐桌
        private void Maploop()
        {
            List<RoomType> list = new BLL_RoomType().GetRoomTypes();
            foreach (var rt in list)
            {
                //获取房间名称并添加到选项卡中
                TabPage t = new TabPage();
                t.Text = rt.Name;
                t.Tag = rt;
                uiTabControl1.TabPages.Add(t);
                AddShowTable(t, rt.Id,99);
            }
        }

        private void AddShowTable(TabPage t, int rid,int state)
        {
            t.Controls.Clear();
            //添加每个房间中的餐桌
            ListView lv = new ListView();
            lv.MouseClick += Lv_MouseClick;
            lv.Dock = DockStyle.Fill;
            lv.Font = new System.Drawing.Font("微软雅黑", 12);
            lv.LargeImageList = this.imageList1;
            lv.SmallImageList = this.imageList2;

            List<Tables> tbs = new BLL_Tables().GetTables(rid, state);
            foreach (var item in tbs)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = item.Name;
                lvItem.ImageIndex = item.State;
                lvItem.Tag = item;
                lv.Items.Add(lvItem);
            }
            lv.Parent = t;
            t.Controls.Add(lv);
        }




        //右键菜单
        private void Lv_MouseClick(object sender, MouseEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count <= 0)
                return;
            TableEnum tEnum = (TableEnum)lv.SelectedItems[0].ImageIndex;
            switch (tEnum)
            {//ChangeMenuStrip(bool 开单, bool 消费, bool 结账, bool 换桌, string 状态, bool 可用, bool 占用, bool 停用, bool 预约)
                case TableEnum.可用:
                    ChangeMenuStrip(true, false, false, false, "可用", false, true, true, true);
                    break;
                case TableEnum.占用:
                    ChangeMenuStrip(false, true, true, true, "占用", true, false, true, true);
                    break;
                case TableEnum.停用:
                    ChangeMenuStrip(false, false, false, false, "停用", true, true, false, true);
                    break;
                case TableEnum.预约:
                    ChangeMenuStrip(true, false, false, false, "预约", true, true, true, false);
                    break;
            }
            lv.ContextMenuStrip = this.uiContextMenuStrip1;
        }

        public void ChangeMenuStrip(bool 开单, bool 消费, bool 结账, bool 换桌, string 状态, bool 可用, bool 占用, bool 停用, bool 预约)
        {
            顾客开单ToolStripMenuItem.Enabled = 开单;
            增加消费ToolStripMenuItem.Enabled = 消费;
            宾客结账ToolStripMenuItem.Enabled = 结账;
            换桌ToolStripMenuItem.Enabled = 换桌;
            当前状态ToolStripMenuItem.Text = "当前状态：" + 状态;
            改为停用ToolStripMenuItem.Enabled = 停用;
            改为占用ToolStripMenuItem.Enabled = 占用;
            改为可用ToolStripMenuItem.Enabled = 可用;
            改为预约ToolStripMenuItem.Enabled = 预约;
            当前状态ToolStripMenuItem.Enabled = false;
        }


        private void 改为可用ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            UpdateTableState((int)TableEnum.可用);
        }

        private void 改为占用ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            UpdateTableState((int)TableEnum.占用);
        }

        private void 改为停用ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            UpdateTableState((int)TableEnum.停用);
        }

        private void 改为预约ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            UpdateTableState((int)TableEnum.预约);
        }

        private void UpdateTableState(int num)
        {
            var lvi = uiTabControl1.SelectedTab.Controls[0] as ListView;
            if (lvi.SelectedItems.Count <= 0)
                return;
            Tables tb = (Tables)lvi.SelectedItems[0].Tag;
            tb.State = num;
            new BLL_Tables().UpdateTableNum(tb);
            lvi.SelectedItems[0].ImageIndex = num;         
        }





        private void uiComboBox1_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {
            switch (((UIComboBox)sender).Text)
            {
                case "大图标":
                    ShowListViewModel(0);
                    break;
                case "小图标":
                    ShowListViewModel(2);
                    break;
                case "显示可用":
                    ShowStateTable((int)TableEnum.可用);
                    break;
                case "显示占用":
                    ShowStateTable((int)TableEnum.占用);
                    break;
                case "显示停用":
                    ShowStateTable((int)TableEnum.停用);
                    break;
                case "显示预约":
                    ShowStateTable((int)TableEnum.预约);
                    break;
                case "显示全部":
                    ShowStateTable(99);
                    break;
                default:
                    break;
            }
        }

        //ListView显示方式
        private void ShowListViewModel(int num)
        {
            var tbs = uiTabControl1.TabPages;
            for (int i = 0; i < tbs.Count; i++)
            {
                ListView liv = tbs[i].Controls[0] as ListView;
                liv.View = (View)num;
            }
        }

        //显示不同状态的餐桌
        private void ShowStateTable(int num)
        {
            var tbs = uiTabControl1.TabPages;
            for(int i = 0; i < tbs.Count; i++)
            {
                int rid = ((RoomType)tbs[i].Tag).Id;
                AddShowTable(tbs[i], rid, num);
            }
        }

        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PagePanel_Click(object sender, System.EventArgs e)
        {

        }

        private void uiPanel1_Click(object sender, System.EventArgs e)
        {

        }

        private void uiContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void 顾客开单ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void 增加消费ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void 宾客结账ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void 餐桌状态ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void 当前状态ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void 换桌ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

      

        private void uiPanel2_Click(object sender, System.EventArgs e)
        {

        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
