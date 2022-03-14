
namespace ControleHotel.Forms
{
    partial class TelaControleClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaControleClientes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numEndereco = new System.Windows.Forms.NumericUpDown();
            this.mtxtCep = new System.Windows.Forms.MaskedTextBox();
            this.mtxtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mtxtRg = new System.Windows.Forms.MaskedTextBox();
            this.mtxtCpf = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSobrenome = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtNascimento = new System.Windows.Forms.TextBox();
            this.txtCadastro = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDesativar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stLbAviso = new System.Windows.Forms.ToolStripStatusLabel();
            this.stLbAvisoTxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sobrenome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodEndereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataNascimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextoEndereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEndereco)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnDesativar);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.btnAtualizar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.statusStrip1);
            this.groupBox1.Controls.Add(this.dgvClientes);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.numEndereco);
            this.groupBox3.Controls.Add(this.mtxtCep);
            this.groupBox3.Controls.Add(this.mtxtTelefone);
            this.groupBox3.Controls.Add(this.txtEstado);
            this.groupBox3.Controls.Add(this.txtRua);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // numEndereco
            // 
            resources.ApplyResources(this.numEndereco, "numEndereco");
            this.numEndereco.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numEndereco.Name = "numEndereco";
            this.numEndereco.ReadOnly = true;
            // 
            // mtxtCep
            // 
            resources.ApplyResources(this.mtxtCep, "mtxtCep");
            this.mtxtCep.Name = "mtxtCep";
            this.mtxtCep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // mtxtTelefone
            // 
            resources.ApplyResources(this.mtxtTelefone, "mtxtTelefone");
            this.mtxtTelefone.Name = "mtxtTelefone";
            this.mtxtTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtEstado
            // 
            resources.ApplyResources(this.txtEstado, "txtEstado");
            this.txtEstado.Name = "txtEstado";
            // 
            // txtRua
            // 
            resources.ApplyResources(this.txtRua, "txtRua");
            this.txtRua.Name = "txtRua";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.mtxtRg);
            this.groupBox2.Controls.Add(this.mtxtCpf);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.txtSobrenome);
            this.groupBox2.Controls.Add(this.txtNome);
            this.groupBox2.Controls.Add(this.txtNascimento);
            this.groupBox2.Controls.Add(this.txtCadastro);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // mtxtRg
            // 
            resources.ApplyResources(this.mtxtRg, "mtxtRg");
            this.mtxtRg.Name = "mtxtRg";
            this.mtxtRg.ReadOnly = true;
            this.mtxtRg.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // mtxtCpf
            // 
            resources.ApplyResources(this.mtxtCpf, "mtxtCpf");
            this.mtxtCpf.Name = "mtxtCpf";
            this.mtxtCpf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtEmail
            // 
            resources.ApplyResources(this.txtEmail, "txtEmail");
            this.txtEmail.Name = "txtEmail";
            // 
            // txtSobrenome
            // 
            resources.ApplyResources(this.txtSobrenome, "txtSobrenome");
            this.txtSobrenome.Name = "txtSobrenome";
            // 
            // txtNome
            // 
            resources.ApplyResources(this.txtNome, "txtNome");
            this.txtNome.Name = "txtNome";
            // 
            // txtNascimento
            // 
            resources.ApplyResources(this.txtNascimento, "txtNascimento");
            this.txtNascimento.Name = "txtNascimento";
            this.txtNascimento.ReadOnly = true;
            // 
            // txtCadastro
            // 
            resources.ApplyResources(this.txtCadastro, "txtCadastro");
            this.txtCadastro.Name = "txtCadastro";
            this.txtCadastro.ReadOnly = true;
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
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
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
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
            // dgvClientes
            // 
            resources.ApplyResources(this.dgvClientes, "dgvClientes");
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nome,
            this.Sobrenome,
            this.Cpf,
            this.Rg,
            this.Email,
            this.CodEndereco,
            this.DataNascimento,
            this.DataCadastro,
            this.Ativo,
            this.TextoEndereco,
            this.Numero,
            this.Cep,
            this.Telefone,
            this.Estado});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvClientes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvClientes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            this.dgvClientes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvClientes.RowTemplate.Height = 25;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.TabStop = false;
            this.dgvClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvClientes_CellDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            resources.ApplyResources(this.Codigo, "Codigo");
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            resources.ApplyResources(this.Nome, "Nome");
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // Sobrenome
            // 
            this.Sobrenome.DataPropertyName = "Sobrenome";
            resources.ApplyResources(this.Sobrenome, "Sobrenome");
            this.Sobrenome.Name = "Sobrenome";
            this.Sobrenome.ReadOnly = true;
            // 
            // Cpf
            // 
            this.Cpf.DataPropertyName = "Cpf";
            resources.ApplyResources(this.Cpf, "Cpf");
            this.Cpf.Name = "Cpf";
            this.Cpf.ReadOnly = true;
            // 
            // Rg
            // 
            this.Rg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rg.DataPropertyName = "Rg";
            resources.ApplyResources(this.Rg, "Rg");
            this.Rg.Name = "Rg";
            this.Rg.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Email.DataPropertyName = "Email";
            resources.ApplyResources(this.Email, "Email");
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // CodEndereco
            // 
            this.CodEndereco.DataPropertyName = "CodEndereco";
            resources.ApplyResources(this.CodEndereco, "CodEndereco");
            this.CodEndereco.Name = "CodEndereco";
            this.CodEndereco.ReadOnly = true;
            // 
            // DataNascimento
            // 
            this.DataNascimento.DataPropertyName = "DataNascimento";
            resources.ApplyResources(this.DataNascimento, "DataNascimento");
            this.DataNascimento.Name = "DataNascimento";
            this.DataNascimento.ReadOnly = true;
            // 
            // DataCadastro
            // 
            this.DataCadastro.DataPropertyName = "DataCadastro";
            resources.ApplyResources(this.DataCadastro, "DataCadastro");
            this.DataCadastro.Name = "DataCadastro";
            this.DataCadastro.ReadOnly = true;
            // 
            // Ativo
            // 
            this.Ativo.DataPropertyName = "Ativo";
            resources.ApplyResources(this.Ativo, "Ativo");
            this.Ativo.Name = "Ativo";
            this.Ativo.ReadOnly = true;
            // 
            // TextoEndereco
            // 
            this.TextoEndereco.DataPropertyName = "TextoEndereco";
            resources.ApplyResources(this.TextoEndereco, "TextoEndereco");
            this.TextoEndereco.Name = "TextoEndereco";
            this.TextoEndereco.ReadOnly = true;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            resources.ApplyResources(this.Numero, "Numero");
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // Cep
            // 
            this.Cep.DataPropertyName = "Cep";
            resources.ApplyResources(this.Cep, "Cep");
            this.Cep.Name = "Cep";
            this.Cep.ReadOnly = true;
            // 
            // Telefone
            // 
            this.Telefone.DataPropertyName = "Telefone";
            resources.ApplyResources(this.Telefone, "Telefone");
            this.Telefone.Name = "Telefone";
            this.Telefone.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            resources.ApplyResources(this.Estado, "Estado");
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
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
            // TelaControleClientes
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(143)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TelaControleClientes";
            this.Enter += new System.EventHandler(this.TelaControleClientes_Enter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEndereco)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stLbAviso;
        private System.Windows.Forms.ToolStripStatusLabel stLbAvisoTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDesativar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox mtxtRg;
        private System.Windows.Forms.MaskedTextBox mtxtCpf;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSobrenome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtNascimento;
        private System.Windows.Forms.TextBox txtCadastro;
        private System.Windows.Forms.MaskedTextBox mtxtCep;
        private System.Windows.Forms.MaskedTextBox mtxtTelefone;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtRua;
        private System.Windows.Forms.NumericUpDown numEndereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sobrenome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cpf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodEndereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataNascimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCadastro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TextoEndereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}