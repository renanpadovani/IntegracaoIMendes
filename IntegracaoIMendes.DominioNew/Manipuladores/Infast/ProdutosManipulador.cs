using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegracaoIMendes.Dominio.Manipuladores
{
    public class ProdutosManipulador
    {
        private readonly IProdutosRepositorio _repositorio;

        public ProdutosManipulador(IProdutosRepositorio produtoRepositorio)
        {
            _repositorio = produtoRepositorio;
        }

        public IEnumerable<Produtos> PesquisarProdutos(Int64 produtoId = 0, string tipoClassificacao = "")
        {
            try
            {
                return _repositorio.PesquisarProdutos(produtoId, tipoClassificacao).OrderBy(o => o.origemMercadoria);
            }
            catch (Exception)
            {
                IEnumerable<Produtos> empty = Enumerable.Empty<Produtos>();
                return empty;
            }
        }
    }
}
