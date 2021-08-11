using Sunny.UI;
using BLL;
using MDL;
using System;

namespace MyCateringsTack
{
    public partial class RoomTableFrm : UITitlePage
    {
        public RoomTableFrm()
        {
            InitializeComponent();
        }
        public RoomTableFrm(DefaultFrm frm) : base()
        {
            InitializeComponent();
            frm1 = frm;
        }
        DefaultFrm frm1;

        //房间餐桌加载事件
        private void RoomTableFrm_Load(object sender, System.EventArgs e)
        {
            var list = new BLL_RoomType().GetRoomTypes();
            uiDataGridView1.DataSource = list;
            uiDataGridView2.DataSource = new BLL_Tables().GetRommTypes(null);
            uiComboBox1.DataSource = list;
            uiComboBox1.DisplayMember = "name";
            uiComboBox1.ValueMember = "id";
            uiComboBox1.Items.Add("全部");


            uiDataGridView1.SelectedIndex = 0;
            uiDataGridView2.SelectedIndex = 0;


        }

        //根据房间类型筛选出餐桌

        private void uiComboBox1_SelectedValueChanged(object sender, System.EventArgs e)
        {
            var text = uiComboBox1.Text;
            var list = new BLL_Tables().GetRommTypes(text);
            uiDataGridView2.DataSource = list;
        }

        private void uiButton3_Click(object sender, System.EventArgs e)
        {
            AddRommType r = new AddRommType();
            r.ShowDialog();
            RoomTableFrm_Load(null, null);
            frm1.DefaultFrm_Load(null, null);
        }

        //编辑房间类型
        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            if (uiDataGridView1.SelectedRows.Count <= 0)
            {
                UIMessageTip.ShowError("请选择要编辑行数据！");
                return;
            }
            RoomType rt = new RoomType();
            int index = uiDataGridView1.SelectedIndex;
            rt.Id = (int)uiDataGridView1.Rows[index].Cells["rid"].Value;
            rt.Name = uiDataGridView1.Rows[index].Cells["name"].Value.ToString();
            rt.MinConst = (double)uiDataGridView1.Rows[index].Cells["minConst"].Value;
            rt.MaxRenshu = (int)uiDataGridView1.Rows[index].Cells["maxRenshu"].Value;
            rt.Area = uiDataGridView1.Rows[index].Cells["area"].Value.ToString();
            rt.IsZheKou = (bool)uiDataGridView1.Rows[index].Cells["isZheKou"].Value;

            AddRommType addRommType = new AddRommType();
            addRommType.MyroomType = rt;
            addRommType.ShowDialog();

            RoomTableFrm_Load(null, null);
            Program.frm.DefaultFrm_Load(null, null);
        }

        //删除房间类型
        private void uiButton2_Click(object sender, System.EventArgs e)
        {
            if (uiDataGridView1.SelectedRows.Count <= 0)
            {
                UIMessageTip.ShowError("请选择要删除行数据！");
                return;
            }
            int index = (int)uiDataGridView1.SelectedRows[0].Cells["rid"].Value;
            bool bl = new BLL_RoomType().GetRomCount(index);
            if (bl)
            {
                UIMessageTip.ShowError("该房间类型包含餐桌不能删除！");
                return;
            }
            if (System.Windows.Forms.MessageBox.Show("是否确认删除？", "系统提示", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            bl = new BLL_RoomType().DeleteRoom(index);
            if (bl)
                UIMessageTip.ShowOk("删除房间类型成功！");
            else
                UIMessageTip.ShowError("删除房间类型失败！");
            RoomTableFrm_Load(null, null);
            frm1.DefaultFrm_Load(null, null);
        }

        //添加餐桌
        private void uiButton6_Click(object sender, System.EventArgs e)
        {
            UpdateTable up = new UpdateTable();
            up.ShowDialog();
            RoomTableFrm_Load(null, null);

        }

        //批量添加餐桌
        private void uiButton7_Click(object sender, System.EventArgs e)
        {
            PiAddTables pa = new PiAddTables();
            pa.ShowDialog();
            RoomTableFrm_Load(null, null);
        }

        //修改餐桌
        private void uiButton4_Click(object sender, System.EventArgs e)
        {
            UpdateTable up = new UpdateTable();
            Tables t = new Tables();
            int id = (int)uiDataGridView2.SelectedRows[0].Cells["id"].Value;
            t = new BLL_Tables().GetTable(id);
            //t.Id = (int)uiDataGridView2.SelectedRows[0].Cells["id"].Value;
            //t.Rid = (int)uiDataGridView2.SelectedRows[0].Cells["rtId"].Value;
            //t.RName = uiDataGridView2.SelectedRows[0].Cells["rname"].Value.ToString();
            //t.TName = uiDataGridView2.SelectedRows[0].Cells["tName"].Value.ToString();
            //t.Sts = (int)Enum.Parse(typeof(TableEnum), uiDataGridView2.SelectedRows[0].Cells["state"].Value.ToString());
            //up.MyTables = new BLL_Tables().GetTable(id);

            up.MyTables = t;
            up.Txt = uiDataGridView2.SelectedRows[0].Cells["tName"].Value.ToString();
            up.ShowDialog();
            RoomTableFrm_Load(null, null);
        }

        //删除餐桌
        private void uiButton5_Click(object sender, System.EventArgs e)
        {
            int index = (int)uiDataGridView2.SelectedRows[0].Cells["id "].Value;

            string state = new BLL_Tables().GetTableState(index);

            if (state == TableEnum.占用.ToString())
            {
                UIMessageTip.ShowError("该餐桌正在使用中，不允许删除！");
                return;
            }

            if (System.Windows.Forms.MessageBox.Show("是否确认删除？", "系统提示", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;
            bool bl = new BLL_Tables().DeleteTableNuM(index);
            if (bl)
                UIMessageTip.ShowOk("删除成功！");
            else
                UIMessageTip.ShowError("删除失败！");
            RoomTableFrm_Load(null, null);

        }
    }
}
