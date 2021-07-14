using IntegracaoIMendes.Dominio.Entidades.Infast;
using System;
using System.Collections.Generic;
using IntegracaoIMendes.Dominio.Repositorios.Interfaces;
using System.Linq;

namespace IntegracaoIMendes.Dominio.Manipuladores.Infast
{
    public class CenariosManipulador
    {
        private readonly ICenariosRepositorio _cenarioRepositorio;

        public CenariosManipulador(ICenariosRepositorio cenarioRepositorio)
        {
            _cenarioRepositorio = cenarioRepositorio;
        }

        public IEnumerable<Cenarios> CarregarListaCenarios()
        {
            try
            {
                return _cenarioRepositorio.PesquisarCenarios();
            }
            catch (Exception)
            {
                IEnumerable<Cenarios> empty = Enumerable.Empty<Cenarios>();
                return empty;
            }  
        }

        public Cenarios CarregarCenario(Int64 Id)
        {
            return _cenarioRepositorio.CarregarCenario(Id);
        }

        public Cenarios IncluirCenario(Cenarios novoCenario)
        {
            novoCenario.Validar();
                
            novoCenario.ID = _cenarioRepositorio.IncluirCenario(novoCenario);

            return novoCenario;
        }

        public void InativarCenario(Int64 Id)
        {
            Cenarios cenario = _cenarioRepositorio.CarregarCenario(Id);

            cenario.InativarCenario();

            _cenarioRepositorio.AlterarCenario(cenario);
        }

        public void AtualizarDataProcessamentoCenario(Int64 Id)
        {
            Cenarios cenario = _cenarioRepositorio.CarregarCenario(Id);

            cenario.AtualizarDataProcessamento();

            _cenarioRepositorio.AlterarCenario(cenario);
        }
    }
}
