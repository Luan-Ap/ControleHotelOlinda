
namespace ControleHotel.Forms
{
    partial class TelaControleQuarto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaControleQuarto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvQuartos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumQuarto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxAcompanhantes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodTipoQuarto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grBoxControleQuarto = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stLbAviso = new System.Windows.Forms.ToolStripStatusLabel();
            this.stLbAvisoTxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDesativar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.mtxtValor = new System.Windows.Forms.MaskedTextBox();
            this.mtxtNum = new System.Windows.Forms.MaskedTextBox();
            this.txtCadastro = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuartos)).BeginInit();
            this.grBoxControleQuarto.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQuartos
            // 
            resources.ApplyResources(this.dgvQuartos, "dgvQuartos");
            this.dgvQuartos.AllowUserToAddRows = false;
            this.dgvQuartos.AllowUserToDeleteRows = false;
            this.dgvQuartos.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuartos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQuartos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvQuartos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.NumQuarto,
            this.Tipo,
            this.MaxAcompanhantes,
            this.Valor,
            this.DataCadastro,
            this.Descricao,
            this.CodTipoQuarto,
            this.Ativo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuartos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQuartos.MultiSelect = false;
            this.dgvQuartos.Name = "dgvQuartos";
            this.dgvQuartos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuartos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvQuartos.RowHeadersVisible = false;
            this.dgvQuartos.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvQuartos.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvQuartos.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            this.dgvQuartos.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvQuartos.RowTemplate.Height = 25;
            this.dgvQuartos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuartos.TabStop = false;
            this.dgvQuartos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvQuartos_CellDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            resources.ApplyResources(this.Codigo, "Codigo");
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // NumQuarto
            // 
            this.NumQuarto.DataPropertyName = "NumQuarto";
            resources.ApplyResources(this.NumQuarto, "NumQuarto");
            this.NumQuarto.Name = "NumQuarto";
            this.NumQuarto.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            resources.ApplyResources(this.Tipo, "Tipo");
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // MaxAcompanhantes
            // 
            this.MaxAcompanhantes.DataPropertyName = "MaxAcompanhantes";
            resources.ApplyResources(this.MaxAcompanhantes, "MaxAcompanhantes");
            this.MaxAcompanhantes.Name = "MaxAcompanhantes";
            this.MaxAcompanhantes.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Valor.DataPropertyName = "Valor";
            resources.ApplyResources(this.Valor, "Valor");
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // DataCadastro
            // 
            this.DataCadastro.DataPropertyName = "DataCadastro";
            resources.ApplyResources(this.DataCadastro, "DataCadastro");
            this.DataCadastro.Name = "DataCadastro";
            this.DataCadastro.ReadOnly = true;
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "Descricao";
            resources.ApplyResources(this.Descricao, "Descricao");
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            // 
            // CodTipoQuarto
            // 
            this.CodTipoQuarto.DataPropertyName = "CodTipoQuarto";
            resources.ApplyResources(this.CodTipoQuarto, "CodTipoQuarto");
            this.CodTipoQuarto.Name = "CodTipoQuarto";
            this.CodTipoQuarto.ReadOnly = true;
            // 
            // Ativo
            // 
            this.Ativo.DataPropertyName = "Ativo";
            resources.ApplyResources(this.Ativo, "Ativo");
            this.Ativo.Name = "Ativo";
            this.Ativo.ReadOnly = true;
            // 
            // grBoxControleQuarto
            // 
            resources.ApplyResources(this.grBoxControleQuarto, "grBoxControleQuarto");
            this.grBoxControleQuarto.Controls.Add(this.statusStrip1);
            this.grBoxControleQuarto.Controls.Add(this.btnDesativar);
            this.grBoxControleQuarto.Controls.Add(this.btnConsultar);
            this.grBoxControleQuarto.Controls.Add(this.btnAtualizar);
            this.grBoxControleQuarto.Controls.Add(this.mtxtValor);
            this.grBoxControleQuarto.Controls.Add(this.mtxtNum);
            this.grBoxControleQuarto.Controls.Add(this.txtCadastro);
            this.grBoxControleQuarto.Controls.Add(this.txtTipo);
            this.grBoxControleQuarto.Controls.Add(this.txtDescricao);
            this.grBoxControleQuarto.Controls.Add(this.label5);
            this.grBoxControleQuarto.Controls.Add(this.label3);
            this.grBoxControleQuarto.Controls.Add(this.label4);
            this.grBoxControleQuarto.Controls.Add(this.label2);
            this.grBoxControleQuarto.Controls.Add(this.label6);
            this.grBoxControleQuarto.Controls.Add(this.label1);
            this.grBoxControleQuarto.Controls.Add(this.dgvQuartos);
            this.grBoxControleQuarto.ForeColor = System.Drawing.Color.White;
            this.grBoxControleQuarto.Name = "grBoxControleQuarto";
            this.grBoxControleQuarto.TabStop = false;
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
            // btnDesativar
            // 
            resources.ApplyResources(this.btnDesativar, "btnDesativar");
            this.btnDesativar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesativar.FlatAppearance.BorderSize = 2;
            this.btnDesativar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnDesativar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnDesativar.Name = "btnDesativar";
            this.btnDesativar.UseVisualStyleBackColor = true;
            this.btnDesativar.Click += new System.EventHandler(this.BtnDesativar_Click);
            // 
            // btnConsultar
            // 
            resources.ApplyResources(this.btnConsultar, "btnConsultar");
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.FlatAppearance.BorderSize = 2;
            this.btnConsultar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnConsultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // btnAtualizar
            // 
            resources.ApplyResources(this.btnAtualizar, "btnAtualizar");
            this.btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizar.FlatAppearance.BorderSize = 2;
            this.btnAtualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnAtualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.BtnAtualizar_Click);
            // 
            // mtxtValor
            // 
            resources.ApplyResources(this.mtxtValor, "mtxtValor");
            this.mtxtValor.Name = "mtxtValor";
            this.mtxtValor.ReadOnly = true;
            // 
            // mtxtNum
            // 
            resources.ApplyResources(this.mtxtNum, "mtxtNum");
            this.mtxtNum.Name = "mtxtNum";
            // 
            // txtCadastro
            // 
            resources.ApplyResources(this.txtCadastro, "txtCadastro");
            this.txtCadastro.Name = "txtCadastro";
            this.txtCadastro.ReadOnly = true;
            // 
            // txtTipo
            // 
            resources.ApplyResources(this.txtTipo, "txtTipo");
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            // 
            // txtDescricao
            // 
            resources.ApplyResources(this.txtDescricao, "txtDescricao");
            this.txtDescricao.Name = "txtDescricao";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
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
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            // TelaControleQuarto
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(143)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.grBoxControleQuarto);
            this.Controls.Add(this.btnVoltar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TelaControleQuarto";
            this.Enter += new System.EventHandler(this.TelaControleQuarto_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuartos)).EndInit();
            this.grBoxControleQuarto.ResumeLayout(false);
            this.grBoxControleQuarto.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQuartos;
        private System.Windows.Forms.GroupBox grBoxControleQuarto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumQuarto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxAcompanhantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCadastro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodTipoQuarto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ativo;
        private System.Windows.Forms.MaskedTextBox mtxtNum;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtxtValor;
        private System.Windows.Forms.TextBox txtCadastro;
        private System.Windows.Forms.Button btnDesativar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stLbAviso;
        private System.Windows.Forms.ToolStripStatusLabel stLbAvisoTxt;
        private System.Windows.Forms.Button btnVoltar;
    }
}