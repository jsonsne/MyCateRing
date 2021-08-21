using BLL;
using Sunny.UI;
using MDL;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Linq;

namespace MyCateringsTack
{
    public partial class AddOrderFrm : UIForm
    {
        public AddOrderFrm()
        {
            InitializeComponent();
        }
        public int TableId { get; set; }

        //加载事件
        private void AddOrderFrm_Load(object sender, System.EventArgs e)
        {
            List<ProductTypes> types = new BLL_ProductTypes().GetProductTypes();
            dataGridView2.DataSource = new BLL_Products().GetProducts();
            CaterBill cater = new BLL_CaterBill().GetCater(TableId);
            List<CaterDetail> cas = new BLL_CaterDetail().GetCaters(TableId);
            dataGridView1.DataSource = cas;
            uiLabel6.Text = cater.Id;
            Uilabsumprice(cas);
            AddTypes(types);
        }

        private void Uilabsumprice(List<CaterDetail> cas)
        {
            uiLabel9.Text = cas.Count.ToString();
            uiLabel10.Text = cas.Select(c => c.SumPrice).Sum().ToString();
        }

        //添加项目类别
        private void AddTypes(List<ProductTypes> list)
        {
            foreach (var item in list)
            {
                TreeNode node = new TreeNode();
                node.Text = item.Name;
                node.Tag = item.Id;
                uiTreeView1.Nodes.Add(node);
                List<Products> pdList = new BLL_Products().GetProducts(item.Id);
                AddChildTypes(pdList, node);
            }
        }
        //添加项目子项目
        private void AddChildTypes(List<Products> list, TreeNode node)
        {
            foreach (var item in list)
            {
                TreeNode tree = new TreeNode();
                tree.Tag = item;
                tree.Text = item.Name;
                node.Nodes.Add(tree);
            }
        }
        private List<int> DetailsIds = new List<int>();
        private bool IsXiadan = false;
        //添加菜品
        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            CaterDetail cd = new CaterDetail();
            if (string.IsNullOrWhiteSpace(uiTextBox2.Text))
            {
                UIMessageTip.ShowError("数量不能为空!");
                return;
            }
            if (tabControl1.SelectedIndex == 0)
            {
                //MessageBox.Show("datagrid");
                int index = dataGridView2.CurrentCell.RowIndex;
                cd.BiiId = uiLabel6.Text;
                cd.Pid = (int)dataGridView2.Rows[index].Cells["id"].Value;
                cd.Pname = dataGridView2.Rows[index].Cells["pname"].Value.ToString();
                cd.Tname = dataGridView2.Rows[index].Cells["tname"].Value.ToString();
                cd.costType = (int)dataGridView2.Rows[index].Cells["ptid"].Value;
                cd.Price = (double)dataGridView2.Rows[index].Cells["pprice"].Value;
                cd.Pcount = int.Parse(uiTextBox2.Text);
                cd.SumPrice = cd.Pcount * cd.Price;
                cd.FinishDate = DateTime.Now.ToString("yyyy-MM-dd");

                int n = new BLL_CaterDetail().AddCaterDetail(cd);
                DetailsIds.Add(n);
            }
            else
            {
                TreeNode node = uiTreeView1.SelectedNode;
                Products ps = node.Tag as Products;
                if (ps == null)
                {
                    UIMessageTip.ShowError("请选择具体的商品！");
                    return;
                }
                cd.BiiId = uiLabel6.Text;
                cd.Pid = ps.Id;
                cd.Pname = ps.Name;
                cd.Tname = ps.TypeName;
                cd.costType = ps.PType;
                cd.Price = ps.Price;
                cd.Pcount = int.Parse(uiTextBox2.Text);
                cd.SumPrice = cd.Pcount * cd.Price;
                cd.FinishDate = DateTime.Now.ToString("yyyy-MM-dd");

                int n = new BLL_CaterDetail().AddCaterDetail(cd);
                DetailsIds.Add(n);
            }
            List<CaterDetail> cas = new BLL_CaterDetail().GetCaters(TableId);
            dataGridView1.DataSource = cas;
            Uilabsumprice(cas);
        }

        //下单
        private void uiButton3_Click(object sender, EventArgs e)
        {
            IsXiadan = true;
            this.Close();
        }

        private void AddOrderFrm_FormClosing(object sender, FormClosingEventArgs e)
        {

            //新增的菜品进行删除

            if (!IsXiadan)
            {
                var de = new BLL_CaterDetail();
                foreach (var item in DetailsIds)
                {
                    de.DeleteDetail(item);
                }
            }
            IsXiadan = false;

        }

        //退菜
        private void uiButton4_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            if (index < 0)
                return;
            int id = (int)dataGridView1.Rows[index].Cells["id2"].Value;
            new BLL_CaterDetail().DeleteDetail(id);
            List<CaterDetail> cas = new BLL_CaterDetail().GetCaters(TableId);
            dataGridView1.DataSource = cas;
            Uilabsumprice(cas);
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            if (index > 0)
            {
                string name = dataGridView2.Rows[index].Cells["pname"].Value.ToString();
                uiLabel2.Text = name;
            }

        }

        private void uiTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Products ps = e.Node.Tag as Products;
            if (ps != null)
                uiLabel2.Text = ps.Name;
        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {

            dataGridView2.DataSource = new BLL_Products().GetProducts(0, uiTextBox1.Text);
        }
    }
}
