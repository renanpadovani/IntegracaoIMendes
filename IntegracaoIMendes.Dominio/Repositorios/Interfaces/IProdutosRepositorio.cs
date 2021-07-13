using IntegracaoIMendes.Dominio.Entidades.Infast;
using System;
using System.Collections.Generic;

namespace IntegracaoIMendes.Dominio.Repositorios.Interfaces
{
    public interface IProdutosRepositorio
    {
        public IEnumerable<Produtos> PesquisarProdutos(Int64 produtoId = 0, string tipoClassificacao = "");
    }
}
