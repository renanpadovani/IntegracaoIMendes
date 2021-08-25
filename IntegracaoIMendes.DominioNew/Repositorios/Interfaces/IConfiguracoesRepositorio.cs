using IntegracaoIMendes.Dominio.Entidades.Infast;
using System;

namespace IntegracaoIMendes.Dominio.Repositorios.Interfaces
{
    public interface IConfiguracoesRepositorio
    {
        Configuracoes CarregarConfiguracao();

        Int64 IncluirConfiguracao(Configuracoes config);
    }
}
