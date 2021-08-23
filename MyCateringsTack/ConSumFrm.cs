using BLL;
using Sunny.UI;

namespace MyCateringsTack
{
    public partial class ConSumFrm : UITitlePage
    {
        public delegate void ReSetWinfrom();
        public event ReSetWinfrom Myevet3;
        public ConSumFrm()
        {
            InitializeComponent();
            Myevet3 += ShowData;
        }
        public void ShowEvenet()
        {
            if (Myevet3 != null)
                Myevet3.Invoke();
        }
        private void ConSumFrm_Load(object sender, System.EventArgs e)
        {
            ShowEvenet();
        }

        public void ShowData()
        {
            uiComboBox1.DataSource = new BLL_AdUsers().GetUsers();
            uiComboBox1.DisplayMember = "usCode";
            uiComboBox1.ValueMember = "id";
            uiComboBox1.Items.Add("查询所有");
            uiComboBox1.Text = "查询所有";
            uiDataGridView1.DataSource = new BLL_CaterBill().GetConSums();
        }

        private void uiDataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (uiDataGridView1.SelectedRows.Count <= 0)
                return;
            int index = uiDataGridView1.CurrentCell.RowIndex;
            string bid = (string)uiDataGridView1.Rows[index].Cells["bid"].Value;
            uiDataGridView2.DataSource = new BLL_CaterBill().GetConSumsDetails(bid);
        }

        //查询
        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            string adus = uiComboBox1.Text == "查询所有" ? null : uiComboBox1.Text;

            uiDataGridView1.DataSource = new BLL_CaterBill().GetConSums(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss"), adus, textBox1.Text);
        }
    }
}
