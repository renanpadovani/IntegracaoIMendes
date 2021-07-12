
namespace IntegracaoIMendes.Apresentacao.Formularios
{
    partial class ConfiguracoesBDForm
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
            this.salvarbutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.senhatextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.usuariotextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bancoDeDadostextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.servidortextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.salvarbutton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.senhatextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.usuariotextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bancoDeDadostextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.servidortextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 288);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Credenciais";
            // 
            // salvarbutton
            // 
            this.salvarbutton.Location = new System.Drawing.Point(250, 241);
            this.salvarbutton.Name = "salvarbutton";
            this.salvarbutton.Size = new System.Drawing.Size(107, 31);
            this.salvarbutton.TabIndex = 17;
            this.salvarbutton.Text = "Salvar";
            this.salvarbutton.UseVisualStyleBackColor = true;
            this.salvarbutton.Click += new System.EventHandler(this.salvarbutton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Senha:";
            // 
            // senhatextBox
            // 
            this.senhatextBox.Location = new System.Drawing.Point(6, 188);
            this.senhatextBox.MaxLength = 30;
            this.senhatextBox.Name = "senhatextBox";
            this.senhatextBox.PasswordChar = '*';
            this.senhatextBox.Size = new System.Drawing.Size(170, 23);
            this.senhatextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Usuário:";
            // 
            // usuariotextBox
            // 
            this.usuariotextBox.Location = new System.Drawing.Point(6, 140);
            this.usuariotextBox.MaxLength = 30;
            this.usuariotextBox.Name = "usuariotextBox";
            this.usuariotextBox.Size = new System.Drawing.Size(170, 23);
            this.usuariotextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Banco de Dados:";
            // 
            // bancoDeDadostextBox
            // 
            this.bancoDeDadostextBox.Location = new System.Drawing.Point(6, 92);
            this.bancoDeDadostextBox.MaxLength = 30;
            this.bancoDeDadostextBox.Name = "bancoDeDadostextBox";
            this.bancoDeDadostextBox.Size = new System.Drawing.Size(232, 23);
            this.bancoDeDadostextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Servidor:";
            // 
            // servidortextBox
            // 
            this.servidortextBox.Location = new System.Drawing.Point(6, 45);
            this.servidortextBox.MaxLength = 30;
            this.servidortextBox.Name = "servidortextBox";
            this.servidortextBox.Size = new System.Drawing.Size(232, 23);
            this.servidortextBox.TabIndex = 2;
            // 
            // ConfiguracoesBDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(398, 312);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfiguracoesBDForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações de Conexão ao Banco de Dados do INFAST ERP";
            this.Load += new System.EventHandler(this.ConfiguracoesBDForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox senhatextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usuariotextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bancoDeDadostextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox servidortextBox;
        private System.Windows.Forms.Button salvarbutton;
    }
}