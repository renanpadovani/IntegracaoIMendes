using IntegracaoIMendes.Dominio.Entidades.IMendes;
using IntegracaoIMendes.Dominio.Servicos;
using IntegracaoIMendes.Testes.Servicos.Mocks;
using NUnit.Framework;

namespace IntegracaoIMendes.Testes.Servicos
{
    public class IMendesServicoTestes
    {
        TributosRequisicaoMocks _tributosRequisicaoMoks;
        IMendesServico _iMendesServico;

        public IMendesServicoTestes()
        {
            _tributosRequisicaoMoks = new TributosRequisicaoMocks();
        }

        private IMendesServico RetornarInstanciaObjetoIMendesServicoSemInformarCredenciais()
        {
            const string loginInvalido = "";
            const string senhaInvalida = "";

            return new IMendesServico(loginInvalido, senhaInvalida);
        }

        private IMendesServico RetornarInstanciaObjetoIMendesServicoComCredenciaisInvalidas()
        {
            const string loginInvalido = "62488937000105";
            const string senhaInvalida = "senhaInvalida";

            return new IMendesServico(loginInvalido, senhaInvalida);
        }

        private IMendesServico RetornarInstanciaObjetoIMendesServicoComCredenciaisValidas()
        {
            const string loginValido = "08956337000189";
            const string senhaValida = "ItDFirzvFV41";

            return new IMendesServico(loginValido, senhaValida);
        }

        [Test]
        public void ValidarMetodo_PesquisarTributos_ComCredenciaisInvalidas()
        {
            _iMendesServico = RetornarInstanciaObjetoIMendesServicoComCredenciaisInvalidas();

            TributosRetorno retornoIMendes = _iMendesServico.PesquisarTributos(_tributosRequisicaoMoks.RetornarInstanciaTributosRetornoValida());

            Assert.IsTrue(retornoIMendes.ErroRetorno == true);
        }

        [Test]
        public void ValidarMetodo_PesquisarTributos_SemCredenciais()
        {
            _iMendesServico = RetornarInstanciaObjetoIMendesServicoSemInformarCredenciais();

            TributosRetorno retornoIMendes = _iMendesServico.PesquisarTributos(_tributosRequisicaoMoks.RetornarInstanciaTributosRetornoValida());

            Assert.IsTrue(retornoIMendes.ErroRetorno == true);
        }

        [Test]
        public void ValidarMetodo_PesquisarTributos_ComCredenciaisValidas()
        {
            _iMendesServico = RetornarInstanciaObjetoIMendesServicoComCredenciaisValidas();

            TributosRetorno retornoIMendes = _iMendesServico.PesquisarTributos(_tributosRequisicaoMoks.RetornarInstanciaTributosRetornoValida());

            Assert.IsTrue(retornoIMendes.ErroRetorno == false);
        }
    }
}
