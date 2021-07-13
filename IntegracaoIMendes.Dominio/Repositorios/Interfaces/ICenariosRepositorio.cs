using IntegracaoIMendes.Dominio.Entidades.Infast;
using System;
using System.Collections.Generic;

namespace IntegracaoIMendes.Dominio.Repositorios.Interfaces
{
    public interface ICenariosRepositorio
    {
        public IEnumerable<Cenarios> PesquisarCenarios();

        public Cenarios CarregarCenario(Int64 Id);

        public Int64 IncluirCenario(Cenarios cenario);

        public void AlterarCenario(Cenarios cenario);
    }
}
