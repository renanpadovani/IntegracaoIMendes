using IntegracaoIMendes.Dominio.Entidades.IMendes;
using IntegracaoIMendes.Dominio.Servicos;
using IntegracaoIMendes.Testes.Servicos.Mocks;
using NUnit.Framework;

namespace IntegracaoIMendes.Testes.Servicos
{
    public class IMendesServicoTestes
    {
        TributosRequisicaoMocks _tributosRequisicaoMoks;
        IMendesServico _iMendesServicoValido;
        IMendesServico _iMendesServicoInvalido;

        public IMendesServicoTestes()
        {
            _iMendesServicoInvalido = RetornarInstanciaObjetoIMendesServicoComCredenciaisInvalidas();
            _iMendesServicoValido = RetornarInstanciaObjetoIMendesServicoComCredenciaisValidas();
            _tributosRequisicaoMoks = new TributosRequisicaoMocks();
        }

        private IMendesServico RetornarInstanciaObjetoIMendesServicoComCredenciaisInvalidas()
        {
            return new IMendesServico("","");
        }

        private IMendesServico RetornarInstanciaObjetoIMendesServicoComCredenciaisValidas()
        {
            return new IMendesServico("08956337000189", "ItDFirzvFV41");
        }

        [Test]
        public void ValidarMetodo_PesquisarTributos_ComCredenciaisInvalidas()
        {
            TributosRetorno retornoIMendes = _iMendesServicoInvalido.PesquisarTributos(_tributosRequisicaoMoks.RetornarInstanciaTributosRetornoValida());

            Assert.IsTrue(retornoIMendes.ErroRetorno == true);
        }

        [Test]
        public void ValidarMetodo_PesquisarTributos_ComCredenciaisValidas()
        {
            TributosRetorno retornoIMendes = _iMendesServicoValido.PesquisarTributos(_tributosRequisicaoMoks.RetornarInstanciaTributosRetornoValida());

            Assert.IsTrue(retornoIMendes.ErroRetorno == false);
        }

    }
}
