using Sunny.UI;
using BLL;
using MDL;

namespace MyCateringsTack
{
    public partial class ProductFrm : UITitlePage
    {
        private const string V = "id";

        public ProductFrm()
        {
            InitializeComponent();
        }
        //事件加载
        private void ProductFrm_Load(object sender, System.EventArgs e)
        {
            uiDataGridView1.DataSource = new BLL_ProductTypes().GetProductTypes();
            uiDataGridView2.DataSource = new BLL_Products().GetProducts();
            uiComboBox1.DataSource = new BLL_ProductTypes().GetProductTypes();
            uiComboBox1.DisplayMember = "name";
            uiComboBox1.ValueMember = "id";
            uiComboBox1.Items.Add("全部");
        }
        //添加商品类型
        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            AddProductType ad = new AddProductType();
            ad.ShowDialog();
            ProductFrm_Load(null, null);
        }
        //商品类型修改
        private void uiButton2_Click(object sender, System.EventArgs e)
        {
            AddProductType ad = new AddProductType();
            ProductTypes pt = new ProductTypes();


            if (uiDataGridView1.SelectedRows.Count <= 0)
            {
                UIMessageTip.ShowError("请选择要修改的行数据");
                return;
            }
            pt.Id = (int)uiDataGridView1.SelectedRows[0].Cells["Id"].Value;
            pt.Name = uiDataGridView1.SelectedRows[0].Cells["sb"].Value.ToString();
            ad.Types = pt;
            ad.ShowDialog();
            ProductFrm_Load(null, null);
        }

        //删除
        private void uiButton3_Click(object sender, System.EventArgs e)
        {
            if (uiDataGridView1.SelectedRows.Count <= 0)
            {
                UIMessageTip.ShowError("请选择要修改的行数据");
                return;
            }

            if (System.Windows.Forms.MessageBox.Show("是否确认删除？", "系统提示", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;
            int id = (int)uiDataGridView1.SelectedRows[0].Cells["Id"].Value;
            bool bl = new BLL_ProductTypes().HasProduct(id);
            if (bl)
            {
                UIMessageTip.ShowError("该商品类型包含有商品不能删除！");
                return;
            }
            bl = new BLL_ProductTypes().DeleteTypes(id);
            if (bl)
            {
                UIMessageTip.ShowOk("删除成功！");
            }
            else
                UIMessageTip.ShowError("删除失败！");

            ProductFrm_Load(null, null);

        }
        //添加商品
        private void uiButton6_Click(object sender, System.EventArgs e)
        {
            AddProductInfoFrm info = new AddProductInfoFrm();
            info.ShowDialog();
            ProductFrm_Load(null, null);

        }
        //编辑商品
        private void uiButton5_Click(object sender, System.EventArgs e)
        {
            AddProductInfoFrm info = new AddProductInfoFrm();
            info.Txt = uiDataGridView2.SelectedRows[0].Cells["tname"].Value.ToString();

            Products p = new Products();
            p.Name = uiDataGridView2.SelectedRows[0].Cells["pname"].Value.ToString();
            p.JianPin = uiDataGridView2.SelectedRows[0].Cells["jianpin"].Value.ToString();
            p.Price = (double)uiDataGridView2.SelectedRows[0].Cells["price"].Value;
            p.PType = (int)uiDataGridView2.SelectedRows[0].Cells["ptype"].Value;
            p.State = (int)uiDataGridView2.SelectedRows[0].Cells["state"].Value;
            p.Id = (int)uiDataGridView2.SelectedRows[0].Cells["pid"].Value;
            // System.Windows.Forms.MessageBox.Show($"{p.Name},{p.JianPin},{p.PType},{p.Price},{p.State},{p.Id}");
            info.MyProperty = p;
            info.ShowDialog();
            ProductFrm_Load(null, null);

        }
        //删除商品
        private void uiButton4_Click(object sender, System.EventArgs e)
        {
            if (uiDataGridView1.SelectedRows.Count < 1)
            {
                UIMessageTip.ShowError("请选择要删除的行数据!");
                return;
            }
            if (System.Windows.Forms.MessageBox.Show("是否确认删除？", "系统提示", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            int id = (int)uiDataGridView2.SelectedRows[0].Cells["pid"].Value;
            bool bl = new BLL_Products().DeleteProduct(id);
            if (bl)
            {
                UIMessageTip.ShowOk("删除成功！");
            }
            else
                UIMessageTip.ShowError("删除失败！");

            ProductFrm_Load(null, null);

        }

        int pt = 0;
        string jinapin = "aa";
        //简拼查询
        private void uiTextBox1_TextChanged(object sender, System.EventArgs e)
        {
            jinapin = string.IsNullOrWhiteSpace(uiTextBox1.Text) ? "aa" : uiTextBox1.Text;
            if (uiComboBox1.Text == "全部")
            {
                uiDataGridView2.DataSource = new BLL_Products().GetProducts(0, jinapin);
                return;
            }
            pt = (int)uiComboBox1.SelectedValue;
            uiDataGridView2.DataSource = new BLL_Products().GetProducts(pt, jinapin);

        }

        private void uiComboBox1_SelectedValueChanged(object sender, System.EventArgs e)
        {
            jinapin = string.IsNullOrWhiteSpace(uiTextBox1.Text) ? "aa" : uiTextBox1.Text;

            if (uiComboBox1.Text == "全部")
            {
                uiDataGridView2.DataSource = new BLL_Products().GetProducts(0, jinapin);
                return;
            }

            pt = (int)uiComboBox1.SelectedValue;
            uiDataGridView2.DataSource = new BLL_Products().GetProducts(pt, jinapin);

        }
    }
}
