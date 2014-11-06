namespace armsim
{
    partial class ui
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFile_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.reset_strip = new System.Windows.Forms.ToolStripMenuItem();
            this.step_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.run_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.stop_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.tracing_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer10 = new System.Windows.Forms.SplitContainer();
            this.flag_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.address_box = new System.Windows.Forms.TextBox();
            this.address_Btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.log_check = new System.Windows.Forms.CheckBox();
            this.step_Btn = new System.Windows.Forms.Button();
            this.run_Btn = new System.Windows.Forms.Button();
            this.stop_Btn = new System.Windows.Forms.Button();
            this.reset_Btn = new System.Windows.Forms.Button();
            this.exit_Btn = new System.Windows.Forms.Button();
            this.file_Bx = new System.Windows.Forms.TextBox();
            this.splitContainer11 = new System.Windows.Forms.SplitContainer();
            this.splitContainer12 = new System.Windows.Forms.SplitContainer();
            this.data_box = new System.Windows.Forms.TextBox();
            this.tabs_page = new System.Windows.Forms.TabControl();
            this.memory_page = new System.Windows.Forms.TabPage();
            this.memory_Grid = new System.Windows.Forms.DataGridView();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ascii = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terminal_page = new System.Windows.Forms.TabPage();
            this.terminal_box = new System.Windows.Forms.TextBox();
            this.stack_page = new System.Windows.Forms.TabPage();
            this.stack_grid = new System.Windows.Forms.DataGridView();
            this.addr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.word1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.word2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.word3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.word4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regData_grid = new System.Windows.Forms.DataGridView();
            this.registers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).BeginInit();
            this.splitContainer10.Panel1.SuspendLayout();
            this.splitContainer10.Panel2.SuspendLayout();
            this.splitContainer10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).BeginInit();
            this.splitContainer11.Panel1.SuspendLayout();
            this.splitContainer11.Panel2.SuspendLayout();
            this.splitContainer11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer12)).BeginInit();
            this.splitContainer12.Panel1.SuspendLayout();
            this.splitContainer12.Panel2.SuspendLayout();
            this.splitContainer12.SuspendLayout();
            this.tabs_page.SuspendLayout();
            this.memory_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memory_Grid)).BeginInit();
            this.terminal_page.SuspendLayout();
            this.stack_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stack_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regData_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(829, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFile_menu,
            this.reset_strip,
            this.step_menu,
            this.run_menu,
            this.stop_menu,
            this.tracing_menu,
            this.closeToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // loadFile_menu
            // 
            this.loadFile_menu.Name = "loadFile_menu";
            this.loadFile_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadFile_menu.Size = new System.Drawing.Size(164, 22);
            this.loadFile_menu.Text = "Load File";
            this.loadFile_menu.Click += new System.EventHandler(this.loadFile_menu_Click_1);
            // 
            // reset_strip
            // 
            this.reset_strip.Name = "reset_strip";
            this.reset_strip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.reset_strip.Size = new System.Drawing.Size(164, 22);
            this.reset_strip.Text = "Reset";
            this.reset_strip.Click += new System.EventHandler(this.reset_strip_Click);
            // 
            // step_menu
            // 
            this.step_menu.Name = "step_menu";
            this.step_menu.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.step_menu.Size = new System.Drawing.Size(164, 22);
            this.step_menu.Text = "Step";
            // 
            // run_menu
            // 
            this.run_menu.Name = "run_menu";
            this.run_menu.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.run_menu.Size = new System.Drawing.Size(164, 22);
            this.run_menu.Text = "Run";
            this.run_menu.Click += new System.EventHandler(this.run_menu_Click);
            // 
            // stop_menu
            // 
            this.stop_menu.Name = "stop_menu";
            this.stop_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.stop_menu.Size = new System.Drawing.Size(164, 22);
            this.stop_menu.Text = "Stop";
            this.stop_menu.Click += new System.EventHandler(this.stop_menu_Click);
            // 
            // tracing_menu
            // 
            this.tracing_menu.Name = "tracing_menu";
            this.tracing_menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.tracing_menu.Size = new System.Drawing.Size(164, 22);
            this.tracing_menu.Text = "Tracing";
            this.tracing_menu.Click += new System.EventHandler(this.tracing_menu_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // splitContainer10
            // 
            this.splitContainer10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer10.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer10.Location = new System.Drawing.Point(0, 24);
            this.splitContainer10.Name = "splitContainer10";
            // 
            // splitContainer10.Panel1
            // 
            this.splitContainer10.Panel1.Controls.Add(this.flag_box);
            this.splitContainer10.Panel1.Controls.Add(this.label1);
            this.splitContainer10.Panel1.Controls.Add(this.address_box);
            this.splitContainer10.Panel1.Controls.Add(this.address_Btn);
            this.splitContainer10.Panel1.Controls.Add(this.textBox1);
            this.splitContainer10.Panel1.Controls.Add(this.log_check);
            this.splitContainer10.Panel1.Controls.Add(this.step_Btn);
            this.splitContainer10.Panel1.Controls.Add(this.run_Btn);
            this.splitContainer10.Panel1.Controls.Add(this.stop_Btn);
            this.splitContainer10.Panel1.Controls.Add(this.reset_Btn);
            this.splitContainer10.Panel1.Controls.Add(this.exit_Btn);
            this.splitContainer10.Panel1.Controls.Add(this.file_Bx);
            // 
            // splitContainer10.Panel2
            // 
            this.splitContainer10.Panel2.Controls.Add(this.splitContainer11);
            this.splitContainer10.Size = new System.Drawing.Size(829, 347);
            this.splitContainer10.SplitterDistance = 104;
            this.splitContainer10.TabIndex = 1;
            // 
            // flag_box
            // 
            this.flag_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flag_box.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flag_box.Location = new System.Drawing.Point(0, 37);
            this.flag_box.Multiline = true;
            this.flag_box.Name = "flag_box";
            this.flag_box.ReadOnly = true;
            this.flag_box.Size = new System.Drawing.Size(104, 119);
            this.flag_box.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mem Address:";
            // 
            // address_box
            // 
            this.address_box.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.address_box.Location = new System.Drawing.Point(0, 169);
            this.address_box.Name = "address_box";
            this.address_box.Size = new System.Drawing.Size(104, 20);
            this.address_box.TabIndex = 9;
            // 
            // address_Btn
            // 
            this.address_Btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.address_Btn.Location = new System.Drawing.Point(0, 189);
            this.address_Btn.Name = "address_Btn";
            this.address_Btn.Size = new System.Drawing.Size(104, 23);
            this.address_Btn.TabIndex = 8;
            this.address_Btn.Text = "Enter";
            this.address_Btn.UseVisualStyleBackColor = true;
            this.address_Btn.Click += new System.EventHandler(this.address_Btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(0, 212);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(104, 20);
            this.textBox1.TabIndex = 7;
            // 
            // log_check
            // 
            this.log_check.AutoSize = true;
            this.log_check.Dock = System.Windows.Forms.DockStyle.Top;
            this.log_check.Location = new System.Drawing.Point(0, 20);
            this.log_check.Name = "log_check";
            this.log_check.Size = new System.Drawing.Size(104, 17);
            this.log_check.TabIndex = 6;
            this.log_check.Text = "Tracing";
            this.log_check.UseVisualStyleBackColor = true;
            this.log_check.CheckedChanged += new System.EventHandler(this.log_check_CheckedChanged);
            // 
            // step_Btn
            // 
            this.step_Btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.step_Btn.Location = new System.Drawing.Point(0, 232);
            this.step_Btn.Name = "step_Btn";
            this.step_Btn.Size = new System.Drawing.Size(104, 23);
            this.step_Btn.TabIndex = 4;
            this.step_Btn.Text = "S&tep";
            this.step_Btn.UseVisualStyleBackColor = true;
            this.step_Btn.Click += new System.EventHandler(this.step_Btn_Click);
            // 
            // run_Btn
            // 
            this.run_Btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.run_Btn.Location = new System.Drawing.Point(0, 255);
            this.run_Btn.Name = "run_Btn";
            this.run_Btn.Size = new System.Drawing.Size(104, 23);
            this.run_Btn.TabIndex = 3;
            this.run_Btn.Text = "&Run";
            this.run_Btn.UseVisualStyleBackColor = true;
            this.run_Btn.Click += new System.EventHandler(this.run_Btn_Click);
            // 
            // stop_Btn
            // 
            this.stop_Btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stop_Btn.Enabled = false;
            this.stop_Btn.Location = new System.Drawing.Point(0, 278);
            this.stop_Btn.Name = "stop_Btn";
            this.stop_Btn.Size = new System.Drawing.Size(104, 23);
            this.stop_Btn.TabIndex = 2;
            this.stop_Btn.Text = "&Stop";
            this.stop_Btn.UseVisualStyleBackColor = true;
            this.stop_Btn.Click += new System.EventHandler(this.stop_Btn_Click);
            // 
            // reset_Btn
            // 
            this.reset_Btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.reset_Btn.Location = new System.Drawing.Point(0, 301);
            this.reset_Btn.Name = "reset_Btn";
            this.reset_Btn.Size = new System.Drawing.Size(104, 23);
            this.reset_Btn.TabIndex = 1;
            this.reset_Btn.Text = "R&eset";
            this.reset_Btn.UseVisualStyleBackColor = true;
            this.reset_Btn.Click += new System.EventHandler(this.reset_Btn_Click);
            // 
            // exit_Btn
            // 
            this.exit_Btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exit_Btn.Location = new System.Drawing.Point(0, 324);
            this.exit_Btn.Name = "exit_Btn";
            this.exit_Btn.Size = new System.Drawing.Size(104, 23);
            this.exit_Btn.TabIndex = 0;
            this.exit_Btn.Text = "E&xit";
            this.exit_Btn.UseVisualStyleBackColor = true;
            this.exit_Btn.Click += new System.EventHandler(this.exit_Btn_Click);
            // 
            // file_Bx
            // 
            this.file_Bx.Dock = System.Windows.Forms.DockStyle.Top;
            this.file_Bx.Location = new System.Drawing.Point(0, 0);
            this.file_Bx.Name = "file_Bx";
            this.file_Bx.ReadOnly = true;
            this.file_Bx.Size = new System.Drawing.Size(104, 20);
            this.file_Bx.TabIndex = 12;
            // 
            // splitContainer11
            // 
            this.splitContainer11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer11.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer11.Location = new System.Drawing.Point(0, 0);
            this.splitContainer11.Name = "splitContainer11";
            // 
            // splitContainer11.Panel1
            // 
            this.splitContainer11.Panel1.Controls.Add(this.splitContainer12);
            // 
            // splitContainer11.Panel2
            // 
            this.splitContainer11.Panel2.Controls.Add(this.regData_grid);
            this.splitContainer11.Size = new System.Drawing.Size(721, 347);
            this.splitContainer11.SplitterDistance = 470;
            this.splitContainer11.TabIndex = 0;
            // 
            // splitContainer12
            // 
            this.splitContainer12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer12.Location = new System.Drawing.Point(0, 0);
            this.splitContainer12.Name = "splitContainer12";
            this.splitContainer12.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer12.Panel1
            // 
            this.splitContainer12.Panel1.Controls.Add(this.data_box);
            // 
            // splitContainer12.Panel2
            // 
            this.splitContainer12.Panel2.Controls.Add(this.tabs_page);
            this.splitContainer12.Size = new System.Drawing.Size(470, 347);
            this.splitContainer12.SplitterDistance = 164;
            this.splitContainer12.TabIndex = 0;
            // 
            // data_box
            // 
            this.data_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_box.Location = new System.Drawing.Point(0, 0);
            this.data_box.Multiline = true;
            this.data_box.Name = "data_box";
            this.data_box.ReadOnly = true;
            this.data_box.Size = new System.Drawing.Size(470, 164);
            this.data_box.TabIndex = 0;
            this.data_box.Text = "This box contains stuff!";
            // 
            // tabs_page
            // 
            this.tabs_page.Controls.Add(this.memory_page);
            this.tabs_page.Controls.Add(this.terminal_page);
            this.tabs_page.Controls.Add(this.stack_page);
            this.tabs_page.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs_page.Location = new System.Drawing.Point(0, 0);
            this.tabs_page.Name = "tabs_page";
            this.tabs_page.SelectedIndex = 0;
            this.tabs_page.Size = new System.Drawing.Size(470, 179);
            this.tabs_page.TabIndex = 0;
            // 
            // memory_page
            // 
            this.memory_page.Controls.Add(this.memory_Grid);
            this.memory_page.Location = new System.Drawing.Point(4, 22);
            this.memory_page.Name = "memory_page";
            this.memory_page.Padding = new System.Windows.Forms.Padding(3);
            this.memory_page.Size = new System.Drawing.Size(462, 153);
            this.memory_page.TabIndex = 0;
            this.memory_page.Text = "Memory";
            this.memory_page.UseVisualStyleBackColor = true;
            // 
            // memory_Grid
            // 
            this.memory_Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.memory_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memory_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.byte_1,
            this.byte_2,
            this.byte_3,
            this.byte_4,
            this.ascii});
            this.memory_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memory_Grid.Location = new System.Drawing.Point(3, 3);
            this.memory_Grid.Name = "memory_Grid";
            this.memory_Grid.ReadOnly = true;
            this.memory_Grid.Size = new System.Drawing.Size(456, 147);
            this.memory_Grid.TabIndex = 0;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // byte_1
            // 
            this.byte_1.HeaderText = "Word 1";
            this.byte_1.Name = "byte_1";
            this.byte_1.ReadOnly = true;
            // 
            // byte_2
            // 
            this.byte_2.HeaderText = "Word 2";
            this.byte_2.Name = "byte_2";
            this.byte_2.ReadOnly = true;
            // 
            // byte_3
            // 
            this.byte_3.HeaderText = "Word 3";
            this.byte_3.Name = "byte_3";
            this.byte_3.ReadOnly = true;
            // 
            // byte_4
            // 
            this.byte_4.HeaderText = "Word 4";
            this.byte_4.Name = "byte_4";
            this.byte_4.ReadOnly = true;
            // 
            // ascii
            // 
            this.ascii.HeaderText = "ASCII";
            this.ascii.Name = "ascii";
            this.ascii.ReadOnly = true;
            // 
            // terminal_page
            // 
            this.terminal_page.Controls.Add(this.terminal_box);
            this.terminal_page.Location = new System.Drawing.Point(4, 22);
            this.terminal_page.Name = "terminal_page";
            this.terminal_page.Padding = new System.Windows.Forms.Padding(3);
            this.terminal_page.Size = new System.Drawing.Size(462, 153);
            this.terminal_page.TabIndex = 1;
            this.terminal_page.Text = "Terminal";
            this.terminal_page.UseVisualStyleBackColor = true;
            // 
            // terminal_box
            // 
            this.terminal_box.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.terminal_box.Cursor = System.Windows.Forms.Cursors.Default;
            this.terminal_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.terminal_box.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terminal_box.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.terminal_box.Location = new System.Drawing.Point(3, 3);
            this.terminal_box.Multiline = true;
            this.terminal_box.Name = "terminal_box";
            this.terminal_box.Size = new System.Drawing.Size(456, 147);
            this.terminal_box.TabIndex = 0;
            // 
            // stack_page
            // 
            this.stack_page.Controls.Add(this.stack_grid);
            this.stack_page.Location = new System.Drawing.Point(4, 22);
            this.stack_page.Name = "stack_page";
            this.stack_page.Padding = new System.Windows.Forms.Padding(3);
            this.stack_page.Size = new System.Drawing.Size(462, 153);
            this.stack_page.TabIndex = 2;
            this.stack_page.Text = "Stack";
            this.stack_page.UseVisualStyleBackColor = true;
            // 
            // stack_grid
            // 
            this.stack_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stack_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stack_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addr,
            this.word1,
            this.word2,
            this.word3,
            this.word4});
            this.stack_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stack_grid.Location = new System.Drawing.Point(3, 3);
            this.stack_grid.Name = "stack_grid";
            this.stack_grid.Size = new System.Drawing.Size(456, 147);
            this.stack_grid.TabIndex = 0;
            // 
            // addr
            // 
            this.addr.HeaderText = "Address:";
            this.addr.Name = "addr";
            this.addr.ReadOnly = true;
            // 
            // word1
            // 
            this.word1.HeaderText = "Word 1";
            this.word1.Name = "word1";
            this.word1.ReadOnly = true;
            // 
            // word2
            // 
            this.word2.HeaderText = "Word 2";
            this.word2.Name = "word2";
            this.word2.ReadOnly = true;
            // 
            // word3
            // 
            this.word3.HeaderText = "Word 3";
            this.word3.Name = "word3";
            this.word3.ReadOnly = true;
            // 
            // word4
            // 
            this.word4.HeaderText = "Word 4";
            this.word4.Name = "word4";
            this.word4.ReadOnly = true;
            // 
            // regData_grid
            // 
            this.regData_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.regData_grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.regData_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.regData_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.registers,
            this.value});
            this.regData_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regData_grid.Location = new System.Drawing.Point(0, 0);
            this.regData_grid.Name = "regData_grid";
            this.regData_grid.ReadOnly = true;
            this.regData_grid.Size = new System.Drawing.Size(247, 347);
            this.regData_grid.TabIndex = 0;
            // 
            // registers
            // 
            this.registers.HeaderText = "Regs";
            this.registers.Name = "registers";
            this.registers.ReadOnly = true;
            // 
            // value
            // 
            this.value.HeaderText = "Value";
            this.value.Name = "value";
            this.value.ReadOnly = true;
            // 
            // ui
            // 
            this.ClientSize = new System.Drawing.Size(829, 371);
            this.Controls.Add(this.splitContainer10);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.MinimumSize = new System.Drawing.Size(637, 410);
            this.Name = "ui";
            this.Text = "Armsim";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.splitContainer10.Panel1.ResumeLayout(false);
            this.splitContainer10.Panel1.PerformLayout();
            this.splitContainer10.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).EndInit();
            this.splitContainer10.ResumeLayout(false);
            this.splitContainer11.Panel1.ResumeLayout(false);
            this.splitContainer11.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).EndInit();
            this.splitContainer11.ResumeLayout(false);
            this.splitContainer12.Panel1.ResumeLayout(false);
            this.splitContainer12.Panel1.PerformLayout();
            this.splitContainer12.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer12)).EndInit();
            this.splitContainer12.ResumeLayout(false);
            this.tabs_page.ResumeLayout(false);
            this.memory_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memory_Grid)).EndInit();
            this.terminal_page.ResumeLayout(false);
            this.terminal_page.PerformLayout();
            this.stack_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stack_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regData_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadFile_menu;
        private System.Windows.Forms.ToolStripMenuItem reset_strip;
        private System.Windows.Forms.SplitContainer splitContainer10;
        private System.Windows.Forms.Button run_Btn;
        private System.Windows.Forms.Button stop_Btn;
        private System.Windows.Forms.Button reset_Btn;
        private System.Windows.Forms.Button exit_Btn;
        private System.Windows.Forms.SplitContainer splitContainer11;
        private System.Windows.Forms.SplitContainer splitContainer12;
        private System.Windows.Forms.TabControl tabs_page;
        private System.Windows.Forms.TabPage memory_page;
        private System.Windows.Forms.TabPage terminal_page;
        private System.Windows.Forms.DataGridView regData_grid;
        private System.Windows.Forms.TextBox data_box;
        private System.Windows.Forms.DataGridView memory_Grid;
        private System.Windows.Forms.TextBox terminal_box;
        private System.Windows.Forms.TabPage stack_page;
        private System.Windows.Forms.Button step_Btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registers;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.CheckBox log_check;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte_4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ascii;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox address_box;
        private System.Windows.Forms.Button address_Btn;
        private System.Windows.Forms.TextBox flag_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem step_menu;
        private System.Windows.Forms.ToolStripMenuItem run_menu;
        private System.Windows.Forms.ToolStripMenuItem stop_menu;
        private System.Windows.Forms.ToolStripMenuItem tracing_menu;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridView stack_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn addr;
        private System.Windows.Forms.DataGridViewTextBoxColumn word1;
        private System.Windows.Forms.DataGridViewTextBoxColumn word2;
        private System.Windows.Forms.DataGridViewTextBoxColumn word3;
        private System.Windows.Forms.DataGridViewTextBoxColumn word4;
        private System.Windows.Forms.TextBox file_Bx;
    }
}