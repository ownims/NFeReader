
namespace NFeReader {
    partial class FrmXMLExtractor {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.CbExportType = new System.Windows.Forms.ComboBox();
            this.BtnOpenFile = new System.Windows.Forms.Button();
            this.BtnExtractAll = new System.Windows.Forms.Button();
            this.BtnExport = new System.Windows.Forms.Button();
            this.BtnExtractSection = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 385);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(874, 199);
            this.dataGridView1.TabIndex = 6;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.DimGray;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 380);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(874, 5);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.MinimumSize = new System.Drawing.Size(585, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(874, 380);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Escolha as sessões";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 13);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.CbExportType);
            this.splitContainer1.Panel2.Controls.Add(this.BtnOpenFile);
            this.splitContainer1.Panel2.Controls.Add(this.BtnExtractAll);
            this.splitContainer1.Panel2.Controls.Add(this.BtnExport);
            this.splitContainer1.Panel2.Controls.Add(this.BtnExtractSection);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(874, 367);
            this.splitContainer1.SplitterDistance = 251;
            this.splitContainer1.TabIndex = 10;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.LightGray;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(251, 367);
            this.treeView1.TabIndex = 10;
            // 
            // CbExportType
            // 
            this.CbExportType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CbExportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbExportType.FormattingEnabled = true;
            this.CbExportType.Location = new System.Drawing.Point(4, 317);
            this.CbExportType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CbExportType.Name = "CbExportType";
            this.CbExportType.Size = new System.Drawing.Size(119, 21);
            this.CbExportType.TabIndex = 9;
            // 
            // BtnOpenFile
            // 
            this.BtnOpenFile.Location = new System.Drawing.Point(3, 3);
            this.BtnOpenFile.Name = "BtnOpenFile";
            this.BtnOpenFile.Size = new System.Drawing.Size(117, 23);
            this.BtnOpenFile.TabIndex = 3;
            this.BtnOpenFile.Text = "Selecionar XML";
            this.BtnOpenFile.UseVisualStyleBackColor = true;
            this.BtnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // BtnExtractAll
            // 
            this.BtnExtractAll.Location = new System.Drawing.Point(3, 61);
            this.BtnExtractAll.Name = "BtnExtractAll";
            this.BtnExtractAll.Size = new System.Drawing.Size(117, 23);
            this.BtnExtractAll.TabIndex = 2;
            this.BtnExtractAll.Text = "Extrair Todos";
            this.BtnExtractAll.UseVisualStyleBackColor = true;
            this.BtnExtractAll.Click += new System.EventHandler(this.BtnExtractAll_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExport.Location = new System.Drawing.Point(3, 341);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(121, 23);
            this.BtnExport.TabIndex = 7;
            this.BtnExport.Text = "Exportar Tabela";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // BtnExtractSection
            // 
            this.BtnExtractSection.Location = new System.Drawing.Point(3, 32);
            this.BtnExtractSection.Name = "BtnExtractSection";
            this.BtnExtractSection.Size = new System.Drawing.Size(117, 23);
            this.BtnExtractSection.TabIndex = 4;
            this.BtnExtractSection.Text = "Exibir Sessões";
            this.BtnExtractSection.UseVisualStyleBackColor = true;
            this.BtnExtractSection.Click += new System.EventHandler(this.BtnExtractSection_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Arquivo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Caminho:";
            // 
            // FrmXMLExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 584);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmXMLExtractor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML Extractor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ComboBox CbExportType;
        private System.Windows.Forms.Button BtnOpenFile;
        private System.Windows.Forms.Button BtnExtractAll;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Button BtnExtractSection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

