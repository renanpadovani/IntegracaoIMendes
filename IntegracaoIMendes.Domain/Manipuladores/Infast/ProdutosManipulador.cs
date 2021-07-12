using IntegracaoIMendes.Dominio.ContextoDados;
using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegracaoIMendes.Dominio.Manipuladores
{
    public class ProdutosManipulador
    {
        private readonly InfastContextoDados _contexto;
        private ProdutosRepositorio _produtoRepositorio;

        public ProdutosManipulador(InfastContextoDados contexto)
        {
            _contexto = contexto;
            _produtoRepositorio = new ProdutosRepositorio(_contexto);
        }

        public IEnumerable<Produtos> PesquisarProdutos(Int64 produtoId = 0, string tipoClassificacao = "")
        {
            return _produtoRepositorio.PesquisarProdutos(produtoId, tipoClassificacao).OrderBy(o => o.origemMercadoria);
        }
    }
}
