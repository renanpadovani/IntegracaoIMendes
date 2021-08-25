using IntegracaoIMendes.Dominio.Entidades.Infast;
using System;
using System.Collections.Generic;
using IntegracaoIMendes.Dominio.Repositorios.Interfaces;
using System.Linq;

namespace IntegracaoIMendes.Dominio.Manipuladores.Infast
{
    public class CenariosManipulador
    {
        private readonly ICenariosRepositorio _Repositorio;

        public CenariosManipulador(ICenariosRepositorio cenarioRepositorio)
        {
            _Repositorio = cenarioRepositorio;
        }

        public IEnumerable<Cenarios> CarregarListaCenarios()
        {
            try
            {
                return _Repositorio.PesquisarCenarios();
            }
            catch (Exception)
            {
                IEnumerable<Cenarios> empty = Enumerable.Empty<Cenarios>();
                return empty;
            }  
        }

        public Cenarios CarregarCenario(Int64 Id)
        {
            return _Repositorio.CarregarCenario(Id);
        }

        public Cenarios IncluirCenario(Cenarios novoCenario)
        {
            novoCenario.Validar();
                
            novoCenario.ID = _Repositorio.IncluirCenario(novoCenario);

            return novoCenario;
        }

        public void InativarCenario(Int64 Id)
        {
            Cenarios cenario = _Repositorio.CarregarCenario(Id);

            cenario.InativarCenario();

            _Repositorio.AlterarCenario(cenario);
        }

        public void AtualizarDataProcessamentoCenario(Int64 Id)
        {
            Cenarios cenario = _Repositorio.CarregarCenario(Id);

            cenario.AtualizarDataProcessamento();

            _Repositorio.AlterarCenario(cenario);
        }
    }
}
