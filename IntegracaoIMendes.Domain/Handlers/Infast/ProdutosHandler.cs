using IntegracaoIMendes.Domain.Entities.Infast;
using IntegracaoIMendes.Domain.Enums;
using IntegracaoIMendes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegracaoIMendes.Domain.Handlers
{
    public class ProdutosHandler
    {
        private readonly ProdutosRepositorio _produtoRepositorio;

        public ProdutosHandler(ProdutosRepositorio produtoRepository)
        {
            _produtoRepositorio = produtoRepository;
        }

        public IEnumerable<Produtos> PesquisarProdutos(Int64 produtoId = 0, string tipoClassificacao = "")
        {
            return _produtoRepositorio.PesquisarProdutos(produtoId, tipoClassificacao).OrderBy(o => o.origemMercadoria);
        }
    }
}
