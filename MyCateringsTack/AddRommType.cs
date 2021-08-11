using MDL;
using BLL;
using Sunny.UI;

namespace MyCateringsTack
{
    public partial class AddRommType : UIForm
    {
        public AddRommType()
        {
            InitializeComponent();
        }

        public RoomType MyroomType { get; set; }

        private void uiButton2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        //保存数据
        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            //RoomType r = new RoomType();
            if (MyroomType == null)
                MyroomType = new RoomType();
            MyroomType.Name = uiTextBox1.Text;
            MyroomType.MinConst = double.Parse(uiTextBox2.Text);
            MyroomType.MaxRenshu = int.Parse(uiTextBox3.Text);
            MyroomType.Area = uiTextBox4.Text;
            MyroomType.IsZheKou = uiCheckBox1.Checked;

            bool bl = new BLL_RoomType().UpdateRoomtype(MyroomType);
            if (bl)
                UIMessageTip.ShowOk("更新数据成功！");
            else
                UIMessageTip.ShowError("更新数据失败！");

            this.Close();

        }

        //事件加载
        private void AddRommType_Load(object sender, System.EventArgs e)
        {
            if (MyroomType != null)
            {
                uiTextBox1.Text = MyroomType.Name;
                uiTextBox2.Text = MyroomType.MinConst.ToString();
                uiTextBox3.Text = MyroomType.MaxRenshu.ToString();
                uiTextBox4.Text = MyroomType.Area;
                uiCheckBox1.Checked = MyroomType.IsZheKou;
            }
        }
    }
}
