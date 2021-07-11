using IntegracaoIMendes.Domain.Handlers.Infast;
using IntegracaoIMendes.Apresentacao.Services;
using System;
using System.Windows.Forms;
using IntegracaoIMendes.Domain.Entities.Infast;
using IntegracaoIMendes.Domain.Repositories;
using System.Collections.Generic;
using IntegracaoIMendes.Domain.Handlers;
using System.Linq;

namespace IntegracaoIMendes.Apresentacao.UI
{
    public partial class PrincipalForm : Form
    {
        Domain.DataContext.InfastDataContext _context;
        ProcessamentoCenariosHandler _processamentoTributosHandler;

        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarCredenciaisBancoDeDados();

                _context = new Domain.DataContext.InfastDataContext(Properties.Settings.Default.Server.ToString(), Properties.Settings.Default.Database.ToString(), Properties.Settings.Default.User.ToString(), Properties.Settings.Default.Password.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - " + ex.InnerException);
            }

        }

        private void CarregarCredenciaisBancoDeDados()
        {
            ConnectionDbService.CarregarCredenciais();

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
            _processamentoTributosHandler = new ProcessamentoCenariosHandler(_context, CarregarConfiguracaoIMendes());

            IEnumerable<Cenarios> listaCenariosIMendes = CarregarCenariosIMendes();

            foreach (Cenarios cenario in listaCenariosIMendes)
            {
                if (cenario.DataHoraUltimoProcessamento.ToString("dd/MM/yyyy") == "01/01/1900" ||
                    DateTime.Compare(System.DateTime.Now, cenario.DataHoraUltimoProcessamento) > cenario.IntervaloDeBuscaEmDias)
                {
                    List<Produtos> produtosInfast = CarregarProdutosParaIntegracao(0, cenario.TipoProduto);

                    _processamentoTributosHandler.ProcessarTributosCenario(cenario, produtosInfast);
                }
            }
        }

        private void ProcessarTributosTodosCenarios()
        {
            EscreverMensagemLog("Iniciando integração...");

            logIntegracaotimer.Enabled = true;

            _processamentoTributosHandler = new ProcessamentoCenariosHandler(_context, CarregarConfiguracaoIMendes());

            _processamentoTributosHandler.ProcessarTributos(CarregarCenariosIMendes(), CarregarProdutosParaIntegracao());
        }

        private Configuracoes CarregarConfiguracaoIMendes()
        {
            ConfiguracoesRepositorio configRepositorio = new ConfiguracoesRepositorio(_context);
            ConfiguracoesHandler configuracoesHandler = new ConfiguracoesHandler(configRepositorio);

            return configuracoesHandler.CarregarConfiguracao();
        }

        private IEnumerable<Cenarios> CarregarCenariosIMendes()
        {
            CenariosRepositorio cenariosRepositorio = new CenariosRepositorio(_context);

            CenariosHandler cenariosHandler = new CenariosHandler(cenariosRepositorio);

            return cenariosHandler.CarregarListaCenarios();
        }

        private List<Produtos> CarregarProdutosParaIntegracao(Int64 produtoId = 0, string tipoClassificacaoProdutos = "")
        {
            ProdutosRepositorio produtoRepositorio = new ProdutosRepositorio(_context);

            ProdutosHandler produtosInfastHandler = new ProdutosHandler(produtoRepositorio);

            return produtosInfastHandler.PesquisarProdutos(produtoId, tipoClassificacaoProdutos).ToList();
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
            if (_processamentoTributosHandler != null)
            {

            }
        }
    }
}
