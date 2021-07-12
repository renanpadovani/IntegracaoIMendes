using IntegracaoIMendes.Apresentacao.Servicos;
using System;
using System.Windows.Forms;

namespace IntegracaoIMendes.Apresentacao.Formularios
{
    public partial class ConfiguracoesBDForm : Form
    {
        public ConfiguracoesBDForm()
        {
            InitializeComponent();
        }

        private void ConfiguracoesBDForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Server != null) servidortextBox.Text = Properties.Settings.Default.Server.ToString();
            if (Properties.Settings.Default.Database != null) bancoDeDadostextBox.Text = Properties.Settings.Default.Database.ToString();
            if (Properties.Settings.Default.User != null) usuariotextBox.Text = Properties.Settings.Default.User.ToString();
            if (Properties.Settings.Default.Password != null) senhatextBox.Text = Properties.Settings.Default.Password.ToString();
        }

        private void salvarbutton_Click(object sender, EventArgs e)
        {
            if (servidortextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Atenção: Servidor não informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (bancoDeDadostextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Atenção: Banco de dados não informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (usuariotextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Atenção: Usuário não informado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (senhatextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Atenção: Senha não informada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SalvarCredenciais(servidortextBox.Text, bancoDeDadostextBox.Text, usuariotextBox.Text, senhatextBox.Text);
        }

        private void SalvarCredenciais(string server, string database, string user, string password)
        {
            try
            {
                Dominio.ContextoDados.InfastContextoDados _contexto = new Dominio.ContextoDados.InfastContextoDados(server, database, user, password);

                ConexaoBDServico.SalvarCredenciais(server, database, user, password);

                MessageBox.Show("Crendenciais de banco de dados salva com sucesso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao salvar as credenciais de banco de dados:" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
