
namespace MyCateringsTack
{
    partial class DefaultFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.顾客开单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加消费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.宾客结账ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.餐桌状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当前状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.改为可用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.改为占用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.改为停用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.改为预约ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.换桌ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiComboBox2 = new Sunny.UI.UIComboBox();
            this.uiComboBox1 = new Sunny.UI.UIComboBox();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.PagePanel.SuspendLayout();
            this.uiContextMenuStrip1.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.uiPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // PagePanel
            // 
            this.PagePanel.Controls.Add(this.uiPanel2);
            this.PagePanel.Controls.Add(this.uiPanel1);
            this.PagePanel.Controls.Add(this.uiTabControl1);
            this.PagePanel.Size = new System.Drawing.Size(800, 515);
            this.PagePanel.Click += new System.EventHandler(this.PagePanel_Click);
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(800, 295);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "可用.png");
            this.imageList1.Images.SetKeyName(1, "使用中.png");
            this.imageList1.Images.SetKeyName(2, "停用.png");
            this.imageList1.Images.SetKeyName(3, "预约.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "可用.png");
            this.imageList2.Images.SetKeyName(1, "使用中.png");
            this.imageList2.Images.SetKeyName(2, "停用.png");
            this.imageList2.Images.SetKeyName(3, "预约.png");
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.顾客开单ToolStripMenuItem,
            this.增加消费ToolStripMenuItem,
            this.宾客结账ToolStripMenuItem,
            this.餐桌状态ToolStripMenuItem,
            this.换桌ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(145, 134);
            this.uiContextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.uiContextMenuStrip1_Opening);
            // 
            // 顾客开单ToolStripMenuItem
            // 
            this.顾客开单ToolStripMenuItem.Name = "顾客开单ToolStripMenuItem";
            this.顾客开单ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.顾客开单ToolStripMenuItem.Text = "顾客开单";
            this.顾客开单ToolStripMenuItem.Click += new System.EventHandler(this.顾客开单ToolStripMenuItem_Click);
            // 
            // 增加消费ToolStripMenuItem
            // 
            this.增加消费ToolStripMenuItem.Name = "增加消费ToolStripMenuItem";
            this.增加消费ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.增加消费ToolStripMenuItem.Text = "增加消费";
            this.增加消费ToolStripMenuItem.Click += new System.EventHandler(this.增加消费ToolStripMenuItem_Click);
            // 
            // 宾客结账ToolStripMenuItem
            // 
            this.宾客结账ToolStripMenuItem.Name = "宾客结账ToolStripMenuItem";
            this.宾客结账ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.宾客结账ToolStripMenuItem.Text = "宾客结账";
            this.宾客结账ToolStripMenuItem.Click += new System.EventHandler(this.宾客结账ToolStripMenuItem_Click);
            // 
            // 餐桌状态ToolStripMenuItem
            // 
            this.餐桌状态ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.当前状态ToolStripMenuItem,
            this.改为可用ToolStripMenuItem,
            this.改为占用ToolStripMenuItem,
            this.改为停用ToolStripMenuItem,
            this.改为预约ToolStripMenuItem});
            this.餐桌状态ToolStripMenuItem.Name = "餐桌状态ToolStripMenuItem";
            this.餐桌状态ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.餐桌状态ToolStripMenuItem.Text = "餐桌状态";
            this.餐桌状态ToolStripMenuItem.Click += new System.EventHandler(this.餐桌状态ToolStripMenuItem_Click);
            // 
            // 当前状态ToolStripMenuItem
            // 
            this.当前状态ToolStripMenuItem.Name = "当前状态ToolStripMenuItem";
            this.当前状态ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.当前状态ToolStripMenuItem.Text = "当前状态";
            this.当前状态ToolStripMenuItem.Click += new System.EventHandler(this.当前状态ToolStripMenuItem_Click);
            // 
            // 改为可用ToolStripMenuItem
            // 
            this.改为可用ToolStripMenuItem.Name = "改为可用ToolStripMenuItem";
            this.改为可用ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.改为可用ToolStripMenuItem.Text = "改为可用";
            this.改为可用ToolStripMenuItem.Click += new System.EventHandler(this.改为可用ToolStripMenuItem_Click);
            // 
            // 改为占用ToolStripMenuItem
            // 
            this.改为占用ToolStripMenuItem.Name = "改为占用ToolStripMenuItem";
            this.改为占用ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.改为占用ToolStripMenuItem.Text = "改为占用";
            this.改为占用ToolStripMenuItem.Click += new System.EventHandler(this.改为占用ToolStripMenuItem_Click);
            // 
            // 改为停用ToolStripMenuItem
            // 
            this.改为停用ToolStripMenuItem.Name = "改为停用ToolStripMenuItem";
            this.改为停用ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.改为停用ToolStripMenuItem.Text = "改为停用";
            this.改为停用ToolStripMenuItem.Click += new System.EventHandler(this.改为停用ToolStripMenuItem_Click);
            // 
            // 改为预约ToolStripMenuItem
            // 
            this.改为预约ToolStripMenuItem.Name = "改为预约ToolStripMenuItem";
            this.改为预约ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.改为预约ToolStripMenuItem.Text = "改为预约";
            this.改为预约ToolStripMenuItem.Click += new System.EventHandler(this.改为预约ToolStripMenuItem_Click);
            // 
            // 换桌ToolStripMenuItem
            // 
            this.换桌ToolStripMenuItem.Name = "换桌ToolStripMenuItem";
            this.换桌ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.换桌ToolStripMenuItem.Text = "换桌";
            this.换桌ToolStripMenuItem.Click += new System.EventHandler(this.换桌ToolStripMenuItem_Click);
            // 
            // uiPanel1
            // 
            this.uiPanel1.BackColor = System.Drawing.Color.Transparent;
            this.uiPanel1.Controls.Add(this.uiComboBox2);
            this.uiPanel1.Controls.Add(this.uiComboBox1);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel1.FillColor = System.Drawing.Color.Gray;
            this.uiPanel1.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(0, 295);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.RectColor = System.Drawing.Color.Transparent;
            this.uiPanel1.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.uiPanel1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanel1.Size = new System.Drawing.Size(800, 43);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel1.StyleCustomMode = true;
            this.uiPanel1.TabIndex = 1;
            this.uiPanel1.Text = null;
            this.uiPanel1.Click += new System.EventHandler(this.uiPanel1_Click);
            // 
            // uiComboBox2
            // 
            this.uiComboBox2.BackColor = System.Drawing.Color.Transparent;
            this.uiComboBox2.FillColor = System.Drawing.Color.Gray;
            this.uiComboBox2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiComboBox2.Items.AddRange(new object[] {
            "显示可用",
            "显示占用",
            "显示停用",
            "显示预约",
            "显示全部"});
            this.uiComboBox2.Location = new System.Drawing.Point(4, 6);
            this.uiComboBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox2.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox2.Name = "uiComboBox2";
            this.uiComboBox2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.uiComboBox2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiComboBox2.Size = new System.Drawing.Size(104, 29);
            this.uiComboBox2.Style = Sunny.UI.UIStyle.Custom;
            this.uiComboBox2.StyleCustomMode = true;
            this.uiComboBox2.TabIndex = 0;
            this.uiComboBox2.Text = "过滤条件";
            this.uiComboBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox2.SelectedIndexChanged += new System.EventHandler(this.uiComboBox1_SelectedIndexChanged_1);
            // 
            // uiComboBox1
            // 
            this.uiComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiComboBox1.FillColor = System.Drawing.Color.Gray;
            this.uiComboBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiComboBox1.Items.AddRange(new object[] {
            "大图标",
            "小图标"});
            this.uiComboBox1.Location = new System.Drawing.Point(116, 6);
            this.uiComboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox1.Name = "uiComboBox1";
            this.uiComboBox1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.uiComboBox1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiComboBox1.Size = new System.Drawing.Size(113, 29);
            this.uiComboBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiComboBox1.StyleCustomMode = true;
            this.uiComboBox1.TabIndex = 0;
            this.uiComboBox1.Text = "显示方式";
            this.uiComboBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox1.SelectedIndexChanged += new System.EventHandler(this.uiComboBox1_SelectedIndexChanged_1);
            // 
            // uiPanel2
            // 
            this.uiPanel2.Controls.Add(this.uiDataGridView1);
            this.uiPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel2.Location = new System.Drawing.Point(0, 338);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(800, 177);
            this.uiPanel2.TabIndex = 2;
            this.uiPanel2.Text = "uiPanel2";
            this.uiPanel2.Click += new System.EventHandler(this.uiPanel2_Click);
            // 
            // uiDataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.uiDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.uiDataGridView1.Name = "uiDataGridView1";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.uiDataGridView1.RowTemplate.Height = 29;
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.ShowGridLine = true;
            this.uiDataGridView1.Size = new System.Drawing.Size(800, 177);
            this.uiDataGridView1.TabIndex = 0;
            this.uiDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiDataGridView1_CellContentClick);
            // 
            // DefaultFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Name = "DefaultFrm";
            this.StyleCustomMode = true;
            this.Text = "餐饮首页";
            this.Load += new System.EventHandler(this.DefaultFrm_Load);
            this.Controls.SetChildIndex(this.PagePanel, 0);
            this.PagePanel.ResumeLayout(false);
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 顾客开单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加消费ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 宾客结账ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 餐桌状态ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 当前状态ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 改为可用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 改为占用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 改为停用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 改为预约ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 换桌ToolStripMenuItem;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIComboBox uiComboBox2;
        private Sunny.UI.UIComboBox uiComboBox1;
    }
}