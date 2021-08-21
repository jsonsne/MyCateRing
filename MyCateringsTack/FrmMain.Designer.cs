
namespace MyCateringsTack
{
    partial class FrmMain
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
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("餐饮首页");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("消费查询");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("账单查询");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("营业查询", new System.Windows.Forms.TreeNode[] {
            treeNode34,
            treeNode35});
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("会员管理");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("房间餐台设置");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("商品管理");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("系统管理");
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLinkLabel1 = new Sunny.UI.UILinkLabel();
            this.lbldate = new Sunny.UI.UILabel();
            this.Header.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Aside
            // 
            this.Aside.LineColor = System.Drawing.Color.Black;
            this.Aside.Location = new System.Drawing.Point(0, 98);
            treeNode33.Name = "节点0";
            treeNode33.Text = "餐饮首页";
            treeNode34.Name = "节点6";
            treeNode34.Text = "消费查询";
            treeNode35.Name = "节点7";
            treeNode35.Text = "账单查询";
            treeNode36.Name = "节点1";
            treeNode36.Text = "营业查询";
            treeNode37.Name = "节点2";
            treeNode37.Text = "会员管理";
            treeNode38.Name = "节点3";
            treeNode38.Text = "房间餐台设置";
            treeNode39.Name = "节点4";
            treeNode39.Text = "商品管理";
            treeNode40.Name = "节点5";
            treeNode40.Text = "系统管理";
            this.Aside.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode33,
            treeNode36,
            treeNode37,
            treeNode38,
            treeNode39,
            treeNode40});
            this.Aside.Size = new System.Drawing.Size(250, 630);
            this.Aside.Style = Sunny.UI.UIStyle.Custom;
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Header.Controls.Add(this.uiPanel1);
            this.Header.Controls.Add(this.uiLabel1);
            this.Header.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.Header.Size = new System.Drawing.Size(1100, 63);
            this.Header.Style = Sunny.UI.UIStyle.Custom;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("楷体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Location = new System.Drawing.Point(3, 2);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(237, 58);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "CateRing";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.lbldate);
            this.uiPanel1.Controls.Add(this.uiLinkLabel1);
            this.uiPanel1.Controls.Add(this.uiLabel3);
            this.uiPanel1.Controls.Add(this.uiLabel2);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiPanel1.FillColor = System.Drawing.Color.Transparent;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(693, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.uiPanel1.Size = new System.Drawing.Size(407, 63);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel1.StyleCustomMode = true;
            this.uiPanel1.TabIndex = 1;
            this.uiPanel1.Text = null;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.ForeColor = System.Drawing.Color.Red;
            this.uiLabel2.Location = new System.Drawing.Point(164, 24);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(71, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 0;
            this.uiLabel2.Text = "欢迎：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.Red;
            this.uiLabel3.Location = new System.Drawing.Point(219, 25);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(71, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 0;
            this.uiLabel3.Text = "Admin";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLinkLabel1
            // 
            this.uiLinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.uiLinkLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLinkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.uiLinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.uiLinkLabel1.LinkColor = System.Drawing.Color.Yellow;
            this.uiLinkLabel1.Location = new System.Drawing.Point(343, 25);
            this.uiLinkLabel1.Name = "uiLinkLabel1";
            this.uiLinkLabel1.Size = new System.Drawing.Size(61, 23);
            this.uiLinkLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLinkLabel1.TabIndex = 1;
            this.uiLinkLabel1.TabStop = true;
            this.uiLinkLabel1.Text = "注销";
            this.uiLinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiLinkLabel1.Click += new System.EventHandler(this.uiLinkLabel1_Click);
            // 
            // lbldate
            // 
            this.lbldate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbldate.ForeColor = System.Drawing.Color.Lime;
            this.lbldate.Location = new System.Drawing.Point(121, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(286, 23);
            this.lbldate.Style = Sunny.UI.UIStyle.Custom;
            this.lbldate.TabIndex = 2;
            this.lbldate.Text = "uiLabel4";
            this.lbldate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 728);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 726);
            this.Name = "FrmMain";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Style = Sunny.UI.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Header.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILinkLabel uiLinkLabel1;
        private Sunny.UI.UILabel lbldate;
    }
}