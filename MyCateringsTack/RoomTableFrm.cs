using Sunny.UI;
using BLL;
namespace MyCateringsTack
{
    public partial class RoomTableFrm : UITitlePage
    {
        public RoomTableFrm()
        {
            InitializeComponent();
        }

        //房间餐桌加载事件
        private void RoomTableFrm_Load(object sender, System.EventArgs e)
        {
            var list= new BLL_RoomType().GetRoomTypes();
            uiDataGridView1.DataSource = list;
            uiDataGridView2.DataSource = new BLL_Tables().GetTables();
            uiComboBox1.DataSource = list;
            uiComboBox1.DisplayMember = "name";
            uiComboBox1.ValueMember = "id";
        }

        //显示房间类型


        //显示房间餐桌


        //根据房间类型筛选出餐桌

        private void uiComboBox1_SelectedValueChanged(object sender, System.EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(uiComboBox1.Text);
        }








    }
}
