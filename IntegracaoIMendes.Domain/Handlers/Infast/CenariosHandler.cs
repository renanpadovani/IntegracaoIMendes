using IntegracaoIMendes.Domain.Entities.Infast;
using IntegracaoIMendes.Domain.Enums;
using IntegracaoIMendes.Domain.Repositories;
using System;
using System.Collections.Generic;


namespace IntegracaoIMendes.Domain.Handlers.Infast
{
    public class CenariosHandler
    {
        private readonly CenariosRepositorio _repositorio;

        public CenariosHandler(CenariosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Cenarios> CarregarListaCenarios()
        { 
            return _repositorio.CarregarListaCenarios();
        }

        public Cenarios CarregarCenario(Int64 Id)
        {
            return _repositorio.CarregarCenario(Id);
        }

        public Cenarios IncluirCenario(string ufCliente,
                                    string cfop,
                                    ECodRegimeTributario codRegimeTributario,
                                    string regimeTributario,
                                    List<EFinalidade> finalidades,
                                    List<ECaracteristicaTributaria> caracteristicasTributarias,
                                    List<string> ufs,
                                    string tipoProduto,
                                    Int16 IntervaloDeBuscaEmDias)
        {
            Cenarios novoCenario = new Cenarios();

            novoCenario.UfCliente = ufCliente;
            novoCenario.CFOP = cfop;
            novoCenario.CodRegimeTributario = codRegimeTributario;
            novoCenario.RegimeTributario = regimeTributario;
            novoCenario.Finalidades = finalidades;
            novoCenario.CaracteristicasTributarias = caracteristicasTributarias;
            novoCenario.UFs = ufs;
            novoCenario.TipoProduto = tipoProduto;
            novoCenario.IntervaloDeBuscaEmDias = IntervaloDeBuscaEmDias;

            novoCenario.Validar();

            novoCenario.ID = _repositorio.IncluirCenario(novoCenario);

            return novoCenario;
        }

        public void InativarCenario(Int64 Id)
        {
            Cenarios cenario = _repositorio.CarregarCenario(Id);

            cenario.InativarCenario();

            _repositorio.AlterarCenario(cenario);
        }

        public void AtualizarDataProcessamentoCenario(Int64 Id)
        {
            Cenarios cenario = _repositorio.CarregarCenario(Id);

            cenario.AtualizarDataProcessamento();

            _repositorio.AlterarCenario(cenario);
        }
    }
}
