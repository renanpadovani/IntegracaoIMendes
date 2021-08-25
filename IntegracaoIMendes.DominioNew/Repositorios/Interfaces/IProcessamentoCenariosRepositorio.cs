using IntegracaoIMendes.Dominio.Entidades.Infast;
using System;

namespace IntegracaoIMendes.Dominio.Repositorios.Interfaces
{
    public interface IProcessamentoCenariosRepositorio
    {
        Int64 IncluirProcessamentoCenario(ProcessamentoCenarios processamentoCenario);

        Int64 RetornarNumeroRequisicoesConsumidas(DateTime data);
    }
}
