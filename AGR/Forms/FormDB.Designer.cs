namespace AGR
{
    partial class FormDB
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
            this.b_testDB = new System.Windows.Forms.Button();
            this.tB_OpenDB = new System.Windows.Forms.TextBox();
            this.b_OpenDB = new System.Windows.Forms.Button();
            this.chB_DB = new System.Windows.Forms.CheckBox();
            this.cB_Profiles = new System.Windows.Forms.ComboBox();
            this.tB_Columns1 = new System.Windows.Forms.TextBox();
            this.tB_Columns2 = new System.Windows.Forms.TextBox();
            this.tB_FolderDB = new System.Windows.Forms.TextBox();
            this.bTestFolderDB = new System.Windows.Forms.Button();
            this.b_OpenFolderDB = new System.Windows.Forms.Button();
            this.tB_MaskKey = new System.Windows.Forms.TextBox();
            this.tB_MaskDB = new System.Windows.Forms.TextBox();
            this.b_AddChanges = new System.Windows.Forms.Button();
            this.b_SaveChanges = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.oFD_BD = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.b_delete = new System.Windows.Forms.Button();
            this.b_make = new System.Windows.Forms.Button();
            this.fBD_DB_Folder = new System.Windows.Forms.FolderBrowserDialog();
            this.tB_Table2 = new System.Windows.Forms.TextBox();
            this.tB_Table1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tB_MainColumn = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // b_testDB
            // 
            this.b_testDB.Location = new System.Drawing.Point(672, 50);
            this.b_testDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_testDB.Name = "b_testDB";
            this.b_testDB.Size = new System.Drawing.Size(100, 27);
            this.b_testDB.TabIndex = 6;
            this.b_testDB.Text = "Ок";
            this.b_testDB.UseVisualStyleBackColor = true;
            this.b_testDB.Click += new System.EventHandler(this.b_testDB_Click);
            // 
            // tB_OpenDB
            // 
            this.tB_OpenDB.Location = new System.Drawing.Point(145, 54);
            this.tB_OpenDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tB_OpenDB.Name = "tB_OpenDB";
            this.tB_OpenDB.Size = new System.Drawing.Size(495, 22);
            this.tB_OpenDB.TabIndex = 5;
            this.tB_OpenDB.Text = "C:\\";
            this.tB_OpenDB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_Profiles_KeyPress);
            // 
            // b_OpenDB
            // 
            this.b_OpenDB.Location = new System.Drawing.Point(28, 50);
            this.b_OpenDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_OpenDB.Name = "b_OpenDB";
            this.b_OpenDB.Size = new System.Drawing.Size(100, 27);
            this.b_OpenDB.TabIndex = 7;
            this.b_OpenDB.Text = "Обзор";
            this.b_OpenDB.UseVisualStyleBackColor = true;
            this.b_OpenDB.Click += new System.EventHandler(this.b_OpenDB_Click);
            // 
            // chB_DB
            // 
            this.chB_DB.AutoSize = true;
            this.chB_DB.Location = new System.Drawing.Point(137, 167);
            this.chB_DB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chB_DB.Name = "chB_DB";
            this.chB_DB.Size = new System.Drawing.Size(238, 21);
            this.chB_DB.TabIndex = 8;
            this.chB_DB.Text = "Имеется несколько баз данных";
            this.chB_DB.UseVisualStyleBackColor = true;
            this.chB_DB.CheckedChanged += new System.EventHandler(this.chB_DB_CheckedChanged);
            // 
            // cB_Profiles
            // 
            this.cB_Profiles.FormattingEnabled = true;
            this.cB_Profiles.Location = new System.Drawing.Point(28, 10);
            this.cB_Profiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cB_Profiles.Name = "cB_Profiles";
            this.cB_Profiles.Size = new System.Drawing.Size(663, 24);
            this.cB_Profiles.TabIndex = 9;
            this.cB_Profiles.DropDown += new System.EventHandler(this.cB_Profiles_DropDown);
            this.cB_Profiles.SelectedIndexChanged += new System.EventHandler(this.cB_Profiles_SelectedIndexChanged);
            this.cB_Profiles.SelectionChangeCommitted += new System.EventHandler(this.cB_Profiles_SelectionChangeCommitted);
            this.cB_Profiles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_Profiles_KeyPress);
            // 
            // tB_Columns1
            // 
            this.tB_Columns1.Location = new System.Drawing.Point(402, 100);
            this.tB_Columns1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tB_Columns1.Name = "tB_Columns1";
            this.tB_Columns1.Size = new System.Drawing.Size(495, 22);
            this.tB_Columns1.TabIndex = 5;
            this.tB_Columns1.Text = "C:\\";
            this.tB_Columns1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_Profiles_KeyPress);
            // 
            // tB_Columns2
            // 
            this.tB_Columns2.Location = new System.Drawing.Point(402, 126);
            this.tB_Columns2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tB_Columns2.Name = "tB_Columns2";
            this.tB_Columns2.Size = new System.Drawing.Size(495, 22);
            this.tB_Columns2.TabIndex = 5;
            this.tB_Columns2.Text = "C:\\";
            this.tB_Columns2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_Profiles_KeyPress);
            // 
            // tB_FolderDB
            // 
            this.tB_FolderDB.Location = new System.Drawing.Point(333, 256);
            this.tB_FolderDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tB_FolderDB.Name = "tB_FolderDB";
            this.tB_FolderDB.Size = new System.Drawing.Size(495, 22);
            this.tB_FolderDB.TabIndex = 5;
            this.tB_FolderDB.Text = "C:\\";
            this.tB_FolderDB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_Profiles_KeyPress);
            // 
            // bTestFolderDB
            // 
            this.bTestFolderDB.Location = new System.Drawing.Point(860, 252);
            this.bTestFolderDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bTestFolderDB.Name = "bTestFolderDB";
            this.bTestFolderDB.Size = new System.Drawing.Size(100, 27);
            this.bTestFolderDB.TabIndex = 6;
            this.bTestFolderDB.Text = "Ок";
            this.bTestFolderDB.UseVisualStyleBackColor = true;
            // 
            // b_OpenFolderDB
            // 
            this.b_OpenFolderDB.Location = new System.Drawing.Point(224, 251);
            this.b_OpenFolderDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_OpenFolderDB.Name = "b_OpenFolderDB";
            this.b_OpenFolderDB.Size = new System.Drawing.Size(100, 27);
            this.b_OpenFolderDB.TabIndex = 7;
            this.b_OpenFolderDB.Text = "Обзор";
            this.b_OpenFolderDB.UseVisualStyleBackColor = true;
            this.b_OpenFolderDB.Click += new System.EventHandler(this.b_OpenFolderDB_Click);
            // 
            // tB_MaskKey
            // 
            this.tB_MaskKey.Location = new System.Drawing.Point(224, 319);
            this.tB_MaskKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tB_MaskKey.Name = "tB_MaskKey";
            this.tB_MaskKey.Size = new System.Drawing.Size(265, 22);
            this.tB_MaskKey.TabIndex = 5;
            this.tB_MaskKey.Text = "C:\\";
            this.tB_MaskKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_Profiles_KeyPress);
            // 
            // tB_MaskDB
            // 
            this.tB_MaskDB.Location = new System.Drawing.Point(672, 319);
            this.tB_MaskDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tB_MaskDB.Name = "tB_MaskDB";
            this.tB_MaskDB.Size = new System.Drawing.Size(288, 22);
            this.tB_MaskDB.TabIndex = 5;
            this.tB_MaskDB.Text = "C:\\";
            this.tB_MaskDB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_Profiles_KeyPress);
            // 
            // b_AddChanges
            // 
            this.b_AddChanges.Enabled = false;
            this.b_AddChanges.Location = new System.Drawing.Point(797, 383);
            this.b_AddChanges.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_AddChanges.Name = "b_AddChanges";
            this.b_AddChanges.Size = new System.Drawing.Size(100, 27);
            this.b_AddChanges.TabIndex = 6;
            this.b_AddChanges.Text = "Применить";
            this.b_AddChanges.UseVisualStyleBackColor = true;
            this.b_AddChanges.Click += new System.EventHandler(this.b_AddChanges_Click);
            // 
            // b_SaveChanges
            // 
            this.b_SaveChanges.Enabled = false;
            this.b_SaveChanges.Location = new System.Drawing.Point(919, 383);
            this.b_SaveChanges.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_SaveChanges.Name = "b_SaveChanges";
            this.b_SaveChanges.Size = new System.Drawing.Size(100, 27);
            this.b_SaveChanges.TabIndex = 6;
            this.b_SaveChanges.Text = "Сохранить";
            this.b_SaveChanges.UseVisualStyleBackColor = true;
            this.b_SaveChanges.Click += new System.EventHandler(this.b_SaveChanges_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 384);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 27);
            this.button1.TabIndex = 6;
            this.button1.Text = "Показать БД";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 415);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1041, 258);
            this.dataGridView1.TabIndex = 10;
            // 
            // oFD_BD
            // 
            this.oFD_BD.SupportMultiDottedExtensions = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(118, 384);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 27);
            this.button2.TabIndex = 6;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // b_delete
            // 
            this.b_delete.Location = new System.Drawing.Point(679, 383);
            this.b_delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_delete.Name = "b_delete";
            this.b_delete.Size = new System.Drawing.Size(100, 27);
            this.b_delete.TabIndex = 6;
            this.b_delete.Text = "Удалить";
            this.b_delete.UseVisualStyleBackColor = true;
            this.b_delete.Click += new System.EventHandler(this.b_delete_Click);
            // 
            // b_make
            // 
            this.b_make.Location = new System.Drawing.Point(707, 8);
            this.b_make.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_make.Name = "b_make";
            this.b_make.Size = new System.Drawing.Size(100, 27);
            this.b_make.TabIndex = 6;
            this.b_make.Text = "Создать";
            this.b_make.UseVisualStyleBackColor = true;
            this.b_make.Click += new System.EventHandler(this.b_make_Click);
            // 
            // fBD_DB_Folder
            // 
            this.fBD_DB_Folder.RootFolder = System.Environment.SpecialFolder.History;
            // 
            // tB_Table2
            // 
            this.tB_Table2.Location = new System.Drawing.Point(137, 126);
            this.tB_Table2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tB_Table2.Name = "tB_Table2";
            this.tB_Table2.Size = new System.Drawing.Size(106, 22);
            this.tB_Table2.TabIndex = 5;
            this.tB_Table2.Text = "C:\\";
            this.tB_Table2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_Profiles_KeyPress);
            // 
            // tB_Table1
            // 
            this.tB_Table1.Location = new System.Drawing.Point(137, 100);
            this.tB_Table1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tB_Table1.Name = "tB_Table1";
            this.tB_Table1.Size = new System.Drawing.Size(106, 22);
            this.tB_Table1.TabIndex = 5;
            this.tB_Table1.Text = "C:\\";
            this.tB_Table1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_Profiles_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Таблица №1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Таблица №2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Столбцы:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Столбцы:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tB_MainColumn
            // 
            this.tB_MainColumn.Location = new System.Drawing.Point(948, 100);
            this.tB_MainColumn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tB_MainColumn.Name = "tB_MainColumn";
            this.tB_MainColumn.Size = new System.Drawing.Size(96, 22);
            this.tB_MainColumn.TabIndex = 12;
            this.tB_MainColumn.Text = "C:\\";
            // 
            // FormDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 686);
            this.Controls.Add(this.tB_MainColumn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cB_Profiles);
            this.Controls.Add(this.chB_DB);
            this.Controls.Add(this.b_OpenFolderDB);
            this.Controls.Add(this.b_make);
            this.Controls.Add(this.b_delete);
            this.Controls.Add(this.b_SaveChanges);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.b_AddChanges);
            this.Controls.Add(this.bTestFolderDB);
            this.Controls.Add(this.b_OpenDB);
            this.Controls.Add(this.b_testDB);
            this.Controls.Add(this.tB_Table2);
            this.Controls.Add(this.tB_Columns2);
            this.Controls.Add(this.tB_MaskDB);
            this.Controls.Add(this.tB_MaskKey);
            this.Controls.Add(this.tB_FolderDB);
            this.Controls.Add(this.tB_Table1);
            this.Controls.Add(this.tB_Columns1);
            this.Controls.Add(this.tB_OpenDB);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormDB";
            this.Text = "Расширенные настройки подключения к БД";
            this.Load += new System.EventHandler(this.FormDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button b_testDB;
        private System.Windows.Forms.TextBox tB_OpenDB;
        private System.Windows.Forms.Button b_OpenDB;
        private System.Windows.Forms.CheckBox chB_DB;
        private System.Windows.Forms.ComboBox cB_Profiles;
        private System.Windows.Forms.TextBox tB_Columns1;
        private System.Windows.Forms.TextBox tB_Columns2;
        private System.Windows.Forms.TextBox tB_FolderDB;
        private System.Windows.Forms.Button bTestFolderDB;
        private System.Windows.Forms.Button b_OpenFolderDB;
        private System.Windows.Forms.TextBox tB_MaskKey;
        private System.Windows.Forms.TextBox tB_MaskDB;
        private System.Windows.Forms.Button b_AddChanges;
        private System.Windows.Forms.Button b_SaveChanges;
        private System.Windows.Forms.Button button1;
        
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog oFD_BD;
        //private MainDBDataSetTableAdapters.MainTableAdapter mainTableAdapter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button b_delete;
        private System.Windows.Forms.Button b_make;
        private System.Windows.Forms.FolderBrowserDialog fBD_DB_Folder;
        private System.Windows.Forms.TextBox tB_Table2;
        private System.Windows.Forms.TextBox tB_Table1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tB_MainColumn;
    }
}