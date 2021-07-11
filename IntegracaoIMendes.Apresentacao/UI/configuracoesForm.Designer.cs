
namespace IntegracaoIMendes.Apresentacao.UI
{
    partial class configuracoesForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.qtdCaracteristicasTributariasPorRequisicaonumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.qtdUfsPorRequisicaonumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.qtdProdutosPorRequisicaonumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.salvarbutton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cnpjClientetextBox = new System.Windows.Forms.TextBox();
            this.ambientecomboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.senhaIMendestextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loginIMendestextBox = new System.Windows.Forms.TextBox();
            this.qtdDiariaRequisicoesIMendesnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtdCaracteristicasTributariasPorRequisicaonumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtdUfsPorRequisicaonumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtdProdutosPorRequisicaonumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtdDiariaRequisicoesIMendesnumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.qtdDiariaRequisicoesIMendesnumericUpDown);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.qtdCaracteristicasTributariasPorRequisicaonumericUpDown);
            this.groupBox1.Controls.Add(this.qtdUfsPorRequisicaonumericUpDown);
            this.groupBox1.Controls.Add(this.qtdProdutosPorRequisicaonumericUpDown);
            this.groupBox1.Controls.Add(this.salvarbutton);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cnpjClientetextBox);
            this.groupBox1.Controls.Add(this.ambientecomboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.senhaIMendestextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.loginIMendestextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 292);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parâmetros";
            // 
            // qtdCaracteristicasTributariasPorRequisicaonumericUpDown
            // 
            this.qtdCaracteristicasTributariasPorRequisicaonumericUpDown.Location = new System.Drawing.Point(182, 193);
            this.qtdCaracteristicasTributariasPorRequisicaonumericUpDown.Name = "qtdCaracteristicasTributariasPorRequisicaonumericUpDown";
            this.qtdCaracteristicasTributariasPorRequisicaonumericUpDown.Size = new System.Drawing.Size(170, 23);
            this.qtdCaracteristicasTributariasPorRequisicaonumericUpDown.TabIndex = 19;
            // 
            // qtdUfsPorRequisicaonumericUpDown
            // 
            this.qtdUfsPorRequisicaonumericUpDown.Location = new System.Drawing.Point(6, 193);
            this.qtdUfsPorRequisicaonumericUpDown.Name = "qtdUfsPorRequisicaonumericUpDown";
            this.qtdUfsPorRequisicaonumericUpDown.Size = new System.Drawing.Size(170, 23);
            this.qtdUfsPorRequisicaonumericUpDown.TabIndex = 18;
            // 
            // qtdProdutosPorRequisicaonumericUpDown
            // 
            this.qtdProdutosPorRequisicaonumericUpDown.Location = new System.Drawing.Point(182, 147);
            this.qtdProdutosPorRequisicaonumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.qtdProdutosPorRequisicaonumericUpDown.Name = "qtdProdutosPorRequisicaonumericUpDown";
            this.qtdProdutosPorRequisicaonumericUpDown.Size = new System.Drawing.Size(170, 23);
            this.qtdProdutosPorRequisicaonumericUpDown.TabIndex = 17;
            this.qtdProdutosPorRequisicaonumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // salvarbutton
            // 
            this.salvarbutton.Location = new System.Drawing.Point(363, 241);
            this.salvarbutton.Name = "salvarbutton";
            this.salvarbutton.Size = new System.Drawing.Size(107, 31);
            this.salvarbutton.TabIndex = 16;
            this.salvarbutton.Text = "Salvar";
            this.salvarbutton.UseVisualStyleBackColor = true;
            this.salvarbutton.Click += new System.EventHandler(this.salvarbutton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(182, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Qtd. Caract. Trib. por Requisição:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Qtd. UF\'s por Requisição:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Qtd. Produtos por Requisição:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "CNPJ Cliente:";
            // 
            // cnpjClientetextBox
            // 
            this.cnpjClientetextBox.Location = new System.Drawing.Point(182, 95);
            this.cnpjClientetextBox.MaxLength = 14;
            this.cnpjClientetextBox.Name = "cnpjClientetextBox";
            this.cnpjClientetextBox.Size = new System.Drawing.Size(170, 23);
            this.cnpjClientetextBox.TabIndex = 6;
            // 
            // ambientecomboBox
            // 
            this.ambientecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ambientecomboBox.FormattingEnabled = true;
            this.ambientecomboBox.Location = new System.Drawing.Point(6, 95);
            this.ambientecomboBox.Name = "ambientecomboBox";
            this.ambientecomboBox.Size = new System.Drawing.Size(170, 23);
            this.ambientecomboBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ambiente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Senha IMendes:";
            // 
            // senhaIMendestextBox
            // 
            this.senhaIMendestextBox.Location = new System.Drawing.Point(182, 46);
            this.senhaIMendestextBox.MaxLength = 30;
            this.senhaIMendestextBox.Name = "senhaIMendestextBox";
            this.senhaIMendestextBox.PasswordChar = '*';
            this.senhaIMendestextBox.Size = new System.Drawing.Size(170, 23);
            this.senhaIMendestextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login IMendes:";
            // 
            // loginIMendestextBox
            // 
            this.loginIMendestextBox.Location = new System.Drawing.Point(6, 46);
            this.loginIMendestextBox.MaxLength = 30;
            this.loginIMendestextBox.Name = "loginIMendestextBox";
            this.loginIMendestextBox.Size = new System.Drawing.Size(170, 23);
            this.loginIMendestextBox.TabIndex = 0;
            // 
            // qtdDiariaRequisicoesIMendesnumericUpDown
            // 
            this.qtdDiariaRequisicoesIMendesnumericUpDown.Location = new System.Drawing.Point(6, 147);
            this.qtdDiariaRequisicoesIMendesnumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.qtdDiariaRequisicoesIMendesnumericUpDown.Name = "qtdDiariaRequisicoesIMendesnumericUpDown";
            this.qtdDiariaRequisicoesIMendesnumericUpDown.Size = new System.Drawing.Size(170, 23);
            this.qtdDiariaRequisicoesIMendesnumericUpDown.TabIndex = 21;
            this.qtdDiariaRequisicoesIMendesnumericUpDown.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Qtd. Diária Requisições IMendes";
            // 
            // configuracoesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(524, 316);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "configuracoesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações Integrador IMendes";
            this.Load += new System.EventHandler(this.configuracoesForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtdCaracteristicasTributariasPorRequisicaonumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtdUfsPorRequisicaonumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtdProdutosPorRequisicaonumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtdDiariaRequisicoesIMendesnumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox senhaIMendestextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox loginIMendestextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cnpjClientetextBox;
        private System.Windows.Forms.ComboBox ambientecomboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button salvarbutton;
        private System.Windows.Forms.NumericUpDown qtdCaracteristicasTributariasPorRequisicaonumericUpDown;
        private System.Windows.Forms.NumericUpDown qtdUfsPorRequisicaonumericUpDown;
        private System.Windows.Forms.NumericUpDown qtdProdutosPorRequisicaonumericUpDown;
        private System.Windows.Forms.NumericUpDown qtdDiariaRequisicoesIMendesnumericUpDown;
        private System.Windows.Forms.Label label8;
    }
}