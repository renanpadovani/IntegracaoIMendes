using IntegracaoIMendes.Dominio.Entidades.Infast;
using System;

namespace IntegracaoIMendes.Dominio.Repositorios.Interfaces
{
    public interface IConfiguracoesRepositorio
    {
        public Configuracoes CarregarConfiguracao();

        public Int64 IncluirConfiguracao(Configuracoes config);
    }
}
