using IntegracaoIMendes.Dominio.Entidades.Infast;
using System;

namespace IntegracaoIMendes.Dominio.Repositorios.Interfaces
{
    public interface IProcessamentoCenariosRepositorio
    {
        public Int64 IncluirProcessamentoCenario(ProcessamentoCenarios processamentoCenario);

        public Int64 RetornarNumeroRequisicoesConsumidas(DateTime data);
    }
}
