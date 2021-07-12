using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Modelos;

namespace IntegracaoIMendes.Dominio.Mapeamentos
{
    public class ProcessamentoCenariosMapeamento
    {
        UFsMapeamento _ufMapp;
        EnumFinalidadesMapeamento _finalidadeMapp;
        EnumCaracteristicasTributariasMapeamento _caracteristicaMapp;

        public ProcessamentoCenariosMapeamento()
        {
            _ufMapp = new UFsMapeamento();
            _finalidadeMapp = new EnumFinalidadesMapeamento();
            _caracteristicaMapp = new EnumCaracteristicasTributariasMapeamento();
        }

        public ProcessamentoCenarios Mapp(ProcessamentoCenariosModelo processamentoCenariosModelo)
        {
            ProcessamentoCenarios processamentoCenario = null;

            if (processamentoCenariosModelo != null)
            {
                processamentoCenario = new ProcessamentoCenarios();

                processamentoCenario.ID = processamentoCenariosModelo.ID;
                processamentoCenario.EmpresaID = processamentoCenariosModelo.EmpresaID;
                processamentoCenario.FilialID = processamentoCenariosModelo.FilialID;
                processamentoCenario.Data = processamentoCenariosModelo.Data;
                processamentoCenario.CenarioID = processamentoCenariosModelo.CenarioID;
                processamentoCenario.Finalidades = _finalidadeMapp.Mapp(processamentoCenariosModelo.Finalidades);
                processamentoCenario.CaracteristicasTributarias = _caracteristicaMapp.Mapp(processamentoCenariosModelo.CaracteristicasTributarias);
                processamentoCenario.UFs = _ufMapp.Mapp(processamentoCenariosModelo.UFs);
                processamentoCenario.QtdProdutos = processamentoCenariosModelo.QtdProdutos;
                processamentoCenario.QtdOrigensProdutos = processamentoCenariosModelo.QtdOrigensProdutos;
                processamentoCenario.QtdRequisicoesRealizadas = processamentoCenariosModelo.QtdRequisicoesRealizadas;
                processamentoCenario.Mensagem = processamentoCenariosModelo.Mensagem;
            }

            return processamentoCenario;
        }

        public ProcessamentoCenariosModelo Mapp(ProcessamentoCenarios processamentoCenario)
        {
            ProcessamentoCenariosModelo processamentoCenariosModelo = null;

            if (processamentoCenario != null)
            {
                processamentoCenariosModelo = new ProcessamentoCenariosModelo();

                processamentoCenariosModelo.ID = processamentoCenario.ID;
                processamentoCenariosModelo.EmpresaID = processamentoCenario.EmpresaID;
                processamentoCenariosModelo.FilialID = processamentoCenario.FilialID;
                processamentoCenariosModelo.Data = processamentoCenario.Data;
                processamentoCenariosModelo.CenarioID = processamentoCenario.CenarioID;
                processamentoCenariosModelo.Finalidades = _finalidadeMapp.Mapp(processamentoCenario.Finalidades);
                processamentoCenariosModelo.CaracteristicasTributarias = _caracteristicaMapp.Mapp(processamentoCenario.CaracteristicasTributarias);
                processamentoCenariosModelo.UFs = _ufMapp.Mapp(processamentoCenario.UFs);
                processamentoCenariosModelo.QtdProdutos = processamentoCenario.QtdProdutos;
                processamentoCenariosModelo.QtdOrigensProdutos = processamentoCenario.QtdOrigensProdutos;
                processamentoCenariosModelo.QtdRequisicoesRealizadas = processamentoCenario.QtdRequisicoesRealizadas;
                processamentoCenariosModelo.Mensagem = processamentoCenario.Mensagem;
            }

            return processamentoCenariosModelo;
        }
    }
}
