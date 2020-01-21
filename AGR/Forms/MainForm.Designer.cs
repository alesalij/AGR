namespace AGR
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.chB_Recipe = new System.Windows.Forms.CheckBox();
            this.chB_Speed = new System.Windows.Forms.CheckBox();
            this.chB_Hardness = new System.Windows.Forms.CheckBox();
            this.chB_pH = new System.Windows.Forms.CheckBox();
            this.chB_Mg = new System.Windows.Forms.CheckBox();
            this.chB_Zn = new System.Windows.Forms.CheckBox();
            this.chB_Ca = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tB_OpenDB = new System.Windows.Forms.TextBox();
            this.b_OpenDB = new System.Windows.Forms.Button();
            this.b_LoadDB = new System.Windows.Forms.Button();
            this.b_BD = new System.Windows.Forms.Button();
            this.dGV_DB1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.b_AddNode = new System.Windows.Forms.Button();
            this.b_AddGroup = new System.Windows.Forms.Button();
            this.b_DeleteGroup = new System.Windows.Forms.Button();
            this.tV_Groups = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.textBoxWLabel1 = new AGR.TextBoxWLabel();
            this.eH_Parameters = new System.Windows.Forms.Integration.ElementHost();
            this.tVWTB_Parameters = new AGR.TreeViewWTBox();
            this.b_SaveDefaultGroups = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_DB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(448, 602);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chB_Recipe
            // 
            this.chB_Recipe.AutoSize = true;
            this.chB_Recipe.Checked = true;
            this.chB_Recipe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chB_Recipe.Location = new System.Drawing.Point(722, 436);
            this.chB_Recipe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chB_Recipe.Name = "chB_Recipe";
            this.chB_Recipe.Size = new System.Drawing.Size(101, 21);
            this.chB_Recipe.TabIndex = 1;
            this.chB_Recipe.Text = "Рецептура";
            this.chB_Recipe.UseVisualStyleBackColor = true;
            // 
            // chB_Speed
            // 
            this.chB_Speed.AutoSize = true;
            this.chB_Speed.Checked = true;
            this.chB_Speed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chB_Speed.Location = new System.Drawing.Point(722, 460);
            this.chB_Speed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chB_Speed.Name = "chB_Speed";
            this.chB_Speed.Size = new System.Drawing.Size(176, 21);
            this.chB_Speed.TabIndex = 1;
            this.chB_Speed.Text = "Скорость фильтрации";
            this.chB_Speed.UseVisualStyleBackColor = true;
            // 
            // chB_Hardness
            // 
            this.chB_Hardness.AutoSize = true;
            this.chB_Hardness.Checked = true;
            this.chB_Hardness.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chB_Hardness.Location = new System.Drawing.Point(722, 484);
            this.chB_Hardness.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chB_Hardness.Name = "chB_Hardness";
            this.chB_Hardness.Size = new System.Drawing.Size(101, 21);
            this.chB_Hardness.TabIndex = 1;
            this.chB_Hardness.Text = "Жесткость";
            this.chB_Hardness.UseVisualStyleBackColor = true;
            // 
            // chB_pH
            // 
            this.chB_pH.AutoSize = true;
            this.chB_pH.Checked = true;
            this.chB_pH.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chB_pH.Location = new System.Drawing.Point(722, 508);
            this.chB_pH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chB_pH.Name = "chB_pH";
            this.chB_pH.Size = new System.Drawing.Size(48, 21);
            this.chB_pH.TabIndex = 1;
            this.chB_pH.Text = "pH";
            this.chB_pH.UseVisualStyleBackColor = true;
            // 
            // chB_Mg
            // 
            this.chB_Mg.AutoSize = true;
            this.chB_Mg.Checked = true;
            this.chB_Mg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chB_Mg.Location = new System.Drawing.Point(722, 556);
            this.chB_Mg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chB_Mg.Name = "chB_Mg";
            this.chB_Mg.Size = new System.Drawing.Size(49, 21);
            this.chB_Mg.TabIndex = 1;
            this.chB_Mg.Text = "Mg";
            this.chB_Mg.UseVisualStyleBackColor = true;
            // 
            // chB_Zn
            // 
            this.chB_Zn.AutoSize = true;
            this.chB_Zn.Checked = true;
            this.chB_Zn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chB_Zn.Location = new System.Drawing.Point(722, 580);
            this.chB_Zn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chB_Zn.Name = "chB_Zn";
            this.chB_Zn.Size = new System.Drawing.Size(47, 21);
            this.chB_Zn.TabIndex = 1;
            this.chB_Zn.Text = "Zn";
            this.chB_Zn.UseVisualStyleBackColor = true;
            // 
            // chB_Ca
            // 
            this.chB_Ca.AutoSize = true;
            this.chB_Ca.Checked = true;
            this.chB_Ca.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chB_Ca.Location = new System.Drawing.Point(722, 532);
            this.chB_Ca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chB_Ca.Name = "chB_Ca";
            this.chB_Ca.Size = new System.Drawing.Size(47, 21);
            this.chB_Ca.TabIndex = 2;
            this.chB_Ca.Text = "Ca";
            this.chB_Ca.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(601, 605);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 39);
            this.button2.TabIndex = 0;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tB_OpenDB
            // 
            this.tB_OpenDB.Location = new System.Drawing.Point(611, 407);
            this.tB_OpenDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tB_OpenDB.Name = "tB_OpenDB";
            this.tB_OpenDB.Size = new System.Drawing.Size(180, 22);
            this.tB_OpenDB.TabIndex = 3;
            this.tB_OpenDB.Text = "C:\\";
            // 
            // b_OpenDB
            // 
            this.b_OpenDB.Location = new System.Drawing.Point(505, 405);
            this.b_OpenDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_OpenDB.Name = "b_OpenDB";
            this.b_OpenDB.Size = new System.Drawing.Size(100, 27);
            this.b_OpenDB.TabIndex = 0;
            this.b_OpenDB.Text = "Обзор";
            this.b_OpenDB.UseVisualStyleBackColor = true;
            // 
            // b_LoadDB
            // 
            this.b_LoadDB.Location = new System.Drawing.Point(797, 405);
            this.b_LoadDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_LoadDB.Name = "b_LoadDB";
            this.b_LoadDB.Size = new System.Drawing.Size(100, 27);
            this.b_LoadDB.TabIndex = 4;
            this.b_LoadDB.Text = "Ок";
            this.b_LoadDB.UseVisualStyleBackColor = true;
            this.b_LoadDB.Click += new System.EventHandler(this.b_LoadDB_Click);
            // 
            // b_BD
            // 
            this.b_BD.Location = new System.Drawing.Point(14, 2);
            this.b_BD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_BD.Name = "b_BD";
            this.b_BD.Size = new System.Drawing.Size(67, 42);
            this.b_BD.TabIndex = 5;
            this.b_BD.Text = "BD";
            this.b_BD.UseVisualStyleBackColor = true;
            this.b_BD.Click += new System.EventHandler(this.b_BD_Click);
            // 
            // dGV_DB1
            // 
            this.dGV_DB1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_DB1.Location = new System.Drawing.Point(14, 49);
            this.dGV_DB1.Name = "dGV_DB1";
            this.dGV_DB1.RowHeadersWidth = 51;
            this.dGV_DB1.RowTemplate.Height = 24;
            this.dGV_DB1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_DB1.Size = new System.Drawing.Size(406, 611);
            this.dGV_DB1.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(448, 668);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 31);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // b_AddNode
            // 
            this.b_AddNode.Location = new System.Drawing.Point(761, 264);
            this.b_AddNode.Name = "b_AddNode";
            this.b_AddNode.Size = new System.Drawing.Size(75, 57);
            this.b_AddNode.TabIndex = 9;
            this.b_AddNode.Text = ">>";
            this.b_AddNode.UseVisualStyleBackColor = true;
            this.b_AddNode.Click += new System.EventHandler(this.b_Add_Click);
            // 
            // b_AddGroup
            // 
            this.b_AddGroup.Location = new System.Drawing.Point(941, 59);
            this.b_AddGroup.Name = "b_AddGroup";
            this.b_AddGroup.Size = new System.Drawing.Size(58, 45);
            this.b_AddGroup.TabIndex = 10;
            this.b_AddGroup.Text = "+";
            this.b_AddGroup.UseVisualStyleBackColor = true;
            this.b_AddGroup.Click += new System.EventHandler(this.b_AddGroup_Click);
            // 
            // b_DeleteGroup
            // 
            this.b_DeleteGroup.Location = new System.Drawing.Point(1005, 57);
            this.b_DeleteGroup.Name = "b_DeleteGroup";
            this.b_DeleteGroup.Size = new System.Drawing.Size(59, 48);
            this.b_DeleteGroup.TabIndex = 11;
            this.b_DeleteGroup.Text = "-";
            this.b_DeleteGroup.UseVisualStyleBackColor = true;
            this.b_DeleteGroup.Click += new System.EventHandler(this.b_DeleteGroup_Click);
            // 
            // tV_Groups
            // 
            this.tV_Groups.HideSelection = false;
            this.tV_Groups.LabelEdit = true;
            this.tV_Groups.Location = new System.Drawing.Point(941, 110);
            this.tV_Groups.Name = "tV_Groups";
            this.tV_Groups.Size = new System.Drawing.Size(303, 189);
            this.tV_Groups.TabIndex = 12;
            this.tV_Groups.Tag = "Program.GV.Groups";
            this.tV_Groups.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tV_Groups_AfterLabelEdit);
            this.tV_Groups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tV_Groups_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(703, 683);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(8, 8);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(426, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(442, 192);
            this.dataGridView1.TabIndex = 16;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(601, 649);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 53);
            this.button4.TabIndex = 17;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(554, 321);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 21);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.ThreeState = true;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // elementHost2
            // 
            this.elementHost2.Location = new System.Drawing.Point(448, 498);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(214, 31);
            this.elementHost2.TabIndex = 15;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.textBoxWLabel1;
            // 
            // eH_Parameters
            // 
            this.eH_Parameters.Location = new System.Drawing.Point(941, 319);
            this.eH_Parameters.Name = "eH_Parameters";
            this.eH_Parameters.Size = new System.Drawing.Size(339, 372);
            this.eH_Parameters.TabIndex = 14;
            this.eH_Parameters.Text = "elementHost1";
            this.eH_Parameters.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.eH_Parameters_ChildChanged);
            this.eH_Parameters.Child = this.tVWTB_Parameters;
            // 
            // b_SaveDefaultGroups
            // 
            this.b_SaveDefaultGroups.Location = new System.Drawing.Point(1250, 110);
            this.b_SaveDefaultGroups.Name = "b_SaveDefaultGroups";
            this.b_SaveDefaultGroups.Size = new System.Drawing.Size(99, 61);
            this.b_SaveDefaultGroups.TabIndex = 19;
            this.b_SaveDefaultGroups.Text = "Сохранить по умолчанию";
            this.b_SaveDefaultGroups.UseVisualStyleBackColor = true;
            this.b_SaveDefaultGroups.Click += new System.EventHandler(this.b_SaveDefaultGroups_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 711);
            this.Controls.Add(this.b_SaveDefaultGroups);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.elementHost2);
            this.Controls.Add(this.eH_Parameters);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tV_Groups);
            this.Controls.Add(this.b_DeleteGroup);
            this.Controls.Add(this.b_AddGroup);
            this.Controls.Add(this.b_AddNode);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dGV_DB1);
            this.Controls.Add(this.b_BD);
            this.Controls.Add(this.b_LoadDB);
            this.Controls.Add(this.tB_OpenDB);
            this.Controls.Add(this.chB_Ca);
            this.Controls.Add(this.chB_Zn);
            this.Controls.Add(this.chB_Mg);
            this.Controls.Add(this.chB_pH);
            this.Controls.Add(this.chB_Hardness);
            this.Controls.Add(this.chB_Speed);
            this.Controls.Add(this.chB_Recipe);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.b_OpenDB);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Enter += new System.EventHandler(this.MainForm_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_DB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chB_Recipe;
        private System.Windows.Forms.CheckBox chB_Speed;
        private System.Windows.Forms.CheckBox chB_Hardness;
        private System.Windows.Forms.CheckBox chB_pH;
        private System.Windows.Forms.CheckBox chB_Mg;
        private System.Windows.Forms.CheckBox chB_Zn;
        private System.Windows.Forms.CheckBox chB_Ca;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tB_OpenDB;
        private System.Windows.Forms.Button b_OpenDB;
        private System.Windows.Forms.Button b_LoadDB;
        private System.Windows.Forms.Button b_BD;
        private System.Windows.Forms.DataGridView dGV_DB1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button b_AddNode;
        private System.Windows.Forms.Button b_AddGroup;
        private System.Windows.Forms.Button b_DeleteGroup;
        private System.Windows.Forms.TreeView tV_Groups;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Integration.ElementHost eH_Parameters;
        private TreeViewWTBox tVWTB_Parameters;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private TextBoxWLabel textBoxWLabel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button b_SaveDefaultGroups;
    }
}

