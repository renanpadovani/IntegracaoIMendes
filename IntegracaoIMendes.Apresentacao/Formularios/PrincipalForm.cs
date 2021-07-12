using IntegracaoIMendes.Dominio.Manipuladores.Infast;
using IntegracaoIMendes.Apresentacao.Servicos;
using System;
using System.Windows.Forms;
using IntegracaoIMendes.Dominio.Entidades.Infast;

namespace IntegracaoIMendes.Apresentacao.Formularios
{
    public partial class PrincipalForm : Form
    {
        Dominio.ContextoDados.InfastContextoDados _contexto;
        ProcessamentoCenariosManipulador _processamentoCenariosManipulador;

        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarCredenciaisBancoDeDados();

                _contexto = new Dominio.ContextoDados.InfastContextoDados(Properties.Settings.Default.Server.ToString(), Properties.Settings.Default.Database.ToString(), Properties.Settings.Default.User.ToString(), Properties.Settings.Default.Password.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - " + ex.InnerException);
            }

        }

        private void CarregarCredenciaisBancoDeDados()
        {
            ConnectionDbServico.CarregarCredenciais();

            if (Properties.Settings.Default.Server == null || Properties.Settings.Default.Server.ToString().Length == 0)
            {
                MessageBox.Show("Atenção: É necessário configurar as credenciais de banco de dados antes de iniciar integrador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ConfiguracoesBDForm oFormConfigBD = new ConfiguracoesBDForm();
                oFormConfigBD.ShowDialog();

                CarregarCredenciaisBancoDeDados();
            }
        }

        private void processarTributosbutton_Click(object sender, EventArgs e)
        {
            _processamentoCenariosManipulador = new ProcessamentoCenariosManipulador(_contexto, CarregarConfiguracaoIMendes());

            _processamentoCenariosManipulador.ProcessarCenarios();
        }

        private Configuracoes CarregarConfiguracaoIMendes()
        {
            ConfiguracoesManipulador configuracoesManipulador = new ConfiguracoesManipulador(_contexto);

            return configuracoesManipulador.CarregarConfiguracao();
        }

        private void EscreverMensagemLog(string mensagem)
        {
            logIntegracaolistBox.Items.Add(System.DateTime.Now.ToString("dd/MM/yy HH:mm:ss") + ": " + mensagem);
        }

        private void credenciaisBancoDeDadosINFASTERPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracoesBDForm oFormConfiguracaoBD = new ConfiguracoesBDForm();
            oFormConfiguracaoBD.ShowDialog();
        }

        private void configuraçõesIMendesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuracoesForm oFormConfiguracao = new configuracoesForm();
            oFormConfiguracao.ShowDialog();
        }

        private void cenáriosTributáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cenariosTributariosForm oFormCenario = new cenariosTributariosForm();
            oFormCenario.ShowDialog();
        }

        private void logIntegracaotimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
