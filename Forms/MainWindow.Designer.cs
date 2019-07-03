namespace lyric_matcher
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_search = new System.Windows.Forms.Button();
            this.button_match = new System.Windows.Forms.Button();
            this.checkBox_recursion = new System.Windows.Forms.CheckBox();
            this.checkBox_mergeTr = new System.Windows.Forms.CheckBox();
            this.checkBox_overWrite = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox_files = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.button_selectPath = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox_lyric = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button_search);
            this.flowLayoutPanel1.Controls.Add(this.button_match);
            this.flowLayoutPanel1.Controls.Add(this.checkBox_recursion);
            this.flowLayoutPanel1.Controls.Add(this.checkBox_mergeTr);
            this.flowLayoutPanel1.Controls.Add(this.checkBox_overWrite);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 417);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(468, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(3, 3);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 0;
            this.button_search.Text = "搜索";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.Button_search_Click);
            // 
            // button_match
            // 
            this.button_match.Location = new System.Drawing.Point(84, 3);
            this.button_match.Name = "button_match";
            this.button_match.Size = new System.Drawing.Size(75, 23);
            this.button_match.TabIndex = 1;
            this.button_match.Text = "批量匹配";
            this.button_match.UseVisualStyleBackColor = true;
            this.button_match.Click += new System.EventHandler(this.Button_match_Click);
            // 
            // checkBox_recursion
            // 
            this.checkBox_recursion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_recursion.AutoSize = true;
            this.checkBox_recursion.Checked = true;
            this.checkBox_recursion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_recursion.Enabled = false;
            this.checkBox_recursion.Location = new System.Drawing.Point(165, 3);
            this.checkBox_recursion.Name = "checkBox_recursion";
            this.checkBox_recursion.Size = new System.Drawing.Size(72, 23);
            this.checkBox_recursion.TabIndex = 2;
            this.checkBox_recursion.Text = "递归搜索";
            this.checkBox_recursion.UseVisualStyleBackColor = true;
            // 
            // checkBox_mergeTr
            // 
            this.checkBox_mergeTr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_mergeTr.AutoSize = true;
            this.checkBox_mergeTr.Checked = true;
            this.checkBox_mergeTr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_mergeTr.Location = new System.Drawing.Point(243, 3);
            this.checkBox_mergeTr.Name = "checkBox_mergeTr";
            this.checkBox_mergeTr.Size = new System.Drawing.Size(72, 23);
            this.checkBox_mergeTr.TabIndex = 3;
            this.checkBox_mergeTr.Text = "合并翻译";
            this.checkBox_mergeTr.UseVisualStyleBackColor = true;
            this.checkBox_mergeTr.CheckedChanged += new System.EventHandler(this.CheckBox_mergeTr_CheckedChanged);
            // 
            // checkBox_overWrite
            // 
            this.checkBox_overWrite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_overWrite.AutoSize = true;
            this.checkBox_overWrite.Location = new System.Drawing.Point(321, 3);
            this.checkBox_overWrite.Name = "checkBox_overWrite";
            this.checkBox_overWrite.Size = new System.Drawing.Size(144, 23);
            this.checkBox_overWrite.TabIndex = 4;
            this.checkBox_overWrite.Text = "覆盖已存在的歌词文件";
            this.checkBox_overWrite.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox_files);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 3);
            this.panel1.Size = new System.Drawing.Size(480, 450);
            this.panel1.TabIndex = 1;
            // 
            // listBox_files
            // 
            this.listBox_files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_files.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_files.FormattingEnabled = true;
            this.listBox_files.ItemHeight = 17;
            this.listBox_files.Location = new System.Drawing.Point(6, 35);
            this.listBox_files.Name = "listBox_files";
            this.listBox_files.Size = new System.Drawing.Size(468, 382);
            this.listBox_files.TabIndex = 2;
            this.listBox_files.SelectedIndexChanged += new System.EventHandler(this.ListBox_files_SelectedIndexChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.textBox_path);
            this.flowLayoutPanel2.Controls.Add(this.button_selectPath);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(468, 29);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(3, 3);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(423, 21);
            this.textBox_path.TabIndex = 0;
            // 
            // button_selectPath
            // 
            this.button_selectPath.Location = new System.Drawing.Point(432, 3);
            this.button_selectPath.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.button_selectPath.Name = "button_selectPath";
            this.button_selectPath.Size = new System.Drawing.Size(36, 23);
            this.button_selectPath.TabIndex = 1;
            this.button_selectPath.Text = "...";
            this.button_selectPath.UseVisualStyleBackColor = true;
            this.button_selectPath.Click += new System.EventHandler(this.Button_selectPath_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(480, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 450);
            this.panel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_lyric, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(9, 9);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(302, 199);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "歌名";
            this.columnHeader1.Width = 36;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "歌手";
            this.columnHeader2.Width = 36;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 226;
            // 
            // textBox_lyric
            // 
            this.textBox_lyric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_lyric.Location = new System.Drawing.Point(9, 214);
            this.textBox_lyric.Multiline = true;
            this.textBox_lyric.Name = "textBox_lyric";
            this.textBox_lyric.ReadOnly = true;
            this.textBox_lyric.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_lyric.Size = new System.Drawing.Size(302, 199);
            this.textBox_lyric.TabIndex = 2;
            this.textBox_lyric.WordWrap = false;
            this.textBox_lyric.TextChanged += new System.EventHandler(this.TextBox_lyric_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(9, 419);
            this.progressBar1.Maximum = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(302, 22);
            this.progressBar1.TabIndex = 3;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainWindow";
            this.Text = "歌词匹配器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Button button_match;
        private System.Windows.Forms.CheckBox checkBox_recursion;
        private System.Windows.Forms.CheckBox checkBox_mergeTr;
        private System.Windows.Forms.CheckBox checkBox_overWrite;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button button_selectPath;
        private System.Windows.Forms.ListBox listBox_files;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox textBox_lyric;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

