
namespace ControleHotel.Forms
{
    partial class TelaControleConsumos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaControleConsumos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gboxAdicionar = new System.Windows.Forms.GroupBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.rbMercadoria = new System.Windows.Forms.RadioButton();
            this.rbServico = new System.Windows.Forms.RadioButton();
            this.numQtd = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.mtxtValTot = new System.Windows.Forms.MaskedTextBox();
            this.mtxtUnitario = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbProdutos = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mtxtTotConsumo = new System.Windows.Forms.MaskedTextBox();
            this.mtxtValUnit = new System.Windows.Forms.MaskedTextBox();
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtDataConsumo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvConsumos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodHospedagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantidadeConsumida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataConsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stLbAviso = new System.Windows.Forms.ToolStripStatusLabel();
            this.stLbAvisoTxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.gboxAdicionar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumos)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            resources.ApplyResources(this.btnVoltar, "btnVoltar");
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.FlatAppearance.BorderSize = 2;
            this.btnVoltar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnVoltar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.BtnVoltar_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.gboxAdicionar);
            this.groupBox1.Controls.Add(this.mtxtTotConsumo);
            this.groupBox1.Controls.Add(this.mtxtValUnit);
            this.groupBox1.Controls.Add(this.txtQtd);
            this.groupBox1.Controls.Add(this.txtProduto);
            this.groupBox1.Controls.Add(this.txtTipo);
            this.groupBox1.Controls.Add(this.txtDataConsumo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dgvConsumos);
            this.groupBox1.Controls.Add(this.statusStrip1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // gboxAdicionar
            // 
            resources.ApplyResources(this.gboxAdicionar, "gboxAdicionar");
            this.gboxAdicionar.Controls.Add(this.btnAdicionar);
            this.gboxAdicionar.Controls.Add(this.rbMercadoria);
            this.gboxAdicionar.Controls.Add(this.rbServico);
            this.gboxAdicionar.Controls.Add(this.numQtd);
            this.gboxAdicionar.Controls.Add(this.label11);
            this.gboxAdicionar.Controls.Add(this.mtxtValTot);
            this.gboxAdicionar.Controls.Add(this.mtxtUnitario);
            this.gboxAdicionar.Controls.Add(this.label9);
            this.gboxAdicionar.Controls.Add(this.label10);
            this.gboxAdicionar.Controls.Add(this.cbProdutos);
            this.gboxAdicionar.Controls.Add(this.label8);
            this.gboxAdicionar.ForeColor = System.Drawing.Color.White;
            this.gboxAdicionar.Name = "gboxAdicionar";
            this.gboxAdicionar.TabStop = false;
            // 
            // btnAdicionar
            // 
            resources.ApplyResources(this.btnAdicionar, "btnAdicionar");
            this.btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionar.FlatAppearance.BorderSize = 2;
            this.btnAdicionar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnAdicionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.BtnAdicionar_Click);
            // 
            // rbMercadoria
            // 
            resources.ApplyResources(this.rbMercadoria, "rbMercadoria");
            this.rbMercadoria.Name = "rbMercadoria";
            this.rbMercadoria.UseVisualStyleBackColor = true;
            this.rbMercadoria.CheckedChanged += new System.EventHandler(this.RbMercadoria_CheckedChanged);
            // 
            // rbServico
            // 
            resources.ApplyResources(this.rbServico, "rbServico");
            this.rbServico.Checked = true;
            this.rbServico.Name = "rbServico";
            this.rbServico.TabStop = true;
            this.rbServico.UseVisualStyleBackColor = true;
            this.rbServico.CheckedChanged += new System.EventHandler(this.RbServico_CheckedChanged);
            // 
            // numQtd
            // 
            resources.ApplyResources(this.numQtd, "numQtd");
            this.numQtd.Name = "numQtd";
            this.numQtd.ReadOnly = true;
            this.numQtd.ValueChanged += new System.EventHandler(this.NumQtd_ValueChanged);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // mtxtValTot
            // 
            resources.ApplyResources(this.mtxtValTot, "mtxtValTot");
            this.mtxtValTot.Name = "mtxtValTot";
            this.mtxtValTot.ReadOnly = true;
            // 
            // mtxtUnitario
            // 
            resources.ApplyResources(this.mtxtUnitario, "mtxtUnitario");
            this.mtxtUnitario.Name = "mtxtUnitario";
            this.mtxtUnitario.ReadOnly = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // cbProdutos
            // 
            resources.ApplyResources(this.cbProdutos, "cbProdutos");
            this.cbProdutos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProdutos.FormattingEnabled = true;
            this.cbProdutos.Name = "cbProdutos";
            this.cbProdutos.SelectionChangeCommitted += new System.EventHandler(this.CbProdutos_SelectionChangeCommitted);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // mtxtTotConsumo
            // 
            resources.ApplyResources(this.mtxtTotConsumo, "mtxtTotConsumo");
            this.mtxtTotConsumo.Name = "mtxtTotConsumo";
            this.mtxtTotConsumo.ReadOnly = true;
            // 
            // mtxtValUnit
            // 
            resources.ApplyResources(this.mtxtValUnit, "mtxtValUnit");
            this.mtxtValUnit.Name = "mtxtValUnit";
            this.mtxtValUnit.ReadOnly = true;
            // 
            // txtQtd
            // 
            resources.ApplyResources(this.txtQtd, "txtQtd");
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.ReadOnly = true;
            // 
            // txtProduto
            // 
            resources.ApplyResources(this.txtProduto, "txtProduto");
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.ReadOnly = true;
            // 
            // txtTipo
            // 
            resources.ApplyResources(this.txtTipo, "txtTipo");
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            // 
            // txtDataConsumo
            // 
            resources.ApplyResources(this.txtDataConsumo, "txtDataConsumo");
            this.txtDataConsumo.Name = "txtDataConsumo";
            this.txtDataConsumo.ReadOnly = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // dgvConsumos
            // 
            resources.ApplyResources(this.dgvConsumos, "dgvConsumos");
            this.dgvConsumos.AllowUserToAddRows = false;
            this.dgvConsumos.AllowUserToDeleteRows = false;
            this.dgvConsumos.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsumos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsumos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.CodHospedagem,
            this.CodProduto,
            this.Produto,
            this.TipoProduto,
            this.Valor,
            this.QuantidadeConsumida,
            this.ValorTotal,
            this.DataConsumo});
            this.dgvConsumos.MultiSelect = false;
            this.dgvConsumos.Name = "dgvConsumos";
            this.dgvConsumos.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsumos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConsumos.RowHeadersVisible = false;
            this.dgvConsumos.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvConsumos.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvConsumos.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            this.dgvConsumos.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvConsumos.RowTemplate.Height = 25;
            this.dgvConsumos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsumos.TabStop = false;
            this.dgvConsumos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsumos_CellDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            resources.ApplyResources(this.Codigo, "Codigo");
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // CodHospedagem
            // 
            this.CodHospedagem.DataPropertyName = "CodHospedagem";
            resources.ApplyResources(this.CodHospedagem, "CodHospedagem");
            this.CodHospedagem.Name = "CodHospedagem";
            this.CodHospedagem.ReadOnly = true;
            // 
            // CodProduto
            // 
            this.CodProduto.DataPropertyName = "CodProduto";
            resources.ApplyResources(this.CodProduto, "CodProduto");
            this.CodProduto.Name = "CodProduto";
            this.CodProduto.ReadOnly = true;
            // 
            // Produto
            // 
            this.Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Produto.DataPropertyName = "Nome";
            resources.ApplyResources(this.Produto, "Produto");
            this.Produto.Name = "Produto";
            this.Produto.ReadOnly = true;
            // 
            // TipoProduto
            // 
            this.TipoProduto.DataPropertyName = "TipoProduto";
            resources.ApplyResources(this.TipoProduto, "TipoProduto");
            this.TipoProduto.Name = "TipoProduto";
            this.TipoProduto.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            resources.ApplyResources(this.Valor, "Valor");
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // QuantidadeConsumida
            // 
            this.QuantidadeConsumida.DataPropertyName = "QuantidadeConsumida";
            resources.ApplyResources(this.QuantidadeConsumida, "QuantidadeConsumida");
            this.QuantidadeConsumida.Name = "QuantidadeConsumida";
            this.QuantidadeConsumida.ReadOnly = true;
            // 
            // ValorTotal
            // 
            this.ValorTotal.DataPropertyName = "ValorTotal";
            resources.ApplyResources(this.ValorTotal, "ValorTotal");
            this.ValorTotal.Name = "ValorTotal";
            this.ValorTotal.ReadOnly = true;
            // 
            // DataConsumo
            // 
            this.DataConsumo.DataPropertyName = "DataConsumo";
            resources.ApplyResources(this.DataConsumo, "DataConsumo");
            this.DataConsumo.Name = "DataConsumo";
            this.DataConsumo.ReadOnly = true;
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stLbAviso,
            this.stLbAvisoTxt});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // stLbAviso
            // 
            resources.ApplyResources(this.stLbAviso, "stLbAviso");
            this.stLbAviso.BackColor = System.Drawing.Color.White;
            this.stLbAviso.ForeColor = System.Drawing.Color.Black;
            this.stLbAviso.Name = "stLbAviso";
            // 
            // stLbAvisoTxt
            // 
            resources.ApplyResources(this.stLbAvisoTxt, "stLbAvisoTxt");
            this.stLbAvisoTxt.BackColor = System.Drawing.Color.White;
            this.stLbAvisoTxt.ForeColor = System.Drawing.Color.Red;
            this.stLbAvisoTxt.Name = "stLbAvisoTxt";
            // 
            // TelaControleConsumos
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(143)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVoltar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TelaControleConsumos";
            this.Load += new System.EventHandler(this.TelaControleConsumos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxAdicionar.ResumeLayout(false);
            this.gboxAdicionar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumos)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stLbAviso;
        private System.Windows.Forms.ToolStripStatusLabel stLbAvisoTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvConsumos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodHospedagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeConsumida;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataConsumo;
        private System.Windows.Forms.GroupBox gboxAdicionar;
        private System.Windows.Forms.RadioButton rbMercadoria;
        private System.Windows.Forms.RadioButton rbServico;
        private System.Windows.Forms.NumericUpDown numQtd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox mtxtValTot;
        private System.Windows.Forms.MaskedTextBox mtxtUnitario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbProdutos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mtxtTotConsumo;
        private System.Windows.Forms.MaskedTextBox mtxtValUnit;
        private System.Windows.Forms.TextBox txtQtd;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.TextBox txtDataConsumo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdicionar;
    }
}