using IntegracaoIMendes.Dominio.Entidades.Infast;
using System;
using System.Collections.Generic;

namespace IntegracaoIMendes.Dominio.Repositorios.Interfaces
{
    public interface ICenariosRepositorio
    {
        IEnumerable<Cenarios> PesquisarCenarios();

        Cenarios CarregarCenario(Int64 Id);

        Int64 IncluirCenario(Cenarios cenario);

        void AlterarCenario(Cenarios cenario);
    }
}
