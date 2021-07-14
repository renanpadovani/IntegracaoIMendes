using IntegracaoIMendes.Dominio.Manipuladores.Infast;
using IntegracaoIMendes.Apresentacao.Servicos;
using System;
using System.Windows.Forms;
using IntegracaoIMendes.Dominio.Entidades.Infast;
using System.Collections.Generic;
using System.Linq;
using IntegracaoIMendes.Dominio.Repositorios;
using IntegracaoIMendes.Dominio.Manipuladores;
using IntegracaoIMendes.Dominio.Servicos;

namespace IntegracaoIMendes.Apresentacao.Formularios
{
    public partial class PrincipalForm : Form
    {
        Dominio.ContextoDados.InfastContextoDados _contexto;
        private List<string> listaMensagens = new List<string>();
        private Configuracoes _configuracao;

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

                _configuracao = CarregarConfiguracaoIMendes();

                if (_configuracao == null) 
                    listaMensagens.Add("É necessário configurar a integração antes de iniciá-la.");
                else
                    listaMensagens.Add("Aguardando integração.");

                logIntegracaotimer.Enabled = true;
                integracaotimer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao iniciar a conexão com o banco de dados:\n\n" + ex.Message + "\n\nEntre em contato com o suporte técnico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void CarregarCredenciaisBancoDeDados()
        {
            ConexaoBDServico.CarregarCredenciais();

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
            integracaobackgroundWorker.RunWorkerAsync();
        }

        private void credenciaisBancoDeDadosINFASTERPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracoesBDForm oFormConfiguracaoBD = new ConfiguracoesBDForm();
            oFormConfiguracaoBD.ShowDialog();
        }

        private void configuraçõesIMendesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuracoesForm oFormConfiguracao = new configuracoesForm(_contexto);
            oFormConfiguracao.ShowDialog();
        }

        private void cenáriosTributáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cenariosTributariosForm oFormCenario = new cenariosTributariosForm(_contexto);
            oFormCenario.ShowDialog();
        }

        private void integracaotimer_Tick(object sender, EventArgs e)
        {
            if (System.DateTime.Now.ToString("mm") == "00")
                integracaobackgroundWorker.RunWorkerAsync();
        }

        private void integracaobackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IniciarIntegracao();
        }

        private void IniciarIntegracao()
        {
            if (_configuracao != null)
            {
                listaMensagens.Add("Integração iniciada.");


                ProcessamentoCenariosRepositorio repositorioProcessamentoCenarios = new ProcessamentoCenariosRepositorio(_contexto);
                CenariosRepositorio repositorioCenarios = new CenariosRepositorio(_contexto);
                TributacoesRepositorio repositorioTributacoes = new TributacoesRepositorio(_contexto);
                ProdutosRepositorio repositorioProdutos = new ProdutosRepositorio(_contexto);
                ConfiguracoesRepositorio repositorioConfiguracoes = new ConfiguracoesRepositorio(_contexto);

                ProcessamentoCenariosServico _processamentoServico = new ProcessamentoCenariosServico(repositorioProcessamentoCenarios,
                                                                                                      repositorioCenarios,
                                                                                                      repositorioTributacoes,
                                                                                                      repositorioProdutos,
                                                                                                      repositorioConfiguracoes);

                _processamentoServico.ProcessarCenarios();



                listaMensagens.Add("Integração concluída, aguardando próximo ciclo.");
            }
            else
                listaMensagens.Add("É necessário configurar a integração antes de iniciá-la.");
        }

        private Configuracoes CarregarConfiguracaoIMendes()
        {
            ConfiguracoesRepositorio repositorioConfiguracoes = new ConfiguracoesRepositorio(_contexto);
            ConfiguracoesManipulador configuracoesManipulador = new ConfiguracoesManipulador(repositorioConfiguracoes);

            return configuracoesManipulador.CarregarConfiguracao();
        }

        private void logIntegracaotimer_Tick(object sender, EventArgs e)
        {
            while (listaMensagens.Count > 0)
            {
                statusIntegracaotoolStripStatusLabel.Text = System.DateTime.Now.ToString("dd/MM/yy HH:mm:ss: ") + listaMensagens[0];
                listaMensagens.RemoveAt(0);
            }            
        }
    }
}
