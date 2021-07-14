using System.Collections.Generic;
using NUnit.Framework;
using IntegracaoIMendes.Dominio.Servicos;
using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Enums;

namespace IntegracaoIMendes.Testes.Servicos
{
    public class CalculoRequisicoesIMendesServicoTeste
    {
        CalculoRequisicoesIMendesServico _calculoRequisicoesServico;

        public CalculoRequisicoesIMendesServicoTeste()
        {
            _calculoRequisicoesServico = new CalculoRequisicoesIMendesServico();
        }

        [Test]
        public void ValidarMetodo_RetornarNumeroRequisicoesIMendesEstimadasParaProcessamentoCenario_ComParametrosNulos()
        {
            var resultado = _calculoRequisicoesServico.RetornarNumeroRequisicoesIMendesEstimadasParaProcessamentoCenario(0, null, null);

            Assert.IsTrue(resultado == 0);
        }

        [Test]
        public void ValidarMetodo_RetornarNumeroRequisicoesIMendesEstimadasParaProcessamentoCenario_ComParametroInteiroENegativo()
        {
            var resultado = _calculoRequisicoesServico.RetornarNumeroRequisicoesIMendesEstimadasParaProcessamentoCenario(-50, null, null);

            Assert.IsTrue(resultado == 0);
        }

        [Test]
        public void ValidarMetodo_RetornarNumeroRequisicoesIMendesEstimadasParaProcessamentoCenario_ComParametrosValidos()
        {
            List<Produtos> listaProdutos = new List<Produtos>();
            List<EFinalidade> listaFinalidades = new List<EFinalidade>();

            listaProdutos.Add(new Produtos { codigo = "1", codImendes = "", codInterno = "", descricao = "Produto Teste 1", empresaID = 1, filialID = 1, ncm = "12345678", origemMercadoria = 0, produtoID = 1 });
            listaProdutos.Add(new Produtos { codigo = "2", codImendes = "", codInterno = "", descricao = "Produto Teste 2", empresaID = 1, filialID = 1, ncm = "12345678", origemMercadoria = 0, produtoID = 2 });
            listaProdutos.Add(new Produtos { codigo = "3", codImendes = "", codInterno = "", descricao = "Produto Teste 3", empresaID = 1, filialID = 1, ncm = "12345678", origemMercadoria = 0, produtoID = 3 });

            listaFinalidades.Add(EFinalidade.Revenda);
            listaFinalidades.Add(EFinalidade.UsoEConsumoOuAtivoImobilizado);

            var resultado = _calculoRequisicoesServico.RetornarNumeroRequisicoesIMendesEstimadasParaProcessamentoCenario(200, listaProdutos, listaFinalidades);

            Assert.IsTrue(resultado > 0);
        }

    }
}
