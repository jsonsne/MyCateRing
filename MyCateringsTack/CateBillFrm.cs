using BLL;
using Sunny.UI;

namespace MyCateringsTack
{
    public partial class CateBillFrm : UITitlePage
    {
        public delegate void ReSetWinfrom();
        public event ReSetWinfrom Myevet3;
        public CateBillFrm()
        {
            InitializeComponent();
            Myevet3 += ShowData;
        }
        public void ShowEvent()
        {
            if (Myevet3 != null)
                Myevet3.Invoke();
        }
        public void ShowData()
        {
            comboBox1.SelectedIndex = 0;
            uiDataGridView1.DataSource = new BLL_Tables().GetConSums();
        }
        private void CateBillFrm_Load(object sender, System.EventArgs e)
        {
            ShowEvent();
        }

        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                uiDataGridView1.DataSource = new BLL_Tables().GetConSums();
            }
            if (comboBox1.SelectedIndex == 0)
            {
                uiDataGridView1.DataSource = new BLL_Tables().GetConSums(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"), dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss"), textBox1.Text);
            }
            else
            {
                uiDataGridView1.DataSource = new BLL_Tables().GetConSums(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"), dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss"), null, textBox1.Text);
            }
        }
    }
}
